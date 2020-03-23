namespace RoutingDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMasterDbRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Master_Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Master_Roles");
        }
    }
}
