using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using CryptoQuery.SqlServer;
using CryptoQuery.Domain.Articles;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using CryptoQuery.Api.Exceptions;
using CryptoQuery.Domain.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Configuration;
using System.Xml.Linq;

namespace CryptoQuery
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly int? _httpsPort;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;

            _hostingEnvironment = hostingEnvironment;
            if (_hostingEnvironment.IsDevelopment())
            {
                var launchJsonConfig = new ConfigurationBuilder()
                    .SetBasePath(_hostingEnvironment.ContentRootPath)
                    .AddJsonFile("Properties\\launchSettings.json")
                    .Build();
                _httpsPort = launchJsonConfig.GetValue<int>("iisSettings:iisExpress:sslPort");
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = GetConnectionStringFromAppConfigFile("LocalHost");

            services.AddDbContext<CryptoDbContext>(options =>
                options.UseSqlServer(connectionString));

            if (!_hostingEnvironment.IsDevelopment())
            {
                services.AddMvc(
                    config =>
                    {
                        config.Filters.Add(typeof(GlobalExceptionFilter));
                    }
                );
            }


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = KeyStore.Issuer,
                        ValidAudience = KeyStore.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyStore.Key))
                    };
                });

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(RequireHttpsAttribute));
                opt.SslPort = _httpsPort;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CryptoQuery API",
                    Description = "API for Senior Project",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Francisco Solano", Email = "fsolano@nevada.unr.edu", Url = "https://github.com/fsolano94" },
                    License = new License { Name = "None", Url = "" }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "CryptoQuery.Api.xml");
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

            });

            services.AddTransient<IArticleRepository, SqlServerArticleRepository>();
            services.AddScoped<ArticleService, ArticleService>();

            services.AddTransient<IUserRepository, SqlServerUserRepository>();
            services.AddScoped<UserService, UserService>();

            services.AddAutoMapper();


            services.AddApiVersioning(opt =>
            {
                opt.ApiVersionReader = new MediaTypeApiVersionReader();
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
            });
        }

        private string GetConnectionStringFromAppConfigFile(string connectionStringName)
        {

            XDocument xmlDocument = XDocument.Load("app.config");

            var addXmlElement = xmlDocument.Descendants().Where(element => element.Name == "add" && element.Attribute("name").Value == connectionStringName).FirstOrDefault();

            if (addXmlElement == null)
            {
                return string.Empty;
            }

            return addXmlElement.Attribute("connectionString").Value;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                // make sure it's /swagger/v1/swagger.json in release and /swagger/swagger/v1/swagger.json
                c.SwaggerEndpoint("/swagger/swagger/v1/swagger.json", "My API v1"); // will be relative to route prefix, which is itself relative to the application basepath
            });

            app.UseAuthentication();

            app.UseHsts(opt =>
            {
                opt.MaxAge(days: 180);
                opt.IncludeSubdomains();
                opt.Preload();
            });

            app.UseMvc();

        }
    }
}
