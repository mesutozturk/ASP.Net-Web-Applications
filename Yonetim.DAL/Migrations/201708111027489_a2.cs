namespace Yonetim.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Kategoriler", "Ad", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Kategoriler", new[] { "Ad" });
        }
    }
}
