using Microsoft.AspNetCore.Mvc;
using TeknoPortal.Models;

namespace TeknoPortal.Controllers
{
    public class AuthController : Controller
    {
        private readonly PortalContext _db;

        public AuthController(PortalContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(string email, string sifre)
        {
            var kullanici = _db.Kullanicilar
                .FirstOrDefault(x =>
                    x.Email == email &&
                    x.Sifre == sifre);

            if (kullanici != null)
            {
                HttpContext.Session.SetString(
                    "GirisYapan",
                    kullanici.AdSoyad);

                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Hata = "Hatalı giriş!";

            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}