using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class school_schoolsubtypeId_allownull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "SchoolSubTypeId",
                table: "Schools",
                nullable: true,
                oldClrType: typeof(short));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "SchoolSubTypeId",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "525302e0-62c4-4272-b8ac-9295b24b686f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aeb3ee56-ba1b-46fd-bbf0-b0ebe5aee426");
        }
    }
}
