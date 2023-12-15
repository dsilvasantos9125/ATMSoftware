using ATMLib.Controller;
using ATMLib.Enum;
using ATMLib.Model;
using ATMLib.Operation;
using SharedLibrary;

namespace ATMConsole;
internal class AppManager : IAppManager {
	private readonly IPasswordController _passwordController;
	private readonly IOperations _operations;
	private readonly ISharedConsole _sharedConsole;

	public AppManager(
		IPasswordController passwordController,
		IOperations operations,
		ISharedConsole sharedConsole
		) {
		_passwordController = passwordController;
		_operations = operations;
		_sharedConsole = sharedConsole;
	}

	public void Run() {
		ShowWelcomeMessage();

		Costumer costumer = new();
		int userAnswer = 0;

		CreatePassword(costumer);

		while (userAnswer != 4) {
			ShowOptions();

			userAnswer = ReadAnswer();
			Options possibleAnswers = (Options)userAnswer;
			int moneyAmount;

			switch (possibleAnswers) {
				case Options.Balance:
					if (WhileReadPassword(costumer))
						ViewBalance(costumer);

					break;
				case Options.Withdraw:
					LoadMoneyAmount(out moneyAmount);

					if (WhileReadPassword(costumer)) {
						_operations.CalculateWithdraw(costumer, moneyAmount);
						ViewBalance(costumer);
					}

					break;
				case Options.Deposit:
					LoadMoneyAmount(out moneyAmount);

					if (WhileReadPassword(costumer)) {
						_operations.CalculateDeposit(costumer, moneyAmount);
						ViewBalance(costumer);
					}

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
	public void ShowWelcomeMessage() {
		_sharedConsole.WriteLine("Banco Sofra - Aplicativo Digital");
	}

	public void WritePassword() =>
		_sharedConsole.WriteLine("Crie a sua senha de 6 dígitos (sem repetições de números):");


	public int ReadPassword() =>
		int.Parse(_sharedConsole.ReadLine() ?? "0");

	public void ShowPasswordStatus(Costumer costumer) =>
		_sharedConsole.WriteLine(costumer.Password == 0 ? "Senha Inválida! Crie novamente." : "Senha válida.");

	public void ShowOptions() => 
		_sharedConsole.WriteLine("\n1 - Verificar Saldo \n2 - Realizar Saque \n3 - Depositar \n4 - Sair");

	public int ReadAnswer() =>
		int.Parse(_sharedConsole.ReadLine() ?? "0");

	public void RequireMoneyAmount() => 
		_sharedConsole.WriteLine("Qual será a quantia de dinheiro?");

	public int ReadMoneyAmount() =>
		int.Parse(_sharedConsole.ReadLine());

	public void RequirePassword() => 
		_sharedConsole.WriteLine("Digite sua senha:");

	public void ViewBalance(Costumer costumer) => 
		_sharedConsole.WriteLine(String.Format($"O seu saldo é de {costumer.Balance:C}"));

	public void ShowExitMessage() => 
		_sharedConsole.WriteLine("Obrigado por utilizar nosso programa!");

	public void ShowInvalidPassword() => 
		_sharedConsole.WriteLine("Senha inválida! Insira-a novamente.");

	public bool WhileReadPassword(Costumer costumer) {
		bool passwordEquality = false;

		while (!passwordEquality) {
			RequirePassword();

			int userPassword = ReadPassword();
			passwordEquality = _passwordController.ComparePasswords(costumer, userPassword);
		}

		return true;
	}

	public void LoadMoneyAmount(out int moneyAmount) {
		RequireMoneyAmount();

		moneyAmount = ReadMoneyAmount();
	}

	public void CreatePassword(Costumer costumer) {
		while (costumer.Password == 0) {
			WritePassword();

			int userPassword = ReadPassword();
			costumer.Password = _passwordController.ValidatePassword(userPassword);

			ShowPasswordStatus(costumer);
		}
	}
	#endregion
}
