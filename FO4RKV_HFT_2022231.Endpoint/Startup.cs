using FO4RKV_HFT_2022231.Logic.Classes;
using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.ModelRepositories;
using FO4RKV_HFT_2022231.Repository.RepositoryInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FO4RKV_HFT_2022231.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository<Song>, SongRepository>();
            services.AddTransient<IRepository<Artist>, ArtistRepository>();
            services.AddTransient<IRepository<Publisher>, PublisherRepository>();

            services.AddTransient<ISongLogic, SongLogic>();
            services.AddTransient<IArtistLogic, ArtistLogic>();
            services.AddTransient<IPublisherLogic, PublisherLogic>();

            services.AddControllers();
            services.AddSwaggerGen(swagger => swagger.SwaggerDoc("Swagger", new OpenApiInfo { Title = "FO4RKV_HFT_2022232", Version = "1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(ui => ui.SwaggerEndpoint("/swagger/Swagger/swagger.json", "FO4RKV_HFT_2022232 v1"));
            }

            app.UseExceptionHandler(handler => handler.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
