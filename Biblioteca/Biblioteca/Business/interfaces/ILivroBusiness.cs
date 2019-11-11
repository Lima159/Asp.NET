using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.interfaces
{
    public interface ILivroBusiness
    {
        Task<Livro> Create(Livro obj);
        Task<Livro> Update(Livro obj);
        Task<Livro> FindById(int id);
        Task<ICollection<Livro>> FindAll();
        Task Delete(int id);
        Task<ICollection<Livro>> FindByTitulo(string titulo);
        Task<ICollection<Livro>> FindByAutor(string autor);
        Task<ICollection<Livro>> FindByEditora(string editora);
    }
}
