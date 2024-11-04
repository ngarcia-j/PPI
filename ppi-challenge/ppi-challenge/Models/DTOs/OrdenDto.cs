namespace ppi_challenge.Models.DTOs
{
    public class OrdenDto
    {
        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdActivo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
    }
}
