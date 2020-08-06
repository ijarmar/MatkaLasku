using Microsoft.EntityFrameworkCore.Migrations;

namespace MatkaLasku.Migrations
{
    public partial class AddedMissingFieldsToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistanceInKM",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocationDeparture",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationDestination",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Trips",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceInKM",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "LocationDeparture",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "LocationDestination",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Trips");
        }
    }
}
