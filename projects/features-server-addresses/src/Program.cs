using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace HelloWorldWithReload 
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var serverAddress = app.ServerFeatures.Get<IServerAddressesFeature>();

            app.Run(context =>
            {
                var str = string.Empty;
                foreach(var a in serverAddress.Addresses)
                {
                    str += $"{a}\n";
                }
                return context.Response.WriteAsync(str);
            });
        }
    }
    
   public class Program
    {
        public static void Main(string[] args)
        {
              var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}