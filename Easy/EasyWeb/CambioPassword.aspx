﻿<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="CambioPassword.aspx.cs" Inherits="EasyWebReport.CambioPassword" Title="Cambio password" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-8">
            <cc1:hwPanel GroupingText="Cambio Password" CssClass="gbox scheduler-border form-group" ID="grpRuolo" runat="server" Tag="">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwLabel runat="server" ID="lblOldPwd" Text="Inserire la password attuale"></cc1:hwLabel>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox ID="txtOldPwd" TextMode="Password" runat="server" Style="text-align: left;" TabIndex="1"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwLabel runat="server" ID="lblNewPwd" Text="Inserire la nuova password"></cc1:hwLabel>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox ID="txtNewPwd" TextMode="Password" runat="server" Style="text-align: left;" TabIndex="2"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwLabel runat="server" ID="lblNewPwd2" Text="Re-Inserire la nuova password"></cc1:hwLabel>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox ID="txtNewPwd2" TextMode="Password" runat="server" Style="text-align: left;" TabIndex="3"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwLabel runat="server" ID="labError"></cc1:hwLabel>
                    </div>
                </div>
            </cc1:hwPanel>
        </div>
        <div class="col-md-2">
        </div>
    </div>



     <div class="row">
        <div class="col-md-5">
        </div>
        <div class="col-md-1">
            <cc1:hwButton ID="btnOk"  runat="server" TabIndex="4" Text="Ok" class="btn btn-primary" OnClick="btnOk_Click" />
        </div>
        <div class="col-md-1">
            <cc1:hwButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" TabIndex="5" class="btn btn-danger" Text="Annulla" />
        </div>
        <div class="col-md-5">
        </div>
    </div>


    
    
    
</asp:Content>

