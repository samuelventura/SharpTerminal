using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using SharpTerminal.Tools;

namespace SharpTerminal
{
    public partial class TerminalControl : UserControl
    {
        private readonly ASCIIEncoding ascii = new ASCIIEncoding();
        private readonly SerialSettings serial = new SerialSettings();
        private LogViewBuffer buffer = new LogViewBuffer();
        private IoManager iom = new NopManager();
        private ThreadRunner ior;
        private ControlRunner uir;

        public TerminalControl()
        {
            InitializeComponent();

            Link(buttonSendText, textBoxTextInput);
            Link(buttonSendText1, textBoxTextInput1);
            Link(buttonSendText2, textBoxTextInput2);
            Link(buttonSendText3, textBoxTextInput3);
            Link(buttonSendText4, textBoxTextInput4);
            Link(buttonSendText5, textBoxTextInput5);
            Link(buttonSendText6, textBoxTextInput6);
            Link(buttonSendText7, textBoxTextInput7);
            Link(buttonSendText8, textBoxTextInput8);
            Link(buttonSendText9, textBoxTextInput9);
            Link(buttonSendText10, textBoxTextInput10);
            Link(buttonSendText11, textBoxTextInput11);
            Link(buttonSendText12, textBoxTextInput12);
            Link(buttonSendHex, textBoxHexInput);
            Link(buttonSendHex1, textBoxHexInput1);
            Link(buttonSendHex2, textBoxHexInput2);
            Link(buttonSendHex3, textBoxHexInput3);
            Link(buttonSendHex4, textBoxHexInput4);
            Link(buttonSendHex5, textBoxHexInput5);
            Link(buttonSendHex6, textBoxHexInput6);
            Link(buttonSendHex7, textBoxHexInput7);
            Link(buttonSendHex8, textBoxHexInput8);
            Link(buttonSendHex9, textBoxHexInput9);
            Link(buttonSendHex10, textBoxHexInput10);
            Link(buttonSendHex11, textBoxHexInput11);
            Link(buttonSendHex12, textBoxHexInput12);
        }

        public void FromUI(TerminalDto config)
        {
            config.Serial.CopyFrom(serial);
            config.PortName = comboBoxSerial.Text;
            config.ClientHost = textBoxClientHost.Text;
            config.ClientPort = (int)numericUpDownClientPort.Value;
            config.ServerIP = comboBoxServerIP.Text;
            config.ServerPort = (int)numericUpDownServerPort.Value;
            config.Standard = checkBoxStandard.Checked;
            config.Readline = checkBoxReadline.Checked;
            config.ReadMode = comboBoxReadMode.Text;
            config.SendMode = comboBoxSendMode.Text;
            config.Text = textBoxTextInput.Text;
            config.Text1 = textBoxTextInput1.Text;
            config.Text2 = textBoxTextInput2.Text;
            config.Text3 = textBoxTextInput3.Text;
            config.Text4 = textBoxTextInput4.Text;
            config.Text5 = textBoxTextInput5.Text;
            config.Text6 = textBoxTextInput6.Text;
            config.Text7 = textBoxTextInput7.Text;
            config.Text8 = textBoxTextInput8.Text;
            config.Text9 = textBoxTextInput9.Text;
            config.Text10 = textBoxTextInput10.Text;
            config.Text11 = textBoxTextInput11.Text;
            config.Text12 = textBoxTextInput12.Text;
            config.Hex = textBoxHexInput.Text;
            config.Hex1 = textBoxHexInput1.Text;
            config.Hex2 = textBoxHexInput2.Text;
            config.Hex3 = textBoxHexInput3.Text;
            config.Hex4 = textBoxHexInput4.Text;
            config.Hex5 = textBoxHexInput5.Text;
            config.Hex6 = textBoxHexInput6.Text;
            config.Hex7 = textBoxHexInput7.Text;
            config.Hex8 = textBoxHexInput8.Text;
            config.Hex9 = textBoxHexInput9.Text;
            config.Hex10 = textBoxHexInput10.Text;
            config.Hex11 = textBoxHexInput11.Text;
            config.Hex12 = textBoxHexInput12.Text;
        }

