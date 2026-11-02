using System;
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
        balance+=amount ;
    } 
    static void Withdraw(ref decimal balance , decimal amount){
        balance -= amount ;
    }
    static void DisplayBalance(decimal balance){
        Console.WriteLine($"Your current balance is : {balance}");
    }
    static decimal ReadAmount(){
        decimal amount ;
        while(true){
            Console.WriteLine("Enter amount : ");
            if(!decimal.TryParse(Console.ReadLine(),out amount)){
                Console.WriteLine("please enter number");
                continue ;
            }
            if(amount<=0){
                Console.Write("amount cannot be 0 , please enter a valid number");
                continue ;
            }
            return amount ;
        }
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
                decimal amount =  ReadAmount();
                Deposite(ref balance , amount);
                 depositCount++;
                 totalDeposited += amount;
                break ;
            case 3 : 
                decimal amountt =  ReadAmount();
                if(amountt > balance ){
                    Console.WriteLine("Insufficient balance.");
                }else{
                    Withdraw(ref balance , amountt);
                    withdrawCount++;
                    totalWithdrawn += amountt;
                }
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