namespace PostgreSqlCodeFirts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VtHazirlandi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10),
                        Sifre = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Firmas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(maxLength: 30),
                        Yetkili = c.String(maxLength: 20),
                        Telefon = c.String(maxLength: 20),
                        Mail = c.String(maxLength: 30),
                        Sektor = c.String(maxLength: 20),
                        Il = c.String(maxLength: 20),
                        Ilce = c.String(maxLength: 30),
                        Adres = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GorevDetays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GorevId = c.Int(nullable: false),
                        Aciklama = c.String(maxLength: 200),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gorevs", t => t.GorevId, cascadeDelete: true)
                .Index(t => t.GorevId);
            
            CreateTable(
                "dbo.Gorevs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gorevveren = c.Int(nullable: false),
                        GorevAlan = c.Int(nullable: false),
                        Aciklama = c.String(maxLength: 500),
                        Durum = c.String(maxLength: 20),
                        Tarih = c.DateTime(nullable: false),
                        GorevAlanPersonel_Id = c.Int(),
                        GorevverenPersonel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personels", t => t.GorevAlanPersonel_Id)
                .ForeignKey("dbo.Personels", t => t.GorevverenPersonel_Id)
                .Index(t => t.GorevAlanPersonel_Id)
                .Index(t => t.GorevverenPersonel_Id);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 20),
                        Soyad = c.String(maxLength: 20),
                        Mail = c.String(maxLength: 50),
                        Telefon = c.String(maxLength: 20),
                        Gorsel = c.String(maxLength: 100),
                        DepartmanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departmen", t => t.DepartmanId, cascadeDelete: true)
                .Index(t => t.DepartmanId);
            
            AlterColumn("dbo.Departmen", "Ad", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GorevDetays", "GorevId", "dbo.Gorevs");
            DropForeignKey("dbo.Gorevs", "GorevverenPersonel_Id", "dbo.Personels");
            DropForeignKey("dbo.Gorevs", "GorevAlanPersonel_Id", "dbo.Personels");
            DropForeignKey("dbo.Personels", "DepartmanId", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "DepartmanId" });
            DropIndex("dbo.Gorevs", new[] { "GorevverenPersonel_Id" });
            DropIndex("dbo.Gorevs", new[] { "GorevAlanPersonel_Id" });
            DropIndex("dbo.GorevDetays", new[] { "GorevId" });
            AlterColumn("dbo.Departmen", "Ad", c => c.String());
            DropTable("dbo.Personels");
            DropTable("dbo.Gorevs");
            DropTable("dbo.GorevDetays");
            DropTable("dbo.Firmas");
            DropTable("dbo.Admins");
        }
    }
}
