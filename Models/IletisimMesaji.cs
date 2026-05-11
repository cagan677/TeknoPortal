using System.ComponentModel.DataAnnotations;

namespace TeknoPortal.Models
{
    public class IletisimMesaji
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Gonderen { get; set; }

        [Required]
        public string Konu { get; set; }

        [Required]
        public string Metin { get; set; }

        public bool OkunduMu { get; set; } = false;

        public DateTime Tarih { get; set; } = DateTime.Now;
    }
}