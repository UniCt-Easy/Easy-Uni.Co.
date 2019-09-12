<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" 
        CodeFile="lcardvar_web.aspx.cs" Inherits="lcardvar_web" Title="Ricarica card" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">



<div style='position:relative;width:628px;height:460px;'>
<HelpWeb:hwTextBox runat="server" id="textBox9" tag="lcardvar.adate" style="position: absolute;  left:177px; top:100px;width:109px;" TabIndex="4" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label7" tag="" style="position: absolute;  left:174px; top:84px; width:77px;height:17px;text-align: left; vertical-align: top;" Text="Data contabile"></HelpWeb:hwLabel>
<img src="Immagini/pixel.gif" alt="" width="159" height="1" style="position:absolute;left:428px;top:77px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="59" style="position:absolute;left:428px;top:77px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="59" style="position:absolute;left:586px;top:77px;"/>
<img src="Immagini/pixel.gif" alt="" width="159" height="1" style="position:absolute;left:428px;top:135px;"/>
<div runat="server" id="gboxlblgroupBox5" class="GroupBoxLabel" style="position:absolute;  left:438px;top:72px;">Variazione di bilancio</div>
<HelpWeb:hwPanel CssClass="gbox"  runat="server" id="groupBox5" style="position:absolute;  left: 428px; top: 77px; width:159px;height:59px;" width="159" height="59">
<HelpWeb:hwTextBox runat="server" id="textBox7" tag="lcardvar.nvar" style="position: absolute;  left:89px; top:27px;width:40px;" ReadOnly="true"></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label5" tag="" style="position: absolute;  left:86px; top:11px; width:44px;height:17px;text-align: left; vertical-align: top;" Text="Numero"></HelpWeb:hwLabel>
<HelpWeb:hwLabel runat="server" id="label6" tag="" style="position: absolute;  left:16px; top:11px; width:50px;height:17px;text-align: left; vertical-align: top;" Text="Esercizio"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="textBox8" tag="lcardvar.yvar" style="position: absolute;  left:19px; top:27px;width:40px;" ReadOnly="true"></HelpWeb:hwTextBox>
</HelpWeb:hwPanel>
<HelpWeb:hwLabel runat="server" id="label4" tag="" style="position: absolute;  left:15px; top:342px; width:63px;height:17px;text-align: left; vertical-align: middle;" Text="Descrizione"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="textBox6" tag="lcardvar.description" style="position: absolute;  left:12px; top:358px;height:47px;width:569px" TextMode="MultiLine" TabIndex="7" ></HelpWeb:hwTextBox>
<img src="Immagini/pixel.gif" alt="" width="575" height="1" style="position:absolute;left:12px;top:243px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="87" style="position:absolute;left:12px;top:243px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="87" style="position:absolute;left:586px;top:243px;"/>
<img src="Immagini/pixel.gif" alt="" width="575" height="1" style="position:absolute;left:12px;top:329px;"/>
<HelpWeb:hwPanel CssClass="gbox"  runat="server" id="groupBox4" style="position:absolute;  left: 12px; top: 243px; width:575px;height:87px;" width="575" height="87">
<HelpWeb:hwButton runat="server" id="btnBilancio" tag="choose.finview.default" style="position: absolute;  left:6px; top:14px; width:75px;height:23px;" TabIndex="5" Text="Bilancio"/>
<HelpWeb:hwTextBox runat="server" id="txtfintitle" tag="finview.title" style="position: absolute;  left:231px; top:14px;height:47px;width:323px" TextMode="MultiLine" TabIndex="8" ReadOnly="True" ></HelpWeb:hwTextBox>
<HelpWeb:hwDropDownList runat="server" AutoPostBack="true" id="cmbBilancio" tag="lcardvar.idfin" style="position: absolute;  left:6px; top:43px; width:219px;" TabIndex="6"></HelpWeb:hwDropDownList>
</HelpWeb:hwPanel>
<img src="Immagini/pixel.gif" alt="" width="575" height="1" style="position:absolute;left:12px;top:135px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="87" style="position:absolute;left:12px;top:135px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="87" style="position:absolute;left:586px;top:135px;"/>
<img src="Immagini/pixel.gif" alt="" width="575" height="1" style="position:absolute;left:12px;top:221px;"/>
<HelpWeb:hwPanel CssClass="gbox"  runat="server" id="groupBox3" style="position:absolute;  left: 12px; top: 135px; width:575px;height:87px;" width="575" height="87">
<HelpWeb:hwButton runat="server" id="btnUPB" tag="choose.upb.default.(active='S')" style="position: absolute;  left:6px; top:14px; width:75px;height:23px;" TabIndex="5" Text="UPB"/>
<HelpWeb:hwTextBox runat="server" id="txtUpbTitle" tag="upb.title" style="position: absolute;  left:231px; top:14px;height:47px;width:323px" TextMode="MultiLine" TabIndex="8" ReadOnly="True" ></HelpWeb:hwTextBox>
<HelpWeb:hwDropDownList runat="server" AutoPostBack="true" id="cmbUPB" tag="lcardvar.idupb" style="position: absolute;  left:6px; top:43px; width:219px;" TabIndex="5"></HelpWeb:hwDropDownList>
</HelpWeb:hwPanel>
<HelpWeb:hwTextBox runat="server" id="textBox3" tag="lcardvar.amount" style="position: absolute;  left:15px; top:100px;width:109px;" TabIndex="3" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label3" tag="" style="position: absolute;  left:12px; top:84px; width:82px;height:17px;text-align: left; vertical-align: top;" Text="Importo ricarica"></HelpWeb:hwLabel>
<img src="Immagini/pixel.gif" alt="" width="418" height="1" style="position:absolute;left:190px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="59" style="position:absolute;left:190px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="59" style="position:absolute;left:607px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="418" height="1" style="position:absolute;left:190px;top:70px;"/>
<div runat="server" id="gboxlblgroupBox2" class="GroupBoxLabel" style="position:absolute;  left:200px;top:7px;">Card magazzino</div>
<HelpWeb:hwPanel CssClass="gbox"  runat="server" id="groupBox2" style="position:absolute;  left: 190px; top: 12px; width:418px;height:59px;" width="418" height="59">
<HelpWeb:hwDropDownList runat="server" AutoPostBack="true" id="cmblcard" tag="lcardvar.idlcard" style="position: absolute;  left:87px; top:18px; width:313px;" TabIndex="2"></HelpWeb:hwDropDownList>
<HelpWeb:hwButton runat="server" id="btnCard" tag="choose.lcard.default" style="position: absolute;  left:6px; top:18px; width:75px;height:23px;" Text="Card"/>
</HelpWeb:hwPanel>
<img src="Immagini/pixel.gif" alt="" width="172" height="1" style="position:absolute;left:12px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="59" style="position:absolute;left:12px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="1" height="59" style="position:absolute;left:183px;top:12px;"/>
<img src="Immagini/pixel.gif" alt="" width="172" height="1" style="position:absolute;left:12px;top:70px;"/>
<div runat="server" id="gboxlblgroupBox1" class="GroupBoxLabel" style="position:absolute;  left:22px;top:7px;">Variazione</div>
<HelpWeb:hwPanel CssClass="gbox"  runat="server" id="groupBox1" style="position:absolute;  left: 12px; top: 12px; width:172px;height:59px;" width="172" height="59" TabIndex="1">
<HelpWeb:hwTextBox runat="server" id="txtNlvar" tag="lcardvar.nlvar" style="position: absolute;  left:89px; top:27px;width:40px;" TabIndex="1" ></HelpWeb:hwTextBox>
<HelpWeb:hwLabel runat="server" id="label2" tag="" style="position: absolute;  left:86px; top:11px; width:44px;height:17px;text-align: left; vertical-align: top;" Text="Numero"></HelpWeb:hwLabel>
<HelpWeb:hwLabel runat="server" id="label1" tag="" style="position: absolute;  left:16px; top:11px; width:50px;height:17px;text-align: left; vertical-align: top;" Text="Esercizio"></HelpWeb:hwLabel>
<HelpWeb:hwTextBox runat="server" id="textBox1" tag="lcardvar.ylvar" style="position: absolute;  left:19px; top:27px;width:40px;" ReadOnly="true"></HelpWeb:hwTextBox>
</HelpWeb:hwPanel>
</div>




</asp:Content>

