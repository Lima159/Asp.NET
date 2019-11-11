using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;

namespace Biblioteca.Repository.implementacoes
{
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaContext context) : base(context) { }
    }
}
