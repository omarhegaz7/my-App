/////// task 1 
using System;
namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Enter your name: ");
      string name = Console.ReadLine();  
      decimal balance ;
      while(true){
         Console.Write("Enter initial balance: ");
          string input = Console.ReadLine();
          if(!decimal.TryParse(input , out balance))
          { Console.WriteLine("Invalid balance, try again ");
                continue;}
          if(balance<0){
               Console.WriteLine("Balance cannot be negative, try again");
              continue ; 
          }
          break ;
      }
        Console.WriteLine($"Account created successfully! balance : {balance} EGP");
		while (true){
		 Console.WriteLine("Enter your age :  ");
        try{
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"your age is :  {age}");
			break ;
        }
        catch(FormatException){
            Console.WriteLine("Invalid age please enter a numper");
        }
		}
       
        
        
        
    }}
  }




///////////// task 2,3,4





using System;
using System.Data;
namespace HelloWorld
{
  class Program
  {
    static int ShowMenue(){
        Console.WriteLine("========== BANK MENU ==========");
        Console.WriteLine("1. check balance");
        Console.WriteLine("2. deposit money");
        Console.WriteLine("3. widtraw money");
        Console.WriteLine("4. view transaction summary");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option : ");

        int choice ;
        while(!int.TryParse(Console.ReadLine(),out choice)){
            Console.WriteLine("invalid , please enter number ");
        }
        return choice ;
    }
    static void Deposite(ref decimal balance , decimal amount){
        if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount) , "Amount must be greater than zero");
            }
        balance+=amount ;
    } 
    static void Withdraw(ref decimal balance , decimal amount){
    if(amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount) , "Amount must be greater than zero");
        }
    if(amount > balance){
        throw new InvalidOperationException("amount must be less than balance");
    }
        balance -= amount ;
    }
    static void DisplayBalance(decimal balance){
        Console.WriteLine($"Your current balance is : {balance}");
    }
    // static decimal ReadAmount(){
    //     decimal amount ;
    //     while(true){
    //         Console.WriteLine("Enter amount : ");
    //         if(!decimal.TryParse(Console.ReadLine(),out amount)){
    //             Console.WriteLine("please enter number");
    //             continue ;
    //         }
    //         if(amount<=0){
    //             Console.Write("amount cannot be 0 , please enter a valid number");
    //             continue ;
    //         }
    //         return amount ;
    //     }
    // }
    static bool TryReadAmount(string input , out decimal amount)
        {
            return decimal.TryParse(input, out amount);
            // if(amount < 0)
            // {
            //     throw new ArgumentOutOfRangeException(nameof(amount) , "Amount must be greater than zero")
            // }
            
        }
    static void Main(string[] args){
        decimal balance = 1000;  
        int depositCount = 0, withdrawCount = 0;
        decimal totalDeposited = 0, totalWithdrawn = 0;
        bool run = true;
        
        while(run){
        int choice = ShowMenue() ;
        switch(choice) {
            case 1 : 
                DisplayBalance(balance);
                break ;
            case 2 : 
            try{
                decimal amount ;
                    Console.WriteLine($"Current Balance: {balance} EGP");
                    Console.Write("enter deposite amount : ");
                    if(TryReadAmount(Console.ReadLine(), out amount))
                        {
                            Deposite(ref balance , amount);
                            depositCount++;
                            totalDeposited += amount;
                            Console.WriteLine("Succesfully deposite amount .");

                        }else Console.WriteLine("invalid, please inter a number");
            }
            catch(ArgumentOutOfRangeException ex){
                 Console.WriteLine($"Error: {ex.Message}");
            }
            catch(InvalidOperationException ex){
                 Console.WriteLine($"Error: {ex.Message}");
            }
            finally{
                Console.WriteLine("Transaction attempt completed.");
            }
                
                Console.WriteLine("Returning to main menu......");
                break ;
                
            case 3 : 
            try{
                decimal amountt ;
                
                Console.WriteLine($"Current Balance: {balance} EGP"); 
                Console.Write("enter withdraw amount : ");
                if(TryReadAmount(Console.ReadLine(), out amountt))
                {
                    Withdraw(ref balance , amountt);
                    withdrawCount++;
                    totalWithdrawn += amountt;
                    Console.WriteLine("Succesfully Withdraw amount .");   
                            
                }else Console.WriteLine("invalid, please inter a number");
            }
            catch(ArgumentOutOfRangeException ex){
                 Console.WriteLine($"Error: {ex.Message}");
            }
            catch(InvalidOperationException ex){
                 Console.WriteLine($"Error: {ex.Message}");
            }
            finally{
                Console.WriteLine("Transaction attempt completed.");
            }
                
                Console.WriteLine("Returning to main menu......");
                break ;
            case 4 : 
                Console.WriteLine("--- Transaction Summary ---");
                Console.WriteLine($"Deposits:    {depositCount} (Total: {totalDeposited} EGP)");
                Console.WriteLine($"Withdrawals: {withdrawCount} (Total: {totalWithdrawn} EGP)");
                DisplayBalance(balance);
                break ;
            case 5 : 
                Console.WriteLine("thank you for useing our machine Bank ");
                run = false;
                break ;
            default :
                Console.WriteLine("Invalid , please Choose from 1 to 5");
                    break;
        }
        }
    }
    
    }
}
