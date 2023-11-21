﻿using ATMLib.Model;

namespace ATMLib.Controller; 
public interface IPasswordController {
	int ValidatePassword(int userPassword);
	bool CheckPasswordLength(int userPassword);
	bool ComparePasswords(Costumer costumer, int userPassword);
}
