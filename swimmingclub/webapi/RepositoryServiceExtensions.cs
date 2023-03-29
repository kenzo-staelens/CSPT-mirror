using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using webapi.Repositories;
using webapi.Helper;

namespace Extensions {
    public static class RepositoryServiceExtensions {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration config) {

            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<ICoachRepository, CoachRepository>();
            services.AddTransient<IRaceRepository, RaceRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISwimmerRepository, SwimmerRepository>();
            services.AddTransient<ISwimmingPoolRepository, SwimmingPoolRepository>();
            services.AddTransient<IWorkoutRepository, WorkoutRepository>();
            services.AddTransient<IPersoonRepository, PersoonRepository>();

            return services;
        }
    }
}
