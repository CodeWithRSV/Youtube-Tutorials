namespace DemoApp
{
    public class Client
    {
        static void Main(string[] args)
        {
            IDatabase database = new ProxyDataBase();
            var db = (database as ProxyDataBase);
            db.Login();
            Console.WriteLine(database.GetDataForID(3));
            db.Logout();
            Console.WriteLine(database.GetDataForID(3));
        }
    }
    public interface IDatabase
    {
        string GetDataForID(int ID);
    }
    public class RealDatabase : IDatabase
    {
        public string GetDataForID(int ID)
        {
            return "Data from DB for ID: " + ID;
        }
    }
    public class ProxyDataBase : IDatabase
    {
        private bool _isLoogedIn = false;
        private HashSet<int> _cache = new HashSet<int>();

        private IDatabase _realDatabase = new RealDatabase();
        public void Login()
        {
            _isLoogedIn = true;
        }
        public void Logout()
        {
            _isLoogedIn = false;
        }
        public string GetDataForID(int ID)
        {
            if (!_isLoogedIn) return "Please login to fetch data";
            if (_cache.Contains(ID)) return "Data from Cache for ID:" + ID;
            string v = _realDatabase.GetDataForID(ID);
            if(!string.IsNullOrEmpty(v))
                _cache.Add(ID);
            return v;
        }
    }
}
