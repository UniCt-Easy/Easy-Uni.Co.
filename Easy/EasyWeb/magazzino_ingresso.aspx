<%@ Page Language="c#" MasterPageFile="MetaMaster.master"   Inherits="EasyWebReport.magazzino_ingresso"
    CodeFile="magazzino_ingresso.aspx.cs" %>


<asp:Content ID="Content3" ContentPlaceHolderID="CHP_PC" runat="Server">
<script type="text/javascript">
    /*
    $(function() {
        $( "#_ctl0_CHP_PC_DIV" ).draggable();
		
        $("#draggable_message").attr("style","display:none");       
        $("#_ctl0_CHP_PC_DIV").css("width","500px");
        $("#_ctl0_CHP_PC_DIV").css("overflow","hidden");
        
        
    });
    */
</script>

    <div>
    
  
    <center> 
    <fieldset style="background-color: #eeeeee;font-size: 14px;">
    <legend>Accesso al magazzino</legend>
            <table >
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
                    <asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>&nbsp;<br />
                    &nbsp;<br />
                    <fieldset style="background-color: White; width:60%">
                    <legend><b>Selezionare la propria classe di utenza</b></legend>
                    <asp:RadioButtonList ID="rbTipuUtente" runat="server">
                        <asp:ListItem Value="1">Responsabili</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">Utenti dell'applicazione</asp:ListItem>
                        <asp:ListItem Value="4">Utenti LDAP</asp:ListItem>
                    </asp:RadioButtonList>
                    </fieldset>
                    <br />
                    <br />
                   </div>
                <fieldset>
                <legend><b>Inserire i dati necessari  per accedere ai servizi.</b></legend>
                
                <table width="100%">
                    <tr>
                        <td align="left" >
                            <asp:Label ID="lblNomeUtente" TabIndex="99" runat="server" >Nome Utente:</asp:Label>
                        </td>
                        <td align="left" >
                            <asp:TextBox ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Login fornita dal segretario amministrativo" TabIndex="2"
                                ></asp:TextBox>                           
                        </td>
                        <td align="left" >
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="99" runat="server"
                                ErrorMessage="Digitare il Nome Utente" ControlToValidate="txtNomeUtente" ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            <asp:Label ID="lblPassword" TabIndex="99" runat="server">Password</asp:Label>                            
                        </td>
                        <td align="left" >
                            <asp:TextBox ID="txtPassword" TabIndex="3" runat="server" MaxLength="50" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" ToolTip="Password fornita dal segretario amministrativo"
                                 TextMode="Password"></asp:TextBox>                            
                        </td>
                        <td align="left" >
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" TabIndex="99" runat="server"
                                ErrorMessage="Digitare la password" ControlToValidate="txtPassword" ></asp:RequiredFieldValidator>
                            <asp:Label ID="lblMessaggioPass" TabIndex="99" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" TabIndex="6" runat="server" ImageUrl="~/Immagini/SendChat.gif" />
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