using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.implementacoes
{
    public class EmprestimoBusiness : IEmprestimoBusiness
    {
        private IEmprestimoRepository _repository;

        public EmprestimoBusiness(IEmprestimoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Emprestimo> Create(Emprestimo obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Emprestimo>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Emprestimo> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Emprestimo> Update(Emprestimo obj)
        {
            return await _repository.Update(obj);
        }

        public async Task<int> GetDia(int data)
        {
            return await _repository.GetDia(data);
        }
        public async Task<int> GetMes(int data)
        {
            return await _repository.GetMes(data);
        }

        public async Task<int> GetDevolucaoAtrasada(int data)
        {
            return await _repository.GetDevolucaoAtrasada(data);
        }

        public async Task<Emprestimo> DevolucaoAtrasadaLeitor(int id)
        {
            return await _repository.DevolucaoAtrasadaLeitor(id);
            ;
        }
    }
}