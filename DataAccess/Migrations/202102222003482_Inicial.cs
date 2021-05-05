namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 30),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Descripcion, unique: true, name: "Index_Descripcion_Provincia");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Provincia", "Index_Descripcion_Provincia");
            DropTable("dbo.Provincia");
        }
    }
}
