using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
protected void Page_Load(object sender, EventArgs e)
{
if(!IsPostBack)
{
BindRepeaterData();
}
}
// This button click event is used to insert comment details and bind data to repeater control
protected void btnSubmit_Click(object sender, EventArgs e)
{
    con.Open();
    SqlCommand cmd = new SqlCommand("insert into Repeater_Table (UserName,Subject,Comment,PostedDate) values(@userName,@subject,@comment,@postedDate)", con);
    cmd.Parameters.AddWithValue("@userName", txtName.Text);
    cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
    cmd.Parameters.AddWithValue("@comment", txtComment.Text);
    cmd.Parameters.AddWithValue("@postedDate", DateTime.Now);
    cmd.ExecuteNonQuery();
    con.Close();
    txtName.Text = string.Empty;
    txtSubject.Text = string.Empty;
    txtComment.Text = string.Empty;
    BindRepeaterData();
}
//Bind Data to Repeater Control
protected void BindRepeaterData()
{
    con.Open();
    SqlCommand cmd = new SqlCommand("select * from Repeater_Table Order By PostedDate desc", con);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(ds);
    if(ds.Tables[0].Rows.Count>0)
    {
            RepDetails.Visible = true;
            RepDetails.DataSource = ds;
            RepDetails.DataBind();
    }
    else
    {
        RepDetails.Visible = false;
    }

    con.Close();
    }
}
