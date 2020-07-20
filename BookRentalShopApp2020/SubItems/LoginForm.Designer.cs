namespace BookRentalShopApp2020.SubItems
{
    partial class LoginForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TxtUserID = new MetroFramework.Controls.MetroTextBox();
            this.TxtPassword = new MetroFramework.Controls.MetroTextBox();
            this.BtnOK = new MetroFramework.Controls.MetroButton();
            this.BtnCancle = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(11, 110);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(165, 23);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "ID :";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(11, 166);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(165, 31);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "PASSWORD : ";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtUserID
            // 
            // 
            // 
            // 
            this.TxtUserID.CustomButton.Image = null;
            this.TxtUserID.CustomButton.Location = new System.Drawing.Point(259, 2);
            this.TxtUserID.CustomButton.Name = "";
            this.TxtUserID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TxtUserID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtUserID.CustomButton.TabIndex = 1;
            this.TxtUserID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtUserID.CustomButton.UseSelectable = true;
            this.TxtUserID.CustomButton.Visible = false;
            this.TxtUserID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TxtUserID.Lines = new string[0];
            this.TxtUserID.Location = new System.Drawing.Point(182, 103);
            this.TxtUserID.MaxLength = 12;
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.PasswordChar = '\0';
            this.TxtUserID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtUserID.SelectedText = "";
            this.TxtUserID.SelectionLength = 0;
            this.TxtUserID.SelectionStart = 0;
            this.TxtUserID.ShortcutsEnabled = true;
            this.TxtUserID.Size = new System.Drawing.Size(287, 30);
            this.TxtUserID.TabIndex = 0;
            this.TxtUserID.UseSelectable = true;
            this.TxtUserID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtUserID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TxtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUserID_KeyPress);
            // 
            // TxtPassword
            // 
            // 
            // 
            // 
            this.TxtPassword.CustomButton.Image = null;
            this.TxtPassword.CustomButton.Location = new System.Drawing.Point(259, 2);
            this.TxtPassword.CustomButton.Name = "";
            this.TxtPassword.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TxtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtPassword.CustomButton.TabIndex = 1;
            this.TxtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtPassword.CustomButton.UseSelectable = true;
            this.TxtPassword.CustomButton.Visible = false;
            this.TxtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TxtPassword.Lines = new string[0];
            this.TxtPassword.Location = new System.Drawing.Point(182, 167);
            this.TxtPassword.MaxLength = 32767;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '●';
            this.TxtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtPassword.SelectedText = "";
            this.TxtPassword.SelectionLength = 0;
            this.TxtPassword.SelectionStart = 0;
            this.TxtPassword.ShortcutsEnabled = true;
            this.TxtPassword.Size = new System.Drawing.Size(287, 30);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.UseSelectable = true;
            this.TxtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // BtnOK
            // 
            this.BtnOK.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnOK.Location = new System.Drawing.Point(225, 231);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(107, 36);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseSelectable = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnCancle.Location = new System.Drawing.Point(359, 231);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(110, 36);
            this.BtnCancle.TabIndex = 3;
            this.BtnCancle.Text = "Cancle";
            this.BtnCancle.UseSelectable = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 327);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUserID);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "LoginForm";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TxtUserID;
        private MetroFramework.Controls.MetroTextBox TxtPassword;
        private MetroFramework.Controls.MetroButton BtnOK;
        private MetroFramework.Controls.MetroButton BtnCancle;
    }
}