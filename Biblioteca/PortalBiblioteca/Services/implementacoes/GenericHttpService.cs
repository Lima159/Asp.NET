using PortalBiblioteca.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortalBiblioteca.Services.implementacoes
{
    public class GenericHttpService : HttpServiceAbstract, IGenericHttpService
    {
        #region Atributos e Construtores
        public GenericHttpService(IHttpClientFactory clientFactory) : base(clientFactory) { }
        #endregion

        public async Task<T> Post<T>(string uri, T content, Dictionary<string, string> header = null)
        {
            TratarHeader(header);
            response = await client.PostAsJsonAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else if (response.StatusCode.Equals(HttpStatusCode.Conflict))
            {
                return default(T);
            }
            else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                throw new UnauthorizedAccessException();
            }
            throw new Exception($"{ response.Content.ReadAsStringAsync().Result }");
        }

        public async Task<T> Get<T>(string uri, Dictionary<string, string> header = null)
        {
            TratarHeader(header);
            response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default(T);
            }
            else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                throw new UnauthorizedAccessException();
            }
            throw new Exception($"{ response.Content.ReadAsStringAsync().Result }");
        }

        public async Task<T> FindById<T>(string uri, Dictionary<string, string> header = null)
        {
            TratarHeader(header);
            response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default(T);
            }
            else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                throw new UnauthorizedAccessException();
            }
            throw new Exception($"{ response.Content.ReadAsStringAsync().Result }");
        }

        public async Task<T> Update<T>(string uri, T content, Dictionary<string, string> header = null)
        {
            TratarHeader(header);
            response = await client.PutAsJsonAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return default(T);
            }
            else if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                throw new UnauthorizedAccessException();
            }
            throw new Exception($"{ response.Content.ReadAsStringAsync().Result }");
        }

        public async Task<HttpStatusCode> Delete(string uri, Dictionary<string, string> header = null)
        {
            TratarHeader(header);
            response = await client.DeleteAsync(uri);
            return response.StatusCode;
        }   
    }
}
