using AutoMapper;
using SimpraFinal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpraFinal.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductCategoryMapsController : ControllerBase
{
    private readonly IProductCategoryMapService _productCategoryMapService;
    private readonly IMapper _mapper;

    public ProductCategoryMapsController(IProductCategoryMapService productCategoryMapService, IMapper mapper)
    {
        _productCategoryMapService = productCategoryMapService;
        _mapper = mapper;
    }

    // GET: api/ProductCategoryMaps
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCategoryMapDTO>>> GetProductCategoryMaps()
    {
        var productCategoryMaps = await _productCategoryMapService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ProductCategoryMapDTO>>(productCategoryMaps));
    }

    // GET: api/ProductCategoryMaps/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategoryMapDTO>> GetProductCategoryMap(int id)
    {
        var productCategoryMap = await _productCategoryMapService.GetByIdAsync(id);

        if (productCategoryMap == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductCategoryMapDTO>(productCategoryMap));
    }

    // POST: api/ProductCategoryMaps
    [HttpPost]
    public async Task<ActionResult<ProductCategoryMapDTO>> PostProductCategoryMap(ProductCategoryMapDTO productCategoryMapDto)
    {
        var productCategoryMap = _mapper.Map<ProductCategoryMap>(productCategoryMapDto);
        await _productCategoryMapService.CreateAsync(productCategoryMap);

        productCategoryMapDto.Id = productCategoryMap.Id;

        return CreatedAtAction(nameof(GetProductCategoryMap), new { id = productCategoryMap.Id }, productCategoryMapDto);
    }

    // PUT: api/ProductCategoryMaps/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductCategoryMap(int id, ProductCategoryMapDTO productCategoryMapDto)
    {
        if (id != productCategoryMapDto.Id)
        {
            return BadRequest();
        }

        var productCategoryMap = _mapper.Map<ProductCategoryMap>(productCategoryMapDto);
        await _productCategoryMapService.UpdateAsync(productCategoryMap);

        return Ok(productCategoryMapDto);
    }

    // DELETE: api/ProductCategoryMaps/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductCategoryMap(int id)
    {
        var productCategoryMap = await _productCategoryMapService.GetByIdAsync(id);

        if (productCategoryMap == null)
        {
            return NotFound();
        }

        await _productCategoryMapService.DeleteAsync(id);

        return NoContent();
    }
}