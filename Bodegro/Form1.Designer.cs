﻿namespace Bodegro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TestButton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // TestButton
            // 
            TestButton.Location = new Point(409, 320);
            TestButton.Margin = new Padding(3, 4, 3, 4);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(86, 31);
            TestButton.TabIndex = 0;
            TestButton.Text = "Test";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(457, 156);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button1);
            Controls.Add(TestButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button TestButton;
        private Button button1;
    }
}
