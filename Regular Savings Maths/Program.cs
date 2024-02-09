// Initialises all variables
double savingsBalance = 20000;
double savingsAccountRate = 5.1;
double regularSaverAccountRate;
double amountMovedPerMonth;
double monthsToCalculate = 12;
double totalExtra = 0;

static double CompoundInterest(double initialValue, double timeInMonths, double monthlyChange, double yearlyInterest)
{
    // Assumes monthly change is added / subtracted at the start of the month BEFORE interest is paid
    double finalValue = initialValue;
    yearlyInterest /= 100;
    for (int month = 1; month <= timeInMonths; month++)
    {
        finalValue += monthlyChange;
        finalValue *= (1 + yearlyInterest / 12);
    }
    return Math.Round(finalValue, 2);
}
Console.WriteLine("Enter number of regular savers");
int amountOfAccounts = int.Parse(Console.ReadLine());

for (int i = 0; i < amountOfAccounts; i++)
{

    //Console.Write("Savings account starting balance: ");
    //savingsBalance = double.Parse(Console.ReadLine());
    //Console.Write("\nSavings account yearly interest rate as a percentage: ");
    //savingsAccountRate = double.Parse(Console.ReadLine());
    Console.Write("Regular Saver account yearly interest rate as a percentage: ");
    regularSaverAccountRate = double.Parse(Console.ReadLine());
    Console.Write("\nEnter the amount moved from the savings account to the regular saver per month: ");
    amountMovedPerMonth = double.Parse(Console.ReadLine());
    //Console.Write("\nHow many months into the future to calculate for: ");
    //monthsToCalculate = double.Parse(Console.ReadLine());
    Console.WriteLine("\n\n\n");


    // Interest from only savings account:
    Console.WriteLine("Money in savings account after that many months: £{0}", CompoundInterest(savingsBalance, monthsToCalculate, 0, savingsAccountRate));

    // Interest from regular saver AND savings account:
    //Console.WriteLine("Money in savings account after moving money to regular saver: £{0}", CompoundInterest(savingsBalance, monthsToCalculate, -amountMovedPerMonth, savingsAccountRate));
    Console.WriteLine("Money in regular saver account at the end of that many months: £{0}", CompoundInterest(0, monthsToCalculate, amountMovedPerMonth, regularSaverAccountRate));
    Console.WriteLine("Total money in both accounts: £{0}", CompoundInterest(savingsBalance, monthsToCalculate, -amountMovedPerMonth, savingsAccountRate) + CompoundInterest(0, monthsToCalculate, amountMovedPerMonth, regularSaverAccountRate));
   
    // Difference between the 2:
    //Console.WriteLine("Total WITHOUT regular saver - total amount WITH regular saver: £{0}", -(CompoundInterest(savingsBalance, monthsToCalculate, 0, savingsAccountRate) - (CompoundInterest(savingsBalance, monthsToCalculate, -amountMovedPerMonth, savingsAccountRate) + CompoundInterest(0, monthsToCalculate, amountMovedPerMonth, regularSaverAccountRate))));
    totalExtra += -(CompoundInterest(savingsBalance, monthsToCalculate, 0, savingsAccountRate) - (CompoundInterest(savingsBalance, monthsToCalculate, -amountMovedPerMonth, savingsAccountRate) + CompoundInterest(0, monthsToCalculate, amountMovedPerMonth, regularSaverAccountRate)));
    Console.WriteLine("\n\n--------------------------------------------------------------------------");
}

Console.WriteLine(totalExtra);




