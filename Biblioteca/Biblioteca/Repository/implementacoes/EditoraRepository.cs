using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;

namespace Biblioteca.Repository.implementacoes
{
    public class EditoraRepository : GenericRepository<Editora>, IEditoraRepository
    {
        public EditoraRepository(BibliotecaContext context) : base(context) { }
    }
}
