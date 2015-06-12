<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventbeheerForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.EventbeheerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="nav1" runat="server" Text="Event"></asp:Label>
        <br />
        <br />
        Event&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlEvent" runat="server" OnSelectedIndexChanged="ddlEvent_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventPasAan" runat="server" Text="Pas Aan" OnClick="ddlEventPasAan_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventVerwijder" runat="server" Text="Verwijderen" OnClick="btnEventVerwijder_Click" />
        <br />
        Naam&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventNaam" runat="server"></asp:TextBox>
        <br />
        Startdatum&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventStartdatum" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ibtnStartdatum" runat="server" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="ibtnStartdatum_Click" Width="24px" />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
        <br />
        Einddatum&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventEinddatum" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ibtnBegindatum" runat="server" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="ibtnBegindatum_Click" Width="24px" />
        <br />
        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False"></asp:Calendar>
        <br />
        Plaats&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventPlaats" runat="server"></asp:TextBox>
        <br />
        Adres&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventAdres" runat="server"></asp:TextBox>
        <br />
        Deelnemers&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlEventDeelnemers" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        Plaatsen&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlEventPlaatsen" runat="server" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventPlaatsenVerwijder" runat="server" Text="Verwijder" OnClick="btnEventPlaatsenVerwijder_Click" />
        <br />
        Materiaal&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlEventMateriaal" runat="server" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventMateriaalVerwijder" runat="server" Text="Verwijder" OnClick="btnEventMateriaalVerwijder_Click" />
        <br />
        <asp:Button ID="btnEventAanmaken" runat="server" Text="Aanmaken" OnClick="btnEventAanmaken_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDatabaseConnectie" runat="server" Text="Database Connectie" OnClick="btnDatabaseConnectie_Click" />
        <br />
        <br />
        <asp:Label ID="nav2" runat="server" Text="Gebruikers Verwijderen"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnGebruikerVerwijder" runat="server" Text="Verwijder Gebruiker" OnClick="btnGebruikerVerwijder_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGebruikerZeker" runat="server" Text="Zeker?" OnClick="btnGebruikerZeker_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGebruikerNee" runat="server" Text="Nee" OnClick="btnGebruikerNee_Click" />
        <br />
        <asp:ListBox ID="lbGebruiker" runat="server" Height="204px" Width="610px"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="nav3" runat="server" Text="Materiaal Toevoegen"></asp:Label>
        <br />
        <br />
        <br />
        Soort&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlMateriaalSoort" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        Naam&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbMateriaalNaam" runat="server"></asp:TextBox>
        <br />
        Prijs&nbsp;&nbsp;&nbsp; €
        <asp:TextBox ID="tbMateriaalPrijs" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMateriaalVoegToe" runat="server" Text="Voeg Toe" OnClick="btnMateriaalVoegToe_Click" />
        <br />
        <asp:ListBox ID="lbMateriaal" runat="server" Height="175px" Width="610px"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="nav4" runat="server" Text="Plaats Toevoegen"></asp:Label>
        <br />
        <br />
        prijs&nbsp;&nbsp;&nbsp; € <asp:TextBox ID="tbPlaatsPrijs" runat="server"></asp:TextBox>
        <br />
        Veel geluidsoverlast&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="cbGeluidsoverlast" runat="server" />
        <br />
        Aantal Personen&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPlaatsAantalPersonen" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Huidige Plaatsen"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPlaatsVoegToe" runat="server" Text="Voeg Toe" OnClick="btnPlaatsVoegToe_Click" />
        <br />
        <asp:ListBox ID="lbPlaatsHuidig" runat="server" Height="175px" Width="610px"></asp:ListBox>
    </form>
</body>
</html>
