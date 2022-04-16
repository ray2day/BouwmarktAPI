using System.ComponentModel.DataAnnotations;

namespace Bouwmarkt_Models
{
    public class Vestiging
    {
        [Key]
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
