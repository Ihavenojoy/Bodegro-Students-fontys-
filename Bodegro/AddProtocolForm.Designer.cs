namespace Bodegro
{
    partial class AddProtocolForm
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
            ProtocolSteps = new ListBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // ProtocolSteps
            // 
            ProtocolSteps.FormattingEnabled = true;
            ProtocolSteps.ItemHeight = 15;
            ProtocolSteps.Location = new Point(515, 232);
            ProtocolSteps.Name = "ProtocolSteps";
            ProtocolSteps.Size = new Size(201, 169);
            ProtocolSteps.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // AddProtocolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(ProtocolSteps);
            Name = "AddProtocolForm";
            Text = "AddProtocolForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ProtocolSteps;
        private TextBox textBox1;
    }
}