        public void ToUI(TerminalDto config)
        {
            config.Serial.CopyTo(serial);
            comboBoxSerial.Text = config.PortName;
            numericUpDownClientPort.Value = config.ClientPort;
            numericUpDownServerPort.Value = config.ServerPort;
            textBoxClientHost.Text = config.ClientHost;
            comboBoxServerIP.Text = config.ServerIP;
            comboBoxSendMode.Text = config.SendMode;
            comboBoxReadMode.Text = config.ReadMode;
            checkBoxReadline.Checked = config.Readline;
            checkBoxStandard.Checked = config.Standard;
            textBoxTextInput.Text = config.Text;
            textBoxTextInput1.Text = config.Text1;
            textBoxTextInput2.Text = config.Text2;
            textBoxTextInput3.Text = config.Text3;
            textBoxTextInput4.Text = config.Text4;
            textBoxTextInput5.Text = config.Text5;
            textBoxTextInput6.Text = config.Text6;
            textBoxTextInput7.Text = config.Text7;
            textBoxTextInput8.Text = config.Text8;
            textBoxTextInput9.Text = config.Text9;
            textBoxTextInput10.Text = config.Text10;
            textBoxTextInput11.Text = config.Text11;
            textBoxTextInput12.Text = config.Text12;
            textBoxHexInput.Text = config.Hex;
            textBoxHexInput1.Text = config.Hex1;
            textBoxHexInput2.Text = config.Hex2;
            textBoxHexInput3.Text = config.Hex3;
            textBoxHexInput4.Text = config.Hex4;
            textBoxHexInput5.Text = config.Hex5;
            textBoxHexInput6.Text = config.Hex6;
            textBoxHexInput7.Text = config.Hex7;
            textBoxHexInput8.Text = config.Hex8;
            textBoxHexInput9.Text = config.Hex9;
            textBoxHexInput10.Text = config.Hex10;
            textBoxHexInput11.Text = config.Hex11;
            textBoxHexInput12.Text = config.Hex12;
        }

        private void Link(Button button, TextBox textBox)
        {
            textBox.Tag = button;
            button.Tag = textBox;
        }

        private void RefreshSerials()
        {
            var current = comboBoxSerial.Text;
            comboBoxSerial.Items.Clear();
            foreach (var name in SerialPort.GetPortNames())
            {
                comboBoxSerial.Items.Add(name);
            }
            comboBoxSerial.Text = current;
        }

        private void EnableControls(bool closed)
        {
            timer.Interval = closed ? 500 : 200;
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
            buttonSendText5.Enabled = !closed;
            buttonSendText6.Enabled = !closed;
            buttonSendText7.Enabled = !closed;
            buttonSendText8.Enabled = !closed;
            buttonSendText9.Enabled = !closed;
            buttonSendText10.Enabled = !closed;
            buttonSendText11.Enabled = !closed;
            buttonSendText12.Enabled = !closed;
            buttonSendHex.Enabled = !closed;
            buttonSendHex1.Enabled = !closed;
            buttonSendHex2.Enabled = !closed;
            buttonSendHex3.Enabled = !closed;
            buttonSendHex4.Enabled = !closed;
            buttonSendHex5.Enabled = !closed;
            buttonSendHex6.Enabled = !closed;
            buttonSendHex7.Enabled = !closed;
            buttonSendHex8.Enabled = !closed;
            buttonSendHex9.Enabled = !closed;
            buttonSendHex10.Enabled = !closed;
            buttonSendHex11.Enabled = !closed;
            buttonSendHex12.Enabled = !closed;
        }

