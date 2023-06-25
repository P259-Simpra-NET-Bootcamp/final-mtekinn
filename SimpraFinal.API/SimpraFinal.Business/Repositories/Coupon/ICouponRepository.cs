using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface ICouponRepository : IGenericRepository<Coupon>
{
    Task<Coupon> GetCouponByCodeAsync(string code);
    Task<List<Coupon>> GetActiveCouponsAsync();
    Task MarkAsUsedAsync(int id);
}