using Microsoft.EntityFrameworkCore.Migrations;

namespace MatkaLasku.Migrations
{
    public partial class CreatedCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Trips",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CompanyId",
                table: "Trips",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Companies_CompanyId",
                table: "Trips",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Companies_CompanyId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CompanyId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Trips");
        }
    }
}
