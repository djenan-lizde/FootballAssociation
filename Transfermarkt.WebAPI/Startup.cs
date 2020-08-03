using AutoMapper;
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
using Transfermarkt.Models.Requests;
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<FootballAssociationDbContext>(options =>
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

            //users
            services.AddScoped<IData<Database.Users>, Data<Database.Users>>();
            services.AddScoped<IData<Database.Roles>, Data<Database.Roles>>();
            services.AddScoped<IData<Database.UsersRoles>, Data<Database.UsersRoles>>();
            services.AddScoped<IUserService, UserService>();

            //queries
            services.AddScoped<IData<Database.Cities>, Data<Database.Cities>>();
            services.AddScoped<IData<Database.Clubs>, Data<Database.Clubs>>();
            services.AddScoped<IData<Database.Leagues>, Data<Database.Leagues>>();
            services.AddScoped<IData<Database.Seasons>, Data<Database.Seasons>>();
            services.AddScoped<IData<Database.Referees>, Data<Database.Referees>>();
            services.AddScoped<IData<Database.Positions>, Data<Database.Positions>>();
            services.AddScoped<IData<Database.Stadiums>, Data<Database.Stadiums>>();
            services.AddScoped<IData<Database.Players>, Data<Database.Players>>();
            services.AddScoped<IData<Database.Contracts>, Data<Database.Contracts>>();
            services.AddScoped<IData<Database.ClubsLeague>, Data<Database.ClubsLeague>>();
            services.AddScoped<IData<Database.Matches>, Data<Database.Matches>>();
            services.AddScoped<IData<Database.PlayerPositions>, Data<Database.PlayerPositions>>();
            services.AddScoped<IData<Database.RefereeMatches>, Data<Database.RefereeMatches>>();
            services.AddScoped<IData<Database.MatchDetails>, Data<Database.MatchDetails>>();

            //get
            services.AddScoped<IService<Models.Cities, object>, BaseService<Models.Cities, object, Database.Cities>>();
            services.AddScoped<IService<Models.Positions, object>, BaseService<Models.Positions, object, Database.Positions>>();
            services.AddScoped<IService<Models.Roles, object>, BaseService<Models.Roles, object, Database.Roles>>();

            //CRUD
            services.AddScoped<ICRUDService<Models.Clubs, ClubSearchRequest, Models.Clubs, Models.Clubs>, ClubsService>();
            services.AddScoped<ICRUDService<Models.Players, PlayerSearchRequest, Models.Players, Models.Players>, PlayersService>();
            services.AddScoped<ICRUDService<Models.Leagues, object, Models.Leagues, Models.Leagues>,LeaguesService>();
            services.AddScoped<ICRUDService<Models.Referees, object, Models.Referees, Models.Referees>, RefereesService>();
            services.AddScoped<ICRUDService<Models.Seasons, object, Models.Seasons, Models.Seasons>, SeasonsService>();
            services.AddScoped<ICRUDService<Models.Stadiums, object, Models.Stadiums, Models.Stadiums>, StadiumsService>();
            services.AddScoped<ICRUDService<Models.Contracts, object, Models.Contracts, Models.Contracts>, ContractsService>();
            services.AddScoped<ICRUDService<Models.Matches, object, Models.Matches, Models.Matches>, MatchesService>();
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
