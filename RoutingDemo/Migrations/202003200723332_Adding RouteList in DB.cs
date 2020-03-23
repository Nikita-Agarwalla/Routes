namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRouteListinDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_RouteList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Route = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_RouteList");
        }
    }
}
