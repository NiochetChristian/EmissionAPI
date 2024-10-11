using System.ComponentModel.DataAnnotations;

namespace EmisionAPI.Models
{
    public class Emission
    {
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo.")]
        public decimal Quantity { get; set; }

        [Required]
        public DateTime EmissionDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EmissionType { get; set; }
    }
}
