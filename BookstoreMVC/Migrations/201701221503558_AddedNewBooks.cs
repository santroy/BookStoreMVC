namespace BookstoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "IsNew");
        }
    }
}
