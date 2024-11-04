using ppi_challenge.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ppi_challenge.Models.Requests
{
    public class UpdateOrdenRequest 
    {
        [Required]
        public string Estado { get; set; }
    }
}
