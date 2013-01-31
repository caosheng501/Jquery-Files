using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trirand.Web.UI.WebControls;

public partial class demotreeview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string message = "Expanded nodes: ";
        if (JQTreeView1.CheckedNodes.Count == 0)
            message += " none";
        else
        {
            foreach (JQTreeNode node in JQTreeView1.CheckedNodes)
            {
                message += node.Text + "; ";
            }
        }

        SelectedNodeMessage.Text = message;
    }
}
