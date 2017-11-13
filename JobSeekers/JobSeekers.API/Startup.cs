using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobSeekers.Data.Models;
using Microsoft.EntityFrameworkCore;
using JobSeekers.Data;
using JobSeekers.API.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using JobSeekers.API.Models;

namespace JobSeekers.API
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
            // Register Application Services
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddTransient<IMapper, Mapper>();

            // todo get exception handler filter added
            services.AddDbContext<JobSeekersContext>(options =>
                       options.UseSqlite("Data Source=JobSeekers.db"));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Job Seekers API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Seekers API V1");
            });
        }
    }
}
