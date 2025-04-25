using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RO.DevTest.Application.Features.Auth.Commands.LoginCommand;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.WebApi.Controllers
{
    [Route("api/product")]
    [OpenApiTags("Products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //[HttpPut]
        //[HttpDelete]
        //[HttpGet]

    }
}
