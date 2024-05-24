using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueViteSampleApp.Areas.Client.Controllers
{
    /// <summary>
    /// 
    /// Authored: 26/04/24
    /// 
    /// </summary>
    [Area("Client")]
    public class UiController(): Controller
    {
        public async Task <IActionResult> Index()
        {
            return View();
        }
    }
}