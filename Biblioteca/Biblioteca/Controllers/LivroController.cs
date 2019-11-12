using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("livro")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LivroController : ControllerBase
    {
        private ILivroBusiness _livroBusiness;

        public LivroController(ILivroBusiness livroBusiness)
        {
            _livroBusiness = livroBusiness;
        }

        #region POST
        [HttpPost(Name = "CreateLivro")]
        public async Task<IActionResult> Create([FromBody]Livro obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                var newlivro = await _livroBusiness.Create(obj);
                return CreatedAtRoute("GetByIdLivro", new { id = newlivro.Id }, newlivro);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }
        #endregion

        #region GET
        [HttpGet("{id}", Name = "GetByIdLivro")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var newlivro = await _livroBusiness.FindById(Convert.ToInt32(id));
                if (newlivro == null)
                    return NotFound();

                return Ok(newlivro);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet(Name = "GetAllLivro")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newlivros = await _livroBusiness.FindAll();
                return Ok(newlivros);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("findbytitulo", Name = "FindByTitulo")]
        public async Task<IActionResult> FindByTitulo(string titulo)
        {
            try
            {
                if (string.IsNullOrEmpty(titulo))
                    return BadRequest("Titulo não informado");

                var newlivros = await _livroBusiness.FindByTitulo(titulo);
                if (newlivros == null)
                    return NotFound("Titulo não existente");
                return Ok(newlivros);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("findbyautor", Name = "FindByAutor")]
        public async Task<IActionResult> FindByAutor(string autor)
        {
            try
            {
                if (string.IsNullOrEmpty(autor))
                    return BadRequest("Autor não informado");

                var newlivros = await _livroBusiness.FindByAutor(autor);
                if (newlivros == null)
                    return NotFound("Autor não existente");
                return Ok(newlivros);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("findbyeditora", Name = "FindByEditora")]
        public async Task<IActionResult> FindByEditora(string editora)
        {
            try
            {
                if (string.IsNullOrEmpty(editora))
                    return BadRequest("Editora não informada");

                var newlivros = await _livroBusiness.FindByEditora(editora);
                if (newlivros == null)
                    return NotFound("Editora não existente");
                return Ok(newlivros);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut(Name = "UpdateLivro")]
        public async Task<IActionResult> Update(Livro obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest();

                var newlivro = await _livroBusiness.FindById(obj.Id);
                if (newlivro == null)
                    return NotFound();

                var putLivro = await _livroBusiness.Update(obj);
                return CreatedAtRoute("GetByIdLivro", new { id = putLivro.Id }, putLivro);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteLivro")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return NotFound();

                await _livroBusiness.Delete(Convert.ToInt32(id));
                return Ok("Item Deletado");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion        
    }
}
