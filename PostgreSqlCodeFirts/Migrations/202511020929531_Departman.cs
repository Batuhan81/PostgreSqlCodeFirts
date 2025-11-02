namespace PostgreSqlCodeFirts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Departman : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departmen");
        }
    }
}
