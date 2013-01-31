using System;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage Msg = new MailMessage();
            // Sender e-mail address.
            Msg.From = new MailAddress(txtEmail.Text);
            // Recipient e-mail address.
            Msg.To.Add("duldulaojakes@gmail.com");
            Msg.Subject = txtSubject.Text;
            Msg.Body = txtMessage.Text;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("duldulaojakes@gmail.com", "123jakes123");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            //Msg = null;
            lbltxt.Text = "Thanks for Contact us";
            // Clear the textbox valuess
            txtName.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
            txtEmail.Text = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
    }
}
