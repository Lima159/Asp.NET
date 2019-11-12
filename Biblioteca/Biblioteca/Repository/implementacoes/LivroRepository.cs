using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository.implementacoes
{
    public class LivroRepository : GenericRepository<Livro>, ILivroRepository
    {
        public LivroRepository(BibliotecaContext context) : base(context) { }
        public override async Task<Livro> FindById(int id)
        {
            return await _context.Livro
                .Include(livro => livro.Autor)
                .Include(livro => livro.Editora)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<ICollection<Livro>> FindByTitulo(string titulo)
        {
            return await _context.Livro
                .Where(livro => livro.Titulo.Equals(titulo))
                .ToListAsync();
        }

        public async Task<ICollection<Livro>> FindByAutor(string autor)
        {
            return await _context.Livro
                .Where(livro => livro.Autor.Nome.Equals(autor))
                .ToListAsync();
        }

        public async Task<ICollection<Livro>> FindByEditora(string editora)
        {
            return await _context.Livro
                .Where(livro => livro.Editora.Nome.Equals(editora))
                .ToListAsync();
        }
    }
}
