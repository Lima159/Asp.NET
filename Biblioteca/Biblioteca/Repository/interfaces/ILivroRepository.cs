using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Repository.interfaces
{
    public interface ILivroRepository : IGenericRepository<Livro>
    {
        Task<ICollection<Livro>> FindByTitulo(string titulo);
        Task<ICollection<Livro>> FindByAutor(string autor);
        Task<ICollection<Livro>> FindByEditora(string editora);
    }
}
