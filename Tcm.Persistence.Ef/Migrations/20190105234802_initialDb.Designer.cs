﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tcm.Persistence.Ef;

namespace Tcm.Persistence.Ef.Migrations
{
    [DbContext(typeof(TcmContext))]
    [Migration("20190105234802_initialDb")]
    partial class initialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.Citysequence", "'Citysequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ClassRoomsequence", "'ClassRoomsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.EducationCoursesequence", "'EducationCoursesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.EducationLevelsequence", "'EducationLevelsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.EducationSubCoursesequence", "'EducationSubCoursesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Majorsequence", "'Majorsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.PhoneNumbersequence", "'PhoneNumbersequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ProvinceSequence", "'ProvinceSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Schoolsequence", "'Schoolsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.SchoolSubTypesequence", "'SchoolSubTypesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.SchoolTypesequence", "'SchoolTypesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Studentsequence", "'Studentsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.UserSequence", "'UserSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tcm.Domain.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Citysequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.Property<short>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "ClassRoomsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.Property<short>("SchoolEducationSubCourseEducationSubCourseId");

                    b.Property<long>("SchoolEducationSubCourseId");

                    b.Property<short>("SchoolEducationSubCourseMajorId");

                    b.Property<long>("SchoolEducationSubCourseSchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassStudent", b =>
                {
                    b.Property<long>("ClassRoomId");

                    b.Property<long>("StudentId");

                    b.Property<long>("Id");

                    b.Property<short>("Year");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassStudents");
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationCourse", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EducationCoursesequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<bool>("AllowAssignMajor");

                    b.Property<short>("EducationLevelId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EducationLevelId");

                    b.ToTable("EducationCourses");
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationLevel", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EducationLevelsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EducationLevels");
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationSubCourse", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EducationSubCoursesequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<short>("EducationCourseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EducationCourseId");

                    b.ToTable("EducationSubCourses");
                });

            modelBuilder.Entity("Tcm.Domain.Model.Major", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Majorsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("Tcm.Domain.Model.PhoneNumber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "PhoneNumbersequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Phone");

                    b.Property<int>("PhoneType");

                    b.Property<long?>("SchoolId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Tcm.Domain.Model.Province", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "ProvinceSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Tcm.Domain.Model.School", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Schoolsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("CityId");

                    b.Property<string>("CreationDate");

                    b.Property<short?>("EducationCourseId");

                    b.Property<string>("FounderName");

                    b.Property<string>("ManagerName");

                    b.Property<string>("Name");

                    b.Property<string>("PostalAddress");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<int>("RegisterStudentCount");

                    b.Property<string>("SchoolNumber");

                    b.Property<short>("SchoolSubTypeId");

                    b.Property<short>("SchoolTypeId");

                    b.Property<bool>("Sex");

                    b.Property<bool>("ShiftType");

                    b.Property<int>("TotalStudentCount");

                    b.Property<string>("WebUrl");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("EducationCourseId");

                    b.HasIndex("SchoolSubTypeId");

                    b.HasIndex("SchoolTypeId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolEducationSubCourse", b =>
                {
                    b.Property<short>("EducationSubCourseId");

                    b.Property<short>("MajorId");

                    b.Property<long>("SchoolId");

                    b.Property<int>("ClassCount");

                    b.Property<long>("Id");

                    b.HasKey("EducationSubCourseId", "MajorId", "SchoolId");

                    b.HasIndex("MajorId");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolEducationSubCourses");
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolSubType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "SchoolSubTypesequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.Property<short?>("SchoolTypeId");

                    b.HasKey("Id");

                    b.HasIndex("SchoolTypeId");

                    b.ToTable("SchoolSubTypes");
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "SchoolTypesequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SchoolTypes");
                });

            modelBuilder.Entity("Tcm.Domain.Model.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Studentsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("FatherName");

                    b.Property<string>("FatherPhone");

                    b.Property<string>("HomeAddress");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<long>("NationalCode");

                    b.Property<string>("StudentNumber");

                    b.Property<string>("StudentPhone");

                    b.Property<string>("TrackerPhone");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Tcm.Domain.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "UserSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tcm.Domain.Model.City", b =>
                {
                    b.HasOne("Tcm.Domain.Model.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassRoom", b =>
                {
                    b.HasOne("Tcm.Domain.Model.SchoolEducationSubCourse", "SchoolEducationSubCourse")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassStudent", b =>
                {
                    b.HasOne("Tcm.Domain.Model.ClassRoom", "ClassRoom")
                        .WithMany("ClassStudents")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tcm.Domain.Model.Student", "Student")
                        .WithMany("ClassStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationCourse", b =>
                {
                    b.HasOne("Tcm.Domain.Model.EducationLevel", "EducationLevel")
                        .WithMany("EducationCourses")
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationSubCourse", b =>
                {
                    b.HasOne("Tcm.Domain.Model.EducationCourse", "EducationCourse")
                        .WithMany("EducationSubCourses")
                        .HasForeignKey("EducationCourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.PhoneNumber", b =>
                {
                    b.HasOne("Tcm.Domain.Model.School", "School")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("Tcm.Domain.Model.School", b =>
                {
                    b.HasOne("Tcm.Domain.Model.City", "City")
                        .WithMany("Schools")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tcm.Domain.Model.EducationCourse")
                        .WithMany("Schools")
                        .HasForeignKey("EducationCourseId");

                    b.HasOne("Tcm.Domain.Model.SchoolSubType", "SchoolSubType")
                        .WithMany("Schools")
                        .HasForeignKey("SchoolSubTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tcm.Domain.Model.SchoolType", "SchoolType")
                        .WithMany("Schools")
                        .HasForeignKey("SchoolTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolEducationSubCourse", b =>
                {
                    b.HasOne("Tcm.Domain.Model.EducationSubCourse", "EducationSubCourse")
                        .WithMany("SchoolEducationSubCourses")
                        .HasForeignKey("EducationSubCourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tcm.Domain.Model.Major", "Major")
                        .WithMany("SchoolEducationSubCourses")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tcm.Domain.Model.School", "School")
                        .WithMany("SchoolEducationSubCourses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolSubType", b =>
                {
                    b.HasOne("Tcm.Domain.Model.SchoolType", "SchoolType")
                        .WithMany()
                        .HasForeignKey("SchoolTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
