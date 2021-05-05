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
    [Table("Localidad")]
    [MetadataType(typeof(ILocalidad))]

    public class Localidad : EntidadBase
    {
        public long ProvinciaId { get; set; }
        public string  Descripcion { get; set; }

        //navigation

        public virtual Provincia Provincia { get; set; }
    }
}
