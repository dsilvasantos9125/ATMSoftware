using ATMLib.Controller;
using ATMLib.Enum;
using ATMLib.Model;
using ATMLib.Operation;

namespace ATMConsole; 
internal class AppManager : IAppManager {
	private readonly IPasswordController _passwordController;
	private readonly IOperations _operations;

    public AppManager(
		IPasswordController passwordController, 
		IOperations operations
		) {
        _passwordController = passwordController;
		_operations = operations;
    }

    public void Run() {
		WelcomeMessage();
		
		Costumer costumer = new();

		int passwordLength = 0;

		int userPassword = 0;

		while (costumer.Password == 0 || passwordLength != 6) {
			CreatePassword();

			userPassword = ReadPassword();

			passwordLength = _passwordController.CheckPasswordLength(userPassword);

			costumer.Password = _passwordController.ValidatePassword(userPassword);

			PasswordStatus(costumer, passwordLength);
		}

		int userAnswer = 0;

		while(userAnswer != 4) {
			ShowOptions();

			userAnswer = ReadAnswer();

			Options possibleAnswers = (Options)userAnswer;

			int moneyAmount;

			bool passwordEquality = userPassword == costumer.Password;

			switch (possibleAnswers) {
				case Options.Balance:
					RequirePassword();

					userPassword = ReadPassword();

					if (passwordEquality)
						ViewBalance(costumer);
					break;
				case Options.Withdraw:
					RequireMoneyAmount();

					moneyAmount = ReadMoneyAmount();

					RequirePassword();

					userPassword = ReadPassword();

					if (passwordEquality)
						costumer.Balance = _operations.CalculateWithdraw(costumer, moneyAmount);

					ViewBalance(costumer);
					break;
				case Options.Deposit:
					RequireMoneyAmount();

					moneyAmount = ReadMoneyAmount();

					RequirePassword();

					userPassword = ReadPassword();

					if (passwordEquality)
						costumer.Balance = _operations.CalculateDeposit(costumer, moneyAmount);

					ViewBalance(costumer);
					break;
				case Options.Exit:
					ShowExitMessage();

					break;
				default:
					Console.WriteLine("Opção inválida!");

					break;
			}
		}
	}

	#region
	public void WelcomeMessage() {
		Console.WriteLine("Banco Sofra - Aplicativo Digital");
	}

	public void CreatePassword() {
		Console.WriteLine("Crie a sua senha de 6 dígitos (sem repetições de números):");
	}

	public int ReadPassword() {
		int userPassword = int.Parse(Console.ReadLine());

		return userPassword;
	}

	public void PasswordStatus(Costumer costumer, int passwordLength) {
		string? passwordMessage = costumer.Password == 0 || passwordLength != 6 ? "Senha Inválida! Crie novamente." : "Senha válida.";

		Console.WriteLine(passwordMessage);
	}

	public void ShowOptions() {
		Console.WriteLine("\n1 - Verificar Saldo \n2 - Realizar Saque \n3 - Depositar \n4 - Sair");
	}

	public int ReadAnswer() {
		int answer = int.Parse(Console.ReadLine());

		return answer;
	}

	public void RequireMoneyAmount() {
		Console.WriteLine("Qual será a quantia de dinheiro?");
	}

	public int ReadMoneyAmount() {
		int moneyAmount = int.Parse(Console.ReadLine());

		return moneyAmount;
	}

	public void RequirePassword() {
		Console.WriteLine("Digite sua senha:");
	}

	public void ViewBalance(Costumer costumer) {
		Console.WriteLine(String.Format("O seu saldo é de {0:C}", costumer.Balance));
	}

	public void ShowExitMessage() {
		Console.WriteLine("Obrigado por utilizar nosso programa!");
	}
	#endregion
}
