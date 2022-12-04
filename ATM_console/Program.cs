using System;
public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
       return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
       pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setFirstLast(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1.   Deposit");
            Console.WriteLine("2.   Withdraw");
            Console.WriteLine("3.   Show Balance");
            Console.WriteLine("4.   Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your Balance is: " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());

            //check if user has enough
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance :( ");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }


        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("354242642366", 1234, "John", "Doe", 150.59));
        cardHolders.Add(new CardHolder("536326677473", 4321, "Mark", "Henry", 200.00));
        cardHolders.Add(new CardHolder("134352435544", 4432, "Luke", "Harp", 89.50));
        cardHolders.Add(new CardHolder("754424354645", 9485, "Matt", "Karl", 930.60));
        cardHolders.Add(new CardHolder("234562642366", 6544, "Simon", "Peter", 749.99));
        cardHolders.Add(new CardHolder("123", 6544, "James", "zebedee", 249.99));

        //prompt user
        Console.WriteLine("Welcome to Easy_ATM");
        Console.WriteLine("Please insert your depit card: ");

        String debitCardNum = "";
        CardHolder curretUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against data
                curretUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (curretUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card number not recognized. Please try again");
            }
        }
            Console.WriteLine("Please enter your pin");
            int userPin = 0;

            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //check against data
                    if (curretUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
            }

            Console.WriteLine("Welcome " + curretUser.getFirstName() + " :)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    
                }
            if (option == 1) { deposit(curretUser); }
            else if (option == 2) { withdraw(curretUser); }
            else if (option == 3) { balance(curretUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
            while (option != 4);
            {
                Console.WriteLine("Thank you! have a nice day :)");
            }

        
    }
}