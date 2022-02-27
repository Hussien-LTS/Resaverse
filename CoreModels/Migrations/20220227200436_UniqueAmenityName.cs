using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreModels.Migrations
{
    public partial class UniqueAmenityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AmenityName",
                table: "Amenities",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_AmenityName",
                table: "Amenities",
                column: "AmenityName",
                unique: true,
                filter: "[AmenityName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Amenities_AmenityName",
                table: "Amenities");

            migrationBuilder.AlterColumn<string>(
                name: "AmenityName",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
