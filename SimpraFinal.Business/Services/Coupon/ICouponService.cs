using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface ICouponService
{
    Task<List<Coupon>> GetAllCouponsAsync();
    Task<Coupon> GetCouponByIdAsync(int id);
    Task<Coupon> GetCouponByCodeAsync(string code);
    Task<List<Coupon>> GetActiveCouponsAsync();
    Task<Coupon> CreateCouponAsync(Coupon coupon);
    Task<Coupon> UpdateCouponAsync(Coupon coupon);
    Task DeleteCouponAsync(int id);
    Task MarkAsUsedAsync(int id);
}