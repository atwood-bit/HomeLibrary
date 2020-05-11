namespace Home_Library
{
    partial class FormRegister
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
            this.btReg = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.NameText = new System.Windows.Forms.TextBox();
            this.PassText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btReg
            // 
            this.btReg.Location = new System.Drawing.Point(26, 123);
            this.btReg.Name = "btReg";
            this.btReg.Size = new System.Drawing.Size(75, 23);
            this.btReg.TabIndex = 0;
            this.btReg.Text = "Register";
            this.btReg.UseVisualStyleBackColor = true;
            this.btReg.Click += new System.EventHandler(this.btReg_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(144, 123);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(84, 28);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(164, 20);
            this.NameText.TabIndex = 2;
            // 
            // PassText
            // 
            this.PassText.Location = new System.Drawing.Point(84, 70);
            this.PassText.Name = "PassText";
            this.PassText.PasswordChar = '*';
            this.PassText.Size = new System.Drawing.Size(164, 20);
            this.PassText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(258, 167);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PassText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btReg);
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Library";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRegister_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btReg;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox PassText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}