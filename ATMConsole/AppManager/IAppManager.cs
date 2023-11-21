using ATMLib.Model;

namespace ATMConsole; 
internal interface IAppManager {
	void Run();
	void ShowWelcomeMessage();
	void CreatePassword();
	int ReadPassword();
	void ShowPasswordStatus(Costumer costumer, bool passwordLengthSurpass);
	void ShowOptions();
	int ReadAnswer();
	void RequireMoneyAmount();
	int ReadMoneyAmount();
	void RequirePassword();
	void ViewBalance(Costumer costumer);
	void ShowInvalidPassword();
}
