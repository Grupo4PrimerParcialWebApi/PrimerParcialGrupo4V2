using System;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcialGrupo4WebApi.Model
{
    public class Producto
    {
        [Key] // Clave primaria
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}