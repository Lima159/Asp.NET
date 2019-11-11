using Biblioteca.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Igor_Leitor")]
    public class Leitor : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("DataNascimento ")]
        public DateTime DataNascimento { get; set; }
    }
}
