using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.interfaces
{
    public interface IAutorBusiness
    {
        Task<Autor> Create(Autor obj);
        Task<Autor> Update(Autor obj);
        Task<Autor> FindById(int id);
        Task<ICollection<Autor>> FindAll();
        Task Delete(int id);
    }
}
