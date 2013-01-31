<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>

</head>
<body>
<script type="text/javascript">
    var editedRowSelector = null;

    function OnGridCallback() {
        if (editedRowSelector) {
            $(editedRowSelector).effect("highlight", {}, 3000);
            editedRowSelector = null;
        }
        AddHandlerToUpdateButton();
    }

    function AddHandlerToUpdateButton() {
        $("table[class^='dxgvEditFormTable']")
        .find("a:contains('Update')")
        .click(function () {
            editedRowSelector = '#' + $("tr[class^='dxgvEditFormDisplayRow']").attr('id');
        });
    }

</script>
    <form id="form1" runat="server">
    <div>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="AccessDataSource1" KeyFieldName="EmployeeID">
    <ClientSideEvents EndCallback="function(s, e) {
	OnGridCallback();
}" />
    <Columns>
        <dx:GridViewCommandColumn VisibleIndex="0">
            <EditButton Visible="True">
            </EditButton>
            <NewButton Visible="True">
            </NewButton>
            <DeleteButton Visible="True">
            </DeleteButton>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" 
            VisibleIndex="1">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="BirthDate" VisibleIndex="4">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="City" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>    
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
            DataFile="~/App_Data/nwind.mdb" 
            DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = ?" 
            InsertCommand="INSERT INTO [Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate], [City], [Country]) VALUES (?, ?, ?, ?, ?, ?)" 
            SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [BirthDate], [City], [Country] FROM [Employees]" 
            UpdateCommand="UPDATE [Employees] SET [LastName] = ?, [FirstName] = ?, [BirthDate] = ?, [City] = ?, [Country] = ? WHERE [EmployeeID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="EmployeeID" Type="Int32" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="BirthDate" Type="DateTime" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="BirthDate" Type="DateTime" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
