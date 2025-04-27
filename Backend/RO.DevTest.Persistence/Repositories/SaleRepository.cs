using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories
{
    public  class SaleRepository(DefaultContext context) : BaseRepository<Sale>(context), ISaleRepository { }

}
