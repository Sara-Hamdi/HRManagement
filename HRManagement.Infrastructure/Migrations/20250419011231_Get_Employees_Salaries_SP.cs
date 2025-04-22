using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Get_Employees_Salaries_SP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
             CREATE PROCEDURE GetEmployeesSalaries
                 @DepartmentId UNIQUEIDENTIFIER
             AS
             BEGIN
                 SELECT 
                     Em.FullName AS [Name], 
                     Em.NationalId AS [National Id], 
                     Em.GrossSalary AS [Gross Salary],
                     Em.NetSalary As [Net Salary]
                     
                 FROM Employee Em
                 WHERE @DepartmentId is null or Em.DepartmentId = @DepartmentId
             END
             ";

            migrationBuilder.Sql(sp);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetEmployeesSalaries");

        }
    }
}
