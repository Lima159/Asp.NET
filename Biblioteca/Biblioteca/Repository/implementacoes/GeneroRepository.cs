using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;

namespace Biblioteca.Repository.implementacoes
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(BibliotecaContext context) : base(context) { }
    }
}
