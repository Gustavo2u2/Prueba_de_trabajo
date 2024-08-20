using BlazorCrud.shared;
using System.Net.Http.Json;

namespace BlazorCrud.client.Services
{
    public class TarjetaService : ITarjetaService
    {
        private readonly HttpClient _http;

        public TarjetaService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<TarjetaDTO>> list()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TarjetaDTO>>>("api/Tarjeta/Lista");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje);
        }
        public async Task<List<TarjetaDTO>> listCuenta()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TarjetaDTO>>>("api/Tarjeta/ListaCuenta");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje);
        }

        public async Task<TarjetaDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<TarjetaDTO>>($"api/Tarjeta/Buscar/{id}");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje);
        }

        //public async Task<int> Guardar(TarjetaDTO tarjeta)
        //{
        //    var result = await _http.PostAsJsonAsync($"api/Tarjeta/Guardar", tarjeta);
        //    var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        //    if (response!.Success)
        //        return response.Value!;
        //    else
        //        throw new Exception(response.Mesaje);
        //}

        //public async Task<int> Editar(TarjetaDTO tarjeta)
        //{
        //    var result = await _http.PutAsJsonAsync($"api/Tarjeta/Editar/{tarjeta.Id}", tarjeta);
        //    var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        //    if (response!.Success)
        //        return response.Value!;
        //    else
        //        throw new Exception(response.Mesaje);
        //}

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Tarjeta/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Success)
                return response.Success!;
            else
                throw new Exception(response.Mesaje);
        }

    }
}
