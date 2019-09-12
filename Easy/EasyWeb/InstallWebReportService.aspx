<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InstallWebReportService.aspx.cs" Inherits="EasyWebReport.InstallWebReportService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Configurazione Servizio Web Report</title>
</head>
<body style="font-family: Arial, Helvetica; font-size: 12px;">
    <form id="form1" runat="server">
    <div>
    <center>
    <br />
    <p style="text-align: center; font-size: 18px; font-weight: bold; text-align:center;color: blue;">Configurazione Servizio Web Report</p>
    <br />
    <div style="width: 65%; font-size: 11px; text-align: justify; ">
    <b><i>Attenzione:</i></b>&nbsp;&nbsp;Prima di eseguire questa configurazione &egrave; <u>necessario</u> assegnare i permessi in lettura/scrittura all'utente 
    impersonato alla cartella "cfg" dell'applicazione Web. <b>Dopo</b> aver effettuato correttamente la configurazione sar&agrave; possibile rimuoverli.<br/>
    Per configurare il Servizio, è necessario inserire la <b>Password di abilitazione alla configurazione</b> e cliccare sul pulsante <i>"Verifica"</i>.
    Successivamente è possibile inserire i dati di configurazione del Database di Sistema e la directory dei Report. Una volta terminato, cliccare sul pulsante
     "Salva Modifiche"
        per modificare il file di configurazione.<br />

    </div>
    </center>
    <br />
        <center>
            <asp:Label runat="server" ID="lblmessages" Text="" style="color: Red;"></asp:Label>
            </center>
        <center>
            &nbsp;</center>
        <center>

    <table width="70%">
    <tr>
        <td width="50%">
            <fieldset style="width: 95%; background-color: #eaeaea;">
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
            <br />
            <br />
            <asp:Label runat="server" ID="lblImpUser" style="color: Blue;" Text=""></asp:Label>
            <br />
            <br />
            <fieldset style="width: 95%; background-color: #eaeaea;">
            <legend>Configurazione Report</legend>
            <table>
            <tr>
                <td width="40%"  style="text-align: right;"><strong>Directory per l'accesso ai Report:</strong></td>
                <td width="60%"  ><asp:TextBox runat="server" ID="txtReport" ></asp:TextBox></td>
            </tr>
            </table>
            </fieldset>
        </td>
        <td width="50%">
         <fieldset style="width: 95%;background-color: #eaeaea;">
         <legend>Dati di collegamento al DataBase di Sistema</legend>
         <table width="90%">
            <tr>
                <td width="40%" style="text-align: right;"><strong>Nome DBMS Server:</strong></td>
                <td width="60%"><asp:TextBox runat="server" ID="txtServer" style="width: 100%"></asp:TextBox></td>
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
            <br />
        
        </td>
    </tr>
    </table>
    <br />
    <br />
    <asp:Button runat="server" ID="btnSalva" Text="Salva Modifiche" OnClick="btnSalva_Click" />&nbsp;&nbsp;
        </center>
    </div>
    </form>
</body>
</html>
