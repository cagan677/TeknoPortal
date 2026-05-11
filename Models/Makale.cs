using System.ComponentModel.DataAnnotations;

namespace TeknoPortal.Models
{
    public class Makale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        public string ResimUrl { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;
    }
}