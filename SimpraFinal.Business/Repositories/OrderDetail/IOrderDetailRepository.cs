using SimpraFinal.Business.Interfaces.BaseRepository;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business;

public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalPointsByOrderIdAsync(int orderId);
    Task<decimal> GetTotalPriceByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderDetail>> GetOrderDetailsByProductIdAsync(int productId);
}