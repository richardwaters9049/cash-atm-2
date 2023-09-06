using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }

    //Getters

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

    //Setters

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

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        //Give the user a menu of options

        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            //Bug
            currentUser.setBalance(currentUser.getBalance() +  deposit);
            Console.WriteLine("Thank you, your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to withdraw?");
            double withdrawl = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficent Funs : ( ");

            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You're good to go!! Thank you :) ");
            }
            
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("You balance is:  " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();

        cardHolders.Add(new cardHolder("2963220225617944", 1234, "John", "Smith", 150.91));
        cardHolders.Add(new cardHolder("3123929317529721", 7766, "Sarah", "High", 230.59));
        cardHolders.Add(new cardHolder("913681442302307", 5555, "Bob", "Green", 8298.08));
        cardHolders.Add(new cardHolder("430586883384733", 8899, "Dale", "Appleton", 500.23));
        cardHolders.Add(new cardHolder("918602492883269", 0011, "Mary", "Sway", 66.77));

        //Prompt User

        Console.WriteLine("SimpleATM");
        Console.WriteLine("Please enter your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        //User Validation Loop

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check user data
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Card not recognised, Please try again"); 
                }
            }
            catch { Console.WriteLine("Card not recognised, Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine()); 
                //Check user data
                if (currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Incorrect pin, Please try again");
                }
            }
            catch { Console.WriteLine("Incorrect pin, Please try again"); }
        }

        //Welcome user into the system
        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":) ");
        //Choose your options
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1)
            {
                deposit(currentUser);
            }else if(option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else { option = 0;}

        } while (option != 4);

        Console.WriteLine("Thank you, have a nice day :) "); 

    }

}






