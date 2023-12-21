using ATMLib.Controller;
using ATMLib.Model;

namespace ATMLibTests.Controller;

public class PasswordControllerTest {

	private PasswordController context;

	[SetUp]
	public void Setup() {
		context = new();
	}

	[Test]
	public void ValidatePassword_ReturnsPassword_WhenIsCorrect() {
		//Arrange
		int expectedValue = 123456;

		//Act
		int result = context.ValidatePassword(expectedValue);

		//Assert
		Assert.That(result, Is.EqualTo(expectedValue), "Expected password");
	}

	[Test]
	public void ValidatePassword_ReturnsZero_WhenIsIncorrect() {
		//Arrange
		int expectedValue = 123455;

		//Act
		int result = context.ValidatePassword(expectedValue);

		//Assert
		Assert.That(result, Is.EqualTo(0), "Expected zero");
	}

	[Test]
	public void ValidatePassword_ReturnsZero_WhenLengthIsWrong() {
		//Arrange
		int expectedValue = 1234567;

		//Act
		int result = context.ValidatePassword(expectedValue);

		//Assert
		Assert.That(result, Is.EqualTo(0), "Expected zero");
	}

	[Test]
	public void ComparePasswords_ReturnsTrue_WhenPasswordsAreEqual() {
		//Arrange
		int expectedValue = 123456;
		Costumer costumer = new() {
			Password = 123456
		};

		//Act
		bool result = context.ComparePasswords(costumer, expectedValue);

		//Assert
		Assert.That(result, Is.EqualTo(true), "Expected true");
	}

	[Test]
	public void ComparePasswords_ReturnsFalse_WhenPasswordsAreDifferent() {
		//Arrange
		int expectedValue = 702892;
		Costumer costumer = new() {
			Password = 123456
		};

		//Act
		bool result = context.ComparePasswords(costumer, expectedValue);

		//Assert
		Assert.That(result, Is.EqualTo(false), "Expected false");
	}
}