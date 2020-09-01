namespace MovieRentalWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
