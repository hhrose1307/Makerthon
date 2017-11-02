namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetourtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tour", "SoNguoiDaCo", c => c.Int());
            AddColumn("dbo.Tour", "GioiTinh", c => c.String());
            AlterColumn("dbo.Tour", "PhuongTien", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tour", "PhuongTien", c => c.Int());
            DropColumn("dbo.Tour", "GioiTinh");
            DropColumn("dbo.Tour", "SoNguoiDaCo");
        }
    }
}
