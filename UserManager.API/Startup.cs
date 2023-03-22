using Microsoft.EntityFrameworkCore;
using UserManager.Core.Domain.Ports.Incoming;
using UserManager.Core.Domain.Ports.Outgoing;
using UserManager.Infrastructure.Persistence;
using UserManager.Core.Domain.Ports.Adapters;
using UserManager.Infrastructure.Adapters;
using UserManager.Service.Contracts;
using UserManager.Service;

namespace UserManager.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<UserManagerDbContext>(opts => opts.UseInMemoryDatabase("users_db"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserPort, UserAdapter>();
            services.AddScoped<IUserDatabasePort, UserDatabaseAdapter>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
