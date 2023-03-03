<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MetaMasterBootstrap.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">
    <div class="jumbotron">
        <h1>Easy Pagamenti</h1>
        <h2>Servizio Web</h2>
        <p>Se non si dovesse aprire la pagina di login consultare le <a href="docHelp/Impostazioni Browser.pdf">istruzioni</a> per l'abilitazione dei popup</p>
    </div>

    <div>
        <asp:HyperLink Style="text-align: center;" ID="HyperLink1" runat="server" Font-Size="Medium"
            Target="_blank" NavigateUrl="~/docHelp/Impostazioni Browser.pdf">Istruzioni per la configurazione del browser</asp:HyperLink><br />
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="JScriptBeforeLibs" runat="server">
    <script type="text/javascript">
        function detectPopupBlocker() {
            var testWindow = window.open("about:blank", "", "height=100,width=100");
            if (testWindow) {
                testWindow.close();
                window.location = "LoginServizi.aspx";
            }
            else {
                $("#message").text("Rilevato blocco dei pop-up attivo. Configurare il browser e ricaricare la pagina.");
            }
        }

        detectPopupBlocker();
    </script>
</asp:Content>


