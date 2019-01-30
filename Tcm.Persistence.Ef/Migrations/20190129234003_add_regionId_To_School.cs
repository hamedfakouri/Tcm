using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class add_regionId_To_School : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Schools");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Schools",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_RegionId",
                table: "Schools",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Regions_RegionId",
                table: "Schools",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Regions_RegionId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_RegionId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Schools",
                nullable: true);
        }
    }
}
