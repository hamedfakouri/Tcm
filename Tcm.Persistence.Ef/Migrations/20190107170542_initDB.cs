using Microsoft.EntityFrameworkCore.Migrations;

namespace Tcm.Persistence.Ef.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Citysequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "ClassRoomsequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "EducationCoursesequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "EducationLevelsequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "EducationSubCoursesequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Majorsequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "PhoneNumbersequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "ProvinceSequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Schoolsequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SchoolSubTypesequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SchoolTypesequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Studentsequence",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "UserSequence",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTypes",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NationalCode = table.Column<long>(nullable: false),
                    StudentNumber = table.Column<string>(nullable: true),
                    StudentPhone = table.Column<string>(nullable: true),
                    TrackerPhone = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    FatherPhone = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationCourses",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EducationLevelId = table.Column<short>(nullable: false),
                    AllowAssignMajor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationCourses_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSubTypes",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SchoolTypeId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSubTypes_SchoolTypes_SchoolTypeId",
                        column: x => x.SchoolTypeId,
                        principalTable: "SchoolTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationSubCourses",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EducationCourseId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationSubCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationSubCourses_EducationCourses_EducationCourseId",
                        column: x => x.EducationCourseId,
                        principalTable: "EducationCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    SchoolTypeId = table.Column<short>(nullable: false),
                    SchoolSubTypeId = table.Column<short>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    ShiftType = table.Column<bool>(nullable: false),
                    TotalStudentCount = table.Column<int>(nullable: false),
                    RegisterStudentCount = table.Column<int>(nullable: false),
                    CreationDate = table.Column<string>(nullable: true),
                    SchoolNumber = table.Column<string>(nullable: true),
                    FounderName = table.Column<string>(nullable: true),
                    ManagerName = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    WebUrl = table.Column<string>(nullable: true),
                    EducationCourseId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schools_EducationCourses_EducationCourseId",
                        column: x => x.EducationCourseId,
                        principalTable: "EducationCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolSubTypes_SchoolSubTypeId",
                        column: x => x.SchoolSubTypeId,
                        principalTable: "SchoolSubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolTypes_SchoolTypeId",
                        column: x => x.SchoolTypeId,
                        principalTable: "SchoolTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SchoolEducationSubCourses",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false),
                    EducationSubCourseId = table.Column<short>(nullable: false),
                    MajorId = table.Column<short>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    ClassCount = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEducationSubCourses", x => new { x.EducationSubCourseId, x.MajorId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_SchoolEducationSubCourses_EducationSubCourses_EducationSubCourseId",
                        column: x => x.EducationSubCourseId,
                        principalTable: "EducationSubCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolEducationSubCourses_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolEducationSubCourses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SchoolEducationSubCourseId = table.Column<long>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    SchoolEducationSubCourseEducationSubCourseId = table.Column<short>(nullable: false),
                    SchoolEducationSubCourseMajorId = table.Column<short>(nullable: false),
                    SchoolEducationSubCourseSchoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRooms_SchoolEducationSubCourses_SchoolEducationSubCourseEducationSubCourseId_SchoolEducationSubCourseMajorId_SchoolEduc~",
                        columns: x => new { x.SchoolEducationSubCourseEducationSubCourseId, x.SchoolEducationSubCourseMajorId, x.SchoolEducationSubCourseSchoolId },
                        principalTable: "SchoolEducationSubCourses",
                        principalColumns: new[] { "EducationSubCourseId", "MajorId", "SchoolId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    StudentId = table.Column<long>(nullable: false),
                    ClassRoomId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => new { x.ClassRoomId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ClassStudents_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_SchoolEducationSubCourseEducationSubCourseId_SchoolEducationSubCourseMajorId_SchoolEducationSubCourseSchoolId",
                table: "ClassRooms",
                columns: new[] { "SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCourses_EducationLevelId",
                table: "EducationCourses",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationSubCourses_EducationCourseId",
                table: "EducationSubCourses",
                column: "EducationCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_SchoolId",
                table: "PhoneNumbers",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEducationSubCourses_MajorId",
                table: "SchoolEducationSubCourses",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEducationSubCourses_SchoolId",
                table: "SchoolEducationSubCourses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CityId",
                table: "Schools",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_EducationCourseId",
                table: "Schools",
                column: "EducationCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SchoolSubTypeId",
                table: "Schools",
                column: "SchoolSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SchoolTypeId",
                table: "Schools",
                column: "SchoolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubTypes_SchoolTypeId",
                table: "SchoolSubTypes",
                column: "SchoolTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SchoolEducationSubCourses");

            migrationBuilder.DropTable(
                name: "EducationSubCourses");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EducationCourses");

            migrationBuilder.DropTable(
                name: "SchoolSubTypes");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "SchoolTypes");

            migrationBuilder.DropSequence(
                name: "Citysequence");

            migrationBuilder.DropSequence(
                name: "ClassRoomsequence");

            migrationBuilder.DropSequence(
                name: "EducationCoursesequence");

            migrationBuilder.DropSequence(
                name: "EducationLevelsequence");

            migrationBuilder.DropSequence(
                name: "EducationSubCoursesequence");

            migrationBuilder.DropSequence(
                name: "Majorsequence");

            migrationBuilder.DropSequence(
                name: "PhoneNumbersequence");

            migrationBuilder.DropSequence(
                name: "ProvinceSequence");

            migrationBuilder.DropSequence(
                name: "Schoolsequence");

            migrationBuilder.DropSequence(
                name: "SchoolSubTypesequence");

            migrationBuilder.DropSequence(
                name: "SchoolTypesequence");

            migrationBuilder.DropSequence(
                name: "Studentsequence");

            migrationBuilder.DropSequence(
                name: "UserSequence");
        }
    }
}
