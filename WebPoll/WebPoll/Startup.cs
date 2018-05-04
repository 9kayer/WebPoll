using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebPoll.Services;
using WebPoll.Model.Models;
using WebPoll.Repository;
using WebPoll.OuterRepository;
using WebPoll.Model.OuterModels;

namespace WebPoll
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
            services.AddDbContext<MusicalContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Singleton);
            services.AddDbContext<OuterContext>(option => option.UseSqlServer(Configuration.GetConnectionString("OuterConnection")), ServiceLifetime.Singleton);

            services.AddSingleton<GenreService>();
            services.AddSingleton<ArtistService>();
            services.AddSingleton<MusicService>();
            //services.AddAutoMapper();
            services.AddSingleton<IRepository<Genre>, GenreRepository>();
            services.AddSingleton<IRepository<Artist>, ArtistRepository>();
            services.AddSingleton<IRepository<Music>, MusicRepository>();

            services.AddScoped<IOuterRepository<OuterGenre>, OuterGenreRepository>();
            services.AddScoped<IOuterRepository<OuterArtist>, OuterArtistRepository>();

            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
