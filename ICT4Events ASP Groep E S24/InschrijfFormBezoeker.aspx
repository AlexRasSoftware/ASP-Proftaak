<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InschrijfFormBezoeker.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.InschrijfFormBezoeker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .InschrijfForm {
            position: absolute;
            left: 150px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Inschrijf Formulier Bezoeker</h1>
    <div style="height: 241px; width: 319px;" id="Persoonsinfo">
    
        <asp:Label ID="Label2" runat="server" Text="Voornaam:"></asp:Label>
        <asp:TextBox ID="tbVoornaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Tussenvoegsel:"></asp:Label>
        <asp:TextBox ID="tbTussenvoegsel" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Achternaam:"></asp:Label>
        <asp:TextBox ID="tbAchternaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Straat: "></asp:Label>
        <asp:TextBox ID="tbStraat" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Huisnr: "></asp:Label>
        <asp:TextBox ID="tbHuisnr" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Woonplaats:"></asp:Label>
        <asp:TextBox ID="tbWoonplaats" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Gebruikersnaam:"></asp:Label>
        <asp:TextBox ID="tbGebruikersnaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server" CssClass="InschrijfForm"></asp:TextBox>
        <br />
        <br />
        

        <asp:Button ID="btnMaakBezoeker" runat="server" Text="Maak Bezoeker" Width="131px" />
        <br />
        

    </div>
        <br />
    </div>
        <asp:Button ID="btnVolgende" runat="server" Text="Volgende" />
        <asp:Button ID="btnMateriaalHuren" runat="server" style="margin-left: 17px" Text="Materiaal Huren" />
        <asp:Button ID="btnAnnuleren" runat="server" style="margin-left: 129px" Text="Annuleren" Width="109px" />
    </form>
</body>
</html>
