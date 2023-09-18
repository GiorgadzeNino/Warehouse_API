using BTUProject.DataAccess;
using BTUProject.Interfaces;
using BTUProject.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BTUProject
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddEntityFrameworkProxies();
            services.AddDbContext<WarehouseDbContext>(options =>
                      options.UseSqlServer(Configuration.GetConnectionString("WarehouseDbContext")));
            services.AddTransient<WarehouseDbContext>();
            services.AddTransient<ICustomerAppSevice, CustomerAppService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // ConfigureServices method
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warehouse", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));


        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseCors(_MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WareHouse v1"));

            //app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api"), builder =>
            //{
            //    app.Run(async (context) =>
            //    {
            //        context.Response.ContentType = "text/html";
            //        context.Response.Headers[HeaderNames.CacheControl] = "no-store, no-cache, must-revalidate";
            //        await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
            //    });
            //});

        }
    }
}
