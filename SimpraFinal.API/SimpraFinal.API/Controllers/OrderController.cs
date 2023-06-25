using AutoMapper;
using SimpraFinal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;

namespace SimpraFinal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    // GET: api/Orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(_mapper.Map<IEnumerable<OrderDTO>>(orders));
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDTO>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrderDTO>(order));
    }

    // POST: api/Orders
    [HttpPost]
    public async Task<ActionResult<OrderDTO>> PostOrder(OrderDTO orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        await _orderService.CreateOrderAsync(order);

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, _mapper.Map<OrderDTO>(order));
    }

    // PUT: api/Orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, OrderDTO orderDto)
    {
        if (id != orderDto.Id)
        {
            return BadRequest();
        }

        var order = _mapper.Map<Order>(orderDto);
        await _orderService.UpdateOrderAsync(order);

        return NoContent();
    }

    // PUT: api/Orders/5/MarkAsPaid
    [HttpPut("{id}/MarkAsPaid")]
    public async Task<IActionResult> MarkOrderAsPaid(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        await _orderService.MarkAsPaidAsync(id);

        return NoContent();
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        await _orderService.DeleteOrderAsync(id);

        return NoContent();
    }
}