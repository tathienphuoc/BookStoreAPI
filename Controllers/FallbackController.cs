using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    public class FallbackController : Controller
    {
        public ActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), 
                        "wwwroot", "index.html"), "text/HTML");
        }
    }
}