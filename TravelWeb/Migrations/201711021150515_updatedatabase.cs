namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tour", "TinhDi", c => c.String());
            AddColumn("dbo.Tour", "HuyenDi", c => c.String());
            AddColumn("dbo.Tour", "TinhToi", c => c.String());
            AddColumn("dbo.Tour", "HuyenToi", c => c.String());
            DropColumn("dbo.Tour", "DiaDiemDi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "DiaDiemDi", c => c.String(maxLength: 150));
            DropColumn("dbo.Tour", "HuyenToi");
            DropColumn("dbo.Tour", "TinhToi");
            DropColumn("dbo.Tour", "HuyenDi");
            DropColumn("dbo.Tour", "TinhDi");
        }
    }
}
