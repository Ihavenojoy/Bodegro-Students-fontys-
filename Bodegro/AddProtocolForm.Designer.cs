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
            NameBox = new TextBox();
            NameLabel = new Label();
            DescriptionLabel = new Label();
            DescriptionBox = new TextBox();
            NewStep = new Button();
            AddProtocol = new Button();
            SuspendLayout();
            // 
            // ProtocolSteps
            // 
            ProtocolSteps.FormattingEnabled = true;
            ProtocolSteps.ItemHeight = 15;
            ProtocolSteps.Location = new Point(515, 187);
            ProtocolSteps.Name = "ProtocolSteps";
            ProtocolSteps.Size = new Size(201, 184);
            ProtocolSteps.TabIndex = 0;
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
            DescriptionBox.Size = new Size(456, 214);
            DescriptionBox.TabIndex = 4;
            // 
            // NewStep
            // 
            NewStep.Location = new Point(632, 158);
            NewStep.Name = "NewStep";
            NewStep.Size = new Size(84, 23);
            NewStep.TabIndex = 5;
            NewStep.Text = "Nieuwe Stap";
            NewStep.UseVisualStyleBackColor = true;
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
            // AddProtocolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddProtocol);
            Controls.Add(NewStep);
            Controls.Add(DescriptionBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(NameLabel);
            Controls.Add(NameBox);
            Controls.Add(ProtocolSteps);
            Name = "AddProtocolForm";
            Text = "AddProtocolForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox ProtocolSteps;
        private TextBox NameBox;
        private Label NameLabel;
        private Label DescriptionLabel;
        private TextBox DescriptionBox;
        private Button NewStep;
        private Button AddProtocol;
    }
}