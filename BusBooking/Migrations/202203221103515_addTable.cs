namespace BusBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogic",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.BusInfoes",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        BusName = c.String(nullable: false, maxLength: 20),
                        SeatsCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.BusId);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        CPassword = c.String(maxLength: 20),
                        Age = c.Int(nullable: false),
                        DocNumber = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.TblVoyageBooking",
                c => new
                    {
                        VoyageId = c.Int(nullable: false, identity: true),
                        From = c.String(nullable: false, maxLength: 20),
                        To = c.String(nullable: false, maxLength: 20),
                        Dtime = c.String(maxLength: 15),
                        BusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoyageId)
                .ForeignKey("dbo.BusInfoes", t => t.BusId, cascadeDelete: true)
                .Index(t => t.BusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblVoyageBooking", "BusId", "dbo.BusInfoes");
            DropIndex("dbo.TblVoyageBooking", new[] { "BusId" });
            DropTable("dbo.TblVoyageBooking");
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.BusInfoes");
            DropTable("dbo.TblAdminLogic");
        }
    }
}
