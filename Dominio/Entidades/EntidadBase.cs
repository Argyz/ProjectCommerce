using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dominio.Entidades
{
    public class EntidadBase
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name = "Esta Elimado")]
        [DefaultValue(0)]
        public bool EstaEliminado { get; set; }
    }
}
