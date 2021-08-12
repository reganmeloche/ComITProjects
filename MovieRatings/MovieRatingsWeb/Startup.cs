using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MovieRatingsListDB;
using MovieRatingsLib;

namespace MovieRatingsWeb
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

            // Setup engine
            var listStore = new MovieStoreList();
            var movieRater = new MovieRater(listStore);

            // Populate with default values
            // var movie1 = movieRater.AddMovie("Jurassic park", "Steven Spielberg", 1993, new List<string>() {"Thriller"});
            // var movie2 = movieRater.AddMovie("Toy Story", "John Lasseter", 1995, new List<string>() {"Animation", "Comedy"});
            // var movie3 = movieRater.AddMovie("Titanic", "James Cameron", 1997, new List<string>() {"Drama"});

            // Inject 
            services.AddSingleton(movieRater);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
             
            // Need to add these in for wwwroot
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
