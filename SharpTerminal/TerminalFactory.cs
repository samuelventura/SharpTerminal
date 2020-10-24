﻿using System;
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
        public string Title => "SharpTerminal - 1.0.11 https://github.com/samuelventura/SharpTerminal";
        public string Status => path;
        public Icon Icon => Resource.Icon;

        public TerminalFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public SessionDto[] Load()
        {
            return Load(path);
        }

        public SessionDto[] Load(string path)
        {
            SessionDao.Exec(path, (db) =>
            {
                if (TabsTools.IsDebug())
                {
                    //force migration
                    //db.Engine.UserVersion = 0;
                }
                //migration
                if (db.Engine.UserVersion < 1)
                {
                    var assy = typeof(TerminalDto).Assembly.FullName;
                    var type = typeof(TerminalDto).FullName;
                    db.Engine.Run($"db.sessions.update _type='{type}, {assy}'");
                    db.Engine.UserVersion = 1;
                }
            });
            return SessionDao.Load<TerminalDto>(path);
        }

        public void Unload(Control obj)
        {
            var control = obj as TerminalControl;
            control.Unload();
        }

        public void Save(SessionDto[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, SessionDto[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new TerminalDto
            {
                Name = NewName()
            });
        }

        public SessionDto Unwrap(Control obj)
        {
            var control = obj as TerminalControl;
            var dto = new TerminalDto 
            { 
                Name = control.Text 
            };
            control.FromUI(dto);
            return dto;
        }

        public Control Wrap(SessionDto obj)
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
