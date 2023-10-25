namespace DemoApp
{
    public class MySingleton
    {
        private MySingleton() { }
        private static object locker = new object();

        private static MySingleton instance;

        public static MySingleton GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new MySingleton();
                }
            }
            return instance;
        }
    }
}
