using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelID);
                });

            migrationBuilder.CreateTable(
                name: "Seriess",
                columns: table => new
                {
                    SeriesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seriess", x => x.SeriesID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<int>(type: "int", nullable: false),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleYear = table.Column<int>(type: "int", nullable: false),
                    VehicleKm = table.Column<int>(type: "int", nullable: false),
                    VehicleFuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleGear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleBodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleEnginePower = table.Column<int>(type: "int", nullable: false),
                    VehicleEngineCapacity = table.Column<int>(type: "int", nullable: false),
                    VehicleWheelDrive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleWarranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleExcangeable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleAd = table.Column<int>(type: "int", nullable: false),
                    VehicleAdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Seriess");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
