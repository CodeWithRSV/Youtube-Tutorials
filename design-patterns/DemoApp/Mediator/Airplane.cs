namespace DemoApp.Mediator
{
    public interface Airplane
    {
        Task TakeOff();
        Task Land();
        void ProvideClearance();
    }
    public class CommercialAirplane : Airplane
    {
        private readonly AirTrafficMediator mediator;
        public CommercialAirplane(AirTrafficMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task TakeOff()
        {
            while(!mediator.RequestTakeOff(this))
            {
                Console.WriteLine($"Waiting for clearance to takeoff...");
                await Task.Delay(2000); // Simulate waiting
            }
            Console.WriteLine($"Takeoff granted.");
        }

        public async Task Land()
        {
            while (!mediator.RequestLanding(this))
            {
                Console.WriteLine($"Waiting for clearance to land...");
                await Task.Delay(2000); // Simulate waiting
            }
            Console.WriteLine($"Landing granted.");
        }
        public void ProvideClearance()
        {
            mediator.ProvideClearance();
        }
    }
}
