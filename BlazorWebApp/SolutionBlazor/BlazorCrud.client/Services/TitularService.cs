using BlazorCrud.shared;
using System.Net.Http.Json;

namespace BlazorCrud.client.Services
{
    public class TitularService : ITitularService
    {
        private readonly HttpClient _http;

        public TitularService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TitularDTO>> list()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TitularDTO>>>("api/Titular/Lista");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje);
        }
    }
}
