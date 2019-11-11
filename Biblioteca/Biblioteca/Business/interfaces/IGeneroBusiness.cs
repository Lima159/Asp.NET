using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.interfaces
{
    public interface IGeneroBusiness
    {
        Task<Genero> Create(Genero obj);
        Task<Genero> Update(Genero obj);
        Task<Genero> FindById(int id);
        Task<ICollection<Genero>> FindAll();
        Task Delete(int id);
    }
}
