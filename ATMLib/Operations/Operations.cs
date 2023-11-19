using ATMLib.Model;

namespace ATMLib.Operation; 
public class Operations : IOperations {
	public int GetBalance(Costumer costumer) {
		return costumer.Balance;
	}

	public int CalculateWithdraw(Costumer costumer, int moneyAmount) {
		costumer.Balance -= moneyAmount;

		return costumer.Balance;
	}

	public int CalculateDeposit(Costumer costumer, int moneyAmount) {
		costumer.Balance += moneyAmount;

		return costumer.Balance;
	}
}
