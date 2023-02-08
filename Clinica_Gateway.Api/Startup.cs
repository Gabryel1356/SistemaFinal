using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Clinica_Gateway.Aplicacion;

namespace Clinica_Gateway.Api
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
   
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddControllers();
       
            services.AddSwaggerGen();

            services.AddPacientes(Configuration);

            services.AddServicios(Configuration);

          
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/",
                   async context =>
                   {
                       string color = env.IsDevelopment() ? "Gray" : "Green";
                       await context.Response.WriteAsync($"<h1 style='color:{color};'>[MS.Api] Environment: <a href='/swagger'>{env.EnvironmentName}</a></h1>");
                   });
            });
        }


    }
}
