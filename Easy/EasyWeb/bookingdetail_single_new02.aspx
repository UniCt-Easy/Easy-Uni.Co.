<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="bookingdetail_single_new02.aspx.cs" Inherits="bookingdetail_single_new02"  %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >


    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Articolo</legend>
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
                                <cc1:hwTextBox runat="server" ID="txtNumber"  CssClass="input-md form-control" Tag="bookingdetail.number.n"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label for="txtDesArt">Descrizione</label>
                            </div>                           
                        </div>
                        <div class="row">
                            <div class="col-md-12">
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
                                <cc1:hwTextBox ID="txtPrezzoUnitario" runat="server" ReadOnly="True" CssClass="input-md form-control" TabIndex="20" Tag="bookingdetail.price.C"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtUnloaded">Quantità già scaricata</label>
                            </div>
                            <div class="col-md-6">
                                <cc1:hwTextBox ID="txtUnloaded" runat="server" ReadOnly="True" CssClass="input-md form-control" style="text-align:right" TabIndex="20"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtDaScaricare">Disponibile da scaricare:</label>
                            </div>
                            <div class="col-md-6">
                                <cc1:hwTextBox ID="txtDaScaricare" runat="server" CssClass="input-md form-control" style="text-align:right" ReadOnly="True"></cc1:hwTextBox>
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
        <div class="col-md-5">
            <label for="txtStore">Magazzino</label>
            <cc1:hwTextBox runat="server" ID="txtStore" Tag="store.description"  CssClass="input-md form-control"  TabIndex="40" ReadOnly="true"></cc1:hwTextBox>
        </div>
        <div class="col-md-4">
            </div>
        <div class="col-md-3">
            <label for="chkAuthorized">Autorizza</label>
            <cc1:hwCheckBox ID="chkAuthorized" Enabled="false" Tag="bookingdetail.authorized:S:N" runat="server" />
        </div>

    </div>

    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Classificazione Merceologica</legend>
                <div class="row">
                    <div class="col-md-1">
                        <label for="txtCodeListClass">Codice</label>
                    </div>
                    <div class="col-md-2">
                        <cc1:hwTextBox runat="server" ID="txtCodeListClass" Tag="listclass.codelistclass" CssClass="input-md form-control" TabIndex="50" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-1">
                        <label for="txtDesListClass">Descrizione</label>
                    </div>
                    <div class="col-md-8">
                        <cc1:hwTextBox runat="server" ID="txtDesListClass" Tag="listclass.title" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="60" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <cc1:hwPanel ID="gboxclass1" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwButton runat="server" ID="btnCodice1" Tag="manage.sorting1.tree" TabIndex="4" Text="Codice" />
                        <cc1:hwTextBox runat="server" ID="txtCodice1" Tag="sorting1.sortcode?x" CssClass="input-md form-control" TabIndex="2"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox runat="server" ID="txtDenom1" Tag="sorting1.description" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="3" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </cc1:hwPanel>
        </div>
        <div class="col-md-6">
            <cc1:hwPanel ID="gboxclass2" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwButton runat="server" ID="btnCodice2" Tag="manage.sorting2.tree" Text="Codice" />
                        <cc1:hwTextBox runat="server" ID="txtCodice2" Tag="sorting2.sortcode?x" CssClass="input-md form-control" TabIndex="2"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox runat="server" ID="txtDenom2" Tag="sorting2.description" CssClass="input-md form-control"
                            TextMode="MultiLine" Rows="3" TabIndex="3" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </cc1:hwPanel>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <cc1:hwPanel ID="gboxclass3" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwButton runat="server" ID="btnCodice3" Tag="manage.sorting3.tree" TabIndex="4" Text="Codice" />
                        <cc1:hwTextBox runat="server" ID="txtCodice3" Tag="sorting3.sortcode?x" CssClass="input-md form-control" TabIndex="4"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox runat="server" ID="txtDenom3" Tag="sorting3.description" CssClass="input-md form-control"
                            TextMode="MultiLine" Rows="3" TabIndex="3" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </cc1:hwPanel>
        </div>
        <div class="col-md-6">
        </div>
    </div>

    
    
    
</asp:Content>