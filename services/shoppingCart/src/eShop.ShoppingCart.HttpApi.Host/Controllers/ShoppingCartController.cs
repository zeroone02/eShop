using AutoMapper;
using eShop.DDD.Application.Contracts;
using eShop.DDD.Entity;
using eShop.ShoppingCartService.Application.Contracts;
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
    private IProductService _productService;
    private ICouponService _couponService;
    public ShoppingCartController(UnitOfWork unitOfWork, IMapper mapper, ShoppingCartServiceDbContext db, IProductService productService, ICouponService couponService)
    {
        _unitOfWork = unitOfWork;
        _response = new ResponseDto();
        _mapper = mapper;
        _db = db;
        _productService = productService;
        _couponService = couponService;
    }
    [HttpGet("GetCart/{userId}")]
    public async Task<ResponseDto> GetCart(string userId)
    {
        try
        {
            CartDto cart = new()
            {
                CartHeader = _mapper.Map<CartHeaderDto>(_db.CartHeaders.First(u => u.UserId == userId))
            };
            cart.CartDetails = _mapper.Map<IEnumerable<CartDetailsDto>>(_db.CartDetails
                .Where(u => u.CartHeaderId == cart.CartHeader.Id));

            IEnumerable<ProductDto> productDtos = await _productService.GetProducts();
            //
            foreach (var item in cart.CartDetails)
            {
                item.Product = productDtos.FirstOrDefault(u => u.Id == item.ProductId);
                if (item.Product == null)
                {
                    await RemoveCart(item.Id);
                }
            }
            //fix bag
            CartDto newCart = new()
            {
                CartHeader = _mapper.Map<CartHeaderDto>(_db.CartHeaders.First(u => u.UserId == userId))
            };
            newCart.CartDetails = _mapper.Map<IEnumerable<CartDetailsDto>>(_db.CartDetails
                .Where(u => u.CartHeaderId == newCart.CartHeader.Id));
            foreach (var newItem in newCart.CartDetails)
            {
                newItem.Product = productDtos.FirstOrDefault(u => u.Id == newItem.ProductId);
                newCart.CartHeader.CartTotal += (newItem.Count * newItem.Product.Price);
            }

            //apply coupon if any
            if (!string.IsNullOrEmpty(newCart.CartHeader.CouponCode))
            {
                CouponDto coupon = await _couponService.GetCoupon(newCart.CartHeader.CouponCode);
                if (coupon != null && newCart.CartHeader.CartTotal > coupon.MinAmount)
                {
                    newCart.CartHeader.CartTotal -= coupon.DiscountAmount;
                    newCart.CartHeader.Discount = coupon.DiscountAmount;
                }
            }

            _response.Result = newCart;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpPost("ApplyCoupon")]
    public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
    {
        try
        {
            var cartFromDb = _db.CartHeaders.First(u => u.UserId == cartDto.CartHeader.UserId);
            cartFromDb.CouponCode = cartDto.CartHeader.CouponCode;
            _db.CartHeaders.Update(cartFromDb);
            await _unitOfWork.SaveChangesAsync();
            _response.Result = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.ToString();
        }
        return _response;
    }

    [HttpPost("RemoveCoupon")]
    public async Task<object> RemoveCoupon([FromBody] CartDto cartDto)
    {
        try
        {
            var cartFromDb = _db.CartHeaders.First(u => u.UserId == cartDto.CartHeader.UserId);
            cartFromDb.CouponCode = "";
            _db.CartHeaders.Update(cartFromDb);
            await _unitOfWork.SaveChangesAsync();
            _response.Result = true;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.ToString();
        }
        return _response;
    }


    [HttpPost("CartUpsert")]
    public async Task<ResponseDto> CartUpsert(CartDto cartDto)
    {

        try
        {
            var cartHeaderFromDb = await _db.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader.UserId);
            if (cartHeaderFromDb == null)
            {
                //create header and details
                CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                _db.CartHeaders.Add(cartHeader);
                await _db.SaveChangesAsync();
                cartDto.CartDetails.First().CartHeaderId = cartHeader.Id;
                _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                await _db.SaveChangesAsync();
            }
            else
            {
                //if header is not null
                //check if details has same product
                var cartDetailsFromDb = await _db.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    u => u.ProductId == cartDto.CartDetails.First().ProductId &&
                    u.CartHeaderId == cartHeaderFromDb.Id);
                if (cartDetailsFromDb == null)
                {
                    //create cartdetails
                    cartDto.CartDetails.First().CartHeaderId = cartHeaderFromDb.Id;
                    _db.CartDetails.Add(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                    await _db.SaveChangesAsync();
                }
                else
                {
                    //update count in cart details
                    cartDto.CartDetails.First().Count += cartDetailsFromDb.Count;
                    cartDto.CartDetails.First().CartHeaderId = cartDetailsFromDb.CartHeaderId;
                    cartDto.CartDetails.First().Id = cartDetailsFromDb.Id;
                    _db.CartDetails.Update(_mapper.Map<CartDetails>(cartDto.CartDetails.First()));
                    await _db.SaveChangesAsync();
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
