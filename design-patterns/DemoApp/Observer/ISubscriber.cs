public interface ISubscriber
{
    void Update(string context);
}

public class EmailSubscriber : ISubscriber
{
    private readonly List<string> customers = ["John", "Sarah"];
    public void Update(string context)
    {
        foreach (var customer in customers)
        {
            Console.WriteLine($"Email sent to {customer} with context: {context}");
        }
    }
}

public class SMSSubscriber : ISubscriber
{
    private readonly List<string> customers = ["Mike", "Rachel"];
    public void Update(string context)
    {
        foreach (var customer in customers)
        {
            Console.WriteLine($"SMS sent to {customer} with context: {context}");
        }
    }
}

