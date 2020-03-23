namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAdmintouser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbl_Admin", newName: "tbl_User");
            AddColumn("dbo.tbl_User", "Role_ID", c => c.Int());
            CreateIndex("dbo.tbl_User", "Role_ID");
            AddForeignKey("dbo.tbl_User", "Role_ID", "dbo.Master_Roles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_User", "Role_ID", "dbo.Master_Roles");
            DropIndex("dbo.tbl_User", new[] { "Role_ID" });
            DropColumn("dbo.tbl_User", "Role_ID");
            RenameTable(name: "dbo.tbl_User", newName: "tbl_Admin");
        }
    }
}
