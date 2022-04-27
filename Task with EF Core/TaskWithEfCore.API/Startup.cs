using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaskWithEfCore.API.Services.Orders;
using TaskWithEfCore.API.Services.Products;
using TaskWithEFCore.Infrastructure.Brokers;

namespace TaskWithEfCore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StorageBroker>();            
            AddServices(services);
            AddBrokers(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskWithEfCore.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskWithEfCore.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
        }
    }
}
