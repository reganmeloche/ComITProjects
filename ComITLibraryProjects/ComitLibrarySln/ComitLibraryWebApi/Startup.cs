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

using ComitLibrary;
using ComitLibrary.Models;
using ComitLibrary.Storage;

namespace ComitLibraryWebApi
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
            services.AddControllers();

             // Build a singleton LibrarySystem instance and inject it into any controller that needs it
            
            // Initialize the List implementations for the storage systems
            var bookStorage = new BookStorageList();
            var patronStorage = new PatronStorageList();
            var loanStorage = new LoanStorageList();
            
            // Inject the storage systems into the LibrarySystem
            var _library = new LibrarySystem(bookStorage, patronStorage, loanStorage);

            // And then inject that LibrarySystem as a service into the web application
            services.AddSingleton<LibrarySystem>(_library);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
