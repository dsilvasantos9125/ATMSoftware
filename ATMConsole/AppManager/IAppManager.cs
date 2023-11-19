using ATMLib.Model;

namespace ATMConsole; 
internal interface IAppManager {
	void Run();
	void WelcomeMessage();
	void CreatePassword();
	int ReadPassword();
	void PasswordStatus(Costumer costumer, int passwordLength);
	void ShowOptions();
	int ReadAnswer();
	void RequireMoneyAmount();
	int ReadMoneyAmount();
	void RequirePassword();
	void ViewBalance(Costumer costumer);
}
