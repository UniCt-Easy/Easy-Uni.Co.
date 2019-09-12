<%@ Page Language="c#" MasterPageFile="~/MetaMasterBootstrap.master"   Inherits="EasyWebReport.LoginLDAP" CodeFile="LoginLDAP.aspx.cs" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-2">
            <!-- colonne vuote a sinistra          -->
        </div>
        <div class="col-md-8">
            <!-- corpo al centro          -->
            <div class="row">
                <div class="text-center col-md-12">
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
            </fieldset><!-- Chiude fieldset: Servizio Web Easy            -->


                <fieldset>
                    <legend>Inserire i dati necessari  per accedere ai servizi.</legend>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblNomeUtente" TabIndex="99" runat="server">Nome Utente:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Login fornita dal segretario amministrativo" TabIndex="2" OnTextChanged="txtNomeUtente_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="99" runat="server"
                                ErrorMessage="Digitare il Nome Utente" ControlToValidate="txtNomeUtente"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblPassword" TabIndex="99" runat="server">Password</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPassword" TabIndex="3" runat="server" MaxLength="50" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" ToolTip="Password fornita dal segretario amministrativo"
                                TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" TabIndex="99" runat="server"
                                ErrorMessage="Digitare la password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>

                            <asp:Label ID="lblMessaggioPass" TabIndex="99" runat="server"></asp:Label>
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
                            <asp:Button ID="btnRefresh" ToolTip="Visualizza l'elenco dei dipartimenti a cui puoi accedere" CssClass='btnRefresh' runat="server" OnClick="btnRefresh_Click" Text="Calcola elenco" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-1">
                            <asp:ImageButton ID="btnOk" TabIndex="6" runat="server" ImageUrl="~/Immagini/SendChat.gif"  />
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                </fieldset><!-- Chiude fieldset: Selezionare la propria classe di utenza       -->

        </div>
        <div class="col-md-2"><!-- colonne vuote a destra          -->
        </div>
    </div>

</asp:Content>




