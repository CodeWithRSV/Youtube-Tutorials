using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class SamsumgPhoneBuilder : ICellPhoneBuilder
    {

        private string brand = "Samsung";
        private string os;
        private string processor;
        private double screenSize;
        private int battery;
        private int camera;

        public CellPhone GetPhone()
        {
            return new CellPhone(os, processor, screenSize, battery, camera, brand);
        }

        public ICellPhoneBuilder SetOS(string os)
        {
            this.os = os;
            return this;
        }
        public ICellPhoneBuilder SetProcessor(string processor)
        {
            this.processor = processor;
            return this;
        }
        public ICellPhoneBuilder SetScreenSize(double screenSize)
        {
            this.screenSize = screenSize;
            return this;
        }
        public ICellPhoneBuilder SetBattery(int battery)
        {
            this.battery = battery;
            return this;
        }
        public ICellPhoneBuilder SetCamera(int camera)
        {
            this.camera = camera;
            return this;
        }
    }
}
