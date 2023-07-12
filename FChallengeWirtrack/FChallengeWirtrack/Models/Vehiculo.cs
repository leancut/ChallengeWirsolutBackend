using System.ComponentModel.DataAnnotations;

namespace FChallengeWirtrack.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        public string Patente { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Marca { get; set; }

    }
}
