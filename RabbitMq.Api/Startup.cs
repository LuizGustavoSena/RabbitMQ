using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RabbitMq.CrossCutting;
using RabbitMq.Domain.AutoMapper;
using RabbitMq.Domain.Commands.v1.ConsultRabbitMq;
using RabbitMq.Domain.Commands.v1.InsertRabbitMq;
using RabbitMq.Domain.Interface.Tools;
using RabbitMq.Infrastrucuture.RabbitMq.v1.GetRabbitMq;
using RabbitMq.Infrastrucuture.RabbitMq.v1.SetRabbitMq;
using System.Reflection;

namespace RabbitMq.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RabbitMq.Api", Version = "v1" });
            });

            services.Configure<AppSettings>(Configuration.GetSection(AppSettings.ActionName));

            services.AddMediatR(typeof(InsertRabbitMqCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ConsultRabbitMqCommand).GetTypeInfo().Assembly);

            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.AddSingleton<ISetRabbitMq, SetRabbitMq>();
            services.AddSingleton<IGetRabbitMq, GetRabbitMq>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMq.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
