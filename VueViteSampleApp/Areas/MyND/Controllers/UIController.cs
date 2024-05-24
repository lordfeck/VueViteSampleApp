using VueViteSampleApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueViteSampleApp.Areas.MyND.Controllers
{
    /// <summary>
    /// 
    /// Authored: 26/04/2024
    /// 
    /// </summary>
    [Area("MyND")]
    public class UIController(): Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}