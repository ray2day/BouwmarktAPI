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
    public class KoopzondagRepository : IKoopzondagRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public KoopzondagRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<KoopzondagDTO> Create(KoopzondagDTO objDTO)
        {
            var obj = _mapper.Map<KoopzondagDTO, Koopzondag>(objDTO);
            var addedObj = _db.Koopzondagen.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Koopzondag, KoopzondagDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Koopzondagen.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Koopzondagen.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<KoopzondagDTO> Get(int id)
        {
            var obj = await _db.Koopzondagen.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Koopzondag, KoopzondagDTO>(obj);
            }
            return new KoopzondagDTO();
        }

        public async Task<IEnumerable<KoopzondagDTO>> GetAll(int? id = null)
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<Koopzondag>, IEnumerable<KoopzondagDTO>>
                    (_db.Koopzondagen.Where(u => u.VestigingId == id));
            }
            else
            {
                return _mapper.Map<IEnumerable<Koopzondag>, IEnumerable<KoopzondagDTO>>(_db.Koopzondagen);
            }
        }

        public async Task<KoopzondagDTO> Update(KoopzondagDTO objDTO)
        {
            var objFromDb = await _db.Koopzondagen.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.DatumOpeningstijdVan = objDTO.DatumOpeningstijdVan;
                objFromDb.DatumOpeningstijdTot = objDTO.DatumOpeningstijdTot;
                objFromDb.VestigingId = objDTO.VestigingId;
                _db.Koopzondagen.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Koopzondag, KoopzondagDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
