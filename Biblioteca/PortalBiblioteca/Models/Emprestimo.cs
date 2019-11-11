using PortalBiblioteca.Models.Base;
using System;

namespace PortalBiblioteca.Models
{
    public class Emprestimo : BaseEntity
    {
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }
        public int LeitorId { get; set; }
        public virtual Leitor Leitor { get; set; }
        public DateTime Data_Emprestimo { get; set; }
        public DateTime Data_Expiracao { get; set; }
        public DateTime Data_Devolucao { get; set; }
    }
}
