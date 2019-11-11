using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.interfaces
{
    public interface IEditoraBusiness
    {
        Task<Editora> Create(Editora obj);
        Task<Editora> Update(Editora obj);
        Task<Editora> FindById(int id);
        Task<ICollection<Editora>> FindAll();
        Task Delete(int id);
    }
}
