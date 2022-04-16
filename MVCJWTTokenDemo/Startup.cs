using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MVCJWTTokenDemo.Services;



using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using MVCJWTTokenDemo.DAL;
using Microsoft.EntityFrameworkCore;
using MVCJWTTokenDemo.Repository;

namespace MVCJWTTokenDemo
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
            #region CORS
            ///Type of CORS policy
            /// 1.CORS with named policy and middleware
            /// 2. CORS with default policy and middleware
            /// 3. CORS with default policy and middleware
            /// 4. Enable CORS with attributes 
            #endregion

            //CORS with default policy and middleware
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200",
            //                                "https://localhost:4200");
            //        });
            //});

            services.AddCors(o => o.AddPolicy("AllowMyOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            //services.AddControllers().AddNewtonsoftJson(Options=> { 
            //Options.SerializerSettings.Controller
            //});

            //Database add with code first 
            services.AddScoped<PatientDbContext>();

            // Step 2 :- Attache the middle ware            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true, 
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1", Description="An API for Products",TermsOfService= new Uri("https://example.com/terms") });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Weather API", Version = "V2", Description = "An PI for Weather" });
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                //options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().AddSessionStateTempDataProvider();
            //Add session in services
            services.AddSession((options) => { options.IdleTimeout = TimeSpan.FromMinutes(30); });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddControllers();
            services.AddSingleton<IProductsService, ProductsService>();
            // Add Identity DbContext
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            //CORS
            //app.UseCors();
            app.UseCors("AllowMyOrigin");
            app.UseAuthorization();

            //UseDefaultFiles must be called before UseStaticFiles to serve the default file.UseDefaultFiles is a URL rewriter that doesn't serve the file.
            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("index.html");
            //app.UseDefaultFiles(options);
            app.UseStaticFiles();
            
            //add session in Middleware
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();


            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
            });


            // other code remove for clarity 
            loggerFactory.AddFile("Logs/myapplog-{Date}.txt");


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
