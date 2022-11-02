using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public char Nationality { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
