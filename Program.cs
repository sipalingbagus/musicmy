using System;
using System.Windows.Forms;

namespace MyMusic
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Make sure Form1 is correctly referenced
        }
    }
}
