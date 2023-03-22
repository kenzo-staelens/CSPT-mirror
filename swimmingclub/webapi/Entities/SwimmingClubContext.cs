using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Xml.Serialization;

namespace webapi.Entities {
    public class SwimmingClubContext : IdentityDbContext<
            Member,
            Role,
            Guid,
            IdentityUserClaim<Guid>,
            MemberRole,
            IdentityUserLogin<Guid>,
            IdentityRoleClaim<Guid>,
            IdentityUserToken<Guid>
        > {

        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<SwimmingPool> SwimmingPools { get; set; }

        public SwimmingClubContext(DbContextOptions<SwimmingClubContext> options) : base(options) { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=SSPI;AttachDBFilename=C:\\Users\\User\\Desktop\\2223-cspt-staelenskenzo\\swimmingclub\\webapi\\test.mdf");
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Attendance>().HasKey(x => new { x.SwimmerId, x.WorkoutId });
            builder.Entity<Result>().HasKey(x => new { x.SwimmerId, x.RaceId});
            builder.Entity<Race>().HasKey(x => x.Id);
            builder.Entity<SwimmingPool>().HasKey(x => x.Id);
            builder.Entity<Workout>().HasKey(x => x.Id);

            builder.Entity<Member>().HasMany(x => x.MemberRoles).WithOne(x=>x.Member).IsRequired().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Role>().HasMany(x => x.MemberRoles).WithOne(x=>x.Role).IsRequired().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Workout>().HasMany(x => x.Attendances).WithOne(x => x.Workout).IsRequired().HasForeignKey(x => x.WorkoutId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Swimmer>().HasMany(x => x.Attendances).WithOne(x => x.Swimmer).IsRequired().HasForeignKey(x => x.SwimmerId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Swimmer>().HasMany(x => x.Results).WithOne(x => x.Swimmer).IsRequired().HasForeignKey(x => x.SwimmerId);
            builder.Entity<Race>().HasMany(x => x.Results).WithOne(x => x.Race).IsRequired().HasForeignKey(x => x.RaceId);

            builder.Entity<SwimmingPool>().HasMany(x => x.Races);
            builder.Entity<SwimmingPool>().HasMany(x => x.Workouts);
            builder.Entity<Coach>().HasMany(x => x.Workouts);

            builder.Entity<SwimmingPool>().HasIndex(x => x.Name).IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
