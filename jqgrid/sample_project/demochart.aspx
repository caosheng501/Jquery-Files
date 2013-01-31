<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demochart.aspx.cs" Inherits="demochart" %>
<%@ Register Assembly="Trirand.Web" TagPrefix="trirand" Namespace="Trirand.Web.UI.WebControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>jqChart ASP.NET chart control</title>        
    <!-- jQuery runtime minified -->
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.8.3.min.js" type="text/javascript"></script>    
    <!-- The javascript source file of jqChart -->
    <script src="js/trirand/jquery.jqChart.min.js" type="text/javascript"></script>    
        
    <style type="text/css">    
        body, html { font-size: 80%; }    
    </style>
</head>
<body>
    <form id="form1" runat="server">      
    
    <!-- The chart can be created declaratively in ASPX or in code-behind with C#/VB.NET code -->
    <trirand:JQChart 
        runat="server" 
        ID="TemperatureChart"
        Type="Line"
        Width="700" 
        Height="350">        
        <Title Text="Monthly Average Temperature" X="-15" />
        <SubTitle Text="Source: WorldClimate.com" X="-20" />
        <XAxis>
            <trirand:ChartXAxisSettings>
                <Categories>
                    <trirand:AxisCategory Text="Jan" />
                    <trirand:AxisCategory Text="Feb" />
                    <trirand:AxisCategory Text="Mar" />
                    <trirand:AxisCategory Text="Apr" />
                    <trirand:AxisCategory Text="May" />
                    <trirand:AxisCategory Text="Jun" />
                    <trirand:AxisCategory Text="Jul" />
                    <trirand:AxisCategory Text="Aug" />
                    <trirand:AxisCategory Text="Sep" />
                    <trirand:AxisCategory Text="Oct" />
                    <trirand:AxisCategory Text="Nov" />
                    <trirand:AxisCategory Text="Dec" />
                </Categories>
                <Title Text="Month, Year 2010"></Title>
            </trirand:ChartXAxisSettings>
        </XAxis>
        <YAxis>
            <trirand:ChartYAxisSettings>
                <Title Text="Temperature in Celcius" />
            </trirand:ChartYAxisSettings>
        </YAxis>        
        <ToolTips Formatter="formatToolTip" />
        <Legend 
            Layout="Vertical"
            Align="Right"
            VerticalAlign="Top"
            X="-10"
            Y="100"
            BorderWidth="0"            
         />                  
         <Series>
            <trirand:ChartSeriesSettings Name="Tokyo">
                <Data>
                    <trirand:ChartPoint Y="7" /><trirand:ChartPoint Y="6.9" />
                    <trirand:ChartPoint Y="9.5" /><trirand:ChartPoint Y="14.5" />
                    <trirand:ChartPoint Y="18.2" /><trirand:ChartPoint Y="21.5" />
                    <trirand:ChartPoint Y="25.2" /><trirand:ChartPoint Y="26.2" />
                    <trirand:ChartPoint Y="23.3" /><trirand:ChartPoint Y="18.3" />
                    <trirand:ChartPoint Y="13.9" /><trirand:ChartPoint Y="9.6" />
                </Data>
            </trirand:ChartSeriesSettings>
            <trirand:ChartSeriesSettings Name="New York">
                <Data>
                    <trirand:ChartPoint Y="-0.2" /><trirand:ChartPoint Y="0.8" />
                    <trirand:ChartPoint Y="5.7" /><trirand:ChartPoint Y="11.3" />
                    <trirand:ChartPoint Y="17.0" /><trirand:ChartPoint Y="22.0" />
                    <trirand:ChartPoint Y="24.8" /><trirand:ChartPoint Y="24.1" />
                    <trirand:ChartPoint Y="20.1" /><trirand:ChartPoint Y="14.1" />
                    <trirand:ChartPoint Y="8.6" /><trirand:ChartPoint Y="2.5" />
                </Data>
            </trirand:ChartSeriesSettings>
            <trirand:ChartSeriesSettings Name="Berlin">
                <Data>                
                    <trirand:ChartPoint Y="-0.9" /><trirand:ChartPoint Y="0.6" />
                    <trirand:ChartPoint Y="3.5" /><trirand:ChartPoint Y="8.4" />
                    <trirand:ChartPoint Y="13.5" /><trirand:ChartPoint Y="17.0" />
                    <trirand:ChartPoint Y="18.6" /><trirand:ChartPoint Y="17.9" />
                    <trirand:ChartPoint Y="14.3" /><trirand:ChartPoint Y="9.0" />
                    <trirand:ChartPoint Y="3.9" /><trirand:ChartPoint Y="1.0" />
                </Data>
            </trirand:ChartSeriesSettings>
            <trirand:ChartSeriesSettings Name="London">                
                <Data>                
                    <trirand:ChartPoint Y="3.9" /><trirand:ChartPoint Y="4.2" />
                    <trirand:ChartPoint Y="5.7" /><trirand:ChartPoint Y="8.5" />
                    <trirand:ChartPoint Y="11.9" /><trirand:ChartPoint Y="15.2" />
                    <trirand:ChartPoint Y="17.0" /><trirand:ChartPoint Y="16.6" />
                    <trirand:ChartPoint Y="14.2" /><trirand:ChartPoint Y="10.3" />
                    <trirand:ChartPoint Y="6.6" /><trirand:ChartPoint Y="4.8" />
                </Data>
            </trirand:ChartSeriesSettings>
         </Series>
    </trirand:JQChart>
    
    <script type="text/javascript">    
        function formatToolTip()
        {
            return this.x +': '+ this.y +' units';
        }
    </script> 
    
    </form>
</body>
</html>