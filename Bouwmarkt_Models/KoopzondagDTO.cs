using Bouwmarkt_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouwmarkt_Models
{
    public class KoopzondagDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Datum en Openingstijd Van is verplicht")]
        // validatie nog implementeren!
        public DateTime? DatumOpeningstijdVan { get; set; }
        [Required(ErrorMessage = "Datum en Openingstijd Tot is verplicht")]
        // validatie nog implementeren!
        public DateTime? DatumOpeningstijdTot { get; set; }
        public int VestigingId { get; set; }
        public Vestiging Vestiging { get; set; }
    }
}
