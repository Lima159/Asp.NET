using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("genero")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GeneroController : ControllerBase
    {
        private IGeneroBusiness _generoBusiness;

        public GeneroController(IGeneroBusiness generobusiness)
        {
            _generoBusiness = generobusiness;
        }

        #region POST
        [HttpPost(Name = "CreateGenero")]
        public async Task<IActionResult> Create([FromBody]Genero obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                var newgenero = await _generoBusiness.Create(obj);
                return CreatedAtRoute("GetByIdGenero", new { id = newgenero.Id }, newgenero);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }
        #endregion

        #region GET
        [HttpGet("{id}", Name = "GetByIdGenero")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var newgenero = await _generoBusiness.FindById(Convert.ToInt32(id));
                if (newgenero == null)
                    return NotFound();

                return Ok(newgenero);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet(Name = "GetAllGenero")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newgeneros = await _generoBusiness.FindAll();
                return Ok(newgeneros);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut(Name = "UpdateGenero")]
        public async Task<IActionResult> Update(Genero obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest();

                var newgenero = await _generoBusiness.FindById(obj.Id);
                if (newgenero == null)
                    return NotFound();

                var putGenero = await _generoBusiness.Update(obj);
                return CreatedAtRoute("GetByIdGenero", new { id = putGenero.Id }, putGenero);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteGenero")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return NotFound();

                await _generoBusiness.Delete(Convert.ToInt32(id));
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
