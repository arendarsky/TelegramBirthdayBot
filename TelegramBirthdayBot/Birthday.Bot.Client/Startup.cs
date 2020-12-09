using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Birthday.Bot.Client.Settings;
using Birthday.Bot.Infrastructure;
using Birthday.Bot.Infrastructure.Extensions;
using Birthday.Bot.Services.Extensions;
using Microsoft.AspNetCore.Http;
using Telegram.Bot;
using MediatR;

namespace Birthday.Bot.Client
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton<MemoryContext>();
            services.AddFactories();
            services.AddRepositories();
            services.AddServices();
            AddTelegramBot(services);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ITelegramBotService, TelegramBotService>();
            services.AddMediatR(typeof(Startup));
        }

        private void AddTelegramBot(IServiceCollection services)
        {
            var token = Configuration.GetSection("TelegramBot.Settings")["Token"];
            services.AddSingleton<ITelegramBotClient, TelegramBotClient>(service => new TelegramBotClient(token));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppHttpContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }
    }
}
