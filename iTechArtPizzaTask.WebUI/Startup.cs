using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.Services;
using iTechArtPizzaTask.Infrastructure.Context;
using iTechArtPizzaTask.Infrastructure.Repositories;
using iTechArtPizzaTask.Infrastructure.Repositories.Fakes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.WebUI
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
            //Core
            services.AddScoped<IService<Pizza>, PizzasService>();
            services.AddScoped<IService<Ingredient>, IngredientsService>();
            services.AddScoped<IService<Order>, OrdersService>();
            services.AddScoped<IService<Order>, CartsService>();
            services.AddScoped<IService<User>, UsersService>();
            services.AddScoped<IService<PizzasIngredient>, PizzasIngredientsService>();

            //Infrastructure
            //services.AddScoped<IPizzasRepository, FakePizzasRepository>();
            services.AddScoped<IRepository<Pizza>, PizzasRepository>();
            services.AddScoped<IRepository<Ingredient>, IngredientsRepository>();
            services.AddScoped<IRepository<Order>, OrdersRepository>();
            services.AddScoped<IRepository<Order>, CartsRepository>();
            services.AddScoped<IRepository<User>, UsersRepository>();
            services.AddScoped<IRepository<PizzasIngredient>, PizzasIngredientsRepository>();
            services.AddDbContext<PizzaDeliveryContext>();

            //WebUI
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                        };
                    });
            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<PizzaDeliveryContext>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArtPizzaTask", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iTechArtPizzaTask v1"));


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
