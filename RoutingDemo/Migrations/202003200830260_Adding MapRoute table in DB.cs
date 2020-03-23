namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMapRoutetableinDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MapRoutes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID_ID = c.Int(),
                        RouteID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Master_Roles", t => t.RoleID_ID)
                .ForeignKey("dbo.tbl_RouteList", t => t.RouteID_ID)
                .Index(t => t.RoleID_ID)
                .Index(t => t.RouteID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapRoutes", "RouteID_ID", "dbo.tbl_RouteList");
            DropForeignKey("dbo.MapRoutes", "RoleID_ID", "dbo.Master_Roles");
            DropIndex("dbo.MapRoutes", new[] { "RouteID_ID" });
            DropIndex("dbo.MapRoutes", new[] { "RoleID_ID" });
            DropTable("dbo.MapRoutes");
        }
    }
}
