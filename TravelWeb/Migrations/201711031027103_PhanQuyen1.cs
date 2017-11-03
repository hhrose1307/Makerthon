namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhanQuyen1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.NhaNghi");
            AlterColumn("dbo.NhaNghi", "Ma", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.NhaNghi", "Ma");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.NhaNghi");
            AlterColumn("dbo.NhaNghi", "Ma", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.NhaNghi", "Ma");
        }
    }
}
