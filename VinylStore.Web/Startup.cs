using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VinylStore.BL;
using VinylStore.BL.UseCases.ManagerRole;
using VinylStore.CrossCutting.Interfaces;
using VinylStore.DAL.Context;
using VinylStore.Web.Areas.Identity;

namespace VinylStore.Web
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<VinylStoreDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
			//services.AddScoped<IVinylStoreUnitOfWork, VinylStoreUnitOfWork>();
			//services.AddScoped<IManagerRole, ManagerRole>();
			//services.AddScoped<IArtistRepository, ArtistRepository>();
			//services.AddScoped<IAlbumRepository, AlbumRepository>();
			//services.AddScoped<ITrackRepository, TrackRepository>();

			//services.AddScoped<ICartItemRepository, CartItemRepository>();

			//services.AddScoped<IOrderRepository, OrderRepository>();
			//services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

			services.AddIdentity<DAL.Entities.User, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = true;
				options.User.RequireUniqueEmail = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
			})
				.AddEntityFrameworkStores<VinylStoreDbContext>()
				.AddDefaultUI()
				.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddMicrosoftAccount(o =>
				{
					o.ClientId = Configuration["MicrosoftConnect:key"];
					o.ClientSecret = Configuration["MicrosoftConnect:secret"];
				})
				//.AddFacebook(o =>
				//{
				//	o.ClientId = Configuration["FacebookConnect:key"];
				//	o.ClientSecret = Configuration["FacebookConnect:secret"];
				//})
				.AddGoogle(o =>
				{
					o.ClientId = Configuration["GoogleConnect:key"];
					o.ClientSecret = Configuration["GoogleConnect:secret"];
				});

			services.AddTransient<IEmailSender, EmailSender>();

			services.AddHttpContextAccessor();
			services.AddSession();

			services.AddControllersWithViews()
				.AddNewtonsoftJson();

			services.AddRazorPages();
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
			app.UseSession();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Supply}/{action=Index}/{id?}");

				endpoints.MapRazorPages();
			});
		}
	}
}
