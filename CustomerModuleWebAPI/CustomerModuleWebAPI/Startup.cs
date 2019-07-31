using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingHistoryModuleWebAPI.Models;
using BookingHistoryModuleWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BookingHistoryModuleWebAPI
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
            services.Configure<MongoSettings>(Configuration.GetSection("BookingHistoryDbSettings"));

            services.AddSingleton<IMongoSettings>(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.AddSingleton<BookingHistoryService>();

            //services.AddScoped<BookingHistoryService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "BookingHistory API",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Trupti Pawar",
                        Email = "truptip@hexaware.com"
                    }
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            //if (env.IsDevelopment())
            //{
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingHistory API");
                    c.RoutePrefix = "";
                });
            //}

            app.UseMvc();
        }
    }
}
