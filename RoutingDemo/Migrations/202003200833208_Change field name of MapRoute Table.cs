namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangefieldnameofMapRouteTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MapRoutes", name: "RoleID_ID", newName: "Role_ID");
            RenameColumn(table: "dbo.MapRoutes", name: "RouteID_ID", newName: "Route_ID");
            RenameIndex(table: "dbo.MapRoutes", name: "IX_RoleID_ID", newName: "IX_Role_ID");
            RenameIndex(table: "dbo.MapRoutes", name: "IX_RouteID_ID", newName: "IX_Route_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MapRoutes", name: "IX_Route_ID", newName: "IX_RouteID_ID");
            RenameIndex(table: "dbo.MapRoutes", name: "IX_Role_ID", newName: "IX_RoleID_ID");
            RenameColumn(table: "dbo.MapRoutes", name: "Route_ID", newName: "RouteID_ID");
            RenameColumn(table: "dbo.MapRoutes", name: "Role_ID", newName: "RoleID_ID");
        }
    }
}
