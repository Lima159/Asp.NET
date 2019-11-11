using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.implementacoes
{
    public class GeneroBusiness : IGeneroBusiness
    {
        private IGeneroRepository _repository;

        public GeneroBusiness(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Genero> Create(Genero obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Genero>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Genero> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Genero> Update(Genero obj)
        {
            return await _repository.Update(obj);
        }
    }
}
