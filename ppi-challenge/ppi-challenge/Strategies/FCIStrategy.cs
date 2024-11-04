using ppi_challenge.Models.DTOs;

namespace ppi_challenge.Strategies
{
    public class FCIStrategy : IActivosStrategy
    {
        public async Task<decimal> CalcularMontoTotal(OrdenDto orden)
        {
            decimal precio = await ObtenerPrecioActivo(orden);
            return orden.Cantidad * precio;
        }

        public Task<decimal> ObtenerPrecioActivo(OrdenDto orden)
        {
            return Task.FromResult(orden.Precio);
        }
    }
}
