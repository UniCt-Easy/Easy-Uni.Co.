<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="passwordRecovery.aspx.cs" Inherits="EasyWebReport.passwordRecovery" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
    
<div style="width: 100%">
<center>
   
       
    <fieldset style="background-color: #eeeeee;font-size: 14px;">
    <legend>Servizio Web Easy</legend>
    <table style="width: 100%" >
        <tr>
            
            <td  style="width: 100%">
                <div align="left">
                    <table>
                        <tr>
                            <td width="20%" align="center" >
                                <asp:Image ID="Image1" runat="server" ImageUrl="Immagini/Animation.gif"></asp:Image>
                            </td>
                            <td style="width: 80%;">
                                <asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                    &nbsp;Avvisi<br />
                    &nbsp;<asp:TextBox ID="labExtMessage" TextMode="MultiLine" ReadOnly="true" TabIndex="20" runat="server" MaxLength="1000" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" Width="934px" Height="51px" Font-Bold="True" ForeColor="Red" BackColor="White"
                                 ></asp:TextBox>                            
                        <br />
                    <fieldset style="background-color: White; width:60%">
                    <legend><b>Selezionare la propria classe di utenza</b></legend>
                    <asp:RadioButtonList ID="rbTipuUtente" runat="server">
                        <asp:ListItem Value="1">Responsabili</asp:ListItem>
                        <asp:ListItem Value="2">Fornitori</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">Utenti dell'applicazione</asp:ListItem>
                    </asp:RadioButtonList>
                    </fieldset>
                    <br />
                    <br />
                   </div>
                <fieldset>
                <legend><b>Inserire i dati necessari  per accedere ai servizi.</b></legend>
                
                <table style="width: 100%">
                    <tr>
                        <td align="left" >
                            <asp:Label ID="lblNomeUtente" TabIndex="1" runat="server" >Nome Utente:</asp:Label>
                        </td>
                        <td align="left" style="width: 133px" >
                            <asp:TextBox ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Login fornita dal segretario amministrativo" TabIndex="2"
                                ></asp:TextBox>                           
                        </td>
                        <td align="left" >
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="2" runat="server"
                                ErrorMessage="Digitare il Nome Utente" ControlToValidate="txtNomeUtente" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            <asp:Label ID="Label3" runat="server" >Codice Dipartimento:</asp:Label></td>
                        <td align="left" style="width: 133px" >
                            <asp:TextBox ID="txtCodiceDipartimento" runat="server" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" MaxLength="50" 
                                 ToolTip="Codice del dipartimento" TabIndex="3"></asp:TextBox>
                        </td>
                        <td align="left" >
                            <asp:RequiredFieldValidator ID="Label5" runat="server" 
                               TabIndex="4"
                                ControlToValidate="txtCodiceDipartimento" ErrorMessage="Inserire il codice del dipartimento"   
                                > </asp:RequiredFieldValidator></td>
                    </tr>
                     <tr>                        
                        <td align="center"  colspan="2">                            
                            <asp:Button ID="btnSend" Text="Invia codice via email" TabIndex="5" runat="server" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" ToolTip="Invia il codice di attivazione alla mail inserita all'attivazione" OnClick="btnSend_Click"
                                 ></asp:Button>                            
                        </td>
                        <td align="left" >                            
                            <asp:Label ID="labMessaggioSend" TabIndex="6" runat="server" ></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="left" >
                            <asp:Label ID="lblToken" TabIndex="7" runat="server">Codice ricevuto via mail</asp:Label>                            
                        </td>
                        <td align="left" style="width: 133px" >
                            <asp:TextBox ID="txtToken" TextMode="MultiLine" TabIndex="8" runat="server" MaxLength="1000" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" ToolTip="Codice ricevuto via mail" Width="274px" Height="31px"
                                 ></asp:TextBox>                            
                        </td>
                        <td align="left" >                            
                            <asp:Label ID="lblMessaggioToken" TabIndex="99" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            <asp:Label ID="LabNewPwd" runat="server" >Nuova password</asp:Label></td>
                        <td align="left" style="width: 133px" >
                            <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" MaxLength="50" 
                                 ToolTip="Nuova password da impostare" TabIndex="9"></asp:TextBox>
                        </td>
                        <td align="left" >
                           </td>
                    </tr> 
                     <tr>
                        <td align="left" >
                            <asp:Label ID="LabNewPWd2" runat="server" >Nuova password</asp:Label></td>
                        <td align="left" style="width: 133px" >
                            <asp:TextBox ID="txtPwd2" TextMode="Password" runat="server" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" MaxLength="50" 
                                 ToolTip="Ripetere nuova password da impostare" TabIndex="10"></asp:TextBox>
                        </td>
                        <td align="left" >
                           </td>
                    </tr> 
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnResetPwd" Text="Resetta password" TabIndex="-1" runat="server" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" ToolTip="Reimposta la password" OnClick="btnResetPwd_Click"
                                 ></asp:Button>                            
                        </td>
                    </tr>
                </table>
                </fieldset>
            </td>
        </tr>
    </table>
    </fieldset>
    </center>
    </div>

   
</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="JScriptBeforeLibs" Runat="Server">
     <script type="text/javascript">
         var FocusOnStartup = null;
</script>
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="JScriptAfterLibs" Runat="Server">
    <script type="text/javascript">
        $(function () {
            //initPGridFun($);
            $("#_ctl0_CHP_PC_DIV").draggable();

            //$("#draggable_message").attr("style","display:none");       
            $("#_ctl0_CHP_PC_DIV").css("width", "800px");
            $("#_ctl0_CHP_PC_DIV").css("overflow", "hidden");

        });
</script>
</asp:Content>

