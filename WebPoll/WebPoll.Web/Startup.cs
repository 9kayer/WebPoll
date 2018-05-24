using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebPoll.Repository;
using Microsoft.EntityFrameworkCore;
using WebPoll.OuterRepository;
using WebPoll.Web.Services;
using AutoMapper;
using WebPoll.Model.Models;

namespace WebPoll.Web
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
            services.AddDbContext<MusicalContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
            services.AddDbContext<OuterContext>(option => option.UseSqlServer(Configuration.GetConnectionString("OuterConnection")), ServiceLifetime.Scoped);
            
            services.AddScoped<GenreService>();
            services.AddScoped<ArtistService>();
            services.AddScoped<MusicService>();
            services.AddAutoMapper();
            services.AddScoped<IRepository<Genre>, GenreRepository>();
            services.AddScoped<IRepository<Artist>, ArtistRepository>();
            services.AddScoped<IRepository<Music>, MusicRepository>();

            services.AddScoped<IOuterRepository<Genre>, OuterGenreRepository>();
            services.AddScoped<IOuterRepository<Artist>, OuterArtistRepository>();

            services.AddCors();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                );

            app.UseMvc();
        }
    }
}
