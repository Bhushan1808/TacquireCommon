using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDbWebAPI.Commands;
using MongoDbWebAPI.Commands.Interfaces;
using MongoDbWebAPI.NewFolder;
using MongoDbWebAPI.Services;
using MongoDbWebAPI.Services.Interfaces;
using System;

namespace MongoDbWebAPI
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
            //Added Controller
            services.AddControllers();

            //Adding service for getting data from appsettings.json
            services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));

            //Added Commands
            services.AddScoped<IAddNewFileCommand, AddNewFileCommand>()
                .AddScoped(x=>new Lazy<IAddNewFileCommand>(
                ()=>x.GetRequiredService<IAddNewFileCommand>()));
            services.AddScoped<IGetAllFileDataCommand, GetAllFileDataCommand>()
                .AddScoped(x => new Lazy<IGetAllFileDataCommand>(
                () => x.GetRequiredService<IGetAllFileDataCommand>()));
            services.AddScoped<IGetByTimeStampRangeCommand, GetByTimeStampRangeCommand>()
                .AddScoped(x => new Lazy<IGetByTimeStampRangeCommand>(
                () => x.GetRequiredService<IGetByTimeStampRangeCommand>()));
            services.AddScoped<IGetByDeveloperNameCommand, GetByDeveloperNameCommand>()
                .AddScoped(x => new Lazy<IGetByDeveloperNameCommand>(
                () => x.GetRequiredService<IGetByDeveloperNameCommand>()));
            services.AddScoped<IGetByTimeStampCommand, GetByTimeStampCommand>()
                .AddScoped(x => new Lazy<IGetByTimeStampCommand>(
                () => x.GetRequiredService<IGetByTimeStampCommand>()));
            services.AddScoped<IGetByTimeZoneCommand, GetByTimeZoneCommand>()
                .AddScoped(x => new Lazy<IGetByTimeZoneCommand>(
                () => x.GetRequiredService<IGetByTimeZoneCommand>()));
            services.AddScoped<IDeleteFileCommand, DeleteFileCommand>()
                .AddScoped(x => new Lazy<IDeleteFileCommand>(
                () => x.GetRequiredService<IDeleteFileCommand>()));

            //AddedServices
            services.AddScoped<DataBaseOperationHandler>();
            services.AddScoped<IAddNewFileService, AddNewFileService>();
            services.AddScoped<IGetAllFileDataService, GetAllFileDataService>();
            services.AddScoped<IGetByTimeStampRangeService, GetByTimeStampRangeService>();
            services.AddScoped<IGetByDeveloperNameService, GetByDeveloperNameService>();
            services.AddScoped<IGetByTimeStampService, GetByTimeStampService>();
            services.AddScoped<IGetByTimeZoneService, GetByTimeZoneService>();
            services.AddScoped<IDeleteFileService, DeleteFileService>();

            //Adding Swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Second Backend Api", Version = "v1" });

            });

            //Adding CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors("MyPolicy");

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
