namespace DemoApp
{
    class Shop
    {
        public CellPhone ConstructSamsungPhone()
        {
            ICellPhoneBuilder b = new SamsumgPhoneBuilder();
            return b.SetOS("Android").SetCamera(20).GetPhone();
        }

    }
}