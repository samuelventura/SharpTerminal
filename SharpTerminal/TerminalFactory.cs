using System;
using System.Drawing;
using System.Windows.Forms;
using SharpTabs;

namespace SharpTerminal
{
    public class TerminalFactory : ISessionFactory
    {
        private readonly string path;
        public string Name => "SharpTerminal";
        public string Ext => "SharpTerminal";
        public string Title => $"SharpTerminal - {Version} {Home}";
        public string Status => path;
        public Icon Icon => TabsTools.ExeIcon();
        public bool HasSetup => false;
        private string Version => TabsTools.Version();
        private string Home => "https://github.com/samuelventura/SharpTerminal";

        public TerminalFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public void Setup(Control control)
        {
            throw new NotImplementedException();
        }

        public ISessionDto[] Load()
        {
            return Load(path);
        }

        public ISessionDto[] Load(string path)
        {
            SessionDao.Retype(path, 1, typeof(TerminalDto));
            return SessionDao.Load<TerminalDto>(path);
        }

        public void Unload(Control obj)
        {
            var control = obj as TerminalControl;
            control.Unload();
        }

        public void Save(ISessionDto[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, ISessionDto[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new TerminalDto
            {
                Name = SessionDao.NewName()
            });
        }

        public ISessionDto Unwrap(Control obj)
        {
            var control = obj as TerminalControl;
            var dto = new TerminalDto
            {
                Name = control.Text
            };
            control.FromUI(dto);
            return dto;
        }

        public Control Wrap(ISessionDto obj)
        {
            var dto = obj as TerminalDto;
            var control = new TerminalControl
            {
                Text = dto.Name,
            };
            control.ToUI(dto);
            return control;
        }
    }
}
