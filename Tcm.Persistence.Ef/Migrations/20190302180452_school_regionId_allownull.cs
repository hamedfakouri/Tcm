using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class school_regionId_allownull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Schools",
                nullable: true,
                oldClrType: typeof(int));

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "ConcurrencyStamp",
            //    value: "525302e0-62c4-4272-b8ac-9295b24b686f");

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "ConcurrencyStamp",
            //    value: "aeb3ee56-ba1b-46fd-bbf0-b0ebe5aee426");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "ConcurrencyStamp",
            //    value: "8ec51168-fc5d-4293-8a46-576a3d7a5506");

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "ConcurrencyStamp",
            //    value: "d0a60048-8e41-4ce3-9fcf-2d39e434a5c1");
        }
    }
}
