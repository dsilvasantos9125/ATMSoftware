using ATMConsole;
using ATMLib.Controller;
using ATMLib.Operation;
using Microsoft.Extensions.DependencyInjection;

namespace ATMSoftware;
internal class Program {
	static void Main() {
		using ServiceProvider container = RegistrarClasses();

		var controller = container.GetRequiredService<IAppManager>();

		controller.Run();
	}

	static ServiceProvider RegistrarClasses() {
		var services = new ServiceCollection();

		services.AddSingleton<IPasswordController, PasswordController>();
		services.AddSingleton<IOperations, Operations>();
		services.AddSingleton<IAppManager, AppManager>();

		return services.BuildServiceProvider();
	}
}
