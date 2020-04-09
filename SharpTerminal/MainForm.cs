using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SharpTerminal
{
	public partial class MainForm : Form
    {
        private readonly SessionDao sessionDao;

        public MainForm(string dbPath = null)
        {
            sessionDao = new SessionDao(dbPath);

            InitializeComponent();

            toolStripStatusLabel.Text = sessionDao.DbPath;
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

        private void GetSettings(TabPage tabPage, SessionSettings session)
        {
            var terminalControl = GetTerminal(tabPage);
            terminalControl.FromUI(session);
            session.Name = tabPage.Text;
        }

        private List<SessionSettings> GetSessionList()
        {
            var sessions = new List<SessionSettings>();
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                var session = new SessionSettings();
                GetSettings(tabPage, session);
                sessions.Add(session);
            }
            return sessions;
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
            foreach (TabPage tabPage in tabControl.TabPages) GetTerminal(tabPage).Unload();

            var live = GetSessionList();
            var stored = sessionDao.Load();

            foreach (var session in stored) session.Id = 0;

            var storedJSON = JsonConvert.SerializeObject(stored);
            var liveJSON = JsonConvert.SerializeObject(live);
            if (storedJSON != liveJSON)
            {
                //System.IO.File.WriteAllText(SharpTerminal.Tools.Executable.Relative("storedJSON.txt"), storedJSON);
                //System.IO.File.WriteAllText(SharpTerminal.Tools.Executable.Relative("liveJSON.txt"), liveJSON);

                var result = MessageBox.Show(this, "Save changes before closing?",
                                     "Detected changes will be lost",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    sessionDao.Save(live);
                }
            }
        }
	
		void MainFormLoad(object sender, EventArgs e)
		{
			Text = string.Format("SharpTerminal - 1.0.7 https://github.com/samuelventura/SharpTerminal");

            var sessions = sessionDao.Load();

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

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            sessionDao.Save(GetSessionList());
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
                GetSettings(selectedPage, session);
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

        private void ExportSelectedToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage == null) return;

            var fd = new SaveFileDialog
            {
                Title = "Export to SharpTerminal File",
                Filter = "LiteDB Files (*.SharpTerminal)|*.SharpTerminal",
                OverwritePrompt = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var session = new SessionSettings();
                var list = new List<SessionSettings>();
                list.Add(session);
                GetSettings(selectedPage, session);
                var dao = new SessionDao(fd.FileName);
                dao.Save(list);
            }
        }

        private void ExportAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count == 0) return;

            var fd = new SaveFileDialog
            {
                Title = "Export to SharpTerminal File",
                Filter = "LiteDB Files (*.SharpTerminal)|*.SharpTerminal",
                OverwritePrompt = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var dao = new SessionDao(fd.FileName);
                dao.Save(GetSessionList());
            }
        }

        private void ImportToolStripButton_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = "Import from SharpTerminal File",
                Filter = "LiteDB Files (*.SharpTerminal)|*.SharpTerminal",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var dao = new SessionDao(fd.FileName);
                foreach (var session in dao.Load())
                {
                    AddSession(session);
                }
            }
        }
    }
}
