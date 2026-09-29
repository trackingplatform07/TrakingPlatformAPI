using Interface.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Service.Context;
using Service.Service;
using Service.Services;
using System.Text;

public class Program
{
    private static async Task Main(string[] args)
    {
        // ---------------- SERILOG ----------------
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(
                Path.Combine(AppContext.BaseDirectory, "log", "log-.txt"),
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("OfferService - Starting Application...");

        var builder = WebApplication.CreateBuilder(args);

        // ---------------- CONFIGURATION ----------------
        var configuration = builder.Configuration;

        string secretKey = configuration["SecretKey:JwtSecretKey"];

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey)
        );

        builder.Configuration.AddEnvironmentVariables();

        Log.Information("OfferService - Configuring Services...");

        // ---------------- SERVICES ----------------
        builder.Services.AddHttpClient();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();

        // ---------------- DATABASE ----------------
        builder.Services.AddDbContext<OfferCategoryDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));

        // ---------------- DEPENDENCY INJECTION ----------------
        builder.Services.AddScoped<IOfferCategory, OfferCategoryServices>();
        builder.Services.AddScoped<IOffer, OfferServices>();
        builder.Services.AddScoped<ILandingPage, LandingPageService>();
        builder.Services.AddScoped<ITargetingRule, TargetingRuleService>();
        builder.Services.AddScoped<ICreative, CreativeService>();
        builder.Services.AddScoped<ICappingRule, CappingRuleService>();
        builder.Services.AddScoped<IEventSetting, EventSettingService>();
        builder.Services.AddScoped<IPayoutRule, PayoutRuleService>();
        builder.Services.AddScoped<IEventGoal, EventGoalService>();
        builder.Services.AddScoped<IFallbackIntegration, FallbackIntegrationService>();
        builder.Services.AddScoped<IAntiFraudSetting, AntiFraudSettingService>();
        builder.Services.AddScoped<IAutomationRule, AutomationRuleService>();
        builder.Services.AddScoped<ISuppressionList, SuppressionListService>();
        builder.Services.AddScoped<IRetargetingTag, RetargetingTagService>();
        builder.Services.AddScoped<ICoupon, CouponService>();
        builder.Services.AddScoped<IOfferLinkingRule, OfferLinkingRuleService>();
        builder.Services.AddScoped<ITopOffer, TopOfferService>();
        builder.Services.AddScoped<ITopOfferMailerLog, TopOfferMailerLogService>();
        builder.Services.AddScoped<IProductFeed, ProductFeedService>();
        builder.Services.AddScoped<IMailerTemplate, MailerTemplateService>();
        builder.Services.AddScoped<ISmtpSetting, SmtpSettingService>();
        builder.Services.AddScoped<IMailerLog, MailerLogService>();
        builder.Services.AddScoped<IDefaultMailerTemplate, DefaultMailerTemplateService>();
        builder.Services.AddScoped<IAutomationLog, AutomationLogService>();
        builder.Services.AddScoped<ILinkTesterRule, LinkTesterRuleService>();
        builder.Services.AddScoped<ILinkTestResult, LinkTestResultService>();
        builder.Services.AddScoped<IShortUrl, ShortUrlService>();
        builder.Services.AddScoped<INetworkSetting, NetworkSettingService>();
        builder.Services.AddScoped<IBillingSubscription, BillingSubscriptionService>();
        builder.Services.AddScoped<IBillingPlanHistoryLog, BillingPlanHistoryLogService>();
        // ---------------- SWAGGER ----------------
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Offer API",
                Version = "v1",
                Description = "API for managing Offer-related features."
            });

            c.ResolveConflictingActions(
                apiDescriptions => apiDescriptions.First()
            );

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer schema",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });


        // ---------------- CORS ----------------
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });


        // ---------------- AUTHENTICATION ----------------
        Log.Information("OfferService - Configuring Authentication...");

        builder.Services.AddAuthentication(
            JwtBearerDefaults.AuthenticationScheme
        )
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateIssuer = false,
                ValidateAudience = false,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = 401;

                    return Task.CompletedTask;
                },

                OnForbidden = context =>
                {
                    context.Response.StatusCode = 403;

                    return Task.CompletedTask;
                },

                OnAuthenticationFailed = context =>
                {
                    Log.Error(
                        $"Authentication Failed: {context.Exception.Message}"
                    );

                    return Task.CompletedTask;
                },

                OnTokenValidated = context =>
                {
                    Log.Information("Token validated successfully");

                    return Task.CompletedTask;
                }
            };
        });


        // ---------------- BUILD APP ----------------
        var app = builder.Build();

        Log.Information(
            "OfferService - Application building completed..."
        );


        // ---------------- SWAGGER ----------------
        Log.Information(
            "OfferService - Setting up Swagger UI..."
        );

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "offer/swagger";

            options.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "Offer API V1"
            );
        });


        // ---------------- MIDDLEWARE ----------------
        Log.Information(
            "OfferService - Configuring Middleware..."
        );

        app.UseCors("AllowAll");

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();


        // ---------------- CONTROLLERS ----------------
        app.MapControllers();


        // ---------------- HEALTH CHECK ----------------
        app.MapGet("/offer", async context =>
        {
            await context.Response.WriteAsync(
                "Listening offer Service...."
            );
        });


        Log.Information(
            "OfferService - Application is ready to handle requests."
        );

        app.Run();
    }
}