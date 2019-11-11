using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.interfaces
{
    public interface ILeitorBusiness
    {
        Task<Leitor> Create(Leitor obj);
        Task<Leitor> Update(Leitor obj);
        Task<Leitor> FindById(int id);
        Task<ICollection<Leitor>> FindAll();
        Task Delete(int id);
    }
}
