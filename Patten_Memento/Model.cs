namespace Patten_Memento
{
    class Model
    {
        readonly Originator text = new Originator();
        readonly Caretaker caretaker = new Caretaker();
        public int Capacity;
        public int RedoesQuantity;
        public void SaveState(string state)
        {
            text.Snapshot = state;
            caretaker.Add(text.CreateMemento());
            Capacity = caretaker.Capacity;
            RedoesQuantity = caretaker.RedoesQuantity;
        }

        public string Undo()
        {
            text.SetMemento(caretaker["Undo"]);
            Capacity = caretaker.Capacity;
            RedoesQuantity = caretaker.RedoesQuantity;
            return text.Snapshot;
        }

        public string Redo()
        {
            text.SetMemento(caretaker["Redo"]);
            Capacity = caretaker.Capacity;
            RedoesQuantity = caretaker.RedoesQuantity;
            return text.Snapshot;
        }

        public void ClearRedoesStack()
        {
            caretaker.Clear();
            RedoesQuantity = caretaker.RedoesQuantity;
        }
    }
}
