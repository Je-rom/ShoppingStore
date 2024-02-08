﻿using CouponWeb.Models;
using CouponWeb.Service.IService;
using CouponWeb.Utility;

namespace CouponWeb.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }


        public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.POST,
                Data = couponDto,
                Url = staticDetails.CouponAPIBase + "/api/coupon/" + couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.DELETE,
                Url = staticDetails.CouponAPIBase + "/api/coupon/"+ id

            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.CouponAPIBase + "/api/coupon"
                
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.CouponAPIBase + "/api/coupon/GetByCode/"+ couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.GET,
                Url = staticDetails.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = staticDetails.ApiType.PUT,
                Data = couponDto,
                Url = staticDetails.CouponAPIBase + "/api/coupon/" + couponDto
            });
        }
    }
}
