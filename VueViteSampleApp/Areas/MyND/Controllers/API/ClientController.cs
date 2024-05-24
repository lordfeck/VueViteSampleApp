using VueViteSampleApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueViteSampleApp.Areas.MyND.Controllers.API;

/// <summary>
/// 
/// Authored: 22/05/2024
/// 
/// </summary>
[Area("MyND"), Route("/api/mynd/client/[action]")]
public class ClientController(): Controller
{
    public async Task<IActionResult> GetLite()
    {
        return Ok(new { ClientName = "Foo McBarface", Id = "2"});
    }
}