using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailService(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
    {
        return await _orderDetailRepository.GetAllAsync();
    }

    public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
    {
        return await _orderDetailRepository.GetByIdAsync(id);
    }
    
    public async Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return (List<OrderDetail>)await _orderDetailRepository.GetOrderDetailsByOrderIdAsync(orderId);
    }

    public async Task<int> GetTotalPointsByOrderIdAsync(int orderId)
    {
        return await _orderDetailRepository.GetTotalPointsByOrderIdAsync(orderId);
    }

    public async Task<OrderDetail> CreateOrderDetailAsync(OrderDetail orderDetail)
    {
        await _orderDetailRepository.CreateAsync(orderDetail);
        return orderDetail;
    }

    public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail)
    {
        await _orderDetailRepository.UpdateAsync(orderDetail);
        return orderDetail;
    }

    public async Task DeleteOrderDetailAsync(int id)
    {
        await _orderDetailRepository.DeleteAsync(id);
    }
}