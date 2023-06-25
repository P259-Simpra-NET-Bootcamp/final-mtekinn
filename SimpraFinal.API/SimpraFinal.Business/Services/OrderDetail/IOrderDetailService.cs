using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IOrderDetailService
{
    Task<List<OrderDetail>> GetAllOrderDetailsAsync();
    Task<OrderDetail> GetOrderDetailByIdAsync(int id);
    Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalPointsByOrderIdAsync(int orderId);
    Task<OrderDetail> CreateOrderDetailAsync(OrderDetail orderDetail);
    Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail);
    Task DeleteOrderDetailAsync(int id);
}