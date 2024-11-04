using ppi_challenge.Models.DTOs;

namespace ppi_challenge.Services
{
    public interface IOrdenService
    {
        Task<OrdenDto> CreateOrden(OrdenDto newOrden);
        Task DeleteOrden(int id);
        Task<IEnumerable<OrdenDto>> GetOrdenes();
        Task<OrdenDto> GetOrdenesById(int id);
        Task<OrdenDto> UpdateOrden(int id, OrdenDto updateOrden);
    }
}