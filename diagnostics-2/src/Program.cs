using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace StartupBasic 
{
   public class Program
   {
        public static void Main(string[] args)
        {
              var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(app =>
                {
                    app.UseDeveloperExceptionPage(); //Don't use this in production
                    app.Run(context => throw new ApplicationException("Hello World Exception"));
                })
                .Build();

            host.Run();
        }
    }
}