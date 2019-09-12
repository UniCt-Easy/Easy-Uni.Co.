<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebUsersManagement.aspx.cs" Inherits="EasyWebReport.WebUsersManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gestione Utenti Web</title>
</head>
<body style="font-family: Arial, helvetica; font-size: 11px;">
    <form id="form1" runat="server">
<center>
    <table width="60%">
    <tr>
    <td width="70%" valign="top">
        
        <center>
        <fieldset style="width: 95%;background-color: #eaeaea;">
        
        <legend style="text-align:center; font-size: 13px; font-weight: bold;">Gestione Utenti Web</legend>
        <p style="font-size:11px; text-align: justify; width:95%">
            Per effettuare operazioni sugli utenti è necessario utilizzare i propri <strong>dati
                di accesso</strong> all'applicazione.</p>
        <asp:Label runat="server" style="color:Red; font-weight:bold;" ID="lblError" Font-Bold="True" Font-Size="Medium" >Connessione non effettuata</asp:Label><br />
            <br />
                <asp:Label ID="lbldbstatus" runat="server" style="color: Green;" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
            <br />
        
        <asp:Panel width="100%" ID="customuserdata" runat="server">
            <table width="95%">
            <tr><td style="height: 135px">
            <center>
        <fieldset runat="server" id="typeofuser" style="text-align:left; width: 80%; background-color: White;">
        <legend>Tipologia:</legend><asp:RadioButtonList ID="userkind" AutoPostBack="true" runat="server" OnSelectedIndexChanged="userkind_SelectedIndexChanged" >
        <asp:ListItem Value="1">Responsabile</asp:ListItem>
        <asp:ListItem Value="2">Fornitore</asp:ListItem>
        <asp:ListItem Value="3">Utente dell'Applicazione</asp:ListItem>
        <asp:ListItem Value="4" Selected="true">Utente LDAP</asp:ListItem>
        <asp:ListItem Value="5" Selected="true">Utente SSO</asp:ListItem>
        </asp:RadioButtonList>
        </fieldset>
        </center>
        </td>
        <td style="height: 135px">
        <table width="90%">
        <tr>
            <td width="25%" style="text-align:right;">Login:</td><td style="width: 75%"><asp:TextBox style="width:100%" runat="server" ID="txtlogin"></asp:TextBox></td>
        </tr>            
        <tr>
            <td width="25%" style="text-align:right;">Utente Applicativo:</td><td style="width: 75%"><asp:TextBox runat="server" style="width: 100%" ID="txtcustuser"></asp:TextBox></td>
        </tr>
        </table>
        <center><asp:Button runat="server" id="btnchoose" Text="Seleziona Utente Applicativo" OnClick="btnchoose_Click" />
        <asp:Button runat="server" ID="btnrespforn" Text="Seleziona" visible="false" OnClick="btnrespforn_Click"/>
        </center>
            </td>
            
        </tr>
        </table>
        <br />
        <center>
        <fieldset runat="server" id="identity" style="width: 80%; height: 117px;">
        <legend>Informazioni di Identificazione</legend>
        <table width="90%">
        <tr>
        <td width="10%" style="text-align:right; height: 26px;">Cognome:</td>
        <td width="40%" style="height: 26px"><asp:TextBox style="width:100%"  runat="server" ID="txtCognome"></asp:TextBox></td>
        <td width="10%" style="text-align:right; height: 26px;">Nome:</td>
        <td style="width: 217px; height: 26px"><asp:TextBox style="width:100%" runat="server" ID="txtNome"></asp:TextBox></td>
        </tr>
        <tr>
        <td width="10%" style="text-align:right;">Codice Fiscale:</td>
        <td width="40%"><asp:TextBox style="width:100%" runat="server" ID="txtCf"></asp:TextBox></td>
        <td width="10%" style="text-align:right;">Email:</td>
        <td style="width: 217px; height: 26px"><asp:TextBox style="width:100%" runat="server" ID="txtEmail"></asp:TextBox></td>
        </tr>


        </table>
        </fieldset>
        </center>
        
            <br />
        </asp:Panel>            
        <fieldset runat="server" id="connectiondata" style="width: 40%; background-color: #eaeaea;">
        <legend>Dati di connessione al DataBase</legend>
            <br />

        <table width="95%">
        <tr>
        <td style="text-align:right; height: 26px;" width="25%"><strong>Utente:</strong></td><td width="75%" style="height: 26px" ><asp:TextBox runat="server" style="width:100%" ID="txtdbusername"></asp:TextBox></td>
        </tr>
        <tr>
        <td style="text-align:right" width="25%"><strong>Password:</strong></td><td width="75%" ><asp:TextBox runat="server" style="width:100%" ID="txtdbpasswd" TextMode="password"></asp:TextBox></td>
        </tr>
        <tr>
        <td style="text-align:right" width="25%"><strong>Codice Dipartimento:</strong></td><td width="75%" ><asp:TextBox runat="server" style="width:100%" ID="txtcoddip" ></asp:TextBox></td>
        </tr>
        </table>
        <center>
            &nbsp;</center>
            <center>
                &nbsp;</center>
            <center>
                &nbsp;</center>
        </fieldset>
            <br />
        <br />
        <center><asp:Button ID="btnclear" runat="server" text="Svuota" OnClick="btnclear_Click"/>
        <asp:Button ID="btnread" runat="server" text="Leggi" OnClick="btnread_Click"/>
        <asp:Button ID="btnadd" runat="server" text="Salva" OnClick="btnadd_Click"/>
        <asp:Button ID="btndel" OnClientClick="javascript:return confirm('Cancellare l\'utente corrente?');" runat="server" text="Elimina" OnClick="btndel_Click"/>
        <asp:Button ID="btnshow" runat="server" text="Mostra Elenco Utenti" OnClick="btnshow_Click"/>
        <asp:Button ID="btndisconnect" runat="server" text="Disconnetti" OnClick="btndisconnect_Click"/>
            <asp:Button ID="btnConnetti" runat="server" text="Connetti" OnClick="btnConnetti_Click"/></center>
            <center>
                &nbsp;</center>
        </fieldset>
        </center>
        </td>    
    </tr>
    </table>    
</center>    
<asp:TextBox runat="server" style="display:none;" ID="txtidvirtualuser"></asp:TextBox>
<asp:TextBox runat="server" style="display:none;" ID="txtidcustomuser" ></asp:TextBox>
<asp:TextBox runat="server" style="display:none;" ID="txtidregistryreference" ></asp:TextBox>
<asp:TextBox runat="server" style="display:none;" ID="txtidman" ></asp:TextBox>
    </form>
<center>
<div id="list" runat="server" style="position:fixed; max-height:450px; overflow: auto;"><asp:PlaceHolder runat="server" ID="listplaceholder"></asp:PlaceHolder></div></center>
<script type="text/javascript">

    function submitclick(pid,ptype)
    {
    
        if(pid!=null && pid!="")
        {
            switch(ptype)
            {
                case 'virtualuser':
                    document.getElementById("txtidvirtualuser").value=pid;
                break;
                case 'customuser':
                    document.getElementById("txtidcustomuser").value=pid;
                break;
                case 'registryreference':
                    document.getElementById("txtidregistryreference").value=pid;
                break;
                case 'manager':
                    document.getElementById("txtidman").value=pid;
                break;
            }
        }
        document.form1.submit();
        return;
    }

</script>
</body>
</html>
