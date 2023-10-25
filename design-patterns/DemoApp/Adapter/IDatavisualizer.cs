/* Usage in main
  
            string JsonData = "Randon Json Data";
            AnalyticsLibrary adaptee = new AnalyticsLibrary();
            DataFormatAdapter adapter =  new DataFormatAdapter(adaptee);
            adapter.DisplayGraph(JsonData);
*/

namespace DemoApp
{
    public interface IDatavisualizer
    {
        void DisplayGraph(string jsonData);
    }
    public class DataFormatAdapter : IDatavisualizer
    {
        private readonly AnalyticsLibrary _adaptee;

        public DataFormatAdapter(AnalyticsLibrary adaptee)
        {
            _adaptee = adaptee;
        }

        public void DisplayGraph(string jsonData)
        {
            CustomLibraryObject obj = GetObjFromJSON(jsonData);
            _adaptee.DisplayGraph(obj);
        }

        private CustomLibraryObject GetObjFromJSON(string jsonData)
        {
            //Convert json data to library object
            return new CustomLibraryObject();
        }
    }
}
