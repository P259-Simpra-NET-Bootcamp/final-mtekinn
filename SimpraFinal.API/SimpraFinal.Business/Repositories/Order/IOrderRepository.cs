using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    Task<Order> GetOrderByOrderNumberAsync(string orderNumber);
    Task<IEnumerable<Order>> GetUnpaidOrdersAsync();
    Task MarkAsPaidAsync(int id);
    Task<Order> GetOrderWithDetailsByIdAsync(int id);
}