namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationBar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bar",
                c => new
                    {
                        BarId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        LogoPath = c.String(),
                        Hours = c.String(),
                    })
                .PrimaryKey(t => t.BarId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bar");
        }
    }
}
