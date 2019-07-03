using System;
using Topshelf;

namespace LMDirect.SocketService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            HostFactory.Run(x =>
            {
                x.Service<SocketService>(s =>
                {
                    s.ConstructUsing(name => new SocketService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                //x.SetDescription("LMDirect Service");
                //x.SetDisplayName("LMDirect Service");
                //x.SetServiceName("LMDirectService");
            });
        }
    }
}
