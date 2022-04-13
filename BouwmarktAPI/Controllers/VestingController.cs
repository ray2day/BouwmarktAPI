using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BouwmarktAPI.Controllers                              // note: API controller (dus geen MVC controller)
{
    [Route("api/[controller]")]
    [ApiController]
    public class VestingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var test = new List<Vestiging>
            {
                    new Vestiging {
                        VestigingsNummer = 1,
                        Naam = "Praxis Oss",
                        Adres = "Frankenweg 61",
                        Plaats = "Oss",
                        TelefoonNummer = "0412 690 680"}
            };

            return Ok(test);
        }
    }
}
