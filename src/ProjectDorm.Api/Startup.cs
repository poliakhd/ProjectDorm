using System;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectDorm.Domain.Database;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Database.Providers;
using ProjectDorm.Domain.Database.Providers.Interfaces;
using ProjectDorm.Domain.Database.Repositories;
using ProjectDorm.Domain.Options;
using ProjectDorm.Infrastructure.Providers;
using ProjectDorm.Infrastructure.Providers.Interfaces;
using ProjectDorm.Infrastructure.Services;
using ProjectDorm.Infrastructure.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjectDorm.Api
{
    /// <summary>
    /// App startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method for adding app services
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/> instances</param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

            services.AddIdentity<AppUserEntity, AppUserRoleEntity>(o =>
                {
                    o.Password.RequiredLength = 4;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Dorm Booking Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Jwt bearer token",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            var key = Encoding.ASCII.GetBytes(Configuration["JwtOptions:Secret"]);

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return FromAutofac(services);
        }

        /// <summary>
        /// Method for configuring added services
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/> instance</param>
        /// <param name="env"><see cref="IHostingEnvironment"/> instance</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            app.UseMvc();
        }

        private IServiceProvider FromAutofac(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            RegisterDbContext(builder);

            builder.RegisterGeneric(typeof(EfDbRepository<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<LinqProvider>()
                .As<ILinqProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookingProvider>()
                .As<IBookingProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.Populate(services);

            var container = builder.Build();

            if (true)
            {
                var dbContext = container.Resolve<DbContext>();
                var userManager = container.Resolve<UserManager<AppUserEntity>>();

                if (dbContext.Database.EnsureCreated())
                {
                    var user = userManager.CreateAsync(new AppUserEntity() {UserName = "test"}, "test").Result;
                }
            }

            return new AutofacServiceProvider(container);
        }

        private void RegisterDbContext(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MsSqlServer"));

            builder.Register<AppDbContext>(x => new AppDbContext(optionsBuilder.Options))
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
