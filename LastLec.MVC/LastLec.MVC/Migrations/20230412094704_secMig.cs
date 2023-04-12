using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastLec.MVC.Migrations
{
    /// <inheritdoc />
    public partial class secMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateBuirth",
                table: "Employees",
                newName: "DateBirth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateBirth",
                table: "Employees",
                newName: "DateBuirth");
        }
    }
}
