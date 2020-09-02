namespace MiniPai
{
    partial class MiniPaiForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regNumberTextBox = new System.Windows.Forms.TextBox();
            this.regValueTextbox = new System.Windows.Forms.TextBox();
            this.regSetValue = new System.Windows.Forms.Button();
            this.regClear = new System.Windows.Forms.Button();
            this.memGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pcAddresstextBox = new System.Windows.Forms.TextBox();
            this.programmStopButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.memClearButton = new System.Windows.Forms.Button();
            this.memSetValueButton = new System.Windows.Forms.Button();
            this.memValueTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.memDataGridView = new System.Windows.Forms.DataGridView();
            this.setPCButton = new System.Windows.Forms.Button();
            this.pcTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regGroupBox = new System.Windows.Forms.GroupBox();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regDataGridView)).BeginInit();
            this.memGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memDataGridView)).BeginInit();
            this.regGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1389, 32);
            this.mainMenuStrip.TabIndex = 3;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(175, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(175, 34);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(175, 34);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // regDataGridView
            // 
            this.regDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.regDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.regDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.regDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.regDataGridView.Location = new System.Drawing.Point(253, 27);
            this.regDataGridView.Name = "regDataGridView";
            this.regDataGridView.RowHeadersWidth = 62;
            this.regDataGridView.RowTemplate.Height = 30;
            this.regDataGridView.Size = new System.Drawing.Size(335, 553);
            this.regDataGridView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "RegNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "RegValue";
            // 
            // regNumberTextBox
            // 
            this.regNumberTextBox.Location = new System.Drawing.Point(124, 34);
            this.regNumberTextBox.Name = "regNumberTextBox";
            this.regNumberTextBox.Size = new System.Drawing.Size(89, 28);
            this.regNumberTextBox.TabIndex = 7;
            // 
            // regValueTextbox
            // 
            this.regValueTextbox.Location = new System.Drawing.Point(124, 88);
            this.regValueTextbox.Name = "regValueTextbox";
            this.regValueTextbox.Size = new System.Drawing.Size(89, 28);
            this.regValueTextbox.TabIndex = 8;
            // 
            // regSetValue
            // 
            this.regSetValue.Location = new System.Drawing.Point(32, 137);
            this.regSetValue.Name = "regSetValue";
            this.regSetValue.Size = new System.Drawing.Size(181, 39);
            this.regSetValue.TabIndex = 9;
            this.regSetValue.Text = "SetValue";
            this.regSetValue.UseVisualStyleBackColor = true;
            this.regSetValue.Click += new System.EventHandler(this.regSetValue_Click);
            // 
            // regClear
            // 
            this.regClear.Location = new System.Drawing.Point(32, 197);
            this.regClear.Name = "regClear";
            this.regClear.Size = new System.Drawing.Size(181, 39);
            this.regClear.TabIndex = 10;
            this.regClear.Text = "Clear";
            this.regClear.UseVisualStyleBackColor = true;
            this.regClear.Click += new System.EventHandler(this.regClear_Click);
            // 
            // memGroupBox
            // 
            this.memGroupBox.Controls.Add(this.label6);
            this.memGroupBox.Controls.Add(this.pcAddresstextBox);
            this.memGroupBox.Controls.Add(this.programmStopButton);
            this.memGroupBox.Controls.Add(this.stepButton);
            this.memGroupBox.Controls.Add(this.runButton);
            this.memGroupBox.Controls.Add(this.memClearButton);
            this.memGroupBox.Controls.Add(this.memSetValueButton);
            this.memGroupBox.Controls.Add(this.memValueTextBox);
            this.memGroupBox.Controls.Add(this.addressTextBox);
            this.memGroupBox.Controls.Add(this.label4);
            this.memGroupBox.Controls.Add(this.label5);
            this.memGroupBox.Controls.Add(this.memDataGridView);
            this.memGroupBox.Location = new System.Drawing.Point(30, 65);
            this.memGroupBox.Name = "memGroupBox";
            this.memGroupBox.Size = new System.Drawing.Size(603, 607);
            this.memGroupBox.TabIndex = 11;
            this.memGroupBox.TabStop = false;
            this.memGroupBox.Text = "Memory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "PCAddress";
            // 
            // pcAddresstextBox
            // 
            this.pcAddresstextBox.Location = new System.Drawing.Point(22, 100);
            this.pcAddresstextBox.Name = "pcAddresstextBox";
            this.pcAddresstextBox.ReadOnly = true;
            this.pcAddresstextBox.Size = new System.Drawing.Size(181, 28);
            this.pcAddresstextBox.TabIndex = 20;
            // 
            // programmStopButton
            // 
            this.programmStopButton.Location = new System.Drawing.Point(22, 544);
            this.programmStopButton.Name = "programmStopButton";
            this.programmStopButton.Size = new System.Drawing.Size(181, 39);
            this.programmStopButton.TabIndex = 19;
            this.programmStopButton.Text = "Stop";
            this.programmStopButton.UseVisualStyleBackColor = true;
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(22, 474);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(181, 39);
            this.stepButton.TabIndex = 18;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(22, 399);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(181, 39);
            this.runButton.TabIndex = 17;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // memClearButton
            // 
            this.memClearButton.Location = new System.Drawing.Point(22, 329);
            this.memClearButton.Name = "memClearButton";
            this.memClearButton.Size = new System.Drawing.Size(181, 39);
            this.memClearButton.TabIndex = 16;
            this.memClearButton.Text = "Clear";
            this.memClearButton.UseVisualStyleBackColor = true;
            // 
            // memSetValueButton
            // 
            this.memSetValueButton.Location = new System.Drawing.Point(22, 267);
            this.memSetValueButton.Name = "memSetValueButton";
            this.memSetValueButton.Size = new System.Drawing.Size(181, 39);
            this.memSetValueButton.TabIndex = 15;
            this.memSetValueButton.Text = "SetValue";
            this.memSetValueButton.UseVisualStyleBackColor = true;
            // 
            // memValueTextBox
            // 
            this.memValueTextBox.Location = new System.Drawing.Point(87, 212);
            this.memValueTextBox.Name = "memValueTextBox";
            this.memValueTextBox.Size = new System.Drawing.Size(116, 28);
            this.memValueTextBox.TabIndex = 14;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(87, 171);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(116, 28);
            this.addressTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Address";
            // 
            // memDataGridView
            // 
            this.memDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.memDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memDataGridView.Location = new System.Drawing.Point(234, 30);
            this.memDataGridView.Name = "memDataGridView";
            this.memDataGridView.RowHeadersWidth = 62;
            this.memDataGridView.RowTemplate.Height = 30;
            this.memDataGridView.Size = new System.Drawing.Size(338, 553);
            this.memDataGridView.TabIndex = 0;
            this.memDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.memDataGridView_CellEndEdit);
            this.memDataGridView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.memDataGridView_CellParsing);
            this.memDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.memDataGridView_CellValidating);
            // 
            // setPCButton
            // 
            this.setPCButton.Location = new System.Drawing.Point(32, 438);
            this.setPCButton.Name = "setPCButton";
            this.setPCButton.Size = new System.Drawing.Size(181, 37);
            this.setPCButton.TabIndex = 3;
            this.setPCButton.Text = "setPC";
            this.setPCButton.UseVisualStyleBackColor = true;
            this.setPCButton.Click += new System.EventHandler(this.setPCButton_Click);
            // 
            // pcTextBox
            // 
            this.pcTextBox.Location = new System.Drawing.Point(32, 375);
            this.pcTextBox.Name = "pcTextBox";
            this.pcTextBox.Size = new System.Drawing.Size(181, 28);
            this.pcTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "PC";
            // 
            // regGroupBox
            // 
            this.regGroupBox.Controls.Add(this.regDataGridView);
            this.regGroupBox.Controls.Add(this.label1);
            this.regGroupBox.Controls.Add(this.label2);
            this.regGroupBox.Controls.Add(this.regNumberTextBox);
            this.regGroupBox.Controls.Add(this.regValueTextbox);
            this.regGroupBox.Controls.Add(this.regSetValue);
            this.regGroupBox.Controls.Add(this.regClear);
            this.regGroupBox.Controls.Add(this.pcTextBox);
            this.regGroupBox.Controls.Add(this.setPCButton);
            this.regGroupBox.Controls.Add(this.label3);
            this.regGroupBox.Location = new System.Drawing.Point(639, 65);
            this.regGroupBox.Name = "regGroupBox";
            this.regGroupBox.Size = new System.Drawing.Size(607, 607);
            this.regGroupBox.TabIndex = 12;
            this.regGroupBox.TabStop = false;
            this.regGroupBox.Text = "Register";
            // 
            // MiniPaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 734);
            this.Controls.Add(this.memGroupBox);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.regGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MiniPaiForm";
            this.Text = "MiniPai";
            this.Load += new System.EventHandler(this.MiniPaiForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regDataGridView)).EndInit();
            this.memGroupBox.ResumeLayout(false);
            this.memGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memDataGridView)).EndInit();
            this.regGroupBox.ResumeLayout(false);
            this.regGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView regDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox regNumberTextBox;
        private System.Windows.Forms.TextBox regValueTextbox;
        private System.Windows.Forms.Button regSetValue;
        private System.Windows.Forms.Button regClear;
        private System.Windows.Forms.GroupBox memGroupBox;
        private System.Windows.Forms.TextBox pcTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView memDataGridView;
        private System.Windows.Forms.Button programmStopButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button memClearButton;
        private System.Windows.Forms.Button memSetValueButton;
        private System.Windows.Forms.TextBox memValueTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button setPCButton;
        private System.Windows.Forms.GroupBox regGroupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pcAddresstextBox;
    }
}

