using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.implementacoes
{
    public class LeitorBusiness : ILeitorBusiness
    {
        private ILeitorRepository _repository;

        public LeitorBusiness(ILeitorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Leitor> Create(Leitor obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Leitor>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Leitor> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Leitor> Update(Leitor obj)
        {
            return await _repository.Update(obj);
        }
    }
}
