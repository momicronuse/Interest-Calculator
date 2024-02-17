internal class Account
{
    // Manual input
    static private double yearlyIncome = 20000;
    // In constructor
    private double currentSavings;
    private double interestRate;
    private bool isTaxed;
    // To calculate
    static private double taxBand;
    static private double untaxedSavings;
    private double interestEarnt;
    private double netEarnings;
    private double maxAmountInSavings;
    private double taxPaidOnInterest;
    private double minimumISAInterestRate;



    
    // Calculates the taxBand
    public static void TaxBandCalculator()
    {
        if (yearlyIncome <= 12750)
        {
            taxBand = 0;
        }
        else if (yearlyIncome > 12750 && yearlyIncome < 37700)
        {
            taxBand = 0.2;
        }
        else if (yearlyIncome >= 37700 && yearlyIncome < 125140)
        {
            taxBand = 0.4;
        }
        else if (yearlyIncome >= 125140)
        {
            taxBand = 0.45;
        }
        else
        {
            Console.WriteLine("Invalid input for yearly income");
        }
    }

    // Calculates untaxedSavings
    public static void UntaxedSavingsCalculator()
    {
        if (yearlyIncome < 12570)
        {
            untaxedSavings = -1;
        }
        else if (yearlyIncome >= 12570 && yearlyIncome < 17570)
        {
            untaxedSavings = (17570 - yearlyIncome) / 12d; 
        } 
        else if (yearlyIncome >= 17570 && taxBand == 0.2)
        {
            untaxedSavings = 1000 / 12d;
        }
        else if (yearlyIncome >= 17570 && taxBand == 0.4)
        {
            untaxedSavings = 500 / 12d;
        }
        else if (yearlyIncome >= 17570 && taxBand == 0.45)
        {
            return;
        }
    }

    // Calculates taxPaidOnInterest
    private void TaxPaidOnSavingsCalculator()
    {
        if (untaxedSavings == -1 || interestEarnt < untaxedSavings)
        {
            taxPaidOnInterest = 0;
        }
        else if (interestEarnt >= untaxedSavings)
        {
            taxPaidOnInterest = (interestEarnt - untaxedSavings) * taxBand;
        }
        netEarnings = interestEarnt - taxPaidOnInterest;
    }// CalculatorMethods





    public Account(double currentSavings, double interestRate, bool isTaxed)
    {
        interestEarnt = currentSavings * (1 + interestRate/1200) - currentSavings;
        if (isTaxed)
        {
            TaxPaidOnSavingsCalculator();
            maxAmountInSavings = untaxedSavings / (interestRate / 100) * 12;
            minimumISAInterestRate = interestRate * (1 - taxBand);

            Console.WriteLine("Here is the information for your account:\n");
            Console.WriteLine("Interest per month from the savings account: £" + Math.Round(interestEarnt, 2));
            Console.WriteLine("Tax paid on the savings per month: £" + Math.Round(taxPaidOnInterest,2));
            Console.WriteLine("Net earnings from this account per month: £" + Math.Round(netEarnings,2));

            Console.WriteLine("The minimum interest rate for the ISA for it to be worth it to swap to is: " + Math.Round(minimumISAInterestRate,2) + "%");
            Console.WriteLine("The maximum amount of money to keep in the savings account is: £" + Math.Round(maxAmountInSavings,2) + "\n The rest should be moved to an ISA.");
            Console.ReadLine();
        }
    }
   


    //   3 - Display information
    //3.1 - 

    //       Display interest earned from savings account, tax paid on those savings, and the net earnings
    //       Display the minimum interest rate for the ISA, and the maximum amount of savings to keep in the savings account if money were to be moved to ISA
}
