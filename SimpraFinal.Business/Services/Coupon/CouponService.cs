using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class CouponService : ICouponService
{
    private readonly ICouponRepository _couponRepository;

    public CouponService(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public async Task<List<Coupon>> GetAllCouponsAsync()
    {
        return await _couponRepository.GetAllAsync();
    }

    public async Task<Coupon> GetCouponByIdAsync(int id)
    {
        return await _couponRepository.GetByIdAsync(id);
    }

    public async Task<Coupon> GetCouponByCodeAsync(string code)
    {
        return await _couponRepository.GetCouponByCodeAsync(code);
    }

    public async Task<List<Coupon>> GetActiveCouponsAsync()
    {
        return await _couponRepository.GetActiveCouponsAsync();
    }

    public async Task<Coupon> CreateCouponAsync(Coupon coupon)
    {
        await _couponRepository.CreateAsync(coupon);
        return coupon;
    }

    public async Task<Coupon> UpdateCouponAsync(Coupon coupon)
    {
        await _couponRepository.UpdateAsync(coupon);
        return coupon;
    }

    public async Task DeleteCouponAsync(int id)
    {
        await _couponRepository.DeleteAsync(id);
    }

    public async Task MarkAsUsedAsync(int id)
    {
        await _couponRepository.MarkAsUsedAsync(id);
    }
}