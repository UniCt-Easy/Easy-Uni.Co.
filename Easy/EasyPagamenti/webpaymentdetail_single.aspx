<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="webpaymentdetail_single.aspx.cs" Inherits="webpaymentdetail_single"  %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >


    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Voce</legend>
                <div class="row">
                    <div class="col-md-5">
                        <div class="row">
                            <div class="col-md-2">
                                <label for="txtCodArt">Codice</label>
                            </div>
                            <div class="col-md-4">
                                <cc1:hwTextBox runat="server" ID="txtCodArt" Tag="list.intcode" CssClass="input-md form-control" TabIndex="10" ReadOnly="true"></cc1:hwTextBox>
                            </div>
                            <div class="col-md-2">
                                <label for="txtNumber">Quantità</label>
                            </div>
                            <div class="col-md-4">
                                <cc1:hwTextBox runat="server" ID="txtNumber" CssClass="input-md form-control" Tag="webpaymentdetail.number.n"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label for="txtDesArt">Descrizione</label>
                            </div>
                            <div class="col-md-10">
                                <cc1:hwTextBox runat="server" ID="txtDesArt" Tag="list.description" CssClass="input-md form-control" TextMode="MultiLine" row="4" TabIndex="30" ReadOnly="true"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-6">
                                <cc1:hwLabel ID="lblPrezzoUnitario" runat="server" Text="Prezzo unitario"></cc1:hwLabel>
                            </div>
                            <div class="col-md-6">
                                <cc1:hwTextBox ID="txtPrezzoUnitario" runat="server" CssClass="input-md form-control" TabIndex="20" Tag="webpaymentdetail.price.C"></cc1:hwTextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtStore">Dipartimento</label>
                            </div>
                            <div class="col-md-6">
                                <cc1:hwTextBox runat="server" ID="txtStore" Tag="store.description" CssClass="input-md form-control" TabIndex="40" ReadOnly="true"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <cc1:hwPanel ID="grpImmagine" runat="server">
                            <fieldset>
                                <legend>Immagine</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- colonne vuote-->
                                    </div>
                                </div>
                            </fieldset>
                        </cc1:hwPanel>
                    </div>
                    </div>
            </fieldset>
        </div>
    </div>


    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend></legend>
                <div class="row">
                    <div class="col-md-1">
                        <cc1:hwLabel ID="lblCodeListClass" runat="server" Text="Codice"></cc1:hwLabel>
                    </div>
                    <div class="col-md-2">
                        <cc1:hwTextBox runat="server" ID="txtCodeListClass" Tag="listclass.codelistclass" CssClass="input-md form-control" TabIndex="50" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-1">
                        <cc1:hwLabel ID="lblDesListClass" runat="server" Text="Descrizione"></cc1:hwLabel>
                    </div>
                    <div class="col-md-8">
                        <cc1:hwTextBox runat="server" ID="txtDesListClass" Tag="listclass.title" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="60" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

  
    
    
</asp:Content>