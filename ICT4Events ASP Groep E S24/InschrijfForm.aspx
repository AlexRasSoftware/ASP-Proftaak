<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InschrijfForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.InschrijfForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
    <style type="text/css">
        .InschrijfForm {
            position: absolute;
            left: 150px;
        }
        .Plaatsen {
            position: relative;
            top: 18px;
            left: 3px;
            width: 451px;
            height: 351px;
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
            top: 3px;
            left: 1px;
            width: 450px;
            height: 117px;
        }
        #form1 {
            height: 1416px;
        }
        .Plaatje {
            position: absolute;
            right: 10px;
            top: -4px;
            height: 895px;
            width: 867px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Inschrijf Formulier</h1>
    <div style="height: 468px; width: 529px;" id="Persoonsinfo">
    
        <asp:Label ID="Label2" runat="server" Text="Voornaam:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbVoornaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 62px; left: 155px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ongeldige Voornaam" ControlToValidate="tbVoornaam" ValidationExpression="[a-zA-Z 0-9\-]{3,}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Tussenvoegsel:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbTussenvoegsel" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 100px; left: 155px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Ongeldig Tussenvoegsel" ControlToValidate="tbTussenvoegsel" ValidationExpression="[aA-zZ]{1,}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Achternaam:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbAchternaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 141px; left: 155px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Ongeldige Achternaam" ControlToValidate="tbAchternaam" ValidationExpression="[aA-zZ]{3,}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Straat: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbStraat" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 181px; left: 154px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Ongeldige Straat" ControlToValidate="tbStraat" ValidationExpression="[aA-zZ]{3,}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Huisnr: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbHuisnr" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 220px; left: 154px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Ongeldig Huisnummer" ControlToValidate="tbHuisnr" ValidationExpression="[a-zA-Z0-9]{1,}"></asp:RegularExpressionValidator>       
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Woonplaats:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbWoonplaats" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 260px; left: 154px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Ongeldige Woonplaats" ControlToValidate="tbWoonplaats" ValidationExpression="[aA-zZ]{3,}"></asp:RegularExpressionValidator>       
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Banknr:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbBanknr" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 300px; left: 154px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Ongeldig Banknummer" ControlToValidate="tbBanknr" ValidationExpression="[a-zA-Z0-9]{9,18}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Gebruikersnaam:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbGebruikersnaam" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 341px; left: 154px;"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Ongeldige Gebruikersnaam" ControlToValidate="tbGebruikersnaam" ValidationExpression="[a-zA-Z0-9]{3,}"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEmail" runat="server" CssClass="InschrijfForm" style="margin-left: 0px; top: 380px; left: 154px;"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEmail" ErrorMessage="Ongeldig Emailadres"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Wachtwoord: "></asp:Label>
        <asp:TextBox ID="tbWachtwoord" runat="server" style="margin-left: 0px; top: 420px; left: 154px;" CssClass="InschrijfForm" input type="password"></asp:TextBox>
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server" ValidateRequestMode="Disabled">
        </asp:ScriptManager>
        <br />
        

        <asp:Button ID="btnMaakBezoeker" runat="server" Text="Maak Bezoeker" Width="131px" OnClick="btnMaakBezoeker_Click" />
        <br />
        <br />
        

    </div>

    <div>

    <div id="Plaats" class="Plaatsen">

        <asp:Label ID="Label11" runat="server" Text="Plaats"></asp:Label>
        :<asp:DropDownList ID="ddlPlaatsen" runat="server" style="margin-left: 37px; margin-bottom: 0px" Width="350px">
            <asp:ListItem>Peter</asp:ListItem>
            <asp:ListItem>Henkie</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnVoegPlaatsToe" runat="server" Height="56px" style="margin-top: 15px" Text="Voeg Plaats Toe" OnClick="btnVoegPlaatsToe_Click" />
        <asp:Button ID="btnVerwijderPlaats" runat="server" Height="47px" style="margin-left: 0px; margin-right: 0px;" Text="Verwijder Plaats" Width="189px" OnClick="btnVerwijderPlaats_Click" />
        <br />
        <asp:ListBox ID="lbPlaatsen" runat="server" CssClass="auto-style1" Height="133px"></asp:ListBox>
        <br />

        <br />
    </div>

        <br />
        <h3>Materiaal Verhuur</h3>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Type Huuritem"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlHuurItemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHuurItemType_SelectedIndexChanged" Width="133px">
                </asp:DropDownList>
        <br />
                <asp:Label ID="Label13" runat="server" Text="Merk"></asp:Label>
        <br />
                <asp:DropDownList ID="ddlMerken" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMerken_SelectedIndexChanged" Width="136px">
                </asp:DropDownList>
        <br />
                Volgnummer<br />
                <asp:DropDownList ID="ddlVolgnummers" runat="server" Width="136px">
                </asp:DropDownList>
                <br />
                <br />
                <br />
                
           </ContentTemplate>
        </asp:UpdatePanel>
                <asp:Button ID="btnKiesHuurItem" runat="server" Height="38px" OnClick="btnKiesHuurItem_Click" style="margin-left: 0px" Text="Kies" Width="85px" />
                <br />
                <asp:Label ID="Label14" runat="server" Text="Gekozen Items"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbGekozenItems" runat="server" Height="234px" style="margin-left: 0px" Width="426px"></asp:ListBox>
                    <asp:Button ID="btnVerwijderItem" runat="server" OnClick="btnVerwijderItem_Click" Text="Verwijder Item" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                

        <br />
        <br />
        <br />

    </div>
    <div class="EindInschrijf" id="Eindinschrijf">

        <asp:CheckBox ID="chbMeederePersonen" runat="server" Text="Meerdere Personen" />
        

                <asp:DropDownList ID="ddlMeerderePersonen" runat="server" style="margin-left: 0px" Width="118px">
                </asp:DropDownList>
                <br />

                <asp:Button ID="btnBevestig" runat="server" OnClick="btnBevestig_Click" Text="Bevestig" />

                <br />
                <br />


        <br />

    </div>
        <br />

        <br />
        <asp:Button ID="btnTerug" runat="server" OnClick="btnTerug_Click" Text="Terug" />
        <br />
        <asp:Image ID="imgCamping" runat="server" CssClass="Plaatje" ImageUrl="~/Plaatjes/Camping_ReeënDal (1).png" />

    </form>
</body>
</html>
