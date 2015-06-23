<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBeheerForm2.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.EventBeheerForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
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
            left: 150px;
            right: 598px;
        }
        .newStyle4 {
            position: absolute;
            left: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Pas event aan</h3>
        <br />
        Naam:
        <asp:TextBox ID="tbEvNaam" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Datum Start:
                <asp:ImageButton ID="imbtnCalendarStart" runat="server" CssClass="newStyle2" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="imbtnCalendarStart_Click" Width="24px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="tbEvDatStart" runat="server" Text="11-09-2001"></asp:Label>
                <asp:Calendar ID="calStart" runat="server" OnSelectionChanged="calStart_SelectionChanged" Visible="False"></asp:Calendar>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
        <br />Datum Eind:
                <asp:ImageButton ID="imbtnCalendarEind" runat="server" CssClass="newStyle2" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="imbtnCalendarEind_Click" Width="24px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="tbEvDaEind" runat="server" Text="21-12-2012"></asp:Label>
                <asp:Calendar ID="calEind" runat="server" OnSelectionChanged="calEind_SelectionChanged" Visible="False"></asp:Calendar>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        Locatie:
        <asp:TextBox ID="tbEvLocatie" runat="server" ></asp:TextBox>
    
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
        <asp:Button ID="btnVerwijderGebr" runat="server" Text="Verwijder Gebruiker" OnClick="btnVerwijderGebr_Click" OnClientClick="return confirm('Weet u het zeker?');"/>

    </div>

    <div>
        <h3>Materiaal Toevoegen</h3>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                Type:
                <asp:DropDownList ID="ddlMateriaalType" runat="server" AutoPostBack="True" Height="24px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="180px">
                </asp:DropDownList>
                &nbsp;Merk:
                <asp:DropDownList ID="ddlMateriaalMerk" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMateriaalMerk_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;Volgnummer:
                <asp:DropDownList ID="ddlMateriaalVolgnr" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMateriaalVolgnr_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbMaType" runat="server" ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <br />
                Merk:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbMaMerk" runat="server" ></asp:TextBox>
                <br />
                Volgnummer:
                <asp:TextBox ID="tbMaVolgnummer" runat="server" ></asp:TextBox>
                <br />
                Prijs:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbMaPrijs" runat="server" ></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="btnNieuwType" runat="server" OnClick="btnNieuwType_Click" Text="Nieuw Type" />
                <asp:Button ID="btnMaTypeVerw" runat="server" OnClick="btnMaTypeVerw_Click" Text="Verwijder Type" OnClientClick="return confirm('Weet u het zeker?');"/>
                <asp:Button ID="btnNieuwMerk" runat="server" OnClick="btnNieuwMerk_Click1" Text="Nieuw Merk" />
                <asp:Button ID="MaMerkVerw" runat="server" OnClick="MaMerkVerw_Click" Text="Verwijder Merk" OnClientClick="return confirm('Weet u het zeker?');"/>
                <asp:Button ID="btnVolgnr" runat="server" OnClick="btnVolgnr_Click" Text="Nieuw Volgnr" />
                <asp:Button ID="btnMaVolgnrVerw" runat="server" OnClick="btnMaVolgnrVerw_Click" Text="Verwijder Volgnr" OnClientClick="return confirm('Weet u het zeker?');"/>
                <br />
                <br />
                <asp:Button ID="btnPasMaAan" runat="server" OnClick="btnPasMaAan_Click" Text="Pas Prijs Aan" Width="152px" OnClientClick="return confirm('Weet u het zeker?');"/>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />

    </div>

    <div>

        <br />
        <h3>Plaats Beheer    Locatienaam:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPlaatsLocatie" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                Plaatsnummer:&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlPlaatsnummers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlaatsnummers_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                Capaciteit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblPlaatscapaciteit" runat="server" Text="Label"></asp:Label>
                <br />
                Plaatsnummer&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbPlaatsnummer" runat="server" style="margin-left: 8px"></asp:TextBox>
                <br />
                Capaciteit:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbPlaCap" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="btnPlaatsAanpassen" runat="server" OnClick="btnPlaatsAanpassen_Click" Text="Plaats Aanpassen" Width="147px" OnClientClick="return confirm('Weet u het zeker?');"/>
                <asp:Button ID="btnNieuwPlaats" runat="server" OnClick="btnNieuwPlaats_Click1" Text="Nieuwe Plaats" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

    </div>
        <asp:Button ID="btnNavLogin" runat="server" OnClick="btnNavLogin_Click" Text="Terug" />
    </form>
</body>
</html>
