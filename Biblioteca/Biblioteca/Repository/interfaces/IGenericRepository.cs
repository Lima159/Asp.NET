using Biblioteca.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Repository.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<T> Delete(int id);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
    }
}
