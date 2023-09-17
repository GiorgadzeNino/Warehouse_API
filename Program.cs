//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{

////}
//app.UseSwagger();
//app.UseSwaggerUI();
//app.UseCors();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using BTUProject.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTUProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            using (var context = new WarehouseDbContext())
            {
                // Call the method to import data from CSV files
                WarehouseDbContext.ImportDataFromCsvFiles();

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}