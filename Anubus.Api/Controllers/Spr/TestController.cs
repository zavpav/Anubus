using Anubus.Services.Security;

namespace Anubus.Api.Controllers.Spr
{
    [Route("api/Spr/Test")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("List")]
        [Auth]
        public async Task<IActionResult> Test()
        {
            await Task.Yield();

            var a = new SprGrbsController.SprGrbsListDto() 
            {
                Id = 1,
                Code = "sadf1213",
                FullName = "asdfasfsa"
            };

            return Json(a);
        }
    }
}
