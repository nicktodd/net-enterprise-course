using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace WeatherMicroservice
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
				var latString = context.Request.Query["lat"].FirstOrDefault();
				var longString = context.Request.Query["long"].FirstOrDefault();
				var latitude = latString.TryParse();
				var longitude = longString.TryParse();
				if (latitude.HasValue && longitude.HasValue)
				{
					var forecast = new List<WeatherReport>();
					for (var days = 1; days < 6; days++)
					{
						forecast.Add(new WeatherReport(latitude.Value, longitude.Value, days));
					}
					var json = JsonConvert.SerializeObject(forecast, Formatting.Indented);
					context.Response.ContentType = "application/json; charset=utf-8";
					await context.Response.WriteAsync(json);
				}
			});
        }
    }

	public class WeatherReport
	{
		public WeatherReport(double latitude, double longitude, int daysInFuture)
		{
			var generator = new Random((int)(latitude + longitude) + daysInFuture);

			HiTemperature = generator.Next(40, 100);
			LoTemperature = generator.Next(0, HiTemperature);
			AverageWindSpeed = generator.Next(0, 45);
			Conditions = PossibleConditions[generator.Next(0, PossibleConditions.Length - 1)];
		}

		private static readonly string[] PossibleConditions = new string[]
		{
		"Sunny",
		"Mostly Sunny",
		"Partly Sunny",
		"Partly Cloudy",
		"Mostly Cloudy",
		"Rain"
		};

		public int HiTemperature { get; }
		public int LoTemperature { get; }
		public int AverageWindSpeed { get; }
		public string Conditions { get; }
	}

	public static class Extensions
	{
		public static double? TryParse(this string input)
		{
			double result;
			if (double.TryParse(input, out result))
			{
				return result;
			}
			else
			{
				return default(double?);
			}
		}
	}
}
