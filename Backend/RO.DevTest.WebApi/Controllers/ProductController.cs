using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;
using RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;
using RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;
using RO.DevTest.Application.Features.Product.Queries;
using RO.DevTest.Domain.Exception;


namespace RO.DevTest.WebApi.Controllers;

[ApiController]
[Route("api/product")]
[OpenApiTags("Products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {

        if (command == null)
        {
            _logger.LogError("CreateProduct - The command receive is null.");
            throw new BadRequestException("Product cannot be null");
        }

        try
        {
            _logger.LogInformation($"CreateProduct: {command.Name}, preço: {command.Price}, estoque: {command.Stock}");

            var result = await _mediator.Send(command);

            if (result != null)
            {
                _logger.LogInformation("CreateProduct - Producct created with success.");
                return Ok(result);
            }

            return StatusCode(500, "Error during create product.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateById([FromBody] UpdateProductCommand command, Guid id)
    {
        if (id != command.ProductId)
        {
            throw new BadRequestException("Product ID not found");
        }
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromBody] DeleteProductCommand command, Guid id)
    {
        if (id != command.ProductId)
        {
            throw new BadRequestException("Product ID not Found");
        }
        var result = await _mediator.Send(new DeleteProductCommand { ProductId = id});
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

}
