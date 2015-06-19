<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AanwezigenForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.AanwezigenForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Alle aanwezigen</div>
        <asp:ListBox ID="ListBoxPersonen" runat="server" Height="400px" Width="550px"></asp:ListBox>
        <p>
            &nbsp;</p>
            <asp:Button ID="ButtonDownload" runat="server" OnClick="ButtonDownload_Click" Text="Download bestand" Width="168px" />
            <asp:Button ID="ButtonTerug" runat="server" OnClick="ButtonTerug_Click" style="margin-left: 0px" Text="Terug" Width="83px" />
    </form>
</body>
</html>
