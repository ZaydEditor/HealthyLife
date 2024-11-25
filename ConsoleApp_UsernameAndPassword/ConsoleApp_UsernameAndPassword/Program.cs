// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;


    UserProfile user = new UserProfile();
    Console.Write("UserName: ");
    user.username = Console.ReadLine();
    Console.Write("Password: ");
    user.password = Console.ReadLine();

    try
    {
        ValidateUser(user);
        Console.Clear();
        Console.WriteLine("Welcome to the system...");
    }
    catch (InvalidUserCredentialsException e)
    {
        var logger = new Logger();
        logger.LogError(InvalidUserCredentialsException.Code, e.Message);
    }
    finally
    {
        Console.WriteLine("Session finished");
    }

   
//Method for checking
static void ValidateUser(UserProfile user)
{
    if (user.username != "admin" && user.password != "password333")
    {
        throw new InvalidUserCredentialsException();
    }
}

//Error message
class Logger
{
    public void LogError(string code,string message)
    {
        Console.Clear();
        string time = DateTime.Now.ToString("HH:mm:ss");
        Console.WriteLine($"[{time} ERR] {code}: {message}");
    } 

}

//UserProfile
public class UserProfile
{
    public string username {  get; set; }
    public string password { get; set; }
}


//New Custom Exception
public class InvalidUserCredentialsException : Exception
{
    public const string Code = "invalid_user_credentials";
 
    public InvalidUserCredentialsException()
        : base("Username or password is incorrect") 
    {
    }
}
