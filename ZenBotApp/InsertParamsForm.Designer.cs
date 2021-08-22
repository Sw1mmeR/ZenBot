
namespace ZenBotApp
{
    partial class InsertParamsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertParamsForm));
            this.likesCheckBox = new System.Windows.Forms.CheckBox();
            this.viewsCheckBox = new System.Windows.Forms.CheckBox();
            this.formTextBox = new System.Windows.Forms.TextBox();
            this.viewsBox = new System.Windows.Forms.TextBox();
            this.likesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.timerBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.changeFormBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // likesCheckBox
            // 
            this.likesCheckBox.AutoSize = true;
            this.likesCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.likesCheckBox.Location = new System.Drawing.Point(138, 14);
            this.likesCheckBox.Name = "likesCheckBox";
            this.likesCheckBox.Size = new System.Drawing.Size(59, 19);
            this.likesCheckBox.TabIndex = 0;
            this.likesCheckBox.Text = "Лайки";
            this.likesCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewsCheckBox
            // 
            this.viewsCheckBox.AutoSize = true;
            this.viewsCheckBox.Checked = true;
            this.viewsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewsCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewsCheckBox.Location = new System.Drawing.Point(19, 15);
            this.viewsCheckBox.Name = "viewsCheckBox";
            this.viewsCheckBox.Size = new System.Drawing.Size(90, 19);
            this.viewsCheckBox.TabIndex = 1;
            this.viewsCheckBox.Text = "Просмотры";
            this.viewsCheckBox.UseVisualStyleBackColor = true;
            // 
            // formTextBox
            // 
            this.formTextBox.Location = new System.Drawing.Point(14, 91);
            this.formTextBox.Multiline = true;
            this.formTextBox.Name = "formTextBox";
            this.formTextBox.Size = new System.Drawing.Size(427, 170);
            this.formTextBox.TabIndex = 2;
            // 
            // viewsBox
            // 
            this.viewsBox.Location = new System.Drawing.Point(19, 37);
            this.viewsBox.Name = "viewsBox";
            this.viewsBox.Size = new System.Drawing.Size(98, 23);
            this.viewsBox.TabIndex = 3;
            this.viewsBox.Text = "1000";
            // 
            // likesBox
            // 
            this.likesBox.Location = new System.Drawing.Point(138, 37);
            this.likesBox.Name = "likesBox";
            this.likesBox.Size = new System.Drawing.Size(98, 23);
            this.likesBox.TabIndex = 4;
            this.likesBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Текст формы:";
            // 
            // saveBtn
            // 
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Location = new System.Drawing.Point(355, 268);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(87, 27);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // timerBox
            // 
            this.timerBox.Location = new System.Drawing.Point(343, 37);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(98, 23);
            this.timerBox.TabIndex = 7;
            this.timerBox.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Таймер (минут):";
            // 
            // changeFormBox
            // 
            this.changeFormBox.AutoSize = true;
            this.changeFormBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeFormBox.Location = new System.Drawing.Point(14, 267);
            this.changeFormBox.Name = "changeFormBox";
            this.changeFormBox.Size = new System.Drawing.Size(126, 19);
            this.changeFormBox.TabIndex = 9;
            this.changeFormBox.Text = "Изменение формы";
            this.changeFormBox.UseVisualStyleBackColor = true;
            // 
            // InsertParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 307);
            this.Controls.Add(this.changeFormBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timerBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.likesBox);
            this.Controls.Add(this.viewsBox);
            this.Controls.Add(this.formTextBox);
            this.Controls.Add(this.viewsCheckBox);
            this.Controls.Add(this.likesCheckBox);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(472, 346);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(472, 346);
            this.Name = "InsertParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZenBotApp: Параметры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsertParamsForm_FormClosing);
            this.Load += new System.EventHandler(this.InsertParamsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox likesCheckBox;
        private System.Windows.Forms.CheckBox viewsCheckBox;
        private System.Windows.Forms.TextBox formTextBox;
        private System.Windows.Forms.TextBox viewsBox;
        private System.Windows.Forms.TextBox likesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox timerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox changeFormBox;
    }
}