using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.implementacoes
{
    public class EditoraBusiness : IEditoraBusiness
    {
        private IEditoraRepository _repository;

        public EditoraBusiness(IEditoraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Editora> Create(Editora obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Editora>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Editora> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Editora> Update(Editora obj)
        {
            return await _repository.Update(obj);
        }
    }
}
