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
    [HttpPost("CartUpsert")]
    public async Task<ResponseDto> CartUpsert(CartDto cartDto)
    {
       
        try
        {
            var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(u => u.Id == cartDto.CartHeader.Id);
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
                var cartDetailsFromDb = await _db.CartDetails.FirstOrDefaultAsync(u =>
                u.ProductId == cartDto.CartDetails
                .First().ProductId && u.CartHeaderId == cartHeaderFromDb.Id);

                if(cartDetailsFromDb == null)
                {
                    //create cartdetails
                }
                else
                {
                    //update count in cart details
                }
            }
        }
        catch (Exception ex)
        {
            _response.Message = ex.Message.ToString();
            _response.IsSuccess = false;
        }
    }
}
