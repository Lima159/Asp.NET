using Biblioteca.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Igor_Genero")]
    public class Genero : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
    }
}
