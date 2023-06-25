using AutoMapper;
using SimpraFinal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;

namespace SimpraFinal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponController : ControllerBase
{
    private readonly ICouponService _couponService;
    private readonly IMapper _mapper;

    public CouponController(ICouponService couponService, IMapper mapper)
    {
        _couponService = couponService;
        _mapper = mapper;
    }

    // GET: api/Coupons
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CouponDTO>>> GetCoupons()
    {
        var coupons = await _couponService.GetAllCouponsAsync();
        return Ok(_mapper.Map<IEnumerable<CouponDTO>>(coupons));
    }

    // GET: api/Coupons/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CouponDTO>> GetCoupon(int id)
    {
        var coupon = await _couponService.GetCouponByIdAsync(id);

        if (coupon == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CouponDTO>(coupon));
    }

    // POST: api/Coupons
    [HttpPost]
    public async Task<ActionResult<CouponDTO>> PostCoupon(CouponDTO couponDto)
    {
        var coupon = _mapper.Map<Coupon>(couponDto);
        await _couponService.CreateCouponAsync(coupon);

        return CreatedAtAction(nameof(GetCoupon), new { id = coupon.Id }, _mapper.Map<CouponDTO>(coupon));
    }

    // PUT: api/Coupons/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCoupon(int id, CouponDTO couponDto)
    {
        if (id != couponDto.Id)
        {
            return BadRequest();
        }

        var coupon = _mapper.Map<Coupon>(couponDto);
        await _couponService.UpdateCouponAsync(coupon);

        return NoContent();
    }

    // PUT: api/Coupons/5/MarkAsUsed
    [HttpPut("{id}/MarkAsUsed")]
    public async Task<IActionResult> MarkCouponAsUsed(int id)
    {
        var coupon = await _couponService.GetCouponByIdAsync(id);
        if (coupon == null)
        {
            return NotFound();
        }

        await _couponService.MarkAsUsedAsync(id);

        return NoContent();
    }

    // DELETE: api/Coupons/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        var coupon = await _couponService.GetCouponByIdAsync(id);
        if (coupon == null)
        {
            return NotFound();
        }

        await _couponService.DeleteCouponAsync(id);

        return NoContent();
    }
}