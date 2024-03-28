using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid19ManagmentSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Persons",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "streetNumber",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "streetNumber",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Persons",
                newName: "Address");
        }
    }
}
