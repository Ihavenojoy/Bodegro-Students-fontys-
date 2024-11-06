namespace Bodegro;
using Bodegro2FALibrary;
using Domain.Enums;
using Domain.Modules;
using System.Net.Mail;

public partial class Form1 : Form
{
    Email email;
    public Form1()
    {
        InitializeComponent();
        email = new Email();
    }

    private void TestButton_Click(object sender, EventArgs e)
    {
        Doctor doctor = new Doctor("Henry", "test@gmail.com", Regio.Hart_voor_Brabant,1,true);
        Admin admin = new Admin(1, "Henk", "temp@gmail.com");
        //MessageBox.Show(Convert.ToString(Generate.OTP)); // Greate OTP without key (does nothing)
        //MessageBox.Show(Convert.ToString(Generate.RandomKey)); //Generates Key (not stringable)
        MessageBox.Show(Convert.ToString(Code32.Encode(Generate.RandomKey(32)))); // Generates a Readable Key
        MessageBox.Show(Generate.OTP(Code32.Encode(Generate.RandomKey(32)), 6, 30)); // Generates a OTP
        this.Hide();
        NewSubscription newSubscription = new NewSubscription(doctor);
        newSubscription.Closed += (s, args) => this.Close();
        newSubscription.Show();
        InlogPagina inlog = new InlogPagina();
        if (inlog.ShowDialog() == DialogResult.OK && inlog.inlog == true)
        {

        }
        AddProtocolForm addProtocolForm = new AddProtocolForm(admin);
        addProtocolForm.Closed += (s, args) => this.Close();
        addProtocolForm.Show();
        CreateUser createUser = new CreateUser();
        createUser.Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        MailMessage message = email.MailMessage("bodegro.students.fontys@outlook.com", "Luuk.heesbeen@hotmail.com", "Testing the email");
        email.SendEmail(message);
    }
}
