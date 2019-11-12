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
    public class LivroController : Controller
    {
        private readonly IGenericHttpService _service;
        private readonly IGeradorHeader _header;

        public LivroController(IGenericHttpService service, IGeradorHeader header)
        {
            _service = service;
            _header = header;
        }

        public async Task<IActionResult> Index()
        {
            var livrosDyn = await _service.Get<List<Livro>>(Api.Livro.ListarLivros);
            ViewBag.Message = livrosDyn;
            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var livroDyn = await _service.Get<Livro>(Api.Livro.ListarLivro + id);
            ViewBag.Message = livroDyn;
            return View();
        }

        public async Task<IActionResult> Create(Livro obj)
        {
            try
            {
                obj.Titulo = "Squack";
                obj.NumeroPaginas = 75;
                obj.AutorId = 1;
                obj.Autor = null;
                obj.EditoraId = 4;
                obj.Editora = null;
                obj.GeneroId = 3;
                obj.Genero = null;

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Post<dynamic>(Api.Livro.EnviarLivro, obj);
                ViewBag.Message = "Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Update(Livro obj)
        {
            try
            {
                obj.Titulo = "Squack O Retorno";
                obj.NumeroPaginas = 250;
                obj.AutorId = 1;
                obj.Autor = null;
                obj.EditoraId = 4;
                obj.Editora = null;
                obj.GeneroId = 3;
                obj.Genero = null;

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Update<Livro>(Api.Livro.AtualizarLivro, obj);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(Api.Livro.DeletarLivro + id);
            return RedirectToAction("Index");
        }
    }
}