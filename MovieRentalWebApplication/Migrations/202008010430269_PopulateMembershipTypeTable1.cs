namespace MovieRentalWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes(SignUpFee,DurationInMonth,DiscountRate,Name) VALUES (0,0,0,'Pay as Yo Go')");
            Sql("Insert into MembershipTypes(SignUpFee,DurationInMonth,DiscountRate,Name) VALUES (30,1,10,'Monthly')");
            Sql("Insert into MembershipTypes(SignUpFee,DurationInMonth,DiscountRate,Name) VALUES (90,3,15,'Quaterly')");
            Sql("Insert into MembershipTypes(SignUpFee,DurationInMonth,DiscountRate,Name) VALUES (300,12,20,'Yearly')");
        }
        
        public override void Down()
        {
        }
    }
}
