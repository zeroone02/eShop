using AutoMapper;
using eShop.DDD.Application.Contracts;
using eShop.DDD.Entity;
using eShop.ShoppingCartService.Domain;
using eShop.ShoppingCartService.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.ShoppingCartService.HttpApi.Host;
[Route("api/cart")]
[ApiController]
public class ShoppingCartController : Controller
{
    private UnitOfWork _unitOfWork;
    private IMapper _mapper;
    private ResponseDto _response;
    private readonly ShoppingCartServiceDbContext _db;
    public ShoppingCartController(UnitOfWork unitOfWork, IMapper mapper, ShoppingCartServiceDbContext db)
    {
        _unitOfWork = unitOfWork;
        _response = new ResponseDto();
        _mapper = mapper;
        _db = db;
    }
    [HttpGet("GetCart/{userId}")]
    public async Task<ResponseDto> GetCart(Guid userId)
    {
        try
        {
            CartDto cart = new()
            {
                CartHeader = _mapper.Map<CartHeaderDto>(_db.CartHeaders.First(u => u.UserId == userId))
            };
            cart.CartDetails = _mapper
                .Map<IEnumerable<CartDetailsDto>>(_db.CartDetails
                .Where(u => u.CartHeaderId == cart.CartHeader.Id));
            foreach (var item in cart.CartDetails)
            {
                cart.CartHeader.CartTotal += (item.Count * item.Product.Price);
            }
            _response.Result = cart;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }
    [HttpPost("CartUpsert")]
    public async Task<ResponseDto> CartUpsert(CartDto cartDto)
    {

        try
        {
            var cartHeaderFromDb = await _db.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == cartDto.CartHeader.Id);

            if (cartHeaderFromDb == null)
            {
                //create header and details
                CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                _db.CartHeaders.Add(cartHeader);
                await _unitOfWork.SaveChangesAsync();
                cartDto.CartDetails.First().CartHeaderId = cartHeader.Id;
                _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                await _unitOfWork.SaveChangesAsync();

            }
            else
            {
                //if header is not null
                //check if details has same product
                var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(u =>
                u.ProductId == cartDto.CartDetails
                .First().ProductId && u.CartHeaderId == cartHeaderFromDb.Id);

                if (cartDetailsFromDb == null)
                {
                    //create cartdetails
                    cartDto.CartDetails.First().CartHeaderId = cartHeaderFromDb.Id;
                    _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                    await _unitOfWork.SaveChangesAsync();
                }
                else
                {
                    //update count in cart details
                    cartDto.CartDetails.First().Count += cartDetailsFromDb.Count;
                    cartDto.CartDetails.First().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    cartDto.CartDetails.First().Id = cartDetailsFromDb.Id;
                    _db.CartDetails.Update(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            _response.Result = cartDto;
        }
        catch (Exception ex)
        {
            _response.Message = ex.Message.ToString();
            _response.IsSuccess = false;
        }
        return _response;
    }
    [HttpPost("RemoveCart")]
    public async Task<ResponseDto> RemoveCart([FromBody] Guid cartDetailsId)
    {

        try
        {
            CartDetails cartDetails = _db.CartDetails
                .First(u => u.Id == cartDetailsId);

            int totalCountofCartItem = _db.CartDetails
                .Where(u => u.CartHeaderId == cartDetails.CartHeaderId)
                .Count();
            _db.CartDetails.Remove(cartDetails);
            if (totalCountofCartItem == 1)
            {
                var cartHeaderToRemove = await _db.CartHeaders
                    .FirstOrDefaultAsync(u => u.Id == cartDetails.CartHeaderId);

                _db.CartHeaders.Remove(cartHeaderToRemove);
            }
            await _unitOfWork.SaveChangesAsync();

            _response.Result = true;
        }
        catch (Exception ex)
        {
            _response.Message = ex.Message.ToString();
            _response.IsSuccess = false;
        }
        return _response;
    }
}
