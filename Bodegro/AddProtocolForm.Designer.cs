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
            NameBox = new TextBox();
            NameLabel = new Label();
            DescriptionLabel = new Label();
            DescriptionBox = new TextBox();
            AddProtocol = new Button();
            BackButton = new Button();
            AmountLabel = new Label();
            StepAmount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)StepAmount).BeginInit();
            SuspendLayout();
            // 
            // NameBox
            // 
            NameBox.Location = new Point(45, 58);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(100, 23);
            NameBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(45, 40);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(39, 15);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "Name";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(45, 169);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(87, 15);
            DescriptionLabel.TabIndex = 3;
            DescriptionLabel.Text = "DescriptionBox";
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(45, 187);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(590, 214);
            DescriptionBox.TabIndex = 4;
            // 
            // AddProtocol
            // 
            AddProtocol.Location = new Point(641, 378);
            AddProtocol.Name = "AddProtocol";
            AddProtocol.Size = new Size(75, 23);
            AddProtocol.TabIndex = 6;
            AddProtocol.Text = "Klaar";
            AddProtocol.UseVisualStyleBackColor = true;
            AddProtocol.Click += AddProtocol_Click;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 415);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(75, 23);
            BackButton.TabIndex = 7;
            BackButton.Text = "Terug";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // AmountLabel
            // 
            AmountLabel.AutoSize = true;
            AmountLabel.Location = new Point(45, 104);
            AmountLabel.Name = "AmountLabel";
            AmountLabel.Size = new Size(87, 15);
            AmountLabel.TabIndex = 9;
            AmountLabel.Text = "Aantal Stappen";
            // 
            // StepAmount
            // 
            StepAmount.Location = new Point(45, 122);
            StepAmount.Name = "StepAmount";
            StepAmount.Size = new Size(120, 23);
            StepAmount.TabIndex = 10;
            // 
            // AddProtocolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StepAmount);
            Controls.Add(AmountLabel);
            Controls.Add(BackButton);
            Controls.Add(AddProtocol);
            Controls.Add(DescriptionBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(NameLabel);
            Controls.Add(NameBox);
            Name = "AddProtocolForm";
            Text = "AddProtocolForm";
            ((System.ComponentModel.ISupportInitialize)StepAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NameBox;
        private Label NameLabel;
        private Label DescriptionLabel;
        private TextBox DescriptionBox;
        private Button AddProtocol;
        private Button BackButton;
        private Label AmountLabel;
        private NumericUpDown StepAmount;
    }
}