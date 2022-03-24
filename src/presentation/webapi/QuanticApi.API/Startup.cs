using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QuanticApi.Application.services.account;
using QuanticApi.Application.validators;
using QuanticApi.Core.security;
using QuanticApi.Domain.repositories;
using QuanticApi.Domain.services;
using QuanticApi.Infrastructure;
using QuanticApi.Persistence.contexts;
using QuanticApi.Persistence.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanticApi.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuanticApi.API", Version = "v1" });
            });

            services.AddDbContext<UserDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("LocalDb"));
            });
            services.AddScoped<IUserRegisterService, UserRegisterService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserDomainService, UserDomainService>();
            services.AddScoped<IPasswordHasher, CustomPasswordHashService>();
            services.AddScoped<IUserRegisterValidator, UserRegisterValidator>();

            
            
            

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod(); // GET,POST apida açýk, HTTPDELETE, HTTPUT içinde açmýþ olduk; 415 hatasýda HttpMethod izni verilmemiþtir.
                    policy.AllowAnyOrigin(); // Herhangi bir domaine istek atabiliriz.
                    //policy.WithOrigins("www.a.com", "www.b.com");
                    policy.AllowAnyHeader(); // Application/json appliation/xml
                    //policy.WithHeaders("x-token"); // Application/json appliation/xml
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuanticApi.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
