using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
    {
        return (List<Order>)await _orderRepository.GetOrdersByUserIdAsync(userId);
    }

    public async Task<Order> GetOrderByOrderNumberAsync(string orderNumber)
    {
        return await _orderRepository.GetOrderByOrderNumberAsync(orderNumber);
    }

    public async Task<List<Order>> GetUnpaidOrdersAsync()
    {
        return (List<Order>)await _orderRepository.GetUnpaidOrdersAsync();
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        await _orderRepository.CreateAsync(order);
        return order;
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        await _orderRepository.UpdateAsync(order);
        return order;
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _orderRepository.DeleteAsync(id);
    }
    
    public async Task<Order> GetOrderWithDetailsByIdAsync(int id)
    {
        return await _orderRepository.GetOrderWithDetailsByIdAsync(id);
    }
    
    public async Task MarkAsPaidAsync(int id)
    {
        await _orderRepository.MarkAsPaidAsync(id);
    }
}