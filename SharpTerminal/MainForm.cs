using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using SharpToolsUI;
using SharpTools;

namespace SharpTerminal
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private readonly ASCIIEncoding ascii = new ASCIIEncoding();
		private readonly SerialSettings serial = new SerialSettings();
		private readonly XmlPersister<PersistedSettings> persister = new XmlPersister<PersistedSettings>();
		private IoManager iom = new NopManager();
		private Readline readline;
		private ThreadRunner ior;
		private ControlRunner uir;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void RefreshSerials()
		{
			var current = comboBoxSerial.Text;
			comboBoxSerial.Items.Clear();
			foreach (var name in SerialPort.GetPortNames())
				comboBoxSerial.Items.Add(name);
			comboBoxSerial.Text = current;
		}
		
		private void EnableControls(bool closed)
		{
			linkLabelSerial.Enabled = closed;
			comboBoxSerial.Enabled = closed;
			buttonOpenSerial.Enabled = closed;
			buttonSetupSerial.Enabled = closed;
			textBoxClientHost.Enabled = closed;
			numericUpDownClientPort.Enabled = closed;
			buttonOpenSocket.Enabled = closed;
			comboBoxServerIP.Enabled = closed;
			numericUpDownServerPort.Enabled = closed;
			buttonListenSocket.Enabled = closed;
			buttonClose.Enabled = !closed;
			buttonSendText.Enabled = !closed;
			buttonSendText1.Enabled = !closed;
			buttonSendText2.Enabled = !closed;
			buttonSendText3.Enabled = !closed;
			buttonSendText4.Enabled = !closed;
			buttonSendHex.Enabled = !closed;
			buttonSendHex1.Enabled = !closed;
			buttonSendHex2.Enabled = !closed;
			buttonSendHex3.Enabled = !closed;
			buttonSendHex4.Enabled = !closed;
		}
		
		private void Log(string type, string format, params object[] args)
		{
			if (args.Length > 0)
				format = string.Format(format, args);
			var color = Color.White;
			switch (type) {
				case "<":
					color = Color.DodgerBlue;
					break;
				case ">":
					color = Color.Salmon;
					break;
				case "success":
					color = Color.LimeGreen;
					break;
				case "error":
					color = Color.OrangeRed;
					break;
				case "warn":
					color = Color.Yellow;
					break;
			}
			richTextBoxLog.SelectionLength = 0; //clear selection
			richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
			richTextBoxLog.SelectionColor = Color.Gray;
			richTextBoxLog.AppendText(DateTime.Now.ToString("HH:mm:ss.fff"));
			richTextBoxLog.SelectionColor = color;
			richTextBoxLog.AppendText(" ");
			richTextBoxLog.AppendText(format);
			richTextBoxLog.AppendText("\n");
			richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
			richTextBoxLog.ScrollToCaret();
		}
		
		private void AppendLineEnding(List<byte> bytes)
		{
			var mode = comboBoxSendMode.Text;
			switch (mode) {
				case "Append CR+NL":
					bytes.Add(0x0D);
					bytes.Add(0x0A);
					break;
				case "Append CR":
					bytes.Add(0x0D);
					break;
				case "Append NL":
					bytes.Add(0x0A);
					break;
			}			
		}
		
		private void Log(char prefix, byte[] bytes)
		{
			var sb = new StringBuilder();
			foreach (var b in bytes) {
				var c = (char)b;
				if (Char.IsControl(c))
					sb.Append(string.Format("[{0:X2}]", (int)c));
				else
					sb.Append(c);
			}	
			sb.Append("\n");
			sb.Append(prefix);
			foreach (var b in bytes) {
				sb.Append(b.ToString("X2"));
				sb.Append(" ");
			}
			Log(prefix.ToString(), sb.ToString());
		}
		
		private string SettingsPath()
		{
			#if DEBUG
			return Exe.Relative(Exe.Filename() + ".xml");
			#else
			var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			var folder = Path.Combine(path, "." + Exe.Filename());
			Directory.CreateDirectory(folder);
			return Path.Combine(folder, "config.xml");
			#endif
		}
		
		private void SaveSettings()
		{
			var config = new PersistedSettings();
			config.Serial = serial;
			config.Name = comboBoxSerial.Text;
			config.ClientHost = textBoxClientHost.Text;
			config.ClientPort = (int)numericUpDownClientPort.Value;
			config.ServerIP = comboBoxServerIP.Text;
			config.ServerPort = (int)numericUpDownServerPort.Value;
			config.Readline = checkBoxReadline.Checked;
			config.ReadMode = comboBoxReadMode.Text;
			config.SendMode = comboBoxSendMode.Text;
			config.Text = textBoxTextInput.Text;
			config.Text1 = textBoxTextInput1.Text;
			config.Text2 = textBoxTextInput2.Text;
			config.Text3 = textBoxTextInput3.Text;
			config.Text4 = textBoxTextInput4.Text;
			config.Hex = textBoxHexInput.Text;
			config.Hex1 = textBoxHexInput1.Text;
			config.Hex2 = textBoxHexInput2.Text;
			config.Hex3 = textBoxHexInput3.Text;
			config.Hex4 = textBoxHexInput4.Text;
			persister.Save(SettingsPath(), config);
		}
		
		private void LoadSettings()
		{
			var config = persister.Load(SettingsPath());
			config.Serial.CopyTo(serial);
			comboBoxSerial.Text = config.Name;
			textBoxClientHost.Text = config.ClientHost;
			numericUpDownClientPort.Value = config.ClientPort;
			comboBoxServerIP.Text = config.ServerIP;
			numericUpDownServerPort.Value = config.ServerPort;
			comboBoxSendMode.Text = config.SendMode;
			comboBoxReadMode.Text = config.ReadMode;
			checkBoxReadline.Checked = config.Readline;
			textBoxTextInput.Text = config.Text;
			textBoxTextInput1.Text = config.Text1;
			textBoxTextInput2.Text = config.Text2;
			textBoxTextInput3.Text = config.Text3;
			textBoxTextInput4.Text = config.Text4;
			textBoxHexInput.Text = config.Hex;
			textBoxHexInput1.Text = config.Hex1;
			textBoxHexInput2.Text = config.Hex2;
			textBoxHexInput3.Text = config.Hex3;
			textBoxHexInput4.Text = config.Hex4;
		}
		
		private void UpdateReadline()
		{
			var enable = checkBoxReadline.Checked && tabControl.SelectedTab != tabPageHex;
			var separator = comboBoxReadMode.SelectedIndex < 1 ? (byte)0x0a : (byte)0x0d;
			ior.Run(() => readline.Setup(enable, separator));
		}
		
		private void Write(byte[] bytes)
		{
			Log('>', bytes);
			ior.Run(() => iom.Write(bytes));
		}
		
		private void IoClose()
		{
			Disposer.Dispose(iom);
			iom = new NopManager();
			uir.Run(() => EnableControls(true));
		}
		
		private void IoException(Exception ex)
		{
			IoClose();
			uir.Run(() => Log("error", "Error: {0}", ex.Message));			
			#if DEBUG
			uir.Run(() => Log("warn", "Error: {0}", ex.ToString()));
			#endif
		}
		
		private void IoIdle()
		{
			iom.Read();
			Thread.Sleep(10);
		}
		
		private void IoMonitor(byte[] bytes)
		{
			uir.Run(() => Log('<', bytes));
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			SaveSettings();
		}
	
		void MainFormLoad(object sender, EventArgs e)
		{
			uir = new ControlRunner(this);
			ior = new ThreadRunner("IO", IoException, IoIdle);
			readline = new Readline(IoMonitor);
			Text = string.Format("{0} - {1} https://github.com/samuelventura/SharpTerminal", Text, Exe.VersionString());
			LoadSettings();
			if (comboBoxReadMode.SelectedIndex < 0) comboBoxReadMode.SelectedIndex = 0;
			if (comboBoxSendMode.SelectedIndex < 0) comboBoxSendMode.SelectedIndex = 0;
			if (comboBoxServerIP.SelectedIndex < 0) comboBoxServerIP.SelectedIndex = 0;
			RefreshSerials();
			EnableControls(true);
			UpdateReadline();
		}
		
		void ButtonOpenSerialClick(object sender, EventArgs e)
		{
			var name = comboBoxSerial.Text;
			EnableControls(false);
			ior.Run(() => {
				iom = new SerialManager(name, serial, readline);
				uir.Run(() => Log("success", "Serial {0}@{1} open", name, serial.BaudRate));		
			});
		}
		
		void ButtonOpenSocketClick(object sender, EventArgs e)
		{
			var host = textBoxClientHost.Text;
			var port = (int)numericUpDownClientPort.Value;
			EnableControls(false);
			ior.Run(() => {
				iom = new SocketManager(host, port, readline);
				uir.Run(() => Log("success", "Socket {0}:{1} open", host, port));
			});			
		}
		
		void ButtonListenSocketClick(object sender, EventArgs e)
		{
			var ip = comboBoxServerIP.Text;
			var port = (int)numericUpDownServerPort.Value;
			EnableControls(false);
			ior.Run(() => {
				iom = new ListenManager(ip, port, readline, ior);
				uir.Run(() => Log("success", "Listener {0}:{1} open", ip, port));
			});		
		}
		
		void ButtonCloseClick(object sender, EventArgs e)
		{
			ior.Run(IoClose);
		}
		
		void LinkLabelSerialLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshSerials();
			comboBoxSerial.DroppedDown = true;
		}
		
		void ButtonSetupSerialClick(object sender, EventArgs e)
		{
			var setup = new SerialSetupForm(serial);
			setup.ShowDialog();
		}
		
		void CheckBoxLinerCheckedChanged(object sender, EventArgs e)
		{
			UpdateReadline();
		}
		
		void ComboBoxReadModeSelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateReadline();
		}
		
		void TabControl1Selected(object sender, TabControlEventArgs e)
		{
			UpdateReadline();
		}
		
		void TextBoxTextInputKeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyData == (Keys.Control | Keys.Enter))) {
				e.SuppressKeyPress = true;
				buttonSendText.PerformClick();
			}
		}

		void ButtonSendTextClick(object sender, EventArgs e)
		{
			foreach (var text in textBoxTextInput.Lines) {
				SendText(text);
			}
		}
		
		private void SendText(string text)
		{
			var bytes = new List<byte>();
			bytes.AddRange(ascii.GetBytes(text));
			AppendLineEnding(bytes);
			Write(bytes.ToArray());
		}
		
		private void SendHex(TextBox textBox)
		{
			var bytes = Hex.Parse(textBox.Text);
			textBox.Text = Hex.ToString(bytes);
			Write(bytes);			
		}
		
		void ButtonSendText1Click(object sender, EventArgs e)
		{
			SendText(textBoxTextInput1.Text);
		}
		
		void ButtonSendText2Click(object sender, EventArgs e)
		{
			SendText(textBoxTextInput2.Text);
		}
		
		void ButtonSendText3Click(object sender, EventArgs e)
		{
			SendText(textBoxTextInput3.Text);
		}
		
		void ButtonSendText4Click(object sender, EventArgs e)
		{
			SendText(textBoxTextInput4.Text);
		}
		
		void ButtonSendHex1Click(object sender, EventArgs e)
		{
			SendHex(textBoxHexInput1);
		}
		
		void ButtonSendHex2Click(object sender, EventArgs e)
		{
			SendHex(textBoxHexInput2);
		}
		
		void ButtonSendHex3Click(object sender, EventArgs e)
		{
			SendHex(textBoxHexInput3);
		}
		
		void ButtonSendHex4Click(object sender, EventArgs e)
		{
			SendHex(textBoxHexInput4);
		}
		
		void ButtonSendHexClick(object sender, EventArgs e)
		{
			SendHex(textBoxHexInput);
		}
		
		void ButtonClearClick(object sender, EventArgs e)
		{
			richTextBoxLog.Clear();
		}
	}
}
