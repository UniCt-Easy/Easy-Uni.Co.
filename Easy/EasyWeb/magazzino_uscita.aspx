<%@ Page Language="C#" MasterPageFile="MetaMaster.master"   CodeFile="magazzino_uscita.aspx.cs" Inherits="EasyWebReport.magazzino_uscita" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">

<script type="text/javascript">
$(function() {
  $(".startfocus").focus();
});

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
                    
                   </div>
                <fieldset>
                <legend><b>Inserire la scansione del codice a barre</b></legend>
                
                <table width="100%">
                
                
                    <tr>
                        <td align="left" style="height: 26px" >
                            <asp:Label ID="lblCodice" TabIndex="99" runat="server" >Lettura codice a barre</asp:Label>
                        </td>
                        <td align="left" style="height: 26px" >
                            <asp:TextBox ID="txtCodice"  CssClass="startfocus" TabIndex="1"  onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Login fornita dal segretario amministrativo" 
                                ></asp:TextBox>                           
                        </td>
                        <td align="left" style="height: 26px" >
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="99" runat="server"
                                ErrorMessage="Effettuare la lettura o inserire a mano il codice a barre" ControlToValidate="txtCodice" ></asp:RequiredFieldValidator>
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
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Immagini/approvato.png" OnClick="ImageButton1_Click" />
                            <asp:ImageButton ID="ImageButton2"  runat="server" ImageUrl="~/Immagini/annullato.png" />
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

