using FO4RKV_HFT_2022231.Logic.Classes;
using FO4RKV_HFT_2022231.Logic.Interface;
using FO4RKV_HFT_2022231.Models;
using FO4RKV_HFT_2022231.Repository.Database;
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
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MusicDbContext>();
            services.AddTransient<IRepository<Song>, SongRepository>();
            services.AddTransient<IRepository<Artist>, ArtistRepository>();
            services.AddTransient<IRepository<Publisher>, PublisherRepository>();
            services.AddTransient<ISongLogic, SongLogic>();
            services.AddTransient<IArtistLogic, ArtistLogic>();
            services.AddTransient<IPublisherLogic, PublisherLogic>();
            services.AddControllers();
            services.AddSwaggerGen(swagger => swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "FO4RKV_HFT_2022231.Endpoint", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(ui => ui.SwaggerEndpoint("/swagger/v1/swagger.json", "FO4RKV_HFT_2022231.Endpoint v1"));
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
