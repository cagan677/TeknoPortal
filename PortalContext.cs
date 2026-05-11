using Microsoft.EntityFrameworkCore;
using TeknoPortal.Models;

namespace TeknoPortal
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions<PortalContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Makale> Makaleler { get; set; }

        public DbSet<IletisimMesaji> Mesajlar { get; set; }
    }
}