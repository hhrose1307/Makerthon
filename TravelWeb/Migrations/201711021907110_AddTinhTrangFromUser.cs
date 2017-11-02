namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTinhTrangFromUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GioiTinh", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GioiTinh");
        }
    }
}
