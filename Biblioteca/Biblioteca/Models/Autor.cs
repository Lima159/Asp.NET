using Biblioteca.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Igor_Autor")]
    public class Autor : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
    }
}
