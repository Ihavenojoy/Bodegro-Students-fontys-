namespace Bodegro
{
    partial class LinkArtsAanPatient
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
            PatientList = new ComboBox();
            AllDoctorsBox = new ComboBox();
            LinkButton = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // PatientList
            // 
            PatientList.FormattingEnabled = true;
            PatientList.Location = new Point(263, 64);
            PatientList.Name = "PatientList";
            PatientList.Size = new Size(192, 28);
            PatientList.TabIndex = 0;
            PatientList.SelectedIndexChanged += PatientList_SelectedIndexChanged;
            // 
            // AllDoctorsBox
            // 
            AllDoctorsBox.FormattingEnabled = true;
            AllDoctorsBox.Location = new Point(38, 64);
            AllDoctorsBox.Name = "AllDoctorsBox";
            AllDoctorsBox.Size = new Size(151, 28);
            AllDoctorsBox.TabIndex = 1;
            AllDoctorsBox.SelectedIndexChanged += AllDoctorsBox_SelectedIndexChanged;
            // 
            // LinkButton
            // 
            LinkButton.Location = new Point(38, 195);
            LinkButton.Name = "LinkButton";
            LinkButton.Size = new Size(178, 29);
            LinkButton.TabIndex = 2;
            LinkButton.Text = "Link patient To Doctor";
            LinkButton.UseVisualStyleBackColor = true;
            LinkButton.Click += LinkButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 40);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 3;
            label1.Text = "Doctor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 41);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 4;
            label2.Text = "Patient:";
            // 
            // LinkArtsAanPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LinkButton);
            Controls.Add(AllDoctorsBox);
            Controls.Add(PatientList);
            Name = "LinkArtsAanPatient";
            Text = "LinkArtsAanPatient";
            Load += LinkArtsAanPatient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox PatientList;
        private ComboBox AllDoctorsBox;
        private Button LinkButton;
        private Label label1;
        private Label label2;
    }
}