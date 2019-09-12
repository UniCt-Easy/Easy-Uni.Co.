<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="bookingdetail_default_new02.aspx.cs" Inherits="bookingdetail_default_new02"  %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" Runat="Server" >

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
                                <cc1:hwTextBox runat="server" ID="txtNumber"  CssClass="input-md form-control" Tag="bookingdetail.number.n" ReadOnly="true"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label for="txtDesArt">Descrizione</label>
                            </div>                           
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox runat="server" ID="txtDesArt" Tag="list.description" CssClass="input-md form-control" TextMode="MultiLine" row="5" TabIndex="30" ReadOnly="true"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="chkAuthorized">Autorizza</label>
                                <cc1:hwCheckBox ID="chkAuthorized" Enabled="false" Tag="bookingdetail.authorized:S:N" runat="server" />
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
            <label for="txtStore">Magazzino</label>
            <cc1:hwTextBox runat="server" ID="txtStore" Tag="store.description"  CssClass="input-md form-control"  TabIndex="40" ReadOnly="true"></cc1:hwTextBox>
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
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
            <cc1:hwButton ID="btnAutorizza" runat="server" TabIndex="70" Tag="autorizza" Text="Autorizza e continua" class="btn btn-block" />
        </div>
        <div class="col-md-3">
        </div>
    </div>
	
</asp:Content>



