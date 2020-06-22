using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TwitterApi.Caching;
using TwitterApi.Factories;
using TwitterApi.Services;

namespace TwitterApi
{
    public class Startup
    {
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITweetFactory, TweetFactory>();
            services.AddScoped<ISearchTweetsService, SearchTweetsService>();
        }

        private void EnableCache(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<SearchTweetsService>();
            services.AddScoped<ISearchTweetsService, SearchTweetsCaching<SearchTweetsService>>();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddControllers();
            RegisterServices(services);
            EnableCache(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
