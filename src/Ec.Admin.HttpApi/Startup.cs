using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace Ec.Admin.HttpApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services.AddApplication<AdminHttpApiModule>(options =>
            {
                options.UseAutofac();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
