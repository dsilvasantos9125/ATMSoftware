using ATMLib.Model;

namespace ATMLib.Controller; 
public interface IPasswordController {
	int ValidatePassword(int userPassword);
	int CheckPasswordLength(int userPassword);
}
