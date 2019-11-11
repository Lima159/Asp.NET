using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PortalBiblioteca.Services.interfaces;
using System.Collections.Generic;

namespace PortalBiblioteca.Services.implementacoes
{
    public class GeradorHeader : IGeradorHeader
    {
        #region Atributos e Construtor

        private IConfiguration _configuration;

        public GeradorHeader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        public Dictionary<string, string> GerarHeader(HttpContext context, HttpRequest request)
        {
            Dictionary<string, string> dicionarioHeader = new Dictionary<string, string>();

            string idUsuario = context.Session.GetString("UsuarioID");
            string idClient = _configuration["Cliente:Chave"].ToString();
            string token = request.Cookies["AcessToken"].ToString();

            dicionarioHeader.Add("idUsuario", idUsuario);
            dicionarioHeader.Add("idClient", idClient);
            dicionarioHeader.Add("token", token);

            return dicionarioHeader;
        }
    }
}
