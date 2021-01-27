<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="booking_default_new02.aspx.cs" Inherits="booking_default_new02"  %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-6 align-self-end">
            <div class="row">
                <div class="col-md-6">
                    <label for="txtybooking">Esercizio</label>
                    <cc1:hwTextBox runat="server" ID="txtybooking" CssClass="input-md form-control" Tag="booking.ybooking.year" TabIndex="2"></cc1:hwTextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtnbooking">Numero</label>
                    <cc1:hwTextBox runat="server" ID="txtnbooking" CssClass="input-md form-control" Tag="booking.nbooking" TabIndex="3"></cc1:hwTextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <fieldset>
                <legend>Responsabile</legend>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwDropDownList ID="cmbidman" CssClass="input-md form-control" Tag="booking.idman" runat="server" AutoPostBack="True" TabIndex="190"></cc1:hwDropDownList>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>  

    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Dati del Richiedente</legend>
                <div class="row">
                    <div class="col-md-4">
                        <label for="txtforename">Cognome</label>
                        <cc1:hwTextBox runat="server" ID="txtsurname" Tag="booking.surname" CssClass="input-md form-control" ReadOnly="true" Style="text-align: left"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="txtforename">Nome</label>
                        <cc1:hwTextBox runat="server" ID="txtforename" Tag="booking.forename" CssClass="input-md form-control" TabIndex="1" ReadOnly="true" Style="text-align: left"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="txtcf">Codice Fiscale</label>
                        <cc1:hwTextBox runat="server" ID="txtcf" Tag="booking.cf" CssClass="input-md form-control" ReadOnly="true" Style="text-align: left"></cc1:hwTextBox>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Card Magazzino</legend>
                <div class="row">
                    <div class="col-md-2">
                        <cc1:hwButton runat="server" ID="btnCard" Tag="choose.lcard.default" Text="Card" />
                    </div>
                    <div class="col-md-6">
                        <cc1:hwDropDownList ID="cmbCard" CssClass="input-md form-control" Tag="booking.idlcard" runat="server" AutoPostBack="True" TabIndex="190"></cc1:hwDropDownList>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwLabel runat="server" ID="lblDetailsInWait" ForeColor="Olive"></cc1:hwLabel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwLabel runat="server" ID="lblDetailsNotAuth" ForeColor="Red"></cc1:hwLabel>
                            </div>
                        </div>
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
                    <div class="col-md-12">
                        <cc1:hwButton runat="server" ID="btndelete" Tag="delete" TabIndex="7" class="btn" Text="Elimina" />
                        <cc1:hwButton runat="server" ID="btnedit" Tag="edit.singlenew02" TabIndex="6" class="btn" Text="Modifica" />
                        <cc1:hwButton runat="server" ID="btnvetrina" Tag="vetrina" TabIndex="8" class="btn" Text="Vetrina" style="background-color:#ff9966;color: Black;" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwDataGridWeb runat="server" ID="detailgrid" Tag="bookingdetail.list.single" />
                    </div>
                </div>
            </fieldset>
        </div>
    </div>



</asp:Content>