        private void AppendLineEnding(List<byte> bytes)
        {
            var mode = comboBoxSendMode.Text;
            switch (mode)
            {
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

        private void UpdateReadline()
        {
            var standard = checkBoxStandard.Checked;
            var hexmode = tabControl.SelectedTab == tabPageHex;
            var readline = checkBoxReadline.Checked && comboBoxReadMode.SelectedIndex >= 0 && !hexmode;
            var separator = (byte)0x00;
            switch (comboBoxReadMode.Text)
            {
                case "Break on NL":
                    separator = 0x0a;
                    break;
                case "Break on CR":
                    separator = 0x0d;
                    break;
            }
            buffer.Setup(readline, standard, hexmode, separator);
        }

        private void IoClose()
        {
            Disposer.Dispose(iom);
            iom = new NopManager();
            uir.Run(() =>
            {
                buffer.Flush();
                EnableControls(true);
            });
        }

        private void IoException(Exception ex)
        {
            IoClose();
            uir.Run(() => buffer.Log("error", ex.Message));
        }

        private void IoIdle()
        {
            var data = iom.Read();
            while (data != null)
            {
                uir.Run(() => buffer.Input(data));
                data = iom.Read();
            }
            uir.Run(() => buffer.CheckSilence());
        }

        public void Unload()
        {
            ior.Dispose(IoClose, false);
        }

        private void SendText(string text)
        {
            var list = new List<byte>();
            list.AddRange(ascii.GetBytes(text));
            AppendLineEnding(list);
            var bytes = list.ToArray();
            buffer.Output(bytes, true);
            ior.Run(() => iom.Write(bytes));
        }

        private void SendHex(TextBox textBox)
        {
            var bytes = Hexadecimal.Parse(textBox.Text);
            textBox.Text = Hexadecimal.ToString(bytes);
            buffer.Output(bytes, false);
            ior.Run(() => iom.Write(bytes));
        }

        private void TerminalControl_Load(object sender, EventArgs e)
        {
            uir = new ControlRunner(this);
            ior = new ThreadRunner("IO", IoException, IoIdle, 50);
            RefreshSerials();
            EnableControls(true);
            UpdateReadline();
            timer.Enabled = true;
        }

        private void LinkLabelSerial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshSerials();
            comboBoxSerial.DroppedDown = true;
        }

        private void ButtonSetupSerial_Click(object sender, EventArgs e)
        {
            var setup = new SerialSettingsForm(serial);
            setup.ShowDialog();
        }

        private void ButtonOpenSerial_Click(object sender, EventArgs e)
        {
            var name = comboBoxSerial.Text;
            EnableControls(false);
            ior.Run(() =>
            {
                iom = new SerialManager(name, serial);
                uir.Run(() => buffer.Log("success", "Serial {0} open", iom.Name));
            });
        }

        private void ButtonOpenSocket_Click(object sender, EventArgs e)
        {
            var host = textBoxClientHost.Text;
            var port = (int)numericUpDownClientPort.Value;
            EnableControls(false);
            ior.Run(() =>
            {
                iom = new SocketManager(host, port);
                uir.Run(() => buffer.Log("success", "Socket {0} open", iom.Name));
            });
        }

        private void ButtonListenSocket_Click(object sender, EventArgs e)
        {
            var ip = comboBoxServerIP.Text;
            var port = (int)numericUpDownServerPort.Value;
            EnableControls(false);
            ior.Run(() =>
            {
                iom = new ListenManager(ip, port, ior);
                uir.Run(() => buffer.Log("success", "Listener {0} open", iom.Name));
            });
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            ior.Run(IoClose);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            logView.Clear();
        }

        private void ButtonSendText_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var textbox = (TextBox)button.Tag;
            SendText(textbox.Text);
        }

        private void ButtonSendLines_Click(object sender, EventArgs e)
        {
            foreach (var text in textBoxTextInput.Lines)
            {
                SendText(text);
            }
        }

        private void ButtonSendHex_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var textbox = (TextBox)button.Tag;
            SendHex(textbox);
        }

        private void TextBoxAllInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var textbox = (TextBox)sender;
                var button = (Button)textbox.Tag;
                button.PerformClick();
            }
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == (Keys.Control | Keys.Enter)))
            {
                e.SuppressKeyPress = true;
                var textbox = (TextBox)sender;
                var button = (Button)textbox.Tag;
                button.PerformClick();
            }
        }

        private void CheckBoxReadline_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReadline();
        }

        private void CheckBoxStandard_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReadline();
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            UpdateReadline();
        }

        private void ComboBoxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReadline();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            buffer.Update(logView);
        }
    }
}
