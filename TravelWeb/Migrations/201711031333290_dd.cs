namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tour", "Anh", c => c.String());
            AddColumn("dbo.Tour", "TinhTrang", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tour", "TinhTrang");
            DropColumn("dbo.Tour", "Anh");
        }
    }
}
