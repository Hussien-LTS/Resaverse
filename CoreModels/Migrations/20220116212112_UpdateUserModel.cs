using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreModels.Migrations
{
    public partial class UpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorSize",
                table: "Floors");

            migrationBuilder.RenameColumn(
                name: "Cordonation",
                table: "Rooms",
                newName: "Coordonation");

            migrationBuilder.RenameColumn(
                name: "CoOrdination",
                table: "Floors",
                newName: "Coordination");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Coordination",
                table: "Floors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Coordonation",
                table: "Rooms",
                newName: "Cordonation");

            migrationBuilder.RenameColumn(
                name: "Coordination",
                table: "Floors",
                newName: "CoOrdination");

            migrationBuilder.AlterColumn<string>(
                name: "Capacity",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CoOrdination",
                table: "Floors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FloorSize",
                table: "Floors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
