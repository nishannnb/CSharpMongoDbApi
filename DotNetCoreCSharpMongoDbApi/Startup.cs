using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreCSharpMongoDbApi.IServices;
using DotNetCoreCSharpMongoDbApi.Models;
using DotNetCoreCSharpMongoDbApi.Services;
using DotNetCoreCSharpMongoDbApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreCSharpMongoDbApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			#region Edited

			MongoDBContext.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
			MongoDBContext.DatabaseName = Configuration.GetSection("MongoConnection:DatabaseName").Value;
			MongoDBContext.IsSSL = Convert.ToBoolean(Configuration.GetSection("MongoConnection:IsSSL").Value);
			
			////startup without context
			//services.Configure<Setting>(Options =>
			//{
			//	Options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
			//	Options.Database = Configuration.GetSection("MongoConnection:Database").Value;

			//});

			services.AddSingleton<IProductService, ProductService>();
			#endregion
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			#region Edited

			//// global policy, if assigned here (it could be defined indvidually for each controller) 
			//app.UseCors("CorsPolicy");


			//// Add service and create Policy with options 
			//services.AddCors(options =>
			//{
			//	options.AddPolicy("CorsPolicy",
			//	  builder => builder.AllowAnyOrigin()
			//						.AllowAnyMethod()
			//						.AllowAnyHeader()
			//						.AllowCredentials());
			//});

			#endregion

			app.UseMvc();
		}
	}
}
