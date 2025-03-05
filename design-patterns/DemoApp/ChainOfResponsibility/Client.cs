using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ChainOfResponsibility
{
    public class Client
    {
        static void Main(string[] args)
        {
            IHandler handler = CORSetup();
            Request request = new Request
            {
                IsLoggedIn = true,
                CanOrder = true,
                ReqData = "45"
            };
            PlaceOrder(handler, request);
            PlaceOrder(handler, request);
        }
        private static IHandler CORSetup()
        {
            IHandler handler = new AuthenticationHandler();
            handler.SetNext(new AuthorizationHandler()).SetNext(new ValidationHandler()).SetNext(new CacheHandler());
            return handler;
        }
        private static void PlaceOrder(IHandler handler, Request request)
        {
            string msg = handler.Handle(request);
            if (!string.IsNullOrEmpty(msg))
                Console.WriteLine(msg);
            else
            {
                new OrderingSystem().PlaceOrder(request);
            }
        }
    }
}
