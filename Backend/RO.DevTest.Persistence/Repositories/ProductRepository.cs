﻿using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories
{
    public class ProductRepository(DefaultContext context) : BaseRepository<Product>(context), IProductRepository { }
}
