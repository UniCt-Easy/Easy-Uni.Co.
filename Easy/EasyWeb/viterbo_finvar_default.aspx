<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="viterbo_finvar_default.aspx.cs" Inherits="viterbo_finvar_default"  Title="Viterbo - Richiesta Variazione bilancio" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

   
                
    <div class="row">
        <div class="col-md-12">
            <cc1:hwButton ID="B1" runat="server" Text="Ordina per stato" class="btn btn-primary" Tag="do_command.OrdinaPerStato" />
            <cc1:hwButton ID="B2" runat="server" Text="Storico Variazioni Approvate" class="btn btn-primary" Tag="do_command.StoricoVariazioni"/>
        </div>
    </div>                

    <div class="row">
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-6">
                    <label for="esercizio">Esercizio</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="esercizio" runat="server" CssClass="form-control" Tag="viterbo_finvar.yvar.year" TabIndex="10"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label for="nman">Prot.</label>
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="nvar" runat="server" CssClass="input-md form-control" Tag="viterbo_finvar.nvar" TabIndex="20"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <cc1:hwCheckBox ID="Official" runat="server" Text="Num.Var.Ufficiale" Tag="viterbo_finvar.official:S:N" TabIndex="70" />
                </div>
                <div class="col-md-6">
                    <cc1:hwTextBox ID="NumUfficiale" runat="server" CssClass="input-md form-control" Tag="viterbo_finvar.nofficial" TabIndex="80"></cc1:hwTextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <cc1:hwPanel GroupingText="Tipo Variazione" CssClass="stdfieldset form-group" ID="groupTipoPrevisione" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwRadioButton ID="variationtime1" runat="server" Text="Normale" Tag="viterbo_finvar.variationkind:1" TabIndex="30" /><br />
                        <cc1:hwRadioButton ID="variationtime2" runat="server" Text="Ripartizione" Tag="viterbo_finvar.variationkind:2" TabIndex="40" /><br />
                        <cc1:hwRadioButton ID="variationtime3" runat="server" Text="Assestamento" Tag="viterbo_finvar.variationkind:3" TabIndex="50" /><br />
                        <cc1:hwRadioButton ID="variationtime4" runat="server" Text="Storno" Tag="viterbo_finvar.variationkind:4" TabIndex="60" /><br />
                        <cc1:hwRadioButton ID="variationtime5" runat="server" Text="Iniziale" tag="viterbo_finvar.variationkind:5" TabIndex="61"/> 
                    </div>
                </div>
            </cc1:hwPanel>
        </div>

        <div class="col-md-4">
            <fieldset>
                <legend>Tipo Previsione / Dotazione</legend>
                <cc1:hwCheckBox ID="chkPrevPrincipale" TabIndex="63" runat="server" Text="Competenza" Tag="viterbo_finvar.flagprevision:S:N" />
                <cc1:hwCheckBox ID="ChkPrevSecondaria" TabIndex="65" runat="server" Text="Cassa" Tag="viterbo_finvar.flagsecondaryprev:S:N" />

            </fieldset>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" ID="grpResponsabile" runat="server" Tag="AutoChoose.txtResponsabile.lista.(financeactive='S')">
                <cc1:hwButton ID="btnResponsabile" runat="server" Text="Responsabile" class="btn btn-primary" Tag="choose.manager.lista" />
                <cc1:hwTextBox TabIndex="20" ID="txtResponsabile" CssClass="form-control input-md" Tag="manager.title?x" runat="server"></cc1:hwTextBox>
            </cc1:hwPanel>
        </div>
        <div class="col-md-4">
            <label for="DataContabile">Data Contabile</label>
            <cc1:hwTextBox ID="DataContabile" runat="server" Tag="viterbo_finvar.adate" CssClass="form-control" TabIndex="90"></cc1:hwTextBox>
        </div>
        <div class="col-md-4">
            <!-- Colonne vuote-->
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12">
                    <label for="descrizione">Descrizione</label>
                    <cc1:hwTextBox ID="descrizione" runat="server" Tag="viterbo_finvar.description" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="100"></cc1:hwTextBox>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12">
                    <label for="Saldo">Saldo</label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwTextBox runat="server" ID="Saldo" ReadOnly="True" Tag="" CssClass="input-md form-control" TabIndex="170"></cc1:hwTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label for="Limit">Limite</label>
                </div>
                </div>
            <div class="row">
                <div class="col-md-9">
                    <cc1:hwTextBox runat="server" ID="Limit" Tag="viterbo_finvar.limit" CssClass="input-md form-control" ReadOnly="True" TabIndex="180"></cc1:hwTextBox><br />
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
        <div class="col-md-4">
            <fieldset>
                <legend>Stato Corrente</legend>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwDropDownList ID="idfinvarstatus" CssClass="input-md form-control" Tag="viterbo_finvar.idfinvarstatus?viterbo_finvarview.idfinvarstatus" runat="server" AutoPostBack="True" TabIndex="130"></cc1:hwDropDownList>
                    </div>
                </div>
            </fieldset>
            <div class="row">
                <div class="col-md-4">
                    <label for="btnStatus"></label>
                    <cc1:hwButton ID="btnStatus" runat="server" Tag="approvati" class="btn btn-primary" Visible="False" />
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-md-8">
            <fieldset>
                <legend>Provvedimento</legend>
                <div class="row">
                    <div class="col-md-6">
                        <cc1:hwTextBox runat="server" ID="Provvedimento" Tag="viterbo_finvar.enactment" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="140"></cc1:hwTextBox><br />
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-3">
                                <label for="DataProvv">Data:</label>
                            </div>
                            <div class="col-md-9">
                                <cc1:hwTextBox runat="server" ID="DataProvv" Tag="viterbo_finvar.enactmentdate" CssClass="input-md form-control c_Data" TabIndex="150"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label for="NumProvv">Numero:</label>
                            </div>
                            <div class="col-md-9">
                                <cc1:hwTextBox runat="server" ID="NumProvv" Tag="viterbo_finvar.nenactment" CssClass="input-md form-control" TabIndex="160"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>

                </div>
            </fieldset>
        </div>
        <div class="col-md-4">
            <fieldset>
                <legend>Atto Amministrativo</legend>
                <div class="row">
                    <div class="col-md-4">
                        <label for="yadministrativeact">Esercizio:</label>
                    </div>
                    <div class="col-md-8">
                        <cc1:hwTextBox runat="server" ID="yadministrativeact" CssClass="form-control" Tag="enactment.yenactment" TabIndex="110" Width="153px"></cc1:hwTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label for="nadministrativeact">Numero:</label>
                    </div>
                    <div class="col-md-8">
                        <cc1:hwTextBox runat="server" ID="nadministrativeact" CssClass="form-control" Tag="enactment.nenactment" TabIndex="120" Width="151px"></cc1:hwTextBox>
                    </div>
                </div>
            </fieldset>

        </div>




    </div>


        <ul id="mainTabControl" class="nav nav-tabs nav-justified">
            <li><a data-toggle="tab" href="#tabdettagli">Dettagli</a></li>
            <li><a data-toggle="tab" href="#taballegati">Allegati</a></li>
        </ul>

    <div class="tab-content">
        <div id="tabdettagli" class="tab-pane fade">
            <div title="Dettagli">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="row">
                        <div class="col-md-2">
                            <cc1:hwButton ID="btnInsert" runat="server" Tag="insert.default" Text="Inserisci" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
                            <cc1:hwButton ID="btnEdit" runat="server" Tag="edit.default" Text="Modifica" class="btn btn-info" TabIndex="220"></cc1:hwButton>
                            <cc1:hwButton ID="btnDelete" runat="server" Tag="delete" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
                        </div>
                        <div class="col-md-10">
                            <cc1:hwDataGridWeb ID="DtlDataGrid" runat="server" Tag="viterbo_finvardetail.listaweb.single" TabIndex="240" />
                        </div>
                    </div>



                </asp:Panel>
            </div>

        </div>

        <div id="taballegati" class="tab-pane fade">
            <div title="Allegati">
                <asp:Panel ID="Panel2" runat="server">
                    <div class="row">
                        <div class="col-md-2">
                            <cc1:hwButton ID="btnInsAllegato" runat="server" Tag="insert.defaultnew02" Text="Inserisci" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
                            <cc1:hwButton ID="HwEditAllegato" runat="server" Tag="edit.defaultnew02" Text="Modifica" class="btn btn-info" TabIndex="220"></cc1:hwButton>
                            <cc1:hwButton ID="HwCancAllegato" runat="server" Tag="delete" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
                        </div>
                        <div class="col-md-10">
                            <cc1:hwDataGridWeb ID="HwDataGridAllegati" runat="server" Tag="finvarattachment.default.default" TabIndex="240" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>

    </div>	<!-- chiude tab-content	-->
  
			

</asp:Content>
