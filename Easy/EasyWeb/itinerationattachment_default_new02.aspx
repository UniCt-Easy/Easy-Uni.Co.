<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itinerationattachment_default_new02.aspx.cs" Inherits="itinerationattachment_default_new02" Title="Allegato a missione" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">

<div class="row">		
    <div class="col-md-12">	

        <cc1:hwpanel GroupingText="File allegato" CssClass="stdfieldset form-group" ID="gboxlblgroupBox1" runat="server" Tag="AutoChoose.txtCredDeb.lista.(active='S')">
            <div class="row">		 		
			    <div class="col-md-12">	
                    <cc1:hwLabel runat="server" id="labAttachFileName" tag="itinerationattachment.filename" ></cc1:hwLabel>
                    </div>
            </div>
        </cc1:hwpanel>

        <div class="row">
            <div class="col-md-12">
                <cc1:hwLabel CssClass="control-label" runat="server" for="txtDescrizione">Descrizione</cc1:hwLabel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtDescrizione" Tag="itinerationattachment.description" TabIndex="70" ></cc1:hwTextBox>
            </div>
        </div>

        <div class="row">		 		
	        <div class="col-md-12">	
                <cc1:hwButton runat="server" id="btnVisualizza" TabIndex="5" Text="Visualizza" Tag="visualizza"/>
                </div>
        </div>
    <asp:FileUpload  ID="btnFileUpload" data-id="btnFileUpload" runat="server" />
    </div>
</div>
</asp:Content>


<asp:Content ContentPlaceHolderID="JScriptAfterLibs"  runat="server">

	<script type="text/javascript">
		$('[data-id="btnFileUpload"]').change(function(ev) {
			__doPostBack('do_command', "aggiornaNome");
		});
	</script>


</asp:Content>