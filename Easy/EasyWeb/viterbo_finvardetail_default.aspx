<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="viterbo_finvardetail_default.aspx.cs" Inherits="viterbo_finvardetail_default"  Title="Dettaglio variazione di bilancio" %>

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
                            <cc1:hwPanel GroupingText="Anno 1" CssClass="gbox scheduler-border form-group" ID="grpImporto1" runat="server" Tag="viterbo_finvardetail.amount.valuesigned">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton1" runat="server" TabIndex="30" Text="Aumento" Tag="+" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwRadioButton ID="HwRadioButton2" runat="server" TabIndex="40" Text="Diminuzione" Tag="-" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="HwTextAnno1" Tag="viterbo_finvardetail.amount" TabIndex="50"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 2" CssClass="gbox scheduler-border form-group" ID="grpImporto2" runat="server" Tag="viterbo_finvardetail.prevision2.valuesigned">
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
                                        <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="HwTextAnno2" Tag="viterbo_finvardetail.prevision2" TabIndex="80"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 3" CssClass="gbox scheduler-border form-group" ID="grpImporto3" runat="server" Tag="viterbo_finvardetail.prevision3.valuesigned">
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
                                        <cc1:hwTextBox runat="server" ID="HwTextAnno3" CssClass="input-md form-control" Tag="viterbo_finvardetail.prevision3" TabIndex="110"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 4" CssClass="gbox scheduler-border form-group" ID="grpImporto4" runat="server" Tag="viterbo_finvardetail.prevision4.valuesigned">
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
                                        <cc1:hwTextBox runat="server" ID="HwTextAnno4" CssClass="input-md form-control" Tag="viterbo_finvardetail.prevision4" TabIndex="220"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <cc1:hwPanel GroupingText="Anno 5" CssClass="gbox scheduler-border form-group" ID="grpImporto5" runat="server" Tag="viterbo_finvardetail.prevision5.valuesigned">
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
                                        <cc1:hwTextBox runat="server" ID="HwTextAnno5" CssClass="input-md form-control" Tag="viterbo_finvardetail.prevision5" TabIndex="320"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-3">
                            <label for="txtTotale">Totale pluriennale</label>
                            <cc1:hwTextBox ID="txtTotale" ReadOnly="true" runat="server" TabIndex="400" CssClass="form-control input-md"></cc1:hwTextBox><br />
                             <cc1:hwCheckBox runat="server" ID="HwChkCreaExpense" CssClass="input-md form-control" Tag="viterbo_finvardetail.createexpense:S:N" Text="Richiedi movimento" />
                            <cc1:hwLabel ID="labMovimento" runat="server" Text="Label"></cc1:hwLabel>
                        </div>
                    </div>

                </fieldset>
            </div>

        </div>
    </asp:Panel>





    <div class="row">
        <div class="col-md-7">
            <cc1:hwPanel GroupingText="Finanziamento" CssClass="stdfieldset form-group" ID="grpUnderwriting" runat="server" Tag="AutoChoose.txtTitleUnderwriting.default.(active = 'S')">
                <div class="row">
                    <div class="col-md-2">
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwButton ID="btnFinanziamento" runat="server" Text="Finanziamento" class="btn btn-primary" Tag="choose.underwriting.default" />
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
        <div class="col-md-5">
            <div class="row">
                <cc1:hwPanel GroupingText="U.P.B. del titolare del procedimento" CssClass="gbox scheduler-border form-group" ID="PanelUpb_RespProcedimento" runat="server" Tag="AutoManage.txtCodiceUPB_RespProcedimento.treenosec">
                    <div class="col-md-7">
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwButton ID="btnUpb_RespProcedimento" runat="server" Text="UPB" class="btn btn-primary" Tag="manage.upb_procedureman.treenosec" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox TabIndex="20" ID="txtCodiceUPB_RespProcedimento" CssClass="form-control input-md" Tag="upb_procedureman.codeupb?x" runat="server"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <cc1:hwTextBox runat="server" ID="txtDescrUPB_RespProcedimento" Tag="upb_procedureman.title" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
                    </div>
                </cc1:hwPanel>
            </div>
            </div>
    </div>


    <div class="row">
        <div class="col-md-6">
            <cc1:hwPanel runat="server" ID="panelImporto">
                <fieldset>
                    <legend>Dati Contabili</legend>
                    <div class="row">
                        <div class="col-md-12">
                            <cc1:hwPanel runat="server" ID="PnlVariazione" Tag="viterbo_finvardetail.amount.valuesigned">
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
                                        <cc1:hwTextBox ID="txtImporto" runat="server" CssClass="input-md form-control" Tag="viterbo_finvardetail.amount" TabIndex="50" ></cc1:hwTextBox>
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
                    <cc1:hwTextBox runat="server" ReadOnly="True" Tag="viterbo_finvardetail.limit" CssClass="input-md form-control" TabIndex="60" ID="txtLimit"></cc1:hwTextBox>
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
            <cc1:hwTextBox ID="txtDescrizione" runat="server" TabIndex="110" CssClass="form-control input-md" Tag="viterbo_finvardetail.description" TextMode="MultiLine" Rows="4"></cc1:hwTextBox><br />
        </div>
        <div class="col-md-6">
            <label for="txtDescrizione">Annotazioni:</label>
            <cc1:hwTextBox ID="txtAnnotazioni" runat="server" TabIndex="120" CssClass="form-control input-md" Tag="viterbo_finvardetail.annotation" TextMode="MultiLine" Rows="4"></cc1:hwTextBox>
        </div>
    </div>
        <div class="row" style="padding:10px">
            <div class="col-md-3 col-xs-12">
                <label for="txtDataInizioCompetenza">Data Inizio Competenza</label>
                <cc1:hwTextBox ID="txtDataInizioCompetenza" runat="server"  CssClass="form-control" Tag="viterbo_finvardetail.start"></cc1:hwTextBox>           
            </div>
            <div class="col-md-3 col-xs-12">
                <label for="txtDataFineCompetenza">Data Fine Competenza</label>
                <cc1:hwTextBox ID="txtDataFineCompetenza" runat="server" CssClass="form-control" Tag="viterbo_finvardetail.stop"></cc1:hwTextBox>           
            </div>
            <div class="col-md-4 col-xs-12">
                <label for="cmbCausale" class="col-xs-12">Tipo Movimento</label>
               <cc1:hwDropDownList ID="cmbCausale"  runat="server" CssClass="form-control col-xs-12" AutoPostBack="true" Tag="viterbo_finvardetail.underwritingkind" TabIndex="100"></cc1:hwDropDownList>
                    
            </div>
        </div>
	<div class="row" style="padding: 10px">
		<div class="col-xs-12 col-md-6">
			<cc1:hwPanel GroupingText="Conto" CssClass="gbox scheduler-border form-group" ID="grpConto" runat="server"
				Tag="AutoManage.txtCodiceConto.treeminusable">
				<div class="col-md-7">
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
				<div class="col-md-5">
					<cc1:hwTextBox runat="server" ID="txtDenominazioneConto" CssClass="form-control input-md" Tag="account.title" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
				</div>
			</cc1:hwPanel>
		</div>
		<div class="col-xs-12 col-md-4">
			<cc1:hwPanel ID="grpRipartizioneCosti" GroupingText="Ripartizione Costi" Tag="AutoChoose.txtRipartizione.default.(active='S')" runat="server">
				<div class="row">
					<div class="col-md-6">
						<cc1:hwButton runat="server" ID="btnRipartizione" Tag="choose.costpartition.default.(active='S')" TabIndex="4" Text="Codice" />
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
	<div class="row" style="padding: 10px">
        		<div class="col-xs-12 col-md-6">
			<cc1:hwPanel ID="gboxclass1" runat="server" GroupingText="Ordinamento 1">
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
		<div class="col-xs-12 col-md-6">
			<cc1:hwPanel ID="gboxclass2" runat="server" GroupingText="Ordinamento 2">
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
	<div class="row" style="padding: 10px">
		<div class="col-xs-12 col-md-6">
			<cc1:hwPanel ID="gboxclass3" runat="server" GroupingText="Ordinamento 3">
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

		<div class="col-xs-12 col-md-6">
			<cc1:hwPanel ID="gboxclass4" runat="server" GroupingText="Ordinamento 4">
				<div class="row">
					<div class="col-md-6">
						<cc1:hwButton runat="server" ID="btnCodice4" Tag="manage.sorting4.tree" TabIndex="4" class="btn btn-primary" Text="Codice" />
						<cc1:hwTextBox runat="server" ID="txtCodice4" Tag="sorting4.sortcode?x" CssClass="input-md form-control" TabIndex="4"></cc1:hwTextBox>
					</div>
					<div class="col-md-6">
						<cc1:hwTextBox runat="server" ID="txtDenom4" Tag="sorting4.description" CssClass="input-md form-control"
							TextMode="MultiLine" Rows="3" TabIndex="3" ReadOnly="true"></cc1:hwTextBox>
					</div>
				</div>
			</cc1:hwPanel>
		</div>
	</div>

    <div class="row" style="padding:10px">
      <cc1:hwPanel ID="divCampiStat" runat="server">
        <div class="col-xs-12">
            <fieldset>
                <legend>Campi Statistici</legend>
                <div class="row">
                    <div class="col-md-3">
                        <cc1:hwLabel runat="server" ID="HwLabel1" Text="Didattica"></cc1:hwLabel>
                        <cc1:hwTextBox Style="width: 50%;" runat="server" CssClass="input-md form-control" ID="HwTextDidattica" Tag="viterbo_finvardetail.didattica" TabIndex="66"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-3">
                        <cc1:hwLabel runat="server" ID="txtricerca" Text="Ricerca"></cc1:hwLabel>
                        <cc1:hwTextBox Style="width: 50%;" runat="server" CssClass="input-md form-control" ID="HwTextRicerca" Tag="viterbo_finvardetail.ricerca" TabIndex="67"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-3">
                        <cc1:hwLabel runat="server" ID="txtservizi" Text="Servizi"></cc1:hwLabel>
                        <cc1:hwTextBox Style="width: 50%;" runat="server" ID="HwTextServizi" CssClass="input-md form-control" Tag="viterbo_finvardetail.servizi" TabIndex="68"></cc1:hwTextBox>
                    </div>
                    <div class="col-md-3">
                        <cc1:hwLabel runat="server" ID="HwLabelCassa" Text="Prev. Cassa DI 394/2017 "></cc1:hwLabel>
                        <cc1:hwTextBox Style="width: 50%;" runat="server" ID="hwTextcassa" CssClass="input-md form-control" Tag="viterbo_finvardetail.prevcassa" TabIndex="68"></cc1:hwTextBox>
                    </div>
                </div>
            </fieldset>
        </div>
    </cc1:hwPanel>
    </div>



</asp:Content>
