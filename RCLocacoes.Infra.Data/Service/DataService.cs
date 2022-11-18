using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Infra.Data.Service
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public DataService(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDB()
        {
            contexto.Database.Migrate();

            contexto.Set<Product>().Add(new Product
            {
                Name = "Louça",
                Description = "Louça bonitona",
                RentPrice = 29.50M,
                ReplacementCost = 31.23M,
                Inactive = false,
                Picture = "link"
            });

            contexto.SaveChanges();
        }

    }

}
