using BlazorCrud.shared;

namespace BlazorCrud.client.Services
{
    public interface IMovimientoService
    {
        Task<List<MovimientoDTO>> List();

        Task<int> Pago(MovimientoDTO movimiento);

        Task<int> Compra(MovimientoDTO movimiento);
    }
}
