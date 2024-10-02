namespace Bodegro
{
    partial class InlogPagina
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
            EmailInputUser = new TextBox();
            PassWordInputUser = new TextBox();
            LogInButton = new Button();
            EmailLabel = new Label();
            PassWordLabel = new Label();
            SuspendLayout();
            // 
            // EmailInputUser
            // 
            EmailInputUser.Location = new Point(123, 163);
            EmailInputUser.Name = "EmailInputUser";
            EmailInputUser.Size = new Size(567, 23);
            EmailInputUser.TabIndex = 0;
            // 
            // PassWordInputUser
            // 
            PassWordInputUser.Location = new Point(123, 243);
            PassWordInputUser.Name = "PassWordInputUser";
            PassWordInputUser.ScrollBars = ScrollBars.Vertical;
            PassWordInputUser.Size = new Size(567, 23);
            PassWordInputUser.TabIndex = 1;
            PassWordInputUser.UseSystemPasswordChar = true;
            // 
            // LogInButton
            // 
            LogInButton.Location = new Point(359, 272);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new Size(75, 23);
            LogInButton.TabIndex = 2;
            LogInButton.Text = "Log in";
            LogInButton.UseVisualStyleBackColor = true;
            LogInButton.Click += LogInButton_Click;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(123, 145);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(36, 15);
            EmailLabel.TabIndex = 3;
            EmailLabel.Text = "Email";
            // 
            // PassWordLabel
            // 
            PassWordLabel.AutoSize = true;
            PassWordLabel.Location = new Point(123, 221);
            PassWordLabel.Name = "PassWordLabel";
            PassWordLabel.Size = new Size(57, 15);
            PassWordLabel.TabIndex = 4;
            PassWordLabel.Text = "Password";
            // 
            // InlogPagina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 477);
            Controls.Add(PassWordLabel);
            Controls.Add(EmailLabel);
            Controls.Add(LogInButton);
            Controls.Add(PassWordInputUser);
            Controls.Add(EmailInputUser);
            Name = "InlogPagina";
            Text = "InlogPagina";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EmailInputUser;
        private TextBox PassWordInputUser;
        private Button LogInButton;
        private Label EmailLabel;
        private Label PassWordLabel;
    }
}