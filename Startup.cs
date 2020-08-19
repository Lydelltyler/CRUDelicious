using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;// Add this
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using tenthMVP.Models; // Add this

namespace tenthMVP {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddSession (); 
            services.AddControllersWithViews();
            // services.AddDbContext<MyContext> (options => options.UseMySql (Configuration["DBInfo:ConnectionString"]));
            services.AddDbContext<MyContext>(options => options.UseSqlite("Data Source=MyContext.db")); // Add this
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

            app.UseDeveloperExceptionPage ();
            app.UseStaticFiles ();
            app.UseSession ();
            app.UseMvc ();

        }
    }
}