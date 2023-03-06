using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class IoCBuilder {
        internal static IContainer Build() {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterTypes(builder);
            return builder.Build();
        }

        private static void RegisterTypes(ContainerBuilder builder) {
            //builder.RegisterType<IDataLoader>().As<RepoDataLoader>();
        }
    }
}
