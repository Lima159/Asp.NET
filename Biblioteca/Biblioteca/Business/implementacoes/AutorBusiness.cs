using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.implementacoes
{
    public class AutorBusiness : IAutorBusiness
    {
        private IAutorRepository _repository;

        public AutorBusiness(IAutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Autor> Create(Autor obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Autor>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Autor> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Autor> Update(Autor obj)
        {
            return await _repository.Update(obj);
        }
    }
}
