using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MvcMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                    {
                        options.Limits.MaxConcurrentConnections = 100;
                        options.Limits.MaxConcurrentUpgradedConnections = 100;
                        options.Limits.MaxRequestBodySize = 10 * 1024;
                        options.Limits.MinRequestBodyDataRate = 
                            new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                        options.Limits.MinResponseDataRate = 
                        // options.Listen(IPAddress.Loopback, 5000);
                        // options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                        // {
                        //     listenOptions.UseHttps("testCert.pfx", "testPassword");
                        // });
                            new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    })
                .Build();
    }

}