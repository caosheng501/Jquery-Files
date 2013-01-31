<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
<table>
<tr>
<td align="right">
    <asp:ImageButton ID="ImageButton1" runat="server"   ImageUrl="~/EXCEL.jpg" Width="32px" Height="32px"  onclick="ImageButton1_Click" />
    </td>
<td align="right">
<asp:ImageButton ID="btnPDF" runat="server" ImageUrl="~/PDF.jpg" Width="32px" 
Height="32px" onclick="btnPDF_Click"/>
</td>
</tr>
<tr>
<td>
<asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" Width="645px" 
                            DataKeyNames="DrugID" 
                            ShowFooter="True" AllowPaging="True" PageSize="30" 
        onpageindexchanging="gvdetails_PageIndexChanging" 
        onrowcreated="gvdetails_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="DrugID" HeaderText="Code" Visible="False" />
                        <asp:ButtonField DataTextField="DrugName" HeaderText="Drug Name" 
                            CommandName="Select">
                        <ItemStyle Font-Bold="True" ForeColor="black" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="GenericName" HeaderText="GenericName" >
                        <ItemStyle ForeColor="black" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BrandName" HeaderText="BrandName" >
                        <ItemStyle ForeColor="black" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#003300" />
                    <HeaderStyle BackColor="#003300" 
                        HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:GridView>
</td>
</tr>
</table>
</div>
</form>
</body>
</html>
