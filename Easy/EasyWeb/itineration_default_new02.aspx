<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itineration_default_new02.aspx.cs" Inherits="itineration_default_new02" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

            <ul id="mainTabControl" class="nav nav-tabs nav-justified">
     
				<li><a data-toggle="tab" href="#tabgenerale">Generale</a></li>
				<li><a data-toggle="tab" href="#tabautorizzazionicomunicazioni">Autorizzazioni</a></li>
				<li><a data-toggle="tab" id='titleTappe' href="#tabtappespese">Tappe e Spese</a></li>
                <li><a data-toggle="tab" href="#tabmezzo">Mezzo proprio</a></li>
                <li><a data-toggle="tab" href="#tabpagamenti">Annotazioni</a></li>
				<li><a data-toggle="tab" href="#taballegati">Allegati</a></li>
            	<li class="ephid"><a data-toggle="tab" href="#tabEP">E/P</a></li>
     
			</ul>
			<div class="tab-content">
				<div id="tabgenerale" class="tab-pane fade in active">
                           <div title="Generale">
                               <asp:Panel ID="Panel1" runat="server">
                                   <div class="row">
                                       <div class="col-md-4">
                                           <!-- 4 colonne vuote-->
                                       </div>
                                       <div class="col-md-4">
                                           <cc1:hwButton runat="server" ID="btnitinerationhistory" Text="Storico Missioni Approvate" TabIndex="-1" ></cc1:hwButton>
                                       </div>
                                       <div class="col-md-4">
                                           <!-- 4 colonne vuote-->
                                       </div>

                                   </div>
                                   <!-- chiude row -->


                                   <div class="row">
                                    <div class="col-md-8"><!-- prima colonna formata da 8 span-->

                                   <div class="row">
                                       <div class="col-md-5">
                                           <fieldset>
                                               <legend>Missione</legend>
                                               <div class="row">
                                                   <div class="col-md-12">
                                                       <div class="col-md-4">
                                                           <label for="input-text" class="control-label">Esercizio</label>
                                                       </div>
                                                       <div class="col-md-8">
                                                           <cc1:hwTextBox CssClass="input-md form-control" runat="server" ID="txtEsercmissione" Tag="itineration.yitineration.year" TabIndex="10"></cc1:hwTextBox>
                                                       </div>
                                                   </div>
                                               </div>
                                               <div class="row">
                                                   <div class="col-md-12">
                                                       <div class="col-md-4">
                                                           <label for="txtNummissione">Numero</label>
                                                       </div>
                                                       <div class="col-md-8">
                                                           <cc1:hwTextBox CssClass="input-md form-control" ID="txtNummissione" runat="server" Tag="itineration.nitineration" TabIndex="20"></cc1:hwTextBox>
                                                       </div>

                                                   </div>
                                               </div>
                                           </fieldset>
                                       </div>
                                       <div class="col-md-7">
                                           <fieldset>
                                               <legend>Stato</legend>
                                               <div class="row">
                                                   <div class="col-md-3">
                                                       <label for="cmbStatus">Stato</label>
                                                   </div>
                                                   <div class="col-md-9">
                                                       <cc1:hwDropDownList ID="cmbStatus" CssClass="form-control"
                                                           Tag="itineration.iditinerationstatus?itinerationview.iditinerationstatus" runat="server" AutoPostBack="True" TabIndex="30">
                                                       </cc1:hwDropDownList>
                                                   </div>
                                               </div>
                                               <div class="row">
                                                   <div class="col-md-3">
                                                       <!-- 4 colonne vuote-->
                                                   </div>
                                                   <div class="col-md-9">
                                                       <cc1:hwButton runat="server" ID="btnStatus" Tag="StatusClick" Text="Invia Richiesta" TabIndex="-1"></cc1:hwButton>
                                                   </div>
                                               </div>
                                           </fieldset>
                                       </div>
                                   </div>

                                          <div class="row">
                                              <div class="col-md-12">
                                                <cc1:hwPanel GroupingText="Richiedente" CssClass="stdfieldset form-group" ID="grpIncaricato" runat="server" Tag="AutoChoose.txtIncaricato.default.((active = 'S') AND (idreg IN(SELECT idreg FROM registrylegalstatus)) )">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <cc1:hwTextBox ID="txtIncaricato" runat="server" CssClass="gbox form-control input-md" TabIndex="40" 
                                                                Tag="registry.title?itinerationview.registry">
                                                            </cc1:hwTextBox>
                                                        </div>
                                                    </div>
                                                </cc1:hwPanel>
                                            </div>
                                          </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <fieldset>
                                                    <legend>Località principale</legend>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <cc1:hwTextBox runat="server" CssClass="form-control" ID="txtLocation" Tag="itineration.location" TabIndex="50"></cc1:hwTextBox>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>

                                            <div class="col-md-6">
                                                <fieldset>
                                                    <legend>Responsabile del fondo</legend>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" ID="grpResponsabile" runat="server" Tag="AutoChoose.txtResponsabile.lista.(financeactive='S')">
                                                                <cc1:hwButton ID="btnResponsabile" runat="server" Text="Responsabile" class="btn btn-block" Tag="choose.manager.lista.(financeactive='S')" />
                                                                <cc1:hwTextBox TabIndex="20" ID="txtResponsabile" CssClass="form-control input-md" Tag="manager.title?x" runat="server"></cc1:hwTextBox>
                                                            </cc1:hwPanel>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                        </div>

                                        <div class="row">
                                                <div class="col-md-12">
                                                    <fieldset>
                                                        <legend>Date della Missione</legend>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <label for="txtDataInizio">Data inizio:</label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <cc1:hwTextBox runat="server" ID="txtDataInizio" CssClass="form-control" Tag="itineration.start" TabIndex="70" ></cc1:hwTextBox>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label for="txtDataFine">Data fine:</label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <cc1:hwTextBox runat="server" ID="txtDataFine" CssClass="form-control" Tag="itineration.stop" TabIndex="80" ></cc1:hwTextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                </div>
                                                            <div class="col-md-3">
                                                                <label for="txtDataContabile">Data contabile:</label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <cc1:hwTextBox runat="server" ID="txtDataContabile" CssClass="form-control" Tag="itineration.adate" TabIndex="90" ReadOnly="true"></cc1:hwTextBox>
                                                            </div>
                                                        </div>
                                                        </fieldset>
                                                   </div>
                                            </div>

                                        <div class="row">
                                            <div class="panel-group col-md-12" id="Div1" role="tablist" aria-multiselectable="true">
                                                <div class="btn btn-info btn-block" role="tab" id="tabPosizioneGiuridicaHead">
                                                    <h4 class="panel-title">
                                                        <a role="button" data-toggle="collapse" data-parent="#panelPosizioneGiuridica" href="#tabPosizioneGiuridicaBody"
                                                            aria-expanded="true" aria-controls="panelPosizioneGiuridica">Posizione giuridica(a cura del sistema)</a>
                                                    </h4>
                                                </div>
                                                <div id="tabPosizioneGiuridicaBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabPosizioneGiuridicaHead">
                                                    <div class="panel-body row form-horizontal">

                                                        <div class="col-md-12">

                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    <label for="txtQualifica">Qualifica</label>
                                                                </div>
                                                                <div class="col-md-10">
                                                                    <cc1:hwTextBox runat="server" ID="txtQualifica" CssClass="form-control" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    <label for="txtClassStip">Classe stipendiale:</label>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <cc1:hwTextBox runat="server" ID="txtClassStip" CssClass="form-control" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <label for="txtDecorrClassStip">Data Decorrenza:</label>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <cc1:hwTextBox runat="server" ID="txtDecorrClassStip" CssClass="form-control" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    <label for="txtGruppoEstero">Gruppo estero:</label>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <cc1:hwTextBox runat="server" ID="txtGruppoEstero" CssClass="form-control" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <label for="txtMatricola">Matricola</label>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <cc1:hwTextBox runat="server" ID="txtMatricola" CssClass="form-control" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </div> <!-- chiude la prima colonna-->
                                       <div class="col-md-4">
                                           <!-- seconda colonna formata da 4 span-->
                                           <div class="row">
                                               <div class="col-md-12">
                                                   <label for="txtDescrizione">Descrizione</label>
                                               </div>
                                           </div>
                                           <div class="row">
                                               <div class="col-md-12">
                                                   <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtDescrizione" Tag="itineration.description" TextMode="MultiLine" TabIndex="100"></cc1:hwTextBox>
                                               </div>
                                           </div>
                                            <!-- Imponibile Esente-->       
                                           <div class="row">
                                               <div class="panel-group col-md-12" id="Div2" role="tablist" aria-multiselectable="true">
                                                   <div class="btn btn-info btn-block" role="tab" id="tabImpEsenteHead">
                                                       <h4 class="panel-title">
                                                           <a role="button" data-toggle="collapse" data-parent="#panelImpEsente" href="#tabImpEsenteBody"
                                                               aria-expanded="true" aria-controls="panelImpEsente">Imponibile Esente</a>
                                                       </h4>
                                                   </div>
                                                   <div id="tabImpEsenteBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabImpEsenteHead">
                                                       <div class="panel-body row form-horizontal">
                                                           <div class="col-md-6">
                                                               <label for="txtImpEsenteItalia">Per le missioni in Italia:</label>
                                                               <cc1:hwTextBox runat="server" ID="txtImpEsenteItalia" CssClass="form-control" Rows="4" TabIndex="3"></cc1:hwTextBox>
                                                           </div>
                                                           <div class="col-md-6">
                                                               <label for="txtImpEsenteEstero">Per le missioni all'estero:</label>
                                                               <cc1:hwTextBox runat="server" ID="txtImpEsenteEstero" CssClass="form-control" Rows="4" TabIndex="3"></cc1:hwTextBox>
                                                           </div>
                                                       </div>
                                                   </div>
                                               </div>
                                           </div>
                                           <!--------------------->
                                            <!-- Sezioni totati-->
                                           <div class="row">
                                               <div class="col-md-12">
                                                   <fieldset>
                                                       <legend>Totali</legend>
                                                       <div class="row">
                                                           <div class="col-md-7">
                                                               <cc1:hwLabel ID="HwLabel1" runat="server" Text="Anticipo riscosso"></cc1:hwLabel>
                                                           </div>
                                                           <div class="col-md-5">
                                                               <cc1:hwTextBox runat="server" ID="txtAnticipoErogato" CssClass="form-control" Style="text-align:right" ReadOnly="true" Tag="" TabIndex="-1"></cc1:hwTextBox>
                                                           </div>
                                                       </div>
                                                       <div class="row">
                                                           <div class="col-md-7">
                                                               <cc1:hwLabel ID="HwLabel2" runat="server" Text="Riscosso"></cc1:hwLabel>
                                                           </div>
                                                           <div class="col-md-5">
                                                               <cc1:hwTextBox runat="server" ID="txtTotaleErogato" CssClass="form-control" ReadOnly="true" Tag="" Style="text-align:right"  TabIndex="-1"></cc1:hwTextBox>
                                                           </div>
                                                       </div>
                                                       <div class="row">
                                                           <div class="col-md-7">
                                                               <cc1:hwLabel ID="HwLabel3" runat="server" Text="Residuo da riscuotere"></cc1:hwLabel>
                                                           </div>
                                                           <div class="col-md-5">
                                                               <cc1:hwTextBox runat="server" ID="txtResiduoDaErogare" CssClass="form-control" ReadOnly="true" Style="text-align:right"  Tag="" TabIndex="-1"></cc1:hwTextBox>
                                                           </div>
                                                       </div>
                                                   </fieldset>

                                               </div>
                                           </div>
                                           <asp:Panel ID="PanelCSA" runat="server">
                                               <div class="row csahid">
                                                   <div class="col-md-12">
                                                       <fieldset>
                                                           <legend>Dati CSA</legend>
                                                           <div class="row">
                                                               <div class="col-md-5">
                                                                   <label for="txtCompartoCSA">Comparto</label>
                                                               </div>
                                                               <div class="col-md-7">
                                                                   <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtCompartoCSA" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-md-5">
                                                                   <label for="txtRuoloCSA">Ruolo</label>
                                                               </div>
                                                               <div class="col-md-7">
                                                                   <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtRuoloCSA" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-md-5">
                                                                   <label for="txtInquadrcsa">Inquadramento</label>
                                                               </div>
                                                               <div class="col-md-7">
                                                                   <cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtInquadrcsa" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-md-8"></div>
                                                               <div class="col-md-4">
                                                                   <cc1:hwButton runat="server" ID="btnCambiaRuolo" OnClick="btnCambiaRuolo_Click" Tag="" TabIndex="-1" Text="Scegli Ruolo"></cc1:hwButton>
                                                               </div>
                                                           </div>
                                                       </fieldset>
                                                   </div>
                                               </div>
                                           </asp:Panel>

 
                                           <div class="row">
                                               <div class="col-md-12">
                                                   <cc1:hwCheckBox runat="server" ID="chkWeb" ThreeState="false" Tag="itineration.flagweb:S:N" TabIndex="-1" Text="Missione inserita mediante interfaccia web" />
                                               </div>
                                           </div>

                                       </div><!-- chiude la seconda colonna, quella di destra-->
                                   </div>



                                
                               </asp:Panel>                                                                                           
                        </div> <!-- chiude title-->

				</div> <!--chiude tabgenerale-->

				<div id="tabautorizzazionicomunicazioni" class="tab-pane fade">
                    <div title="Autorizzazioni e Comunicazioni">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend>Modello autorizzativo</legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <cc1:hwDropDownList ID="cmbAuthModel" CssClass="form-control"
                                                Tag="itineration.idauthmodel?itinerationview.idauthmodel" runat="server" AutoPostBack="True" TabIndex="40">
                                            </cc1:hwDropDownList>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend>Autorizzazioni</legend>
                                    <asp:Panel ID="Panel3" runat="server">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <cc1:hwPanel CssClass="gbox" runat="server" ID="groupBox12">
                                                    <cc1:hwDataGridWeb runat="server" ID="dgrAutorizzazioni" Tag="itinerationauthagency.webdefault" />
                                                </cc1:hwPanel>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend>Avvisi per il Richiedente</legend>
                                    <cc1:hwTextBox runat="server" ID="txtwebwarn" CssClass="form-control"  Tag="itineration.webwarn"  TextMode="MultiLine" Rows="4" TabIndex="490"></cc1:hwTextBox>
                                </fieldset>
                            </div>
                        </div>
                    </div>
				</div>
				<div id="tabtappespese" class="tab-pane fade">
                    <div title="Tappe e Spese">
                        <asp:Panel ID="PanelTappe" runat="server">
                       <div class="row hid1">		 		
                           <div class="col-md-12">
                               <fieldset>
                                   <legend>Tappe</legend>

                                   <div class="row">
                                       <div class="col-md-12">
                                           <cc1:hwButton runat="server" ID="btnInsertTappa" Tag="insert.defaultnew02" TabIndex="-1" Text="Inserisci"></cc1:hwButton>
                                           <cc1:hwButton runat="server" ID="btnEditTappa" Tag="edit.defaultnew02" TabIndex="-1" Text="Modifica"></cc1:hwButton>
                                           <cc1:hwButton runat="server" ID="btnDelTappa" Tag="delete" TabIndex="-1" Text="Cancella"></cc1:hwButton>
                                       </div>
                                   </div>
                                   <div class="row">
                                       <div class="col-md-12">
                                           <cc1:hwDataGridWeb runat="server" ID="dgrTappe" Tag="itinerationlap.default.defaultnew02" />
                                       </div>
                                   </div>

                               </fieldset>
                           </div>
                           </div>
                            </asp:Panel>
                       <div class="row">		 		
						    <div class="col-md-6">	
                                <asp:Panel ID="PanelAnticipo" runat="server">
                                <fieldset>
                                    <legend>Spese Preventivate/Anticipo Richiesto</legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <cc1:hwButton runat="server" id="btnInsertSpesa" tag="insert.advancenew02" TabIndex="-1" Text="Inserisci"></cc1:hwButton>
                                                <cc1:hwButton runat="server"  id="btnEditSpesa" tag="edit.advancenew02" TabIndex="-1" Text="Modifica"></cc1:hwButton>
                                                <cc1:hwButton runat="server" id="btnDelSpesa" tag="delete" TabIndex="-1" Text="Elimina"></cc1:hwButton>
                                                </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                    <cc1:hwDataGridWeb runat="server"  CssClass="he1" id="dgrSpeseAnticipo" tag="itinerationrefund_advance.advance.advance"  TabIndex="-1" />
                                            </div>
                                        </div>
                                    <div class="row">
                                        <div class="offset12"></div>
                                        </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="txtanticiporichiesto">Totale Spese richieste per Anticipo</label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-7">
                                            <cc1:hwTextBox runat="server" CssClass="sup2 input-md form-control" ID="txtanticiporichiesto" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="txtanticipoaccordato">Totale Spese accordate per Anticipo</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-7">
                                            <cc1:hwTextBox runat="server" CssClass="sup2 input-md form-control" ID="txtanticipoaccordato" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                        </div>
                                    </div>

                                </fieldset>
                                    </asp:Panel>
                            </div>
						    <div class="col-md-6">	
                                <asp:Panel ID="grpRendicontoSpese" runat="server">
                                    <fieldset class="GroupBoxLabel sup1 hid2">
                                        <legend>Rendiconto Spese</legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <cc1:hwButton runat="server" ID="btnInsertSpesaSaldo" Tag="insert.balancenew02" TabIndex="-1" Text="Inserisci"></cc1:hwButton>
                                                <cc1:hwButton runat="server" ID="btnEditSpesaSaldo" Tag="edit.balancenew02" TabIndex="-1" Text="Modifica"></cc1:hwButton>
                                                <cc1:hwButton runat="server" ID="btnDeleteSpesaSaldo" Tag="delete" TabIndex="-1" Text="Elimina"></cc1:hwButton>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <cc1:hwDataGridWeb runat="server" CssClass="he1" ID="dgrSpeseSaldo" Tag="itinerationrefund_balance.balance.balance" TabIndex="-1" />
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <label for="txtsaldorichiesto">Totale Saldo Richiesto</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" CssClass="hid2 sup2 input-md form-control" ID="txtsaldorichiesto" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <label for="txtsaldoaccordato">Totale Saldo Accordato</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" CssClass="hid2 sup2  input-md form-control" ID="txtsaldoaccordato" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                        
                                    </fieldset>
                                </asp:Panel>
                            </div>
                           </div>


				        </div>
                    </div>

				<div id="tabmezzo" class="tab-pane fade">
                    <div title="Mezzo proprio"> 
                        
                        <asp:Panel ID="km_panel" runat="server">
                            <div class="row">
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend>Mezzo proprio</legend>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <label for="txtKmMezzoProprio">Km. percorsi</label>
                                            </div>
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" ID="txtKmMezzoProprio" CssClass="input-md form-control c_KmMezzoProprio" Tag="itineration.owncarkm" TabIndex="320"></cc1:hwTextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-5">
                                                <label for="txtEurKmMezzoProprio">EUR/Km.</label>
                                            </div>
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" ID="txtEurKmMezzoProprio" CssClass="input-md form-control c_EurKmMezzoProprio" Tag="itineration.owncarkmcost.fixed.5...1" TabIndex="330"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <label for="txtEurTotMezzoProprio">EUR tot.</label>
                                            </div>
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" ID="txtEurTotMezzoProprio" CssClass="input-md form-control c_EurTotMezzoProprio" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend>A piedi</legend>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <label for="txtKmAPiedi">Km. percorsi</label>
                                            </div>
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" CssClass="input-md form-control c_KmAPiedi" ID="txtKmAPiedi" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <label for="txtEurKmAPiedi">EUR/Km.</label>
                                            </div>
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" CssClass="input-md form-control c_EurKmAPiedi" ID="txtEurKmAPiedi" Tag="itineration.footkmcost.fixed.5...1" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <label for="txtEurTotAPiedi">EUR tot.</label>
                                            </div>
                                            <div class="col-md-7">
                                                <cc1:hwTextBox runat="server" CssClass="input-md form-control c_EurTotAPiedi" ID="txtEurTotAPiedi" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-md-3">
                                            <label for="txtformulakm">Formula di EUR tot.</label>
                                        </div>
                                        <div class="col-md-3">
                                            <cc1:hwTextBox runat="server" ID="txtformulakm" CssClass="input-md form-control" TabIndex="-1" ReadOnly="true" Text="Km. percorsi * EUR/Km."></cc1:hwTextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </asp:Panel>

                        <asp:Panel ID="PanelClausola" runat="server">
                            <div class="row hid3">
                                <div class="col-md-12">
                                    <label>Clausola di richiesta</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwTextBox runat="server" ID="HwTextBox2" CssClass="input-md form-control" TextMode="MultiLine" ReadOnly="true" TabIndex="-1"></cc1:hwTextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwCheckBox runat="server" ID="HwCheckClause" ThreeState="false" Tag="itineration.clause_accepted:S:N" Text="Accetto la clausola" TabIndex="501"></cc1:hwCheckBox>
                                </div>
                            </div>
                        </asp:Panel>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Motivazione</label>
                                </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox runat="server" id="txtMotivazione" CssClass="input-md form-control" Tag="itineration.vehicle_motive" TextMode="MultiLine" rows="4" TabIndex="500" ></cc1:hwTextBox>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Dati di identificazione del veicolo (modello, targa, anno immatricolazione</label>
                                </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox runat="server" ID="txtinfovehicle" CssClass="input-md form-control" Tag="itineration.vehicle_info"  TextMode="SingleLine" TabIndex="500"></cc1:hwTextBox>
                            </div>
                        </div>


                    </div> <!-- chiude Title Mezzo proprio-->
				</div> <!-- chiude tab Mezzo proprio-->

                <div id="tabpagamenti" class="tab-pane fade">
                    <div title="Pagamenti">
                        <div class="row">
                            <div class="col-md-12">
                                <label>Appunti per il pagamento &#47; Tipologia di Fondo</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox runat="server" ID="txtapplierannotation" CssClass="input-md form-control" Tag="itineration.applierannotations" Rows="8" TextMode="MultiLine" TabIndex="500"></cc1:hwTextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Richieste aggiuntive sulla missione</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <cc1:hwTextBox runat="server" ID="txtadditionalannotation" CssClass="input-md form-control" Tag="itineration.additionalannotations" Rows="8" TextMode="MultiLine" TabIndex="500"></cc1:hwTextBox>
                            </div>
                        </div>
                    </div>
                </div>

				<div id="taballegati" class="tab-pane fade">
                          <div title="Allegati">
                                   <asp:Panel ID="Panel2" runat="server">
                                       <div class="row">		 		
								            <div class="col-md-2">	
                                              <cc1:hwButton id="btnInsAtt" runat="server"  Tag="insert.defaultnew02" Text="Inserisci"   TabIndex="210"></cc1:hwButton>
                                              <cc1:hwButton id="btnEditAtt" runat="server"  Tag="edit.defaultnew02" Text="Modifica" TabIndex="220"></cc1:hwButton>
                                              <cc1:hwButton id="btnDelAtt" runat="server"  Tag="delete" Text="Elimina" TabIndex="230"></cc1:hwButton>
                                            </div>
                                            <div class="col-md-10">	
                                                <cc1:hwDataGridWeb ID="gridAtt" runat="server"   Tag="itinerationattachment.default.default" TabIndex="240" />
                                            </div>
                                       </div>
                                   </asp:Panel>        
                            </div>
				</div>

                <div id="tabEP" class="tab-pane fade ephid">
                    <div title="E/P">
                    </div>
                            <div class="row">
                                 <cc1:hwPanel GroupingText="U.P.B." CssClass="gbox scheduler-border form-group" ID="PanelUpb" runat="server" Tag="AutoManage.txtCodiceUPB.tree">
                                <div class="col-md-10">
                                    <fieldset>
                                        <legend>Finanziario</legend>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <cc1:hwButton runat="server" ID="btnUPB" Tag="manage.upb.tree" TabIndex="380" Text="UPB"></cc1:hwButton>
                                                    </div>
                                                    <div class="col-md-9">
                                                            <cc1:hwTextBox TabIndex="390" ID="txtCodiceUPB" CssClass="form-control input-md" Tag="upb.codeupb?x" runat="server"></cc1:hwTextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <cc1:hwTextBox runat="server" Tag="upb.title" ID="txtDescrUPB" CssClass="input-md form-control" TextMode="multiline" TabIndex="-1"></cc1:hwTextBox>
                                            </div>
                                          
                                        </div>
                                    </fieldset>
                                </div>
                                 </cc1:hwPanel>
                                <div class="col-md-2">
                                    <!-- colonna vuota-->
                                    </div>
                            </div>
                     <asp:Panel ID="PanelAnalitico" runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <fieldset>
                                <legend>Analitico</legend>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <!-- Classificazione 1-->

                                                <cc1:hwPanel GroupingText="Classificazione 1" CssClass="gbox stdfieldset form-group" ID="gboxclass1" runat="server" Tag="AutoManage.txtCodice1.treeclassmovimenti">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <cc1:hwButton runat="server" ID="btnCodice1" Tag="manage.sorting1.tree" TabIndex="400" Text="Codice"></cc1:hwButton>
                                                            <cc1:hwTextBox runat="server" ID="txtCodice1" CssClass="form-control input-md" Tag="sorting1.sortcode?x" TabIndex="410"></cc1:hwTextBox>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <cc1:hwTextBox runat="server" ID="txtDenom1" CssClass="form-control input-md" Tag="sorting1.description" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                        </div>
                                                    </div>
                                                </cc1:hwPanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <!-- Classificazione 2-->
                                                <cc1:hwPanel GroupingText="Classificazione 2" CssClass="gbox stdfieldset form-group" ID="gboxclass2" runat="server" Tag="AutoManage.txtCodice2.treeclassmovimenti">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <cc1:hwButton runat="server" ID="btnCodice2" Tag="manage.sorting2.tree" TabIndex="400" Text="Codice"></cc1:hwButton>
                                                            <cc1:hwTextBox runat="server" ID="txtCodice2" CssClass="form-control input-md" Tag="sorting2.sortcode?x" TabIndex="410"></cc1:hwTextBox>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <cc1:hwTextBox runat="server" ID="txtDenom2" CssClass="form-control input-md" Tag="sorting2.description" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                        </div>
                                                    </div>
                                                </cc1:hwPanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <!-- Classificazione 3-->
                                        <cc1:hwPanel GroupingText="Classificazione 3" CssClass="gbox stdfieldset form-group" ID="gboxclass3" runat="server" Tag="AutoManage.txtCodice3.treeclassmovimenti">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <cc1:hwButton runat="server" ID="btnCodice3" Tag="manage.sorting3.tree" TabIndex="400" Text="Codice"></cc1:hwButton>
                                                    <cc1:hwTextBox runat="server" ID="txtCodice3" CssClass="form-control input-md" Tag="sorting3.sortcode?x" TabIndex="410"></cc1:hwTextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <cc1:hwTextBox runat="server" ID="txtDenom3" CssClass="form-control input-md" Tag="sorting3.description" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                                </div>
                                            </div>
                                        </cc1:hwPanel>
                                    </div>
                                </div>
                            </fieldset>
                        </div>

                    </div><!-- chiude sezione Classificazioni Analitiche-->
                          </asp:Panel>

                    <asp:Panel ID="PanelEP" runat="server">
                        <div class="row">
                            <div class="col-md-6">
                                <fieldset>
                                    <legend>E/P</legend>
                                    <!-- Causale-->
                                    <cc1:hwPanel GroupingText="Causale" CssClass="gbox stdfieldset form-group" ID="PaneCausaleEP" runat="server" Tag="AutoManage.txtCodiceCausale.tree.(in_use='S')">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <cc1:hwButton runat="server" ID="BtnCausale" Tag="manage.accmotiveapplied.tree" TabIndex="400" Text="Causale"></cc1:hwButton>
                                                <cc1:hwTextBox runat="server" ID="txtCodiceCausale" CssClass="form-control input-md" Tag="accmotiveapplied.codemotive?itinerationview.codemotive" TabIndex="410"></cc1:hwTextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <cc1:hwTextBox runat="server" ID="txtMotive" CssClass="form-control input-md" Tag="accmotiveapplied.motive" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </cc1:hwPanel>
                                </fieldset>
                            </div>
                        </div>
                    </asp:Panel>
                                <div class="col-md-6">
                                    <!-- colonna vuota-->
                                    </div>
                            </div>


				</div>

<script type="text/javascript">
    function CalcTotAPiedi() {
        var Km;
        var Eu;

        Km = GetObjectFromString("Decimal", $(".c_KmAPiedi").val(), "fixed.5...1");
        Eur = GetObjectFromString("Decimal", $(".c_EurKmAPiedi").val(), "fixed.5...1");

    if (Km == null) Km = new Object();
    if (Eur == null) Eur = new Object();
    if (Km.Obj == null) Km.Obj = 0;
    if (Eur.Obj == null) Eur.Obj = 0;

    var Total = new Object();
    Total.Obj = Km.Obj * Eur.Obj;

    Total.TypeName = "Decimal";

   $(".c_EurTotAPiedi").val(StringValue(Total, "c.2...1"));
}



function CalcTotMezzoProprio() {
    var Km;
    var Eur;

    Km = GetObjectFromString("Decimal", $(".c_KmMezzoProprio").val(), "fixed.5...1");
    Eur = GetObjectFromString("Decimal", $(".c_EurKmMezzoProprio").val(), "fixed.5...1");

    if (Km == null) Km = new Object();
    if (Eur == null) Eur = new Object();
    if (Km.Obj == null) Km.Obj = 0;
    if (Eur.Obj == null) Eur.Obj = 0;

    var Total = new Object();
    Total.Obj = Km.Obj * Eur.Obj;

    Total.TypeName = "Decimal";

    $(".c_EurTotMezzoProprio").val(StringValue(Total, "c.2...1"));
}


</script>

				
<!-- chiude tab-content	-->

</asp:Content>