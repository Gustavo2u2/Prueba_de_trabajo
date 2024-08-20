using BlazorCrud.shared;
using System.Net.Http.Json;

namespace BlazorCrud.client.Services
{
    public class TransaccionService : ITransaccionService
    {

        private readonly HttpClient _http;

        public TransaccionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TransaccionDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TransaccionDTO>>>("api/Transaccion/Lista");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje); ;
        }

        public async Task<List<TransaccionDTO>> ListaHeader()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TransaccionDTO>>>("api/Transaccion/ListaHeader");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje); ;
        }
    }
}
