using ATMConsole;
using ATMLib.Controller;
using ATMLib.Operation;

namespace ATMSoftware;
internal class Program {
	static void Main(string[] args) {
		IPasswordController _passwordController = new PasswordController();
		IOperations _operations = new Operations();
		IAppManager appManager = new AppManager(
			_passwordController,
			_operations
			);

		appManager.Run();
	}
}
