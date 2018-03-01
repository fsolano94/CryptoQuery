using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            if (!_hostingEnvironment.IsDevelopment())
            {
                services.AddMvc(
                    config =>
                    {
                        config.Filters.Add(typeof(GlobalExceptionFilter));
                    }
                );
            }

            services.AddMvc();

            //services.AddMvc(options => {
            //    options.SslPort = _httpsPort;
            //    options.Filters.Add(typeof(RequireHttpsAttribute));
            //});


            //services.AddApiVersioning(options =>
            //{
            //    options.ApiVersionReader = new MediaTypeApiVersionReader();
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.ReportApiVersions = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            //});

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //});

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
            });


            services.AddTransient<IArticleRepository, SqlServerArticleRepository>();
            services.AddScoped<ArticleService, ArticleService>();

            services.AddTransient<IUserRepository, SqlServerUserRepository>();
            services.AddScoped<UserService, UserService>();

            services.AddAutoMapper();
            //services.AddScoped<CryptoDbContext>(_ => new CryptoDbContext(@"Server=(localdb)\DESKTOP-0EIN6C4;Database=CryptoQuery;Trusted_Connection=True;"));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                // force to add another /swagger to fix issue
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            // Creates Swagger JSON
            //app.UseSwagger(c =>
            //{
            //    //c.RouteTemplate = "api/docs/{documentName}/swagger.json";
            //    c.RouteTemplate = "swagger/swagger.json";
            //});

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/api/swagger/swagger/swagger.json", "AnnexUI API V1");
            //    c.RoutePrefix = "";
            //});

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            //app.UseHsts(options =>
            //{
            //    options.MaxAge(180);
            //    options.IncludeSubdomains();
            //    options.Preload();
            //});


            app.UseMvc();
            

        }
    }
}
