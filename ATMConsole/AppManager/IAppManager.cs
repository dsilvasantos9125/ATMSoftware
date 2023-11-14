using ATMLib.Model;

namespace ATMConsole; 
internal interface IAppManager {
	void Run();
	void WelcomeMessage();
	void CreatePassword();
	int ReadPassword();
	void PasswordStatus(Costumer costumer, int passwordLength);
	void ShowOptions();
}
