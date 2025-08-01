public interface IPublisher
{
    void Subscribe(ISubscriber observer);
    void Unsubscribe(ISubscriber observer);
    void NotifySubscribers(string context);
}

public class Publisher : IPublisher
{
    private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();
    public void Subscribe(ISubscriber observer)
    {
        _subscribers.Add(observer);
    }
    public void Unsubscribe(ISubscriber observer)
    {
        _subscribers.Remove(observer);
    }
    public void NotifySubscribers(string context)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(context);
        }
    }
}
