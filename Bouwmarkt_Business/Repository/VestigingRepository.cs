using AutoMapper;
using Bouwmarkt_Business.Repository.IRepository;
using Bouwmarkt_DataAccess;
using Bouwmarkt_DataAccess.Data;
using Bouwmarkt_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public VestigingDTO Create(VestigingDTO objDTO)
        {
            var obj = _mapper.Map<VestigingDTO, Vestiging>(objDTO);
            var addedObj = _db.Vestigingen.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Vestiging, VestigingDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.Vestigingen.FirstOrDefault(u => u.VestigingsNummer == id);
            if (obj != null)
            {
                _db.Vestigingen.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public VestigingDTO Get(int id)
        {
            var obj = _db.Vestigingen.FirstOrDefault(u => u.VestigingsNummer == id);
            if (obj != null)
            {
                return _mapper.Map<Vestiging, VestigingDTO>(obj);
            }
            return new VestigingDTO();
        }

        public IEnumerable<VestigingDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Vestiging>, IEnumerable<VestigingDTO>>(_db.Vestigingen);
        }

        public VestigingDTO Update(VestigingDTO objDTO)
        {
            var objFromDb = _db.Vestigingen.FirstOrDefault(u => u.VestigingsNummer == objDTO.VestigingsNummer);
            if (objFromDb != null)
            {
                objFromDb.Naam = objDTO.Naam;
                objFromDb.Adres = objDTO.Adres;
                objFromDb.Plaats = objDTO.Plaats;
                objFromDb.TelefoonNummer = objDTO.TelefoonNummer;
                _db.Vestigingen.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Vestiging, VestigingDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
