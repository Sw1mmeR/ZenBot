
namespace ZenBotApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.usersContainer = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteUserMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.formIdBox = new System.Windows.Forms.TextBox();
            this.proxyAddressField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.proxyLoginField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.proxyPassField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loginField = new System.Windows.Forms.TextBox();
            this.showPassBtn = new System.Windows.Forms.PictureBox();
            this.passField = new System.Windows.Forms.TextBox();
            this.showPassBox = new System.Windows.Forms.CheckBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.authBtn = new System.Windows.Forms.Button();
            this.passLabel = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.insertParams = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openDirToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.logFileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.getDataTimer = new System.Windows.Forms.Timer(this.components);
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.linkBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPassBtn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersContainer
            // 
            this.usersContainer.BackColor = System.Drawing.SystemColors.Control;
            this.usersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usersContainer.ContextMenuStrip = this.contextMenuStrip1;
            this.usersContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usersContainer.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usersContainer.FormattingEnabled = true;
            this.usersContainer.ItemHeight = 23;
            this.usersContainer.Location = new System.Drawing.Point(280, 31);
            this.usersContainer.Name = "usersContainer";
            this.usersContainer.Size = new System.Drawing.Size(164, 324);
            this.usersContainer.TabIndex = 2;
            this.usersContainer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.usersContainer_MouseDoubleClick);
            this.usersContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.usersContainer_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteUserMenuStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // deleteUserMenuStrip
            // 
            this.deleteUserMenuStrip.Name = "deleteUserMenuStrip";
            this.deleteUserMenuStrip.Size = new System.Drawing.Size(118, 22);
            this.deleteUserMenuStrip.Text = "Удалить";
            this.deleteUserMenuStrip.Click += new System.EventHandler(this.deleteUserMenuStrip_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.formIdBox);
            this.panel1.Controls.Add(this.proxyAddressField);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.proxyLoginField);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.proxyPassField);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.loginField);
            this.panel1.Controls.Add(this.showPassBtn);
            this.panel1.Controls.Add(this.passField);
            this.panel1.Controls.Add(this.showPassBox);
            this.panel1.Controls.Add(this.loginLabel);
            this.panel1.Controls.Add(this.authBtn);
            this.panel1.Controls.Add(this.passLabel);
            this.panel1.Location = new System.Drawing.Point(14, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 386);
            this.panel1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Введите id формы:";
            // 
            // formIdBox
            // 
            this.formIdBox.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formIdBox.Location = new System.Drawing.Point(15, 130);
            this.formIdBox.Margin = new System.Windows.Forms.Padding(1);
            this.formIdBox.Multiline = true;
            this.formIdBox.Name = "formIdBox";
            this.formIdBox.Size = new System.Drawing.Size(211, 28);
            this.formIdBox.TabIndex = 19;
            // 
            // proxyAddressField
            // 
            this.proxyAddressField.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.proxyAddressField.Location = new System.Drawing.Point(15, 315);
            this.proxyAddressField.Margin = new System.Windows.Forms.Padding(1);
            this.proxyAddressField.Multiline = true;
            this.proxyAddressField.Name = "proxyAddressField";
            this.proxyAddressField.Size = new System.Drawing.Size(211, 28);
            this.proxyAddressField.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Введите адрес (IP:Port):";
            // 
            // proxyLoginField
            // 
            this.proxyLoginField.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.proxyLoginField.Location = new System.Drawing.Point(15, 214);
            this.proxyLoginField.Margin = new System.Windows.Forms.Padding(1);
            this.proxyLoginField.Multiline = true;
            this.proxyLoginField.Name = "proxyLoginField";
            this.proxyLoginField.Size = new System.Drawing.Size(211, 28);
            this.proxyLoginField.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Введите логин:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(0, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 1);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(93, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Прокси";
            // 
            // proxyPassField
            // 
            this.proxyPassField.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.proxyPassField.Location = new System.Drawing.Point(15, 266);
            this.proxyPassField.Multiline = true;
            this.proxyPassField.Name = "proxyPassField";
            this.proxyPassField.PasswordChar = '*';
            this.proxyPassField.Size = new System.Drawing.Size(211, 28);
            this.proxyPassField.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Введите пароль:";
            // 
            // loginField
            // 
            this.loginField.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginField.Location = new System.Drawing.Point(15, 29);
            this.loginField.Margin = new System.Windows.Forms.Padding(1);
            this.loginField.Multiline = true;
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(211, 28);
            this.loginField.TabIndex = 2;
            // 
            // showPassBtn
            // 
            this.showPassBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPassBtn.Image = ((System.Drawing.Image)(resources.GetObject("showPassBtn.Image")));
            this.showPassBtn.Location = new System.Drawing.Point(226, 80);
            this.showPassBtn.Name = "showPassBtn";
            this.showPassBtn.Size = new System.Drawing.Size(29, 27);
            this.showPassBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showPassBtn.TabIndex = 8;
            this.showPassBtn.TabStop = false;
            this.showPassBtn.Click += new System.EventHandler(this.showPassBtn_Click);
            // 
            // passField
            // 
            this.passField.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passField.Location = new System.Drawing.Point(15, 80);
            this.passField.Multiline = true;
            this.passField.Name = "passField";
            this.passField.PasswordChar = '*';
            this.passField.Size = new System.Drawing.Size(211, 28);
            this.passField.TabIndex = 3;
            // 
            // showPassBox
            // 
            this.showPassBox.AutoSize = true;
            this.showPassBox.Location = new System.Drawing.Point(233, 113);
            this.showPassBox.Name = "showPassBox";
            this.showPassBox.Size = new System.Drawing.Size(15, 14);
            this.showPassBox.TabIndex = 7;
            this.showPassBox.UseVisualStyleBackColor = true;
            this.showPassBox.Visible = false;
            this.showPassBox.CheckedChanged += new System.EventHandler(this.showPassBox_CheckedChanged);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 10);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(89, 15);
            this.loginLabel.TabIndex = 4;
            this.loginLabel.Text = "Введите логин:";
            // 
            // authBtn
            // 
            this.authBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authBtn.Location = new System.Drawing.Point(75, 348);
            this.authBtn.Name = "authBtn";
            this.authBtn.Size = new System.Drawing.Size(87, 27);
            this.authBtn.TabIndex = 6;
            this.authBtn.Text = "Сохранить";
            this.authBtn.UseVisualStyleBackColor = true;
            this.authBtn.Click += new System.EventHandler(this.authBtn_Click);
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(12, 61);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(95, 15);
            this.passLabel.TabIndex = 5;
            this.passLabel.Text = "Введите пароль:";
            // 
            // startBtn
            // 
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(279, 361);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(165, 57);
            this.startBtn.TabIndex = 11;
            this.startBtn.Text = "Мониторить";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // insertParams
            // 
            this.insertParams.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertParams.Name = "insertParams";
            this.insertParams.Size = new System.Drawing.Size(85, 21);
            this.insertParams.Text = "Параметры";
            this.insertParams.Click += new System.EventHandler(this.insertParams_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertParams,
            this.openDirToolStrip,
            this.logFileToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(457, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openDirToolStrip
            // 
            this.openDirToolStrip.Name = "openDirToolStrip";
            this.openDirToolStrip.Size = new System.Drawing.Size(53, 21);
            this.openDirToolStrip.Text = "Папка";
            this.openDirToolStrip.Click += new System.EventHandler(this.openDirToolStrip_Click);
            // 
            // logFileToolStrip
            // 
            this.logFileToolStrip.Name = "logFileToolStrip";
            this.logFileToolStrip.Size = new System.Drawing.Size(71, 21);
            this.logFileToolStrip.Text = "Лог файл";
            this.logFileToolStrip.Click += new System.EventHandler(this.logFileToolStrip_Click);
            // 
            // getDataTimer
            // 
            this.getDataTimer.Tick += new System.EventHandler(this.getDataTimer_Tick);
            // 
            // tickTimer
            // 
            this.tickTimer.Interval = 1000;
            this.tickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Url формы:";
            // 
            // linkBox
            // 
            this.linkBox.Location = new System.Drawing.Point(16, 439);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(429, 23);
            this.linkBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 474);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.linkBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.usersContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(473, 513);
            this.MinimumSize = new System.Drawing.Size(473, 513);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZenBotApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_LoadAsync);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPassBtn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox usersContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.PictureBox showPassBtn;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.CheckBox showPassBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Button authBtn;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteUserMenuStrip;
        private System.Windows.Forms.TextBox proxyAddressField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox proxyLoginField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox proxyPassField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox formIdBox;
        private System.Windows.Forms.ToolStripMenuItem insertParams;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer getDataTimer;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.ToolStripMenuItem openDirToolStrip;
        private System.Windows.Forms.ToolStripMenuItem logFileToolStrip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox linkBox;
    }
}