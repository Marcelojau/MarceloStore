using MarceloStore.Domain.StoreContext.Handlers;
using MarceloStore.Domain.StoreContext.Repositories;
using MarceloStore.Domain.StoreContext.Services;
using MarceloStore.Infra.StoreContexts.DataContexts;
using MarceloStore.Infra.StoreContexts.Repositories;
using MarceloStore.Infra.StoreContexts.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace MarceloStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            services.AddControllers();
            
            services.AddResponseCompression();

            services.AddScoped<MarceloDataContext, MarceloDataContext>();
            services.AddTransient<ICustomerRepositorie, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Marcelo Store", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marcelo Store Api V1");
            });

        }
    }
}
