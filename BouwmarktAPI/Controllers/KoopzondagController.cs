using Bouwmarkt_DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Bouwmarkt_API.Controllers
{
    [ApiController]                                          // (API controller, volgens MVC pattern)
    [Route("api/[controller]")]
    public class KoopzondagController : ControllerBase
    {
        private readonly ApplicationDbContext _koopzondagRepository;

        public KoopzondagController(ApplicationDbContext koopzondagRepository)
        {
            _koopzondagRepository = koopzondagRepository;
        }


        // /api/Koopzondag/{id} | READ (Get)

        [HttpGet]
        public async Task<ActionResult<List<Koopzondag>>> Get()
        {
            return Ok(await _koopzondagRepository.Koopzondagen.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Koopzondag>> Get(int id)
        {
            var koopzondag = await _koopzondagRepository.Koopzondagen.FindAsync(id);
            if (koopzondag == null)
            {
                return BadRequest("Koopzondag niet gevonden.");
            }
            return Ok(koopzondag);
        }



        //// /api/Koopzondag | CREATE (Post)

        //[HttpPost]
        //public async Task<ActionResult<List<Koopzondag>>> AddKoopzondag(Koopzondag koopzondag)
        //{
        //    _koopzondagRepository.Koopzondagen.Add(koopzondag);
        //    await _koopzondagRepository.SaveChangesAsync();

        //    return Ok(await _koopzondagRepository.Koopzondagen.ToListAsync());
        //}

        // ----
        // /api/Koopzondag | CREATE (Post) - inclusief check of datum reeds aanwezig is [test]

        //[HttpPost]
        //public async Task<ActionResult<List<Koopzondag>>> AddKoopzondag(Koopzondag koopzondag)
        //{
        //    if (koopzondag != null)
        //    {
        //        //KoopzondagService ses = new KoopzondagService();

        //        List<Koopzondag> upcomingEvents = await _koopzondagRepository.Koopzondagen.ToListAsync();

        //        bool conflict = false;

        //        foreach (Koopzondag se in upcomingEvents)
        //        {
        //            if(DateOnly.FromDateTime(koopzondag.DatumOpeningstijdVan) == DateOnly.FromDateTime(se.DatumOpeningstijdVan))
        //            {
        //                conflict = true;
        //                break;                    }
        //        }
        //    }


        //    _koopzondagRepository.Koopzondagen.Add(koopzondag);
        //    await _koopzondagRepository.SaveChangesAsync();

        //    return Ok(await _koopzondagRepository.Koopzondagen.ToListAsync());
        //}
        // ----





        // /api/Koopzondag | UPDATE (Put)

        [HttpPut]
        public async Task<ActionResult<List<Koopzondag>>> UpdateKoopzondag(Koopzondag request)
        {
            var koopzondagRepositoryKoopzondag = await _koopzondagRepository.Koopzondagen.FindAsync(request.Id);
            if (koopzondagRepositoryKoopzondag == null)
            {
                return BadRequest("Koopzondag niet gevonden.");
            }
            koopzondagRepositoryKoopzondag.DatumOpeningstijdVan = request.DatumOpeningstijdVan;
            koopzondagRepositoryKoopzondag.DatumOpeningstijdTot = request.DatumOpeningstijdTot;
            koopzondagRepositoryKoopzondag.VestigingId = request.VestigingId;

            await _koopzondagRepository.SaveChangesAsync();

            return Ok(await _koopzondagRepository.Koopzondagen.ToListAsync());
        }


        // /api/Koopzondag/{id} | DELETE (Delete)

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Koopzondag>>> Delete(int id)
        {
            var koopzondagRepositoryKoopzondag = await _koopzondagRepository.Koopzondagen.FindAsync(id);
            if (koopzondagRepositoryKoopzondag == null)
            {
                return BadRequest("Koopzondag niet gevonden.");
            }
            _koopzondagRepository.Koopzondagen.Remove(koopzondagRepositoryKoopzondag);

            await _koopzondagRepository.SaveChangesAsync();

            return Ok(await _koopzondagRepository.Koopzondagen.ToListAsync());
        }
    }
}