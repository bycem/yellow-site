using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initmigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                schema: "sale",
                table: "Listings",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "VehicleValueObject_ModelYear",
                schema: "sale",
                table: "Listings",
                newName: "ModelYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelYear",
                schema: "sale",
                table: "Listings",
                newName: "VehicleValueObject_ModelYear");

            migrationBuilder.RenameColumn(
                name: "Model",
                schema: "sale",
                table: "Listings",
                newName: "Year");
        }
    }
}
