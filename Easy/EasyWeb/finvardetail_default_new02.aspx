<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="finvardetail_default_new02.aspx.cs" Inherits="finvardetail_default_new02"  Title="Dettaglio variazione di bilancio" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >


<fieldset>
<legend>Dati Variazione</legend>
    <div class="row">
       <div class="col-md-6">
            <div class="row">
                <cc1:hwPanel GroupingText="U.P.B." CssClass="gbox scheduler-border form-group" ID="PanelUpb" runat="server" Tag="AutoManage.txtCodiceUPB.tree">
                    <div class="col-md-7">
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwButton ID="btnUpb" runat="server" Text="UPB" class="btn btn-primary" Tag="manage.upb.tree" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox TabIndex="20" ID="txtCodiceUPB" CssClass="form-control input-md" Tag="upb.codeupb?x" runat="server"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <cc1:hwTextBox runat="server" ID="txtDescrUPB" Tag="upb.title" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
                    </div>
                </cc1:hwPanel>
            </div>
        </div>

        <div class="col-md-6">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwRadioButton runat="server" TabIndex="70" ToEnable="true" EnableViewState="true" AutoPostBack="true" OnCheckedChanged="rdb_CheckedChanged" Text="Entrata" ID="rdbEntrata" Tag="finview.finpart:E?x" />
                                <cc1:hwRadioButton runat="server" TabIndex="80" ToEnable="true" EnableViewState="true" AutoPostBack="true" OnCheckedChanged="rdb_CheckedChanged" Text="Spesa" ID="rdbSpesa" Tag="finview.finpart:S?x" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwButton runat="server" TabIndex="85" Text="Bilancio" ID="btnBilancio" class="btn btn-primary" Tag="do_command.scegliBilancio" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox TabIndex="90" ID="txtCodiceBilancio" CssClass="form-control input-md" Tag="finview.codefin?x" runat="server"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox runat="server" ID="txtDenominazioneBilancio" CssClass="form-control input-md" Tag="finview.title?x" TextMode="MultiLine" Rows="5" ReadOnly="True" TabIndex="100"></cc1:hwTextBox>
                    </div>
                </div>
        </div>
    </div>     
</fieldset>

    <asp:Panel ID="divPrevisioni" runat="server">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <legend>Previsioni</legend>
                    <div class="row">
                        <div class="col-md-3">
                            <cc1:hwLabel runat="server" ID="txtAnno1" Text="Anno1"></cc1:hwLabel>
                            <cc1:hwTextBox Style="width: 50%;" runat="server" CssClass="input-md form-control" ID="HwTextAnno1" Tag="finvardetail.amount" TabIndex="66"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwLabel runat="server" ID="txtAnno2" Text="Anno2"></cc1:hwLabel>
                            <cc1:hwTextBox Style="width: 50%;" runat="server" CssClass="input-md form-control" ID="HwTextAnno2" Tag="finvardetail.prevision2" TabIndex="67"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwLabel runat="server" ID="txtAnno3" Text="Anno3"></cc1:hwLabel>
                            <cc1:hwTextBox Style="width: 50%;" runat="server" ID="HwTextAnno3" CssClass="input-md form-control" Tag="finvardetail.prevision3" TabIndex="68"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwCheckBox runat="server" ID="HwChkCreaExpense" CssClass="input-md form-control" Tag="finvardetail.createexpense:S:N" Text="Richiedi movimento" />
                            <cc1:hwLabel ID="labMovimento" runat="server" Text="Label"></cc1:hwLabel>
                        </div>
                    </div>
                </fieldset>
            </div>

        </div>
        </asp:Panel>

    <div class="row">
        <div class="col-md-12">
            <cc1:hwPanel GroupingText="Finanziamento" CssClass="stdfieldset form-group" ID="grpUnderwriting" runat="server" Tag="AutoChoose.txtTitleUnderwriting.default.(active = 'S')">
                <div class="row">
                    <div class="col-md-2">
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwButton ID="btnFinanziamento" runat="server" Text="Scegli finanziamento" class="btn btn-primary" Tag="choose.underwriting.default" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwButton ID="HwButton3" runat="server" Text="Nuovo finanziamento" class="btn btn-primary" Tag="manage.underwriting.createnew02" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-10">
                        <cc1:hwTextBox ID="txtTitleUnderwriting" runat="server" CssClass="form-control input-md" TabIndex="80" Tag="underwriting.title?x"></cc1:hwTextBox>
                    </div>
                </div>
            </cc1:hwPanel>

        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <cc1:hwPanel runat="server" ID="panelImporto">
                <fieldset>
                    <legend>Dati Contabili</legend>
                    <div class="row">
                        <div class="col-md-12">
                            <cc1:hwPanel runat="server" ID="PnlVariazione" Tag="finvardetail.amount.valuesigned">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-6">
                                        <cc1:hwRadioButton ID="TipoVar1" runat="server" TabIndex="30" Text="Var. in aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-6">
                                        <cc1:hwRadioButton ID="TipoVar2" runat="server" TabIndex="40" Text="Var. in diminuzione" Tag="-" />
                                    </div>
                                </div>
                                <div class="row">
                                    <label for="txtImporto"class="col-md-6">Importo</label>
                                    <div class="col-md-6">
                                        <cc1:hwTextBox ID="txtImporto" runat="server" CssClass="input-md form-control" Tag="finvardetail.amount" TabIndex="50" ></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                    </div>
                </fieldset>
            </cc1:hwPanel>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <label for="txtLimit">Limite imposto alla variazione:</label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <cc1:hwTextBox runat="server" ReadOnly="True" Tag="finvardetail.limit" CssClass="input-md form-control" TabIndex="60" ID="txtLimit"></cc1:hwTextBox>
                </div>
                <div class="col-md-3">
                    <img runat="server" alt="" id="img_Green" visible="false" src="Immagini/green_light.gif" />
                    <img runat="server" alt="" id="img_Red" visible="false" src="Immagini/red_light.gif" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwLabel runat="server" ID="LimSuperato" Text="Limite della variazione superato!" ForeColor="Red" Visible="false"></cc1:hwLabel>
                </div>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-md-6">
            <label for="txtDescrizione">Descrizione Dettaglio:</label>
            <cc1:hwTextBox ID="txtDescrizione" runat="server" TabIndex="110" CssClass="form-control input-md" Tag="finvardetail.description" TextMode="MultiLine" Rows="4"></cc1:hwTextBox><br />
        </div>
        <div class="col-md-6">
            <label for="txtDescrizione">Annotazioni:</label>
            <cc1:hwTextBox ID="txtAnnotazioni" runat="server" TabIndex="120" CssClass="form-control input-md" Tag="finvardetail.annotation" TextMode="MultiLine" Rows="4"></cc1:hwTextBox>
        </div>
    </div>


</asp:Content>
