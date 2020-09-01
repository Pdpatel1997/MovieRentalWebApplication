namespace MovieRentalWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DateRanted = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_CustomerId = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_CustomerId" });
            DropTable("dbo.Rentals");
        }
    }
}
