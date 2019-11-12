using System.Collections.Generic;
using System.Net.Http;

namespace PortalBiblioteca.Services.Abstracts
{
    public abstract class HttpServiceAbstract
    {
        #region Atributos e Construtor

        protected readonly HttpClient client;
        protected HttpResponseMessage response;

        public HttpServiceAbstract(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient();
        }

        #endregion

        protected void TratarHeader(Dictionary<string, string> header)
        {
            if (header == null || header.Count.Equals(0))
                return;

            client.DefaultRequestHeaders.Clear();

            foreach (var keyValue in header)
            {
                client.DefaultRequestHeaders.Add(keyValue.Key, keyValue.Value);
            }
        }
    }
}
