using Bouwmarkt_Models;
using Microsoft.AspNetCore.Mvc;

namespace Bouwmarkt_API.Controllers
{
    [ApiController]                                          // (API controller; dus geen MVC controller!! wel volgens MVC pattern!)
    [Route("api/[controller]")]
    public class VestigingController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public VestigingController(ApplicationDbContext db)
        {
            _db = db;
        }


        // /api/Vestiging/{id} | READ (Get)

        [HttpGet]
        public async Task<ActionResult<List<Vestiging>>> Get()
        {
            return Ok(await _db.Vestigingen.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vestiging>> Get(int id)
        {
            var vestiging = await _db.Vestigingen.FindAsync(id);
            if (vestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            return Ok(vestiging);
        }


        // /api/Vestiging | CREATE (Post)

        [HttpPost]
        public async Task<ActionResult<List<Vestiging>>> AddVestiging(Vestiging vestiging)
        {
            _db.Vestigingen.Add(vestiging);
            await _db.SaveChangesAsync();

            return Ok(await _db.Vestigingen.ToListAsync());
        }


        // /api/Vestiging | UPDATE (Put)

        [HttpPut]
        public async Task<ActionResult<List<Vestiging>>> UpdateVestiging(Vestiging request)
        {
            var dbVestiging = await _db.Vestigingen.FindAsync(request.VestigingsNummer);
            if (dbVestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            dbVestiging.Naam = request.Naam;
            dbVestiging.Adres = request.Adres;
            dbVestiging.Plaats = request.Plaats;
            dbVestiging.TelefoonNummer = request.TelefoonNummer;

            await _db.SaveChangesAsync();

            return Ok(await _db.Vestigingen.ToListAsync());
        }


        // /api/Vestiging/{id} | DELETE (Delete)

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vestiging>>> Delete(int id)
        {
             var dbVestiging = await _db.Vestigingen.FindAsync(id);
            if (dbVestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            _db.Vestigingen.Remove(dbVestiging);

            await _db.SaveChangesAsync();

            return Ok(await _db.Vestigingen.ToListAsync());
        }
    }
}
