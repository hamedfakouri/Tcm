using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class schoolChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_SchoolEducationSubCourses_SchoolEducationSubCourseEducationSubCourseId_SchoolEducationSubCourseMajorId_SchoolEduc~",
                table: "ClassRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_ClassRooms_ClassRoomId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationCourses_EducationLevels_EducationLevelId",
                table: "EducationCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationSubCourses_EducationCourses_EducationCourseId",
                table: "EducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationSubCourses_EducationSubCourses_EducationSubCourseId",
                table: "SchoolEducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationSubCourses_Majors_MajorId",
                table: "SchoolEducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationSubCourses_Schools_SchoolId",
                table: "SchoolEducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SchoolSubTypes_SchoolSubTypeId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SchoolTypes_SchoolTypeId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropSequence(
                name: "PhoneNumbersequence");

            migrationBuilder.AlterColumn<short>(
                name: "ShiftType",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber1",
                table: "Schools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber2",
                table: "Schools",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CityId",
                table: "Regions",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_SchoolEducationSubCourses_SchoolEducationSubCourseEducationSubCourseId_SchoolEducationSubCourseMajorId_SchoolEduc~",
                table: "ClassRooms",
                columns: new[] { "SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId" },
                principalTable: "SchoolEducationSubCourses",
                principalColumns: new[] { "EducationSubCourseId", "MajorId", "SchoolId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_ClassRooms_ClassRoomId",
                table: "ClassStudents",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationCourses_EducationLevels_EducationLevelId",
                table: "EducationCourses",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationSubCourses_EducationCourses_EducationCourseId",
                table: "EducationSubCourses",
                column: "EducationCourseId",
                principalTable: "EducationCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationSubCourses_EducationSubCourses_EducationSubCourseId",
                table: "SchoolEducationSubCourses",
                column: "EducationSubCourseId",
                principalTable: "EducationSubCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationSubCourses_Majors_MajorId",
                table: "SchoolEducationSubCourses",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationSubCourses_Schools_SchoolId",
                table: "SchoolEducationSubCourses",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SchoolSubTypes_SchoolSubTypeId",
                table: "Schools",
                column: "SchoolSubTypeId",
                principalTable: "SchoolSubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SchoolTypes_SchoolTypeId",
                table: "Schools",
                column: "SchoolTypeId",
                principalTable: "SchoolTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_SchoolEducationSubCourses_SchoolEducationSubCourseEducationSubCourseId_SchoolEducationSubCourseMajorId_SchoolEduc~",
                table: "ClassRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_ClassRooms_ClassRoomId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationCourses_EducationLevels_EducationLevelId",
                table: "EducationCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationSubCourses_EducationCourses_EducationCourseId",
                table: "EducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationSubCourses_EducationSubCourses_EducationSubCourseId",
                table: "SchoolEducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationSubCourses_Majors_MajorId",
                table: "SchoolEducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEducationSubCourses_Schools_SchoolId",
                table: "SchoolEducationSubCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SchoolSubTypes_SchoolSubTypeId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_SchoolTypes_SchoolTypeId",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber1",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "Schools");

            migrationBuilder.CreateSequence(
                name: "PhoneNumbersequence",
                incrementBy: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "ShiftType",
                table: "Schools",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    PhoneType = table.Column<int>(nullable: false),
                    SchoolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_SchoolId",
                table: "PhoneNumbers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_SchoolEducationSubCourses_SchoolEducationSubCourseEducationSubCourseId_SchoolEducationSubCourseMajorId_SchoolEduc~",
                table: "ClassRooms",
                columns: new[] { "SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId" },
                principalTable: "SchoolEducationSubCourses",
                principalColumns: new[] { "EducationSubCourseId", "MajorId", "SchoolId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_ClassRooms_ClassRoomId",
                table: "ClassStudents",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationCourses_EducationLevels_EducationLevelId",
                table: "EducationCourses",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationSubCourses_EducationCourses_EducationCourseId",
                table: "EducationSubCourses",
                column: "EducationCourseId",
                principalTable: "EducationCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationSubCourses_EducationSubCourses_EducationSubCourseId",
                table: "SchoolEducationSubCourses",
                column: "EducationSubCourseId",
                principalTable: "EducationSubCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationSubCourses_Majors_MajorId",
                table: "SchoolEducationSubCourses",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEducationSubCourses_Schools_SchoolId",
                table: "SchoolEducationSubCourses",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Cities_CityId",
                table: "Schools",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SchoolSubTypes_SchoolSubTypeId",
                table: "Schools",
                column: "SchoolSubTypeId",
                principalTable: "SchoolSubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_SchoolTypes_SchoolTypeId",
                table: "Schools",
                column: "SchoolTypeId",
                principalTable: "SchoolTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
