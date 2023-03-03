<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="ActivateAccount.aspx.cs" Inherits="Activate" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
    <div class="row">
        <div class="col-12">
            <h2 style="text-align :center">Attivazione Account</h2>
        </div>
    </div>

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></asp:Label>
            <asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>
        </div>
    </div>

    <div id="campi" runat="server">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <h4 style="width:80%;margin:auto;margin-top:15px;text-align:center;">Inserisci la email con la quale ti sei registrato e il codice di attivazione che hai ricevuto via mail</h4>   
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="row" style="margin-top:25px;">
                    <div class="col-md-2">
                        <asp:Label ID="lblEmail" TabIndex="99" runat="server">Email:</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtEmail" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" 
                            runat="server" MaxLength="50" ToolTip="Inserisci la Email con la quale ti sei registrato" TabIndex="3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" TabIndex="99" runat="server"
                            ErrorMessage="Inserire la Email con la quale ti sei registrato" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:Label ID="lblCodice" TabIndex="99" runat="server">Codice:</asp:Label>
                    </div>
                    <div class="col-md-4 col-6">
                        <asp:TextBox ID="txtCodice" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" 
                            runat="server" MaxLength="50" ToolTip="Inserisci il codice che hai ricevuto via EMail" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" TabIndex="99" runat="server"
                            ErrorMessage="Inserire il codice di attivazione che hai ricevuto via Email" ControlToValidate="txtCodice"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-6">
                        <button style="float:right" type="submit">Attiva Account</button>
                    </div>
                </div>
                <br />
                <a ID="LinkResend" runat="server" style="display:none;" class="btn btn-default" href="CodeResend.aspx">Invia Nuovo Codice</a>
            </div>
        </div>
    </div>

    <div class="row mb-25">
        <div class="col-md-8 col-md-offset-2">
			<a ID="LinkLogin" runat="server" class="btn btn-default" href="LoginServizi.aspx">Torna alla Login</a>
        </div>
    </div>
    
</asp:Content>