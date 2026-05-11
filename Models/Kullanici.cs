using System.ComponentModel.DataAnnotations;

namespace TeknoPortal.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sifre { get; set; }

        public string Rol { get; set; } = "Admin";
    }
}