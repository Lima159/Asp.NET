using PortalBiblioteca.Models.Base;
using System;

namespace PortalBiblioteca.Models
{
    public class Leitor : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
