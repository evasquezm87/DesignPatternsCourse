using DesignPatternsASP.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;//Para la inyeccion de dependencias
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Earn;

namespace DesignPatternsASP
{
	//Esta clase es la que usa .Net para el manejo de la inyeccion de dependencias
	/*
	 Se pueden inyectar objetos de 3 tipos
	Singleton.- solo un objeto en la aplicaicon
	Transitor.- un objeto para cada servicio, por cada controlador
	Alcance(Scope).- Un objeto por la misma solicitud, a diferencia del anterior hay uno por cada controlador
	 */
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
			services.AddControllersWithViews();
			//Inyección de dependencias, obtener valores del config para ser utilizado en el proyecto
			//Inyeccción de un objeto para poder ser utilizado en cualquier controlador
			services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));
			services.AddTransient((factory) =>
			{
				//En lugar de poner directamente el parametro en el codigo, llamarlo desde el archivo de configuración
				//return new LocalEarnFactory(.20m);
				return new LocalEarnFactory(Configuration.GetSection("MyConfig").GetValue<decimal>("LocalPercentage"));
			}
			);//Para crear inyeccion del tipo Transient aqui se crea el objeto
			
			//Objeto 2 creado para la inyeccion de dependencias
			services.AddTransient((factory) =>
			{
				return new ForeignEarnFactory(Configuration.GetSection("MyConfig")
					.GetValue<decimal>("ForeignPercentage"), Configuration.GetSection("MyConfig")
					.GetValue<decimal>("Extra"));
			}
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
