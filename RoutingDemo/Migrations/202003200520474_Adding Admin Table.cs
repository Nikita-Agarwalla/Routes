namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAdminTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Admin",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailID = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Admin");
        }
    }
}
