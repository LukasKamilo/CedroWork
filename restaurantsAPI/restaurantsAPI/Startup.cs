using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using restaurantsAPI.Context;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace restaurantsAPI
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

			var connection = @"Server=(localdb)\mssqllocaldb;Database=DB_Restaurant;Trusted_Connection=True;ConnectRetryCount=0";
			services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(connection));

			// Register the Swagger generator, defining one or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "RestaurantAPI", Version = "v1" });

				// Set the comments path for the Swagger JSON and UI.
				var basePath = AppContext.BaseDirectory;
				var xmlPath = Path.Combine(basePath, "restaurantsAPI.xml");
				c.IncludeXmlComments(xmlPath);
			});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantAPI V1");
			});

			app.UseMvc();
        }
    }
}
