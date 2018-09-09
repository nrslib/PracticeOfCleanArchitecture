using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Configs.DI;

namespace WebApplication
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
            services.AddMvc();
            var diLauncher = this.diLauncher();
            diLauncher.Launch(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// どの DILauncher が選ばれるかは appsettings.Development.json の記述を変更することで切り替えることができます
        /// </summary>
        /// <returns></returns>
        private IDILauncher diLauncher() {
            switch (Configuration["DI"])
            {
                case "LocalDILauncher": return new LocalDILauncher(); // データ = インメモリ, 処理 = プロダクト
                case "TestDILauncher": return new TestDILauncher(); // データ = 未使用, 処理 = モック
                case "ProductDILauncher": return new ProductDILauncher(); // データ = MYSQL, 処理 = プロダクト
                default:
                    throw new InvalidOperationException("not found di launcher");
            }
        }
    }
}
