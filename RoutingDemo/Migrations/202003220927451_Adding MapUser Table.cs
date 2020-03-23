namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMapUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_MapUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Role_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Master_Roles", t => t.Role_ID)
                .ForeignKey("dbo.tbl_User", t => t.User_ID)
                .Index(t => t.Role_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_MapUser", "User_ID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_MapUser", "Role_ID", "dbo.Master_Roles");
            DropIndex("dbo.tbl_MapUser", new[] { "User_ID" });
            DropIndex("dbo.tbl_MapUser", new[] { "Role_ID" });
            DropTable("dbo.tbl_MapUser");
        }
    }
}
