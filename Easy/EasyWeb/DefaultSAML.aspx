<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MetaMasterBootstrap.master" CodeFile="DefaultSAML.aspx.cs" Inherits="DefaultSAML" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">
    <div class="jumbotron">
        <h1>Easy</h1>
        <h2>Servizio Web</h2>
        <p id="message">Rilevazione del blocco dei pop-up in corso. Attendere l'avvio della sessione...</p>
    </div>

    <div class="content">
        <p class="text-center">
            <asp:HyperLink ID="link" runat="server" Font-Size="Medium" Target="_blank" NavigateUrl="~/EasyWeb Impostazioni Browser.pdf">
                Istruzioni per la configurazione del browser.
            </asp:HyperLink>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="JScriptBeforeLibs" runat="server">
    <script type="text/javascript">
        function detectPopupBlocker() {
            var testWindow = window.open("about:blank", "", "height=100,width=100");
            if (testWindow) {
                testWindow.close();
                
                window.location = "DefaultSAML.aspx?popup=ok";
            }
            else {
                $("#message").text("Rilevato blocco dei pop-up attivo. Configurare il browser e ricaricare la pagina.");
            }
        }

        detectPopupBlocker();
    </script>
</asp:Content>
