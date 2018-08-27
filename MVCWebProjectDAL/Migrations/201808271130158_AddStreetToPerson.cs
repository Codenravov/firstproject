namespace MVCWebProjectDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddStreetToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Street", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.People", "Street");
        }
    }
}
