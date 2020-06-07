using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace quartz_app
{
    public class ConfigureService
    {
        public static void Configure()
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<CommonScheduler>(s =>
                {
                    s.ConstructUsing(name => new CommonScheduler());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Topshelf with Quartz");
                x.SetDisplayName("Topshelf with Quartz");
                x.SetServiceName("Topshelf-Quartz");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }

    }
}
