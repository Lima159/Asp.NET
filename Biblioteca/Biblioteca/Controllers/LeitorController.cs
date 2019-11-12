using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("leitor")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LeitorController : ControllerBase
    {
        private ILeitorBusiness _leitorBusiness;

        public LeitorController(ILeitorBusiness leitorBusiness)
        {
            _leitorBusiness = leitorBusiness;
        }

        [HttpPost(Name = "CreateLeitor")]
        public async Task<IActionResult> Create([FromBody]Leitor obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                var newleitor = await _leitorBusiness.Create(obj);
                return CreatedAtRoute("GetByIdLeitor", new { id = newleitor.Id }, newleitor);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        [HttpGet("{id}", Name = "GetByIdLeitor")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var newleitor = await _leitorBusiness.FindById(Convert.ToInt32(id));
                if (newleitor == null)
                    return NotFound();

                return Ok(newleitor);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpPut(Name = "UpdateLeitor")]
        public async Task<IActionResult> Update(Leitor obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest();

                var newleitor = await _leitorBusiness.FindById(obj.Id);
                if (newleitor == null)
                    return NotFound();

                var putLeitor = await _leitorBusiness.Update(obj);
                return CreatedAtRoute("GetByIdLeitor", new { id = putLeitor.Id }, putLeitor);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpDelete("{id}", Name = "DeleteLeitor")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return NotFound();

                await _leitorBusiness.Delete(Convert.ToInt32(id));
                return Ok("Item Deletado");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet(Name = "GetAllLeitor")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newleitores = await _leitorBusiness.FindAll();
                return Ok(newleitores);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
