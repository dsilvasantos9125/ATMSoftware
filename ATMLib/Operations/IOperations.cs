using ATMLib.Model;

namespace ATMLib.Operation; 
public interface IOperations {
	int GetBalance(Costumer costumer);
	int CalculateWithdraw(Costumer costumer, int moneyAmount);
	int CalculateDeposit(Costumer costumer, int moneyAmount);
}
