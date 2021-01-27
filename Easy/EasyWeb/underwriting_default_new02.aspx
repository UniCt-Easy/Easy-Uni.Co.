<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="underwriting_default_new02.aspx.cs" Inherits="underwriting_default_new02"  Title="Finanziamento"%>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" Runat="Server" >
    <div class="row">
        <div class="col-lg-8 offset-lg-2">
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="txtDenominazione">Denominazione</label>
                </div>
                <div class="col-md-8">
                    <cc1:hwTextBox runat="server" TabIndex="20"  CssClass="form-control" ID="txtDenominazione" Tag="underwriting.title"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="cmbUnderwriter">Finanziatore</label>
                </div>
                <div class="col-md-8">
                    <cc1:hwDropDownList AutoPostBack="true" ID="cmbUnderwriter" CssClass="form-control" runat="server" Tag="underwriting.idunderwriter"></cc1:hwDropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="txtCodice">Codice</label>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="txtCodice" runat="server" CssClass="form-control" Tag="underwriting.codeunderwriting"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="HwTextBox3">Documento</label>
                </div>
                <div class="col-md-8">
                    <cc1:hwTextBox ID="HwTextBox3" runat="server" CssClass="form-control" Tag="underwriting.doc"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <label for="HwTextBox4">Data Documento</label>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="HwTextBox4" runat="server" CssClass="form-control" Tag="underwriting.docdate"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 align-self-center">
                    </div>
                <div class="col-md-8">
                    <cc1:hwCheckBox ID="HwCheckBox1" runat="server" Tag="underwriting.active:S:N" Text="Attivo" />
                </div>
            </div> 
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <cc1:hwLabel ID="labprev1" runat="server"  Text="Previsione N"></cc1:hwLabel>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="txtprev1" runat="server" CssClass="form-control" Tag="underwritingyear.prevision" SubEntity="True"></cc1:hwTextBox>
                </div>
            </div> 
    
            <div class="row">
                <div class="col-md-3 align-self-center">
                    <cc1:hwLabel ID="labprev2" runat="server" Text="Previsione N+1"></cc1:hwLabel>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="txtprev2" runat="server" CssClass="form-control" Tag="underwritingyear.prevision2" SubEntity="True"></cc1:hwTextBox>
                </div>
            </div> 

            <div class="row">
                <div class="col-md-3 align-self-center">
                    <cc1:hwLabel ID="labprev3" runat="server" Text="Previsione N+2"></cc1:hwLabel>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="txtprev3" runat="server" CssClass="form-control" Tag="underwritingyear.prevision3" SubEntity="True"></cc1:hwTextBox>
                </div>
            </div> 
    
            <div class="row">
                <div class="col-md-3 align-self-center">
                                <cc1:hwLabel ID="labprev4" runat="server" Text="Previsione N+3"></cc1:hwLabel>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="txtprev4" runat="server" CssClass="form-control" Tag="underwritingyear.prevision4" SubEntity="True"></cc1:hwTextBox>
                </div>
            </div> 

            <div class="row">
                <div class="col-md-3 align-self-center">
                    <cc1:hwLabel ID="labprev5" runat="server" Text="Previsione N+4"></cc1:hwLabel>
                </div>
                <div class="col-md-3">
                    <cc1:hwTextBox ID="txtprev5" runat="server" CssClass="form-control" Tag="underwritingyear.prevision5" SubEntity="True"></cc1:hwTextBox>
                </div>
            </div> 
        </div>
    </div>

</asp:Content>

