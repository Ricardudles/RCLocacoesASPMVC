using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Application.Interface
{
    public interface ILoginUseCase : IUseCaseBase<Login>
    {
        public void AddAccount(Login login);
        public bool VerifyAccount(Login login);
        public void UpdateAccount(Login login);
    }
}