using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models
{
    public class NewsletterEmail
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}