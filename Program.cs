// порушено SRP, OCP
class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}
interface IEmailLogType
{
    void Log(Email email);
}
class EmailLogTypeConsole : IEmailLogType
{
    public void Log(Email email)
    {
        Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}

class EmailSender
{
    public void Send(Email email, IEmailLogType log)
    {
        // ... sending...
       log.Log(email);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email()
        {
            From = "Me",
            To = "Vasya",
            Theme = "Who are you?"
        };
        Email e2 = new Email()
        {
            From = "Vasya",
            To = "Me",
            Theme = "vacuum cleaners!"
        };
        Email e3 = new Email()
        {
            From = "Kolya",
            To =
       "Vasya",
            Theme = "No! Thanks!"
        };
        Email e4 = new Email()
        {
            From = "Vasya",
            To = "Me",
            Theme = "washing machines!"
        };
        Email e5 = new Email()
        {
            From = "Me",
            To = "Vasya",
            Theme = "Yes"
        };
        Email e6 = new Email()
        {
            From = "Vasya",
            To =
       "Petya",
            Theme = "+2"
        };
        IEmailLogType con = new EmailLogTypeConsole();
        EmailSender es = new EmailSender();
        es.Send(e1, con);
        es.Send(e2, con);
        es.Send(e3, con);
        es.Send(e4, con);
        es.Send(e5, con);
        es.Send(e6, con);
        Console.ReadKey();
    }
}