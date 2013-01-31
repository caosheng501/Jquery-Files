<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demotreeview.aspx.cs" Inherits="demotreeview" %>
<%@ Register Assembly="Trirand.Web" TagPrefix="trirand" Namespace="Trirand.Web.UI.WebControls" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <title>jqTreeView for ASP.NET WebForms - Checkboxes</title>
    <!-- The jQuery UI theme that will be used by the treeview  -->
    <link rel="stylesheet" type="text/css" media="screen" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/redmond/jquery-ui.css" />
    <!-- The jQuery UI theme extension jqTreeView needs -->
    <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqtreeview.css" />
    <!-- jQuery runtime minified -->
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>    
    <!-- The jqTreeView client-side javascript -->
    <script src="js/trirand/jquery.jqTreeView.min.js" type="text/javascript"></script>    
    <style type="text/css">    
        body, html { font-size: 80%; }    
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <trirand:JQTreeView 
            runat="server" 
            ID="JQTreeView1" 
            CheckBoxes="true"
            Width="200" 
            Height="270">
            <Nodes>
                <trirand:JQTreeNode Text="One" ImageUrl="images/document.png" />
                <trirand:JQTreeNode Text="Two" ImageUrl="images/folder.png" ExpandedImageUrl="images/folder-open.png" Expanded="true">
                    <Nodes>
                        <trirand:JQTreeNode Text="2.1" ImageUrl="images/document.png" />
                        <trirand:JQTreeNode Text="2.2" ImageUrl="images/folder.png" ExpandedImageUrl="images/folder-open.png" Expanded="true">
                            <Nodes>
                                <trirand:JQTreeNode Text="2.2.1" ImageUrl="images/document.png" />
                                <trirand:JQTreeNode Text="2.2.2" ImageUrl="images/document.png" />
                                <trirand:JQTreeNode Text="2.2.3" ImageUrl="images/document.png" />
                                <trirand:JQTreeNode Text="2.2.4" ImageUrl="images/document.png" />
                            </Nodes>
                        </trirand:JQTreeNode>
                        <trirand:JQTreeNode Text="2.3" ImageUrl="images/document.png" />
                    </Nodes>
                </trirand:JQTreeNode>
                <trirand:JQTreeNode Text="Three" ImageUrl="images/document.png" />
            </Nodes>
        </trirand:JQTreeView>        
        <asp:Label runat="server" ID="SelectedNodeMessage" style="font-size:120%; font-family:Tahoma"></asp:Label>
        <br /><br />
        <asp:Button runat="server" ID="Button1" Text="Show Checked Nodes" 
            onclick="Button1_Click" />        
    </div>
    </form>
</body>
</html>
