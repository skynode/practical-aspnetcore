using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using System;

namespace HelloWorldWithReload 
{
    interface ICustomFeature 
    {
        string Greetings {get;}
    }

    public class CustomFeature : ICustomFeature
    {
        public string  Greetings => "This is my custom feature set from previous middleware";
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next ) =>{
                context.Features.Set<ICustomFeature>(new CustomFeature());
                await next.Invoke();
            });

            app.Run(context =>
            {
                var custom = context.Features.Get<ICustomFeature>();
                if (custom == null)
                    return context.Response.WriteAsync($"Custom is null");
                else
                    return context.Response.WriteAsync($"hello {custom.Greetings}");
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