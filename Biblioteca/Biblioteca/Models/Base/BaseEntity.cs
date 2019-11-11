using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
