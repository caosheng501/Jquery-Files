using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ClassFields
/// </summary>
public class ClassFields
{
	public ClassFields()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long IllnessID { set; get; }
    public long userID { set; get; }
    public string Members { set; get; }
    public string usercodename { set; get; }
    public string userpassword { set; get; }

    public string IllnessName { set; get; }

    public long DrugclassID { set; get; }
    public string TreatmentDescription { set; get; }

    //public long ThreadID { set; get; }
    public string Symptoms { set; get; }
    public string AvailableForms { set; get; }

    public long DrugID { set; get; }
    public string DrugName { set; get; }
    public string GenericName { set; get; }
    public string BrandName { set; get; }

    //public long ThreadStatus { set; get; }
    //public long ThreadViewCount { set; get; }
    public string SideEffects { set; get; }
    public string Dosage { set; get; }
    public string WarningsDescription { set; get; }
    public string drugClass { set; get; }

    //public string UserBy { set; get; }

    //public string Names { set; get; }

    //public string Withtopics { set; get; }
}
