using AutoMapper;
using SimpraFinal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SimpraFinal.API.DTOs;
using SimpraFinal.Business;

namespace SimpraFinal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ProductDTO>(product));
    }

    // POST: api/Products
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        product = await _productService.CreateProductAsync(product);

        productDto.MaxPoint = (int)product.MaxPoint;  // Compute MaxPoint
        productDto.PointEarningRate = product.PointEarningRate;  // Compute PointEarningRate

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, productDto);
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductDTO productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest();
        }

        var product = _mapper.Map<Product>(productDto);
        await _productService.UpdateProductAsync(product);

        productDto.MaxPoint = (int)product.MaxPoint;  // Compute MaxPoint
        productDto.PointEarningRate = product.PointEarningRate;  // Compute PointEarningRate

        return Ok(productDto);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        await _productService.DeleteProductAsync(id);

        return NoContent();
    }
}