using System;

namespace Patten_Memento
{
    class Presenter
    {
        private readonly IText itext;
        private Model model = new Model();

        public Presenter(IText itext)
        {
            this.itext = itext;
            this.itext.TextUpdate += Update;
            this.itext.Undo += UndoMeth;
            this.itext.Redo += RedoMeth;
            this.itext.ClearRedoes += (sender, args) => model.ClearRedoesStack();

            Update(null, EventArgs.Empty);
        }

        public void Update(object sender, EventArgs e)
        {
            model.SaveState(itext.TextInBox);
            itext.Capacity = model.Capacity;
            itext.RedoesQuantity = model.RedoesQuantity;
        }

        public void UndoMeth(object sender, EventArgs e)
        {
            string text = model.Undo();
            if (text.Equals(itext.TextInBox))
            {
                text = model.Undo();
            }

            itext.TextInBox = text;
            itext.Capacity = model.Capacity;
            itext.RedoesQuantity = model.RedoesQuantity;
        }

        public void RedoMeth(object sender, EventArgs e)
        {
            string text = model.Redo();
            if (text.Equals(itext.TextInBox))
            {
                text = model.Redo();
            }

            itext.TextInBox = text;
            itext.Capacity = model.Capacity;
            itext.RedoesQuantity = model.RedoesQuantity;
        }
    }
}
