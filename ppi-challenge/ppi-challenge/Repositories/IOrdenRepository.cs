using ppi_challenge.Models.Entities;

namespace ppi_challenge.Repositories
{
    public interface IOrdenRepository
    {
        Task Create(Orden orden);
        Task<IEnumerable<Orden>> GetAll();
        Task<Orden> GetById(int id);
        Task Update(Orden orden);
        Task Delete(int id);
        Task<decimal> GetPrecioActivo(int id);
        Task<IEnumerable<Estado>> GetEstados();
    }
}