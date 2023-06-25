using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
{
    private readonly SimpraFinalDbContext _context;

    public CouponRepository(SimpraFinalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Coupon> GetCouponByCodeAsync(string code)
    {
        return await _context.Coupons.SingleOrDefaultAsync(c => c.Code == code && c.IsActive == true);
    }
    
    public async Task<List<Coupon>> GetActiveCouponsAsync()
    {
        return await _context.Coupons
            .Where(c => c.IsActive)
            .ToListAsync();
    }
    
    public async Task MarkAsUsedAsync(int id)
    {
        var coupon = await _context.Coupons.FindAsync(id);
        coupon.IsUsed = true;
        await _context.SaveChangesAsync();
    }
}