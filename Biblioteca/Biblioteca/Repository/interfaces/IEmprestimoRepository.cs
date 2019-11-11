using Biblioteca.Models;
using System.Threading.Tasks;

namespace Biblioteca.Repository.interfaces
{
    public interface IEmprestimoRepository : IGenericRepository<Emprestimo>
    {
        Task<int> GetDia(int data);
        Task<int> GetMes(int data);
        Task<Emprestimo> DevolucaoAtrasadaLeitor(int id);
        Task<int> GetDevolucaoAtrasada(int data);
    }
}
