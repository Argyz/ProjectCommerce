using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Metadata;
namespace Dominio.Entidades
{
    [Table("Provincia")]
    [MetadataType(typeof(IProvincia))]
    public class Provincia : EntidadBase
    {
        public string Descripcion { get; set; }

        //navigation prop
        public virtual IEnumerable<Localidad> Localidades { get; set; }
    }
}
