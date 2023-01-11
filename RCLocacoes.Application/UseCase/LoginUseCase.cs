using RCLocacoes.Application.Interface;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Application.UseCase
{
    public class LoginUseCase : UseCaseBase<Login>, ILoginUseCase
    {
        private readonly ILoginRepository loginRepository;

        public LoginUseCase(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public void AddAccount(Login login)
        {
            loginRepository.Add(login);
        }
    }
}
