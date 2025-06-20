﻿using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using MediatR;
using RO.DevTest.Application.Features.Sale.Commands;
using RO.DevTest.Application.Features.Sale.Queries;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/sales")]
    [OpenApiTags("Sales")]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand command)
        {
            if (command == null)
            {
                return BadRequest("Sale cannot be null");
            }
            try
            {
                var result = await _mediator.Send(command);
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(500, "Error during create sale.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleById(Guid id)
        {
            var result = await _mediator.Send(new GetSaleByIdCommand (id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var result = await _mediator.Send(new GetAllSalesCommand());
            return Ok(result);
        }
    }

}
