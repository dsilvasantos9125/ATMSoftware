using ATMLib.Model;

namespace ATMLib.Controller; 
public class PasswordController : IPasswordController {
	public int ValidatePassword(int userPassword) {

        if (!CheckPasswordLength(userPassword)) return 0;
		
        int password = userPassword;

        for (int i = 0; i < 6; i++) {
			int repetitions = 0;

			int actualNumber = password % 10;

			password = userPassword;

			while (password != 0) {
                int comparableNumber = password % 10;

				if (comparableNumber == actualNumber) 
					repetitions++;

				if (repetitions >= 2) 
					return 0;

				password /= 10;
			}

			password = (int)(userPassword / Math.Pow(10, i + 1));
        }

		return userPassword;
    }

	public bool ComparePasswords(Costumer costumer, int userPassword) =>
		costumer.Password == userPassword;

	private static bool CheckPasswordLength(int userPassword) =>
		userPassword.ToString().Length == 6;
}
