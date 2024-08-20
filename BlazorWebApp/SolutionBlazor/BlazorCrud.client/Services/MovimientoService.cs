using BlazorCrud.shared;
using System.Net.Http.Json;

namespace BlazorCrud.client.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly HttpClient _http;

        public MovimientoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<MovimientoDTO>> List()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<MovimientoDTO>>>("api/Movimiento/Lista");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Mesaje);
        }
 
        public async Task<int> Pago(MovimientoDTO movimiento)
        {
                var result = await _http.PutAsJsonAsync($"api/Tarjeta/Pago/{movimiento.Id}", movimiento);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Success)
                return response.Value!;
            else
                throw new Exception(response.Mesaje);
        }

        public async Task<int> Compra(MovimientoDTO movimiento)
        {
            var result = await _http.PostAsJsonAsync($"api/Tarjeta/Compra/{movimiento.Id}", movimiento);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.Success)
                return response.Value!;
            else
                throw new Exception(response.Mesaje);
        }


    }
}
