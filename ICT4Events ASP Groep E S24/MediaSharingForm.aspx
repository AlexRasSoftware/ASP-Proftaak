<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaSharingForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.MediaSharingForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MediaSharing</title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
        Media Sharing<br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Alles</asp:ListItem>
            <asp:ListItem>Berichten</asp:ListItem>
            <asp:ListItem>Foto&#39;s</asp:ListItem>
            <asp:ListItem>Video&#39;s</asp:ListItem>
            <asp:ListItem>Muziek</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="162px" Width="331px"></asp:ListBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Like" />
        <asp:Button ID="Button3" runat="server" Text="Reageer en meer" />
        <br />
        Nieuwe post<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="52px" Width="176px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Text="Upload bestand" />
        <asp:Button ID="Button5" runat="server" Text="Plaats post" />
        <br />
        Zoeken<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
    </form>
</body>
</html>
