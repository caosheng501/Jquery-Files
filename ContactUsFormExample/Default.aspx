<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Asp.net contact us page in c#, VB.NET</title>
    <style type="text/css">
    .Button
{
 background-color :#FF5A00;
 color: #FFFFFF;
    font-weight: bold;
    margin-right: 2px;
    padding: 4px 20px 4px 21px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="2" cellpadding="2" border="0">
    <tr><td></td><td><b>Contact Us Form</b></td></tr>
    <tr><td><b>Name</b></td><td><asp:TextBox ID="txtName" runat="server" /></td></tr>
    <tr><td><b>Email</b></td><td><asp:TextBox ID="txtEmail" runat="server" /></td></tr>
    <tr><td><b>Subject</b></td><td><asp:TextBox ID="txtSubject" runat="server" /></td></tr>
    <tr><td valign="top"><b>Message</b></td><td> <asp:TextBox ID="txtMessage" Rows="5" Columns="40" TextMode="MultiLine" runat="server"/></td></tr>
     <tr><td></td><td><asp:button ID="btnSubmit" Text="Submit"  runat="server" onclick="btnSubmit_Click" CssClass="Button"/></td></tr>
    <tr><td colspan="2" style=" color:red"><asp:Label ID="lbltxt" runat="server"/></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
