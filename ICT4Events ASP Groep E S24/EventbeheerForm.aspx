<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventbeheerForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.EventbeheerForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Navigeren"></asp:Label>
    
    </div>
        <asp:Button ID="btnToEvent1" runat="server" OnClick="btnToEvent1_Click" Text="Event" />
        <asp:Button ID="btnToGebruiker1" runat="server" OnClick="btnToGebruiker1_Click" Text="Gebruikers Verwijderen" />
        <asp:Button ID="btnToMateriaal1" runat="server" OnClick="btnToMateriaal1_Click" Text="Materiaal Toevoegen" />
        <asp:Button ID="btnToPlaats1" runat="server" OnClick="Button4_Click" Text="Plaats Toevoegen" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Event"></asp:Label>
        <br />
        <br />
        Event&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlEvent" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ddlEventPasAan" runat="server" Text="Pas Aan" OnClick="ddlEventPasAan_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventVerwijder" runat="server" Text="Verwijderen" OnClick="btnEventVerwijder_Click" />
        <br />
        Naam&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventNaam" runat="server"></asp:TextBox>
        <br />
        Startdatum&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventStartdatum" runat="server"></asp:TextBox>
        <br />
        Einddatum&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventEinddatum" runat="server"></asp:TextBox>
        <br />
        Plaats&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventPlaats" runat="server"></asp:TextBox>
        <br />
        Adres&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbEventAdres" runat="server"></asp:TextBox>
        <br />
        Deelnemers&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlEventDeelnemers" runat="server">
        </asp:DropDownList>
        <br />
        Plaatsen&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlEventPlaatsen" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventPlaatsenVerwijder" runat="server" Text="Verwijder" OnClick="btnEventPlaatsenVerwijder_Click" />
        <br />
        Materiaal&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlEventMateriaal" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEventMateriaalVerwijder" runat="server" Text="Verwijder" OnClick="btnEventMateriaalVerwijder_Click" />
        <br />
        <asp:Button ID="btnEventAanmaken" runat="server" Text="Aanmaken" OnClick="btnEventAanmaken_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDatabaseConnectie" runat="server" Text="Database Connectie" OnClick="btnDatabaseConnectie_Click" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Navigeren"></asp:Label>
        <br />
        <asp:Button ID="btnToEvent2" runat="server" OnClick="btnToEvent2_Click" Text="Event" />
        <asp:Button ID="btnToGebruiker2" runat="server" OnClick="btnToGebruiker2_Click" Text="Gebruikers Verwijderen" />
        <asp:Button ID="btnToMateriaal2" runat="server" OnClick="btnToMateriaal2_Click" Text="Materiaal Toevoegen" />
        <asp:Button ID="btnToPlaats2" runat="server" OnClick="Button4_Click" Text="Plaats Toevoegen" />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Gebruikers Verwijderen"></asp:Label>
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
        <br />
        <asp:Label ID="Label4" runat="server" Text="Navigeren"></asp:Label>
        <br />
        <asp:Button ID="btnToEvent3" runat="server" OnClick="btnToEvent3_Click" Text="Event" />
        <asp:Button ID="btnToGebruiker3" runat="server" OnClick="btnToGebruiker3_Click" Text="Gebruikers Verwijderen" />
        <asp:Button ID="btnToMateriaal3" runat="server" OnClick="btnToMateriaal3_Click" Text="Materiaal Toevoegen" />
        <asp:Button ID="btnToPlaats3" runat="server" OnClick="Button4_Click" Text="Plaats Toevoegen" />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Materiaal Toevoegen"></asp:Label>
        <br />
        <br />
        <br />
        Soort&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlMateriaalSoort" runat="server">
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
        <br />
        <asp:Label ID="Label7" runat="server" Text="Navigeren"></asp:Label>
        <br />
        <asp:Button ID="btnToEvent4" runat="server" OnClick="btnToEvent4_Click" Text="Event" />
        <asp:Button ID="btnToGebruiker4" runat="server" OnClick="btnToGebruiker4_Click" Text="Gebruikers Verwijderen" />
        <asp:Button ID="btnToMateriaal4" runat="server" OnClick="btnToMateriaal4_Click" Text="Materiaal Toevoegen" />
        <asp:Button ID="btnToPlaats4" runat="server" OnClick="Button4_Click" Text="Plaats Toevoegen" />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Plaats Toevoegen"></asp:Label>
        <br />
        <br />
        prijs&nbsp;&nbsp;&nbsp; € <asp:TextBox ID="tbPlaatsPrijs" runat="server"></asp:TextBox>
        <br />
        Veel geluidsoverlast&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="cbGeluidsoverlast" runat="server" />
        <br />
        Aantal Personen&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPlaatsAantalPersonen" runat="server">
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
