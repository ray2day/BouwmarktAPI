using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bouwmarkt_Models;

namespace Bouwmarkt_Business.Repository.IRepository
{
    public interface IKoopzondagRepository
    {
        public Task<KoopzondagDTO> Create(KoopzondagDTO objDTO);
        public Task<KoopzondagDTO> Update(KoopzondagDTO objDTO);
        public Task<int> Delete(int id);
        public Task<KoopzondagDTO> Get(int id);
        public Task<IEnumerable<KoopzondagDTO>> GetAll(int? id = null);
    }
}

