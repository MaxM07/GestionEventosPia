﻿using GestiondeEventos.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace GestiondeEventos
{
    public class Startup
    {

        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddTransient<IService, ServiceA>();

            services.AddTransient<ServiceTransient>();
            services.AddScoped<ServiceScoped>();
            services.AddSingleton<ServiceSingleton>();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c=>
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title="Api Gestion de Eventos", Version="v1"}));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

