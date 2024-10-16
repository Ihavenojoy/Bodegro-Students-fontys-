namespace Bodegro
{
    partial class CreateUser
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
            tabControl1 = new TabControl();
            Gebruiker = new TabPage();
            btnDeleteUser = new Button();
            label6 = new Label();
            lbAdmin = new ListBox();
            groupBox1 = new GroupBox();
            rbDoctor = new RadioButton();
            rbAdmin = new RadioButton();
            btnCreateUser = new Button();
            label5 = new Label();
            lbDoctors = new ListBox();
            cbRegioUser = new ComboBox();
            tbPasswordUser = new TextBox();
            tbEmailUser = new TextBox();
            tbNameUser = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            tbMedical = new TextBox();
            label11 = new Label();
            tbTelefoon = new TextBox();
            label10 = new Label();
            tbPatientEmail = new TextBox();
            tbPatientName = new TextBox();
            label7 = new Label();
            label8 = new Label();
            btnDeletePatient = new Button();
            btnCreatePatient = new Button();
            lbPatient = new Label();
            listBoxPatient = new ListBox();
            tabControl1.SuspendLayout();
            Gebruiker.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Gebruiker);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1192, 693);
            tabControl1.TabIndex = 0;
            // 
            // Gebruiker
            // 
            Gebruiker.Controls.Add(btnDeleteUser);
            Gebruiker.Controls.Add(label6);
            Gebruiker.Controls.Add(lbAdmin);
            Gebruiker.Controls.Add(groupBox1);
            Gebruiker.Controls.Add(btnCreateUser);
            Gebruiker.Controls.Add(label5);
            Gebruiker.Controls.Add(lbDoctors);
            Gebruiker.Controls.Add(cbRegioUser);
            Gebruiker.Controls.Add(tbPasswordUser);
            Gebruiker.Controls.Add(tbEmailUser);
            Gebruiker.Controls.Add(tbNameUser);
            Gebruiker.Controls.Add(label4);
            Gebruiker.Controls.Add(label3);
            Gebruiker.Controls.Add(label2);
            Gebruiker.Controls.Add(label1);
            Gebruiker.Location = new Point(4, 29);
            Gebruiker.Name = "Gebruiker";
            Gebruiker.Padding = new Padding(3);
            Gebruiker.Size = new Size(1184, 660);
            Gebruiker.TabIndex = 0;
            Gebruiker.Text = "Gebruiker";
            Gebruiker.UseVisualStyleBackColor = true;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(334, 575);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(105, 29);
            btnDeleteUser.TabIndex = 33;
            btnDeleteUser.Text = "Verwijderen";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(401, 57);
            label6.Name = "label6";
            label6.Size = new Size(56, 20);
            label6.TabIndex = 30;
            label6.Text = "Admin:";
            // 
            // lbAdmin
            // 
            lbAdmin.FormattingEnabled = true;
            lbAdmin.Location = new Point(401, 89);
            lbAdmin.Name = "lbAdmin";
            lbAdmin.Size = new Size(185, 384);
            lbAdmin.TabIndex = 29;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbDoctor);
            groupBox1.Controls.Add(rbAdmin);
            groupBox1.Location = new Point(114, 89);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(195, 128);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gebruiker";
            // 
            // rbDoctor
            // 
            rbDoctor.AutoSize = true;
            rbDoctor.Location = new Point(6, 84);
            rbDoctor.Name = "rbDoctor";
            rbDoctor.Size = new Size(56, 24);
            rbDoctor.TabIndex = 13;
            rbDoctor.TabStop = true;
            rbDoctor.Text = "Arts";
            rbDoctor.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            rbAdmin.AutoSize = true;
            rbAdmin.Location = new Point(6, 50);
            rbAdmin.Name = "rbAdmin";
            rbAdmin.Size = new Size(74, 24);
            rbAdmin.TabIndex = 12;
            rbAdmin.TabStop = true;
            rbAdmin.Text = "Admin";
            rbAdmin.UseVisualStyleBackColor = true;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(215, 575);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(113, 29);
            btnCreateUser.TabIndex = 27;
            btnCreateUser.Text = "Maak";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(663, 57);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 26;
            label5.Text = "Arts:";
            // 
            // lbDoctors
            // 
            lbDoctors.FormattingEnabled = true;
            lbDoctors.Location = new Point(663, 89);
            lbDoctors.Name = "lbDoctors";
            lbDoctors.Size = new Size(185, 384);
            lbDoctors.TabIndex = 25;
            // 
            // cbRegioUser
            // 
            cbRegioUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRegioUser.FormattingEnabled = true;
            cbRegioUser.Items.AddRange(new object[] { "Zuid_Holland_Zuid", "Amsterdam", "Brabant_Zuidoost", "Drente", "Flevoland", "Fryslân", "Gerderland_Zuid", "Gooi_en_Vechtstreek", "Groningen", "Haaglanden", "Hart_voor_Brabant", "Hollands_Midden", "Hollands_Noorden", "Ijsselland", "Kennemerland", "Limburg_Noord", "Noord__en_Oost_Gelderland", "regio_Utrecht", "Rotterdam_Rijnmond", "Twente", "West_Brabant", "Zaanstreek_Waterland", "Zeeland", "Zuid_Limburg", "Gelderland_Midden" });
            cbRegioUser.Location = new Point(215, 499);
            cbRegioUser.Name = "cbRegioUser";
            cbRegioUser.Size = new Size(125, 28);
            cbRegioUser.TabIndex = 24;
            // 
            // tbPasswordUser
            // 
            tbPasswordUser.Location = new Point(215, 439);
            tbPasswordUser.Name = "tbPasswordUser";
            tbPasswordUser.Size = new Size(125, 27);
            tbPasswordUser.TabIndex = 23;
            tbPasswordUser.UseSystemPasswordChar = true;
            // 
            // tbEmailUser
            // 
            tbEmailUser.Location = new Point(215, 373);
            tbEmailUser.Name = "tbEmailUser";
            tbEmailUser.Size = new Size(125, 27);
            tbEmailUser.TabIndex = 22;
            // 
            // tbNameUser
            // 
            tbNameUser.Location = new Point(215, 311);
            tbNameUser.Name = "tbNameUser";
            tbNameUser.Size = new Size(125, 27);
            tbNameUser.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(114, 499);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 20;
            label4.Text = "Regio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 439);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 19;
            label3.Text = "Wachtwoord:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 373);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 18;
            label2.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 311);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 17;
            label1.Text = "Naam:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tbMedical);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(tbTelefoon);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(tbPatientEmail);
            tabPage2.Controls.Add(tbPatientName);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(btnDeletePatient);
            tabPage2.Controls.Add(btnCreatePatient);
            tabPage2.Controls.Add(lbPatient);
            tabPage2.Controls.Add(listBoxPatient);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1184, 660);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Patient";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbMedical
            // 
            tbMedical.Location = new Point(218, 213);
            tbMedical.Name = "tbMedical";
            tbMedical.Size = new Size(125, 27);
            tbMedical.TabIndex = 46;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(43, 220);
            label11.Name = "label11";
            label11.Size = new Size(169, 20);
            label11.TabIndex = 45;
            label11.Text = "Medische geschoedenis:";
            // 
            // tbTelefoon
            // 
            tbTelefoon.Location = new Point(218, 170);
            tbTelefoon.Name = "tbTelefoon";
            tbTelefoon.Size = new Size(125, 27);
            tbTelefoon.TabIndex = 44;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(41, 170);
            label10.Name = "label10";
            label10.Size = new Size(125, 20);
            label10.TabIndex = 43;
            label10.Text = "Telefoonnummer:";
            // 
            // tbPatientEmail
            // 
            tbPatientEmail.Location = new Point(218, 131);
            tbPatientEmail.Name = "tbPatientEmail";
            tbPatientEmail.Size = new Size(125, 27);
            tbPatientEmail.TabIndex = 40;
            // 
            // tbPatientName
            // 
            tbPatientName.Location = new Point(218, 94);
            tbPatientName.Name = "tbPatientName";
            tbPatientName.Size = new Size(125, 27);
            tbPatientName.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 131);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 38;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 94);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 37;
            label8.Text = "Naam:";
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.Location = new Point(419, 492);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(105, 29);
            btnDeletePatient.TabIndex = 36;
            btnDeletePatient.Text = "Verwijderen";
            btnDeletePatient.UseVisualStyleBackColor = true;
            // 
            // btnCreatePatient
            // 
            btnCreatePatient.Location = new Point(218, 295);
            btnCreatePatient.Name = "btnCreatePatient";
            btnCreatePatient.Size = new Size(113, 29);
            btnCreatePatient.TabIndex = 35;
            btnCreatePatient.Text = "Maak";
            btnCreatePatient.UseVisualStyleBackColor = true;
            // 
            // lbPatient
            // 
            lbPatient.AutoSize = true;
            lbPatient.Location = new Point(419, 37);
            lbPatient.Name = "lbPatient";
            lbPatient.Size = new Size(57, 20);
            lbPatient.TabIndex = 34;
            lbPatient.Text = "Patient:";
            // 
            // listBoxPatient
            // 
            listBoxPatient.FormattingEnabled = true;
            listBoxPatient.Location = new Point(419, 69);
            listBoxPatient.Name = "listBoxPatient";
            listBoxPatient.Size = new Size(185, 384);
            listBoxPatient.TabIndex = 33;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 693);
            Controls.Add(tabControl1);
            Name = "CreateUser";
            Text = "CreateUser";
            tabControl1.ResumeLayout(false);
            Gebruiker.ResumeLayout(false);
            Gebruiker.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Gebruiker;
        private Button btnDeleteUser;
        private Label label6;
        private ListBox lbAdmin;
        private GroupBox groupBox1;
        private RadioButton rbDoctor;
        private RadioButton rbAdmin;
        private Button btnCreateUser;
        private Label label5;
        private ListBox lbDoctors;
        private ComboBox cbRegioUser;
        private TextBox tbPasswordUser;
        private TextBox tbEmailUser;
        private TextBox tbNameUser;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabPage2;
        private Label lbPatient;
        private ListBox listBoxPatient;
        private TextBox tbTelefoon;
        private Label label10;
        private TextBox tbPatientEmail;
        private TextBox tbPatientName;
        private Label label7;
        private Label label8;
        private Button btnDeletePatient;
        private Button btnCreatePatient;
        private TextBox tbMedical;
        private Label label11;
    }
}