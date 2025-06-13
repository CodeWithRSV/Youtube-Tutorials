
namespace DemoApp.Mediator
{
    public interface AirTrafficMediator
    {
        bool RequestLanding(Airplane airplane);
        bool RequestTakeOff(Airplane airplane);
        void ProvideClearance();
    }

    public class AirportControlTower : AirTrafficMediator
    {
        private Airplane _currentAirplance = null;
        public bool RequestTakeOff(Airplane airplane)
        {
            if (_currentAirplance != null)
            {
                Console.WriteLine("Take off denied. Another airplane is on runway.");
                return false;
            }
            _currentAirplance = airplane;
            return true;
        }
        public bool RequestLanding(Airplane airplane)
        {
            if (_currentAirplance != null)
            {
                Console.WriteLine("Landing denied. Another airplane is on runway.");
                return false;
            }
            _currentAirplance = airplane;
            return true;
        }
        public void ProvideClearance()
        {
            Console.WriteLine("Airspace clear.");
            _currentAirplance = null;
        }
    }
}