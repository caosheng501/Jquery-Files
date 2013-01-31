using System;
using System.Drawing;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblResult.Visible = true;
        lblResult.Text = "Successfully Validated all the controls";
        lblResult.ForeColor = Color.Green;
    }
}
