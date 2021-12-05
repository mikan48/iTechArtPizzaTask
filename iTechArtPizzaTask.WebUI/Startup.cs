using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.Services;
using iTechArtPizzaTask.Infrastructure.Context;
using iTechArtPizzaTask.Infrastructure.Repositories;
using iTechArtPizzaTask.Infrastructure.Repositories.Fakes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddScoped<IPizzasService, PizzasService>();
            services.AddScoped<IIngridientsService, IngridientsService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ICartService, CartsService>();
            services.AddScoped<IUserService, UsersService>();

            //Infrastructure
            //services.AddScoped<IPizzasRepository, FakePizzasRepository>();
            services.AddScoped<IRepository<Pizza>, PizzasRepository>();
            services.AddScoped<IRepository<Ingridient>, IngridientsRepository>();
            services.AddScoped<IRepository<Order>, OrdersRepository>();
            services.AddScoped<IRepository<OrderedPizza>, CartsRepository>();
            services.AddScoped<IRepository<User>, UsersRepository>();
            services.AddDbContext<PizzaDeliveryContext>();

            //WebUI
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
