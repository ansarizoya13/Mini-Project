using System;
class AccountData
{
	private const int AccountNum1 = 1234;
	private const int AccountNum2 = 5678;
	private const int Pin1 = 1304;
	private const int Pin2 = 2004;
	
	public void detail()
	{
		int account;
		int pin;
		bool isAuthenticated =false;
		
		while (!isAuthenticated)
		{
		System.Console.WriteLine("Enter Your Account Number");
		account = System.Convert.ToInt32(Console.ReadLine());
		if(account == AccountNum1 || account == AccountNum2)
		{
			System.Console.WriteLine("Enter Your Pin");
			pin = System.Convert.ToInt32(Console.ReadLine());
			if(pin == Pin1 || pin == Pin2)
			{
				System.Console.WriteLine("Login Successfully");
				isAuthenticated = true;
			}
			else
			{
				System.Console.WriteLine("Invalid Login");
			}
		}
		else
		{
			System.Console.WriteLine("Incorrect Credential");
		}
		}
	}
}

class Option
{
	private int choice;
	private int balance;
	private int Deposit;
	private int withdraw;
	
	public void details()
	{
		balance = 1000;
		while(true)
		{
			System.Console.WriteLine("Enter Your Choice");
			System.Console.WriteLine("1. DEPOSIT");
			System.Console.WriteLine("2. WITHDRAW");
			System.Console.WriteLine("3. BALANCE");
			System.Console.WriteLine("4. EXIT");
			choice = System.Convert.ToInt32(Console.ReadLine());

			switch(choice)
			{
			 	case 1 : System.Console.WriteLine("Enter the Amount to Deposit");
			 		 Deposit = System.Convert.ToInt32(Console.ReadLine());
			 		 balance = balance + Deposit;
			 		 System.Console.WriteLine("Deposit Successfully, Current Balance is : "+balance);
			 		 break; 
				
				case 2 : System.Console.WriteLine("Enter the Amount to Withdraw");
					 withdraw = System.Convert.ToInt32(Console.ReadLine());
					if(withdraw<=balance)
					{
					 	balance = balance - withdraw;
					 	System.Console.WriteLine("Amount Withdraw Successfully, Current Balance is : "+balance);
					 }
					 else
					 {
						System.Console.WriteLine("Insufficient Balance, Current Balance is :"+balance);
					 }
			 		 break; 

				case 3 : Console.WriteLine("Current Balance: " + balance);
                  			 break;
				
				case 4 : System.Console.WriteLine("Thank you for using the ATM. Goodbye!");
                                         return;
			
				default : System.Console.WriteLine("Invalid Option. Check And Try Again");
					  break;
			}
 
		}

	}
}

class Deploy
{

	public static void Main(string[] args)
	{
		AccountData obj = new AccountData();
		obj.detail();
		
		Option obj1 = new Option();
		obj1.details();	
	}
}