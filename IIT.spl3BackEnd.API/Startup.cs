using IIT.spl3Backend.DB.Models;
using IIT.spl3Backend.Repositories.CommentRepositories;
using IIT.spl3Backend.Repositories.ICommentRepositories;
using IIT.spl3Backend.Services.Mappers;
using IIT.spl3Backend.Services.Services;
using IIT.spl3Backend.Services.Services.IServices;

//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using IIT.spl3BackEnd.Helper;

namespace Cefalo.BlogSiteBackEnd.API
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
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
        );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cefalo.BlogSiteBackEnd.API", Version = "v1" });
            });


            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:3000", "http://mywebsite.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });


            //Dependency Injection

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentServices, CommentService>();
            services.AddScoped<IPythonService, PythonService>();
            /*services.AddScoped<IUserservice, UserServices>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IRegexUtilities, RegexUtilities>();
            services.AddScoped<ITokenService, TokenService>();*/


            services.AddAutoMapper(typeof(Mappings));
            services.AddMvc(options => options.EnableEndpointRouting = false);


            // Conent Negotiation

            services.AddControllers()
                .AddXmlSerializerFormatters();

            services.AddControllers().AddJsonOptions(options =>
            {
                //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.ignore;
            });
            services.AddControllers(options => { options.RespectBrowserAcceptHeader = true; });
            services.AddControllers().AddXmlDataContractSerializerFormatters();

            /*services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);*/



            //Authentication

            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cefalo.BlogSiteBackEnd.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //cors
            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseCors("CorsApi");


            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            


            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseRouting();
            /*app.UseEndpoints(endpoints => { endpoints.MapControllers(); });*/
        }
    }
}

/* UserName: Abul
 * "token": "eyJhbGciOiJub25lIiwidHlwIjoiSldUIn0.eyJuYW1laWQiOiJiYXNoaXIiLCJuYmYiOjE2NDk3NDI4MzMsImV4cCI6MTY1MDM0NzYzMywiaWF0IjoxNjQ5NzQyODMzfQ."*/