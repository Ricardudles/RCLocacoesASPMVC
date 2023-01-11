using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;
using RCLocacoes.Infra.Data.Repository.Interfaces;

namespace RCLocacoes.Infra.Data.Repository
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
