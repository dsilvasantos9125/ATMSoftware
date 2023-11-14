using ATMLib.Controller;
using ATMLib.Enum;
using ATMLib.Model;
using System.ComponentModel.DataAnnotations;

namespace ATMConsole; 
internal class AppManager : IAppManager {
	private readonly IPasswordController _passwordController;

    public AppManager(IPasswordController passwordController)
    {
        _passwordController = passwordController;
    }

    public void Run() {
		WelcomeMessage();
		
		Costumer costumer = new();

		int passwordLength = 0;

		while (costumer.Password == 0 || passwordLength != 6)
        {
			CreatePassword();

			int userPassword = ReadPassword();

			passwordLength = _passwordController.CheckPasswordLength(userPassword);

			costumer.Password = _passwordController.ValidatePassword(userPassword);

			PasswordStatus(costumer, passwordLength);
		}

		ShowOptions();
		
	}

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
		Console.WriteLine("\n1 - Saldo \n2 - Saque");
    }
}
