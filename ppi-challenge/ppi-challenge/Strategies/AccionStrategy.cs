using ppi_challenge.Models.DTOs;
using ppi_challenge.Repositories;

namespace ppi_challenge.Strategies
{
    public class AccionStrategy : IActivosStrategy
    {
        private readonly IOrdenRepository _ordenRepository;

        public AccionStrategy(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        public async Task<decimal> CalcularMontoTotal(OrdenDto orden)
        {
            decimal total = orden.Cantidad * await ObtenerPrecioActivo(orden);
            decimal comision = total * 0.006m;
            decimal impuesto = comision * 0.21m;
            return total - comision - impuesto;
        }

        public async Task<decimal> ObtenerPrecioActivo(OrdenDto orden)
        {
            return await _ordenRepository.GetPrecioActivo(orden.IdActivo); ;
        }
    }
}
