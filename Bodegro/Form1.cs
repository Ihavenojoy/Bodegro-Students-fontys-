namespace Bodegro;
using Twofactor;
using Domain.Enums;
using Domain.Modules;
using System.Net.Mail;
using DAL;
using Microsoft.Extensions.Configuration;
using System.Data;

public partial class Form1 : Form
{
    Email email;
    private readonly IConfiguration iConfiguration;
    public Form1()
    {
        InitializeComponent();
        email = new Email("",EmailBody.TWOFACTOR);
        InlogPagina inlog = new InlogPagina(new UserDAL(iConfiguration));
        inlog.Show();
        this.Shown += (s, e) => this.Hide();
    }

    private void TestButton_Click(object sender, EventArgs e)
    {
        User User = new User("Henry", "test@gmail.com", Role.User);
        //MessageBox.Show(Convert.ToString(Generate.OTP)); // Greate OTP without key (does nothing)
        //MessageBox.Show(Convert.ToString(Generate.RandomKey)); //Generates Key (not stringable)
        MessageBox.Show(Convert.ToString(Code32.Encode(Generate.RandomKey(32)))); // Generates a Readable Key
        MessageBox.Show(Generate.OTP(Code32.Encode(Generate.RandomKey(32)), 6, 30)); // Generates a OTP
        this.Hide();
        NewSubscription newSubscription = new NewSubscription(User);
        newSubscription.Closed += (s, args) => this.Close();
        newSubscription.Show();
        AddProtocolForm addProtocolForm = new AddProtocolForm(User);
        addProtocolForm.Closed += (s, args) => this.Close();
        addProtocolForm.Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }
}