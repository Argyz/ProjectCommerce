namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Localidad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinciaId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => new { t.ProvinciaId, t.Descripcion }, unique: true, name: "Index_ProvinciaId_Descripcion_Localidad");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Localidad", "ProvinciaId", "dbo.Provincia");
            DropIndex("dbo.Localidad", "Index_ProvinciaId_Descripcion_Localidad");
            DropTable("dbo.Localidad");
        }
    }
}
