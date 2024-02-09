int numberOfAccounts;

do
{
    Console.Write("Enter number of acounts: ");
    numberOfAccounts = int.Parse(Console.ReadLine());
    if (numberOfAccounts < 1 || numberOfAccounts > 9)
    {
        Console.WriteLine("{0} Is not valid. Enter a number between 1 and 9 inclusive\n", numberOfAccounts);
    }
} while (numberOfAccounts < 1 || numberOfAccounts > 9);


Account[] allAccounts = new Account[numberOfAccounts];
