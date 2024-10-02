namespace Bodegro
{
    partial class NewSubscription
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
            Confirm = new Button();
            ProtocolBox = new ListBox();
            PatientBox = new ListBox();
            StartDate = new DateTimePicker();
            EndDate = new DateTimePicker();
            SuspendLayout();
            // 
            // Confirm
            // 
            Confirm.Location = new Point(610, 393);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(75, 23);
            Confirm.TabIndex = 0;
            Confirm.Text = "Bevestig";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // ProtocolBox
            // 
            ProtocolBox.FormattingEnabled = true;
            ProtocolBox.ItemHeight = 15;
            ProtocolBox.Location = new Point(43, 37);
            ProtocolBox.Name = "ProtocolBox";
            ProtocolBox.Size = new Size(239, 379);
            ProtocolBox.TabIndex = 1;
            // 
            // PatientBox
            // 
            PatientBox.FormattingEnabled = true;
            PatientBox.ItemHeight = 15;
            PatientBox.Location = new Point(326, 37);
            PatientBox.Name = "PatientBox";
            PatientBox.Size = new Size(239, 379);
            PatientBox.TabIndex = 2;
            // 
            // StartDate
            // 
            StartDate.Location = new Point(588, 37);
            StartDate.MinDate = new DateTime(2024, 10, 2, 0, 0, 0, 0);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(200, 23);
            StartDate.TabIndex = 3;
            StartDate.Value = new DateTime(2024, 10, 25, 23, 59, 59, 0);
            // 
            // EndDate
            // 
            EndDate.Location = new Point(588, 66);
            EndDate.Name = "EndDate";
            EndDate.Size = new Size(200, 23);
            EndDate.TabIndex = 4;
            // 
            // NewSubscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EndDate);
            Controls.Add(StartDate);
            Controls.Add(PatientBox);
            Controls.Add(ProtocolBox);
            Controls.Add(Confirm);
            Name = "NewSubscription";
            Text = "NewSubscription";
            ResumeLayout(false);
        }

        #endregion

        private Button Confirm;
        private ListBox ProtocolBox;
        private ListBox PatientBox;
        private DateTimePicker StartDate;
        private DateTimePicker EndDate;
    }
}