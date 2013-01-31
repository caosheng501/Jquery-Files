<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="demogrid.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="Trirand.Web" TagPrefix="trirand" Namespace="Trirand.Web.UI.WebControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <!-- The jQuery UI theme that will be used by the grid -->
    <link rel="stylesheet" type="text/css" media="screen" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/redmond/jquery-ui.css" />
    <!-- The jQuery UI theme extension jqGrid needs -->
    <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
    <!-- jQuery runtime minified -->
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>
    <!-- The localization file we need, English in this case -->
    <script src="js/trirand/i18n/grid.locale-en.js"type="text/javascript"></script>
    <!-- The jqGrid client-side javascript -->
    <script src="js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>
    <style>
        body { font-size: 75%; }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/Northwind.mdb"         
        SelectCommand="SELECT [OrderID], [Freight], [OrderDate], [ShipCity] FROM [Orders]" 
        DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = ?" 
        InsertCommand="INSERT INTO [Orders] ([Freight], [OrderDate], [ShipCity]) VALUES (?, ?, ?)" 
        UpdateCommand="UPDATE [Orders] SET [Freight] = ?, [OrderDate] = ?, [ShipCity] = ? WHERE [OrderID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="OrderID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Freight" Type="Decimal" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="ShipCity" Type="String" />
            <asp:Parameter Name="OrderID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>            
            <asp:Parameter Name="Freight" Type="Decimal" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="ShipCity" Type="String" />
        </InsertParameters>
    </asp:AccessDataSource>
    
    <trirand:JQGrid runat="server" ID="JQGrid1" DataSourceID="AccessDataSource1">
        <Columns>
            <trirand:JQGridColumn DataField="OrderID" PrimaryKey="True" />
            <trirand:JQGridColumn DataField="Freight" Editable="true" />
            <trirand:JQGridColumn DataField="OrderDate" Editable="true" DataFormatString="{0:d}" />
            <trirand:JQGridColumn DataField="ShipCity" Editable="true" />
        </Columns>        
        <ToolBarSettings ShowEditButton="true" ShowRefreshButton="True" ShowAddButton="true" ShowDeleteButton="true"
            ShowSearchButton="True" />
    </trirand:JQGrid>        
    
    
    </form>
</body>
</html>

