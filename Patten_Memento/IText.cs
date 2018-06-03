using System;
namespace Patten_Memento
{
    interface IText
    {
        string TextInBox { get; set; }
        event EventHandler<EventArgs> TextUpdate;
        event EventHandler<EventArgs> Undo;
        event EventHandler<EventArgs> Redo;
        event EventHandler<EventArgs> ClearRedoes;

        int Capacity { get; set; }
        int RedoesQuantity { get; set; }
    }
}
