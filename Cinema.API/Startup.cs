using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cinema.API.Models;
using Cinema.DAL.Auth;
using Cinema.DAL.EF;
using Cinema.DAL.Entities.Sessions;
using Cinema.Services.DTO;
using Cinema.Services.DTO.Sessions;
using Cinema.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Cinema.API
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddScoped<IRepository<AdditionalProductModel>, Repository<AdditionalProductModel>>();
            services.AddScoped<IRepository<SessionModel>, Repository<SessionModel>>();
            services.AddScoped<IRepository<SittingPlaceInfoModel>, Repository<SittingPlaceInfoModel>>();
            services.AddScoped<IRepository<FilmModel>, Repository<FilmModel>>();
            services.AddScoped<IRepository<HallModel>, Repository<HallModel>>();
            services.AddScoped<IRepository<SittingPlaceModel>, Repository<SittingPlaceModel>>();
            services.AddScoped<IRepository<TheaterModel>, Repository<TheaterModel>>();
            services.AddScoped<IRepository<TicketModel>, Repository<TicketModel>>();

            services.AddScoped<IService<AdditionalProductModel>, AdditionalProductService>();
            services.AddScoped<IService<FilmModel>, FilmService>();
            services.AddScoped<IService<HallModel>, HallService>();
            services.AddScoped<IService<SessionModel>, SessionService>();
            services.AddScoped<IService<SittingPlaceInfoModel>, SittingPlaceInfoService>();
            services.AddScoped<IService<SittingPlaceModel>, SittingPlaceService>();
            services.AddScoped<IService<TheaterModel>, TheaterService>();
            services.AddScoped<IService<TicketModel>, TicketService>();
            services.AddScoped<IService<AdditionalProductModel>, AdditionalProductService>();


            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CinemaContext>(optionsAction => optionsAction.UseSqlServer(connectionString));
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

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}