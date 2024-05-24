using VueViteSampleApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueViteSampleApp.Areas.MyND.Controllers
{
    /// <summary>
    /// Default landing page and other related views.
    /// Authored: 13/12/2023
    /// 
    /// </summary>
    [Area("MyND")]
    public class ReceptionController(): Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}