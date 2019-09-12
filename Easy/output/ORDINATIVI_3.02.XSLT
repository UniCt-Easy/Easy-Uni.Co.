<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
	<xsl:template match="/">
		<html>
			<head>
				<style type="text/css">
BODY
{
	margin-left:	5px;
	margin-right:	5px;
	margin-bottom:	0px;
	margin-top:	0px;
	background-color : #FFFFFF;
	
}
.DATI_TABELLA
{
	BACKGROUND-COLOR: #F7F7F7;
	border: 1px #000000 solid;
	COLOR: midnightblue;
	width: 100%;
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-size : 11px;
	color: #002758;
}
.DATI_TITOLO
{
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-weight: bold;
	font-size : 11px;
	background-color: #002758;
	color:#FFFFFF;
}
.DATI_CHIARI
{
	BACKGROUND-COLOR: #F7F7F7;
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-size : 11px;
	color: #002758;
}
.DATI_SCURI
{
	BACKGROUND-COLOR: #D5DBE2;
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-size : 11px;
	color: #002758;
}
.DATI_CHIARI_BOLD
{
	BACKGROUND-COLOR: #F7F7F7;
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-size : 10px;
	font-weight: bold;
	color: #002758;
}
.DATI_SCURI_BOLD
{
	BACKGROUND-COLOR: #D5DBE2;
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-size : 10px;
	font-weight: bold;
	color: #002758;
}
.DATI_NOMICOLONNE
{
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-weight: bold;
	font-size : 11px;
	background-color: #002758;
	color:#FFFFFF;
}
.DATI_ETICHETTA
{
	font-weight: bold;
	font-family: Tahoma, Verdana, Arial, Helvetica;
	font-size : 11px;
	color: #002758;
}
			</style>
			</head>
			<body>
				<xsl:for-each select="flusso_ordinativi">
					<table border="0" width="100%">
						<xsl:if test="position()=1">
							<!--<xsl:text disable-output-escaping="yes">&lt;tbody&gt;</xsl:text>-->
						</xsl:if>
						<tr>
							<td class="DATI_NOMICOLONNE" colspan="10">FLUSSO ORDINATIVI</td>
						</tr>
						<tr>
							<td class="DATI_CHIARI" width="2%"/>
							<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">codice ABI BT</td>
							<td class="DATI_CHIARI" width="15%">
								<xsl:for-each select="codice_ABI_BT">
									<xsl:apply-templates/>
								</xsl:for-each>
							</td>
							<td class="DATI_CHIARI_BOLD" width="15%">identificativo flusso</td>
							<td class="DATI_CHIARI" width="15%">
								<xsl:for-each select="identificativo_flusso">
									<xsl:apply-templates/>
								</xsl:for-each>
							</td>
							<td class="DATI_CHIARI_BOLD" width="15%">data/ora creazione flusso</td>
							<td class="DATI_CHIARI" width="15%">
								<xsl:for-each select="data_ora_creazione_flusso">
									<xsl:apply-templates select="."/>
								</xsl:for-each>
							</td>
						</tr>
						<tr>
							<td class="DATI_CHIARI"/>
							<td class="DATI_CHIARI_BOLD" colspan="4">codice ente</td>
							<td class="DATI_CHIARI">
								<xsl:for-each select="codice_ente">
									<xsl:apply-templates/>
								</xsl:for-each>
							</td>
							<td class="DATI_CHIARI_BOLD">codice ente BT</td>
							<td class="DATI_CHIARI">
								<xsl:for-each select="codice_ente_BT">
									<xsl:apply-templates/>
								</xsl:for-each>
							</td>
							<td class="DATI_CHIARI_BOLD">esercizio</td>
							<td class="DATI_CHIARI">
								<xsl:for-each select="esercizio">
									<xsl:apply-templates select="."/>
								</xsl:for-each>
							</td>
						</tr>
						<tr>
							<td class="DATI_CHIARI"/>
							<td class="DATI_CHIARI_BOLD" colspan="4">descrizione ente</td>
							<td class="DATI_CHIARI" colspan="1">
								<xsl:for-each select="descrizione_ente">
									<xsl:apply-templates/>
								</xsl:for-each>
							</td>
							<td class="DATI_CHIARI_BOLD" colspan="1">riferimento ente</td>
							<td class="DATI_CHIARI" colspan="3">
								<xsl:for-each select="riferimento_ente">
									<xsl:apply-templates/>
								</xsl:for-each>
							</td>
						</tr>
						<!-- 						<tr>
							<td class = "DATI_CHIARI"></td>
							<td class = "DATI_CHIARI_BOLD" colspan="4">riferimento ente</td>
							<td class = "DATI_CHIARI" colspan="5">
								<xsl:for-each select="riferimento_ente">
									 <xsl:apply-templates/>
								</xsl:for-each>
							</td>
						</tr> -->
						<xsl:if test="position()=last()">
							<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
						</xsl:if>
						<!-- ACQUISIZIONE REVERSALI -->
						<!-- <xsl:for-each select="acquisizione_reversali"> -->
						<xsl:for-each select="reversale">
							<xsl:if test="position()=1">
								<!--<xsl:text disable-output-escaping="yes">&lt;tbody&gt;</xsl:text>-->
							</xsl:if>
							<tr>
								<td class="DATI_NOMICOLONNE" colspan="10">REVERSALE</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI" width="2%"/>
								<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">tipo operazione</td>
								<td class="DATI_CHIARI" colspan="5">
									<xsl:for-each select="tipo_operazione">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<!-- 									
									<td class = "DATI_CHIARI_BOLD" width="15%">data reversale</td>
									<td class = "DATI_CHIARI" width="15%">
										<xsl:for-each select="data_reversale">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class = "DATI_CHIARI_BOLD" width="15%"></td>
									<td class = "DATI_CHIARI" width="15%"></td> 
								-->
							</tr>
							<tr>
								<td class="DATI_CHIARI" width="2%"/>
								<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">numero reversale</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="numero_reversale">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%">data reversale</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="data_reversale">
										<xsl:apply-templates select="."/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%"/>
								<td class="DATI_CHIARI" width="15%"/>
							</tr>
							<!-- inserita visualizzazione numero_conto evidenza 29-09-2008 -->
							<tr>
								<td class="DATI_CHIARI" width="2%"/>
								<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">numero conto evidenza</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="conto_evidenza">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%">importo reversale</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="importo_reversale">
										<xsl:apply-templates select="."/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%"/>
								<td class="DATI_CHIARI" width="15%"/>
							</tr>
							<!-- fine modifica -->
							<xsl:if test="position()=last()">
								<xsl:text disable-output-escaping="yes"/>
							</xsl:if>
							<xsl:for-each select="bilancio">
								<xsl:if test="position()=1">
									<!-- <xsl:text disable-output-escaping="yes"> -->
									<tr>
										<td class="DATI_SCURI_BOLD" colspan="10">Bilancio</td>
									</tr>
									<!-- </xsl:text> -->
								</xsl:if>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">codifica bilancio</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="codifica_bilancio">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">descrizione codifica</td>
									<td class="DATI_CHIARI" colspan="3">
										<xsl:for-each select="descrizione_codifica">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">gestione</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="gestione">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">anno residuo</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="anno_residuo">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">numero articolo</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="numero_articolo">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">voce economica</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="voce_economica">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">importo bilancio</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="importo_bilancio">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD"/>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<xsl:if test="position()=last()">
									<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
								</xsl:if>
							</xsl:for-each>
							<xsl:for-each select="informazioni_versante">
								<xsl:if test="position()=1">
									<!--<xsl:text disable-output-escaping="yes">&lt;tbody&gt;</xsl:text>-->
								</xsl:if>
								<tr>
									<td class="DATI_NOMICOLONNE" colspan="10">VERSANTE</td>
								</tr>
								<tr>
									<td class="DATI_CHIARI" width="2%"/>
									<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">progressivo versante</td>
									<td class="DATI_CHIARI" width="15%">
										<xsl:for-each select="progressivo_versante">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD" width="15%">importo versante</td>
									<td class="DATI_CHIARI" width="15%">
										<xsl:for-each select="importo_versante">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD" width="15%"/>
									<td class="DATI_CHIARI" width="15%"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">tipo riscossione</td>
									<td class="DATI_CHIARI" colspan="5">
										<xsl:for-each select="tipo_riscossione">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<!-- <td class = "DATI_CHIARI"/> -->
								</tr>
								<xsl:for-each select="numero_ccp">
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero ccp</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:apply-templates/>
										</td>
										<!-- <td class = "DATI_CHIARI"/> -->
									</tr>
								</xsl:for-each>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">tipo entrata</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="tipo_entrata">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">destinazione</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="destinazione">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<xsl:for-each select="classificazione">
									<xsl:if test="position()=1">
										<!-- <xsl:text disable-output-escaping="yes"> -->
										<tr>
											<td class="DATI_NOMICOLONNE" colspan="10">Classificazione</td>
										</tr>
										<tr>
											<td class="DATI_CHIARI"/>
											<td class="DATI_CHIARI" colspan="4"/>
											<td class="DATI_CHIARI_BOLD">codice cge</td>
											<td class="DATI_CHIARI_BOLD">importo</td>
											<td class="DATI_CHIARI_BOLD"/>
											<td class="DATI_CHIARI_BOLD"/>
											<td class="DATI_CHIARI"/>
										</tr>
										<!-- </xsl:text> -->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI" colspan="1"/>
										<td class="DATI_CHIARI" colspan="4"/>
										<td class="DATI_CHIARI" colspan="1">
											<xsl:for-each select="codice_cge">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI" colspan="1">
											<xsl:for-each select="importo">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="bilancio">
									<xsl:if test="position()=1">
										<!-- <xsl:text disable-output-escaping="yes"> -->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Bilancio</td>
										</tr>
										<!-- </xsl:text> -->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">codifica bilancio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codifica_bilancio">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">descrizione codifica</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="descrizione_codifica">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">gestione</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="gestione">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">anno residuo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="anno_residuo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero articolo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_articolo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">voce economica</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="voce_economica">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">importo bilancio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="importo_bilancio">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD"/>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes"></xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="bollo">
									<xsl:if test="position()=1">
										<!-- <xsl:text disable-output-escaping="yes"> -->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Bollo</td>
										</tr>
										<!-- </xsl:text> -->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">assoggettamento bollo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="assoggettamento_bollo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">causale esenzione bollo</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="causale_esenzione_bollo">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="versante">
									<xsl:if test="position()=1">
										<!-- <xsl:text disable-output-escaping="yes"> -->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Versante</td>
										</tr>
										<!-- </xsl:text> -->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">anagrafica versante</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="anagrafica_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">indirizzo</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="indirizzo_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">cap</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="cap_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">localita'</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="localita_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">provincia</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="provincia_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">stato</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="stato_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">partita IVA</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="partita_iva_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">codice fiscale</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codice_fiscale_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="causale">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Causale</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI" colspan="9">
											<!-- <xsl:for-each select="causale">-->
											<xsl:apply-templates/>
											<!-- </xsl:for-each> -->
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="sospeso">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Sospeso</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero provvisorio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_provvisorio">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">importo provvisorio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="importo_provvisorio">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="mandato_associato">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Mandato associato</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero mandato</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_mandato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">progressivo beneficiario</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="progressivo_beneficiario">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="informazioni_aggiuntive">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Informazioni aggiuntive</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">lingua</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="lingua">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<!--
									<tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">note</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="note">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">riferimento documento esterno</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="riferimento_documento_esterno">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="sostituzione_reversale">
									<xsl:if test="position()=1">
										<!-- <xsl:text disable-output-escaping="yes"> -->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Sostituzione reversale</td>
										</tr>
										<!-- </xsl:text> -->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero reversale da sostituire</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_reversale_da_sostituire">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">progressivo versante da sostituire</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="progressivo_versante_da_sostituire">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">esercizio reversale da sostituire</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="esercizio_reversale_da_sostituire">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="dati_a_disposizione_ente_versante">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Dati a disposizione ente versante</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<!-- <tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">lingua</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="lingua">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">note</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="note">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<!--
									<tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">riferimento documento esterno</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="riferimento_documento_esterno">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
							</xsl:for-each>
							<xsl:for-each select="dati_a_disposizione_ente_reversale">
								<xsl:if test="position()=1">
									<!--<xsl:text disable-output-escaping="yes">-->
									<tr>
										<td class="DATI_SCURI_BOLD" colspan="10">Dati a disposizione ente reversale</td>
									</tr>
									<!--</xsl:text>-->
								</xsl:if>
								<!-- <tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">lingua</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="lingua">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">struttura</td>
									<td class="DATI_CHIARI" colspan="5">
													<xsl:for-each select="struttura">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<!--
									<tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">riferimento documento esterno</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="riferimento_documento_esterno">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
								<xsl:if test="position()=last()">
									<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
								</xsl:if>
							</xsl:for-each>
						</xsl:for-each>
						<!-- </xsl:for-each> -->
						<!-- ACQUISIZIONE MANDATI -->
						<!-- <xsl:for-each select="acquisizione_mandati"> -->
						<xsl:for-each select="mandato">
							<xsl:if test="position()=1">
								<!--<xsl:text disable-output-escaping="yes">&lt;tbody&gt;</xsl:text>-->
							</xsl:if>
							<tr>
								<td class="DATI_NOMICOLONNE" colspan="10">MANDATO</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI" width="2%"/>
								<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">tipo operazione</td>
								<td class="DATI_CHIARI" colspan="5">
									<xsl:for-each select="tipo_operazione">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<!-- 									<td class = "DATI_CHIARI_BOLD" width="15%">data reversale</td>
									<td class = "DATI_CHIARI" width="15%">
										<xsl:for-each select="data_reversale">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class = "DATI_CHIARI_BOLD" width="15%"></td>
									<td class = "DATI_CHIARI" width="15%"></td> -->
							</tr>
							<tr>
								<td class="DATI_CHIARI" width="2%"/>
								<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">numero mandato</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="numero_mandato">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%">data mandato</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="data_mandato">
										<xsl:apply-templates select="."/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%"/>
								<td class="DATI_CHIARI" width="15%"/>
							</tr>
							<!-- inserita visualizzazione numero_conto evidenza 29-09-2008 -->
							<tr>
								<td class="DATI_CHIARI" width="2%"/>
								<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">numero conto evidenza</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="conto_evidenza">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%">importo mandato</td>
								<td class="DATI_CHIARI" width="15%">
									<xsl:for-each select="importo_mandato">
										<xsl:apply-templates select="."/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD" width="15%"/>
								<td class="DATI_CHIARI" width="15%"/>
							</tr>
							<!-- fine modifica -->
							<xsl:if test="position()=last()">
								<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
							</xsl:if>
							<xsl:if test="position()=1">
								<!--<xsl:text disable-output-escaping="yes">&lt;tbody&gt;</xsl:text>-->
							</xsl:if>
							<tr>
								<td class="DATI_CHIARI"/>
								<td class="DATI_CHIARI_BOLD" colspan="4">estremi provvedimento autorizzativo</td>
								<td class="DATI_CHIARI" colspan="5">
									<xsl:for-each select="estremi_provvedimento_autorizzativo">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI"/>
								<td class="DATI_CHIARI_BOLD" colspan="4">responsabile provvedimento</td>
								<td class="DATI_CHIARI" colspan="3">
									<xsl:for-each select="responsabile_provvedimento">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
								<td class="DATI_CHIARI_BOLD">ufficio responsabile</td>
								<td class="DATI_CHIARI">
									<xsl:for-each select="ufficio_responsabile">
										<xsl:apply-templates/>
									</xsl:for-each>
								</td>
							</tr>
							<xsl:if test="position()=last()">
								<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
							</xsl:if>
							<xsl:for-each select="bilancio">
								<xsl:if test="position()=1">
									<!--<xsl:text disable-output-escaping="yes">-->
									<tr>
										<td class="DATI_SCURI_BOLD" colspan="10">Bilancio</td>
									</tr>
									<!--</xsl:text>-->
								</xsl:if>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">codifica bilancio</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="codifica_bilancio">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">descrizione codifica</td>
									<td class="DATI_CHIARI" colspan="3">
										<xsl:for-each select="descrizione_codifica">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">gestione</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="gestione">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">anno residuo</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="anno_residuo">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">numero articolo</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="numero_articolo">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">voce economica</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="voce_economica">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">importo bilancio</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="importo_bilancio">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD"/>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<xsl:if test="position()=last()">
									<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
								</xsl:if>
							</xsl:for-each>
							<xsl:for-each select="funzionario_delegato">
								<xsl:if test="position()=1">
									<!--<xsl:text disable-output-escaping="yes">-->
									<tr>
										<td class="DATI_SCURI_BOLD" colspan="10">Funzionario delegato</td>
									</tr>
									<!--</xsl:text>-->
								</xsl:if>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">codice funzionario delegato</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="codice_funzionario_delegato">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">importo funzionario delegato</td>
									<td class="DATI_CHIARI" colspan="3">
										<xsl:for-each select="importo_funzionario_delegato">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">tipologia pagamento funzionario delegato</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="tipologia_pagamento_funzionario_delegato">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">numero pagamento funzionario delegato</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="numero_pagamento_funzionario_delegato">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<xsl:if test="position()=last()">
									<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
								</xsl:if>
							</xsl:for-each>
							<xsl:for-each select="informazioni_beneficiario">
								<xsl:if test="position()=1">
									<!--<xsl:text disable-output-escaping="yes">&lt;tbody&gt;</xsl:text>-->
								</xsl:if>
								<tr>
									<td class="DATI_NOMICOLONNE" colspan="10">BENEFICIARIO</td>
								</tr>
								<tr>
									<td class="DATI_CHIARI" width="2%"/>
									<td class="DATI_CHIARI_BOLD" width="23%" colspan="4">progressivo beneficiario</td>
									<td class="DATI_CHIARI" width="15%">
										<xsl:for-each select="progressivo_beneficiario">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD" width="15%">importo beneficiario</td>
									<td class="DATI_CHIARI" width="15%">
										<xsl:for-each select="importo_beneficiario">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD" width="15%"/>
									<td class="DATI_CHIARI" width="15%"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">tipo pagamento</td>
									<td class="DATI_CHIARI" colspan="4">
										<xsl:for-each select="tipo_pagamento">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">impignorabili</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="impignorabili">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">frazionabile</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="frazionabile">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">gestione provvisoria</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="gestione_provvisoria">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">data esecuzione pagamento</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="data_esecuzione_pagamento">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">data scadenza pagamento</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="data_scadenza_pagamento">
											<xsl:apply-templates select="."/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI"/>
								</tr>
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">destinazione</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="destinazione">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">numero conto Banca d'Italia ente ricevente</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="numero_conto_banca_italia_ente_ricevente">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
									<td class="DATI_CHIARI_BOLD">tipo contabilita ente ricevente</td>
									<td class="DATI_CHIARI">
										<xsl:for-each select="tipo_contabilita_ente_ricevente">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<xsl:for-each select="classificazione">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Classificazione</td>
										</tr>
										<tr>
											<td class="DATI_CHIARI"/>
											<td class="DATI_CHIARI" colspan="4"/>
											<td class="DATI_CHIARI_BOLD">codice cgu</td>
											<td class="DATI_CHIARI_BOLD">codice cup</td>
											<td class="DATI_CHIARI_BOLD">codice cpv</td>
											<td class="DATI_CHIARI_BOLD">importo</td>
											<td class="DATI_CHIARI"/>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI" colspan="1"/>
										<td class="DATI_CHIARI" colspan="4"/>
										<td class="DATI_CHIARI" colspan="1">
											<xsl:for-each select="codice_cgu">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI" colspan="1">
											<xsl:for-each select="codice_cup">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI" colspan="1">
											<xsl:for-each select="codice_cpv">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI" colspan="1">
											<xsl:for-each select="importo">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="bilancio">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Bilancio</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">codifica bilancio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codifica_bilancio">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">descrizione codifica</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="descrizione_codifica">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">gestione</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="gestione">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">anno residuo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="anno_residuo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero articolo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_articolo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">voce economica</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="voce_economica">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">importo bilancio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="importo_bilancio">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD"/>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="bollo">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Bollo</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">assoggettamento bollo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="assoggettamento_bollo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">causale esenzione bollo</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="causale_esenzione_bollo">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="spese">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Spese</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">soggetto destinatario delle spese</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="soggetto_destinatario_delle_spese">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">natura pagamento</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="natura_pagamento">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">causale esenzione spese</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="causale_esenzione_spese">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="beneficiario">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Beneficiario</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">anagrafica beneficiario</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="anagrafica_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">indirizzo</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="indirizzo_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">cap</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="cap_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">localita'</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="localita_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">provincia</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="provincia_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">stato</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="stato_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">partita IVA</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="partita_iva_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">codice fiscale</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codice_fiscale_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="delegato">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Delegato</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">anagrafica delegato</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="anagrafica_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">indirizzo delegato</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="indirizzo_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">cap delegato</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="cap_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">localita' delegato</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="localita_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">provincia delegato</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="provincia_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">stato delegato</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="stato_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">codice fiscale delegato</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codice_fiscale_delegato">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD"/>
										<!--
											<td class = "DATI_CHIARI">
												<xsl:for-each select="">
													<xsl:apply-templates/>
												</xsl:for-each>
											</td> -->
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
										</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="creditore_effettivo">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Creditore effettivo</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">anagrafica creditore effettivo</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="anagrafica_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">indirizzo creditore effettivo</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="indirizzo_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">cap creditore effettivo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="cap_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">localita' creditore effettivo</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="localita_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">provincia creditore effettivo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="provincia_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">stato creditore effettivo</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="stato_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">partita IVA creditore effettivo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="partita_iva_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">codice fiscale creditore effettivo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codice_fiscale_creditore_effettivo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="piazzatura">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Piazzatura</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr class="DATI_SCURI">
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">codice paese</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codice_paese">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">codice cin</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="codice_cin">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">caratteri di controllo</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="caratteri_controllo">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">ABI</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="abi_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">CAB</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="cab_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">numero conto corrente beneficiario</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_conto_corrente_beneficiario">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">descrizione banca</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="denominazione_banca_destinataria">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="sepa_credit_transfer">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Sepa credit transfer</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">iban</td>
										<td class="DATI_CHIARI" colspan="3">
											<xsl:for-each select="iban">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">bic</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="bic">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">identificativo end to end</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="identificativo_end_to_end">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="codice_versante">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Codice versamento</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI" colspan="9">
											<!-- <xsl:for-each select="codice_versante">-->
											<xsl:apply-templates/>
											<!-- </xsl:for-each> -->
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="causale">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Causale</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI" colspan="9">
											<!-- <xsl:for-each select="causale">-->
											<xsl:apply-templates/>
											<!-- </xsl:for-each> -->
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="sospeso">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Sospeso</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero provvisorio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_provvisorio">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">importo provvisorio</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="importo_provvisorio">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI"/>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="ritenute">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Ritenute</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">importo ritenute</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="importo_ritenute">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">numero reversale</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_reversale">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">progressivo versante</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="progressivo_versante">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="informazioni_aggiuntive">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Informazioni aggiuntive</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">lingua</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="lingua">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<!--
									<tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">note</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="note">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">riferimento documento esterno</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="riferimento_documento_esterno">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="sostituzione_mandato">
									<xsl:if test="position()=1">
										<!-- <xsl:text disable-output-escaping="yes"> -->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Sostituzione mandato</td>
										</tr>
										<!-- </xsl:text> -->
									</xsl:if>
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">numero mandato da sostituire</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="numero_mandato_da_sostituire">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">progressivo beneficiario da sostituire</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="progressivo_beneficiario_da_sostituire">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
										<td class="DATI_CHIARI_BOLD">esercizio mandato da sostituire</td>
										<td class="DATI_CHIARI">
											<xsl:for-each select="esercizio_mandato_da_sostituire">
												<xsl:apply-templates select="."/>
											</xsl:for-each>
										</td>
									</tr>
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="dati_a_disposizione_ente_beneficiario">
									<xsl:if test="position()=1">
										<!--<xsl:text disable-output-escaping="yes">-->
										<tr>
											<td class="DATI_SCURI_BOLD" colspan="10">Dati a disposizione ente beneficiario</td>
										</tr>
										<!--</xsl:text>-->
									</xsl:if>
									<!-- <tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">lingua</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="lingua">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
									<tr>
										<td class="DATI_CHIARI"/>
										<td class="DATI_CHIARI_BOLD" colspan="4">note</td>
										<td class="DATI_CHIARI" colspan="5">
											<xsl:for-each select="note">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<!--
									<tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">riferimento documento esterno</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="riferimento_documento_esterno">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
									<xsl:if test="position()=last()">
										<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
									</xsl:if>
								</xsl:for-each>
							</xsl:for-each>
							<xsl:for-each select="dati_a_disposizione_ente_mandato">
								<xsl:if test="position()=1">
									<!--<xsl:text disable-output-escaping="yes">-->
									<tr>
										<td class="DATI_SCURI_BOLD" colspan="10">Dati a disposizione ente mandato</td>
									</tr>
									<!--</xsl:text>-->
								</xsl:if>
								<!-- <tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">lingua</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="lingua">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
								<tr>
									<td class="DATI_CHIARI"/>
									<td class="DATI_CHIARI_BOLD" colspan="4">struttura</td>
									<td class="DATI_CHIARI" colspan="5">
										<xsl:for-each select="struttura">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</tr>
								<!--
									<tr>
										<td class = "DATI_CHIARI"/>
										<td class = "DATI_CHIARI_BOLD" colspan="4">riferimento documento esterno</td>
										<td class = "DATI_CHIARI" colspan="5">
											<xsl:for-each select="riferimento_documento_esterno">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									-->
								<xsl:if test="position()=last()">
									<!-- <xsl:text disable-output-escaping="yes">&lt;/tbody&gt;</xsl:text> -->
								</xsl:if>
							</xsl:for-each>
						</xsl:for-each>
						<!-- </xsl:for-each> -->
						<!-- Distinta totali -->
						<xsl:if test="position()=last()">
							<tr>
								<td class="DATI_NOMICOLONNE" colspan="10">TOTALI DISTINTA</td>
							</tr>
							<tr>
								<td class="DATI_SCURI_BOLD" colspan="10">Totale reversali di incasso</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI" colspan="6"/>
								<td class="DATI_CHIARI_BOLD">numero reversali</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="conta_reversali"/>
								</td>
								<td class="DATI_CHIARI_BOLD">totale reversali</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="somma_importo_reversali"/>
								</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI" colspan="6"/>
								<td class="DATI_CHIARI_BOLD">numero versanti</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="conta_versanti"/>
								</td>
								<td class="DATI_CHIARI_BOLD">totale versanti</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="somma_importo_versanti"/>
									<!-- </xsl:call-template> -->
								</td>
							</tr>
							<tr>
								<td class="DATI_SCURI_BOLD" colspan="10">Totale mandati di pagamento</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI" colspan="6"/>
								<td class="DATI_CHIARI_BOLD">numero mandati</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="conta_mandati"/>
								</td>
								<td class="DATI_CHIARI_BOLD">totale mandati</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="somma_importo_mandati"/>
								</td>
							</tr>
							<tr>
								<td class="DATI_CHIARI" colspan="6"/>
								<td class="DATI_CHIARI_BOLD">numero beneficiari</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="conta_beneficiari"/>
								</td>
								<td class="DATI_CHIARI_BOLD">totale beneficiari</td>
								<td class="DATI_CHIARI">
									<xsl:call-template name="somma_importo_beneficiari"/>
									<!-- </xsl:call-template> -->
								</td>
							</tr>
							<tr>
								<td class="DATI_NOMICOLONNE" colspan="10">FINE FLUSSO ORDINATIVI</td>
							</tr>
						</xsl:if>
					</table>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
	<!-- definizione tipo decimali -->
	<xsl:decimal-format name="euro" decimal-separator="," grouping-separator="." infinity="infinito"/>
	<!--
  minus-sign = "-" 
  NaN = "NaN" 
  percent = "%" 
  per-mille = "M" 
  zero-digit = "0" 
  digit = "#" 
  pattern-separator = ";"/> 
