using Bouwmarkt_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouwmarkt_Business.Repository.IRepository
{
    public interface IVestigingRepository
    {
        public VestigingDTO Create(VestigingDTO objDTO);
        public VestigingDTO Update(VestigingDTO objDTO);
        public int Delete(int id);
        public VestigingDTO Get(int id);
        public IEnumerable<VestigingDTO> GetAll();
    }
}
