<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBeheerForm2.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.EventBeheerForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            position: absolute;
            left: 150px;
            right: 412px;
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
        <asp:Button ID="btnNavLogin" runat="server" OnClick="btnNavLogin_Click" Text="Terug Naar Login" />
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
        <asp:Button ID="btnPasEvAan" runat="server" Text="Pas Aan" OnClick="btnPasEvAan_Click" />
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
        <asp:Button ID="btnZoek" runat="server" Text="Zoek" OnClick="btnZoek_Click" />
        <asp:Button ID="btnGebResetList" runat="server" OnClick="btnGebResetList_Click" Text="Reset" />
        <br />
        <br />
        <asp:ListBox ID="lbGebruikers" runat="server" Height="127px" Width="229px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnVerwijderGebr" runat="server" Text="Verwijder Gebruiker" OnClick="btnVerwijderGebr_Click" />

    </div>

    <div>
        <h3>Materiaal Toevoegen</h3>
        Type:
        <asp:DropDownList ID="ddlMateriaalType" runat="server" Height="24px" Width="180px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;Merk:
        <asp:DropDownList ID="ddlMateriaalMerk" runat="server" OnSelectedIndexChanged="ddlMateriaalMerk_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;Volgnummer:
        <asp:DropDownList ID="ddlMateriaalVolgnr" runat="server" OnSelectedIndexChanged="ddlMateriaalVolgnr_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbMaType" runat="server"></asp:TextBox>
        <br />
        Merk:<asp:TextBox ID="tbMaMerk" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        Volgnummer:<asp:TextBox ID="tbMaVolgnummer" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        Prijs:<asp:TextBox ID="tbMaPrijs" runat="server" CssClass="newStyle3"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnVoegMaToe" runat="server" Text="Voeg Materiaal Toe" Width="121px" OnClick="btnVoegMaToe_Click" />
        <asp:Button ID="btnPasMaAan" runat="server" Text="Pas Materiaal Aan" Width="129px" OnClick="btnPasMaAan_Click" />
        <br />

    </div>

    <div>

        <br />
        <h3>Plaats Beheer</h3>
        Locatienaam:<asp:DropDownList ID="ddlPlaNaam" runat="server" OnSelectedIndexChanged="ddlPlaNaam_SelectedIndexChanged" style="margin-left: 22px">
        </asp:DropDownList>
        <br />
        Plaatsnummer:&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPlaNr" runat="server" Text="1"></asp:Label>
        <br />
        Capaciteit:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPlaCap" runat="server" Text="4"></asp:Label>
        <br />
        Prijs:<asp:TextBox ID="tbPlaPrijs" runat="server" style="margin-left: 69px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnPlaatsAanpassen" runat="server" Text="Plaats Aanpassen" OnClick="btnPlaatsAanpassen_Click" Width="121px" />
        <br />

    </div>
    </form>
</body>
</html>
