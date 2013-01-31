jqSuite for ASP.NET WebForms 4.5.1

===========================
Installlation
===========================

Download and unzip the contents of the archive to any convenient location. The package contains the following folders

- [bin] - Contains the assembly DLL of the product (Trirand.Web.dll). This is the assembly that you can reference directly in your ASPX file (or better yet, add it to your ToolBox and then drag & drop it from there)
- [themes] - Contains the themes shipped with the products. 

Since jqSuite supports jQuery UI Themeroller, any theme compatible with jQuery UI ThemeRoller will work for jqSuite as well. In this  sample project, we reference the Redmond ThemeRoller theme from Microsofts CDN (online content delivery network). There are more than 30 available themes + custom theme builder tool.

You can download any additional themes directly from jQuery UI's ThemeRoller site available here: 

http://jqueryui.com/themeroller/

or reference them from Microsoft's / Google's CDN.

<link rel="stylesheet" type="text/css" media="screen" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.16/themes/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="themes/ui.jqgrid.css" />

- [js] - The javascript files of jqSuite (and the needed libraries). You need to include them in your ASPX page, in order to gain the client side functionality of the suite. 
The first file is "jquery-1.8.3.min.js" - this is the latest official jQuery library on which jqGrid is built upon.
The second file you need is the i18n (localization) javascript file. Depending on the language you need, just pick one from the "js/i18n" folder.
The last one is the jqGrid javascript code itself, located in "jquery.jqGrid.min.js"

The final result you will have in an ASPX page containing jqGrid would be something similar to that:

...
<%@ Register TagPrefix="trirand" Namespace="Trirand.Web.UI.WebControls" Assembly="JQGrid" %>
...
<head>    
     <!-- The jQuery UI theme that will be used by the grid -->
    <link rel="stylesheet" type="text/css" media="screen" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/redmond/jquery-ui.css" />
    <!-- The jQuery UI theme extension jqGrid needs -->
    <link rel="stylesheet" type="text/css" media="screen" href="/themes/ui.jqgrid.css" />
    <!-- jQuery runtime minified -->
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>    
    <!-- The localization file we need, English in this case -->
    <script src="/js/trirand/i18n/grid.locale-en.js" type="text/javascript"></script>
    <!-- The jqGrid client-side javascript -->
    <script src="/js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>    
    <!-- This jQuery UI library is needed only for the code tabs, not needed by the grid per se -->
</head>

<html>
     <form runat="server">
     ...
     <trirand:JQGrid ID="EditDialogGrid" runat="server" DataSourceID="SqlDataSource1">        
            <Columns>
                <trirand:JQGridColumn DataField="id" Editable="true" />
                <trirand:JQGridColumn DataField="invdate" Editable="true" />
                <trirand:JQGridColumn DataField="name"  Editable="true"/>
                <trirand:JQGridColumn DataField="amount" Editable="true" />
                <trirand:JQGridColumn DataField="tax" Editable="true" />
                <trirand:JQGridColumn DataField="total" Editable="true" />
                <trirand:JQGridColumn DataField="note" Editable="true" />
            </Columns>
            <EditDialogSettings 
                CancelText="Cancel the Editing" 
                CaptionWhenEditing="Edit the Dialog" 
                SubmitText="Go edit that!"                
                TopOffset="50" 
                LeftOffset="50" />            
       </trirand:JQGrid>
     ...
     </form>
</html>

============================
Licensing
============================
This is our evaluation free 30-day trial license. We are very helpful to ALL customers, including trial customers and will gladly assist you 
with any problems you might have (send questions to our online forums here: http://trirand.net/forum or to email support@trirand.net. Forums are our preferred channel of support.). 

After 30-days of trial, you will see a trial expired message. To remove that, just purchase the single developer versions and we will send you a download link to unrestricted versions.  You can also contact us at sales@trirand.net if you need trial extension.

You can purchase developer versions here (http://www.trirand.net/licensing.aspx)

It's as simple as that, no cryptic settings in configs, no registry settings - complete license freedom (so you can use it on test/deployment servers, 
have QA look it at without licenses issues, etc)



==

Hope this helps. If you have any questions, justsend questions to our online forums here: http://trirand.net/forum or to email support@trirand.net. Forums are our preferred channel of support.

Regards,
Rumen Stankov /Trirand Inc/