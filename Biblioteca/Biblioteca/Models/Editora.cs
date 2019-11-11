using Biblioteca.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Igor_Editora")]
    public class Editora : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
    }
}
