using ATMConsole;
using ATMLib.Controller;

namespace ATMSoftware;
internal class Program {
	static void Main(string[] args) {
		IPasswordController _passwordController = new PasswordController();
		IAppManager appManager = new AppManager(
			_passwordController
			);

		appManager.Run();
	}
}
