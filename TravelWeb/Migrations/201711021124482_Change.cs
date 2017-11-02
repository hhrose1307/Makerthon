namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NgaySinh", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NgaySinh");
        }
    }
}
