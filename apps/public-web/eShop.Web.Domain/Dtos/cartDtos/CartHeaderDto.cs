﻿using eShop.DDD.Application.Contracts;

namespace eShop.Web.Domain;
public class CartHeaderDto : EntityDto<Guid>
{
    public string? UserId { get; set; }
    public string? CouponCode { get; set; }
    public double Discount { get; set; }
    public double CartTotal { get; set; }
}
