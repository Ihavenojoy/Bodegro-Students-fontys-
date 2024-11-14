namespace Bodegro
{
    partial class MainPage
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
            PatientListBox = new ListBox();
            AddPatientButton = new Button();
            AddProtocolToPatientButton = new Button();
            CreatePatientButton = new Button();
            CreateArtsButton = new Button();
            CreateUserButton = new Button();
            ComboUserBox = new ComboBox();
            UserTextLable = new Label();
            SuspendLayout();
            // 
            // PatientListBox
            // 
            PatientListBox.FormattingEnabled = true;
            PatientListBox.ItemHeight = 15;
            PatientListBox.Location = new Point(463, 77);
            PatientListBox.Name = "PatientListBox";
            PatientListBox.Size = new Size(507, 439);
            PatientListBox.TabIndex = 0;
            // 
            // AddPatientButton
            // 
            AddPatientButton.Location = new Point(291, 77);
            AddPatientButton.Name = "AddPatientButton";
            AddPatientButton.Size = new Size(135, 23);
            AddPatientButton.TabIndex = 1;
            AddPatientButton.Text = "Toevoegen patiënt";
            AddPatientButton.UseVisualStyleBackColor = true;
            AddPatientButton.Click += AddPatientButton_Click;
            // 
            // AddProtocolToPatientButton
            // 
            AddProtocolToPatientButton.Location = new Point(291, 120);
            AddProtocolToPatientButton.Name = "AddProtocolToPatientButton";
            AddProtocolToPatientButton.Size = new Size(135, 23);
            AddProtocolToPatientButton.TabIndex = 2;
            AddProtocolToPatientButton.Text = "Toevoegen protocol";
            AddProtocolToPatientButton.UseVisualStyleBackColor = true;
            AddProtocolToPatientButton.Click += AddProtocolToPatientButton_Click;
            // 
            // CreatePatientButton
            // 
            CreatePatientButton.Location = new Point(803, 48);
            CreatePatientButton.Name = "CreatePatientButton";
            CreatePatientButton.Size = new Size(128, 23);
            CreatePatientButton.TabIndex = 3;
            CreatePatientButton.Text = "Nieuwe Patiënt";
            CreatePatientButton.UseVisualStyleBackColor = true;
            CreatePatientButton.Click += CreatePatientButton_Click;
            // 
            // CreateArtsButton
            // 
            CreateArtsButton.Location = new Point(669, 48);
            CreateArtsButton.Name = "CreateArtsButton";
            CreateArtsButton.Size = new Size(128, 23);
            CreateArtsButton.TabIndex = 4;
            CreateArtsButton.Text = "Nieuwe Arts";
            CreateArtsButton.UseVisualStyleBackColor = true;
            CreateArtsButton.Click += CreateArtsButton_Click;
            // 
            // CreateUserButton
            // 
            CreateUserButton.Location = new Point(535, 48);
            CreateUserButton.Name = "CreateUserButton";
            CreateUserButton.Size = new Size(128, 23);
            CreateUserButton.TabIndex = 5;
            CreateUserButton.Text = "Nieuwe beheerders";
            CreateUserButton.UseVisualStyleBackColor = true;
            CreateUserButton.Click += CreateUserButton_Click;
            // 
            // ComboUserBox
            // 
            ComboUserBox.FormattingEnabled = true;
            ComboUserBox.Location = new Point(56, 12);
            ComboUserBox.Name = "ComboUserBox";
            ComboUserBox.Size = new Size(200, 23);
            ComboUserBox.TabIndex = 6;
            ComboUserBox.SelectedIndexChanged += ComboUserBox_SelectedIndexChanged;
            // 
            // UserTextLable
            // 
            UserTextLable.AutoSize = true;
            UserTextLable.Location = new Point(12, 15);
            UserTextLable.Name = "UserTextLable";
            UserTextLable.Size = new Size(43, 15);
            UserTextLable.TabIndex = 7;
            UserTextLable.Text = "User";
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 655);
            Controls.Add(UserTextLable);
            Controls.Add(ComboUserBox);
            Controls.Add(CreateUserButton);
            Controls.Add(CreateArtsButton);
            Controls.Add(CreatePatientButton);
            Controls.Add(AddProtocolToPatientButton);
            Controls.Add(AddPatientButton);
            Controls.Add(PatientListBox);
            Name = "MainPage";
            Text = "MainPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox PatientListBox;
        private Button AddPatientButton;
        private Button AddProtocolToPatientButton;
        private Button CreatePatientButton;
        private Button CreateArtsButton;
        private Button CreateUserButton;
        private ComboBox ComboUserBox;
        private Label UserTextLable;
    }
}