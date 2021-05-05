using System.Data.Entity;
using Dominio.Entidades;
using Aplicacion.ConexionString;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConexionString.CadenaConexion)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Localidad> Localidades { get; set; }

        internal void Attach()
        {
            throw new NotImplementedException();
        }
    }
}
