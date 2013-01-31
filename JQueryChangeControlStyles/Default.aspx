<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<title>Change form controls in asp.net using JQuery</title>
<link rel="stylesheet" href="jqtransformplugin/jqtransform.css" type="text/css" media="all" />
<script type="text/javascript" src="js/jquery.js" ></script>
<script type="text/javascript" src="jqtransformplugin/jquery.jqtransform.js" ></script>
<script language="javascript" type="text/javascript">
$(function() {
$('form').jqTransform({ imgPath: 'jqtransformplugin/img/' });
});
</script>
<style type="text/css">
body{
font-family: Arial;
}
form{clear:both;}
</style>
</head>
<body>
<form id="Form1" runat="server" >
<table align="center">
<h2>Billing Information</h2>
<tr>
<td colspan="2">
<div style="border: 1px solid #CCCCCC; padding: 10px;">
<table>
<tr class="rowElem">
<td>First Name:</td>
<td><asp:TextBox ID="txtfname"  runat="server"/></td>
</tr>
<tr class="rowElem">
<td>Last Name:</td>
<td><asp:TextBox ID="txtlname"  runat="server" 
        ontextchanged="txtlname_TextChanged"/></td>
</tr>
<tr class="rowElem">
<td>Gender:</td>
<td>
<asp:RadioButtonList ID="rdbGender" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Value="0" Text="Male"></asp:ListItem>
<asp:ListItem Value="1" Text="Female"></asp:ListItem>
</asp:RadioButtonList>
</td>
</tr>
<tr class="rowElem">
<td>Languages:</td>
<td>
<asp:CheckBoxList ID="chklang" runat="server" RepeatDirection="Horizontal">
<asp:ListItem Value="0">Telugu</asp:ListItem>
<asp:ListItem Value="1">English</asp:ListItem>
<asp:ListItem Value="2">Hindi</asp:ListItem>
</asp:CheckBoxList>
</td>
</tr>
<tr  class="rowElem">
<td>Email:</td>
<td><asp:TextBox ID="txtemail" runat="server" />
</td>
</tr>
<tr class="rowElem">
<td valign="top">Address:</td>
<td>
<asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" Rows="8" Columns="26"/></td>
</tr>
<tr class="rowElem">
<td>State:</td>
<td>
<asp:DropDownList ID="ddlState" runat="server" >
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
<tr class="rowElem">
<td>Zip:</td>
<td>
<asp:TextBox ID="txtZip" runat="server" />
</td>
</tr>
<tr class="rowElem">
<td>Credit Card Type:</td>
<td>
<asp:DropDownList ID="ddlCardType" runat="server" Width="180px" >
<asp:ListItem Value="">Choose Credit Card</asp:ListItem>
<asp:ListItem value="amex">American Express</asp:ListItem>
<asp:ListItem value="discover">Discover</asp:ListItem>
<asp:ListItem value="mastercard">MasterCard</asp:ListItem>
<asp:ListItem value="visa">Visa</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr class="rowElem">
<td></td>
<td>
<asp:Button ID="btnSubmit" runat="server" Text="Submit"/>
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
