using VueViteSampleApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueViteSampleApp.Areas.MyND.Controllers.API;

/// <summary>
/// Authored: 22/05/2024
/// 
/// </summary>
[Area("MyND"), Route("/api/mynd/roomreservation/[action]")]
public class RoomReservationController(): Controller
{
    public async Task<IActionResult> GetReservationsLite()
    {
        var res = new[]
        {
            new { Id = 10, RoomName = "Big Hall" },
            new { Id = 11, RoomName = "Big Hall" },
            new { Id = 12, RoomName = "Big Hall" },
            new { Id = 13, RoomName = "Big Hall" },
        };
        return Ok(res);
    }
}