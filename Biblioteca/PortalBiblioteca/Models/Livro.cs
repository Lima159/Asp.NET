using PortalBiblioteca.Models.Base;

namespace PortalBiblioteca.Models
{
    public class Livro : BaseEntity
    {
        public string Titulo { get; set; }
        public int NumeroPaginas { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        public int EditoraId { get; set; }
        public virtual Editora Editora { get; set; }
    }
}
