using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("autor")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AutorController : ControllerBase
    {
        private IAutorBusiness _autorBusiness;

        public AutorController(IAutorBusiness autorBusiness)
        {
            _autorBusiness = autorBusiness;
        }

        [HttpPost(Name = "CreateAutor")]
        public async Task<IActionResult> Create([FromBody]Autor obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                var newautor = await _autorBusiness.Create(obj);
                return CreatedAtRoute("GetByIdAutor", new { id = newautor.Id }, newautor);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        [HttpGet("{id}", Name = "GetByIdAutor")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var newautor = await _autorBusiness.FindById(Convert.ToInt32(id));
                if (newautor == null)
                    return NotFound();

                return Ok(newautor);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpPut(Name = "UpdateAutor")]
        public async Task<IActionResult> Update(Autor obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest();

                var newautor = await _autorBusiness.FindById(obj.Id);
                if (newautor == null)
                    return NotFound();

                var putAutor = await _autorBusiness.Update(obj);
                return CreatedAtRoute("GetByIdAutor", new { id = putAutor.Id }, putAutor);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpDelete("{id}", Name = "DeleteAutor")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return NotFound();

                await _autorBusiness.Delete(Convert.ToInt32(id));
                return Ok("Item Deletado");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet(Name = "GetAllAutor")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newautores = await _autorBusiness.FindAll();
                return Ok(newautores);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
