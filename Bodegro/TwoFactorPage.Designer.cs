namespace Bodegro
{
    partial class TwoFactorPage
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
            TwoFactorUserInput = new TextBox();
            TwoFactorSubmitButton = new Button();
            SuspendLayout();
            // 
            // TwoFactorUserInput
            // 
            TwoFactorUserInput.Location = new Point(12, 35);
            TwoFactorUserInput.Name = "TwoFactorUserInput";
            TwoFactorUserInput.Size = new Size(325, 23);
            TwoFactorUserInput.TabIndex = 0;
            // 
            // TwoFactorSubmitButton
            // 
            TwoFactorSubmitButton.Location = new Point(129, 82);
            TwoFactorSubmitButton.Name = "TwoFactorSubmitButton";
            TwoFactorSubmitButton.Size = new Size(75, 23);
            TwoFactorSubmitButton.TabIndex = 1;
            TwoFactorSubmitButton.Text = "Log in";
            TwoFactorSubmitButton.UseVisualStyleBackColor = true;
            TwoFactorSubmitButton.Click += TwoFactorSubmitButton_Click;
            // 
            // TwoFactorPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 139);
            Controls.Add(TwoFactorSubmitButton);
            Controls.Add(TwoFactorUserInput);
            Name = "TwoFactorPage";
            Text = "TwoFactorPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TwoFactorUserInput;
        private Button TwoFactorSubmitButton;
    }
}