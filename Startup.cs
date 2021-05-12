using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_With_Inherited_Interface.AnotherDataService;
using DI_With_Inherited_Interface.DataService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DI_With_Inherited_Interface
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
            services.AddScoped<IAnotherDataService, AnotherDataService.AnotherDataService>();

            //services.AddScoped<DataServiceLayer>();
            //services.AddScoped<I2, DataServiceLayer>();
            //services.AddScoped<I1, DataServiceLayer>();

            services.AddScoped<DataServiceLayer>();
            services.AddScoped<I2>(a => a.GetRequiredService<DataServiceLayer>());
            services.AddScoped<I1>(a => a.GetRequiredService<DataServiceLayer>());
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
