<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysteemkiezerForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.SysteemkiezerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Kies een systeem.</div>
        <asp:Button ID="ButtonMedia" runat="server" OnClick="ButtonMedia_Click" Text="Media Sharing" Width="150px" />
        <asp:Button ID="ButtonToegang" runat="server" OnClick="ButtonToegang_Click" Text="Toegangscontrole" Width="150px" />
        <asp:Button ID="ButtonBeheer" runat="server" OnClick="ButtonBeheer_Click" Text="Event beheren" Width="150px" />
    </form>
</body>
</html>
