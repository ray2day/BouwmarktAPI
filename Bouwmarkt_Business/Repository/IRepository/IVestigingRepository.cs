using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bouwmarkt_Models;

namespace Bouwmarkt_Business.Repository.IRepository
{
    public interface IVestigingRepository
    {
        public Task<VestigingDTO> Create(VestigingDTO objDTO);
        public Task<VestigingDTO> Update(VestigingDTO objDTO);
        public Task<int> Delete(int id);
        public Task<VestigingDTO> Get(int id);
        public Task<IEnumerable<VestigingDTO>> GetAll();
    }
}

