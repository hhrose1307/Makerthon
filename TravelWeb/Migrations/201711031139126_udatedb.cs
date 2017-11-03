namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udatedb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tour", "GioiTinhDiCung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "GioiTinhDiCung", c => c.String());
        }
    }
}
