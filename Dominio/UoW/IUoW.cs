using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.UoW
{
    /*
     * La UoW es para el impacto fisico
     * ejemplo:realizo muchos cambios como por ejemplo agregar provincias
     * todos esos cambios se hacen en los repositorios y se mantienen en memoria
     * hasta que se llame a la UoW y realice un commit() y esos cambios impacten en la memoria fisica
     */
    public interface IUoW
    {
        
        void Commit();//es como el savechange

        void Disposed();

        //Declaraciones de los repositorios

        IRepositorio<Provincia> ProvinciaRepositorio { get; }
       
        IRepositorio<Localidad> LocalidadRepositorio { get; }
    }
}
