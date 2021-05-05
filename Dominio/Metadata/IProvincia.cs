using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Metadata
{
    interface IProvincia
    {
        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [MaxLength(30,ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Index("Index_Descripcion_Provincia",IsUnique = true)]
        string Descripcion { get; set; }
    }
}
