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
        <asp:RadioButtonList ID="rbKiesFilter" runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Alles</asp:ListItem>
            <asp:ListItem>Berichten</asp:ListItem>
            <asp:ListItem>Foto&#39;s</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:ListBox ID="lbPosts" runat="server" Height="162px" Width="716px"></asp:ListBox>
        <br />

        <asp:Button ID="btnReageerMeer" runat="server" Text="Reageer en meer" OnClick="btnReageerMeer_Click" />
        <br />
        Nieuwe post<br />
        <asp:TextBox ID="tbBericht" runat="server" Height="52px" Width="176px" Rows="3"></asp:TextBox>
        <br />
        <br />
        <asp:FileUpload ID="fuUpload" runat="server" />
        <asp:Button ID="btnPost" runat="server" Text="Plaats post" OnClick="btnPost_Click" />
        <br />
        Zoeken<br />
        <asp:TextBox ID="tbZoeken" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnZoeken" runat="server" OnClick="Button1_Click1" Text="Zoeken" />
        <br />
        <asp:Button ID="btnTerug" runat="server" OnClick="Button1_Click" Text="Terug" />
        <br />
    </form>
</body>
</html>
