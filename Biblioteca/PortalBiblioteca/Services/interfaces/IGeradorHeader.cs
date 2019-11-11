using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace PortalBiblioteca.Services.interfaces
{
    public interface IGeradorHeader
    {
        Dictionary<string, string> GerarHeader(HttpContext context, HttpRequest request);
    }
}
