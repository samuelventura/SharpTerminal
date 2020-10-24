using System;
using System.Drawing;
using System.Windows.Forms;
using SharpTabs;

namespace SharpTerminal
{
    public class TerminalFactory : SessionFactory
    {
        private readonly string path;
        public string Name => "SharpTerminal";
        public string Ext => "SharpTerminal";
        public string Title => "SharpTerminal - 1.0.10 https://github.com/samuelventura/SharpTerminal";
        public string Status => path;
        public Icon Icon => Resource.Icon;

        public TerminalFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public object[] Load()
        {
            return Load(path);
        }

        public object[] Load(string path)
        {
            var dtos = SessionDao.Load<TerminalDto>(path);
            foreach(var obj in dtos)
            {
                var dto = obj as TerminalDto;
                dto.Id = 0;
            }
            return dtos;
        }

        public void Unload(Control obj)
        {
            var control = obj as TerminalControl;
            control.Unload();
        }

        public void Save(object[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, object[] dtos)
        {
            var index = 0;
            foreach (var obj in dtos)
            {
                var dto = obj as TerminalDto;
                dto.Id = ++index; //1..
            }
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new TerminalDto
            {
                Name = NewName()
            });
        }

        public object Unwrap(Control obj)
        {
            var control = obj as TerminalControl;
            var dto = new TerminalDto 
            { 
                Name = control.Text 
            };
            control.FromUI(dto);
            return dto;
        }

        public Control Wrap(object obj)
        {
            var dto = obj as TerminalDto;
            var control = new TerminalControl
            {
                Text = dto.Name,
                Dock = DockStyle.Fill,
            };
            control.ToUI(dto);
            return control;
        }

        private static long count;

        public static string NewName()
        {
            count++;
            return $"Session {count}";
        }
    }
}
