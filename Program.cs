using System;
using System.IO;
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
			.UseContentRoot(Directory.GetCurrentDirectory()) //ref: so this works: return View("~/helloworld.cshtml"); explicit filename
			.UseKestrel()
			.UseStartup<Startup>()
			.Build();

		host.Run();
        }
    }

	//configure runs first, then configureServices
	public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		
		public void Configure(IApplicationBuilder app)
		{
			//app.UseDeveloperExceptionPage();
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

	public class HelloWorldController: Controller
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

		[HttpGet("helloworld")]
		public ActionResult HelloWorldMvc()
		{
			ViewBag.Message = "Hello World";
			ViewBag.Time = DateTime.Now;

			return View("~/helloworld.cshtml");
			
		}
	}
}
