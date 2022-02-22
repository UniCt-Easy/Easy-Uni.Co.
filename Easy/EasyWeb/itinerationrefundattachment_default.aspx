<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itinerationrefundattachment_default.aspx.cs" Inherits="itinerationrefundattachment_default" Title="Allegato a spesa missione" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">

<div class="row">		
    <div class="col-md-12">	

        <cc1:hwpanel GroupingText="File allegato" CssClass="stdfieldset form-group" ID="gboxlblgroupBox1" runat="server">
            <div class="row">		 		
			    <div class="col-md-12">	
                    <cc1:hwLabel runat="server" id="labAttachFileName" tag="itinerationrefundattachment.filename" ></cc1:hwLabel>
                    </div>
            </div>
        </cc1:hwpanel>

        <div class="row">		 		
	        <div class="col-md-12">	
                <cc1:hwButton runat="server" id="btnVisualizza" TabIndex="5" Text="Scarica" class="btn btn-primary" Tag="visualizza" />
                <cc1:hwCheckBox runat="server" id="chkActive" tag="itinerationrefundattachment.active:S:N"  TabIndex="6" Text="Attivo"/>
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
