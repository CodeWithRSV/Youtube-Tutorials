public interface IMemento
{
    string GetName();
    string GetState();
}
class ConcreteMemento : IMemento
{
    private readonly string _state;
    private readonly DateTime _date;
    public ConcreteMemento(string state)
    {
        this._state = state;
        this._date = DateTime.Now;
    }
    public string GetName()
    {
        return $"{this._date} / ({this._date.Second} sec) / {this._state.Substring(0, 9)}...";
    }
    public string GetState()
    {
        return this._state;
    }
}