using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NietPathe.Models.Movies;
using NietPathe.Models.Performances;
using NietPathe.Models.Halls;
using NietPathe.Models.Tickets;
using NietPathe.Models.Reviews;
using NietPathe.Models;
using MongoDB.Driver;

namespace NietPathe
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
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDB:Database").Value;
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton<IMongoClient, MongoClient>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IPerformanceRepository, PerformanceRepository>();
            services.AddTransient<IHallRepository, HallRepository>();
            services.AddTransient<IDataContext, DataContext>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("CorsPolicy");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseCookiePolicy();

            app.UseMvcWithDefaultRoute();
            app.UseStatusCodePages();

            app.MapWhen(context => context.Request.Path.Value.StartsWith("/secure", StringComparison.CurrentCulture), builder =>
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute("secure-fallback", "Secure", new { controller = "Secure", action = "Index" });
                });
            });

            app.MapWhen(context => context.Request.Path.Value.StartsWith("/ticket", StringComparison.CurrentCulture), builder =>
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute("ticket-fallback", "Ticket", new { controller = "Ticket", action = "Index" });
                });
            });

            app.MapWhen(context => context.Request.Path.Value.StartsWith("/web", StringComparison.CurrentCulture), builder =>
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute("web-fallback", "Web", new { controller = "Web", action = "Index" });
                });
            });

        }
    }
}

/*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Demo Week 1", Version = "v1" });
            });

         
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Week 1 - Version 1");
            });
 */