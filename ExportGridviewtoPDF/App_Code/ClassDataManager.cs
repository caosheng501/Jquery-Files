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
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClassDataManager
/// </summary>
public class ClassDataManager
{
    SqlConnection con = null;
	public ClassDataManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static List<ClassFields> Illness_Load()
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT * FROM tbl_Illness ORDER BY IllnessName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.IllnessID = long.Parse(dr["IllnessID"].ToString());
                            f.IllnessName = dr["IllnessName"].ToString();
                            list.Add(f);
                        }
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> Warnings(double DID)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     tbl_Drugs.DrugName, tbl_Drugs.GenericName, tbl_Drugs.BrandName, tbl_Warnings.WarningsDescription   FROM         tbl_WaningsDrugs INNER JOIN tbl_Warnings ON tbl_WaningsDrugs.WarningID = tbl_Warnings.WarningsID INNER JOIN  tbl_Drugs ON tbl_WaningsDrugs.DrugID = tbl_Drugs.DrugID    WHERE tbl_WaningsDrugs.DrugID = '" + DID + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.WarningsDescription = "•" + dr["WarningsDescription"].ToString();
                            list.Add(f);
                        }
                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> Illness_LoadSearching(string ill)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT IllnessID,IllnessName FROM tbl_Illness WHERE IllnessName LIKE '" + ill + "%'ORDER BY IllnessName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.IllnessID = long.Parse(dr["IllnessID"].ToString());
                            f.IllnessName = dr["IllnessName"].ToString();
                            list.Add(f);
                        }
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> LoadTreatments(double IllnessID)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT * FROM tbl_Treatment WHERE IllnessID = '" + IllnessID + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.TreatmentDescription = "-->>     " + dr["TreatmentDescription"].ToString();
                            list.Add(f);
                        }
                    }
                    else 
                    {
                        ClassFields f = new ClassFields();
                        f.TreatmentDescription = "Unavailable";
                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> LoadSymptoms(double IllnessID)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT        tbl_Illness.IllnessName, tbl_Symptoms.Symptoms, tbl_Illness.IllnessID  FROM            tbl_Illness INNER JOIN tbl_IllnessSymptoms ON tbl_Illness.IllnessID = tbl_IllnessSymptoms.IllnessID INNER JOIN    tbl_Symptoms ON tbl_IllnessSymptoms.SymptomsID = tbl_Symptoms.SymptomsID WHERE tbl_Illness.IllnessID = '" + IllnessID + "'GROUP BY tbl_Illness.IllnessName, tbl_Symptoms.Symptoms, tbl_Illness.IllnessID";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.Symptoms = "-->>     " + dr["Symptoms"].ToString();
                            list.Add(f);
                        }
                    }
                    else 
                    {
                        ClassFields f = new ClassFields();
                        f.Symptoms = "Unavailable";
                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> UserMembers()
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT        TOP (100) PERCENT userID, userlname + ', ' + userfname + '   ' + usermname AS Members, usercodename, userpassword  FROM            dbo.tbl_UserClient   ORDER BY Members";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.userID = long.Parse(dr["userID"].ToString());
                            f.Members = dr["Members"].ToString();
                            f.usercodename = dr["usercodename"].ToString();
                            f.userpassword = dr["userpassword"].ToString();

                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                        f.userID = 0;
                        f.Members = "unavailable";
                        f.usercodename = "unavailable";
                        f.userpassword = "unavailable";

                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> UserMembersSearch(string userslname)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT        TOP (100) PERCENT userID, userlname + ', ' + userfname + '   ' + usermname AS Members, usercodename, userpassword  FROM            dbo.tbl_UserClient WHERE userlname LIKE '" + userslname + "%'ORDER BY Members";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.userID = long.Parse(dr["userID"].ToString());
                            f.Members = dr["Members"].ToString();
                            f.usercodename = dr["usercodename"].ToString();
                            f.userpassword = dr["userpassword"].ToString();

                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                        f.userID = 0;
                        f.Members = "unavailable";
                        f.usercodename = "unavailable";
                        f.userpassword = "unavailable";

                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> LoadMedicines(double IllnessID)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     tbl_Drugs.DrugID, tbl_Drugs.DrugName, tbl_Drugs.GenericName, tbl_Drugs.BrandName FROM         tbl_DrugIllness INNER JOIN   tbl_Drugs ON tbl_DrugIllness.DrugID = tbl_Drugs.DrugID INNER JOIN  tbl_Illness ON tbl_DrugIllness.IllnessID = tbl_Illness.IllnessID WHERE tbl_DrugIllness.IllnessID = '" + IllnessID + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugID = long.Parse(dr["DrugID"].ToString());
                            f.DrugName = dr["DrugName"].ToString();
                            f.GenericName = dr["GenericName"].ToString();
                            f.BrandName = dr["BrandName"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> LoadMedicinesSearchings(double IllnessID,string likename)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     TOP (100) PERCENT tbl_Drugs.DrugID, tbl_Drugs.DrugName, tbl_Drugs.GenericName, tbl_Drugs.BrandName  FROM         tbl_Drugs INNER JOIN  tbl_DrugIllness ON tbl_Drugs.DrugID = tbl_DrugIllness.DrugID INNER JOIN  tbl_Illness ON tbl_DrugIllness.IllnessID = tbl_Illness.IllnessID   WHERE tbl_DrugIllness.IllnessID =  '" + IllnessID + "'AND tbl_Drugs.DrugName LIKE '" + likename + "%'ORDER BY tbl_Drugs.DrugName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugID = long.Parse(dr["DrugID"].ToString());
                            f.DrugName = dr["DrugName"].ToString();
                            f.GenericName = dr["GenericName"].ToString();
                            f.BrandName = dr["BrandName"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> AllDrugz()
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT  * FROM tbl_Drugs ORDER BY DrugName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugID = long.Parse(dr["DrugID"].ToString());
                            f.DrugName = dr["DrugName"].ToString();
                            f.GenericName = dr["GenericName"].ToString();
                            f.BrandName = dr["BrandName"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> AllDrugClasses()
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT  * FROM tbl_DrugClass ORDER BY drugClass";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugclassID = long.Parse(dr["DrugclassID"].ToString());
                            f.drugClass = dr["drugClass"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> AllDrugClassesSearch(string dc)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT  * FROM tbl_DrugClass WHERE drugClass LIKE '" + dc + "%'ORDER BY drugClass";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugclassID = long.Parse(dr["DrugclassID"].ToString());
                            f.drugClass = dr["drugClass"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                        f.DrugclassID = 0;
                        f.drugClass = "0 Result";
                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> AllDrugzSearch(string names)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT * FROM tbl_Drugs WHERE DrugName LIKE '" + names + "%'ORDER BY DrugName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugID = long.Parse(dr["DrugID"].ToString());
                            f.DrugName = dr["DrugName"].ToString();
                            f.GenericName = dr["GenericName"].ToString();
                            f.BrandName = dr["BrandName"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                       // f.DrugID = long.Parse(dr["DrugID"].ToString());
                        f.DrugName = "No results Found." + "'" + names.ToString() + "'?";
                     
                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }

    public static List<ClassFields> DrugClass_Medecina(double drugclassid)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     TOP (100) PERCENT tbl_Drugs.DrugID, tbl_Drugs.DrugName, tbl_Drugs.GenericName, tbl_Drugs.BrandName, tbl_DrugClass.drugClass,     tbl_DrugClass.DrugclassID   FROM         tbl_Drugs INNER JOIN   tbl_MedicineDrugClass ON tbl_Drugs.DrugID = tbl_MedicineDrugClass.DrugID INNER JOIN   tbl_DrugClass ON tbl_MedicineDrugClass.DrugclassID = tbl_DrugClass.DrugclassID WHERE tbl_MedicineDrugClass.DrugclassID = '" + drugclassid + "'ORDER BY tbl_Drugs.DrugName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.DrugID = long.Parse(dr["DrugID"].ToString());
                            f.DrugName = dr["DrugName"].ToString();
                            f.GenericName = dr["GenericName"].ToString();
                            f.BrandName = dr["BrandName"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                        // f.DrugID = long.Parse(dr["DrugID"].ToString());
                        f.DrugName = "No results Found.";

                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> LoadSideEffects(double DrugIDs)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     tbl_Drugs.DrugID, tbl_Drugs.DrugName, tbl_SideEffects.SideEffectsID AS Expr1, tbl_SideEffects.SideEffects  FROM         tbl_drugSideEffects INNER JOIN  tbl_Drugs ON tbl_drugSideEffects.DrugID = tbl_Drugs.DrugID INNER JOIN   tbl_SideEffects ON tbl_drugSideEffects.SideEffectsID = tbl_SideEffects.SideEffectsID WHERE tbl_drugSideEffects.DrugID = '" + DrugIDs + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.SideEffects = dr["SideEffects"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> LoadDosage(double DrugIDs)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     tbl_Drugs.DrugName, tbl_Dosage.Dosage, tbl_Dosage.DosageID, tbl_Drugs.DrugID  FROM         tbl_Dosage INNER JOIN  tbl_DosageDrugs ON tbl_Dosage.DosageID = tbl_DosageDrugs.DosageID INNER JOIN       tbl_Drugs ON tbl_DosageDrugs.DrugID = tbl_Drugs.DrugID WHERE tbl_DosageDrugs.DrugID = '" + DrugIDs + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.Dosage = dr["Dosage"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> FormsAvailable(double DrugIDs)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     tbl_Drugs.DrugName, tbl_AvailableForms.AvailableForms   FROM         tbl_AvailableForms INNER JOIN    tbl_AvailableFormsDrugs ON tbl_AvailableForms.FormsID = tbl_AvailableFormsDrugs.FormsID INNER JOIN      tbl_Drugs ON tbl_AvailableFormsDrugs.DrugID = tbl_Drugs.DrugID    WHERE tbl_AvailableFormsDrugs.DrugID = '" + DrugIDs + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.AvailableForms = dr["AvailableForms"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                        f.AvailableForms = "On progress";
                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }


    public static List<ClassFields> LoadDrugClass(double DrugIDs)
    {
        List<ClassFields> list = new List<ClassFields>();
        using (SqlConnection conn = ClassConnection.ConnectToServer())
        {
            string sql = "SELECT     tbl_DrugClass.drugClass  FROM         tbl_Drugs INNER JOIN  tbl_MedicineDrugClass ON tbl_Drugs.DrugID = tbl_MedicineDrugClass.DrugID INNER JOIN    tbl_DrugClass ON tbl_MedicineDrugClass.DrugclassID = tbl_DrugClass.DrugclassID WHERE tbl_Drugs.DrugID = '" + DrugIDs + "'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ClassFields f = new ClassFields();
                            f.drugClass = ">>" + dr["drugClass"].ToString();
                            list.Add(f);
                        }
                    }
                    else
                    {
                        ClassFields f = new ClassFields();
                        f.drugClass = "--";
                        list.Add(f);
                    }
                }
            }
        }
        return list;
    }
    //add=============================================================
    public void AddIllness(string IN, double AID) 
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_Illness] (IllnessName,AdminID) Values (@IllnessName,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@IllnessName", IN.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally 
        {
            if (con != null)
                con.Close();
        }
    }

    public void AddHomeRemedies(string HR, double IID , double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_Treatment] (TreatmentDescription,IllnessID,AdminID) Values (@TreatmentDescription,@IllnessID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@TreatmentDescription", HR.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@IllnessID", double.Parse(IID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }


    public void AddDrugs_OILLNESS(double DID, double IID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_DrugIllness] (DrugID,IllnessID,AdminID) Values (@DrugID,@IllnessID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@DrugID", double.Parse(DID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@IllnessID", double.Parse(IID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }

    public void Addsymptoms_Proceed(double ILID,double SIMID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_IllnessSymptoms] (IllnessID,SymptomsID,AdminID) Values (@IllnessID,@SymptomsID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@IllnessID", double.Parse(ILID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@SymptomsID", double.Parse(SIMID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }

    public void Addsymptoms_Proceed2(double ILID, double SIMID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_IllnessSymptoms] (IllnessID,SymptomsID,AdminID) Values (@IllnessID,@SymptomsID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@IllnessID", double.Parse(ILID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@SymptomsID", double.Parse(SIMID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }



    public void Addsymptoms_NOW(string SP, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_Symptoms] (Symptoms,AdminID) Values (@Symptoms,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@Symptoms", SP.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (con != null)
                con.Close();
        }
    }



    public void AddMedicine(string DN, string GN, string BD, double AID) 
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_Drugs] (DrugName,GenericName,BrandName,AdminID) Values (@DrugName,@GenericName,@BrandName,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@DrugName", DN.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@GenericName", GN.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@BrandName", BD.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {
                
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally 
        {

            if (con != null)
                con.Close();
        }
    }


    public void AddForms(string AV, double AID) 
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_AvailableForms] (AvailableForms,AdminID) Values (@AvailableForms,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@AvailableForms", AV.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {
               
                
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

    public void AddFormsdrugs(double FID,double DID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_AvailableFormsDrugs] (FormsID,DrugID,AdminID) Values (@FormsID,@DrugID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@FormsID", double.Parse(FID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@DrugID", double.Parse(DID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

    private double s;
    public double S 
    {
        get { return s; }
        set { s = value; }
    }

    public void AddDrugsideEFFECTS(string SE, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_SideEffects] (SideEffects,AdminID) Values (@SideEffects,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@SideEffects", SE.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

    public void AddDRUG_CLASSNOW(string DC, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_DrugClass] (drugClass,AdminID) Values (@drugClass,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@drugClass", DC.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

    public void AdddrugsEffects_Transactions(double SEID, double DID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_drugSideEffects] (SideEffectsID,DrugID,AdminID) Values (@SideEffectsID,@DrugID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@SideEffectsID", double.Parse(SEID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@DrugID", double.Parse(DID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

    public void AdddrugsCLASSES_Transactions(double DCID, double DID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_MedicineDrugClass] (DrugClassID,DrugID,AdminID) Values (@DrugClassID,@DrugID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@DrugClassID", double.Parse(DCID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@DrugID", double.Parse(DID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

    public void AddDrugDosage(string DO, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_Dosage] (Dosage,AdminID) Values (@Dosage,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@Dosage", DO.ToString()));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }


    public void AdddrugsDosage_Transactions(double DOID, double DID, double AID)
    {
        try
        {
            con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbaseconnection"].ConnectionString);
            con.Open();
            System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand("Insert into [tbl_DosageDrugs] (DosageID,DrugID,AdminID) Values (@DosageID,@DrugID,@AdminID)", con);
            // insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
            insertCommand.Parameters.Add(new SqlParameter("@DosageID", double.Parse(DOID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@DrugID", double.Parse(DID.ToString())));
            insertCommand.Parameters.Add(new SqlParameter("@AdminID", double.Parse(AID.ToString())));
            int queryResult = insertCommand.ExecuteNonQuery();
            if (queryResult == 1)
            {


            }
        }
        catch (Exception)
        {

            throw;
        }
        finally { con.Close(); }
    }

}
