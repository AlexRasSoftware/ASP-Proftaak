﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBeheerForm2.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.EventBeheerForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            position: absolute;
            left: 150px;
        }
        .newStyle2 {
            position: absolute;
            left: 290px;
        }
        .newStyle3 {
            position: absolute;
            left: 100px;
            right: 598px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Pas event aan</h3>
        Alle Events&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlEvents" runat="server" CssClass="newStyle1" Width="131px">
        </asp:DropDownList>
        <br />
        Naam:
        <asp:TextBox ID="tbEvNaam" runat="server" CssClass="newStyle1"></asp:TextBox>
        <br />
        Datum Start: <asp:TextBox ID="tbEvDatStart" runat="server" CssClass="newStyle1"></asp:TextBox>
        <asp:ImageButton ID="imbtnCalendarStart" runat="server" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="imbtnCalendarStart_Click" Width="24px" CssClass="newStyle2" />
        <asp:Calendar ID="calStart" runat="server" OnSelectionChanged="calStart_SelectionChanged" Visible="False"></asp:Calendar>
        <br />
        Datum Eind:
        <asp:TextBox ID="tbEvDaEind" runat="server" CssClass="newStyle1"></asp:TextBox>
        <asp:ImageButton ID="imbtnCalendarEind" runat="server" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="imbtnCalendarEind_Click" Width="24px" CssClass="newStyle2" />
        <asp:Calendar ID="calEind" runat="server" OnSelectionChanged="calEind_SelectionChanged" Visible="False"></asp:Calendar>
        <br />
        Locatie:
        <asp:TextBox ID="tbEvLocatie" runat="server" CssClass="newStyle1"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="btnPasEvAan" runat="server" Text="Pas Aan" />
        <br />
    
    </div>

    <div>

        <h3>
            <br />
            Verwijder Gebruikers</h3>
        Zoek Gebruiker:
        <asp:TextBox ID="tbZoekGebruiker" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnZoek" runat="server" Text="Zoek" />
        <br />
        <br />
        <asp:ListBox ID="lbGebruikers" runat="server" Height="127px" Width="229px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnVerwijderGebr" runat="server" Text="Verwijder Gebruiker" />

    </div>

    <div>
        <h3>Materiaal Toevoegen</h3>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="180px">
        </asp:DropDownList>
        <br />
        <br />
        Merk:<asp:TextBox ID="tbMaMerk" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        Serie:<asp:TextBox ID="tbMaSerie" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        Typenummer:<asp:TextBox ID="tbMaTypenummer" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        Prijs:<asp:TextBox ID="tbMaPrijs" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnVoegMaToe" runat="server" Text="Voeg Materiaal Toe" Width="121px" />
        <asp:Button ID="btnPasMaAan" runat="server" Text="Pas Materiaal Aan" Width="129px" />
        <br />

    </div>

    <div>

        <br />
        <h3>Plaats Beheer</h3>
        Locatienaam:<br />
        Plaatsnummer:<br />
        Capaciteit:<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />

    </div>
    </form>
</body>
</html>
