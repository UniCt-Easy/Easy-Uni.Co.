<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="finvarattachment_default_new02.aspx.cs" Inherits="finvarattachment_default_new02" Title="Allegato a variazione di bilancio" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
        
<div class="row">		
    <div class="col-md-12">
        <cc1:hwPanel GroupingText="File allegato" CssClass="stdfieldset form-group" ID="gboxlblgroupBox1" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwLabel runat="server" ID="labAttachFileName" Tag="finvarattachment.filename"></cc1:hwLabel>
                </div>
            </div>
        </cc1:hwPanel>

        <div class="row">
            <div class="col-md-12">
                <cc1:hwButton runat="server" ID="btnVisualizza" Tag="" TabIndex="5" Text="Scarica" class="btn btn-primary" OnClick="btnVisualizza_Click" />
            </div>
        </div>
        <asp:FileUpload ID="btnFileUpload" runat="server" />
    </div>
</div>




</asp:Content>



