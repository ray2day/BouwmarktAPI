using System.ComponentModel.DataAnnotations;

namespace Bouwmarkt_DataAccess
{
    public class Vestiging
    {
        [Key]
        [Display(Name = "Vestigingsnummer")]
        public int VestigingsNummer { get; set; }       
        public string Naam { get; set; } = String.Empty;
        public string Adres { get; set; } = String.Empty;
        public string Plaats { get; set; } = String.Empty;
        [Display(Name = "Telefoonnummer")]
        public string TelefoonNummer { get; set; } = String.Empty;
        public ICollection<Koopzondag>? Koopzondagen { get; set; }
    }
}
