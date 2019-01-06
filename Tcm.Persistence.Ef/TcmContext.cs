using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tcm.Domain.Model;
using Tcm.Persistence.Ef.EntityConfigurations;

namespace Tcm.Persistence.Ef
{
    public class TcmContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<EducationCourse> EducationCourses  { get; set; }
    public DbSet<ClassRoom> ClassRooms  { get; set; }
public DbSet<ClassStudent> ClassStudents  { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EducationSubCourse> EducationSubCourses  { get; set; }
        public DbSet<Major> Majors  { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers  { get; set; }
        public DbSet<School> Schools  { get; set; }
        public DbSet<SchoolEducationSubCourse> SchoolEducationSubCourses  { get; set; }
        public DbSet<SchoolSubType> SchoolSubTypes  { get; set; }
        public DbSet<SchoolType> SchoolTypes { get; set; }
        public DbSet<Student> Students  { get; set; }
        








public TcmContext(DbContextOptions<TcmContext> dbContextOptions) : base(dbContextOptions)
        {

            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TcmContext).Assembly);
    
            base.OnModelCreating(modelBuilder);
        }
    }
}
