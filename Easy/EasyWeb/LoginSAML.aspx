<%@ Page Language="c#" MasterPageFile="~/MetaMasterBootstrap.master" Inherits="EasyWebReport.LoginSAML" CodeFile="LoginSAML.aspx.cs" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">

    <div class="container">

        <!-- corpo al centro  -->
        <div class="col-md-8 col-md-offset-2">
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:HyperLink Style="text-align: center;" ID="HyperLink1" runat="server" Font-Size="Medium"
                        Target="_blank" NavigateUrl="~/EasyWeb Impostazioni Browser.pdf">Istruzioni per la configurazione del browser</asp:HyperLink>
                </div>
            </div>

            <fieldset style="background-color: #eeeeee; font-size: 14px;">
                <legend>Servizio Web Easy</legend>
                <div class="row">
                    <div class="col-md-1">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Immagini/Animation.gif"></asp:Image>
                    </div>
                    <div class="col-md-11">
                        <asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></asp:Label>
                        <asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>
                    </div>
                </div>
            </fieldset>
            <!-- Chiude fieldset: Servizio Web Easy -->

            <fieldset>
                <legend>Inserire i dati necessari  per accedere ai servizi.</legend>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblNomeUtente" TabIndex="99" runat="server">Nome Utente:</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Login fornita dal servizio SSO" TabIndex="2" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblData" runat="server">Data Contabile</asp:Label>:
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDataContabile" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" Style="text-align: right;" TabIndex="4" runat="server" MaxLength="12" ToolTip="Data Contabile"></asp:TextBox>
                    </div>
                    <div class="col-md-5">
                        <asp:RequiredFieldValidator ID="Label4" runat="server" TabIndex="99" ControlToValidate="txtDataContabile"
                            ErrorMessage="Inserire la Data Contabile"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label3" runat="server">Codice Dipartimento:</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="cmbDipartimento" runat="server" TabIndex="5"></asp:DropDownList>
                    </div>
                    <div class="col-md-5">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-md-offset-5 text-center">
                        <asp:ImageButton ID="btnOk" TabIndex="6" runat="server" ImageUrl="~/Immagini/SendChat.gif" OnClick="btnOk_Click" />
                    </div>
                </div>
            </fieldset>
            <!-- Chiude fieldset: Selezionare la propria classe di utenza -->

        </div>

    </div>

</asp:Content>
