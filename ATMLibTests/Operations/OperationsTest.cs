using ATMLib.Model;
using ATMLib.Operation;

namespace ATMLibTests.Controller;

public class OperationsTest
{
    private Operations context;

    [SetUp]
    public void Setup()
    {
        context = new();
    }

    [Test]
    public void GetBalance_ReturnsBalance() {
        //Arrange
        Costumer costumer = new() {
            Balance = 10000
        };

        //Act
        int result = context.GetBalance(costumer);

        //Assert
        Assert.That(result, Is.EqualTo(costumer.Balance), "Expected balance");
    }

	[Test]
	public void CalculateWithdraw_ReturnsBalance() {
        //Arrange
        int expectedMoneyAmount = 500;
		Costumer costumer = new() {
			Balance = 10000
		};

		//Act
		int result = context.CalculateWithdraw(costumer, expectedMoneyAmount);

		//Assert
		Assert.That(result, Is.EqualTo(costumer.Balance), "Expected balance");
	}

	[Test]
	public void CalculateDeposit_ReturnsBalance() {
		//Arrange
		int expectedMoneyAmount = 500;
		Costumer costumer = new() {
			Balance = 10000
		};

		//Act
		int result = context.CalculateDeposit(costumer, expectedMoneyAmount);

		//Assert
		Assert.That(result, Is.EqualTo(costumer.Balance), "Expected balance");
	}
}