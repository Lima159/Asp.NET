using Biblioteca.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Igor_Emprestimo")]
    public class Emprestimo : BaseEntity
    {
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        public int LeitorId { get; set; }
        public virtual Leitor Leitor { get; set; }

        [Column("Data_Emprestimo")]
        public DateTime Data_Emprestimo { get; set; }

        [Column("Data_Expiracao")]
        public DateTime Data_Expiracao { get; set; }

        [Column("Data_Devolucao")]
        public DateTime Data_Devolucao { get; set; }
    }
}
