using Microsoft.EntityFrameworkCore;
using SimpraFinal.Data.Context;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly SimpraFinalDbContext _context;
    
    public OrderRepository(SimpraFinalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ToListAsync();
    }

    public async Task<Order> GetOrderByOrderNumberAsync(string orderNumber)
    {
        return await _context.Orders
            .Where(o => o.OrderNumber == orderNumber)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .SingleOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Order>> GetUnpaidOrdersAsync()
    {
        return await _context.Orders
            .Where(o => !o.IsPaid)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ToListAsync();
    }

    public async Task<Order> GetOrderWithDetailsByIdAsync(int id)
    {
        return await _context.Orders
            .Where(o => o.Id == id)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .SingleOrDefaultAsync();
    }
    
    public async Task MarkAsPaidAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            order.IsPaid = true;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Order with id {id} not found");
        }
    }
}