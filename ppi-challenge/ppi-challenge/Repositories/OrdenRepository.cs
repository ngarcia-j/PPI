using ppi_challenge.Models.DTOs;
using ppi_challenge.Models.Entities;
using System.Text.Json;

namespace ppi_challenge.Repositories
{
    public class OrdenRepository : IOrdenRepository
    {

        private readonly string _jsonFile = "MockDB/PPI.json";

        private async Task<RootObject> ReadMockDB()
        {
            try
            {
                using var stream = File.OpenRead(_jsonFile);
                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<RootObject>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error leyendo los datos.", ex); 
            }
        }

        private async Task WriteMockDataAsync(RootObject data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, 
            };

            using var stream = File.Create(_jsonFile);
            await JsonSerializer.SerializeAsync(stream, data, options);
        }


        public async Task<IEnumerable<Orden>> GetAll()
        {
            var data = await ReadMockDB();
            return data?.Ordenes ?? Enumerable.Empty<Orden>();
        }

        public async Task<Orden> GetById(int id)
        {
            var ordenes = await GetAll();
            return ordenes.FirstOrDefault(o => o.Id.Equals(id));
        }

        public async Task Create(Orden orden)
        {
            var data = await ReadMockDB();
            if (data?.Ordenes != null)
            {
                data.Ordenes.Add(orden);
            }
            await WriteMockDataAsync(data);
        }

        public async Task Update(Orden orden)
        {
            var data = await ReadMockDB();
            var updateOrden = data?.Ordenes?.FirstOrDefault(o => o.Id.Equals(orden.Id));
            if (updateOrden != null)
            {
                updateOrden.Estado = orden.Estado;

                await WriteMockDataAsync(data);
            }
            else
            {
                throw new Exception("Orden no encontrada.");
            }
        }

        public async Task Delete(int id)
        {
            var data = await ReadMockDB();
            if (data?.Ordenes != null)
            {
                data.Ordenes.RemoveAll(o => o.Id == id);
            }
            await WriteMockDataAsync(data);
        }

        //Este metodo se realizaría en otra clase ActivoRepository. 
        //Para los fines prácticos del challenge se realiza en el mismo.
        public async Task<decimal> GetPrecioActivo(int id)
        {
            var data = await ReadMockDB();
            var activo = data.Activos.FirstOrDefault(o => o.Id == id);
            return activo.PrecioBase;
        }

        public async Task<IEnumerable<Estado>> GetEstados()
        {
            var data = await ReadMockDB();
            return data?.Estados ?? Enumerable.Empty<Estado>();
        }
    }

    public class RootObject
    {
        public List<Activo>? Activos { get; set; }
        public List<Cuenta>? Cuentas { get; set; }
        public List<Orden>? Ordenes { get; set; }
        public List<Estado>? Estados { get; set; }
    }
}
