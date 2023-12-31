using LabsChecker.Forms;
using LabsChecker.Logics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LabsChecker
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ServiceCollection services = new();
			ConfigureServices(services);

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			using var serviceProvider = services.BuildServiceProvider();
			Application.Run(serviceProvider.GetRequiredService<LabWorkConfigForm>());
		}

		private static void ConfigureServices(ServiceCollection services)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			var configuration = builder.Build();

			services
				.AddLogging(option =>
				{
					option.SetMinimumLevel(LogLevel.Information);
					//option.AddNLog("nlog.config");
				})
				.AddSingleton<IConfiguration>(configuration)
				.AddSingleton<LabWorkLogic>()
				.AddSingleton<LabWorkConfigForm>();
		}
	}
}