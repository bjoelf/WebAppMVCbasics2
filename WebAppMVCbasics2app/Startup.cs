using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Database;
using WebAppMVCbasics2app.Models;
using WebAppMVCbasics2app.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebAppMVCbasics2app
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            //DEn här ligger redan med pga projekttypen var MVC. Tomt projekt saknar detta(?)
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //******************************** Database connection ***********************************
            //Connection to database (local). Connectionstring in appsettings.json
            services.AddDbContext<PeopleDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //************************** Identity    ********************************************
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<PeopleDbContext>().AddDefaultTokenProviders();

            //**************************** Service IOC ***********************************************
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPersonLanguageService, PersonLanguageService>();

            //**************************** Repo: *****************************************************
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<ICityRepo, DbCityRepo>();
            services.AddScoped<ICountryRepo, DbCountryRepo>();
            services.AddScoped<ILanguageRepo, DbLanguageRepo>();
            services.AddScoped<IPersonLanguageRepo, DbPersonLanguageRepo>();


            //------------------------- CORS -----------------------------------------------------------
            services.AddCors(options =>{
                options.AddPolicy("ReactPolicy",
                    builder => {
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //Swagger
            services.AddSwaggerGen();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person CMS API V1");
            });


            app.UseRouting();

            //Cors
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
