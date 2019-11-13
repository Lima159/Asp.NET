using Microsoft.AspNetCore.Mvc;
using PortalBiblioteca.Models;
using PortalBiblioteca.Services.implementacoes;
using PortalBiblioteca.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using static PortalBiblioteca.Utils.Urls.UrlApi;

namespace PortalBiblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IGenericHttpService _service;
        private readonly IGeradorHeader _header;

        public EmprestimoController(IGenericHttpService service, IGeradorHeader header)
        {
            _service = service;
            _header = header;
        }

        public async Task<IActionResult> Index()
        {
            var emprestimosDyn = await _service.Get<List<Emprestimo>>(Api.Emprestimo.ListarEmprestimos);
            ViewBag.Message = emprestimosDyn;
            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var emprestimoDyn = await _service.Get<Emprestimo>(Api.Emprestimo.ListarEmprestimo + id);
            ViewBag.Message = emprestimoDyn;
            return View();
        }                
                    
        public async Task<IActionResult> EmprestimoDia(string id)
        {
            var emprestimoDyn = await _service.Get<int>(Api.Emprestimo.ListarEmprestimosDia + id);
            ViewBag.Message = emprestimoDyn;
            ViewBag.Dia = id;
            return View();
        }

        public async Task<IActionResult> EmprestimoMes(string id)
        {
            var emprestimoDyn = await _service.Get<int>(Api.Emprestimo.ListarEmprestimosMes + id);
            ViewBag.Message = emprestimoDyn;
            ViewBag.Mes = id;
            return View();
        }

        public async Task<IActionResult> DevolucaoAtrasadoMes(string id)
        {
            var emprestimoDyn = await _service.Get<int>(Api.Emprestimo.ListarDevolucaoAtrasadoMes + id);
            ViewBag.Message = emprestimoDyn;
            ViewBag.Mes = id;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Emprestimo obj)
        {
            try
            {
                //obj.Livro = null;
                //obj.Leitor = null;

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Post<dynamic>(Api.Emprestimo.EnviarEmprestimo, obj);
                ViewBag.Message = "Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Update(Emprestimo obj)
        {
            try
            {
                obj.Id = 7;
                obj.LivroId = 5;
                obj.Livro = null;
                obj.LeitorId = 3;
                obj.Leitor = null;
                obj.Data_Emprestimo = DateTime.Now;
                obj.Data_Expiracao = DateTime.Now;
                obj.Data_Devolucao = DateTime.Now;

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Update<Emprestimo>(Api.Emprestimo.AtualizarEmprestimo, obj);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(Api.Emprestimo.DeletarEmprestimo + id);
            return RedirectToAction("Index");
        }
    }
}