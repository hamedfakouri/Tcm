using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class stdRelWithAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentPhone",
                table: "Students",
                newName: "Phone");

            migrationBuilder.RenameSequence(
                name: "ProvinceSequence",
                newName: "Provincesequence");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NationalCode",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "StudentPhone");

            migrationBuilder.RenameSequence(
                name: "Provincesequence",
                newName: "ProvinceSequence");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NationalCode",
                table: "Students",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
