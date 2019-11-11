using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PortalBiblioteca.Services.implementacoes
{
    public interface IGenericHttpService
    {
        Task<T> Get<T>(string uri, Dictionary<string, string> header = null);
        Task<T> Post<T>(string uri, T content, Dictionary<string, string> header = null);
        Task<T> Update<T>(string uri, T content, Dictionary<string, string> header = null);
        Task<HttpStatusCode> Delete(string uri, Dictionary<string, string> header = null);
    }
}
