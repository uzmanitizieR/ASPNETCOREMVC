using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREMVCPROJE.Controllers
{
    [Authorize(Roles ="Admin")] // Bu Controller'daki tüm action'lara yetkilendirme uygular
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Yeni bir action eklersen de otomatik olarak Authorize gerekecek
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
