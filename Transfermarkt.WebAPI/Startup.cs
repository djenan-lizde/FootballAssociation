using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Configuration;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Filters;
using Transfermarkt.WebAPI.Middleware;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(
                 Configuration.GetConnectionString("Transfermarkt")));

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var config = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                            if (ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                ctx.Response.Headers.Add("Token-Expired", "true");
                            }
                            ctx.Response.Headers["Content-Type"] = "application/json";
                            ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            ctx.Fail("Expired token");
                            return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Unauthorized" }));
                        }
                    };
                });

            services.AddScoped<IData<City>, Data<City>>();
            services.AddScoped<IData<Club>, Data<Club>>();
            services.AddScoped<IData<League>, Data<League>>();
            services.AddScoped<IData<Stadium>, Data<Stadium>>();
            services.AddScoped<IData<Player>, Data<Player>>();
            services.AddScoped<IData<Contract>, Data<Contract>>();
            services.AddScoped<IData<Season>, Data<Season>>();
            services.AddScoped<IData<ClubLeague>, Data<ClubLeague>>();
            services.AddScoped<IData<Match>, Data<Match>>();
            services.AddScoped<IData<Position>, Data<Position>>();
            services.AddScoped<IData<PlayerPosition>, Data<PlayerPosition>>();
            services.AddScoped<IData<Referee>, Data<Referee>>();
            services.AddScoped<IData<RefereeMatch>, Data<RefereeMatch>>();
            services.AddScoped<IData<MatchDetail>, Data<MatchDetail>>();
            services.AddScoped<IData<User>, Data<User>>();
            services.AddScoped<IData<Role>, Data<Role>>();
            services.AddScoped<IData<UsersRoles>, Data<UsersRoles>>();
            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
