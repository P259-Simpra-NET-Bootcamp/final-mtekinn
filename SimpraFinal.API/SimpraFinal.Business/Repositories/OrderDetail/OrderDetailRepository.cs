using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly SimpraFinalDbContext _context;
    
    public OrderDetailRepository(SimpraFinalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .Include(od => od.Product)
            .ToListAsync();
    }

    public async Task<int> GetTotalPointsByOrderIdAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.PointsEarned);
    }
    
    public async Task<decimal> GetTotalPriceByOrderIdAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity * od.Price);
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByProductIdAsync(int productId)
    {
        return await _context.OrderDetails
            .Where(od => od.ProductId == productId)
            .Include(od => od.Product)
            .ToListAsync();
    }
}