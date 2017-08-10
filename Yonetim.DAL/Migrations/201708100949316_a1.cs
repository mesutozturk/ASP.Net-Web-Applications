namespace Yonetim.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haberler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 255),
                        Icerik = c.String(nullable: false),
                        EklenmeZamani = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Hit = c.Int(nullable: false),
                        YayindaMi = c.Boolean(nullable: false),
                        Keywords = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KategoriHabers",
                c => new
                    {
                        Kategori_Id = c.Int(nullable: false),
                        Haber_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kategori_Id, t.Haber_Id })
                .ForeignKey("dbo.Kategoriler", t => t.Kategori_Id, cascadeDelete: true)
                .ForeignKey("dbo.Haberler", t => t.Haber_Id, cascadeDelete: true)
                .Index(t => t.Kategori_Id)
                .Index(t => t.Haber_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KategoriHabers", "Haber_Id", "dbo.Haberler");
            DropForeignKey("dbo.KategoriHabers", "Kategori_Id", "dbo.Kategoriler");
            DropIndex("dbo.KategoriHabers", new[] { "Haber_Id" });
            DropIndex("dbo.KategoriHabers", new[] { "Kategori_Id" });
            DropTable("dbo.KategoriHabers");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.Haberler");
        }
    }
}
