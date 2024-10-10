namespace Bodegro
{
    partial class AddStepForm
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
            NaamLabel = new Label();
            NameBox = new TextBox();
            OrderLabel = new Label();
            OrderBox = new TextBox();
            TestLabel = new Label();
            TestenBox = new TextBox();
            IntevalLabel = new Label();
            IntervalBox = new TextBox();
            DescriptionLabel = new Label();
            DescriptionBox = new TextBox();
            AddStep = new Button();
            SuspendLayout();
            // 
            // NaamLabel
            // 
            NaamLabel.AutoSize = true;
            NaamLabel.Location = new Point(43, 67);
            NaamLabel.Name = "NaamLabel";
            NaamLabel.Size = new Size(39, 15);
            NaamLabel.TabIndex = 0;
            NaamLabel.Text = "Naam";
            // 
            // NameBox
            // 
            NameBox.Location = new Point(43, 85);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(100, 23);
            NameBox.TabIndex = 1;
            // 
            // OrderLabel
            // 
            OrderLabel.AutoSize = true;
            OrderLabel.Location = new Point(219, 67);
            OrderLabel.Name = "OrderLabel";
            OrderLabel.Size = new Size(100, 15);
            OrderLabel.TabIndex = 2;
            OrderLabel.Text = "Volgordenummer";
            // 
            // OrderBox
            // 
            OrderBox.Location = new Point(219, 85);
            OrderBox.Name = "OrderBox";
            OrderBox.Size = new Size(100, 23);
            OrderBox.TabIndex = 3;
            // 
            // TestLabel
            // 
            TestLabel.AutoSize = true;
            TestLabel.Location = new Point(389, 206);
            TestLabel.Name = "TestLabel";
            TestLabel.Size = new Size(40, 15);
            TestLabel.TabIndex = 4;
            TestLabel.Text = "Testen";
            // 
            // TestenBox
            // 
            TestenBox.Location = new Point(389, 224);
            TestenBox.Multiline = true;
            TestenBox.Name = "TestenBox";
            TestenBox.Size = new Size(286, 173);
            TestenBox.TabIndex = 5;
            // 
            // IntevalLabel
            // 
            IntevalLabel.AutoSize = true;
            IntevalLabel.Location = new Point(389, 67);
            IntevalLabel.Name = "IntevalLabel";
            IntevalLabel.Size = new Size(46, 15);
            IntevalLabel.TabIndex = 6;
            IntevalLabel.Text = "Interval";
            // 
            // IntervalBox
            // 
            IntervalBox.Location = new Point(389, 85);
            IntervalBox.Name = "IntervalBox";
            IntervalBox.Size = new Size(100, 23);
            IntervalBox.TabIndex = 7;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(43, 206);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(59, 15);
            DescriptionLabel.TabIndex = 10;
            DescriptionLabel.Text = "Descriptie";
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(43, 224);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(340, 173);
            DescriptionBox.TabIndex = 11;
            // 
            // AddStep
            // 
            AddStep.Location = new Point(681, 374);
            AddStep.Name = "AddStep";
            AddStep.Size = new Size(75, 23);
            AddStep.TabIndex = 12;
            AddStep.Text = "Klaar";
            AddStep.UseVisualStyleBackColor = true;
            AddStep.Click += AddStep_Click;
            // 
            // AddStepForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddStep);
            Controls.Add(DescriptionBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(IntervalBox);
            Controls.Add(IntevalLabel);
            Controls.Add(TestenBox);
            Controls.Add(TestLabel);
            Controls.Add(OrderBox);
            Controls.Add(OrderLabel);
            Controls.Add(NameBox);
            Controls.Add(NaamLabel);
            Name = "AddStepForm";
            Text = "AddStepForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NaamLabel;
        private TextBox NameBox;
        private Label OrderLabel;
        private TextBox OrderBox;
        private Label TestLabel;
        private TextBox TestenBox;
        private Label IntevalLabel;
        private TextBox IntervalBox;
        private Label DescriptionLabel;
        private TextBox DescriptionBox;
        private Button AddStep;
    }
}