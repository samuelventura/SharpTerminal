
namespace SharpTerminal
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonOpenSerial;
		private System.Windows.Forms.ComboBox comboBoxSerial;
		private System.Windows.Forms.LinkLabel linkLabelSerial;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSetupSerial;
		private System.Windows.Forms.Button buttonOpenSocket;
		private System.Windows.Forms.NumericUpDown numericUpDownClientPort;
		private System.Windows.Forms.Label labelPort;
		private System.Windows.Forms.TextBox textBoxClientHost;
		private System.Windows.Forms.Label labelHost;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button buttonSendText;
		private System.Windows.Forms.ComboBox comboBoxSendMode;
		private System.Windows.Forms.TextBox textBoxTextInput;
		private System.Windows.Forms.CheckBox checkBoxReadline;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.TextBox textBoxTextInput1;
		private System.Windows.Forms.Button buttonSendText1;
		private System.Windows.Forms.TextBox textBoxTextInput4;
		private System.Windows.Forms.TextBox textBoxTextInput2;
		private System.Windows.Forms.Button buttonSendText2;
		private System.Windows.Forms.Button buttonSendText4;
		private System.Windows.Forms.Button buttonSendText3;
		private System.Windows.Forms.TextBox textBoxTextInput3;
		private System.Windows.Forms.ComboBox comboBoxServerIP;
		private System.Windows.Forms.Button buttonListenSocket;
		private System.Windows.Forms.NumericUpDown numericUpDownServerPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.ComboBox comboBoxReadMode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageText;
		private System.Windows.Forms.TabPage tabPageHex;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button buttonSendHex3;
		private System.Windows.Forms.Button buttonSendHex4;
		private System.Windows.Forms.TextBox textBoxHexInput1;
		private System.Windows.Forms.TextBox textBoxHexInput4;
		private System.Windows.Forms.TextBox textBoxHexInput2;
		private System.Windows.Forms.Button buttonSendHex1;
		private System.Windows.Forms.TextBox textBoxHexInput3;
		private System.Windows.Forms.Button buttonSendHex2;
		private System.Windows.Forms.Button buttonSendHex;
		private System.Windows.Forms.TextBox textBoxHexInput;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.checkBoxReadline = new System.Windows.Forms.CheckBox();
			this.buttonSendText = new System.Windows.Forms.Button();
			this.textBoxTextInput = new System.Windows.Forms.TextBox();
			this.buttonListenSocket = new System.Windows.Forms.Button();
			this.linkLabelSerial = new System.Windows.Forms.LinkLabel();
			this.buttonSetupSerial = new System.Windows.Forms.Button();
			this.buttonOpenSocket = new System.Windows.Forms.Button();
			this.buttonOpenSerial = new System.Windows.Forms.Button();
			this.buttonSendHex = new System.Windows.Forms.Button();
			this.textBoxHexInput = new System.Windows.Forms.TextBox();
			this.buttonClear = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.comboBoxReadMode = new System.Windows.Forms.ComboBox();
			this.comboBoxSendMode = new System.Windows.Forms.ComboBox();
			this.buttonSendText1 = new System.Windows.Forms.Button();
			this.buttonSendText2 = new System.Windows.Forms.Button();
			this.buttonSendText3 = new System.Windows.Forms.Button();
			this.buttonSendText4 = new System.Windows.Forms.Button();
			this.buttonSendHex3 = new System.Windows.Forms.Button();
			this.buttonSendHex4 = new System.Windows.Forms.Button();
			this.buttonSendHex1 = new System.Windows.Forms.Button();
			this.buttonSendHex2 = new System.Windows.Forms.Button();
			this.textBoxTextInput1 = new System.Windows.Forms.TextBox();
			this.textBoxTextInput4 = new System.Windows.Forms.TextBox();
			this.textBoxTextInput2 = new System.Windows.Forms.TextBox();
			this.textBoxTextInput3 = new System.Windows.Forms.TextBox();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxServerIP = new System.Windows.Forms.ComboBox();
			this.textBoxClientHost = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.labelHost = new System.Windows.Forms.Label();
			this.numericUpDownServerPort = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxSerial = new System.Windows.Forms.ComboBox();
			this.labelPort = new System.Windows.Forms.Label();
			this.numericUpDownClientPort = new System.Windows.Forms.NumericUpDown();
			this.panelRight = new System.Windows.Forms.Panel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageText = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tabPageHex = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxHexInput1 = new System.Windows.Forms.TextBox();
			this.textBoxHexInput4 = new System.Windows.Forms.TextBox();
			this.textBoxHexInput2 = new System.Windows.Forms.TextBox();
			this.textBoxHexInput3 = new System.Windows.Forms.TextBox();
			this.panelLeft.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownServerPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownClientPort)).BeginInit();
			this.panelRight.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageText.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tabPageHex.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBoxReadline
			// 
			this.checkBoxReadline.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.checkBoxReadline.AutoSize = true;
			this.checkBoxReadline.Checked = true;
			this.checkBoxReadline.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxReadline.Location = new System.Drawing.Point(220, 4);
			this.checkBoxReadline.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxReadline.Name = "checkBoxReadline";
			this.checkBoxReadline.Size = new System.Drawing.Size(68, 17);
			this.checkBoxReadline.TabIndex = 7;
			this.checkBoxReadline.Text = "Readline";
			this.toolTip.SetToolTip(this.checkBoxReadline, "Wait for line separator on input");
			this.checkBoxReadline.UseVisualStyleBackColor = true;
			this.checkBoxReadline.CheckedChanged += new System.EventHandler(this.CheckBoxLinerCheckedChanged);
			// 
			// buttonSendText
			// 
			this.buttonSendText.Location = new System.Drawing.Point(220, 147);
			this.buttonSendText.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendText.Name = "buttonSendText";
			this.buttonSendText.Size = new System.Drawing.Size(56, 26);
			this.buttonSendText.TabIndex = 6;
			this.buttonSendText.Text = "Send";
			this.toolTip.SetToolTip(this.buttonSendText, "Send multiline text below");
			this.buttonSendText.UseVisualStyleBackColor = true;
			this.buttonSendText.Click += new System.EventHandler(this.ButtonSendTextClick);
			// 
			// textBoxTextInput
			// 
			this.textBoxTextInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxTextInput.Location = new System.Drawing.Point(3, 178);
			this.textBoxTextInput.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxTextInput.Multiline = true;
			this.textBoxTextInput.Name = "textBoxTextInput";
			this.textBoxTextInput.Size = new System.Drawing.Size(281, 262);
			this.textBoxTextInput.TabIndex = 19;
			this.toolTip.SetToolTip(this.textBoxTextInput, "Ctrl+Enter to send");
			this.textBoxTextInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxTextInputKeyDown);
			// 
			// buttonListenSocket
			// 
			this.buttonListenSocket.Location = new System.Drawing.Point(252, 63);
			this.buttonListenSocket.Margin = new System.Windows.Forms.Padding(2);
			this.buttonListenSocket.Name = "buttonListenSocket";
			this.buttonListenSocket.Size = new System.Drawing.Size(65, 26);
			this.buttonListenSocket.TabIndex = 14;
			this.buttonListenSocket.Text = "Listen";
			this.toolTip.SetToolTip(this.buttonListenSocket, "Open socket listener");
			this.buttonListenSocket.UseVisualStyleBackColor = true;
			this.buttonListenSocket.Click += new System.EventHandler(this.ButtonListenSocketClick);
			// 
			// linkLabelSerial
			// 
			this.linkLabelSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelSerial.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.linkLabelSerial, 2);
			this.linkLabelSerial.Location = new System.Drawing.Point(2, 8);
			this.linkLabelSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelSerial.Name = "linkLabelSerial";
			this.linkLabelSerial.Size = new System.Drawing.Size(60, 13);
			this.linkLabelSerial.TabIndex = 0;
			this.linkLabelSerial.TabStop = true;
			this.linkLabelSerial.Text = "Serial Ports";
			this.toolTip.SetToolTip(this.linkLabelSerial, "Refresh Serial Ports");
			this.linkLabelSerial.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSerialLinkClicked);
			// 
			// buttonSetupSerial
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.buttonSetupSerial, 2);
			this.buttonSetupSerial.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSetupSerial.Location = new System.Drawing.Point(161, 2);
			this.buttonSetupSerial.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSetupSerial.Name = "buttonSetupSerial";
			this.buttonSetupSerial.Size = new System.Drawing.Size(87, 26);
			this.buttonSetupSerial.TabIndex = 8;
			this.buttonSetupSerial.Text = "Setup";
			this.toolTip.SetToolTip(this.buttonSetupSerial, "Setup Serial Port");
			this.buttonSetupSerial.UseVisualStyleBackColor = true;
			this.buttonSetupSerial.Click += new System.EventHandler(this.ButtonSetupSerialClick);
			// 
			// buttonOpenSocket
			// 
			this.buttonOpenSocket.Location = new System.Drawing.Point(252, 32);
			this.buttonOpenSocket.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOpenSocket.Name = "buttonOpenSocket";
			this.buttonOpenSocket.Size = new System.Drawing.Size(65, 26);
			this.buttonOpenSocket.TabIndex = 7;
			this.buttonOpenSocket.Text = "Connect";
			this.toolTip.SetToolTip(this.buttonOpenSocket, "Open socket connection");
			this.buttonOpenSocket.UseVisualStyleBackColor = true;
			this.buttonOpenSocket.Click += new System.EventHandler(this.ButtonOpenSocketClick);
			// 
			// buttonOpenSerial
			// 
			this.buttonOpenSerial.Location = new System.Drawing.Point(252, 2);
			this.buttonOpenSerial.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOpenSerial.Name = "buttonOpenSerial";
			this.buttonOpenSerial.Size = new System.Drawing.Size(65, 26);
			this.buttonOpenSerial.TabIndex = 2;
			this.buttonOpenSerial.Text = "Open";
			this.toolTip.SetToolTip(this.buttonOpenSerial, "Open Serial Port");
			this.buttonOpenSerial.UseVisualStyleBackColor = true;
			this.buttonOpenSerial.Click += new System.EventHandler(this.ButtonOpenSerialClick);
			// 
			// buttonSendHex
			// 
			this.tableLayoutPanel3.SetColumnSpan(this.buttonSendHex, 2);
			this.buttonSendHex.Location = new System.Drawing.Point(2, 122);
			this.buttonSendHex.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendHex.Name = "buttonSendHex";
			this.buttonSendHex.Size = new System.Drawing.Size(275, 26);
			this.buttonSendHex.TabIndex = 6;
			this.buttonSendHex.Text = "Send";
			this.toolTip.SetToolTip(this.buttonSendHex, "Send HEX below");
			this.buttonSendHex.UseVisualStyleBackColor = true;
			this.buttonSendHex.Click += new System.EventHandler(this.ButtonSendHexClick);
			// 
			// textBoxHexInput
			// 
			this.textBoxHexInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxHexInput.Location = new System.Drawing.Point(3, 153);
			this.textBoxHexInput.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHexInput.Multiline = true;
			this.textBoxHexInput.Name = "textBoxHexInput";
			this.textBoxHexInput.Size = new System.Drawing.Size(281, 287);
			this.textBoxHexInput.TabIndex = 20;
			this.toolTip.SetToolTip(this.textBoxHexInput, "Ctrl+Enter to send");
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(321, 63);
			this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(65, 26);
			this.buttonClear.TabIndex = 16;
			this.buttonClear.Text = "Clear";
			this.toolTip.SetToolTip(this.buttonClear, "Clear log");
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(321, 2);
			this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
			this.buttonClose.Name = "buttonClose";
			this.tableLayoutPanel1.SetRowSpan(this.buttonClose, 2);
			this.buttonClose.Size = new System.Drawing.Size(65, 57);
			this.buttonClose.TabIndex = 9;
			this.buttonClose.Text = "Close";
			this.toolTip.SetToolTip(this.buttonClose, "Close current channel");
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// comboBoxReadMode
			// 
			this.comboBoxReadMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.comboBoxReadMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxReadMode.FormattingEnabled = true;
			this.comboBoxReadMode.Items.AddRange(new object[] {
			"Break on NL",
			"Break on CR"});
			this.comboBoxReadMode.Location = new System.Drawing.Point(2, 2);
			this.comboBoxReadMode.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxReadMode.Name = "comboBoxReadMode";
			this.comboBoxReadMode.Size = new System.Drawing.Size(214, 21);
			this.comboBoxReadMode.TabIndex = 17;
			this.toolTip.SetToolTip(this.comboBoxReadMode, "Select line separator");
			this.comboBoxReadMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReadModeSelectedIndexChanged);
			// 
			// comboBoxSendMode
			// 
			this.comboBoxSendMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.comboBoxSendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSendMode.FormattingEnabled = true;
			this.comboBoxSendMode.Items.AddRange(new object[] {
			"Append CR+NL",
			"Append CR",
			"Append NL",
			"Append Nothing"});
			this.comboBoxSendMode.Location = new System.Drawing.Point(2, 149);
			this.comboBoxSendMode.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxSendMode.Name = "comboBoxSendMode";
			this.comboBoxSendMode.Size = new System.Drawing.Size(214, 21);
			this.comboBoxSendMode.TabIndex = 5;
			this.toolTip.SetToolTip(this.comboBoxSendMode, "Select line terminator to append to output");
			// 
			// buttonSendText1
			// 
			this.buttonSendText1.Location = new System.Drawing.Point(220, 27);
			this.buttonSendText1.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendText1.Name = "buttonSendText1";
			this.buttonSendText1.Size = new System.Drawing.Size(56, 26);
			this.buttonSendText1.TabIndex = 7;
			this.buttonSendText1.Text = "Send";
			this.buttonSendText1.UseVisualStyleBackColor = true;
			this.buttonSendText1.Click += new System.EventHandler(this.ButtonSendText1Click);
			// 
			// buttonSendText2
			// 
			this.buttonSendText2.Location = new System.Drawing.Point(220, 57);
			this.buttonSendText2.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendText2.Name = "buttonSendText2";
			this.buttonSendText2.Size = new System.Drawing.Size(56, 26);
			this.buttonSendText2.TabIndex = 12;
			this.buttonSendText2.Text = "Send";
			this.buttonSendText2.UseVisualStyleBackColor = true;
			this.buttonSendText2.Click += new System.EventHandler(this.ButtonSendText2Click);
			// 
			// buttonSendText3
			// 
			this.buttonSendText3.Location = new System.Drawing.Point(220, 87);
			this.buttonSendText3.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendText3.Name = "buttonSendText3";
			this.buttonSendText3.Size = new System.Drawing.Size(56, 26);
			this.buttonSendText3.TabIndex = 13;
			this.buttonSendText3.Text = "Send";
			this.buttonSendText3.UseVisualStyleBackColor = true;
			this.buttonSendText3.Click += new System.EventHandler(this.ButtonSendText3Click);
			// 
			// buttonSendText4
			// 
			this.buttonSendText4.Location = new System.Drawing.Point(220, 117);
			this.buttonSendText4.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendText4.Name = "buttonSendText4";
			this.buttonSendText4.Size = new System.Drawing.Size(56, 26);
			this.buttonSendText4.TabIndex = 15;
			this.buttonSendText4.Text = "Send";
			this.buttonSendText4.UseVisualStyleBackColor = true;
			this.buttonSendText4.Click += new System.EventHandler(this.ButtonSendText4Click);
			// 
			// buttonSendHex3
			// 
			this.buttonSendHex3.Location = new System.Drawing.Point(220, 62);
			this.buttonSendHex3.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendHex3.Name = "buttonSendHex3";
			this.buttonSendHex3.Size = new System.Drawing.Size(57, 26);
			this.buttonSendHex3.TabIndex = 13;
			this.buttonSendHex3.Text = "Send";
			this.buttonSendHex3.UseVisualStyleBackColor = true;
			this.buttonSendHex3.Click += new System.EventHandler(this.ButtonSendHex3Click);
			// 
			// buttonSendHex4
			// 
			this.buttonSendHex4.Location = new System.Drawing.Point(220, 92);
			this.buttonSendHex4.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendHex4.Name = "buttonSendHex4";
			this.buttonSendHex4.Size = new System.Drawing.Size(57, 26);
			this.buttonSendHex4.TabIndex = 15;
			this.buttonSendHex4.Text = "Send";
			this.buttonSendHex4.UseVisualStyleBackColor = true;
			this.buttonSendHex4.Click += new System.EventHandler(this.ButtonSendHex4Click);
			// 
			// buttonSendHex1
			// 
			this.buttonSendHex1.Location = new System.Drawing.Point(220, 2);
			this.buttonSendHex1.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendHex1.Name = "buttonSendHex1";
			this.buttonSendHex1.Size = new System.Drawing.Size(57, 26);
			this.buttonSendHex1.TabIndex = 7;
			this.buttonSendHex1.Text = "Send";
			this.buttonSendHex1.UseVisualStyleBackColor = true;
			this.buttonSendHex1.Click += new System.EventHandler(this.ButtonSendHex1Click);
			// 
			// buttonSendHex2
			// 
			this.buttonSendHex2.Location = new System.Drawing.Point(220, 32);
			this.buttonSendHex2.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSendHex2.Name = "buttonSendHex2";
			this.buttonSendHex2.Size = new System.Drawing.Size(57, 26);
			this.buttonSendHex2.TabIndex = 12;
			this.buttonSendHex2.Text = "Send";
			this.buttonSendHex2.UseVisualStyleBackColor = true;
			this.buttonSendHex2.Click += new System.EventHandler(this.ButtonSendHex2Click);
			// 
			// textBoxTextInput1
			// 
			this.textBoxTextInput1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTextInput1.Location = new System.Drawing.Point(2, 30);
			this.textBoxTextInput1.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxTextInput1.Name = "textBoxTextInput1";
			this.textBoxTextInput1.Size = new System.Drawing.Size(214, 20);
			this.textBoxTextInput1.TabIndex = 10;
			// 
			// textBoxTextInput4
			// 
			this.textBoxTextInput4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTextInput4.Location = new System.Drawing.Point(2, 120);
			this.textBoxTextInput4.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxTextInput4.Name = "textBoxTextInput4";
			this.textBoxTextInput4.Size = new System.Drawing.Size(214, 20);
			this.textBoxTextInput4.TabIndex = 16;
			// 
			// textBoxTextInput2
			// 
			this.textBoxTextInput2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTextInput2.Location = new System.Drawing.Point(2, 60);
			this.textBoxTextInput2.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxTextInput2.Name = "textBoxTextInput2";
			this.textBoxTextInput2.Size = new System.Drawing.Size(214, 20);
			this.textBoxTextInput2.TabIndex = 11;
			// 
			// textBoxTextInput3
			// 
			this.textBoxTextInput3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTextInput3.Location = new System.Drawing.Point(2, 90);
			this.textBoxTextInput3.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxTextInput3.Name = "textBoxTextInput3";
			this.textBoxTextInput3.Size = new System.Drawing.Size(214, 20);
			this.textBoxTextInput3.TabIndex = 14;
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.richTextBoxLog);
			this.panelLeft.Controls.Add(this.tableLayoutPanel1);
			this.panelLeft.Controls.Add(this.panelRight);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(698, 469);
			this.panelLeft.TabIndex = 6;
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
			this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
			this.richTextBoxLog.Location = new System.Drawing.Point(0, 91);
			this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(2);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ReadOnly = true;
			this.richTextBoxLog.Size = new System.Drawing.Size(403, 378);
			this.richTextBoxLog.TabIndex = 9;
			this.richTextBoxLog.Text = "";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.comboBoxServerIP, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.buttonClear, 6, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxClientHost, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelHost, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownServerPort, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.buttonListenSocket, 5, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelSerial, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxSerial, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelPort, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownClientPort, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonSetupSerial, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonClose, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonOpenSocket, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonOpenSerial, 5, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 91);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// comboBoxServerIP
			// 
			this.comboBoxServerIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanel1.SetColumnSpan(this.comboBoxServerIP, 2);
			this.comboBoxServerIP.FormattingEnabled = true;
			this.comboBoxServerIP.Items.AddRange(new object[] {
			"127.0.0.1",
			"0.0.0.0"});
			this.comboBoxServerIP.Location = new System.Drawing.Point(35, 65);
			this.comboBoxServerIP.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxServerIP.Name = "comboBoxServerIP";
			this.comboBoxServerIP.Size = new System.Drawing.Size(122, 21);
			this.comboBoxServerIP.TabIndex = 15;
			// 
			// textBoxClientHost
			// 
			this.textBoxClientHost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxClientHost, 2);
			this.textBoxClientHost.Location = new System.Drawing.Point(35, 35);
			this.textBoxClientHost.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxClientHost.Name = "textBoxClientHost";
			this.textBoxClientHost.Size = new System.Drawing.Size(122, 20);
			this.textBoxClientHost.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 69);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "IP";
			// 
			// labelHost
			// 
			this.labelHost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelHost.AutoSize = true;
			this.labelHost.Location = new System.Drawing.Point(2, 39);
			this.labelHost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHost.Name = "labelHost";
			this.labelHost.Size = new System.Drawing.Size(29, 13);
			this.labelHost.TabIndex = 3;
			this.labelHost.Text = "Host";
			// 
			// numericUpDownServerPort
			// 
			this.numericUpDownServerPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.numericUpDownServerPort.Location = new System.Drawing.Point(191, 66);
			this.numericUpDownServerPort.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownServerPort.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.numericUpDownServerPort.Name = "numericUpDownServerPort";
			this.numericUpDownServerPort.Size = new System.Drawing.Size(57, 20);
			this.numericUpDownServerPort.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(161, 69);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Port";
			// 
			// comboBoxSerial
			// 
			this.comboBoxSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.comboBoxSerial.FormattingEnabled = true;
			this.comboBoxSerial.Location = new System.Drawing.Point(67, 4);
			this.comboBoxSerial.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxSerial.Name = "comboBoxSerial";
			this.comboBoxSerial.Size = new System.Drawing.Size(90, 21);
			this.comboBoxSerial.TabIndex = 1;
			// 
			// labelPort
			// 
			this.labelPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelPort.AutoSize = true;
			this.labelPort.Location = new System.Drawing.Point(161, 39);
			this.labelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(26, 13);
			this.labelPort.TabIndex = 5;
			this.labelPort.Text = "Port";
			// 
			// numericUpDownClientPort
			// 
			this.numericUpDownClientPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.numericUpDownClientPort.Location = new System.Drawing.Point(191, 35);
			this.numericUpDownClientPort.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownClientPort.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.numericUpDownClientPort.Name = "numericUpDownClientPort";
			this.numericUpDownClientPort.Size = new System.Drawing.Size(57, 20);
			this.numericUpDownClientPort.TabIndex = 6;
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.tabControl);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelRight.Location = new System.Drawing.Point(403, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(295, 469);
			this.panelRight.TabIndex = 7;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageText);
			this.tabControl.Controls.Add(this.tabPageHex);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(295, 469);
			this.tabControl.TabIndex = 10;
			this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1Selected);
			// 
			// tabPageText
			// 
			this.tabPageText.Controls.Add(this.textBoxTextInput);
			this.tabPageText.Controls.Add(this.tableLayoutPanel2);
			this.tabPageText.Location = new System.Drawing.Point(4, 22);
			this.tabPageText.Name = "tabPageText";
			this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageText.Size = new System.Drawing.Size(287, 443);
			this.tabPageText.TabIndex = 0;
			this.tabPageText.Text = "Text";
			this.tabPageText.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.buttonSendText3, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.buttonSendText4, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.buttonSendText, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.textBoxTextInput1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.comboBoxSendMode, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.textBoxTextInput4, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.textBoxTextInput2, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.buttonSendText1, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.textBoxTextInput3, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.buttonSendText2, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.checkBoxReadline, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.comboBoxReadMode, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(281, 175);
			this.tableLayoutPanel2.TabIndex = 7;
			// 
			// tabPageHex
			// 
			this.tabPageHex.Controls.Add(this.textBoxHexInput);
			this.tabPageHex.Controls.Add(this.tableLayoutPanel3);
			this.tabPageHex.Location = new System.Drawing.Point(4, 22);
			this.tabPageHex.Name = "tabPageHex";
			this.tabPageHex.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHex.Size = new System.Drawing.Size(287, 443);
			this.tabPageHex.TabIndex = 1;
			this.tabPageHex.Text = "HEX";
			this.tabPageHex.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.buttonSendHex3, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.buttonSendHex4, 1, 3);
			this.tableLayoutPanel3.Controls.Add(this.textBoxHexInput1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.textBoxHexInput4, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.textBoxHexInput2, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.buttonSendHex1, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.textBoxHexInput3, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.buttonSendHex2, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.buttonSendHex, 0, 4);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 5;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(281, 150);
			this.tableLayoutPanel3.TabIndex = 8;
			// 
			// textBoxHexInput1
			// 
			this.textBoxHexInput1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxHexInput1.Location = new System.Drawing.Point(2, 5);
			this.textBoxHexInput1.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHexInput1.Name = "textBoxHexInput1";
			this.textBoxHexInput1.Size = new System.Drawing.Size(214, 20);
			this.textBoxHexInput1.TabIndex = 10;
			// 
			// textBoxHexInput4
			// 
			this.textBoxHexInput4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxHexInput4.Location = new System.Drawing.Point(2, 95);
			this.textBoxHexInput4.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHexInput4.Name = "textBoxHexInput4";
			this.textBoxHexInput4.Size = new System.Drawing.Size(214, 20);
			this.textBoxHexInput4.TabIndex = 16;
			// 
			// textBoxHexInput2
			// 
			this.textBoxHexInput2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxHexInput2.Location = new System.Drawing.Point(2, 35);
			this.textBoxHexInput2.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHexInput2.Name = "textBoxHexInput2";
			this.textBoxHexInput2.Size = new System.Drawing.Size(214, 20);
			this.textBoxHexInput2.TabIndex = 11;
			// 
			// textBoxHexInput3
			// 
			this.textBoxHexInput3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxHexInput3.Location = new System.Drawing.Point(2, 65);
			this.textBoxHexInput3.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHexInput3.Name = "textBoxHexInput3";
			this.textBoxHexInput3.Size = new System.Drawing.Size(214, 20);
			this.textBoxHexInput3.TabIndex = 14;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 469);
			this.Controls.Add(this.panelLeft);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimumSize = new System.Drawing.Size(714, 308);
			this.Name = "MainForm";
			this.Text = "SharpTerminal";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownServerPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownClientPort)).EndInit();
			this.panelRight.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPageText.ResumeLayout(false);
			this.tabPageText.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tabPageHex.ResumeLayout(false);
			this.tabPageHex.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
