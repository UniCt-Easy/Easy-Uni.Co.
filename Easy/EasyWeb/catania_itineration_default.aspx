﻿<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="catania_itineration_default.aspx.cs" Inherits="catania_itineration_default" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">

	<ul id="mainTabControl" class="nav nav-tabs nav-justified">
	</ul>
	<div class="row">
		<div class="col-lg-10 offset-lg-1 col-xl-8 offset-xl-2">

			<asp:Panel ID="PanelGenerale" runat="server">

				<div class="row rowContBlue">
					<div class="col-md-5">
						<fieldset class="scheduler-border smart-tab">
							<legend class="scheduler-border smart-tab">Missione</legend>
							<div class="row">
								<div class="col-md-12">
									<div class="col-md-4">
										<cc1:hwLabel CssClass="control-label" AssociatedControlID="txtEsercmissione" runat="server" for="txtEsercmissione">Esercizio</cc1:hwLabel>
									</div>
									<div class="col-md-8">
										<cc1:hwTextBox CssClass="input-md form-control" runat="server" ID="txtEsercmissione" Tag="itineration.yitineration.year" TabIndex="10"></cc1:hwTextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-12">
									<div class="col-md-4">
										<cc1:hwLabel CssClass="control-label" runat="server" for="txtNummissione">Numero</cc1:hwLabel>
									</div>
									<div class="col-md-8">
										<cc1:hwTextBox CssClass="input-md form-control" ID="txtNummissione" runat="server" Tag="itineration.nitineration" TabIndex="20"></cc1:hwTextBox>
									</div>
								</div>
							</div>
						</fieldset>
					</div>
					<div class="col-md-7">
						<fieldset class="scheduler-border smart-tab">
							<legend class="scheduler-border smart-tab">Stato</legend>
							<div class="row">
								<div class="col-md-3">
									<label for="cmbStatus">Stato</label>
								</div>
								<div class="col-md-9">
									<cc1:hwDropDownList ID="cmbStatus" CssClass="form-control" Tag="itineration.iditinerationstatus?itinerationview.iditinerationstatus" runat="server" AutoPostBack="True" TabIndex="30"></cc1:hwDropDownList>
								</div>
							</div>
							<div class="row">
								<div class="col-md-3">
									<cc1:hwButton ID="idStampaMissione" runat="server" Tag="StampaMissione" class="btn btn-primary" Text="Stampa"></cc1:hwButton>
								</div>
								<div class="col-md-5">
									<cc1:hwButton runat="server" ID="btnStatus" Tag="StatusClick" Text="Invia Richiesta" class="btn btn-primary" TabIndex="-1"></cc1:hwButton>
								</div>
								<div class="col-md-4">
									<cc1:hwButton runat="server" ID="btnAnnullaMissione" Tag="AnnullaMissione" Text="Annulla" class="btn btn-primary" TabIndex="-1"></cc1:hwButton>
								</div>
							</div>
						</fieldset>
					</div>
				</div>

				<div class="row rowContBlue">
					<fieldset class="scheduler-border  smart-tab">
						<legend class="scheduler-border  smart-tab">Dati identificativi della Missione</legend>
						<div class="row">
							<div class="col-md-12">
								<div class="rowContBlue">
									<fieldset class="scheduler-border smart-tab">
										<legend class="scheduler-border smart-tab">Richiedente</legend>
										<div class="control-group">
											<cc1:hwPanel ID="grpIncaricato" runat="server" Tag="AutoChoose.txtIncaricato.default.((active = 'S') AND (idreg IN(SELECT idreg FROM registrylegalstatus)) )">
												<div class="row">
													<div class="col-md-12">
														<cc1:hwTextBox ID="txtIncaricato" runat="server" CssClass="gbox form-control input-md" TabIndex="40" Tag="registry.title?itinerationview.registry"></cc1:hwTextBox>
													</div>
												</div>
											</cc1:hwPanel>
										</div>
									</fieldset>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-6">
								<div class="row">
									<div class="col-md-4">
										<cc1:hwLabel CssClass="control-label" runat="server" for="txtLocation">Destinazione</cc1:hwLabel>
									</div>
									<div class="col-md-8">
										<cc1:hwTextBox runat="server" CssClass="form-control" ID="txtLocation" Tag="itineration.location" TabIndex="50"></cc1:hwTextBox>
									</div>
								</div>
							</div>
							<div class="col-md-6">
								<div class="row">
									<div class="col-md-3">
										<cc1:hwLabel CssClass="control-label" runat="server" for="cmbStatoLocalita">Stato</cc1:hwLabel>
									</div>
									<div class="col-md-9">
										<cc1:hwDropDownList ID="cmbStatoLocalita" runat="server" AutoPostBack="true" CssClass="form-control" TabIndex="60" Tag="itineration.idforeigncountry" ToolTip="In caso di missioni in Italia non è necessario specificare nulla"></cc1:hwDropDownList>
									</div>
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<cc1:hwLabel CssClass="control-label" runat="server" for="txtDescrizione">Motivo</cc1:hwLabel>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtDescrizione" Tag="itineration.description" TabIndex="70" TextMode="MultiLine" ToolTip="Specificare la descrizione della missione e le date del congresso, riunione o corso qualora diverse da quelle della missione. Specificare se la missione tocca più destinazioni oltre la principale"></cc1:hwTextBox>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<div class="rowContBlue">
									<fieldset class="scheduler-border smart-tab">
										<legend class="scheduler-border smart-tab">Date della Missione</legend>
										<div class="row">
											<div class="col-md-3">
												<label for="txtDataInizioOrario">Data inizio:</label>
											</div>
											<div class="col-md-3">
												<div class="it-datepicker-wrapper theme-dark">
													<cc1:hwTextBox runat="server" ID="txtDataInizioOrario" CssClass="form-control it-date-datepicker" Tag="itineration.starttime.d" TabIndex="80"></cc1:hwTextBox>
												</div>
											</div>
											<div class="col-md-3">
												<label for="txtDataFineOrario">Data fine:</label>
											</div>
											<div class="col-md-3">
												<div class="it-datepicker-wrapper theme-dark">
													<cc1:hwTextBox runat="server" ID="txtDataFineOrario" CssClass="form-control it-date-datepicker" Tag="itineration.stoptime.d" TabIndex="90"></cc1:hwTextBox>
												</div>
											</div>
										</div>
										<div class="row">
											<div class="col-md-1">
												<asp:Label ID="Label1" runat="server">Ora</asp:Label>
											</div>
											<div class="col-md-2">
												<cc1:hwTextBox ID="txtOraInizio" CssClass="input-md form-control " runat="server"></cc1:hwTextBox>
											</div>
											<div class="col-md-1">
												<cc1:hwLabel CssClass="control-label" runat="server" for="txtMinutiInizio">Minuti</cc1:hwLabel>
											</div>
											<div class="col-md-2">
												<cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtMinutiInizio" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
											</div>
											<div class="col-md-1">
												<asp:Label ID="Label2" runat="server">Ora</asp:Label>
											</div>
											<div class="col-md-2">
												<cc1:hwTextBox ID="txtOraFine" CssClass="input-md form-control " runat="server"></cc1:hwTextBox>
											</div>
											<div class="col-md-1">
												<cc1:hwLabel CssClass="control-label" runat="server" for="txtMinutiFine">Minuti</cc1:hwLabel>
											</div>
											<div class="col-md-2">
												<cc1:hwTextBox runat="server" CssClass="input-md form-control" ID="txtMinutiFine" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
											</div>
										</div>
									</fieldset>
								</div>
							</div>
						</div>
					</fieldset>
				</div>

				<div class="row">
					<div class="col-12">
						<asp:Panel ID="divAutorizzazioneAutovettura" runat="server">
							<div class="rowContBlue">
								<fieldset class="scheduler-border smart-tab">
									<legend class="scheduler-border smart-tab">Autorizzazione mezzo straordinario</legend>
									<div class="row">
										<div class="col-md-6">
											<cc1:hwLabel CssClass="control-label" runat="server">Autorizzazione mezzo straordinario</cc1:hwLabel>
										</div>
										<div class="col-md-3">
											<cc1:hwRadioButton runat="server" TabIndex="140" ToEnable="true" EnableViewState="true" AutoPostBack="true" Text="No" ID="HwRdbAutorAutoNo" OnCheckedChanged="rdb_CheckedChangedAutorAutoNo" Tag="" />
										</div>
										<div class="col-md-3">
											<cc1:hwRadioButton runat="server" TabIndex="150" ToEnable="true" EnableViewState="true" AutoPostBack="true" Text="Si" ID="HwRdbAutorAutoSi" OnCheckedChanged="rdb_CheckedChangedAutorAutoSi" Tag="" />
										</div>
									</div>
									<div class="row">
										<div class="col-md-12">
											<asp:Panel ID="Panel_Mezzoproprio" runat="server">
												<fieldset class="scheduler-border smart-tab">
													<legend class="scheduler-border smart-tab">Auto propria – Taxi – Auto a noleggio – Car sharing</legend>
													<asp:Panel ID="km_panel" runat="server">
														<div class="row">
															<div class="col-md-6">
																<fieldset class="scheduler-border smart-tab">
																	<legend class="scheduler-border smart-tab">Mezzo proprio</legend>
																	<div class="row">
																		<div class="col-md-5">
																			<cc1:hwLabel CssClass="control-label" runat="server" for="txtKmMezzoProprio">Km. percorsi</cc1:hwLabel>
																		</div>
																		<div class="col-md-7">
																			<cc1:hwTextBox runat="server" ID="txtKmMezzoProprio" CssClass="input-md form-control c_KmMezzoProprio" Tag="itineration.owncarkm" TabIndex="320"></cc1:hwTextBox>
																		</div>
																	</div>
																	<div class="row">
																		<div class="col-md-5">
																			<cc1:hwLabel CssClass="control-label" runat="server" for="txtEurKmMezzoProprio">EUR/Km.</cc1:hwLabel>
																		</div>
																		<div class="col-md-7">
																			<cc1:hwTextBox runat="server" ID="txtEurKmMezzoProprio" CssClass="input-md form-control c_EurKmMezzoProprio" Tag="itineration.owncarkmcost.fixed.5...1" TabIndex="330"></cc1:hwTextBox>
																		</div>
																	</div>
																	<div class="row">
																		<div class="col-md-5">
																			<cc1:hwLabel CssClass="control-label" runat="server" for="txtEurTotMezzoProprio">EUR tot.</cc1:hwLabel>
																		</div>
																		<div class="col-md-7">
																			<cc1:hwTextBox runat="server" ID="txtEurTotMezzoProprio" CssClass="input-md form-control c_EurTotMezzoProprio" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
																		</div>
																	</div>
																</fieldset>
															</div>
															<div class="col-md-6">
																<fieldset class="scheduler-border smart-tab">
																	<legend class="scheduler-border smart-tab">A piedi</legend>
																	<div class="row">
																		<div class="col-md-5">
																			<cc1:hwLabel CssClass="control-label" runat="server" for="txtKmAPiedi">Km. percorsi</cc1:hwLabel>
																		</div>
																		<div class="col-md-7">
																			<cc1:hwTextBox runat="server" CssClass="input-md form-control c_KmAPiedi" ID="txtKmAPiedi" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
																		</div>
																	</div>
																	<div class="row">
																		<div class="col-md-5">
																			<cc1:hwLabel CssClass="control-label" runat="server" for="txtEurKmAPiedi">EUR/Km.</cc1:hwLabel>
																		</div>
																		<div class="col-md-7">
																			<cc1:hwTextBox runat="server" CssClass="input-md form-control c_EurKmAPiedi" ID="txtEurKmAPiedi" Tag="itineration.footkmcost.fixed.5...1" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
																		</div>
																	</div>
																	<div class="row">
																		<div class="col-md-5">
																			<cc1:hwLabel CssClass="control-label" runat="server" for="txtEurTotAPiedi">EUR tot.</cc1:hwLabel>
																		</div>
																		<div class="col-md-7">
																			<cc1:hwTextBox runat="server" CssClass="input-md form-control c_EurTotAPiedi" ID="txtEurTotAPiedi" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
																		</div>
																	</div>
																</fieldset>
															</div>
														</div>
														<div class="row">
															<div class="col-md-12">
																<div class="row">
																	<div class="col-md-6">
																	</div>
																	<div class="col-md-3">
																		<cc1:hwLabel CssClass="control-label" runat="server" for="txtformulakm">Formula di EUR tot.</cc1:hwLabel>
																	</div>
																	<div class="col-md-3">
																		<cc1:hwTextBox runat="server" ID="txtformulakm" CssClass="input-md form-control" TabIndex="-1" ReadOnly="true" Text="Km. percorsi * EUR/Km."></cc1:hwTextBox>
																	</div>
																</div>
															</div>
														</div>
													</asp:Panel>

													<asp:Panel ID="PanelClausola" runat="server" data-toggle="tooltip" data-placement="top" >
														<div class="row hid3">
															<div class="col-md-12">
																<cc1:hwLabel CssClass="control-label" runat="server">Clausola di richiesta</cc1:hwLabel>
															</div>
														</div>
														<div class="row">
															<div class="col-md-12">
																<cc1:hwTextBox runat="server" ID="HwTextBox2" CssClass="input-md form-control" TextMode="MultiLine" Rows="6" ReadOnly="true" TabIndex="-1"></cc1:hwTextBox>
															</div>
														</div>
														<div class="row">
															<div class="col-md-12">
																<cc1:hwCheckBox runat="server" ID="HwCheckClause" ThreeState="false" Tag="itineration.clause_accepted:S:N" Text="Accetto la clausola" TabIndex="-1"></cc1:hwCheckBox>
															</div>
														</div>
														<div class="row">
															<div class="col-md-12">
																<cc1:hwLabel CssClass="control-label" runat="server">La clausola va accettata solo in caso di utilizzo di auto propria. In questo caso è obbligatorio inserire la targa</cc1:hwLabel>
															</div>
														</div>
													</asp:Panel>

													<div class="row">
														<div class="col-md-12">
															<cc1:hwLabel CssClass="control-label" runat="server">Motivo</cc1:hwLabel>
														</div>
													</div>
													<div class="row">
														<div class="col-md-12">
															<cc1:hwTextBox runat="server" ID="txtMotivazione" CssClass="input-md form-control" Tag="itineration.vehicle_motive" TextMode="MultiLine" Rows="4" TabIndex="180"></cc1:hwTextBox>
														</div>
													</div>

													<div class="row">
														<div class="col-md-12">
															<cc1:hwLabel CssClass="control-label" runat="server">Targa</cc1:hwLabel>
														</div>
													</div>
													<div class="row">
														<div class="col-md-12">
															<cc1:hwTextBox runat="server" ID="txtinfovehicle" CssClass="input-md form-control" Tag="itineration.vehicle_info" TextMode="SingleLine" TabIndex="190"></cc1:hwTextBox>
														</div>
													</div>

												</fieldset>
											</asp:Panel>
										</div>


									</div>
									<!-- chiude Title Mezzo proprio-->

								</fieldset>
							</div>
						</asp:Panel>
					</div>
				</div>

				<asp:Panel ID="divAutorizzazioneAereo" runat="server">
					<div class="rowContBlue">
						<fieldset class="scheduler-border smart-tab">
							<legend class="scheduler-border smart-tab">Autorizzazione mezzo aereo/nave</legend>
							<div class="row">
								<div class="col-md-4">
									<cc1:hwLabel CssClass="control-label" runat="server">Autorizzazione uso</cc1:hwLabel>
								</div>
								<div class="col-md-2">
									<cc1:hwCheckBox runat="server" ID="chkAereo" ThreeState="false" AutoPostBack="true" Tag="itineration.flagmove:1" TabIndex="-1" Text="Aereo" OnCheckedChanged="chk_CheckedChangedAereo" />
								</div>
								<div class="col-md-2">
									<cc1:hwCheckBox runat="server" ID="chkNave" ThreeState="false" AutoPostBack="true" Tag="itineration.flagmove:2" TabIndex="-1" Text="Nave" OnCheckedChanged="chk_CheckedChangedNave" />
								</div>
								<div class="col-md-4">
									<cc1:hwCheckBox runat="server" ID="chkNessuno" ThreeState="false" AutoPostBack="true" Tag="itineration.flagmove:0" TabIndex="-1" Text="Nessuno" OnCheckedChanged="chk_CheckedChangedNessuno" />
								</div>
							</div>


							<div class="row">
								<asp:Panel ID="PanelTratteAereo" runat="server" Style="width: 100%">
									<div class="row">
										<div class="col-md-2">
											<cc1:hwButton ID="btnInsTratta" runat="server" Text="Inserisci" Tag="insert.default" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
											<cc1:hwButton ID="btnEditTratta" runat="server" Text="Modifica" Tag="edit.default" class="btn btn-info" TabIndex="220"></cc1:hwButton>
											<cc1:hwButton ID="btnDelTratta" runat="server" Text="Elimina" Tag="delete" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
										</div>
										<div class="col-md-10">
											<cc1:hwDataGridWeb ID="gridTratte" Tag="itinerationflights.default.default" runat="server" TabIndex="240" />
										</div>
									</div>
								</asp:Panel>
							</div>

						</fieldset>
					</div>
				</asp:Panel>

				<div class="rowContBlue">
					<fieldset class="scheduler-border smart-tab">
						<legend class="scheduler-border  smart-tab">Tipologia Fondi di copertura</legend>
						<div class="row">
							<div class="col-md-6">
								<cc1:hwLabel CssClass="control-label" runat="server">Missione soggetta a rimborso</cc1:hwLabel>
							</div>
							<div class="col-md-3">
								<cc1:hwRadioButton runat="server" TabIndex="110" ToEnable="true" EnableViewState="true" AutoPostBack="true" OnCheckedChanged="rdb_CheckedChangedSi" Text="Si" ID="HwRdbNoFondiEsterni" Tag="itineration.flagoutside:N" />
							</div>
							<div class="col-md-3">
								<cc1:hwRadioButton runat="server" TabIndex="120" ToEnable="true" EnableViewState="true" AutoPostBack="true" OnCheckedChanged="rdb_CheckedChangedNo" Text="No" ID="HwRdbSiFondiEsterni" Tag="itineration.flagoutside:S" />
							</div>
						</div>
					</fieldset>
				</div>

				<div class="rowContBlue">
					<fieldset class="scheduler-border smart-tab">
						<legend class="scheduler-border smart-tab">Autorizzazioni e Comunicazioni</legend>
						<div class="row">
							<div class="col-md-12">
								<fieldset class="scheduler-border smart-tab">
									<legend class="scheduler-border smart-tab">Modello autorizzativo</legend>
									<div class="row">
										<div class="col-md-12">
											<cc1:hwDropDownList ID="cmbAuthModel" CssClass="form-control"
												Tag="itineration.idauthmodel?itinerationview.idauthmodel" runat="server" AutoPostBack="True" TabIndex="400">
											</cc1:hwDropDownList>
										</div>
									</div>
								</fieldset>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<fieldset class="scheduler-border smart-tab">
									<legend class="scheduler-border smart-tab">Autorizzazioni</legend>
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
					</fieldset>
				</div>

				<asp:Panel ID="divRichiestaAnticipo" runat="server">
					<div class="rowContBlue">
						<fieldset class="scheduler-border smart-tab">
							<legend class="scheduler-border smart-tab">Importo Missione</legend>
							<div class="row">
								<div class="col-md-6">
									<cc1:hwLabel CssClass="control-label" runat="server">Richiesta anticipo</cc1:hwLabel>
								</div>
								<div class="col-md-3">
									<cc1:hwRadioButton runat="server" TabIndex="-1" ToEnable="true" EnableViewState="true" AutoPostBack="true" Text="No" ID="HwRdbAnticipoNo" OnCheckedChanged="rdb_CheckedChangedAnticipoNo" Tag="itineration.advanceapplied:N" />
								</div>
								<div class="col-md-2">
									<cc1:hwRadioButton runat="server" TabIndex="-1" ToEnable="true" EnableViewState="true" AutoPostBack="true" Text="Si" ID="HwRdbAnticipoSi" OnCheckedChanged="rdb_CheckedChangedAnticipoSi" Tag="itineration.advanceapplied:S" />
								</div>
							</div>
							<div class="row">
								<div class="col-md-6 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblImportopresuntoAnticipo">Importo presunto</cc1:hwLabel>
								</div>
								<div class="col-md-6 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtImportopresuntoAnticipo" CssClass="form-control" Tag="itineration.supposedamount" TabIndex="200"></cc1:hwTextBox>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblPercAnticipo" Text="Percentuale anticipo richiesta"></cc1:hwLabel>
								</div>
								<div class="col-md-6 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtPercAnticipo" CssClass="form-control" Tag="itineration.advancepercentage.fixed.4..%.100" TabIndex="210"></cc1:hwTextBox>
								</div>
							</div>
							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblCostoPresuntoViaggio" Text="Costo presunto Viaggio"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtCostoPresuntoViaggio" CssClass="form-control" Tag="itineration.supposedtravel.c" TabIndex="220"></cc1:hwTextBox>
								</div>
								<div class="col-md-3 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblPercAnticipoViaggi" Text="% Anticipo Viaggi"></cc1:hwLabel>
								</div>
								<div class="col-md-3 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtPercAnticipoViaggi" CssClass="form-control" Tag="itineration.advancepercentagetravel.fixed.4..%.100" TabIndex="210"></cc1:hwTextBox>
								</div>
							</div>

							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblCostoPresuntoSoggiorno" Text="Costo presunto Soggiorno"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox CssClass="form-control" runat="server" ID="txtCostoPresuntoSoggiorno" Tag="itineration.supposedliving.c" TabIndex="230"></cc1:hwTextBox>
								</div>

								<div class="col-md-3 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblPercAnticipoAlloggio" Text="% Anticipo Soggiorno"></cc1:hwLabel>
								</div>
								<div class="col-md-3 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtPercAnticipoAlloggio" CssClass="form-control" Tag="itineration.advancepercentageliving.fixed.4..%.100" TabIndex="210"></cc1:hwTextBox>
								</div>
							</div>
							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblNumPasti" Text="N.Pasti(al costo unitario di categoria)"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtNumPasti" CssClass="form-control" Tag="itineration.nfood" TabIndex="240"></cc1:hwTextBox>
								</div>

								<div class="col-md-3 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblPercAnticipoPasti" Text="% Anticipo Pasti"></cc1:hwLabel>
								</div>
								<div class="col-md-3 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtPercAnticipoPasti" CssClass="form-control" Tag="itineration.advancepercentagefood.fixed.4..%.100" TabIndex="210"></cc1:hwTextBox>
								</div>
							</div>
							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblCostoPresuntoPasti" Text="Costo presunto Pasti"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtCostoPresuntoPasti" CssClass="form-control" Tag="itineration.supposedfood.c" TabIndex="250"></cc1:hwTextBox>
								</div>
							</div>
							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblCostoPresuntoCorso" Text="Spese di iscrizione a convegno o corso (non soggette ad anticipo)"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox CssClass="form-control" runat="server" ID="txtCostoPresuntoCorso" Tag="itineration.supposedcourse.c" TabIndex="230"></cc1:hwTextBox>
								</div>
							</div>
							<div class="row">
								<div class="col-md-3 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblPercAnticipoCorso" Text="% Anticipo Iscrizione a convegno o corso"></cc1:hwLabel>
								</div>
								<div class="col-md-3 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtPercAnticipoCorso" CssClass="form-control" Tag="itineration.advancepercentagecourse.fixed.4..%.100" TabIndex="210"></cc1:hwTextBox>
								</div>
							</div>

							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblTotCostoPresunti" Text="Totale Costi presunti"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtTotCostiPresunti" CssClass="form-control" Tag="" TabIndex="-1"></cc1:hwTextBox>
								</div>

								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblTotAnticipoRichiesto" Text="Totale Anticipo richiesto"></cc1:hwLabel>
								</div>
								<div class="col-md-2 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtTotAnticipoRichiesto" CssClass="form-control" Tag="" TabIndex="-1"></cc1:hwTextBox>
								</div>
							</div>

							<div class="row">
								<div class="col-md-4 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblIban" Text="Iban per bonifico anticipo"></cc1:hwLabel>
								</div>

								<div class="col-md-2 col-xs-12">
									<cc1:hwButton runat="server" ID="btnIban" class="btn btn-primary" Text="IBAN" TabIndex="-1" Tag=""></cc1:hwButton>
								</div>
								<div class="col-md-6 col-xs-12">
									<cc1:hwTextBox TabIndex="260" ID="txtIban" CssClass="form-control input-md" Tag="registrypaymethod.iban?x" runat="server"></cc1:hwTextBox>
								</div>


							</div>
							<div class="row">
								<div class="col-md-12 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblIban2" Text="Qualora l'iban non fosse presente tra quelli registrati sarà necessario richiederne l'inserimento al CINECA"></cc1:hwLabel>
								</div>
							</div>
						</fieldset>
					</div>
				</asp:Panel>

				<asp:Panel ID="divCoperturaMissione" runat="server">
					<div class="rowContBlue">
						<fieldset class="scheduler-border smart-tab">
							<legend class="scheduler-border smart-tab">Copertura della missione</legend>
							<div class="row">
								<div class="col-md-6">
									<cc1:hwLabel CssClass="control-label" runat="server">Missione su fondi Propri</cc1:hwLabel>
								</div>
								<div class="col-md-3">
									<cc1:hwRadioButton runat="server" TabIndex="-1" ToEnable="true" EnableViewState="true" AutoPostBack="true" Text="No" ID="RdbMissioneFondiPropriNo" Tag="itineration.flagownfunds:N" OnCheckedChanged="rdb_CheckedChangedFondiPropriNo" />
								</div>
								<div class="col-md-2">
									<cc1:hwRadioButton runat="server" TabIndex="-1" ToEnable="true" EnableViewState="true" AutoPostBack="true" Text="Si" ID="RdbMissioneFondiPropriSi" Tag="itineration.flagownfunds:S" OnCheckedChanged="rdb_CheckedChangedFondiPropriSi" />
								</div>
							</div>
							<div class="row">
								<cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" ID="grpResponsabile" runat="server" Tag="AutoChoose.txtResponsabile.lista.(financeactive='S')" Style="width: 100%">
									<div class="col-md-4 ">
										<cc1:hwButton ID="btnResponsabile" runat="server" Text="Responsabile" class="btn btn-primary" Tag="choose.manager.lista.(financeactive='S')" data-toggle="tooltip" data-placement="top" title="Inserire alcune lettere del cognome per filtrare la ricerca e premere sul bottone Responsabile" />
									</div>
									<div class="col-md-8 ">
										<cc1:hwTextBox TabIndex="300" ID="txtResponsabile" CssClass="form-control input-md" Tag="manager.title?x" runat="server"></cc1:hwTextBox>
									</div>
								</cc1:hwPanel>
							</div>
							<div class="row">
								<div class="col-md-2 col-xs-12">
									<cc1:hwLabel CssClass="control-label" runat="server" ID="lblMotivo">Motivo</cc1:hwLabel>
								</div>
								<div class="col-md-10 col-xs-12">
									<cc1:hwTextBox runat="server" ID="txtMotivo" CssClass="form-control" TabIndex="320" Tag="itineration.applierannotations" TextMode="MultiLine"></cc1:hwTextBox>

								</div>
							</div>
							<div class="row">
								<div class="col-md-12">
									<cc1:hwPanel GroupingText="U.P.B." CssClass="gbox scheduler-border form-group" ID="PanelUpb" runat="server" Tag="AutoChoose.txtCodiceUPB.missioni">
										<div class="col-md-7">
											<div class="row">
												<div class="col-md-12">
													<cc1:hwButton ID="btnUpbDisponibile" runat="server" Text="UPB" class="btn btn-primary" Tag="choose.upbitinerationavailable.default" />
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
							</div>
						</fieldset>
					</div>
				</asp:Panel>

				<asp:Panel ID="PanelPosGiuridica" runat="server">
					<div class="row">
						<div class="panel-group col-md-12" id="div1" role="tablist" aria-multiselectable="true">
							<div class="rowContBlue">
								<div class="btn btn-info btn-block" role="tab" id="tabPosizioneGiuridicaHead">
									<h4 class="panel-title">
										<a role="button" data-toggle="collapse" data-parent="#panelPosizioneGiuridica" href="#tabPosizioneGiuridicaBody" aria-expanded="true" aria-controls="panelPosizioneGiuridica">Posizione giuridica(a cura del sistema)</a>
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
					</div>
				</asp:Panel>
				<div class="row">
					<div class="col-md-12">
						<cc1:hwCheckBox runat="server" ID="chkWeb" ThreeState="false" Tag="itineration.flagweb:S:N" Visible="false" TabIndex="-1" Text="Missione inserita mediante interfaccia web" />
					</div>
				</div>
				<asp:Panel ID="PanelRendicontoSpeseRef" runat="server">
					<div class="row rowContBlue">
						<div class="col-md-12">
							<asp:Panel ID="grpRendicontoSpeseRef" runat="server">
								<fieldset class="scheduler-border smart-tab GroupBoxLabel">
									<legend class="scheduler-border smart-tab">Spese rendicontate su missioni correlate</legend>
									<div class="row">
									</div>
									<div class="row">
										<div class="col-md-12">
											<cc1:hwDataGridWeb runat="server" CssClass="he1" ID="HwDataGridWeb1" Tag="itinerationrefund_ref.refundbalance_ref.refundbalance_ref" TabIndex="-1" />
										</div>
									</div>

								</fieldset>

							</asp:Panel>
						</div>
					</div>
				</asp:Panel>
			</asp:Panel>
			<!-- chiude title-->
			<div class="row">
				<div class="col-12">
					<asp:Panel ID="PanelTappeespese" runat="server">
						<asp:Panel ID="PanelTappe" runat="server">
							<div class="row hid1 rowContBlue">
								<div class="col-md-12">

									<legend class="scheduler-border smart-tab">Tappe</legend>

									<div class="row">
										<div class="col-md-12">
											<cc1:hwButton runat="server" ID="btnInsertTappa" Tag="insert.defaultnew02" TabIndex="-1" class="btn btn-primary" Text="Inserisci"></cc1:hwButton>
											<cc1:hwButton runat="server" ID="btnEditTappa" Tag="edit.defaultnew02" TabIndex="-1" class="btn btn-info" Text="Modifica"></cc1:hwButton>
											<cc1:hwButton runat="server" ID="btnDelTappa" Tag="delete" TabIndex="-1" class="btn btn-danger" Text="Cancella"></cc1:hwButton>
										</div>
									</div>
									<div class="row">
										<div class="col-md-12">
											<cc1:hwDataGridWeb runat="server" ID="dgrTappe" Tag="itinerationlap.default.defaultnew02" />
										</div>
									</div>


								</div>
							</div>
						</asp:Panel>
						<div class="row">
							<div class="col-md-12">
								<asp:Panel ID="grpRendicontoSpese" runat="server">
									<fieldset class="scheduler-border smart-tab GroupBoxLabel sup1 hid2">
										<legend class="scheduler-border smart-tab">Rendiconto Spese</legend>
										<div class="row">
											<div class="col-md-12">
												<cc1:hwTextBox runat="server" ID="HwTextBoxTappespese" CssClass="input-md form-control" Text="" TextMode="MultiLine" Rows="4" ReadOnly="true" TabIndex="-1"></cc1:hwTextBox>
											</div>
										</div>
										<div class="row">
											<div class="col-md-12">
												<cc1:hwButton runat="server" ID="btnInsertSpesaSaldo" Tag="insert.balancenew02" TabIndex="-1" class="btn btn-primary" Text="Inserisci"></cc1:hwButton>
												<cc1:hwButton runat="server" ID="btnEditSpesaSaldo" Tag="edit.balancenew02" TabIndex="-1" class="btn btn-info" Text="Modifica"></cc1:hwButton>
												<cc1:hwButton runat="server" ID="btnDeleteSpesaSaldo" Tag="delete" TabIndex="-1" class="btn btn-danger" Text="Elimina"></cc1:hwButton>
											</div>
										</div>
										<div class="row">
											<div class="col-md-12">
												<cc1:hwDataGridWeb runat="server" CssClass="he1" ID="dgrSpeseSaldo" Tag="itinerationrefund_balance.balance.balance" TabIndex="-1" />
											</div>
										</div>

										<div class="row">
											<div class="col-md-12">
												<cc1:hwLabel CssClass="control-label" runat="server" for="txtsaldorichiesto">Totale Saldo Richiesto</cc1:hwLabel>
											</div>
										</div>
										<div class="row">
											<div class="col-md-7">
												<cc1:hwTextBox runat="server" CssClass="hid2 sup2 input-md form-control" ID="txtsaldorichiesto" Tag="" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
											</div>
										</div>

										<div class="row">
											<div class="col-md-12">
												<cc1:hwLabel CssClass="control-label" runat="server" for="txtsaldoaccordato">Totale Saldo Accordato</cc1:hwLabel>
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


					</asp:Panel>
				</div>
			</div>


			<div class="row rowContBlue">
				<div class="col-12">
					<fieldset class="scheduler-border smart-tab">
						<legend class="scheduler-border smart-tab">Allegati</legend>
						<div class="row">
							<div class="col-md-12">
								<asp:Panel ID="Panel_allegati" runat="server">
									<div class="row ">
										<div class="col-md-2">
											<cc1:hwButton ID="btnInsAtt" runat="server" Tag="insert.defaultnew02" Text="Inserisci" class="btn btn-primary" TabIndex="-1"></cc1:hwButton>
											<cc1:hwButton ID="btnEditAtt" runat="server" Tag="edit.defaultnew02" Text="Modifica" class="btn btn-info" TabIndex="-1"></cc1:hwButton>
											<cc1:hwButton ID="btnDelAtt" runat="server" Tag="delete" Text="Elimina" class="btn btn-danger" TabIndex="-1"></cc1:hwButton>
										</div>
										<div class="col-md-10">
											<cc1:hwDataGridWeb ID="gridAtt" runat="server" Tag="itinerationattachment.default.default" TabIndex="-1" />
										</div>
									</div>
								</asp:Panel>
							</div>
						</div>
					</fieldset>
				</div>
			</div>

			<div class="row">
				<div class="col-12">
					<asp:Panel ID="PanelEP" runat="server">
						<div class="row">
							<div class="col-md-6">
								<fieldset class="scheduler-border smart-tab">
									<legend class="scheduler-border smart-tab">E/P</legend>
									<!-- Causale-->
									<cc1:hwPanel GroupingText="Causale" CssClass="gbox stdfieldset form-group" ID="PaneCausaleEP" runat="server" Tag="AutoManage.txtCodiceCausale.tree.(in_use='S')">
										<div class="row">
											<div class="col-md-6">
												<cc1:hwButton runat="server" ID="BtnCausale" Tag="manage.accmotiveapplied.tree" TabIndex="-1" class="btn btn-primary" Text="Causale"></cc1:hwButton>
												<cc1:hwTextBox runat="server" ID="txtCodiceCausale" CssClass="form-control input-md" Tag="accmotiveapplied.codemotive?itinerationview.codemotive" TabIndex="-1"></cc1:hwTextBox>
											</div>
											<div class="col-md-6">
												<cc1:hwTextBox runat="server" ID="txtMotive" CssClass="form-control input-md" Tag="accmotiveapplied.motive" TextMode="MultiLine" Rows="3" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
											</div>
										</div>
									</cc1:hwPanel>
								</fieldset>
							</div>
							<div class="col-md-6">
								<!-- colonna vuota-->
							</div>

						</div>
					</asp:Panel>
				</div>
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

	<script type="text/javascript" src="js/cookiemgr.js?v=30"></script>
	<script type="text/javascript" src="js/scrollpositionmgr.js?v=30"></script>

	<!-- chiude tab-content	-->

	<style>
		/* ====================================================================================*/
		/*                                TEST - BOOTSTRAP SIZE                                */
		/* ====================================================================================*/
		body::after {
			content: 'XS';
			position: fixed;
			color: white;
			background-color: #000;
			right: 16px;
			bottom: 16px;
			text-align: center;
			z-index: 10000;
			display: block;
			overflow: hidden;
			font-size: 16px;
			font-weight: bold;
			padding: 2px 10px 4px;
		}

		@media (min-width: 576px) {
			body::after {
				content: 'SM'
			}
		}

		@media (min-width: 768px) {
			body::after {
				content: 'MD'
			}
		}

		@media (min-width: 992px) {
			body::after {
				content: 'LG'
			}
		}

		@media (min-width: 1200px) {
			body::after {
				content: 'XL'
			}
		}
		/*@media (min-width: 1400px) { body::after {content: 'XXL'} }*/

		.rowContBlue {
			border: 2px solid #3686ac;
			border-radius: 10px;
			padding: 10px 20px;
			margin: 15px 15px 30px;
		}
	</style>
</asp:Content>
