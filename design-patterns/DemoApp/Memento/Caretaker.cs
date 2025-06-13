using DemoApp;

class Caretaker
{
    private List<IMemento> _mementos = new List<IMemento>();
    private readonly Originator _originator;
    public Caretaker(Originator originator)
    {
        _originator = originator;
    }
    public void Backup()
    {
        Console.WriteLine("Caretaker: Saving Originator's state...");
        _mementos.Add(_originator.Save());
    }
    public void Undo()
    {
        if (_mementos.Count == 0)
        {
            Console.WriteLine("Caretaker: No mementos to restore.");
            return;
        }
        IMemento memento = _mementos.Last();
        _mementos.RemoveAt(_mementos.Count - 1);
        Console.WriteLine($"Caretaker: Restoring state to: {memento.GetName()}");
        _originator.Restore(memento);
    }

    public void ShowHistory()
    {
        Console.WriteLine("Caretaker: Here's the list of mementos:");

        foreach (var memento in this._mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}