using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Globals;
using MySql.EntityFrameworkCore.Extensions;

namespace Data {
    public class WorkoutContext : DbContext{
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<SwimmingPool> SwimmingPools { get; set; }

        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options) { }

        public WorkoutContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("server=localhost;database=test;user=root;password=Kids2506#");
    }
}
