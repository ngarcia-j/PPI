using ppi_challenge.Models.DTOs;
using ppi_challenge.Models.Entities;

namespace ppi_challenge.Strategies
{
    public class BonoStrategy : IActivosStrategy
    {
        public async Task<decimal> CalcularMontoTotal(OrdenDto orden)
        {
            decimal total = orden.Cantidad * await ObtenerPrecioActivo(orden);
            decimal comision = total * 0.002m;
            decimal impuesto = comision * 0.21m;
            return total - comision - impuesto;
        }

        public Task<decimal> ObtenerPrecioActivo(OrdenDto orden)
        {
            return Task.FromResult(orden.Precio);
        }
    }
}
