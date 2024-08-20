using BlazorCrud.shared;

namespace BlazorCrud.client.Services
{
    public interface ITransaccionService
    {
        Task<List<TransaccionDTO>> Lista();

        Task<List<TransaccionDTO>> ListaBody();
    }
}
