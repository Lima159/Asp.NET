using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalBiblioteca.Models;
using PortalBiblioteca.Services.implementacoes;
using PortalBiblioteca.Services.interfaces;
using static PortalBiblioteca.Utils.Urls.UrlApi;

namespace PortalBiblioteca.Controllers
{    
    public class GeneroController : Controller
    {
        private readonly IGenericHttpService _service;
        private readonly IGeradorHeader _header;

        public GeneroController(IGenericHttpService service, IGeradorHeader header)
        {
            _service = service;
            _header = header;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var generos = await _service.Get<List<Genero>>(Api.Genero.ListarGeneros);
                ViewBag.Message = generos;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return View();
        }

        public async Task<IActionResult> Create(Genero obj)
        {
            try
            {
                obj.Nome = "Ficcao";

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Post<Genero>(Api.Genero.EnviarGenero, obj);
                ViewBag.Message = "Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public async Task<IActionResult> Update(Genero obj)
        {
            try
            {
                obj.Id = 5;
                obj.Nome = "Drama";

                if (!ModelState.IsValid || obj == null)
                    return BadRequest(ModelState);

                await _service.Update<Genero>(Api.Genero.AtualizarGenero, obj);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message} - {e.InnerException}");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}