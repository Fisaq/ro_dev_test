using RO.DevTest.Application.Contracts.Persistance.Repositories;    
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories
{
    public class ClientRepository(DefaultContext context) : BaseRepository<Client>(context), IClientRepository { }
}
