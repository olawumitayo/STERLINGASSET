using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using STERLINGASSET.DATA;
using STERLINGASSET.DATA.Contracts;
using STERLINGASSET.DATA.Helpers;
using STERLINGASSET.DATA.Models;
using STERLINGASSET.DATA.Repository;

namespace STERLINGASSET
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        private IConfigurationRoot _configurationRoot;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();          
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISetupUnitOfWork, SetupUnitOfWork>();
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();
            services.AddSingleton<RepositoryFactories>();
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDbContext<STERLINGASSETContext>(options => options.UseSqlServer("Server=.\\FINTRAKSQL;Database=STERLINGASSET;user id=sa; password=sqluser10$;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
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
                    template: "{controller=Customer}/{action=Index}/{id?}");
            });
        }
    }
}
