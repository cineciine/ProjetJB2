namespace ProjetJB2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        NumGroup = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.ProjectId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Groups", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Groups", new[] { "StudentId" });
            DropIndex("dbo.Groups", new[] { "ProjectId" });
            DropTable("dbo.Students");
            DropTable("dbo.Projects");
            DropTable("dbo.Groups");
        }
    }
}
