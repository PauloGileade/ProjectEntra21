using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjectEntra21.src.Application.Database;
using ProjectEntra21.src.Application.Mapper;
using ProjectEntra21.src.Infrastructure;
using ProjectEntra21.src.Infrastructure.Database.Repositories;
using System.Reflection;

namespace ProjectEntra21
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
            services.AddDbContextPool<DatabaseContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("TextileAutomationBD"), 
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("TextileAutomationBD"))));
            services.AddTransient<IEmployeerRepository, EmployeerRepository>();
            services.AddTransient<ICellRepository, CellRepository>();
            services.AddTransient<ICellEmployeerRepository, CellEmployeerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddControllers();
            services.AddAutoMapper(typeof(CellEmployeerMapper));
            services.AddAutoMapper(typeof(CellMapper));
            services.AddAutoMapper(typeof(EmployeerMapper));
            services.AddAutoMapper(typeof(OrderMapper));
            services.AddAutoMapper(typeof(ProductMapper));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectEntra21", Version = "v1" });
            });
    
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectEntra21 v1"));
            }

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

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