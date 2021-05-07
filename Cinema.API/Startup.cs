using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cinema.API.Models;
using Cinema.DAL.Auth;
using Cinema.DAL.EF;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Sessions;
using Cinema.Services.Models;
using Cinema.Services.Models.Sessions;
using Cinema.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Cinema.API
{
    public class Startup
    {
        private readonly ILogger _logger;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // TODO:
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,

                        ValidIssuer = AuthOptions.Issuer,

                        ValidateAudience = true,

                        ValidAudience = AuthOptions.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                        ValidateIssuerSigningKey = true,
                    };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAdminRights", policy => policy.RequireRole("Admin"));
                    options.AddPolicy("RequireCinemaAdminRights", policy => policy.RequireRole("CinemaAdmin"));
                    //TODO: ???
                    options.AddPolicy("RequireUserRights", policy => policy.RequireRole("User"));
                }
            );
            services.AddScoped<IRepository<AdditionalProductEntity>, Repository<AdditionalProductEntity>>();
            services.AddScoped<IRepository<SessionEntity>, Repository<SessionEntity>>();
            services.AddScoped<IRepository<SittingPlaceInfoEntity>, Repository<SittingPlaceInfoEntity>>();
            services.AddScoped<IRepository<FilmEntity>, Repository<FilmEntity>>();
            services.AddScoped<IRepository<HallEntity>, Repository<HallEntity>>();
            services.AddScoped<IRepository<SittingPlaceEntity>, Repository<SittingPlaceEntity>>();
            services.AddScoped<IRepository<TheaterEntity>, Repository<TheaterEntity>>();
            services.AddScoped<IRepository<TicketEntity>, Repository<TicketEntity>>();
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();

            services
                .AddScoped<IService<AdditionalProductModel, AdditionalProductEntity>,
                    Service<AdditionalProductModel, AdditionalProductEntity>>();
            services.AddScoped<IService<FilmModel, FilmEntity>, Service<FilmModel, FilmEntity>>();
            services.AddScoped<IService<HallModel, HallEntity>, Service<HallModel, HallEntity>>();
            services.AddScoped<IService<SessionModel, SessionEntity>, Service<SessionModel, SessionEntity>>();
            services
                .AddScoped<IService<SittingPlaceInfoModel, SittingPlaceEntity>,
                    Service<SittingPlaceInfoModel, SittingPlaceEntity>>();
            services
                .AddScoped<IService<SittingPlaceModel, SittingPlaceEntity>,
                    Service<SittingPlaceModel, SittingPlaceEntity>>();
            services.AddScoped<IService<TheaterModel, TheaterEntity>, Service<TheaterModel, TheaterEntity>>();
            services.AddScoped<IService<TicketModel, TicketEntity>, Service<TicketModel, TicketEntity>>();
            services
                .AddScoped<IService<AdditionalProductModel, AdditionalProductModel>,
                    Service<AdditionalProductModel, AdditionalProductModel>>();
            services.AddScoped<IService<UserModel, UserEntity>, Service<UserModel, UserEntity>>();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CinemaContext>(optionsAction => optionsAction.UseSqlServer(connectionString));
            /*services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        // TODO: 
                        builder.W
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });*/
            // auto-gen
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            /*using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                using (var context = serviceProvider.GetService<CinemaContext>())
                {
                    context?.Database.Migrate();
                }
            }*/

            if (env.IsDevelopment())
            {
                _logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                _logger.LogInformation("Not in Development environment");
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (contextFeature != null)
                        {
                            _logger.LogError($"Something went wrong: {contextFeature.Error}");
                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server Error"
                            }.ToString());
                        }
                    });
                });
            }

            app.UseCors(
                options => options.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}