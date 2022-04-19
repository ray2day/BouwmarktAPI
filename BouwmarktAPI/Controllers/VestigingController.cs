using Bouwmarkt_DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Bouwmarkt_API.Controllers
{
    [ApiController]                                          // (API controller, volgens MVC pattern)
    [Route("api/[controller]")]
    public class VestigingController : ControllerBase
    {
        private readonly ApplicationDbContext _vestigingRepository;

        public VestigingController(ApplicationDbContext vestigingRepository)
        {
            _vestigingRepository = vestigingRepository;
        }


        // /api/Vestiging/{id} | READ (Get)

        [HttpGet]
        public async Task<ActionResult<List<Vestiging>>> Get()
        {
            return Ok(await _vestigingRepository.Vestigingen.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vestiging>> Get(int id)
        {
            var vestiging = await _vestigingRepository.Vestigingen.FindAsync(id);
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
            _vestigingRepository.Vestigingen.Add(vestiging);
            await _vestigingRepository.SaveChangesAsync();

            return Ok(await _vestigingRepository.Vestigingen.ToListAsync());
        }


        // /api/Vestiging | UPDATE (Put)

        [HttpPut]
        public async Task<ActionResult<List<Vestiging>>> UpdateVestiging(Vestiging request)
        {
            var vestigingRepositoryVestiging = await _vestigingRepository.Vestigingen.FindAsync(request.VestigingsNummer);
            if (vestigingRepositoryVestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            vestigingRepositoryVestiging.Naam = request.Naam;
            vestigingRepositoryVestiging.Adres = request.Adres;
            vestigingRepositoryVestiging.Plaats = request.Plaats;
            vestigingRepositoryVestiging.TelefoonNummer = request.TelefoonNummer;

            await _vestigingRepository.SaveChangesAsync();

            return Ok(await _vestigingRepository.Vestigingen.ToListAsync());
        }


        // /api/Vestiging/{id} | DELETE (Delete)

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vestiging>>> Delete(int id)
        {
            var vestigingRepositoryVestiging = await _vestigingRepository.Vestigingen.FindAsync(id);
            if (vestigingRepositoryVestiging == null)
            {
                return BadRequest("Vestiging niet gevonden.");
            }
            _vestigingRepository.Vestigingen.Remove(vestigingRepositoryVestiging);

            await _vestigingRepository.SaveChangesAsync();

            return Ok(await _vestigingRepository.Vestigingen.ToListAsync());
        }
    }
}
