<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="accountvardetail_default_new02.aspx.cs" Inherits="accountvardetail_default_new02" Title="Dettaglio variazione di Budget" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">


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
                    <cc1:hwPanel GroupingText="Conto" CssClass="gbox scheduler-border form-group" ID="grpConto" runat="server"
                        Tag="AutoManage.txtCodiceConto.treeminusable">

                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwButton runat="server" Text="Conto" ID="btnConto" class="btn btn-primary" Tag="manage.account.treeminusable" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwTextBox TabIndex="20" ID="txtCodiceConto" CssClass="form-control input-md" Tag="account.codeacc?x" runat="server"></cc1:hwTextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <cc1:hwTextBox runat="server" ID="txtDenominazioneConto" CssClass="form-control input-md" Tag="account.title" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
                        </div>

                    </cc1:hwPanel>
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
                            <cc1:hwPanel GroupingText="Anno 1" CssClass="gbox scheduler-border form-group" ID="grpImporto1" runat="server" Tag="accountvardetail.amount.valuesigned">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="TipoVar1" runat="server" TabIndex="30" Text="Aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="TipoVar2" runat="server" TabIndex="40" Text="Diminuzione" Tag="-" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="HwTextAnno1" Tag="accountvardetail.amount" TabIndex="50"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 2" CssClass="gbox scheduler-border form-group" ID="grpImporto2" runat="server" Tag="accountvardetail.amount2.valuesigned">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton2A" runat="server" TabIndex="60" Text="Aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton2D" runat="server" TabIndex="70" Text="Diminuzione" Tag="-" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="HwTextAnno2" Tag="accountvardetail.amount2" TabIndex="80"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 3" CssClass="gbox scheduler-border form-group" ID="grpImporto3" runat="server" Tag="accountvardetail.amount3.valuesigned">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton3A" runat="server" TabIndex="90" Text="Aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton3D" runat="server" TabIndex="100" Text="Diminuzione" Tag="-" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" ID="HwTextAnno3" CssClass="input-md form-control" Tag="accountvardetail.amount3" TabIndex="110"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 4" CssClass="gbox scheduler-border form-group" ID="grpImporto4" runat="server" Tag="accountvardetail.amount4.valuesigned">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton4A" runat="server" TabIndex="200" Text="Aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton4D" runat="server" TabIndex="210" Text="Diminuzione" Tag="-" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" ID="HwTextAnno4" CssClass="input-md form-control" Tag="accountvardetail.amount4" TabIndex="220"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 5" CssClass="gbox scheduler-border form-group" ID="grpImporto5" runat="server" Tag="accountvardetail.amount5.valuesigned">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton5A" runat="server" TabIndex="300" Text="Aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton5D" runat="server" TabIndex="310" Text="Diminuzione" Tag="-" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" ID="HwTextAnno5" CssClass="input-md form-control" Tag="accountvardetail.amount5" TabIndex="320"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <label for="txtTotale">Totale pluriennale</label>
                            <cc1:hwTextBox ID="txtTotale" runat="server" TabIndex="400" CssClass="form-control input-md"></cc1:hwTextBox><br />
                        </div>
                    </div>

                </fieldset>
            </div>

        </div>
    </asp:Panel>

    <div class="row">
        <div class="col-md-12">
            <label for="txtDescrizione">Descrizione Dettaglio:</label>
            <cc1:hwTextBox ID="txtDescrizione" runat="server" TabIndex="410" CssClass="form-control input-md" Tag="accountvardetail.description" TextMode="MultiLine" Rows="2"></cc1:hwTextBox><br />
        </div>
          <div class="col-md-4 col-xs-12">
                <label for="cmbFinanziamento" class="col-xs-12">Fonte di Finanziamento</label>
               <cc1:hwDropDownList ID="cmbFinanziamento"  runat="server" CssClass="form-control col-xs-12" AutoPostBack="true" Tag="accountvardetail.underwritingkind" TabIndex="100"></cc1:hwDropDownList>  
            </div>
        <div class="col-md-4 col-xs-12">
            <cc1:hwLabel Style="font-weight:bold" runat= "server" ID="HwLabelCassa" Text="Prev. Cassa DI 394/2017 "></cc1:hwLabel>
            <cc1:hwTextBox Style="width: 50%;" runat="server" ID="hwTextcassa" CssClass="input-md form-control" Tag="accountvardetail.prevcassa" TabIndex="68"></cc1:hwTextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <cc1:hwPanel ID="gboxclass1" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwButton runat="server" ID="btnCodice1" Tag="manage.sorting1.tree" TabIndex="4" class="btn btn-primary" Text="Codice" />
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
                        <cc1:hwButton runat="server" ID="btnCodice2" Tag="manage.sorting2.tree" class="btn btn-primary" Text="Codice" />
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
                        <cc1:hwButton runat="server" ID="btnCodice3" Tag="manage.sorting3.tree" TabIndex="4" class="btn btn-primary" Text="Codice" />
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
            <cc1:hwPanel ID="grpRipartizioneCosti" GroupingText="Ripartizione Costi" Tag="AutoChoose.txtRipartizione.default.(active='S')" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwButton runat="server" ID="btnRipartizione" Tag="choose.costpartition.default.(active='S')" TabIndex="4" class="btn btn-primary" Text="Codice" />
                        <cc1:hwTextBox runat="server" ID="txtCodiceRipartizione" Tag="costpartition.costpartitioncode?x" CssClass="input-md form-control" TabIndex="4"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-6">
                        <cc1:hwTextBox runat="server" ID="txtRipartizione" Tag="costpartition.title" CssClass="input-md form-control"
                            TextMode="MultiLine" Rows="3" TabIndex="3" ReadOnly="true"></cc1:hwTextBox>
                    </div>
                </div>
            </cc1:hwPanel>
        </div>
    </div>
</asp:Content>
