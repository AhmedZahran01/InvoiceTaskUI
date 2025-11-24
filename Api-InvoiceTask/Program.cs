
using ApplicationInvoiceTask.Interfaces;
using InfrastructureInvoiceTask.Auth;
using InfrastructureInvoiceTask.Context;
using InfrastructureInvoiceTask.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api_InvoiceTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             
            #region MyRegion

            //#region MyRegion
            //// Add services to the container.
            //builder.Services.AddControllers();

            //// DbContext
            //builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            //     opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //// DI Services
            //builder.Services.AddScoped<IInvoiceService, InvoiceService>();


            //// JWT Settings
            //var jwt = Configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? new JwtSettings();
            //var key = Encoding.UTF8.GetBytes(jwt.Secret);


            //// Authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = jwt.Issuer,
            //        ValidAudience = jwt.Audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(key)
            //    };
            //});

            //builder.Services.AddAuthorization();



            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    //app.UseSwagger();
            //    //app.UseSwaggerUI();
            //    app.UseDeveloperExceptionPage();

            //}

            //app.UseRouting();


            //app.UseHttpsRedirection();

            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //app.MapControllers();

            //app.Run();
            //#endregion 
            #endregion


            // Add Controllers (NOT minimal)
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Application services
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();

            // JWT Settings
            var jwt = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? new JwtSettings();
            var key = Encoding.UTF8.GetBytes(jwt.Secret);

            // Authentication
            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.SaveToken = true;

                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            builder.Services.AddAuthorization();

            // Swagger (optional but nice for task)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            

            app.UseCors();

            // Pipeline
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
