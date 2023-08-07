using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class referansVeIliski : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Seriess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeriesID",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelID",
                table: "Vehicles",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Seriess_BrandID",
                table: "Seriess",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_SeriesID",
                table: "Models",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryID",
                table: "Brands",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryID",
                table: "Brands",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Seriess_SeriesID",
                table: "Models",
                column: "SeriesID",
                principalTable: "Seriess",
                principalColumn: "SeriesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seriess_Brands_BrandID",
                table: "Seriess",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelID",
                table: "Vehicles",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ModelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryID",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Seriess_SeriesID",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Seriess_Brands_BrandID",
                table: "Seriess");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ModelID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Seriess_BrandID",
                table: "Seriess");

            migrationBuilder.DropIndex(
                name: "IX_Models_SeriesID",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CategoryID",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Seriess");

            migrationBuilder.DropColumn(
                name: "SeriesID",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Brands");
        }
    }
}
