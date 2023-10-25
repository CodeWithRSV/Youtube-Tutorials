namespace DemoApp
{
    public interface ICellPhoneBuilder
    {
        CellPhone GetPhone();
        ICellPhoneBuilder SetBattery(int battery);
        ICellPhoneBuilder SetCamera(int camera);
        ICellPhoneBuilder SetOS(string os);
        ICellPhoneBuilder SetProcessor(string processor);
        ICellPhoneBuilder SetScreenSize(double screenSize);
    }
}