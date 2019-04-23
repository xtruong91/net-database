using Microsoft.AspNetCore.Mvc;
using MySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQL.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            MusicStoreContext context = HttpContext.RequestServices.GetService(typeof(MySQL.Models.MusicStoreContext)) as MusicStoreContext;

            return View(context.GetAllAlbums());
        }
    }
}
