<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="passwordRecovery.aspx.cs" Inherits="EasyWebReport.passwordRecovery" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
       
<fieldset style="background-color: white;font-size: 14px;">
<legend>Servizio Web Easy</legend>
    <div class="row">            
        <div class="col-12">
                <div class="row">
                    <div class="col-1">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Immagini/Animation.gif"></asp:Image>
                    </div>
                    <div class="col-11">
                        <asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99" ></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-12">
                        &nbsp;Avvisi<br />
                        &nbsp;<asp:TextBox class="form-control" ID="labExtMessage" TextMode="MultiLine" ReadOnly="true" TabIndex="20" runat="server" MaxLength="1000" onfocus="document.getElementById(this.id).className='focused form-control';" onblur="document.getElementById(this.id).className='form-control';" Font-Bold="True" ForeColor="Red" BackColor="White"
                                        ></asp:TextBox>                            
                            <br />
                        <label><b>Selezionare la propria classe di utenza</b></label>
                        <asp:RadioButtonList ID="rbTipuUtente" runat="server">
                            <asp:ListItem Value="1">Responsabili</asp:ListItem>
                            <asp:ListItem Value="2">Fornitori</asp:ListItem>
                            <asp:ListItem Selected="True" Value="3">Utenti dell'applicazione</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <br />
                    </div>
                </div>
            <fieldset>
            <legend><b>Inserire i dati necessari  per accedere ai servizi.</b></legend>                
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="lblNomeUtente" TabIndex="1" runat="server" >Nome Utente:</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused form-control';" onblur="document.getElementById(this.id).className='form-control';" runat="server" MaxLength="50" ToolTip="Login fornita dal segretario amministrativo" TabIndex="2"
                            ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="2" runat="server"
                            ErrorMessage="Digitare il Nome Utente" ControlToValidate="txtNomeUtente" ></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label3" runat="server" >Codice Dipartimento:</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="txtCodiceDipartimento" runat="server" onfocus="document.getElementById(this.id).className='focused form-control';" onblur="document.getElementById(this.id).className='form-control';" MaxLength="50" 
                                ToolTip="Codice del dipartimento" TabIndex="3"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="Label5" runat="server" 
                            TabIndex="4"
                            ControlToValidate="txtCodiceDipartimento" ErrorMessage="Inserire il codice del dipartimento"   
                            > </asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">                        
                    <div class="col-md-4">                            
                        <asp:Button CssClass="btn btn-primary" ID="btnSend" Text="Invia codice via email" TabIndex="5" runat="server" onfocus="document.getElementById(this.id).className='focused btn btn-secondary';" onblur="document.getElementById(this.id).className='btn btn-primary';" ToolTip="Invia il codice di attivazione alla mail inserita all'attivazione" OnClick="btnSend_Click"
                                ></asp:Button>                            
                    </div>
                    <div class="col-md-8">                            
                        <asp:Label ID="labMessaggioSend" TabIndex="6" runat="server" ></asp:Label>
                    </div>
                </div>                   
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="lblToken" TabIndex="7" runat="server">Codice ricevuto via mail</asp:Label>                            
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="txtToken" TextMode="MultiLine" TabIndex="8" runat="server" MaxLength="1000" onfocus="document.getElementById(this.id).className='focused form-control';" onblur="document.getElementById(this.id).className='form-control';" ToolTip="Codice ricevuto via mail"
                                ></asp:TextBox>                            
                    </div>
                    <div class="col-md-4">                            
                        <asp:Label ID="lblMessaggioToken" TabIndex="99" runat="server" ></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="LabNewPwd" runat="server" >Nuova password</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="txtPwd" TextMode="Password" runat="server" onfocus="document.getElementById(this.id).className='focused form-control';" onblur="document.getElementById(this.id).className='form-control';" MaxLength="50" 
                                ToolTip="Nuova password da impostare" TabIndex="9"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                    </div>
                </div> 
                    <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="LabNewPWd2" runat="server" >Nuova password</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="txtPwd2" TextMode="Password" runat="server" onfocus="document.getElementById(this.id).className='focused form-control';" onblur="document.getElementById(this.id).className='form-control';" MaxLength="50" 
                                ToolTip="Ripetere nuova password da impostare" TabIndex="10"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                    </div>
                </div> 
                <div class="row">
                    <div class="col-md-4">
                        <asp:Button CssClass="btn btn-primary" ID="btnResetPwd" Text="Resetta password" TabIndex="-1" runat="server" onfocus="document.getElementById(this.id).className='focused btn btn-secondary';" onblur="document.getElementById(this.id).className='btn btn-primary';" ToolTip="Reimposta la password" OnClick="btnResetPwd_Click"
                                ></asp:Button>                            
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</fieldset>

   
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

