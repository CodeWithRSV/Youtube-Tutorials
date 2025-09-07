public class DocumentContext
{
    private IState _state;

    public DocumentContext(IState state)
    {
        this.TransitionTo(state);
    }

    // The Context allows changing the State of object at runtime.
    public void TransitionTo(IState state)
    {
        Console.WriteLine($"Transition to {state.GetType().Name}.");
        this._state = state;
    }

    public void Publish(string currentUser)
    {
        this._state.HandlePublish(currentUser);
    }

    public void Edit(string currentUser)
    {
        this._state.HandleEdit(currentUser);
    }
}