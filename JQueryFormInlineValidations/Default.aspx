<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Show Inline validation Messages</title>
<link href="css/template.css" rel="stylesheet" type="text/css" />
<link href="css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.6.min.js" type="text/javascript"></script>
<script src="js/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
<script src="js/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
jQuery(document).ready(function() {
jQuery("#form1").validationEngine();
});
</script>
</head>
<body>
<form id="form1" runat="server">
<table align="center">
<tr>
<td colspan="2">
<div style="border: 1px solid #CCCCCC; padding: 10px;">
<table cellpadding="0" cellspacing="30" style=" background-color:White">
<tr>
<td>First Name:</td>
<td><asp:TextBox ID="txtfname"  runat="server" CssClass="validate[required]"/></td>
</tr>
<tr>
<td>Last Name:</td>
<td><asp:TextBox ID="txtlname"  runat="server" CssClass="validate[required]"/></td>
</tr>
<tr >
<td>Email:</td>
<td><asp:TextBox ID="txtemail" runat="server"  CssClass="validate[required,custom[email]" />
</td>
</tr>
<tr >
<td>Url:</td>
<td><asp:TextBox ID="txtUrl" runat="server" CssClass="validate[required,custom[url]] text-input" />
</td>
</tr>
<tr>
<td valign="top">Address:</td>
<td>
<asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" Rows="8" Columns="26"/></td>
</tr>
<tr>
<td>State:</td>
<td>
<asp:DropDownList ID="ddlState" runat="server" CssClass="validate[required] radio">
<asp:ListItem value="">Choose State</asp:ListItem>
<asp:ListItem Value="AL">Alabama</asp:ListItem>
<asp:ListItem value="AK">Alaska</asp:ListItem>
<asp:ListItem  value="AL">Alabama </asp:ListItem>
<asp:ListItem  value="AK">Alaska</asp:ListItem>
<asp:ListItem  value="AZ">Arizona</asp:ListItem>
<asp:ListItem  value="AR">Arkansas</asp:ListItem>
<asp:ListItem  value="CA">California</asp:ListItem>
<asp:ListItem  value="CO">Colorado</asp:ListItem>
<asp:ListItem  value="CT">Connecticut</asp:ListItem>
<asp:ListItem  value="DE">Delaware</asp:ListItem>
<asp:ListItem  value="FL">Florida</asp:ListItem>
<asp:ListItem  value="GA">Georgia</asp:ListItem>
<asp:ListItem  value="HI">Hawaii</asp:ListItem>
<asp:ListItem  value="ID">Idaho</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td>Zip:</td>
<td>
<asp:TextBox ID="txtZip" runat="server" CssClass="validate[required,custom[integer]] text-input"/>
</td>
</tr>
<tr>
<td> I Agree Conditions</td>
<td>
<input class="validate[required] checkbox" type="checkbox" id="agree" name="agree"/>
</td>
</tr>
<tr>
<td></td>
<td>
<asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
</td>
</tr>
<tr>
<td colspan="2">
<asp:Label ID="lblResult" runat="server" Font-Bold="true"/>
</td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</form>
</body>
</html>
