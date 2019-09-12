<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="showcasedetail_single.aspx.cs" Inherits="showcasedetail_single" Title="Dettaglio vetrina" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
<div style='position:relative;width:621px;height:385px;'>
<img src="Immagini/pixel.gif" alt="" width="319" height="1" style="position:absolute;left:275px;top:48px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="227" style="position:absolute;left:275px;top:48px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="227" style="position:absolute;left:593px;top:48px;"/>
<img src="Immagini/pixel.gif" alt="" width="319" height="1" style="position:absolute;left:275px;top:274px;"/>
<div class="GroupBoxLabel" style="position:absolute;  left:285px;top:43px;">Immagine</div>
<HelpWeb:hwPanel runat="server" id="grpimage" style="position:absolute;  left: 275px; top: 48px; width:319px;height:227px;" >
</HelpWeb:hwPanel>
<HelpWeb:hwTextBox runat="server" id="txtordered" tag="stocktotalview.ordered" style="position: absolute;  left:448px; top:302px;width:53px;" TabIndex="14" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label8" tag="" style="position: absolute;  left:352px; top:305px; width:94px;height:17px;text-align: left; vertical-align: top;" Text="Quantità Ordinata"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtbooked" tag="stocktotalview.booked" style="position: absolute;  left:275px; top:302px;width:53px;" TabIndex="11" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label7" tag="" style="position: absolute;  left:173px; top:305px; width:99px;height:17px;text-align: left; vertical-align: top;" Text="Quantità Prenotata"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtnumber" tag="stocktotalview.number" style="position: absolute;  left:115px; top:302px;width:46px;" TabIndex="9" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label6" tag="" style="position: absolute;  left:19px; top:305px; width:92px;height:17px;text-align: left; vertical-align: top;" Text="Quantità in carico"></HelpWeb:hwLabel>
<img src="Immagini/pixel.gif" alt="" width="253" height="1" style="position:absolute;left:16px;top:149px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="126" style="position:absolute;left:16px;top:149px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="126" style="position:absolute;left:268px;top:149px;"/>
<img src="Immagini/pixel.gif" alt="" width="253" height="1" style="position:absolute;left:16px;top:274px;"/>
<div class="GroupBoxLabel" style="position:absolute;  left:26px;top:144px;">Classificazione</div>
<HelpWeb:hwPanel runat="server" id="groupBox1" style="position:absolute;  left: 16px; top: 149px; width:253px;height:126px;" >
<HelpWeb:hwTextBox runat="server" id="txtdescclass" tag="stocktotalview.listclass" style="position: absolute;  left:6px; top:51px;height:61px;width:237px" TextMode="MultiLine" TabIndex="8" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label5" tag="" style="position: absolute;  left:7px; top:35px; width:63px;height:17px;text-align: left; vertical-align: top;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtcodclass" tag="stocktotalview.codelistclass" style="position: absolute;  left:53px; top:12px;width:94px;" TabIndex="1" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label4" tag="" style="position: absolute;  left:7px; top:15px; width:39px;height:17px;text-align: left; vertical-align: top;" Text="Codice"></HelpWeb:hwLabel>
</HelpWeb:hwPanel>
<HelpWeb:hwTextBox runat="server" id="txtdescrizioneart" tag="stocktotalview.list" style="position: absolute;  left:16px; top:64px;height:75px;width:247px" TextMode="MultiLine" TabIndex="6" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label3" tag="" style="position: absolute;  left:13px; top:48px; width:63px;height:17px;text-align: left; vertical-align: top;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtidlist" tag="stocktotalview.idlist" style="position: absolute;  left:132px; top:16px;width:81px;" TabIndex="4" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblIdList" tag="" style="position: absolute;  left:112px; top:18px; width:10px;height:17px;text-align: left; vertical-align: top;" Text="#"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtcodiceart" tag="stocktotalview.intcode" style="position: absolute;  left:275px; top:16px;width:313px;" TabIndex="2" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblcodart" tag="" style="position: absolute;  left:225px; top:18px; width:39px;height:17px;text-align: left; vertical-align: top;" Text="Codice"></HelpWeb:hwLabel>
<HelpWeb:hwButton runat="server" id="btnArticolo" tag="choose.stocktotalview.default" style="position: absolute;  left:16px; top:13px; width:75px;height:23px;" Text="Articolo"/>
</div>
</asp:Content>
