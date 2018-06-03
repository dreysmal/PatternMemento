using System;
using System.Windows.Forms;

namespace Patten_Memento
{
    public partial class Form1 : Form, IText
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string TextInBox
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public event EventHandler<EventArgs> TextUpdate;
        public event EventHandler<EventArgs> Undo;
        public event EventHandler<EventArgs> Redo;
        public event EventHandler<EventArgs> ClearRedoes;
        public int Capacity { get; set; }
        public int RedoesQuantity { get; set; }

        private bool IsButtonPressed;
        private void toolStripButton1_Click(object sender, EventArgs e) //back
        {
            IsButtonPressed = false;
            Undo?.Invoke(this, EventArgs.Empty);
            textBox1.SelectionStart = textBox1.Text.Length;
            toolStripButton2.Enabled = true;
            if (Capacity == 0)
                toolStripButton1.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//forward
        {
            IsButtonPressed = false;
            Redo?.Invoke(this, EventArgs.Empty);
            textBox1.SelectionStart = textBox1.Text.Length;
            toolStripButton1.Enabled = true;
            if (RedoesQuantity == 0)
                toolStripButton2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (IsButtonPressed)
            {
                ClearRedoes?.Invoke(this, EventArgs.Empty);
                TextUpdate?.Invoke(this, EventArgs.Empty);
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsButtonPressed = true;
        }
    }
}
