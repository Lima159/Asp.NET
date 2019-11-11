using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;

namespace Biblioteca.Repository.implementacoes
{
    public class LeitorRepository : GenericRepository<Leitor>, ILeitorRepository
    {
        public LeitorRepository(BibliotecaContext context) : base(context) { }
    }
}
