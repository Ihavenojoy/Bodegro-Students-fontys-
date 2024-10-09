namespace Bodegro
{
    partial class PatiëntRegistry
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
            PatiëntBox = new ListBox();
            SuspendLayout();
            // 
            // PatiëntBox
            // 
            PatiëntBox.FormattingEnabled = true;
            PatiëntBox.ItemHeight = 15;
            PatiëntBox.Location = new Point(12, 12);
            PatiëntBox.Name = "PatiëntBox";
            PatiëntBox.Size = new Size(257, 424);
            PatiëntBox.TabIndex = 0;
            // 
            // PatiëntRegistry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PatiëntBox);
            Name = "PatiëntRegistry";
            Text = "PatiëntRegistry";
            ResumeLayout(false);
        }

        #endregion

        private ListBox PatiëntBox;
    }
}