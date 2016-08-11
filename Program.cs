using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;	
using Microsoft.AspNetCore.Mvc;	
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
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

	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}

/* no Mvc
		public void Configure(IApplicationBuilder app)
		{

			//before Run()
			app.Use(async (context, next) =>
			{
				await context.Response.WriteAsync("Pre Processing");

				await next();

				await context.Response.WriteAsync("Post Processing");
			});

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World, The time is: " + DateTime.Now.ToString("hh:mm:ss tt"));
			});

		}
*/
	}

	public class HelloWorldController 
	{
		[HttpGet("api/helloworld")]
		public object HelloWorld()
		{
			return new
			{
				message = "Hello World",
				time = DateTime.Now
			};
		}
	}
}
