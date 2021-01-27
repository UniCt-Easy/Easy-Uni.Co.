<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="upb_default_new02.aspx.cs" Inherits="upb_default_new02"  Title="UPB"%>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" Runat="Server" >
 
    <div class="row">
        <div class="col-lg-8 offset-lg-2">
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="cmbUpbParent">UPB padre</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwDropDownList ID="cmbUpbParent" runat="server" CssClass="form-control" Tag="upb.paridupb"></cc1:hwDropDownList>
                </div>
            </div>

              <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="txtCodice">Codice</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="txtCodice" runat="server" CssClass="form-control" Tag="upb.codeupb"></cc1:hwTextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="txtprintingorder">Ordine di Stampa</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="txtprintingorder" runat="server" CssClass="form-control" Tag="upb.printingorder"></cc1:hwTextBox>
                </div>
            </div>

   
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="txtTitle">Denominazione</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="txtTitle" runat="server" Tag="upb.title" CssClass="form-control" TextMode="MultiLine" Rows="3" ></cc1:hwTextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="cmbManager">Responsabile</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwDropDownList ID="cmbManager" runat="server" CssClass="form-control" Tag="upb.idman"></cc1:hwDropDownList>
                </div>
            </div>
        
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="HwTextBox1">Codice CUP</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="HwTextBox1" runat="server" CssClass="form-control"  Tag="upb.cupcode"></cc1:hwTextBox>
                </div>
            </div>
        </div>
    </div>

    </asp:Content>
