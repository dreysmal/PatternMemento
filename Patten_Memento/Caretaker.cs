using System.Collections.Generic;

namespace Patten_Memento
{
    class Caretaker
    {
        private readonly LinkedList<Memento> Undos = new LinkedList<Memento>();
        private readonly Stack<Memento> Redos = new Stack<Memento>();

        public int Capacity { get; set; }
        public int RedoesQuantity { get; set; }
        public Memento this[string UndoesOrRedoes]
        {
            get
            {
                switch (UndoesOrRedoes)
                {
                    case "Undo":
                        Redos.Push(Undos.Last.Value);
                        Memento state = Undos.Last.Value;
                        Undos.RemoveLast();
                        Capacity = Undos.Count;
                        RedoesQuantity = Redos.Count;
                        return state;
                    case "Redo":
                        Undos.AddLast(Redos.Pop());
                        Capacity = Undos.Count;
                        RedoesQuantity = Redos.Count;
                        return Undos.Last.Value;
                    default:
                        Capacity = Undos.Count;
                        RedoesQuantity = Redos.Count;
                        return null;
                }
            }
        }

        public void Add(Memento memento)
        {
            if(Undos.Count < 256)
                Undos.AddLast(memento);
            else
            {
                Undos.RemoveFirst();
                Undos.AddLast(memento);
            }
            Capacity = Undos.Count;
            RedoesQuantity = Redos.Count;
        }

        public void Clear()
        {
            if (Redos.Count != 0)
            {
                Undos.AddLast(Redos.Pop());
                Capacity = Undos.Count;
                Redos.Clear();
            }
            RedoesQuantity = 0;
        }
    }
}
