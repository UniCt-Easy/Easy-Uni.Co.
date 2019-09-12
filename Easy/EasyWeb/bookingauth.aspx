<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="bookingauth.aspx.cs" Inherits="bookingauth" Title="Autorizzazione Prenotazione magazzino" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
<div style='position:relative;width:722px;height:371px;'>
<img src="Immagini/pixel.gif" alt="" width="688" height="1" style="position:absolute;left:12px;top:238px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="87" style="position:absolute;left:12px;top:238px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="87" style="position:absolute;left:699px;top:238px;"/>
<img src="Immagini/pixel.gif" alt="" width="688" height="1" style="position:absolute;left:12px;top:324px;"/>
<div class="GroupBoxLabel" style="position:absolute;  left:22px;top:233px;">Classificazione Merceologica</div>
<HelpWeb:hwPanel runat="server" id="grpClass" style="position:absolute;  left: 12px; top: 238px; width:688px;height:87px;" >
<HelpWeb:hwTextBox runat="server" id="txtDesListClass" tag="listclass.title" style="position: absolute;  left:266px; top:14px;height:56px;width:410px" TextMode="MultiLine" TabIndex="60" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblDesListClass" tag="" style="position: absolute;  left:198px; top:17px; width:63px;height:17px;text-align: left; vertical-align: top;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtCodeListClass" tag="listclass.codelistclass" style="position: absolute;  left:53px; top:14px;width:115px;" TabIndex="50" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblCodListClass" tag="" style="position: absolute;  left:7px; top:17px; width:39px;height:17px;text-align: left; vertical-align: top;" Text="Codice"></HelpWeb:hwLabel>
</HelpWeb:hwPanel>
<HelpWeb:hwTextBox runat="server" id="txtStore" tag="store.description" style="position: absolute;  left:170px; top:212px;width:408px;" TabIndex="40" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblStoreDes" tag="" style="position: absolute;  left:104px; top:215px; width:59px;height:17px;text-align: left; vertical-align: top;" Text="Magazzino"></HelpWeb:hwLabel>
<img src="Immagini/pixel.gif" alt="" width="688" height="1" style="position:absolute;left:12px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="194" style="position:absolute;left:12px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="194" style="position:absolute;left:699px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="688" height="1" style="position:absolute;left:12px;top:205px;"/>
<div class="GroupBoxLabel" style="position:absolute;  left:22px;top:7px;">Articolo</div>
<HelpWeb:hwPanel runat="server" id="grpArticolo" style="position:absolute;  left: 12px; top: 12px; width:688px;height:194px;" >
<HelpWeb:hwLabel runat="server" id="lblNumber" tag="" style="position: absolute;  left:198px; top:32px; width:47px;height:17px;text-align: left; vertical-align: top;" Text="Quantità"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtNumber" tag="bookingdetail.number.N" style="position: absolute;  left:251px; top:29px;width:94px;" ReadOnly="true" TabIndex="20" ></HelpWeb:hwTextBox>
<img src="Immagini/pixel.gif" alt="" width="310" height="1" style="position:absolute;left:372px;top:11px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="177" style="position:absolute;left:372px;top:11px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="177" style="position:absolute;left:681px;top:11px;"/>
<img src="Immagini/pixel.gif" alt="" width="310" height="1" style="position:absolute;left:372px;top:187px;"/>
<div class="GroupBoxLabel" style="position:absolute;  left:382px;top:6px;">Immagine</div>
<HelpWeb:hwPanel runat="server" id="grpImmagine" style="position:absolute;  left: 372px; top: 12px; width:310px;height:177px;" >
</HelpWeb:hwPanel>
<HelpWeb:hwTextBox runat="server" id="txtDesArt" tag="list.description" style="position: absolute;  left:10px; top:80px;height:90px;width:335px" TextMode="MultiLine" TabIndex="30" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblDesArt" tag="" style="position: absolute;  left:6px; top:64px; width:63px;height:17px;text-align: left; vertical-align: top;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="txtCodArt" tag="list.intcode" style="position: absolute;  left:53px; top:29px;width:94px;" TabIndex="10" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="lblCodArt" tag="" style="position: absolute;  left:7px; top:32px; width:39px;height:17px;text-align: left; vertical-align: top;" Text="Codice"></HelpWeb:hwLabel>
</HelpWeb:hwPanel>
    <HelpWeb:hwCheckBox ID="chkAuthorized" tag="bookingdetail.authorized:S:N" runat="server" Style="position: absolute;  left: 263px; top: 70px;" Width="3px" />
    <HelpWeb:hwLabel runat="server" id="lblAuthorized" tag="" style="position: absolute;  left:211px; top:70px; width:45px;height:17px;text-align: left; vertical-align: top;" Text="Autorizza"></HelpWeb:hwLabel>
    <HelpWeb:hwButton ID="btnAutorizza" runat="server" Style=" left: 290px;
        width: 217px; position: absolute; top: 334px; height: 23px" TabIndex="70" Tag="autorizza"
        Text="Autorizza e continua" Width="217px" />

</div>
</asp:Content>
