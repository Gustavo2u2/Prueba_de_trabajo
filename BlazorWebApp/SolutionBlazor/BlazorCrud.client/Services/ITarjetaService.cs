using BlazorCrud.shared;

namespace BlazorCrud.client.Services
{
    public interface ITarjetaService
    {
        Task<List<TarjetaDTO>> list();

        Task<List<TarjetaDTO>> listCuenta();
        Task<TarjetaDTO> Buscar(int id);

        //Task<int> Guardar(TarjetaDTO tarjeta);
        //Task<int> Editar(TarjetaDTO tarjeta);
        Task<bool> Eliminar(int id);

    }
}
