using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Metadata
{
    public interface ILocalidad
    {
        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [Display(Name = "Pronvincia")]
        [Index("Index_ProvinciaId_Descripcion_Localidad",IsUnique = true, Order = 1)]
        long ProvinciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} no puede estar vacio")]
        [MaxLength(30,ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Index("Index_ProvinciaId_Descripcion_Localidad",IsUnique = true, Order = 2)]
        string Descripcion { get; set; }

    }
}
