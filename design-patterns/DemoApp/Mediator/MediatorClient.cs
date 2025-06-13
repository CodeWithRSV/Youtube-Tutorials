namespace DemoApp.Mediator
{
    public class Client
    {
        public static async Task Main(string[] args)
        {
            AirTrafficMediator controlTower = new AirportControlTower();

            Airplane airplane1 = new CommercialAirplane(controlTower);
            Airplane airplane2 = new CommercialAirplane(controlTower);
            // Simulate airplane 1 taking off
            Task task1 = airplane1.TakeOff();
            // Simulate airplane 2 trying to land while airplane 1 is on the runway
            Task task2 = airplane2.Land();
            // Provide clearance for the next airplane
            airplane1.ProvideClearance();
            Task.WaitAll(task1, task2);
        }
    }
}
