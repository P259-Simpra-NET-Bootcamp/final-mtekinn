using AutoMapper;
using SimpraFinal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;

namespace SimpraFinal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMapper _mapper;
        
    public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
    {
        _orderDetailService = orderDetailService;
        _mapper = mapper;
    }

    // GET: api/OrderDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetails()
    {
        var orderDetails = await _orderDetailService.GetAllOrderDetailsAsync();
        return Ok(_mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetails));
    }

    // GET: api/OrderDetails/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailDTO>> GetOrderDetail(int id)
    {
        var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);

        if (orderDetail == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrderDetailDTO>(orderDetail));
    }

    // POST: api/OrderDetails
    [HttpPost]
    public async Task<ActionResult<OrderDetailDTO>> PostOrderDetail(OrderDetailDTO orderDetailDto)
    {
        var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
        await _orderDetailService.CreateOrderDetailAsync(orderDetail);

        orderDetailDto.PointsEarned = orderDetail.PointsEarned;  // Compute PointsEarned

        return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.Id }, orderDetailDto);
    }

    // PUT: api/OrderDetails/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrderDetail(int id, OrderDetailDTO orderDetailDto)
    {
        if (id != orderDetailDto.Id)
        {
            return BadRequest();
        }

        var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
        await _orderDetailService.UpdateOrderDetailAsync(orderDetail);

        orderDetailDto.PointsEarned = orderDetail.PointsEarned;  // Compute PointsEarned

        return Ok(orderDetailDto);
    }

    // DELETE: api/OrderDetails/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);
        if (orderDetail == null)
        {
            return NotFound();
        }

        await _orderDetailService.DeleteOrderDetailAsync(id);

        return NoContent();
    }
}