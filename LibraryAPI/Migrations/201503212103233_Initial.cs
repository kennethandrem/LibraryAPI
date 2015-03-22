namespace LibraryAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        año = c.Int(nullable: false),
                        bio = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(nullable: false),
                        año = c.Int(nullable: false),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        autorId = c.Int(nullable: false),
                        categoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Autors", t => t.autorId, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.categoriaId, cascadeDelete: true)
                .Index(t => t.autorId)
                .Index(t => t.categoriaId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "categoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Books", "autorId", "dbo.Autors");
            DropIndex("dbo.Books", new[] { "categoriaId" });
            DropIndex("dbo.Books", new[] { "autorId" });
            DropTable("dbo.Categorias");
            DropTable("dbo.Books");
            DropTable("dbo.Autors");
        }
    }
}
