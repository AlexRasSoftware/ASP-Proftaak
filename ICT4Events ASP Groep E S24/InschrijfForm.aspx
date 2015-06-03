﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InschrijfForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.InschrijfForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .InschrijfForm {
            position: absolute;
            left: 150px;
        }
        .Plaatsen {
            position: relative;
            top: 20px;
            left: 0px;
            width: 451px;
        }
        .auto-style1 {
            position: relative;
            top: 20px;
            left: 1px;
            width: 451px;
            margin-bottom: 0px;
            margin-left: 0px;
        }
        .EindInschrijf {
            position: relative;
            top: 47px;
            left: 2px;
            width: 450px;
        }
        #form1 {
            height: 1416px;
        }
        .Plaatje {
            position: absolute;
            right: 10px;
            top: 10px;
            height: 982px;
            width: 1221px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Inschrijf Formulier</h1>
    <div style="height: 254px; width: 319px;" id="Persoonsinfo">
    
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
        <asp:Label ID="Label8" runat="server" Text="Banknr:"></asp:Label>
        <asp:TextBox ID="tbBanknr" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Gebruikersnaam:"></asp:Label>
        <asp:TextBox ID="tbGebruikersnaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server" CssClass="InschrijfForm"></asp:TextBox>
        <br />
        <br />
        

        <asp:Button ID="btnMaakBezoeker" runat="server" Text="Maak Bezoeker" Width="131px" OnClick="btnMaakBezoeker_Click" />
        <br />
        

    </div>

    <div id="Plaats" class="Plaatsen">

        <asp:Label ID="Label11" runat="server" Text="Plaats"></asp:Label>
        :<asp:DropDownList ID="ddlPlaatsen" runat="server" style="margin-left: 37px; margin-bottom: 0px" Width="350px">
            <asp:ListItem>Peter</asp:ListItem>
            <asp:ListItem>Henkie</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button1" runat="server" Height="40px" style="margin-top: 15px" Text="Voeg Plaats Toe" />
        <asp:Button ID="Button2" runat="server" Height="40px" style="margin-left: 84px" Text="Verwijder Plaats" />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style1" Height="133px"></asp:ListBox>
        <br />

        <br />
        <br />
        <asp:Label ID="lblPrijs" runat="server" Text="Geld!"></asp:Label>
    </div>
    <div class="EindInschrijf" id="Eindinschrijf">

        <asp:CheckBox ID="chbMeederePersonen" runat="server" Text="Meerdere Personen" />
        <asp:DropDownList ID="ddlMeerderePersonen" runat="server" style="margin-left: 22px" Width="118px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnBevestig" runat="server" Text="Bevestig" />
        <asp:Button ID="btnMateriaalHuren" runat="server" style="margin-left: 24px" Text="Materiaal Huren" />
        <asp:Button ID="btnAnnuleren" runat="server" style="margin-left: 31px" Text="Annuleren" Width="126px" />

    </div>
        <br />

        <br />
        <br />
        <asp:Image ID="imgCamping" runat="server" CssClass="Plaatje" ImageUrl="~/Plaatjes/Camping_ReeënDal (1).png" />

    </form>
</body>
</html>
