using GestiondeEventos.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GestiondeEventos.Entidades
{
    public class Evento
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} solo puede tener maximo 15 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 60, ErrorMessage = "El campo {0} solo puede tener maximo 60 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaHora { get; set; }
       
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Ubicacion { get; set; }
       
        [Range(0,150)]
        public int CapacidadMaxima { get; set; } 
      
        public List<Usuario> usuarios { get; set; }

    }
}
