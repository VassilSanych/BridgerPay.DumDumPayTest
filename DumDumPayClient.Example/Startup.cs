using BridgerPay.DumDumPay;
using BridgerPay.DumDumPay.ApiClient;
using BridgerPay.DumDumPay.ApiClient.Interfaces;
using BridgerPay.DumDumPay.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DumDumPayClient.Example
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		
		/// <summary>
		///  DI container setup
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions<ApiSettings>().Bind(Configuration.GetSection("PaymentApiClientSettings"));
			services.AddTransient<IConnection, Connection>();
			services.AddTransient<IApiClient, Client>();
			services.AddTransient<IProcessing, Processing>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(
				routes =>
				{
					routes.MapRoute(
						name: "default",
						template: "{controller=Payment}/{action=Index}/{id?}");
				});
		}
	}
}
