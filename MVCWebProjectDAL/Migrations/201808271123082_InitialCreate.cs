namespace MVCWebProjectDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Title = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
