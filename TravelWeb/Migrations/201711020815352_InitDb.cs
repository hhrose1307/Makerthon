namespace TravelWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietTour",
                c => new
                    {
                        MaTour = c.Int(nullable: false),
                        MaKH = c.String(nullable: false, maxLength: 128),
                        MoTa = c.String(storeType: "ntext"),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MaTour, t.MaKH })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .ForeignKey("dbo.Tour", t => t.MaTour, cascadeDelete: true)
                .Index(t => t.MaTour)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.NhaNghi",
                c => new
                    {
                        Ma = c.Int(nullable: false),
                        TenNhaNghi = c.String(maxLength: 150),
                        DiaChi = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 11),
                        GiaPhong = c.Decimal(precision: 18, scale: 2),
                        Anh1 = c.String(storeType: "ntext"),
                        Anh2 = c.String(storeType: "ntext"),
                        Anh3 = c.String(storeType: "ntext"),
                        Anh4 = c.String(storeType: "ntext"),
                        Anh5 = c.String(storeType: "ntext"),
                        MaKH = c.String(maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Ma)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.Tour",
                c => new
                    {
                        MaTour = c.Int(nullable: false, identity: true),
                        ThoiGianDi = c.DateTime(),
                        NgayDiDuKien = c.Int(),
                        DiaDiemDi = c.String(maxLength: 150),
                        DiaDiemToi = c.String(maxLength: 150),
                        SoNguoi = c.Int(),
                        PhuongTien = c.Int(),
                    })
                .PrimaryKey(t => t.MaTour);
            
            CreateTable(
                "dbo.DiaDanh",
                c => new
                    {
                        MaDiaDanh = c.Int(nullable: false, identity: true),
                        MaTinh = c.Int(),
                        TenDiaDanh = c.String(maxLength: 10),
                        Mota = c.String(storeType: "ntext"),
                        Anh = c.String(storeType: "ntext"),
                        Anh1 = c.String(storeType: "ntext"),
                        Anh2 = c.String(storeType: "ntext"),
                        Anh3 = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.MaDiaDanh)
                .ForeignKey("dbo.DiaDiemToi", t => t.MaTinh)
                .Index(t => t.MaTinh);
            
            CreateTable(
                "dbo.DiaDiemToi",
                c => new
                    {
                        MaTinh = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaTinh);
            
            AddColumn("dbo.AspNetUsers", "HoTen", c => c.String());
            AddColumn("dbo.AspNetUsers", "SoThich", c => c.String());
            AddColumn("dbo.AspNetUsers", "BietDanh", c => c.String());
            AddColumn("dbo.AspNetUsers", "Anh", c => c.String());
            AddColumn("dbo.AspNetUsers", "FaceBook", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zalo", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiaDanh", "MaTinh", "dbo.DiaDiemToi");
            DropForeignKey("dbo.ChiTietTour", "MaTour", "dbo.Tour");
            DropForeignKey("dbo.NhaNghi", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChiTietTour", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DiaDanh", new[] { "MaTinh" });
            DropIndex("dbo.NhaNghi", new[] { "AspNetUser_Id" });
            DropIndex("dbo.ChiTietTour", new[] { "AspNetUser_Id" });
            DropIndex("dbo.ChiTietTour", new[] { "MaTour" });
            DropColumn("dbo.AspNetUsers", "Zalo");
            DropColumn("dbo.AspNetUsers", "FaceBook");
            DropColumn("dbo.AspNetUsers", "Anh");
            DropColumn("dbo.AspNetUsers", "BietDanh");
            DropColumn("dbo.AspNetUsers", "SoThich");
            DropColumn("dbo.AspNetUsers", "HoTen");
            DropTable("dbo.DiaDiemToi");
            DropTable("dbo.DiaDanh");
            DropTable("dbo.Tour");
            DropTable("dbo.NhaNghi");
            DropTable("dbo.ChiTietTour");
        }
    }
}
