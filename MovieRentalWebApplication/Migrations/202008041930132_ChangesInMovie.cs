namespace MovieRentalWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberOfStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberOfStock");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
