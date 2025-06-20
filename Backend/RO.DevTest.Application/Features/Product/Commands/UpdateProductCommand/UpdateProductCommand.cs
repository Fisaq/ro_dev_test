﻿using MediatR;
using RO.DevTest.Application.Features.Product.Response;

namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<ProductResponse>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
