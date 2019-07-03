using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace LMDirect.WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<LMDirectService>(s =>
                {
                    s.ConstructUsing(name => new LMDirectService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("LMDirect Service");
                x.SetDisplayName("LMDirect Service");
                x.SetServiceName("LMDirectService");
            });
        }
    }
}
