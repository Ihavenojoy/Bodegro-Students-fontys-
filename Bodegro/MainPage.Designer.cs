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
            CreateAdminButton = new Button();
            ComboDoctorBox = new ComboBox();
            DoctorTextLable = new Label();
            LinkArtsAanDoktor = new Button();
            SuspendLayout();
            // 
            // PatientListBox
            // 
            PatientListBox.FormattingEnabled = true;
            PatientListBox.Location = new Point(529, 103);
            PatientListBox.Margin = new Padding(3, 4, 3, 4);
            PatientListBox.Name = "PatientListBox";
            PatientListBox.Size = new Size(579, 584);
            PatientListBox.TabIndex = 0;
            // 
            // AddPatientButton
            // 
            AddPatientButton.Location = new Point(333, 103);
            AddPatientButton.Margin = new Padding(3, 4, 3, 4);
            AddPatientButton.Name = "AddPatientButton";
            AddPatientButton.Size = new Size(154, 31);
            AddPatientButton.TabIndex = 1;
            AddPatientButton.Text = "Toevoegen patiënt";
            AddPatientButton.UseVisualStyleBackColor = true;
            AddPatientButton.Click += AddPatientButton_Click;
            // 
            // AddProtocolToPatientButton
            // 
            AddProtocolToPatientButton.Location = new Point(333, 160);
            AddProtocolToPatientButton.Margin = new Padding(3, 4, 3, 4);
            AddProtocolToPatientButton.Name = "AddProtocolToPatientButton";
            AddProtocolToPatientButton.Size = new Size(154, 31);
            AddProtocolToPatientButton.TabIndex = 2;
            AddProtocolToPatientButton.Text = "Toevoegen protocol";
            AddProtocolToPatientButton.UseVisualStyleBackColor = true;
            AddProtocolToPatientButton.Click += AddProtocolToPatientButton_Click;
            // 
            // CreatePatientButton
            // 
            CreatePatientButton.Location = new Point(918, 64);
            CreatePatientButton.Margin = new Padding(3, 4, 3, 4);
            CreatePatientButton.Name = "CreatePatientButton";
            CreatePatientButton.Size = new Size(146, 31);
            CreatePatientButton.TabIndex = 3;
            CreatePatientButton.Text = "Nieuwe Patiënt";
            CreatePatientButton.UseVisualStyleBackColor = true;
            CreatePatientButton.Click += CreatePatientButton_Click;
            // 
            // CreateArtsButton
            // 
            CreateArtsButton.Location = new Point(765, 64);
            CreateArtsButton.Margin = new Padding(3, 4, 3, 4);
            CreateArtsButton.Name = "CreateArtsButton";
            CreateArtsButton.Size = new Size(146, 31);
            CreateArtsButton.TabIndex = 4;
            CreateArtsButton.Text = "Nieuwe Arts";
            CreateArtsButton.UseVisualStyleBackColor = true;
            CreateArtsButton.Click += CreateArtsButton_Click;
            // 
            // CreateAdminButton
            // 
            CreateAdminButton.Location = new Point(611, 64);
            CreateAdminButton.Margin = new Padding(3, 4, 3, 4);
            CreateAdminButton.Name = "CreateAdminButton";
            CreateAdminButton.Size = new Size(146, 31);
            CreateAdminButton.TabIndex = 5;
            CreateAdminButton.Text = "Nieuwe beheerders";
            CreateAdminButton.UseVisualStyleBackColor = true;
            CreateAdminButton.Click += CreateAdminButton_Click;
            // 
            // ComboDoctorBox
            // 
            ComboDoctorBox.FormattingEnabled = true;
            ComboDoctorBox.Location = new Point(64, 16);
            ComboDoctorBox.Margin = new Padding(3, 4, 3, 4);
            ComboDoctorBox.Name = "ComboDoctorBox";
            ComboDoctorBox.Size = new Size(228, 28);
            ComboDoctorBox.TabIndex = 6;
            ComboDoctorBox.SelectedIndexChanged += ComboDoctorBox_SelectedIndexChanged;
            // 
            // DoctorTextLable
            // 
            DoctorTextLable.AutoSize = true;
            DoctorTextLable.Location = new Point(14, 20);
            DoctorTextLable.Name = "DoctorTextLable";
            DoctorTextLable.Size = new Size(55, 20);
            DoctorTextLable.TabIndex = 7;
            DoctorTextLable.Text = "Doctor";
            // 
            // LinkArtsAanDoktor
            // 
            LinkArtsAanDoktor.Location = new Point(333, 529);
            LinkArtsAanDoktor.Margin = new Padding(3, 4, 3, 4);
            LinkArtsAanDoktor.Name = "LinkArtsAanDoktor";
            LinkArtsAanDoktor.Size = new Size(154, 31);
            LinkArtsAanDoktor.TabIndex = 8;
            LinkArtsAanDoktor.Text = "Link arts aan Doctor";
            LinkArtsAanDoktor.UseVisualStyleBackColor = true;
            LinkArtsAanDoktor.Click += LinkArtsAanDoktor_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 873);
            Controls.Add(LinkArtsAanDoktor);
            Controls.Add(DoctorTextLable);
            Controls.Add(ComboDoctorBox);
            Controls.Add(CreateAdminButton);
            Controls.Add(CreateArtsButton);
            Controls.Add(CreatePatientButton);
            Controls.Add(AddProtocolToPatientButton);
            Controls.Add(AddPatientButton);
            Controls.Add(PatientListBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainPage";
            Text = "MainPage";
            Load += MainPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox PatientListBox;
        private Button AddPatientButton;
        private Button AddProtocolToPatientButton;
        private Button CreatePatientButton;
        private Button CreateArtsButton;
        private Button CreateAdminButton;
        private ComboBox ComboDoctorBox;
        private Label DoctorTextLable;
        private Button LinkArtsAanDoktor;
    }
}