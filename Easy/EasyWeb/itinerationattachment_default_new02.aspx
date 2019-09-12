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
                <cc1:hwButton runat="server" id="btnVisualizza" TabIndex="5" Text="Scarica" Tag="visualizza"/>
                </div>
        </div>
    <asp:FileUpload ID="btnFileUpload" runat="server" />
    </div>
</div>
</asp:Content>
