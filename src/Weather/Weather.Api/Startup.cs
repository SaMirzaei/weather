namespace Weather.Api
{
    using System;

    using FluentValidation.AspNetCore;

    using Gelf.Extensions.Logging;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    using Swashbuckle.AspNetCore.SwaggerGen;

    using Weather.Api.Configuration;
    using Weather.Api.Infrastructures;
    using Weather.Api.Services;
    using Weather.Api.Services.Mapper;
    using Weather.Api.V1.Validators;
    using Weather.Data.Entities;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostEnvironment env)
        {
            var environmentName = env.EnvironmentName;

            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<AppOptions>(_configuration.GetSection("app"))
                .AddMvcCore(
                    options =>
                        {
                            options.RespectBrowserAcceptHeader = true;
                            options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                            options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                            options.EnableEndpointRouting = false;
                        })
                .AddFormatterMappings()
                .AddXmlSerializerFormatters()
                // .AddCors()
                //.AddCors(options =>
                //        {
                //            options.AddPolicy(
                //                "CorsPolicy",
                //                builder => builder
                //                    .AllowAnyOrigin()
                //                    .AllowAnyMethod()
                //                    .AllowAnyHeader()
                //                    .WithOrigins("http://*:8080"));
                //        })
                .AddCors(
                    options =>
                        {
                            options.AddDefaultPolicy(
                                builder =>
                                    {
                                        builder.WithOrigins("http://localhost:8080")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                    });
                        })
                .AddFluentValidation(
                    fv =>
                        {
                            fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                        })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddVersionedApiExplorer(
                options =>
                    {
                        options.GroupNameFormat = "'v'VVV";
                        options.SubstituteApiVersionInUrl = true;
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.DefaultApiVersion = new ApiVersion(1, 0);
                    });

            services
                .AddSingleton<Func<DateTime>>(() => DateTime.UtcNow)
                .AddScoped<ModelValidationAttribute>()
                .AddServices()
                .AddBusinessServices()
                .AddMapper()
                .AddValidators()
                .Configure<GelfLoggerOptions>(_configuration.GetSection("Graylog"))
                .AddSwaggerGen(o => ConfigureSwaggerDocGen(services, o))
                .AddLogging(
                    logginBuilder =>
                        {
                            logginBuilder.AddConfiguration(_configuration.GetSection("Logging"))
                                .AddConsole()
                                .AddGelf();
                        })
                .AddApiVersioning(
                    options =>
                        {
                            options.ReportApiVersions = true;
                            options.AssumeDefaultVersionWhenUnspecified = true;
                            options.DefaultApiVersion = new ApiVersion(1, 0);
                            options.ApiVersionReader = new UrlSegmentApiVersionReader();
                        })
                .AddResponseCompression();

            services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("Weather"));

            services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }

                    options.RoutePrefix = string.Empty;
                    options.InjectJavascript("../assets/swaggerinit.js");
                    options.OAuthClientId("swaggerui");
                    options.OAuthAppName("WeatherController API - Swagger");
                });

            app.UseCors()
                .UseResponseCompression()
                .UseMvc();

            AddTestData(app.ApplicationServices.GetService<ApiContext>());
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = $"Appsfactory WeatherController API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "Appsfactory Company",
                TermsOfService = new Uri("http://mobinsb.org/licenses/online"),
                Contact = new OpenApiContact
                {
                    Name = "Pouyaandishan.com",
                    Email = "Pouyaandishan@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Pouyaandishan",
                    Url = new Uri("http://mobinsb.org/licenses/online")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " - deprecated.";
            }

            return info;
        }

        private void ConfigureSwaggerDocGen(IServiceCollection services, SwaggerGenOptions options)
        {
            var provider = services
                .BuildServiceProvider()
                .GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }

            ////options.AddSecurityDefinition(
            ////    "oauth2",
            ////    new OAuth2Scheme
            ////        {
            ////            Type = "oauth2",
            ////            Flow = "implicit",
            ////            AuthorizationUrl = $"{IdentityServer}/connect/authorize",
            ////            TokenUrl = $"{IdentityServer}/connect/token",
            ////            Scopes = new Dictionary<string, string>
            ////                         {
            ////                             { "webapi", "Web API - full access" }
            ////                         }
            ////        });

            ////options.OperationFilter<AuthorizeCheckOperationFilter>();
            ////options.OperationFilter<SwaggerDefaultValues>();

            //////var xmlFile = $"{typeof(Startup).Assembly.GetName().Name}.xml";
            //////var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //////options.IncludeXmlComments(xmlPath);
        }

        private static void AddTestData(ApiContext context)
        {
            var testUser1 = new Information
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Json = "test"
            };

            context.Informations.Add(testUser1);

            context.SaveChanges();
        }
    }
}
