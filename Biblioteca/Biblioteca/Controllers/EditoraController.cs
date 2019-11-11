using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("editora")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class EditoraController : ControllerBase
    {
        private IEditoraBusiness _editorabusiness;

        public EditoraController(IEditoraBusiness editorabusiness)
        {
            _editorabusiness = editorabusiness;
        }

        #region POST
        [HttpPost(Name = "CreateEditora")]
        public async Task<IActionResult> Create([FromBody]Editora obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                var neweditora = await _editorabusiness.Create(obj);
                return CreatedAtRoute("GetByIdEditora", new { id = neweditora.Id }, neweditora);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }
        #endregion

        #region GET
        [HttpGet("{id}", Name = "GetByIdEditora")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var neweditora = await _editorabusiness.FindById(Convert.ToInt32(id));
                if (neweditora == null)
                    return NotFound();

                return Ok(neweditora);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet(Name = "GetAllEditora")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var neweditoras = await _editorabusiness.FindAll();
                return Ok(neweditoras);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut(Name = "UpdateEditora")]
        public async Task<IActionResult> Update(Editora obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest();

                var neweditora = await _editorabusiness.FindById(obj.Id);
                if (neweditora == null)
                    return NotFound();

                var putEditora = await _editorabusiness.Update(obj);
                return CreatedAtRoute("GetByIdEditora", new { id = putEditora.Id }, putEditora);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteEditora")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return NotFound();

                await _editorabusiness.Delete(Convert.ToInt32(id));
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
