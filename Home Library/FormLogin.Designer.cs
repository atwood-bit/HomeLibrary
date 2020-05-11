namespace Home_Library
{
    partial class FormLogin
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btLogin = new System.Windows.Forms.Button();
            this.btRegister = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.PassText = new System.Windows.Forms.TextBox();
            this.lbPass = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(43, 145);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(151, 38);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btRegister
            // 
            this.btRegister.Location = new System.Drawing.Point(43, 189);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(151, 38);
            this.btRegister.TabIndex = 1;
            this.btRegister.Text = "Register";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(43, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(55, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Username";
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(46, 40);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(148, 20);
            this.NameText.TabIndex = 3;
            // 
            // PassText
            // 
            this.PassText.Location = new System.Drawing.Point(46, 106);
            this.PassText.Name = "PassText";
            this.PassText.PasswordChar = '*';
            this.PassText.Size = new System.Drawing.Size(148, 20);
            this.PassText.TabIndex = 4;
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(46, 87);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(53, 13);
            this.lbPass.TabIndex = 5;
            this.lbPass.Text = "Password";
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(43, 233);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(151, 38);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(238, 290);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.PassText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.btLogin);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Library";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox PassText;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Button btExit;
    }
}

