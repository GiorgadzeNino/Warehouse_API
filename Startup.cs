using BTUProject.DataAccess;
using Microsoft.EntityFrameworkCore;

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

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lennt v1"));
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
