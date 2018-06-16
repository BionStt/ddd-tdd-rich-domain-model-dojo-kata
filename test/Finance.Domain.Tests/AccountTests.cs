namespace Finance.DomainTests
{
    using Xunit;
    using Finance.Domain.ValueObjects;
    using Finance.Domain.Accounts;
    using System;

    public class AccountTests
    {
        [Fact]
        public void New_Account_Should_Have_100_Credit_After_Deposit()
        {
            //
            // Arrange
            Amount amount = new Amount(100.0);
            Account sut = new Account(Guid.NewGuid());

            //
            // Act
            sut.Deposit(amount);

            //
            // Assert
            Credit credit = (Credit)sut.Transactions[0];

            Assert.Equal(100, credit.Amount);
            Assert.Equal("Credit", credit.Description);
        }

        [Fact]
        public void New_Account_With_1000_Balance_Should_Have_900_Credit_After_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(1000.0);

            //
            // Act
            sut.Withdraw(100);

            //
            // Assert
            Assert.Equal(900, sut.GetCurrentBalance());
        }

        [Fact]
        public void New_Account_Should_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());

            //
            // Act
            sut.Close();

            //
            // Assert
            Assert.True(true);
        }

        [Fact]
        public void Account_With_Funds_Should_Not_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(100);

            //
            // Act and Assert
            Assert.Throws<AccountCannotBeClosedException>(
                () => sut.Close());
        }


        [Fact]
        public void Account_With_200_Balance_Should_Not_Allow_50000_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(200);

            //
            // Act and Assert
            Assert.Throws<InsuficientFundsException>(
                () => sut.Withdraw(5000));
        }
    }
}
