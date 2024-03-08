<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewServer.aspx.cs" Inherits="EasyWebReport.AddNewServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Server</title>
</head>
<body style="font-family: Arial, Helvetica; font-size: 12px; color: Black;"> 
    <form id="form1" runat="server">
    <div>
    <center>
        <p style="color: Blue; font-size: 18px; text-align:center;">Aggiunta Server al Servizio di Web Reporting</p>
    
    <div style="width: 65%; font-size: 11px; text-align: justify; ">
    Questo form consente di aggiungere un <b>Server</b> al Servizio di Web Reporting. Per configurare il Servizio, è necessario inserire la <b>Password di abilitazione alla configurazione</b> e cliccare sul pulsante <i>"Verifica"</i>.
     E' necessario inserire il Codice ed il nome del Dipartimento ed i dati di collegamento al DataBase. Il Codice Dipartimento sar&agrave; richiesto all'autenticazione all'applicazione. Dopo aver completato i dati del form, cliccare sul pulsante <b>"Aggiungi".</b></div>
    <br />
        <center>
            <asp:Label runat="server" ID="lblmessages" Text="" style="color: Red;"></asp:Label>
            </center>
    <br />
            <fieldset style="width: 40%; background-color: #eaeaea;">
            <legend>Password di abilitazione alla configurazione</legend>
            <table width="90%">
            <tr>
                <td width="30%" style="text-align: right;"><strong>Inserire Password:</strong></td>
                <td width="40%" ><asp:TextBox TextMode="Password" runat="server" ID="txtPwdSystem"></asp:TextBox></td>
                <td width="30%" style="text-align: center;"><asp:Button Text="Verifica" runat="server" ID="btnVerifica" OnClick="btnVerifica_Click" /></td>
            </tr>
            </table>
            <center></center>
            </fieldset>

    </center>
        <center>

            <br />
            
             <fieldset style="width: 40%;background-color: #eaeaea;">
             <legend>Dati di collegamento al DataBase</legend>
             <table width="90%">
                <tr>
                    <td width="40%" style="text-align: right;"><strong>Nome Dipartimento da Aggiungere:</strong></td>
                    <td width="60%"><asp:TextBox runat="server" ID="txtDip" style="width: 100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="40%" style="text-align: right;"><strong>Codice Dipartimento:</strong></td>
                    <td width="60%"><asp:TextBox runat="server" ID="txtCodice" style="width: 100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="40%" style="text-align: right;"><strong>Indirizzo IP DBMS Server:</strong></td>
                    <td width="60%"><asp:TextBox runat="server" ID="txtIP" style="width: 100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="40%" style="text-align: right;"><strong>Nome DataBase:</strong></td>
                    <td width="60%"><asp:TextBox runat="server" ID="txtDB" style="width: 100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="40%" style="text-align: right;"><strong>Nome Utente:</strong></td>
                    <td width="60%"><asp:TextBox runat="server" ID="txtUser" style="width: 100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="40%" style="text-align: right;"><strong>Password:</strong></td>
                    <td width="60%"><asp:TextBox runat="server" TextMode="Password" ID="txtPWD" style="width: 100%"></asp:TextBox></td>
                </tr>
             </table>
             </fieldset>  
        </center>
        <br />
        <center>
            <asp:Button runat="server" ID="brnAdd" Text="Aggiungi" OnClick="brnAdd_Click" /></center>

    </div>
    </form>
</body>
</html>
