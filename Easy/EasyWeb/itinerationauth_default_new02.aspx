<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itinerationauth_default_new02.aspx.cs" Inherits="itinerationauth_default_new02" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >
    <style>
        .row{
            margin-top: 10px;
        }
    </style>
        <ul id="mainTabControl" class="nav nav-tabs nav-justified">
			<li><a data-toggle="tab" href="#tabgenerale">Generale</a></li>
			<li><a data-toggle="tab" href="#taballegati">Allegati</a></li>
		</ul>

    <div class="tab-content">
        <div id="tabgenerale" class="tab-pane fade in active">
            <div title="Generale">
                <div class="row">
                    <div class="col-md-12">
                        <fieldset>
                            <legend>Dati Missione</legend>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="txtesercizio">Esercizio</label>
                                            <cc1:hwTextBox runat="server" ID="txtesercizio" CssClass="input-md form-control" Tag="itinerationauthview.yitineration" TabIndex="10"></cc1:hwTextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label for="txtnumero">Numero</label>
                                            <cc1:hwTextBox runat="server" ID="txtnumero" CssClass="input-md form-control" Tag="itinerationauthview.nitineration" TabIndex="20"></cc1:hwTextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <cc1:hwLabel runat="server" ID="lbltappe" Text="N. Tappe"></cc1:hwLabel>
                                            <cc1:hwTextBox runat="server" ID="txtntappe" CssClass="input-md form-control" Tag="itinerationauthview.lapcount" TabIndex="40"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="txtpercipiente">Percipiente</label>
                                            <cc1:hwTextBox runat="server" ID="txtpercipiente" CssClass="input-md form-control" Tag="itinerationauthview.registry"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="txtresponsabile">Responsabile</label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <cc1:hwTextBox runat="server" ID="txtresponsabile" CssClass="input-md form-control" Tag="itinerationauthview.managertitle" TabIndex="60"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="txtLocation">Destinazione principale della missione</label>
                                            <cc1:hwTextBox ID="txtLocation" runat="server" ReadOnly="true" TabIndex="9000" CssClass="input-md form-control" Tag="itinerationauthview.location"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="txtdtainizio">Data Inizio</label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <cc1:hwTextBox runat="server" ID="txtdatainizio" CssClass="input-md form-control" Tag="itinerationauthview.start" TabIndex="70"></cc1:hwTextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="txtdtafine">Data Fine</label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <cc1:hwTextBox runat="server" ID="txtdtafine" CssClass="input-md form-control" Tag="itinerationauthview.stop" TabIndex="90"></cc1:hwTextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <cc1:hwPanel GroupingText="U.P.B." CssClass="gbox scheduler-border form-group" ID="PanelUpb" runat="server" Tag="AutoManage.txtCodiceUPB.tree">
                                            <div class="col-md-7">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <cc1:hwButton ID="btnUpbDisponibile" runat="server" Text="UPB" class="btn btn-block" Tag="choose.upbitinerationavailable.default" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <cc1:hwTextBox TabIndex="20" ID="txtCodiceUPB" CssClass="form-control input-md" Tag="upbitinerationavailable.codeupb?x" runat="server"></cc1:hwTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <cc1:hwTextBox runat="server" ID="txtUpbDisponibile" Tag="upbitinerationavailable.title" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" ReadOnly="True"></cc1:hwTextBox>
                                            </div>
                                        </cc1:hwPanel>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-xs-12">
                                            <cc1:hwLabel CssClass="control-label" runat="server" ID="lblMotivo">Motivo</cc1:hwLabel>
                                        </div>
                                        <div class="col-md-9 col-xs-12">
                                            <cc1:hwTextBox runat="server" ID="txtMotivo" CssClass="form-control" TabIndex="320" Tag="itinerationauthview.applierannotations" TextMode="MultiLine"></cc1:hwTextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-8">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="txtdescr">Descrizione</label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <cc1:hwTextBox runat="server" ID="txtdescr" Tag="itinerationauthview.description" CssClass="input-md form-control" TextMode="MultiLine" Rows="3" TabIndex="50"></cc1:hwTextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="txtadate">Data Contabile</label>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <cc1:hwTextBox runat="server" ID="txtadate" Tag="itinerationauthview.adate" CssClass="input-md form-control" TabIndex="100"></cc1:hwTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="txtSpesePreviste">Totale Spese Previste</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <cc1:hwTextBox runat="server" ID="txtSpesePreviste" Tag="itinerationauthview.totadvance.c" CssClass="input-md form-control" TabIndex="9000" ReadOnly="true"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <cc1:hwButton runat="server" ID="btnspese" class="btn btn-block" Tag="spesepreviste" TabIndex="92" Text="Spese Previste" />
                                        </div>
                                        <div class="col-md-6">
                                            <cc1:hwButton runat="server" ID="btntappe" class="btn btn-block" Tag="tappe" TabIndex="91" Text="Tappe" />
                                        </div>
                                    </div>
                                    <div class="row">
                                       
                                            <div class="col-md-12">
                                                <label>Richieste aggiuntive sulla missione</label>
                                            </div>
                                 
                                      
                                            <div class="col-md-12">
                                                <cc1:hwTextBox runat="server" ID="txtadditionalannotation" CssClass="input-md form-control" Tag="itinerationauthview.additionalannotations" rows="8" TextMode="MultiLine" TabIndex="500"></cc1:hwTextBox>
                                            </div>
                                    
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwLabel runat="server" ID="lblauthagency"></cc1:hwLabel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtapplierannotation">Appunti per il Pagamento/Tipologia di Fondo</label>
                                    <cc1:hwTextBox ID="txtapplierannotation" runat="server" TabIndex="500" CssClass="input-md form-control" Tag="itinerationauthview.applierannotations" TextMode="MultiLine" Rows="2" ReadOnly="True"></cc1:hwTextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtMotivazione">Motivazione per l'eventuale uso del mezzo proprio</label>
                                    <cc1:hwTextBox ID="txtMotivazione" runat="server" ReadOnly="True" TabIndex="500" CssClass="input-md form-control" Tag="itinerationauthview.vehicle_motive" TextMode="MultiLine" Rows="2"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label for="txtAnnotazioniRifiutoApprovazione">Annotazioni per il Rifiuto o Approvazione</label>
                                    <cc1:hwTextBox ID="txtAnnotazioniRifiutoApprovazione" runat="server" TabIndex="500" CssClass="input-md form-control" Tag="itinerationauthview.annotationsrejectapproval" TextMode="MultiLine" Rows="2"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div runat="server" id="plcitems" style="overflow: scroll; max-height: 400px; border: 1px solid grey; background-color: #ffffff; position: fixed; display: none; width: auto; left: 20%; top: 30%; font-size: 13px;">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <cc1:hwButton ID="btnApproveAll" runat="server" TabIndex="95" Tag="approvatutto" class="btn btn-block" Text="Approva tutte le missioni" />
                                </div>
                                <div class="col-md-4">
                                    <cc1:hwButton ID="btnapprova" runat="server" TabIndex="95" Tag="approva" class="btn btn-block" Text="Approva" />
                                </div>
                                <div class="col-md-4">
                                    <cc1:hwButton runat="server" ID="btnresp" Tag="respingi" TabIndex="96" class="btn btn-block" Text="Nega autorizzazione" />
                                </div>
                            </div>
                            <cc1:hwPanel runat="server" ID="panelAutorizzazioni" Visible="false">
                                <div class="row">
                                    <div class="col-md-12">
                                        <fieldset>
                                            <legend>Nega autorizzazione</legend>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="txtrejectreason">Motivo della negazione</label>
                                                    <cc1:hwTextBox runat="server" ID="txtrejectreason" CssClass="input-md form-control" TextMode="SingleLine"></cc1:hwTextBox>
                                                    <cc1:hwButton runat="server" ID="btnproceed" Tag="negaAutorizzazione" Text="Procedi con la negazione" />
                                                    <cc1:hwButton runat="server" ID="btncancel" Tag="nonNegare" Text="Non procedere" />

                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </fieldset>
                    </div>
                </div>
            </div>
            <!-- chiude title-->
        </div>
        <!--chiude tabgenerale-->
				<div id="taballegati" class="tab-pane fade">
                          <div title="Allegati">
                                   <asp:Panel ID="Panel2" runat="server">
                                       <div class="row">		 		
								            <div class="col-md-2">	
                                              <cc1:hwButton id="btnEditAtt" runat="server"  Tag="edit.defaultnew02" Text="Modifica" TabIndex="220"></cc1:hwButton>
                                            </div>
                                            <div class="col-md-10">	
                                                <cc1:hwDataGridWeb ID="gridAtt" runat="server"   Tag="itinerationattachment.default.default" TabIndex="240" />
                                            </div>
                                       </div>
                                   </asp:Panel>        
                            </div>
				</div>
    </div>
<script type="text/javascript">
    function closelist() {
        document.getElementById("<%=plcitems.ClientID%>").innerHTML = "";
    document.getElementById("<%=plcitems.ClientID%>").style.display = "none";
    document.getElementById("<%=showlapsexpenses.ClientID%>").value = "N";
    return;
}

</script>
<asp:TextBox runat="server" ID="showlapsexpenses" style="display: none"></asp:TextBox>
  

    </asp:Content>