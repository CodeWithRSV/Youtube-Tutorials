public interface IState
{
    void HandlePublish(string currentUser);

    void HandleEdit(string currentUser);
}

public class DraftState : IState
{
    protected DocumentContext _context;
    public DraftState(DocumentContext context)
    {
        _context = context;
    }
    public virtual void HandlePublish(string currentUser)
    {
        if (currentUser != "Author")
        {
            Console.WriteLine($"{currentUser} cannot publish in Draft state. Only Author can publish.");
            return;
        }
        _context.TransitionTo(new ModerationState(_context));
        Console.WriteLine("Document sent to admin for moderation");
    }
    public virtual void HandleEdit(string currentUser)
    {
        if (currentUser != "Author")
        {
            Console.WriteLine($"{currentUser} cannot edit in Draft state. Only Author can edit.");
            return;
        }
        Console.WriteLine($"Document edited by author");
    }
}

public class ModerationState : IState
{
    protected DocumentContext _context;
    public ModerationState(DocumentContext context)
    {
        _context = context;
    }
    public virtual void HandlePublish(string currentUser)
    {
        if (currentUser != "Admin")
        {
            Console.WriteLine($"{currentUser} cannot publish in Moderation state. Only admin can publish.");
            return;
        }
        _context.TransitionTo(new PublishedState(_context));
        Console.WriteLine("Document published by admin");
    }
    public virtual void HandleEdit(string currentUser)
    {
        if (currentUser != "Admin")
        {
            Console.WriteLine($"{currentUser} cannot edit in moderation state. Only admin can edit.");
            return;
        }
        Console.WriteLine($"Document edited by admin");
    }
}
public class PublishedState : IState
{
    protected DocumentContext _context;
    public PublishedState(DocumentContext context)
    {
        _context = context;
    }
    public virtual void HandlePublish(string currentUser)
    {
        Console.WriteLine("Invalid operation. Document is already published.");
    }
    public virtual void HandleEdit(string currentUser)
    {
        Console.WriteLine("Invalid operation. Published document cannot be edited.");
    }
}