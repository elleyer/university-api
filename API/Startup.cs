using System;
using Admin.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => 
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            
            var con = "Server=localhost;Database=master;User=root;";

            services.AddDbContext<FacultyContext>(options => 
                options.UseLazyLoadingProxies().UseMySql(con,
                    mysqloptions => mysqloptions.ServerVersion
                        (new Version(10,5,5), ServerType.MariaDb)));
            
            services.AddDbContext<SchedulerContext>(options => 
                options.UseLazyLoadingProxies().UseMySql(con,
                    mysqloptions => mysqloptions.ServerVersion
                        (new Version(10,5,5), ServerType.MariaDb)));

            services.AddControllers();
            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}