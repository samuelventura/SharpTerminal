using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpTerminal.Tools;

namespace SharpTerminal
{
	public partial class MainForm : Form
	{
        private readonly SessionDao dao = new SessionDao();

		public MainForm()
		{
			InitializeComponent();
		}

        private void AddSession(SessionSettings session)
        {
            var tabPage = new TabPage
            {
                Text = session.Name
            };
            var terminalControl = new TerminalControl
            {
                Dock = DockStyle.Fill
            };
            tabPage.Controls.Add(terminalControl);
            tabControl.TabPages.Add(tabPage);
            terminalControl.ToUI(session);
            tabControl.SelectedTab = tabPage;
        }

        private TerminalControl GetTerminal(TabPage tabPage)
        {
            //Tag not used to make it compatible with designer added tabs
            return (TerminalControl)tabPage.Controls[0];
        }

        private TerminalControl GetSettings(TabPage tabPage, SessionSettings session)
        {
            var terminalControl = GetTerminal(tabPage);
            terminalControl.FromUI(session);
            session.Name = tabPage.Text;
            return terminalControl;
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
            var sessions = new List<SessionSettings>();
            foreach(TabPage tabPage in tabControl.TabPages)
            {
                var session = new SessionSettings();
                var terminalControl = GetSettings(tabPage, session);
                terminalControl.Unload();
                sessions.Add(session);
            }
            dao.Save(sessions);
		}
	
		void MainFormLoad(object sender, EventArgs e)
		{
			Text = string.Format("SharpTerminal - 1.0.2 https://github.com/samuelventura/SharpTerminal");

            var sessions = dao.Load();

            if (sessions.Count == 0)
            {
                sessions.Add(new SessionSettings());
            }
            
            //remove design default
            removeToolStripButton.PerformClick();

            foreach (var session in sessions)
            {
                AddSession(session);
            }

            tabControl.SelectedIndex = 0;
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            AddSession(new SessionSettings());
        }

        private void CloneToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            {
                var session = new SessionSettings();
                var terminalControl = GetSettings(selectedPage, session);
                AddSession(session);
            }
        }

        private void RenameToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            { 
                var form = new RenameForm();
                form.textBox.Text = selectedPage.Text;
                if (DialogResult.OK == form.ShowDialog())
                {
                    selectedPage.Text = form.textBox.Text;
                }
            }
        }

        private void RemoveToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            {
                var terminalControl = GetTerminal(selectedPage);
                terminalControl.Unload();
                tabControl.TabPages.Remove(selectedPage);
            }
        }
    }
}
