using System;
using System.Windows.Forms;
using SharpTabs;

namespace SharpTerminal
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
            //SetHighDpiMode introduced in net5-win
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var path = args.Length > 0 ? args[0] : null;
            var factory = new TerminalFactory(path);
            TabsTools.SetupCatcher(factory.Name);
            Application.Run(new MainForm(factory));
        }		
	}
}
