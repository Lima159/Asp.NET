using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalBiblioteca.Models;
using PortalBiblioteca.Services.implementacoes;
using PortalBiblioteca.Services.interfaces;
using static PortalBiblioteca.Utils.Urls.UrlApi;

namespace PortalBiblioteca.Controllers
{
    public class LeitorController : Controller
    {
        private readonly IGenericHttpService _service;
        private readonly IGeradorHeader _header;

        public LeitorController(IGenericHttpService service, IGeradorHeader header)
        {
            _service = service;
            _header = header;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var leitoresDyn = await _service.Get<List<Leitor>>(Api.Leitor.ListarLeitores);
                ViewBag.Message = leitoresDyn;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var leitorDyn = await _service.Get<Leitor>(Api.Leitor.ListarLeitor + id);
            ViewBag.Message = leitorDyn;
            return View();
        }

        public async Task<IActionResult> Create(Leitor obj)
        {
            try
            {
                obj.Nome = "Itafio";
                obj.CPF = "9999";
                obj.DataNascimento = DateTime.Now;

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Post<Leitor>(Api.Leitor.EnviarLeitor, obj);
                ViewBag.Message = "Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Update(Leitor obj)
        {
            try
            {
                obj.Id = 4;
                obj.Nome = "Big V";
                obj.CPF = "123456";
                obj.DataNascimento = DateTime.Now;

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Update<Leitor>(Api.Leitor.AtualizarLeitor, obj);;
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(Api.Leitor.DeletarLeitor + id);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}