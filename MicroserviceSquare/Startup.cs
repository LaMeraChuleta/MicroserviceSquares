using MicroserviceSquare.Context;
using MicroserviceSquare.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MicroserviceSquare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //string corsPolity = "AllowAllOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //add cors for any origin             
            //services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDelegationRepository, DelegationRepository>();            
            services.AddDbContext<SquareCatalogContext>(options =>
            {
                options.UseSqlServer($"Server=localhost;Database=testSquare;User Id=SA;Password=LaVacaLoca16");                                
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroserviceSquare", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroserviceSquare v1"));
            }            
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
