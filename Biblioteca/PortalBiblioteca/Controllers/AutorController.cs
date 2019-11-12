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
    public class AutorController : Controller
    {
        private readonly IGenericHttpService _service;
        private readonly IGeradorHeader _header;

        public AutorController(IGenericHttpService service, IGeradorHeader header)
        {
            _service = service;
            _header = header;
        }

        public async Task<IActionResult> Index()
        {
            var autoresDyn = await _service.Get<List<Autor>>(Api.Autor.ListarAutores);
            ViewBag.Message = autoresDyn;
            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var autorDyn = await _service.Get<Autor>(Api.Autor.ListarAutor + id);
            ViewBag.Message = autorDyn;
            return View();
        }

        public async Task<IActionResult> Create(Autor obj)
        {
            try
            {
                obj.Nome = "HELLO ITS ME";

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Post<dynamic>(Api.Autor.EnviarAutor, obj);
                ViewBag.Message = "Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Update(Autor obj)
        {
            try
            {
                obj.Id = 6;
                obj.Nome = "MAYDAY";

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Update<Autor>(Api.Autor.AtualizarAutor, obj);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(Api.Autor.DeletarAutor + id);
            return RedirectToAction("Index");
        }
    }
}