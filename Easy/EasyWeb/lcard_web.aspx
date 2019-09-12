<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" 
        CodeFile="lcard_web.aspx.cs" Inherits="lcard_web" Title="Card Magazzino"  %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>


<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">

<div style='position:relative;width:719px;height:515px;'>
<HelpWeb:hwDataGridWeb runat="server" id="dataGrid1" tag="lcardcf.lista.single" style="position: absolute;  left:107px; top:307px; width:585px;height:160px;" TabIndex="18" Height="145px" Width="382px" />
<HelpWeb:hwButton runat="server" id="btnInserisci" tag="insert.single" style="position: absolute;  left:15px; top:316px; width:86px;height:26px;" TabIndex="15" Text="Inserisci"/>
<HelpWeb:hwButton runat="server" id="btnModifica" tag="edit.single" style="position: absolute;  left:15px; top:348px; width:86px;height:26px;" TabIndex="16" Text="Modifica"/>
<HelpWeb:hwButton runat="server" id="btnElimina" tag="delete" style="position: absolute;  left:15px; top:380px; width:86px;height:26px;" TabIndex="17" Text="Elimina"/>
<HelpWeb:hwTextBox runat="server" id="txtCodice" tag="lcard.extcode" style="position: absolute;  left:433px; top:271px;width:253px;" TabIndex="10" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label7" tag="" style="position: absolute;  left:430px; top:255px; width:80px;height:17px;text-align: left; vertical-align: top;" Text="Codice esterno"></HelpWeb:hwLabel>
<HelpWeb:hwDropDownList runat="server" AutoPostBack="true" id="cmbMagazzino" tag="lcard.idstore" style="position: absolute;  left:15px; top:271px; width:276px;" TabIndex="9"></HelpWeb:hwDropDownList>
<HelpWeb:hwLabel runat="server" id="label6" tag="" style="position: absolute;  left:12px; top:255px; width:59px;height:17px;text-align: left; vertical-align: top;" Text="Magazzino"></HelpWeb:hwLabel>
<HelpWeb:hwDropDownList runat="server" AutoPostBack="true" id="cmbResponsabile" tag="lcard.idman" style="position: absolute;  left:15px; top:213px; width:276px;" TabIndex="7"></HelpWeb:hwDropDownList>
<HelpWeb:hwLabel runat="server" id="label5" tag="" style="position: absolute;  left:12px; top:197px; width:73px;height:17px;text-align: left; vertical-align: top;" Text="Responsabile"></HelpWeb:hwLabel>
<HelpWeb:hwCheckBox runat="server" id="chkActive" tag="lcard.active:S:N" style="position: absolute;  left:639px; top:164px; width:52px;" TabIndex="5" Text="Attiva"/>
<HelpWeb:hwTextBox runat="server" id="txtFine" tag="lcard.ystop" style="position: absolute;  left:174px; top:164px;width:58px;" TabIndex="4" ></HelpWeb:hwTextBox>
<HelpWeb:hwTextBox runat="server" id="txtInizio" tag="lcard.ystart" style="position: absolute;  left:15px; top:164px;width:58px;" TabIndex="3" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label4" tag="" style="position: absolute;  left:171px; top:148px; width:90px;height:17px;text-align: left; vertical-align: top;" Text="Anno fine validità"></HelpWeb:hwLabel>
<HelpWeb:hwLabel runat="server" id="label3" tag="" style="position: absolute;  left:12px; top:148px; width:98px;height:17px;text-align: left; vertical-align: top;" Text="Anno inizio validità"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtDescrizione" tag="lcard.description" style="position: absolute;  left:15px; top:75px;height:55px;width:671px" TextMode="MultiLine" TabIndex="2" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label2" tag="" style="position: absolute;  left:12px; top:59px; width:63px;height:17px;text-align: left; vertical-align: top;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtIntestazione" tag="lcard.title" style="position: absolute;  left:15px; top:25px;width:671px;" TabIndex="1" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label1" tag="" style="position: absolute;  left:12px; top:9px; width:65px;height:17px;text-align: left; vertical-align: top;" Text="Intestazione"></HelpWeb:hwLabel>
    <HelpWeb:hwTextBox ID="txtAmount" runat="server" Style=" left: 569px;
        width: 120px; position: absolute; top: 212px" TabIndex="4" Tag="lcardtotal.amount"
        Width="61px" ReadOnly="True"></HelpWeb:hwTextBox>
    <HelpWeb:hwLabel ID="HwLabel1" runat="server" Style=" left: 566px; vertical-align: top;
        width: 150px; position: absolute; top: 193px; height: 17px; text-align: left" Text="Importo Residuo della Card"></HelpWeb:hwLabel>
</div>


</asp:Content>
