using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IOrderService
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
    Task<Order> GetOrderByOrderNumberAsync(string orderNumber);
    Task<List<Order>> GetUnpaidOrdersAsync();
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
    Task<Order> GetOrderWithDetailsByIdAsync(int id);
    Task MarkAsPaidAsync(int id);
}