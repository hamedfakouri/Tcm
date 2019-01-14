using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tcm.Domain.IdentityModel;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef
{
    public class TcmContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public new DbSet<UserClaim> UserClaims { get; set; }
        public new DbSet<RoleClaim> RoleClaims { get; set; }
        public new DbSet<UserRole> UserRoles { get; set; }

        public new DbSet<UserLogin> UserLogins { get; set; }

        public new DbSet<UserToken> UserTokens { get; set; }
        public new DbSet<Role> Roles { get; set; }



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
