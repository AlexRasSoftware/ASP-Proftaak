<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 298px">
    <form id="form1" runat="server">
    <div>
    
        Inloggen</div>
        <asp:DropDownList ID="ddlEvent" runat="server" Height="20px" Width="180px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblGebruikersnaam" runat="server" Text="Gebruikersnaam / RFID"></asp:Label>
        <br />
        <asp:TextBox ID="tbGebruikersnaam" runat="server" Width="170px"></asp:TextBox>
        <br />
        <asp:Label ID="lblWachtwoord" runat="server" Text="Wachtwoord"></asp:Label>
        <br />
        <asp:TextBox ID="tbWachtwoord" runat="server" Width="170px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnInloggen" runat="server" Text="Inloggen" Width="180px" />
        <br />
        <br />
        <asp:Button ID="btnInschrijven" runat="server" Text="Inschrijven" Width="180px" />
    </form>
</body>
</html>
