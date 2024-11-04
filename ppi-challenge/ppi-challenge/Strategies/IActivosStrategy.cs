using ppi_challenge.Models.DTOs;

namespace ppi_challenge.Strategies
{
    public interface IActivosStrategy
    {
        Task<decimal> CalcularMontoTotal(OrdenDto orden);
        Task<decimal> ObtenerPrecioActivo(OrdenDto orden);
    }
}