-->
	<!-- Template -->
	<!-- Importi -->
	<!-- Flusso -->
	<xsl:template match="data_ora_creazione_flusso">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4),' - ',
	substring(.,12,8))"/>
	</xsl:template>
	<!-- Bilancio -->
	<xsl:template match="importo_bilancio">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<!--
<xsl:template match="importo_bilancio_beneficiario">
<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
</xsl:template>
-->
	<!-- Classificazione -->
	<xsl:template match="importo">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<!--
<xsl:template match="importo_cpv">
<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
</xsl:template>

<xsl:template match="importo_cup">
<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
</xsl:template>

<xsl:template match="importo_cge">
<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
</xsl:template>
-->
	<!-- Reversale -->
	<xsl:template match="importo_reversale">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template match="importo_versante">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<!-- Mandato -->
	<xsl:template match="importo_mandato">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template match="importo_beneficiario">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template match="importo_funzionario_delegato">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template match="importo_ritenute_reversale">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template match="importo_ritenute_provvisorio">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<!-- Sospesi -->
	<xsl:template match="importo_provvisorio">
		<xsl:value-of select="format-number(.,'#.##0,00','euro')"/>
	</xsl:template>
	<!-- dati distinta per AOVV -->
	<xsl:template name="somma_importo_reversali">
		<!-- <xsl:value-of select="sum(//importo_reversale)"/> -->
		<xsl:value-of select="format-number(sum(//importo_reversale),'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template name="conta_reversali">
		<xsl:value-of select="count(//importo_reversale)"/>
	</xsl:template>
	<xsl:template name="somma_importo_versanti">
		<xsl:value-of select="format-number(sum(//importo_versante),'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template name="conta_versanti">
		<xsl:value-of select="count(//importo_versante)"/>
	</xsl:template>
	<xsl:template name="somma_importo_mandati">
		<xsl:value-of select="format-number(sum(//importo_mandato),'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template name="conta_mandati">
		<xsl:value-of select="count(//importo_mandato)"/>
	</xsl:template>
	<xsl:template name="somma_importo_beneficiari">
		<xsl:value-of select="format-number(sum(//importo_beneficiario),'#.##0,00','euro')"/>
	</xsl:template>
	<xsl:template name="conta_beneficiari">
		<xsl:value-of select="count(//importo_beneficiario)"/>
	</xsl:template>
	<!-- *** -->
	<!-- Date -->
	<!-- Reversale -->
	<xsl:template match="data_reversale">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<xsl:template match="data_nascita_versante">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<!-- Mandato -->
	<xsl:template match="data_mandato">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<xsl:template match="data_esecuzione_pagamento">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<xsl:template match="data_scadenza_pagamento">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<xsl:template match="data_nascita_beneficiario">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<xsl:template match="data_nascita_delegato">
		<xsl:value-of select="concat(
	substring(.,9,2),'/',
	substring(.,6,2),'/',
	substring(.,1,4))"/>
	</xsl:template>
	<!-- *** -->
	<!--
							<xsl:template match="data_ora_creazione_flusso">
							<xsl:choose>
							<xsl:when test="position()=1">
								<td class = "DATI_CHIARI_BOLD" width="15%">data/ora creazione flusso</td>
								<td class = "DATI_CHIARI" width="15%">
									
									<xsl:value-of select="."/>
									

								</td>
							</xsl:when>
							<xsl:otherwise>
								<td class = "DATI_CHIARI_BOLD" width="15%">non c'e'niente</td>
								<td class = "DATI_CHIARI" width="15%"></td>
							</xsl:otherwise>
							</xsl:choose>
							</xsl:template>
-->
	<!-- inserire select="." nell' apply-templates -->
	<!--
<xsl:template match="provvedimento">
<xsl:value-of select="translate(.,'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ')"/>
</xsl:template>
-->
	<!-- override buil-in taemplates - by benny -->
	<xsl:template match="text()|@*">
		<xsl:value-of select="translate(.,'abcdefghijklmnopqrstuvwxyz','ABCDEFGHIJKLMNOPQRSTUVWXYZ')"/>
	</xsl:template>
</xsl:stylesheet>
