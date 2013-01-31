using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PostMedicine();
        }
    }

    void PostMedicine()
    {
        gvdetails.DataSource = ClassDataManager.AllDrugz();
        gvdetails.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnPDF_Click(object sender, ImageClickEventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvdetails.AllowPaging = false;
        PostMedicine();
        gvdetails.RenderControl(hw);
        gvdetails.HeaderRow.Style.Add("width", "15%");
        gvdetails.HeaderRow.Style.Add("font-size", "10px");
        gvdetails.Style.Add("text-decoration", "none");
        gvdetails.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        gvdetails.Style.Add("font-size", "8px");
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
     }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
                 string.Format("attachment; filename={0}", "EmpInfo.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvdetails.AllowPaging = false;
            PostMedicine();
            //Change the Header Row back to white color
            gvdetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < gvdetails.HeaderRow.Cells.Count; i++)
            {
                gvdetails.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            //This loop is used to apply stlye to cells based on particular row
            foreach (GridViewRow gvrow in gvdetails.Rows)
            {
                //gvrow.BackColor = Color.W;
                if (j <= gvdetails.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            gvdetails.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            string ErrMsg = ex.Message;
        }
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow =
                 new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Half Part 1";
            HeaderCell.ColumnSpan = 4;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Half Part 2";
            HeaderCell.ColumnSpan = 4;
            HeaderGridRow.Cells.Add(HeaderCell);

            gvdetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        PostMedicine();
    }
}
