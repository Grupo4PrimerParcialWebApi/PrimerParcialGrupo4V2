using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcialGrupo4WebApi.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        [Required]
        public bool IsOnline { get; set; }

        public string? Notes { get; set; }
    }
}

