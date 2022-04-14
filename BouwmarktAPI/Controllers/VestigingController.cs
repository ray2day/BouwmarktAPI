using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BouwmarktAPI.Controllers                              // note: API controller (dus geen MVC controller)
{
    [ApiController]
    [Route("api/[controller]")]
    public class VestigingController : ControllerBase
    {
        private static List<Vestiging> vestigingen = new List<Vestiging>
            {
                    new Vestiging {
                        VestigingsNummer = 1,
                        Naam = "Praxis Oss",
                        Adres = "Frankenweg 61",
                        Plaats = "Oss",
                        TelefoonNummer = "0412 690 680"},
                    new Vestiging {
                        VestigingsNummer = 2,
                        Naam = "Praxis Drunen",
                        Adres = "Christiaan Huygensweg 10",
                        Plaats = "Drunen",
                        TelefoonNummer = "0416 374 885"},
                    new Vestiging {
                        VestigingsNummer = 3,
                        Naam = "Praxis Uden",
                        Adres = "Industrielaan 9",
                        Plaats = "Uden",
                        TelefoonNummer = "0413 264 445"},
                    new Vestiging {
                        VestigingsNummer = 4,
                        Naam = "Praxis Oisterwijk",
                        Adres = "Sprendingenpark 44",
                        Plaats = "Oisterwijk",
                        TelefoonNummer = "013 521 0266"}
            };

        [HttpGet]
        public async Task<ActionResult<List<Vestiging>>> Get()
        {
            return Ok(vestigingen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vestiging>> Get(int id)
        {
            var vestiging = vestigingen.Find(h => h.VestigingsNummer == id);
            if (vestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            return Ok(vestiging);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vestiging>>> AddVestiging(Vestiging vestiging)
        {
            vestigingen.Add(vestiging);
            return Ok(vestigingen);
        }

        [HttpPut]
        public async Task<ActionResult<List<Vestiging>>> UpdateVestiging(Vestiging request)
        {
            var vestiging = vestigingen.Find(h => h.VestigingsNummer == request.VestigingsNummer);
            if (vestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            vestiging.Naam = request.Naam;
            vestiging.Adres = request.Adres;
            vestiging.Plaats = request.Plaats;
            vestiging.TelefoonNummer = request.TelefoonNummer;

            return Ok(vestigingen);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vestiging>>> Delete(int id)
        {
            var vestiging = vestigingen.Find(h => h.VestigingsNummer == id);
            if (vestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            vestigingen.Remove(vestiging);
            return Ok(vestigingen);
        }
    }
}
