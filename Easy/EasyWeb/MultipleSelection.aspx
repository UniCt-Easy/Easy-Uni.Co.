<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" 
        CodeFile="MultipleSelection.aspx.cs" Inherits="MultipleSelection" Title="Selezione multipla" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">    
<table width="969px">
<tr>
<td>
    <b>Selezione Multipla </b><br />
    <br />
    <big><asp:label runat="server" ID="labToAdd" Text="Da Aggiungere:"></asp:label></big>
    <br />
    <br />
    <cc1:hwButton runat="server" ID="btnSelAllToAdd" Text="Seleziona Tutti" class="btn btn-primary" OnClick="btnSelAllToAdd_Click"/>
    <cc1:hwButton runat="server" ID="btnUnSelAllToAdd" Text="Deseleziona Tutti" class="btn btn-info" OnClick="btnUnSelAllToAdd_Click"/>
    <br />
    <br />
    <center><asp:Panel runat="server" ID="GridToAdd" style="width: 900px; height: 150px"></asp:Panel></center>
    <br />
    <br />
<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr>
<td><cc1:hwButton runat="server" ID="btnAdd" Text="Aggiungi" class="btn btn-primary" OnClick="btnAdd_Click"/></td><td><cc1:hwButton id="btnRemove" runat="server" onclick="btnRemove_Click" class="btn btn-danger" Text="Rimuovi"/></td>

<td>
    Cliccare sul pulsante "Seleziona Tutti"/"Deseleziona Tutti" per selezionare/deselezionare tutte le righe di un elenco.</td><td><cc1:hwButton runat="server" ID="btnClose" Text="Chiudi" class="btn btn-primary" OnClick="btnClose_Click"/></td>
</tr>
</table><br />
    &nbsp;<big><asp:label runat="server" ID="labAdded" Text="Aggiunti:"></asp:label></big><br />
<br />
    <cc1:hwButton runat="server" ID="btnSelAllAdded"  Text="Seleziona Tutti" class="btn btn-primary" OnClick="btnSelAllAdded_Click"/>
    <cc1:hwButton runat="server" ID="btnUnSelAllAdded"  Text="Deseleziona Tutti" class="btn btn-info" OnClick="btnUnSelAllAdded_Click"/>
    <br />
<br />
<center><asp:Panel runat="server" ID="GridAdded" style="width: 900px; height: 150px"></asp:Panel></center>
</td>
</tr>
</table>
<script type="text/javascript">
var CheckBoxImgPath="Immagini_CheckBox/";
var CheckImg=CheckBoxImgPath+"checked.gif";
var UnCheckImg=CheckBoxImgPath+"unchecked.gif";
var IndetImg=CheckBoxImgPath+"checked-three.gif";
var CheckImgOver=CheckBoxImgPath+"checked-over.gif";
var UnCheckImgOver=CheckBoxImgPath+"unchecked-over.gif";
var IndetImgOver=CheckBoxImgPath+"checked-three-over.gif";
var checkImgDis = CheckBoxImgPath+ "checked-dis.gif";
var uncheckImgDis = CheckBoxImgPath + "unchecked-dis.gif";


function ChkBox_MouseClick(pTCheckBoxID,pStateNumber, pAllowOver)
{
    var el=document.getElementById(pTCheckBoxID); 
    var im=document.getElementById(pTCheckBoxID+'_img');

    var lCheckImg;
    var lUnCheckImg;
    var lIndetImg;
    
    if(pAllowOver)
    {
        lCheckImg=CheckImgOver;
        lUnCheckImg=UnCheckImgOver;
        lIndetImg=IndetImgOver;
    }
    else
    {
        lCheckImg=CheckImg;
        lUnCheckImg=UnCheckImg;
        lIndetImg=IndetImg;
    }
    
    if(pStateNumber==3)
    {
        if (el.value==1) 
        { 
            el.value=2; 
            im.src=lIndetImg; 
        } 
        else
        {
            if (el.value==2) 
            { 
                el.value=0; 
                im.src=lUnCheckImg; 
            } else
            { 
                el.value=1; 
                im.src=lCheckImg; 
            }
        } 
    }
    else
    {
        if (el.value==1) 
        { 
            el.value=0; 
            im.src=lUnCheckImg; 
        } 
        else 
        { 
            el.value=1; 
            im.src=lCheckImg; 
        }
    }
}
</script>
</asp:Content>
