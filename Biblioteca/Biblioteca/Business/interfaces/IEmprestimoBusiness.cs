using Biblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.interfaces
{
    public interface IEmprestimoBusiness
    {
        Task<Emprestimo> Create(Emprestimo obj);
        Task<Emprestimo> Update(Emprestimo obj);
        Task<Emprestimo> FindById(int id);
        Task<ICollection<Emprestimo>> FindAll();
        Task Delete(int id);
        Task<int> GetDia(int data);
        Task<int> GetMes(int data);
        Task<int> GetDevolucaoAtrasada(int data);

        Task<Emprestimo> DevolucaoAtrasadaLeitor(int id);
    }
}
