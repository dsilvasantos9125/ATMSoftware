using ATMLib.Model;

namespace ATMConsole; 
internal interface IAppManager {
	void Run();
	void ShowWelcomeMessage();
	void WritePassword();
	int ReadPassword();
	void ShowPasswordStatus(Costumer costumer);
	void ShowOptions();
	int ReadAnswer();
	void RequireMoneyAmount();
	int ReadMoneyAmount();
	void RequirePassword();
	void ViewBalance(Costumer costumer);
	void ShowInvalidPassword();
	void LoadMoneyAmount(out int moneyAmount);
	void CreatePassword(Costumer costumer);
}
