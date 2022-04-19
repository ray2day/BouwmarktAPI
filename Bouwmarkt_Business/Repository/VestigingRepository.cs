using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bouwmarkt_Business.Repository.IRepository;
using Bouwmarkt_DataAccess;
using Bouwmarkt_DataAccess.Data;
using Bouwmarkt_Models;

namespace Bouwmarkt_Business.Repository
{
    public class VestigingRepository : IVestigingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VestigingRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<VestigingDTO> Create(VestigingDTO objDTO)
        {
            var obj = _mapper.Map<VestigingDTO, Vestiging>(objDTO);
            var addedObj = _db.Vestigingen.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Vestiging, VestigingDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Vestigingen.FirstOrDefaultAsync(u => u.VestigingsNummer == id);
            if (obj != null)
            {
                _db.Vestigingen.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<VestigingDTO> Get(int id)
        {
            var obj = await _db.Vestigingen.FirstOrDefaultAsync(u => u.VestigingsNummer == id);
            if (obj != null)
            {
                return _mapper.Map<Vestiging, VestigingDTO>(obj);
            }
            return new VestigingDTO();
        }

        public async Task<IEnumerable<VestigingDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Vestiging>, IEnumerable<VestigingDTO>>(_db.Vestigingen.Include(u => u.Category).Include(u => u.VestigingPrices));
        }

        public async Task<VestigingDTO> Update(VestigingDTO objDTO)
        {
            var objFromDb = await _db.Vestigingen.FirstOrDefaultAsync(u => u.VestigingsNummer == objDTO.VestigingsNummer);
            if (objFromDb != null)
            {
                objFromDb.Naam = objDTO.Naam;
                objFromDb.Adres = objDTO.Adres;
                objFromDb.Plaats = objDTO.Plaats;
                objFromDb.TelefoonNummer = objDTO.TelefoonNummer;
                _db.Vestigingen.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Vestiging, VestigingDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
