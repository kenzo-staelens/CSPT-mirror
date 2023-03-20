using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Repositories;

namespace webapi {
    public class IoCBuilder {
        internal static IContainer Build() {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterTypes(builder);
            return builder.Build();
        }

        private static void RegisterTypes(ContainerBuilder builder) {
            builder.RegisterType<AttendanceRepository>().As<IAttendanceRepository>();
            builder.RegisterType<CoachRepository>().As<ICoachRepository>();
            builder.RegisterType<RaceRepository>().As<IRaceRepository>();
            builder.RegisterType<ResultRepository>().As<IResultRepository>();
            builder.RegisterType<SwimmerRepository>().As<ISwimmerRepository>();
            builder.RegisterType<SwimmingPoolRepository>().As<ISwimmingPoolRepository>();
            builder.RegisterType<WorkoutRepository>().As<IWorkoutRepository>();
        }
    }
}
