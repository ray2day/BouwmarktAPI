using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouwmarkt_DataAccess
{
    public class Koopzondag
    {
        [Key]
        public int Id { get; set; }
        public int VestigingId { get; set; }
        [ForeignKey("VestigingId")]

        public DateTime DatumOpeningstijdVan { get; set; }      
        public DateTime DatumOpeningstijdTot { get; set; }
    }
}
