using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pemex.Products.API.Util;
using Pemex.Products.DAL.Database;
using Pemex.Products.Repository.CQRS.Advertisement.Commands;
using Pemex.Products.Service.Implementations;
using Pemex.Products.Service.Interfaces;
using System.Reflection;

namespace Pemex.Products.API
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.CreateMap<IFormFile, byte[]>().ConvertUsing(new MapperFormFileToByteArray());
                mc.CreateMap<byte[], string>().ConvertUsing(new MapperByteArrayToBase64String());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddCors();

            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAdvertisementService, AdvertisementService>();
            services.AddTransient<IEmailNotificationService, EmailNotificationService>();
            services.AddMediatR(typeof(CreateAdvertisementCommand).GetTypeInfo().Assembly);
            services.AddSingleton(mapper);
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

            //app.UseCors(options => options.WithOrigins("http://localhost:3000/").AllowAnyMethod());
            app.UseCors(builder => builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
