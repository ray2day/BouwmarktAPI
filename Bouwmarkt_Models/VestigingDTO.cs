using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouwmarkt_Models
{
    public class VestigingDTO
    {
        [Display(Name = "Vestigingsnummer")]
        public int VestigingsNummer { get; set; }
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Naam { get; set; } = String.Empty;
        [Required(ErrorMessage = "Adresgegevens zijn verplicht")]
        public string Adres { get; set; } = String.Empty;
        [Required(ErrorMessage = "Plaatsnaam is verplicht")]
        public string Plaats { get; set; } = String.Empty;
        [Display(Name = "Telefoonnummer")]
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        public string TelefoonNummer { get; set; } = String.Empty;
    }
}
