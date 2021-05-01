namespace DTM_Convertor
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Channels");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl_Config = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxStopBits = new System.Windows.Forms.GroupBox();
            this.radioButtonStopBit2 = new System.Windows.Forms.RadioButton();
            this.radioButtonStopBit1 = new System.Windows.Forms.RadioButton();
            this.groupBoxDataBits = new System.Windows.Forms.GroupBox();
            this.radioButtonDataBits8 = new System.Windows.Forms.RadioButton();
            this.radioButtonDataBits7 = new System.Windows.Forms.RadioButton();
            this.groupBoxParity = new System.Windows.Forms.GroupBox();
            this.radioButtonParityOdd = new System.Windows.Forms.RadioButton();
            this.radioButtonParityEven = new System.Windows.Forms.RadioButton();
            this.radioButtonParityNone = new System.Windows.Forms.RadioButton();
            this.button_Add = new System.Windows.Forms.Button();
            this.textBox_COM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_BaudeRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TimeSend = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_TimeLine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TimeOut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView_Channels = new System.Windows.Forms.DataGridView();
            this.Channel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_Devices = new System.Windows.Forms.DataGridView();
            this.Devices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl_Config.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxStopBits.SuspendLayout();
            this.groupBoxDataBits.SuspendLayout();
            this.groupBoxParity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Channels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Devices)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 28);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.добавитьToolStripMenuItem.Text = "Add Channel";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.Location = new System.Drawing.Point(35, 31);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.ContextMenuStrip = this.contextMenuStrip1;
            treeNode1.Name = "Узел1";
            treeNode1.NodeFont = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode1.Text = "Channels";
            treeNode1.ToolTipText = "Каналы";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(122, 382);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl_Config
            // 
            this.tabControl_Config.Controls.Add(this.tabPage1);
            this.tabControl_Config.Controls.Add(this.tabPage2);
            this.tabControl_Config.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl_Config.Location = new System.Drawing.Point(583, 31);
            this.tabControl_Config.Name = "tabControl_Config";
            this.tabControl_Config.SelectedIndex = 0;
            this.tabControl_Config.Size = new System.Drawing.Size(397, 382);
            this.tabControl_Config.TabIndex = 1;
            this.tabControl_Config.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.groupBoxStopBits);
            this.tabPage1.Controls.Add(this.groupBoxDataBits);
            this.tabPage1.Controls.Add(this.groupBoxParity);
            this.tabPage1.Controls.Add(this.button_Add);
            this.tabPage1.Controls.Add(this.textBox_COM);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox_BaudeRate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox_TimeSend);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox_TimeLine);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_TimeOut);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_Name);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(389, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Channel config";
            // 
            // groupBoxStopBits
            // 
            this.groupBoxStopBits.Controls.Add(this.radioButtonStopBit2);
            this.groupBoxStopBits.Controls.Add(this.radioButtonStopBit1);
            this.groupBoxStopBits.Location = new System.Drawing.Point(146, 199);
            this.groupBoxStopBits.Name = "groupBoxStopBits";
            this.groupBoxStopBits.Size = new System.Drawing.Size(116, 103);
            this.groupBoxStopBits.TabIndex = 23;
            this.groupBoxStopBits.TabStop = false;
            this.groupBoxStopBits.Text = "Stop Bits";
            // 
            // radioButtonStopBit2
            // 
            this.radioButtonStopBit2.AutoSize = true;
            this.radioButtonStopBit2.Location = new System.Drawing.Point(15, 61);
            this.radioButtonStopBit2.Name = "radioButtonStopBit2";
            this.radioButtonStopBit2.Size = new System.Drawing.Size(81, 23);
            this.radioButtonStopBit2.TabIndex = 1;
            this.radioButtonStopBit2.Text = "2 bits";
            this.radioButtonStopBit2.UseVisualStyleBackColor = true;
            // 
            // radioButtonStopBit1
            // 
            this.radioButtonStopBit1.AutoSize = true;
            this.radioButtonStopBit1.Checked = true;
            this.radioButtonStopBit1.Location = new System.Drawing.Point(15, 29);
            this.radioButtonStopBit1.Name = "radioButtonStopBit1";
            this.radioButtonStopBit1.Size = new System.Drawing.Size(72, 23);
            this.radioButtonStopBit1.TabIndex = 0;
            this.radioButtonStopBit1.TabStop = true;
            this.radioButtonStopBit1.Text = "1 bit";
            this.radioButtonStopBit1.UseVisualStyleBackColor = true;
            // 
            // groupBoxDataBits
            // 
            this.groupBoxDataBits.Controls.Add(this.radioButtonDataBits8);
            this.groupBoxDataBits.Controls.Add(this.radioButtonDataBits7);
            this.groupBoxDataBits.Location = new System.Drawing.Point(268, 199);
            this.groupBoxDataBits.Name = "groupBoxDataBits";
            this.groupBoxDataBits.Size = new System.Drawing.Size(105, 103);
            this.groupBoxDataBits.TabIndex = 22;
            this.groupBoxDataBits.TabStop = false;
            this.groupBoxDataBits.Text = "Data Bits";
            // 
            // radioButtonDataBits8
            // 
            this.radioButtonDataBits8.AutoSize = true;
            this.radioButtonDataBits8.Checked = true;
            this.radioButtonDataBits8.Location = new System.Drawing.Point(15, 61);
            this.radioButtonDataBits8.Name = "radioButtonDataBits8";
            this.radioButtonDataBits8.Size = new System.Drawing.Size(81, 23);
            this.radioButtonDataBits8.TabIndex = 1;
            this.radioButtonDataBits8.TabStop = true;
            this.radioButtonDataBits8.Text = "8 bits";
            this.radioButtonDataBits8.UseVisualStyleBackColor = true;
            // 
            // radioButtonDataBits7
            // 
            this.radioButtonDataBits7.AutoSize = true;
            this.radioButtonDataBits7.Location = new System.Drawing.Point(15, 29);
            this.radioButtonDataBits7.Name = "radioButtonDataBits7";
            this.radioButtonDataBits7.Size = new System.Drawing.Size(81, 23);
            this.radioButtonDataBits7.TabIndex = 0;
            this.radioButtonDataBits7.Text = "7 bits";
            this.radioButtonDataBits7.UseVisualStyleBackColor = true;
            // 
            // groupBoxParity
            // 
            this.groupBoxParity.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBoxParity.Controls.Add(this.radioButtonParityOdd);
            this.groupBoxParity.Controls.Add(this.radioButtonParityEven);
            this.groupBoxParity.Controls.Add(this.radioButtonParityNone);
            this.groupBoxParity.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxParity.Location = new System.Drawing.Point(35, 199);
            this.groupBoxParity.Name = "groupBoxParity";
            this.groupBoxParity.Size = new System.Drawing.Size(105, 103);
            this.groupBoxParity.TabIndex = 21;
            this.groupBoxParity.TabStop = false;
            this.groupBoxParity.Text = "Parity";
            // 
            // radioButtonParityOdd
            // 
            this.radioButtonParityOdd.AutoSize = true;
            this.radioButtonParityOdd.Location = new System.Drawing.Point(15, 47);
            this.radioButtonParityOdd.Name = "radioButtonParityOdd";
            this.radioButtonParityOdd.Size = new System.Drawing.Size(54, 23);
            this.radioButtonParityOdd.TabIndex = 2;
            this.radioButtonParityOdd.Text = "Odd";
            this.radioButtonParityOdd.UseVisualStyleBackColor = true;
            // 
            // radioButtonParityEven
            // 
            this.radioButtonParityEven.AutoSize = true;
            this.radioButtonParityEven.Location = new System.Drawing.Point(15, 69);
            this.radioButtonParityEven.Name = "radioButtonParityEven";
            this.radioButtonParityEven.Size = new System.Drawing.Size(63, 23);
            this.radioButtonParityEven.TabIndex = 1;
            this.radioButtonParityEven.Text = "Even";
            this.radioButtonParityEven.UseVisualStyleBackColor = true;
            // 
            // radioButtonParityNone
            // 
            this.radioButtonParityNone.AutoSize = true;
            this.radioButtonParityNone.Checked = true;
            this.radioButtonParityNone.Location = new System.Drawing.Point(15, 24);
            this.radioButtonParityNone.Name = "radioButtonParityNone";
            this.radioButtonParityNone.Size = new System.Drawing.Size(63, 23);
            this.radioButtonParityNone.TabIndex = 0;
            this.radioButtonParityNone.TabStop = true;
            this.radioButtonParityNone.Text = "None";
            this.radioButtonParityNone.UseVisualStyleBackColor = true;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(298, 310);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 34);
            this.button_Add.TabIndex = 18;
            this.button_Add.Text = "&Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_COM
            // 
            this.textBox_COM.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_COM.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_COM.Location = new System.Drawing.Point(123, 141);
            this.textBox_COM.Name = "textBox_COM";
            this.textBox_COM.Size = new System.Drawing.Size(78, 26);
            this.textBox_COM.TabIndex = 17;
            this.textBox_COM.Text = "COM1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(31, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "&COM";
            // 
            // textBox_BaudeRate
            // 
            this.textBox_BaudeRate.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_BaudeRate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_BaudeRate.Location = new System.Drawing.Point(123, 167);
            this.textBox_BaudeRate.Name = "textBox_BaudeRate";
            this.textBox_BaudeRate.Size = new System.Drawing.Size(78, 26);
            this.textBox_BaudeRate.TabIndex = 9;
            this.textBox_BaudeRate.Text = "9600";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(31, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Baude&Rate";
            // 
            // textBox_TimeSend
            // 
            this.textBox_TimeSend.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_TimeSend.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_TimeSend.Location = new System.Drawing.Point(121, 100);
            this.textBox_TimeSend.Name = "textBox_TimeSend";
            this.textBox_TimeSend.Size = new System.Drawing.Size(62, 26);
            this.textBox_TimeSend.TabIndex = 7;
            this.textBox_TimeSend.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(31, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Time&Send          ms";
            // 
            // textBox_TimeLine
            // 
            this.textBox_TimeLine.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_TimeLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_TimeLine.Location = new System.Drawing.Point(121, 74);
            this.textBox_TimeLine.Name = "textBox_TimeLine";
            this.textBox_TimeLine.Size = new System.Drawing.Size(62, 26);
            this.textBox_TimeLine.TabIndex = 5;
            this.textBox_TimeLine.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(31, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time&Line          ms";
            // 
            // textBox_TimeOut
            // 
            this.textBox_TimeOut.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_TimeOut.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_TimeOut.Location = new System.Drawing.Point(121, 48);
            this.textBox_TimeOut.Name = "textBox_TimeOut";
            this.textBox_TimeOut.Size = new System.Drawing.Size(62, 26);
            this.textBox_TimeOut.TabIndex = 3;
            this.textBox_TimeOut.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time&Out           ms";
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_Name.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Name.Location = new System.Drawing.Point(121, 16);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(159, 26);
            this.textBox_Name.TabIndex = 1;
            this.textBox_Name.Text = "Channel_1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Name";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(389, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Device config";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Наименование";
            // 
            // dataGridView_Channels
            // 
            this.dataGridView_Channels.AllowUserToAddRows = false;
            this.dataGridView_Channels.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Channels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Channels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Channels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Channel});
            this.dataGridView_Channels.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Channels.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Channels.Location = new System.Drawing.Point(163, 31);
            this.dataGridView_Channels.Name = "dataGridView_Channels";
            this.dataGridView_Channels.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Channels.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Channels.Size = new System.Drawing.Size(195, 382);
            this.dataGridView_Channels.TabIndex = 2;
            this.dataGridView_Channels.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Channels_CellContentClick);
            // 
            // Channel
            // 
            this.Channel.ContextMenuStrip = this.contextMenuStrip1;
            this.Channel.HeaderText = "Channel";
            this.Channel.Name = "Channel";
            this.Channel.ReadOnly = true;
            // 
            // dataGridView_Devices
            // 
            this.dataGridView_Devices.AllowUserToAddRows = false;
            this.dataGridView_Devices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Devices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Devices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Devices});
            this.dataGridView_Devices.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Devices.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Devices.Location = new System.Drawing.Point(364, 31);
            this.dataGridView_Devices.Name = "dataGridView_Devices";
            this.dataGridView_Devices.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Devices.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Devices.Size = new System.Drawing.Size(195, 382);
            this.dataGridView_Devices.TabIndex = 3;
            // 
            // Devices
            // 
            this.Devices.ContextMenuStrip = this.contextMenuStrip2;
            this.Devices.HeaderText = "Devices";
            this.Devices.Name = "Devices";
            this.Devices.ReadOnly = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeviceToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(169, 28);
            this.contextMenuStrip2.Click += new System.EventHandler(this.contextMenuStrip2_Click);
            // 
            // addDeviceToolStripMenuItem
            // 
            this.addDeviceToolStripMenuItem.Name = "addDeviceToolStripMenuItem";
            this.addDeviceToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.addDeviceToolStripMenuItem.Text = "Add Device";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 440);
            this.Controls.Add(this.dataGridView_Devices);
            this.Controls.Add(this.dataGridView_Channels);
            this.Controls.Add(this.tabControl_Config);
            this.Controls.Add(this.treeView1);
            this.Name = "Config";
            this.Text = "CONFIGURATIONS";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl_Config.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxStopBits.ResumeLayout(false);
            this.groupBoxStopBits.PerformLayout();
            this.groupBoxDataBits.ResumeLayout(false);
            this.groupBoxDataBits.PerformLayout();
            this.groupBoxParity.ResumeLayout(false);
            this.groupBoxParity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Channels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Devices)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl_Config;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TimeOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_BaudeRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TimeSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_TimeLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_COM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.GroupBox groupBoxStopBits;
        private System.Windows.Forms.RadioButton radioButtonStopBit2;
        private System.Windows.Forms.RadioButton radioButtonStopBit1;
        private System.Windows.Forms.GroupBox groupBoxDataBits;
        private System.Windows.Forms.RadioButton radioButtonDataBits8;
        private System.Windows.Forms.RadioButton radioButtonDataBits7;
        private System.Windows.Forms.GroupBox groupBoxParity;
        private System.Windows.Forms.RadioButton radioButtonParityOdd;
        private System.Windows.Forms.RadioButton radioButtonParityEven;
        private System.Windows.Forms.RadioButton radioButtonParityNone;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView_Channels;
        private System.Windows.Forms.DataGridView dataGridView_Devices;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Devices;
        private System.Windows.Forms.ToolStripMenuItem addDeviceToolStripMenuItem;
    }
}