using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;
using RCLocacoes.Infra.Data.Repository.Interfaces;

namespace RCLocacoes.Infra.Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
