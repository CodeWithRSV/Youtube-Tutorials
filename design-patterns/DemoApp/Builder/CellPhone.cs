namespace DemoApp
{
    public class CellPhone
    {
        private string brand;
        private string os;
        private string processor;
        private double screenSize;
        private int battery;
        private int camera;
        public CellPhone(string os, string processor, double screenSize, int battery, int camera, string brand)
        {
            this.os = os;
            this.processor = processor;
            this.screenSize = screenSize;
            this.battery = battery;
            this.camera = camera;
            this.brand = brand;
        }

        public override string ToString()
        {
            return $"OS: {os}, Processor: {processor}, Screensize: {screenSize}, Battery: {battery}, Camera: {camera}";
        }
    }










}