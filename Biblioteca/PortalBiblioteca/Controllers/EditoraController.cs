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
    public class EditoraController : Controller
    {
        private readonly IGenericHttpService _service;
        private readonly IGeradorHeader _header;

        public EditoraController(IGenericHttpService service, IGeradorHeader header)
        {
            _service = service;
            _header = header;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var editoras = await _service.Get<List<Editora>>(Api.Editora.ListarEditoras);
                ViewBag.Message = editoras;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var editoraDyn = await _service.Get<Editora>(Api.Editora.ListarEditora + id);
            ViewBag.Message = editoraDyn;
            return View();
        }

        public async Task<IActionResult> Create(Editora obj)
        {
            try
            {
                obj.Nome = "Furacao";

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Post<Editora>(Api.Editora.EnviarEditora, obj);
                ViewBag.Message = "Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Update(Editora obj)
        {
            try
            {
                obj.Id = 5;
                obj.Nome = "Silvestre";

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Update<Editora>(Api.Editora.AtualizarEditora, obj);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(Api.Editora.DeletarEditora + id);
            return RedirectToAction("Index");
        }
    }
}