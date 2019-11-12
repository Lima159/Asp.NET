using Biblioteca.Business.interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("emprestimo")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class EmprestimoController : ControllerBase
    {
        private IEmprestimoBusiness _emprestimoBusiness;

        public EmprestimoController(IEmprestimoBusiness emprestimoBusiness)
        {
            _emprestimoBusiness = emprestimoBusiness;
        }

        #region POST
        [HttpPost(Name = "CreateEmprestimo")]
        public async Task<IActionResult> Create([FromBody]Emprestimo obj)
        {
            try
            {
                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);
                
                var leitorAtrasado = await _emprestimoBusiness.DevolucaoAtrasadaLeitor(obj.LeitorId);
                if(leitorAtrasado != null)
                {
                    var numeroDeDias = (obj.Data_Emprestimo - leitorAtrasado.Data_Devolucao).TotalDays;

                    if (numeroDeDias <= 7)
                        return BadRequest("Leitor bloqueado a solicitação de livros.\r\nVolte daqui a " + (7 - numeroDeDias) + " dias");
                }
                
                var newemprestimo = await _emprestimoBusiness.Create(obj);
                return CreatedAtRoute("GetByIdEmprestimo", new { id = newemprestimo.Id }, newemprestimo);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }
        #endregion

        #region GET
        [HttpGet("emprestimo/{id}", Name = "GetByIdEmprestimo")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var newemprestimo = await _emprestimoBusiness.FindById(Convert.ToInt32(id));
                if (newemprestimo == null)
                    return NotFound();

                return Ok(newemprestimo);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("emprestimos", Name = "GetAllEmprestimo")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var newemprestimos = await _emprestimoBusiness.FindAll();
                return Ok(newemprestimos);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("emprestimosdia", Name = "GetEmprestimoDia")]
        public async Task<IActionResult> GetDia(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                    return NotFound();

                var contador = await _emprestimoBusiness.GetDia(Convert.ToInt32(data));

                return Ok(contador);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("emprestimosmes", Name = "GetEmprestimoMes")]
        public async Task<IActionResult> GetMes(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                    return NotFound();

                var contador = await _emprestimoBusiness.GetMes(Convert.ToInt32(data));

                return Ok(contador);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("devolucoesatrasadasmes", Name = "GetDevolucaoAtrasada")]
        public async Task<IActionResult> GetDevolucaoAtrasada(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                    return NotFound();

                var contador = await _emprestimoBusiness.GetDevolucaoAtrasada(Convert.ToInt32(data));

                return Ok(contador);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut(Name = "UpdateEmprestimo")]
        public async Task<IActionResult> Update(Emprestimo obj)
        {
            try
            {
                if (obj == null)
                    return BadRequest();

                var newemprestimo = await _emprestimoBusiness.FindById(obj.Id);
                if (newemprestimo == null)
                    return NotFound();

                var putEmprestimo = await _emprestimoBusiness.Update(obj);
                return CreatedAtRoute("GetByIdEditora", new { id = putEmprestimo.Id }, putEmprestimo);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteEmprestimo")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return NotFound();

                await _emprestimoBusiness.Delete(Convert.ToInt32(id));
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
