﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tcm.Persistence.Ef;

namespace Tcm.Persistence.Ef.Migrations
{
    [DbContext(typeof(TcmContext))]
    partial class TcmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.Citysequence", "'Citysequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.ClassRoomsequence", "'ClassRoomsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.EducationCoursesequence", "'EducationCoursesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.EducationLevelsequence", "'EducationLevelsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.EducationSubCoursesequence", "'EducationSubCoursesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Majorsequence", "'Majorsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Provincesequence", "'Provincesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Regionsequence", "'Regionsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Schoolsequence", "'Schoolsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.SchoolSubTypesequence", "'SchoolSubTypesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.SchoolTypesequence", "'SchoolTypesequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Studentsequence", "'Studentsequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.UserSequence", "'UserSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserLogin<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<int>");
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NationalCode");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("SchoolId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SchoolId");

                    b.ToTable("AspNetUsers");
                });

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

                    b.Property<int>("SchoolEducationSubCourseSchoolId");

                    b.Property<short>("Year");

                    b.HasKey("Id");

                    b.HasIndex("SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassStudent", b =>
                {
                    b.Property<long>("ClassRoomId");

                    b.Property<long>("StudentId");

                    b.Property<long>("Id");

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

            modelBuilder.Entity("Tcm.Domain.Model.Province", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Provincesequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Tcm.Domain.Model.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Regionsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("CityId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Tcm.Domain.Model.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Schoolsequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("CityId");

                    b.Property<string>("CreationDate");

                    b.Property<short>("EducationCourseId");

                    b.Property<string>("FounderName");

                    b.Property<string>("ManagerName");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber1");

                    b.Property<string>("PhoneNumber2");

                    b.Property<string>("PostalAddress");

                    b.Property<string>("PostalCode");

                    b.Property<int>("RegionId");

                    b.Property<int>("RegisterStudentCount");

                    b.Property<string>("SchoolNumber");

                    b.Property<short>("SchoolSubTypeId");

                    b.Property<short>("SchoolTypeId");

                    b.Property<bool>("Sex");

                    b.Property<short>("ShiftType");

                    b.Property<int>("TotalStudentCount");

                    b.Property<string>("WebUrl");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("EducationCourseId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SchoolSubTypeId");

                    b.HasIndex("SchoolTypeId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolEducationSubCourse", b =>
                {
                    b.Property<short>("EducationSubCourseId");

                    b.Property<short>("MajorId");

                    b.Property<int>("SchoolId");

                    b.Property<short>("ClassCount");

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

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("FatherName");

                    b.Property<string>("FatherPhone");

                    b.Property<string>("HomeAddress");

                    b.Property<string>("HomePhone");

                    b.Property<string>("Phone");

                    b.Property<string>("StudentNumber");

                    b.Property<string>("TrackerPhone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

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

            modelBuilder.Entity("Tcm.Domain.IdentityModel.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole<int>");

                    b.Property<string>("Title");

                    b.HasDiscriminator().HasValue("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "8ec51168-fc5d-4293-8a46-576a3d7a5506",
                            Name = "Manager",
                            NormalizedName = "MANAGER",
                            Title = "مدیر"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "d0a60048-8e41-4ce3-9fcf-2d39e434a5c1",
                            Name = "Student",
                            NormalizedName = "STUDENT",
                            Title = "دانش آموز"
                        });
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.RoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>");

                    b.HasDiscriminator().HasValue("RoleClaim");
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.UserClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>");

                    b.HasDiscriminator().HasValue("UserClaim");
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.UserLogin", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>");

                    b.HasDiscriminator().HasValue("UserLogin");
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<int>");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.UserToken", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserToken<int>");

                    b.HasDiscriminator().HasValue("UserToken");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Tcm.Domain.IdentityModel.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Tcm.Domain.IdentityModel.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tcm.Domain.IdentityModel.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Tcm.Domain.IdentityModel.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tcm.Domain.IdentityModel.ApplicationUser", b =>
                {
                    b.HasOne("Tcm.Domain.Model.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("Tcm.Domain.Model.City", b =>
                {
                    b.HasOne("Tcm.Domain.Model.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassRoom", b =>
                {
                    b.HasOne("Tcm.Domain.Model.SchoolEducationSubCourse", "SchoolEducationSubCourse")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SchoolEducationSubCourseEducationSubCourseId", "SchoolEducationSubCourseMajorId", "SchoolEducationSubCourseSchoolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.ClassStudent", b =>
                {
                    b.HasOne("Tcm.Domain.Model.ClassRoom", "ClassRoom")
                        .WithMany("ClassStudents")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.Student", "Student")
                        .WithMany("ClassStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationCourse", b =>
                {
                    b.HasOne("Tcm.Domain.Model.EducationLevel", "EducationLevel")
                        .WithMany("EducationCourses")
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.EducationSubCourse", b =>
                {
                    b.HasOne("Tcm.Domain.Model.EducationCourse", "EducationCourse")
                        .WithMany("EducationSubCourses")
                        .HasForeignKey("EducationCourseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.Region", b =>
                {
                    b.HasOne("Tcm.Domain.Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.School", b =>
                {
                    b.HasOne("Tcm.Domain.Model.City", "City")
                        .WithMany("Schools")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.EducationCourse", "EducationCourse")
                        .WithMany("Schools")
                        .HasForeignKey("EducationCourseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.Region", "Region")
                        .WithMany("Schools")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.SchoolSubType", "SchoolSubType")
                        .WithMany("Schools")
                        .HasForeignKey("SchoolSubTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.SchoolType", "SchoolType")
                        .WithMany("Schools")
                        .HasForeignKey("SchoolTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolEducationSubCourse", b =>
                {
                    b.HasOne("Tcm.Domain.Model.EducationSubCourse", "EducationSubCourse")
                        .WithMany("SchoolEducationSubCourses")
                        .HasForeignKey("EducationSubCourseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.Major", "Major")
                        .WithMany("SchoolEducationSubCourses")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Tcm.Domain.Model.School", "School")
                        .WithMany("SchoolEducationSubCourses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Tcm.Domain.Model.SchoolSubType", b =>
                {
                    b.HasOne("Tcm.Domain.Model.SchoolType", "SchoolType")
                        .WithMany()
                        .HasForeignKey("SchoolTypeId");
                });

            modelBuilder.Entity("Tcm.Domain.Model.Student", b =>
                {
                    b.HasOne("Tcm.Domain.IdentityModel.ApplicationUser", "User")
                        .WithOne("Student")
                        .HasForeignKey("Tcm.Domain.Model.Student", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
