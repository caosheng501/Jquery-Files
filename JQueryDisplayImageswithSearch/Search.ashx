<%@ WebHandler Language="C#" Class="Search" %>

using System;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Services;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Search : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        string searchText = context.Request.QueryString["q"];
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select Product_Num,Product_Name,ImageName from PRODUCT where Product_Name Like @Search + '%'", con);
        cmd.Parameters.AddWithValue("@Search",searchText);
        StringBuilder sb = new StringBuilder();
        using(SqlDataReader dr=cmd.ExecuteReader())
        {
            while(dr.Read())
            {
                sb.Append(string.Format("{0},{1}{2}", dr["Product_Name"], dr["ImageName"], Environment.NewLine));
            }
        }
        con.Close();
        context.Response.Write(sb.ToString());

        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

