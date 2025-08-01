namespace DemoApp.observer
{
    public class Client
    {
        static async Task Main(string[] args)
        {
            Publisher publisher = new Publisher();
            ISubscriber emailSubscriber = new EmailSubscriber();
            ISubscriber smsSubscriber = new SMSSubscriber();
            publisher.Subscribe(emailSubscriber);
            publisher.Subscribe(smsSubscriber);
            publisher.NotifySubscribers("New IPhone launch!");
            publisher.Unsubscribe(emailSubscriber);
            publisher.NotifySubscribers("New Samsung Galaxy launch!");
        }
    }
}
