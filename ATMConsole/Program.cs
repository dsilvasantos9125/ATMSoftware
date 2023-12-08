using ATMConsole;
using ATMLib.Controller;
using ATMLib.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace ATMSoftware;
internal class Program {
	static void Main() {
		using ServiceProvider container = RegisterClasses();

		IAppManager controller = container.GetRequiredService<IAppManager>();

		controller.Run();
	}

	static ServiceProvider RegisterClasses() {
		ServiceCollection services = new();

		services.AddTransient<IPasswordController, PasswordController>();
		services.AddTransient<IOperations, Operations>();
		services.AddTransient<IAppManager, AppManager >();

		return services.BuildServiceProvider();
	}
}
