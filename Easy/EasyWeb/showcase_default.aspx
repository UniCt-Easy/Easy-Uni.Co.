<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="showcase_default.aspx.cs" Inherits="showcase_default" Title="Vetrina" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
<div style="position:relative;width:664px;height:414px;">
<HelpWeb:hwButton runat="server" id="btnElimina" tag="delete" style="position: absolute;  left:12px; top:319px; width:75px;height:23px;" TabIndex="18" class="btn btn-danger" Text="Elimina"/>
<HelpWeb:hwButton runat="server" id="btnModifica" tag="edit.single" style="position: absolute;  left:12px; top:290px; width:75px;height:23px;" TabIndex="17" class="btn btn-info" Text="Modifica"/>
<HelpWeb:hwButton runat="server" id="btnInserisci" tag="insert.single" style="position: absolute;  left:12px; top:261px; width:75px;height:23px;" TabIndex="16" class="btn btn-primary" Text="Inserisci"/>
<div style="white-space:normal">
<HelpWeb:hwDataGridWeb CssClass="normalwrap" runat="server" id="detailgrid" tag="showcasedetail.list.single" style="position: absolute;  left:99px; top:247px; width:539px;height:121px;" TabIndex="15" />
</div>
<img src="Immagini/pixel.gif" alt="" width="632" height="1" style="position:absolute;left:12px;top:125px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="116" style="position:absolute;left:12px;top:125px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="116" style="position:absolute;left:643px;top:125px;"/>
<img src="Immagini/pixel.gif" alt="" width="632" height="1" style="position:absolute;left:12px;top:240px;"/>
<div class="GroupBoxLabel" style="position:absolute;  left:22px;top:120px;">Magazzino</div>
<HelpWeb:hwPanel runat="server" id="grpMagazzino" style="position:absolute;  left: 12px; top: 125px; width:632px;height:116px;" >
<HelpWeb:hwTextBox runat="server" id="textBox1" tag="store.deliveryaddress" style="position: absolute;  left:22px; top:44px;height:50px;width:598px" TextMode="MultiLine" TabIndex="2" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwTextBox runat="server" id="txtMagDescrizione" tag="store.description?x" style="position: absolute;  left:104px; top:15px;width:516px;" TabIndex="1" ></HelpWeb:hwTextBox>
<HelpWeb:hwButton runat="server" id="button1" tag="choose.store.default" style="position: absolute;  left:22px; top:14px; width:75px;height:23px;" class="btn btn-primary" Text="Magazzino"/>
</HelpWeb:hwPanel>
<HelpWeb:hwTextBox runat="server" id="txtDescription" tag="showcase.description" style="position: absolute;  left:99px; top:44px;height:68px;width:533px" TextMode="MultiLine" TabIndex="3" ></HelpWeb:hwTextBox>
<HelpWeb:hwTextBox runat="server" id="txtTitle" tag="showcase.title" style="position: absolute;  left:99px; top:13px;width:533px;" TabIndex="2" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label2" tag="" style="position: absolute;  left:31px; top:44px; width:63px;height:17px;text-align: left; vertical-align: top;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwLabel runat="server" id="label1" tag="" style="position: absolute;  left:58px; top:13px; width:34px;height:17px;text-align: left; vertical-align: top;" Text="Nome"></HelpWeb:hwLabel>
</div>
</asp:Content>
