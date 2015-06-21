<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.PostForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbGebruikersnaam" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lbTekst" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lbLikes" runat="server" Text="Label"></asp:Label>
&nbsp;-
        <asp:Label ID="lbDatum" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click" />
        <asp:Button ID="btnRapporteer" runat="server" Text="Rapporteer" />
        <asp:Button ID="btnPlaatsReactie" runat="server" Text="Plaats Reactie" OnClick="Button1_Click" />
        <asp:TextBox ID="tbReactie" runat="server" Height="55px" Width="269px"></asp:TextBox>
        <br />
        <br />
        <asp:ListBox ID="lbReacties" runat="server" Height="206px" Width="272px"></asp:ListBox>
        <br />
        <asp:Button ID="btnVerwijderReactie" runat="server" Text="Verwijder Reactie" OnClick="btnVerwijderReactie_Click" />
        <asp:Button ID="btnVerwijderBericht" runat="server" Text="Verwijder Bericht" />
    
        <asp:Button ID="btnTerug" runat="server" OnClick="btnTerug_Click" Text="Terug" />
    
    </div>
    </form>
</body>
</html>
