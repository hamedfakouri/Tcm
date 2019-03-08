using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class addEducationYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "ClassRooms");

            migrationBuilder.AddColumn<int>(
                name: "EducationYearId",
                table: "ClassRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EducationYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationYears", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0c96633b-0a08-4af7-9536-051f33c2a0f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "21ecb08d-44af-46c3-8627-646a50a24b9b");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_EducationYearId",
                table: "ClassRooms",
                column: "EducationYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_EducationYears_EducationYearId",
                table: "ClassRooms",
                column: "EducationYearId",
                principalTable: "EducationYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_EducationYears_EducationYearId",
                table: "ClassRooms");

            migrationBuilder.DropTable(
                name: "EducationYears");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_EducationYearId",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "EducationYearId",
                table: "ClassRooms");

            migrationBuilder.AddColumn<short>(
                name: "Year",
                table: "ClassRooms",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "41910df6-e5d2-4c72-a250-77243d8420b3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7e0c01e1-a261-4a16-b7a2-d47e49c268e3");
        }
    }
}
