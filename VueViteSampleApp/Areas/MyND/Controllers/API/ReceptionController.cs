using Microsoft.AspNetCore.Mvc;
using VueViteSampleApp.Services;

namespace VueViteSampleApp.Areas.MyND.Controllers.API
{
    /// <summary>
    /// 
    /// Authored: 08/05/2024
    /// 
    /// </summary>
    
    [Area("MyND"), Route("/api/mynd/reception/[action]")]
    public class ReceptionController (IReceptionService _reception): Controller
    {
        /// <summary>
        /// Get reception summary data.
        /// </summary>
        public async Task<IActionResult> Summary()
        {
            return Ok("success");
        }
    }
}