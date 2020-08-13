namespace Employee_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeDepartments",
                c => new
                    {
                        DeptId = c.String(nullable: false, maxLength: 128),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeDepartments");
        }
    }
}
