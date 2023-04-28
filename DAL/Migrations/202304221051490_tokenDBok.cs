namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenDBok : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "DeleteAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "DeleteAt", c => c.DateTime(nullable: false));
        }
    }
}
