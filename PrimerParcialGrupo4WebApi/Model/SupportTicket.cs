using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerParcialGrupo4WebApi.Models
{
    [Table("SupportTickets")]
    public class SupportTicket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; } = null!;

        [Required, EmailAddress]
        public string RequesterEmail { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public string Severity { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        public DateTime OpenedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ClosedAt { get; set; }

        public string? AssignedTo { get; set; }
    }
}