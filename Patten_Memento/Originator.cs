namespace Patten_Memento
{
    class Originator
    {
        public string Snapshot { get; set; }

        public void SetMemento(Memento memento)
        {
            Snapshot = memento.Snapshot;
        }

        public Memento CreateMemento()
        {
            return new Memento(Snapshot);
        }
    }
}
