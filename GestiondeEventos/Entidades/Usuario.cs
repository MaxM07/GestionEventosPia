using GestiondeEventos.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace GestiondeEventos.Entidades
{
    public class Usuario
    {
        
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:15, ErrorMessage ="El campo {0} solo puede tener maximo 15 caracteres")]
        [PrimeraLetraMayuscula]
        public string UsuarioNombre { get; set; }

        [EmailAddress(ErrorMessage ="El campo {0} no es valido")]
        public string UsuarioEmail { get; set; }

        public int EventoID { get; set; }

        public Evento evento { get; set; }
    }
}
