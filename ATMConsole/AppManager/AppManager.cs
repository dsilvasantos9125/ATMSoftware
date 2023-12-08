﻿using ATMLib.Controller;
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
		ShowWelcomeMessage();

		Costumer costumer = new();
		int userPassword;

		while (costumer.Password == 0) {
			CreatePassword();

			userPassword = ReadPassword();
			costumer.Password = _passwordController.ValidatePassword(userPassword);

			ShowPasswordStatus(costumer);
		}

		int userAnswer = 0;

		while (userAnswer != 4) {
			ShowOptions();

			userAnswer = ReadAnswer();
			Options possibleAnswers = (Options)userAnswer;
			int moneyAmount;
			bool passwordEquality = false;

			switch (possibleAnswers) {
				case Options.Balance:
					if (WhileReadPassword(costumer))
						ViewBalance(costumer);

					break;
				case Options.Withdraw:
					RequireMoneyAmount();

					moneyAmount = ReadMoneyAmount();

					if (WhileReadPassword(costumer)) {
						_operations.CalculateWithdraw(costumer, moneyAmount);
						ViewBalance(costumer);
					}

					break;
				case Options.Deposit:
					RequireMoneyAmount();

					moneyAmount = ReadMoneyAmount();

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
		Console.WriteLine("Banco Sofra - Aplicativo Digital");
	}

	public void CreatePassword() {
		Console.WriteLine("Crie a sua senha de 6 dígitos (sem repetições de números):");
	}

	public int ReadPassword() {
		int userPassword = int.Parse(Console.ReadLine() ?? "0");

		return userPassword;
	}

	public void ShowPasswordStatus(Costumer costumer) =>
		Console.WriteLine(costumer.Password == 0 ? "Senha Inválida! Crie novamente." : "Senha válida.");

	public void ShowOptions() {
		Console.WriteLine("\n1 - Verificar Saldo \n2 - Realizar Saque \n3 - Depositar \n4 - Sair");
	}

	public int ReadAnswer() {
		int answer = int.Parse(Console.ReadLine() ?? "0");

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
		Console.WriteLine(String.Format($"O seu saldo é de {costumer.Balance:C}"));
	}

	public void ShowExitMessage() {
		Console.WriteLine("Obrigado por utilizar nosso programa!");
	}

	public void ShowInvalidPassword() {
		Console.WriteLine("Senha inválida! Insira-a novamente.");
	}

	public bool WhileReadPassword(Costumer costumer) {
		bool passwordEquality = false;

		while (!passwordEquality) {
			RequirePassword();

			int userPassword = ReadPassword();
			passwordEquality = _passwordController.ComparePasswords(costumer, userPassword);
		}

		return true;
	}
	#endregion
}
