namespace dz5_middleware {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.Use(async (context, next) => {
				context.Response.Headers.Add("CUSTOM-HEADER", "CUSTOM VALUE");
				await next();
			});

			app.Map("/", async (context) => {
				string headers = "";
				foreach (var header in context.Response.Headers)
					headers += $"{header}\n";
				await context.Response.WriteAsync(headers);
			});

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}