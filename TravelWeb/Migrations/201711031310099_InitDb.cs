namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tour", "Anh");
            DropColumn("dbo.Tour", "TinhTrang");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "TinhTrang", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tour", "Anh", c => c.String());
        }
    }
}
