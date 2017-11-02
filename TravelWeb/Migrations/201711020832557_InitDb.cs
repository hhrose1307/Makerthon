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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        SoThich = c.String(),
                        BietDanh = c.String(),
                        Anh = c.String(),
                        FaceBook = c.String(),
                        Zalo = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DiaDanh", "MaTinh", "dbo.DiaDiemToi");
            DropForeignKey("dbo.ChiTietTour", "MaTour", "dbo.Tour");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NhaNghi", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChiTietTour", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DiaDanh", new[] { "MaTinh" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.NhaNghi", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ChiTietTour", new[] { "AspNetUser_Id" });
            DropIndex("dbo.ChiTietTour", new[] { "MaTour" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DiaDiemToi");
            DropTable("dbo.DiaDanh");
            DropTable("dbo.Tour");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.NhaNghi");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ChiTietTour");
        }
    }
}
