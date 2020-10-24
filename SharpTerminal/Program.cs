using System;
using System.Windows.Forms;
using SharpTerminal.Tools;
using SharpTabs;

namespace SharpTerminal
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
            var path = args.Length > 0 ? args[0] : null;
            Application.EnableVisualStyles();
            Application.ThreadException += (s, t) =>
            {
                Thrower.Dump(t.Exception);
                var msg = string.Format("{0} {1}", t.Exception.GetType().Name, t.Exception.Message);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new TerminalFactory(path)));
        }		
	}
}
