using Microsoft.AspNetCore.Mvc;
using FashionWeek;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FashionWeekController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiModneKuce")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetModneKuce()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveModneKuceAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}