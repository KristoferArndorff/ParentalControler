using Common.Configuration;
using Common.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IO.Compression;

namespace Api.Parent
{
    public class Startup
    {
        protected IConfiguration Configuration { get; }
        protected IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BaseDataContext>(options =>
            {
                options.UseNpgsql(connectionString: "User Id=postgres;Password=12345;Host=localhost;Port=5432;Database=mahdb;Pooling=true;Maximum Pool Size=50;Keepalive=30;", 
                    builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
            }
            );

            // Configure CORS
            services.AddCors();

            // Configure MVC
            services.AddMvc();

            //Add Response compression
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            // Add Response compression services
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.ConfigureDependencies(Configuration);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
           
            app.UseRouting();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            // Use OpenIddict
            app.UseAuthentication();

            //User response compression
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
