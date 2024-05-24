using Microsoft.AspNetCore.Mvc;

namespace VueViteSampleApp.Areas.Client.Controllers
{
    /// <summary>
    /// 
    /// Authored: 19/12/2023
    /// 
    /// </summary>
    [Area("Client")]
    public class ReceptionController(): Controller
    {
        public async Task <IActionResult> Index()
        {
            return View();
        }
    }
}