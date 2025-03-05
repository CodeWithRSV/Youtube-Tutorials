namespace DemoApp
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handle(Request request);
    }
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public virtual string Handle(Request request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class AuthenticationHandler : AbstractHandler
    {
        public override string Handle(Request request)
        {
            if (!request.IsLoggedIn) return "Please log in to access data";
            return base.Handle(request);
        }
    }

    public class AuthorizationHandler : AbstractHandler
    {
        public override string Handle(Request request)
        {
            if (!request.CanOrder) return "User does not have access to ordering system";
            return base.Handle(request);
        }
    }

    public class ValidationHandler : AbstractHandler
    {
        public override string Handle(Request request)
        {
            if (string.IsNullOrEmpty(request.ReqData)) return "Invalid request Data";
            return base.Handle(request);
        }
    }

    public class CacheHandler : AbstractHandler
    {
        private static HashSet<string> _cache = new HashSet<string>();
        public override string Handle(Request request)
        {
            if (_cache.Contains(request.ReqData)) return "Data found in cache";
            _cache.Add(request.ReqData);
            return base.Handle(request);
        }
    }

    public class Request
    {
        public bool IsLoggedIn { get; set; }
        public bool CanOrder { get; set; }
        public string ReqData { get; set; }
    }
    public class OrderingSystem
    {
        public void PlaceOrder(Request request)
        {
            Console.WriteLine("Order Placed: " + request.ReqData);
        }
    }
}
