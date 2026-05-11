using Microsoft.AspNetCore.Mvc;
using TeknoPortal.Models;

namespace TeknoPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortalContext _db;

        public HomeController(PortalContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var makaleler = _db.Makaleler
                .OrderByDescending(x => x.Tarih)
                .ToList();

            return View(makaleler);
        }

        [HttpPost]
        public IActionResult MesajGonder(IletisimMesaji yeniMesaj)
        {
            _db.Mesajlar.Add(yeniMesaj);

            _db.SaveChanges();

            TempData["Bilgi"] =
                "Mesajınız gönderildi.";

            return RedirectToAction("Index");
        }
    }
}