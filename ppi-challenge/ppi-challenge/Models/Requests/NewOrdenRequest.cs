using System.ComponentModel.DataAnnotations;

namespace ppi_challenge.Models.Requests
{
    public class NewOrdenRequest : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdCuenta { get; set; }

        public DateTime FechaAlta = DateTime.UtcNow;
        [Required]
        public int IdActivo { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }

        public decimal MontoTotal;

        public string Estado = "En proceso";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Cantidad <= 0)
            {
                yield return new ValidationResult("La cantidad debe ser mayor que 0.", new[] { nameof(Cantidad) });
            }

            if (Precio <= 0)
            {
                yield return new ValidationResult("El precio debe ser mayor que 0.", new[] { nameof(Precio) });
            }
        }
    }
}
