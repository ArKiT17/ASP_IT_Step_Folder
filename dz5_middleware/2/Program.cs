namespace _2 {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.Map("/", async (context) => {
				string message = "";
				foreach (var header in context.Request.Headers)
					message += $"{header}\n";
				await context.Response.WriteAsync(message);
			});

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}