using Microsoft.AspNetCore.Mvc;
using TeknoPortal.Models;

namespace TeknoPortal.Controllers
{
    public class AdminController : Controller
    {
        private readonly PortalContext _db;

        public AdminController(PortalContext db)
        {
            _db = db;
        }

        private bool GirisYapildiMi()
        {
            return HttpContext.Session
                .GetString("GirisYapan") != null;
        }

        public IActionResult Index()
        {
            if (!GirisYapildiMi())
                return RedirectToAction("Giris", "Auth");

            var mesajlar = _db.Mesajlar
                .OrderByDescending(x => x.Tarih)
                .ToList();

            return View(mesajlar);
        }

        [HttpPost]
        public IActionResult MakaleEkle(Makale yeniMakale)
        {
            if (!GirisYapildiMi())
                return RedirectToAction("Giris", "Auth");

            _db.Makaleler.Add(yeniMakale);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GÖREV 1
        public IActionResult MakaleSil(int id)
        {
            if (!GirisYapildiMi())
                return RedirectToAction("Giris", "Auth");

            var makale = _db.Makaleler.Find(id);

            if (makale != null)
            {
                _db.Makaleler.Remove(makale);

                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        // GÖREV 2
        public IActionResult OkunduYap(int id)
        {
            if (!GirisYapildiMi())
                return RedirectToAction("Giris", "Auth");

            var mesaj = _db.Mesajlar.Find(id);

            if (mesaj != null)
            {
                mesaj.OkunduMu = true;

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}