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
            services.AddDbContext<MusicalContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Scoped);
            services.AddDbContext<OuterContext>(option => option.UseSqlServer(Configuration.GetConnectionString("OuterConnection")), ServiceLifetime.Scoped);

            services.AddScoped<GenreService>();
            services.AddScoped<ArtistService>();
            services.AddScoped<MusicService>();
            //services.AddAutoMapper();
            services.AddScoped<IRepository<Genre>, GenreRepository>();
            services.AddScoped<IRepository<Artist>, ArtistRepository>();
            services.AddScoped<IRepository<Music>, MusicRepository>();

            services.AddScoped<IOuterRepository<Genre>, OuterGenreRepository>();
            services.AddScoped<IOuterRepository<Artist>, OuterArtistRepository>();

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
