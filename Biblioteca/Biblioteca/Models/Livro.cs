using Biblioteca.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Igor_Livro")]
    public class Livro : BaseEntity
    {
        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("NumeroPaginas")]
        public int NumeroPaginas { get; set; }

        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }

        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        public int EditoraId { get; set; }
        public virtual Editora Editora { get; set; }
    }
}
