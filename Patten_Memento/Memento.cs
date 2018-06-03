using System.Windows.Forms;
namespace Patten_Memento
{
    class Memento
    {
        public Memento(string snapshot)
        {
            Snapshot = snapshot;
        }
        public string Snapshot { get; set; }
    }
}
