namespace MVCWebProjectDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ConnectCitiesAndCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            DropColumn("dbo.Cities", "CountryName");
            DropColumn("dbo.People", "Street");
        }

        public override void Down()
        {
            AddColumn("dbo.People", "Street", c => c.String());
            AddColumn("dbo.Cities", "CountryName", c => c.String());
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropColumn("dbo.Cities", "CountryId");
        }
    }
}
