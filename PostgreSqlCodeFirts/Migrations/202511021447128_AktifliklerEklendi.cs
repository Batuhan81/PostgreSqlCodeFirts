namespace PostgreSqlCodeFirts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AktifliklerEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departmen", "Aktif", c => c.Boolean(nullable: false, defaultValue: true));

            AddColumn("dbo.Personels", "Aktif", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personels", "Aktif");
            DropColumn("dbo.Departmen", "Aktif");
        }
    }
}
