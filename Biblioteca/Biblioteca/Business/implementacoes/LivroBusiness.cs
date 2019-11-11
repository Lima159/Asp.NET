using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.implementacoes
{
    public class LivroBusiness : ILivroBusiness
    {
        private ILivroRepository _repository;

        public LivroBusiness(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Livro> Create(Livro obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Livro>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Livro> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Livro> Update(Livro obj)
        {
            return await _repository.Update(obj);
        }

        public async Task<ICollection<Livro>> FindByTitulo(string titulo)
        {
            return await _repository.FindByTitulo(titulo);
        }
        public async Task<ICollection<Livro>> FindByAutor(string autor)
        {
            return await _repository.FindByAutor(autor);
        }
        public async Task<ICollection<Livro>> FindByEditora(string editora)
        {
            return await _repository.FindByEditora(editora);
        }
    }
}
