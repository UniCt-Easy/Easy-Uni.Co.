<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="accountvar_default_new02.aspx.cs" Inherits="accountvar_default_new02"  %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

    <div class="row">
        <div class="col-md-4">
            <label for="esercizio">Esercizio</label>
            <cc1:hwTextBox ID="esercizio" runat="server" CssClass="form-control" Tag="accountvar.yvar.year" TabIndex="10"></cc1:hwTextBox>
        </div>
        <div class="col-md-4">
            <label for="nman">Numero</label>
            <cc1:hwTextBox ID="nvar" runat="server" CssClass="input-md form-control" Tag="accountvar.nvar" TabIndex="20"></cc1:hwTextBox>
        </div>
        <div class="col-md-4">
            <cc1:hwPanel GroupingText="Tipo Variazione" CssClass="stdfieldset form-group" ID="groupTipoPrevisione" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwRadioButton ID="variationtime1" runat="server" Text="Normale" Tag="accountvar.variationkind:1"  /><br />
                        <!-- <cc1:hwRadioButton ID="variationtime5" runat="server" Text="Iniziale" tag="accountvar.variationkind:5" TabIndex="61"/> -->
                    </div>
                    <div class="col-md-6">
                        <cc1:hwRadioButton ID="variationtime4" runat="server" Text="Storno" Tag="accountvar.variationkind:4"  /><br />
                    </div>
                </div>
            </cc1:hwPanel>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-4">
            <legend>Responsabile</legend>
            <div class="row">
                <div class="col-md-12 autochoose">
                    <cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" ID="grpResponsabile" runat="server" Tag="AutoChoose.txtResponsabile.lista.(financeactive='S')">
                        <cc1:hwButton ID="btnResponsabile" runat="server" Text="Responsabile" class="btn btn-primary" Tag="choose.manager.lista" />
                        <cc1:hwTextBox TabIndex="20" ID="txtResponsabile" CssClass="form-control input-md" Tag="manager.title?x" runat="server"></cc1:hwTextBox>
                    </cc1:hwPanel>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <fieldset>
                <legend>Stato Corrente</legend>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwDropDownList ID="idaccountvarstatus" CssClass="input-md form-control" Tag="accountvar.idaccountvarstatus?accountvarview.idaccountvarstatus" runat="server" AutoPostBack="True" TabIndex="70"></cc1:hwDropDownList>
                    </div>
                </div>
            </fieldset>
            <div class="row">
                <div class="col-md-4">
                    <label for="btnStatus"></label>
                    <cc1:hwButton ID="btnStatus" runat="server" Tag="approvati" Visible="False" class="btn btn-primary" />
                </div>
            </div>
        </div>
        <div class="col-md-4 align-self-end">
            <div class="row">
                <div class="col-md-12">
                    <label for="DataContabile">Data Contabile</label>
                    <cc1:hwTextBox ID="DataContabile" runat="server" Tag="accountvar.adate" CssClass="form-control" TabIndex="40"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label></label>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-8">
            <div class="row">
                <div class="col-md-12">
                    <label for="descrizione">Descrizione</label>
                    <cc1:hwTextBox ID="descrizione" runat="server" Tag="accountvar.description" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="50"></cc1:hwTextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12">
                    <label for="Saldo">Saldo</label>
                    <cc1:hwTextBox runat="server" ID="Saldo" ReadOnly="True" Tag="" CssClass="input-md form-control" TabIndex="60"></cc1:hwTextBox>
                </div>
            </div>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <fieldset>
                <legend>Provvedimento</legend>
                <div class="row">
                    <div class="col-md-8">
                        <cc1:hwTextBox runat="server" ID="Provvedimento" Tag="accountvar.enactment" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="80"></cc1:hwTextBox><br />
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <label for="DataProvv">Data:</label>
                                <cc1:hwTextBox runat="server" ID="DataProvv" Tag="accountvar.enactmentdate" CssClass="input-md form-control c_Data" TabIndex="90"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label for="NumProvv">Numero:</label>
                                <cc1:hwTextBox runat="server" ID="NumProvv" Tag="accountvar.nenactment" CssClass="input-md form-control" TabIndex="100"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <ul id="mainTabControl" class="nav nav-tabs nav-justified">
                <li><a data-toggle="tab" href="#tabdettagli">Dettagli</a></li>
                <li><a data-toggle="tab" href="#tabannotazioni">Annotazioni</a></li>
                <li><a data-toggle="tab" href="#taballegati">Allegati</a></li>
            </ul>

            <div class="tab-content">
                <div id="tabdettagli" class="tab-pane fade">
                    <div title="Dettagli">
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwButton ID="btnInsert" runat="server" Tag="insert.detailnew02" Text="Inserisci" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
                                    <cc1:hwButton ID="btnEdit" runat="server" Tag="edit.detailnew02" Text="Modifica" class="btn btn-info" TabIndex="220"></cc1:hwButton>
                                    <cc1:hwButton ID="btnDelete" runat="server" Tag="delete" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
                                </div>
                                <div class="col-md-12">
                                    <cc1:hwDataGridWeb ID="DtlDataGrid" runat="server" Tag="accountvardetail.listaweb.single" TabIndex="200" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <div id="taballegati" class="tab-pane fade">
                    <div title="Allegati">
                        <asp:Panel ID="Panel2" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwButton ID="btnInsAllegato" runat="server" Tag="insert.defaultnew02" class="btn btn-primary" Text="Inserisci" TabIndex="210"></cc1:hwButton>
                                    <cc1:hwButton ID="HwEditAllegato" runat="server" Tag="edit.defaultnew02" class="btn btn-info" Text="Modifica" TabIndex="220"></cc1:hwButton>
                                    <cc1:hwButton ID="HwCancAllegato" runat="server" Tag="delete" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
                                </div>
                                <div class="col-md-12">
                                    <cc1:hwDataGridWeb ID="HwDataGridAllegati" runat="server" Tag="accountvarattachment.default.default" TabIndex="300" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div id="tabannotazioni" class="tab-pane fade">
                    <div title="Annotazioni">
                        <asp:Panel ID="Panel3" runat="server">
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtreason">Motivazione</label>
                                    <cc1:hwTextBox ID="txtreason" runat="server" TabIndex="210" CssClass="input-md form-control" Tag="accountvar.reason" TextMode="MultiLine" Rows="3"></cc1:hwTextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtannotation">Annotazioni</label>
                                    <cc1:hwTextBox ID="txtannotation" runat="server" ReadOnly="True" TabIndex="220" CssClass="input-md form-control" Tag="accountvar.annotation" TextMode="MultiLine" Rows="3"></cc1:hwTextBox>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>


            </div>
        </div>
    </div>

</asp:Content>