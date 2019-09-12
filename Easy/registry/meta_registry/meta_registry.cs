/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Collections;
using q= metadatalibrary.MetaExpression;

namespace meta_registry
{
	/// <summary>
	/// </summary>
	public class Meta_registry : Meta_easydata
	{
		public Meta_registry(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "registry") {
			EditTypes.Add("anagrafica");
			EditTypes.Add("history");
			ListingTypes.Add("default");
			ListingTypes.Add("anagrafica");
			ListingTypes.Add("lista");
			//----------------------segreterie-------------------------------------------- begin
			EditTypes.Add("default");
			EditTypes.Add("aziende");
			ListingTypes.Add("aziende");
			EditTypes.Add("istituti");
			ListingTypes.Add("istituti");
			EditTypes.Add("istitutiesteri");
			ListingTypes.Add("istitutiesteri");
			EditTypes.Add("studenti");
			ListingTypes.Add("studenti");
			EditTypes.Add("docenti");
			ListingTypes.Add("docenti");
			//----------------------segreterie-------------------------------------------- end
			EditTypes.Add("instmuser");
            ListingTypes.Add("instmuser");
            //$EditTypes$

		}

		protected override Form GetForm(string FormName) {
			if (FormName == "anagrafica" || FormName == "history") {
				Name = "Anagrafica";
				DefaultListType = "anagrafica";
				return GetFormByDllName("registry_anagrafica");
			}

			return null;
		}

		override public void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T, "active", "S");
			if (editType != "anagrafica" && editType != "history") SetDefault(T, "residence", 1);
			SetDefault(T, "authorization_free", "N");
			SetDefault(T, "multi_cf", "N");
			SetDefault(T, "flagbankitaliaproceeds", "N");
			SetDefault(T, "flag_pa", "N");
			SetDefault(T, "sdi_norifamm", "N");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idreg"], null, null, 12);
			RowChange.setMinimumTempValue(T.Columns["idreg"], 9990000);
			return base.Get_New_Row(ParentRow, T);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if ((ListingType == "anagrafica") || (ListingType == "default") || (ListingType == "lista"))
				return base.SelectOne(ListingType, filter, "registrymainview", ToMerge);

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

		private DataRow getIndirizzoAttuale(DataRow[] indirizzi) {
			DateTime oggi = System.DateTime.Now.Date;
			foreach (DataRow r in indirizzi) {
				DateTime inizio = (DateTime) r["start"];
				bool infinito = r["stop"] is DBNull;
				if ((inizio <= oggi) && (infinito || (oggi <= (DateTime)r["stop"]))) {
					return r;
				}
			}

			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			//----------------------segreterie-------------------------------------------- begin
			var extension = (R.Table.Columns.Contains("extension") && R["extension"] != null) ?  R["extension"].ToString().Trim():"";
			switch (extension) {
				case "": {
						//----------------------segreterie-------------------------------------------- end

						if (edit_type == "anagrafica") {
							DataColumn C = R.Table.Columns["title"];
							HelpForm.SetDenyNull(C, false);
						}


						if (R["idregistryclass"].ToString() == "") {
							errmess = "Attenzione! Selezionare la Tipologia.";
							errfield = "idregistryclass";
							return false;
						}

						if (edit_type == "anagrafica" || R["active"].ToString().ToUpper() == "S") {

							if (R["idregistryclass"].ToString().ToUpper() == "OO") {
								errmess = "Attenzione! La tipologia non dovrebbe MAI essere 'altro'.";
								errfield = "idregistryclass";
								return false;

							}

						    DataRow rowTipo = null;
						    if (R.Table.DataSet.Relations.Contains("registryclassregistry")) {
						        rowTipo = R.GetParentRow("registryclassregistry");
						    }
						    else {
						        rowTipo = Conn.readFromTable("registryclass", q.eq("idregistryclass", R["idregistryclass"]), "*")?.Rows[0];
						    }
							
							if (rowTipo["active"].ToString().ToUpper() == "N" && R["active"].ToString().ToUpper() == "S") {
								errfield = "idregistryclass";
								errmess = "E' stata selezionata una tipologia non attiva";
								return false;
							}

							if (rowTipo["flaghuman"].ToString().ToUpper() == "S" && R["active"].ToString().ToUpper() == "S") {
								if (R["surname"].ToString().Trim() == "") {
									errmess = "Attenzione! Per le persone fisiche il campo 'Cognome' è obbligatorio";
									errfield = "surname";
									return false;
								}

								if (R["forename"].ToString().Trim() == "") {
									errmess = "Attenzione! Per le persone fisiche il campo 'Nome' è obbligatorio";
									errfield = "forename";
									return false;
								}

								if (R["birthdate"] != DBNull.Value) {
									if (((DateTime)R["birthdate"]).CompareTo(DateTime.Today) > 0) {
										errmess = "Attenzione! Non può essere immessa una data di nascita futura";
										errfield = "birthdate";
										return false;
									}
								}

								if (R["gender"].ToString() == "") {
									errmess = "Attenzione! Per le persone fisiche è necessario inserire il sesso";
									errfield = "gender";
									return false;
								}
							}

							
							string messaggio = "";
							string caption = (R.RowState == DataRowState.Added) ? "Errore" : "Warning";

							if (R["title"].ToString().Trim() == "") {
								errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
								errfield = "title";

								messaggio = "Attenzione! Il campo 'Denominazione' è obbligatorio";
								return false;

							}

							if (((!CheckNOTNULL(R, "cf", rowTipo, "flagcf_forced")) &&
								 (!CheckNOTNULL(R, "foreigncf", rowTipo, "flagcf_forced")))
								&& R["active"].ToString().ToUpper() == "S") {
								errmess = "Attenzione! E' obbligatorio compilare il Codice fiscale o il C.F.estero";
								errfield = "cf";
								return false;
							}

							if ((!CheckNOTNULL(R, "p_iva", rowTipo, "flagp_iva_forced"))
								&& R["active"].ToString().ToUpper() == "S") {
								errmess = "Attenzione! Il campo 'Partita IVA' è obbligatorio";
								errfield = "p_iva";
								return false;
							}

							string partitaIva = R["p_iva"].ToString();
							if (partitaIva != "" && R["active"].ToString().ToUpper() == "S") {
								string errorePIVA = CalcolaPartitaIva.controllaPartitaIva(partitaIva);
								if (errorePIVA != null) {
									errmess = "Attenzione! La Partita IVA inserita non è valida\n" + errorePIVA;
									errfield = "p_iva";
									return false;
								}
							}

							if ((!CheckNOTNULL(R, "idtitle", rowTipo, "flagqualification_forced"))
								&& R["active"].ToString().ToUpper() == "S") {
								errmess = "Attenzione! Il campo 'Titolo' è obbligatorio";
								errfield = "idtitle";

								messaggio = "Attenzione! Il campo 'Titolo' è obbligatorio";

								return false;

							}

							if ((!CheckNOTNULL(R, "extmatricula", rowTipo, "flagextmatricula_forced"))
								&& R["active"].ToString().ToUpper() == "S") {
								errmess = "Attenzione! Il campo 'Matricola ext.' è obbligatorio. Procedo ugualmente?";
								errfield = "extmatricula";


								messaggio = "Attenzione! Il campo 'Matricola ext.' è obbligatorio. Procedo ugualmente?";

								return false;

							}

							if ((!CheckNOTNULL(R, "badgecode", rowTipo, "flagbadgecode_forced"))
								&& R["active"].ToString().ToUpper() == "S") {
								errmess = "Attenzione! Il campo 'Badge' è obbligatorio. Procedo ugualmente?";
								errfield = "badgecode";


								messaggio = "Attenzione! Il campo 'Badge' è obbligatorio. Procedo ugualmente?";


								return false;

							}

							if ((!CheckNOTNULL(R, "idmaritalstatus", rowTipo, "flagmaritalstatus_forced"))
								&& R["active"].ToString().ToUpper() == "S"
							) {
								errmess = "Attenzione! Il campo 'Stato civile' è obbligatorio";
								errfield = "idmaritalstatus";

								messaggio = "Attenzione! Il campo 'Stato civile' è obbligatorio";


								return false;

							}

							if ((!CheckNOTNULL(R, "foreigncf", rowTipo, "flagforeigncf_forced"))
								&& R["active"].ToString().ToUpper() == "S"
							) {
								errmess = "Attenzione! Il campo 'Codice Fiscale Estero' è obbligatorio. Procedo ugualmente?";
								errfield = "foreigncf";


								messaggio = "Attenzione! Il campo 'Codice Fiscale Estero' è obbligatorio. Procedo ugualmente?";


								return false;

							}

							if ((!CheckNOTNULL(R, "maritalsurname", rowTipo, "flagmaritalsurname_forced"))
								&& R["active"].ToString().ToUpper() == "S"
							) {
								errmess = "Attenzione! Il campo 'Cognome acquisito' è obbligatorio";
								errfield = "maritalsurname";

								messaggio = "Attenzione! Il campo 'Cognome acquisito' è obbligatorio";

								return false;

							}

							object stand = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");
							object domfi = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
							if (R["active"].ToString().ToUpper() == "S" &&
								rowTipo["flagresidence"].ToString() == "S" &&
								rowTipo["flagresidence_forced"].ToString() == "S") {
								DataTable TBIndirizzo = R.Table.DataSet.Tables["registryaddress"];
								DataRow[] rResidenze = TBIndirizzo.Select(QHC.CmpEq("idaddresskind", stand));
								DataRow residenza = getIndirizzoAttuale(rResidenze);
								if (residenza == null) {
									object predefinito = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"),
							"description");


									errmess = $"Attenzione! Non è stato inserito l\'indirizzo di residenza ({predefinito}) valido per la data odierna.";
									errfield = "idaddresskind";
									return false;
									/*
									messaggio =
										$"Attenzione! Non è stato inserito l\'indirizzo di residenza ({predefinito}) valido per la data odierna.";

									drConferma = MessageBox.Show(LinkedForm, messaggio, caption, mb);
									if ((InsertMode) || (drConferma == DialogResult.No)) {
										return false;
									}*/
								}
							}

							if (R["active"].ToString().ToUpper() == "S" &&
								rowTipo["flagfiscalresidence"].ToString() == "S" &&
								rowTipo["flagfiscalresidence_forced"].ToString() == "S") {
								DataTable TBIndirizzo = R.Table.DataSet.Tables["registryaddress"];
								string filtro = QHC.FieldIn("idaddresskind", new object[] {domfi, stand});
								if (TBIndirizzo.Select(filtro).Length == 0) {
									errmess = "Attenzione! Non è stato inserito il domicilio fiscale per l'anagrafica.";
									errfield = "idaddresskind";
									messaggio = "Attenzione! Non è stato inserito il domicilio fiscale per l'anagrafica.";
									return false;

								}
							}


							DateTime dataContabile = (DateTime) GetSys("datacontabile");
						    if (R.Table.DataSet.Relations.Contains("registryregistryrole")) {
						        DataRow[] rowsPosRuolo = R.GetChildRows("registryregistryrole");
						        string tipologia = R["idregistryclass"].ToString();
						        foreach (DataRow rowPosRuolo in rowsPosRuolo) {
						            bool controlloDataInizio = true;
						            bool controlloDataFine = true;
						            if (!(rowPosRuolo["start"] is DBNull)) {
						                DateTime dataInizio = (DateTime) rowPosRuolo["start"];
						                controlloDataInizio = dataContabile.CompareTo(dataInizio) >= 0;
						            }

						            if (!(rowPosRuolo["stop"] is DBNull)) {
						                DateTime dataFine = (DateTime) rowPosRuolo["stop"];
						                controlloDataFine = dataContabile.CompareTo(dataFine) <= 0;
						            }

						            if (controlloDataInizio && controlloDataFine) {

						                DataRow rowRuolo = rowPosRuolo.GetParentRow("roleregistryrole");
						                //figli orfani? (succede se non ci sono regole)
						                if (rowRuolo == null) continue;
						                if (tipologia != rowRuolo["idregistryclass"].ToString()) {
						                    errmess = "E' stato inserito un ruolo non compatibile" +
						                              " con la tipologia classificazione";
						                    errfield = "idregistryclass";
						                    return false;
						                }
						            }
						        }
						    }


						    bool CFobbligatorio = ValoreCampoTrue(rowTipo, "flagcf_forced");
							//se sono arrivato qui vuol dire che o il CF è <> "" oppure non è obbligatorio
							if (R["cf"].ToString() != "" && R["active"].ToString().ToUpper() == "S") {
								//se CF <> ""
								if (ValoreCampoTrue(rowTipo, "flaghuman")) {
									//e personafisica = S effettuo controllo su validità
									string errori;
									if (!CalcolaCodiceFiscale.CodiceFiscaleValido(Conn, R, out errori)) {

										errmess = "Il Codice Fiscale non è valido!\n" + errori;
										errfield = "cf";
										return false;

									}
								} else {
									//effettuo controllo solo su codice controllo
									string codiceinserito = R["cf"].ToString().ToUpper();
									if (codiceinserito.Length == 16) {
										bool valido = false;
										char codicecontrollo =
                                CalcolaCodiceFiscale.GetLastChar(
									codiceinserito.Substring(0, 15), out valido);
										if (!valido || codiceinserito[15] != codicecontrollo) {

											errmess = "Il Codice Fiscale non è valido";
											errfield = "cf";
											return false;

										}
									}
								}

								//DataRow[] rModPagamento = R.GetChildRows("registryregistrypaymethod");
								//bool modPagStandInserita = false;
								//foreach (DataRow r in rModPagamento) {
								//	if (r["flagstandard"].ToString() == "S") {
								//		modPagStandInserita = true;
								//	}
								//}

								//if (!modPagStandInserita) {

								//	errmess = "La modalità di pagamento predefinita non è stata inserita.";
								//	errfield = "flagstandard";
								//	return false;
								//}
							}


							//controllo validità comune di nascita rispetto alla data di nascita
							//				if (R["birthdate"].ToString()!="" && R["idcity"].ToString()!="") {
							//					if (!IdGeoValido(R,"geo_comune_alias","idcomune")) {
							//						errmess="Attenzione! Il comune selezionato non è valido in relazione alla data nascita.";
							//						errfield="idcity";
							//						return false;
							//					}
							//				}
							//controllo validità stato di nascita rispetto alla data di nascita
							//				if (R["birthdate"].ToString()!="" && R["idnation"].ToString()!="") {
							//					if (!IdGeoValido(R,"geo_nazione_alias","idstatoestero")) {
							//						errmess="Attenzione! Lo stato selezionato non è valido in relazione alla data nascita.";
							//						errfield="idnation";
							//						return false;
							//					}
							//				}
							if (R["cf"].ToString().Trim() != "") {
								R["cf"] = R["cf"].ToString().ToUpper();
							} else {
								R["cf"] = DBNull.Value;
							}



							return true;
						} //Fine listing type anagrafica

						//----------------------segreterie-------------------------------------------- begin

						break;
					}

				case "aziende": {
						if (R.Table.Columns.Contains("active") && R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R.Table.Columns.Contains("annotation") && R["annotation"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotazioni' può essere al massimo di 400 caratteri";
							errfield = "annotation";
							return false;
						}
						if (R.Table.Columns.Contains("ccp") && R["ccp"].ToString().Trim().Length > 12) {
							errmess = "Attenzione! Il campo 'Conto corrente postale di Riscossione' può essere al massimo di 12 caratteri";
							errfield = "ccp";
							return false;
						}
						if (R.Table.Columns.Contains("cf") && R["cf"].ToString().Trim().Length > 16) {
							errmess = "Attenzione! Il campo 'Codice fiscale' può essere al massimo di 16 caratteri";
							errfield = "cf";
							return false;
						}
						if (R.Table.Columns.Contains("foreigncf") && R["foreigncf"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Codice fiscale estero' può essere al massimo di 40 caratteri";
							errfield = "foreigncf";
							return false;
						}
						if (R.Table.Columns.Contains("idcategory") && R["idcategory"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'ID Categoria (tabella category)' può essere al massimo di 2 caratteri";
							errfield = "idcategory";
							return false;
						}
						if (R.Table.Columns.Contains("idcentralizedcategory") && R["idcentralizedcategory"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)' può essere al massimo di 20 caratteri";
							errfield = "idcentralizedcategory";
							return false;
						}
						if (R.Table.Columns.Contains("idreg") && R["idreg"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id anagrafica (tabella registry)' è obbligatorio";
							errfield = "idreg";
							return false;
						}
						if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'ID Tipologie classificazione (tabella registryclass)' può essere al massimo di 2 caratteri";
							errfield = "idregistryclass";
							return false;
						}
						if (R.Table.Columns.Contains("ipa_fe") && R["ipa_fe"].ToString().Trim().Length > 7) {
							errmess = "Attenzione! Il campo 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.' può essere al massimo di 7 caratteri";
							errfield = "ipa_fe";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ubicazione' può essere al massimo di 50 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("p_iva") && R["p_iva"].ToString().Trim().Length > 15) {
							errmess = "Attenzione! Il campo 'Partita iva' può essere al massimo di 15 caratteri";
							errfield = "p_iva";
							return false;
						}
						if (R.Table.Columns.Contains("residence") && R["residence"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipo residenza (chiave di tabella residence)' è obbligatorio";
							errfield = "residence";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 100 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "docenti": {
						if (R.Table.Columns.Contains("active") && R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R.Table.Columns.Contains("annotation") && R["annotation"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotazioni' può essere al massimo di 400 caratteri";
							errfield = "annotation";
							return false;
						}
						if (R.Table.Columns.Contains("badgecode") && R["badgecode"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Codice badge' può essere al massimo di 20 caratteri";
							errfield = "badgecode";
							return false;
						}
						if (R.Table.Columns.Contains("birthdate") && R["birthdate"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Data di nascita' è obbligatorio";
							errfield = "birthdate";
							return false;
						}
						if (R.Table.Columns.Contains("cf") && R["cf"].ToString().Trim().Length > 16) {
							errmess = "Attenzione! Il campo 'Codice fiscale' può essere al massimo di 16 caratteri";
							errfield = "cf";
							return false;
						}
						if (R.Table.Columns.Contains("extmatricula") && R["extmatricula"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Matricola' può essere al massimo di 40 caratteri";
							errfield = "extmatricula";
							return false;
						}
						if (R.Table.Columns.Contains("foreigncf") && R["foreigncf"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Codice fiscale estero' può essere al massimo di 40 caratteri";
							errfield = "foreigncf";
							return false;
						}
						if (R.Table.Columns.Contains("forename") && R["forename"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Nome' è obbligatorio";
							errfield = "forename";
							return false;
						}
						if (R.Table.Columns.Contains("forename") && R["forename"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Nome' può essere al massimo di 50 caratteri";
							errfield = "forename";
							return false;
						}
						if (R.Table.Columns.Contains("gender") && R["gender"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Sesso (M/F)' è obbligatorio";
							errfield = "gender";
							return false;
						}
						if (R.Table.Columns.Contains("idcity") && R["idcity"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Comune di nascita' è obbligatorio";
							errfield = "idcity";
							return false;
						}
						if (R.Table.Columns.Contains("idmaritalstatus") && R["idmaritalstatus"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Stato civile' può essere al massimo di 20 caratteri";
							errfield = "idmaritalstatus";
							return false;
						}
						if (R.Table.Columns.Contains("idnation") && R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Nazionalità' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R.Table.Columns.Contains("idreg") && R["idreg"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idreg";
							return false;
						}
						if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'Tipologia fiscale' può essere al massimo di 2 caratteri";
							errfield = "idregistryclass";
							return false;
						}
						if (R.Table.Columns.Contains("idtitle") && R["idtitle"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Titolo' può essere al massimo di 20 caratteri";
							errfield = "idtitle";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ubicazione' può essere al massimo di 50 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("maritalsurname") && R["maritalsurname"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Cognome acquisito' può essere al massimo di 50 caratteri";
							errfield = "maritalsurname";
							return false;
						}
						if (R.Table.Columns.Contains("p_iva") && R["p_iva"].ToString().Trim().Length > 15) {
							errmess = "Attenzione! Il campo 'Partita iva' può essere al massimo di 15 caratteri";
							errfield = "p_iva";
							return false;
						}
						if (R.Table.Columns.Contains("residence") && R["residence"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Residenza' è obbligatorio";
							errfield = "residence";
							return false;
						}
						if (R.Table.Columns.Contains("surname") && R["surname"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Cognome' è obbligatorio";
							errfield = "surname";
							return false;
						}
						if (R.Table.Columns.Contains("surname") && R["surname"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Cognome' può essere al massimo di 50 caratteri";
							errfield = "surname";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 100 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "istituti": {
						if (R.Table.Columns.Contains("active") && R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R.Table.Columns.Contains("annotation") && R["annotation"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotazioni' può essere al massimo di 400 caratteri";
							errfield = "annotation";
							return false;
						}
						if (R.Table.Columns.Contains("ccp") && R["ccp"].ToString().Trim().Length > 12) {
							errmess = "Attenzione! Il campo 'Conto corrente postale di Riscossione' può essere al massimo di 12 caratteri";
							errfield = "ccp";
							return false;
						}
						if (R.Table.Columns.Contains("cf") && R["cf"].ToString().Trim().Length > 16) {
							errmess = "Attenzione! Il campo 'Codice fiscale' può essere al massimo di 16 caratteri";
							errfield = "cf";
							return false;
						}
						if (R.Table.Columns.Contains("foreigncf") && R["foreigncf"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Codice fiscale estero' può essere al massimo di 40 caratteri";
							errfield = "foreigncf";
							return false;
						}
						if (R.Table.Columns.Contains("idcategory") && R["idcategory"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'ID Categoria (tabella category)' può essere al massimo di 2 caratteri";
							errfield = "idcategory";
							return false;
						}
						if (R.Table.Columns.Contains("idcentralizedcategory") && R["idcentralizedcategory"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)' può essere al massimo di 20 caratteri";
							errfield = "idcentralizedcategory";
							return false;
						}
						if (R.Table.Columns.Contains("idreg") && R["idreg"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id anagrafica (tabella registry)' è obbligatorio";
							errfield = "idreg";
							return false;
						}
						if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'ID Tipologie classificazione (tabella registryclass)' può essere al massimo di 2 caratteri";
							errfield = "idregistryclass";
							return false;
						}
						if (R.Table.Columns.Contains("ipa_fe") && R["ipa_fe"].ToString().Trim().Length > 7) {
							errmess = "Attenzione! Il campo 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.' può essere al massimo di 7 caratteri";
							errfield = "ipa_fe";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ubicazione' può essere al massimo di 50 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("p_iva") && R["p_iva"].ToString().Trim().Length > 15) {
							errmess = "Attenzione! Il campo 'Partita iva' può essere al massimo di 15 caratteri";
							errfield = "p_iva";
							return false;
						}
						if (R.Table.Columns.Contains("residence") && R["residence"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipo residenza (chiave di tabella residence)' è obbligatorio";
							errfield = "residence";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 100 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "istitutiesteri": {
						if (R.Table.Columns.Contains("active") && R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R.Table.Columns.Contains("annotation") && R["annotation"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotazioni' può essere al massimo di 400 caratteri";
							errfield = "annotation";
							return false;
						}
						if (R.Table.Columns.Contains("ccp") && R["ccp"].ToString().Trim().Length > 12) {
							errmess = "Attenzione! Il campo 'Conto corrente postale di Riscossione' può essere al massimo di 12 caratteri";
							errfield = "ccp";
							return false;
						}
						if (R.Table.Columns.Contains("cf") && R["cf"].ToString().Trim().Length > 16) {
							errmess = "Attenzione! Il campo 'Codice fiscale' può essere al massimo di 16 caratteri";
							errfield = "cf";
							return false;
						}
						if (R.Table.Columns.Contains("foreigncf") && R["foreigncf"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Codice fiscale estero' può essere al massimo di 40 caratteri";
							errfield = "foreigncf";
							return false;
						}
						if (R.Table.Columns.Contains("idcategory") && R["idcategory"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'ID Categoria (tabella category)' può essere al massimo di 2 caratteri";
							errfield = "idcategory";
							return false;
						}
						if (R.Table.Columns.Contains("idcentralizedcategory") && R["idcentralizedcategory"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)' può essere al massimo di 20 caratteri";
							errfield = "idcentralizedcategory";
							return false;
						}
						if (R.Table.Columns.Contains("idreg") && R["idreg"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'id anagrafica (tabella registry)' è obbligatorio";
							errfield = "idreg";
							return false;
						}
						if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'ID Tipologie classificazione (tabella registryclass)' può essere al massimo di 2 caratteri";
							errfield = "idregistryclass";
							return false;
						}
						if (R.Table.Columns.Contains("ipa_fe") && R["ipa_fe"].ToString().Trim().Length > 7) {
							errmess = "Attenzione! Il campo 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.' può essere al massimo di 7 caratteri";
							errfield = "ipa_fe";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ubicazione' può essere al massimo di 50 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("p_iva") && R["p_iva"].ToString().Trim().Length > 15) {
							errmess = "Attenzione! Il campo 'Partita iva' può essere al massimo di 15 caratteri";
							errfield = "p_iva";
							return false;
						}
						if (R.Table.Columns.Contains("residence") && R["residence"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipo residenza (chiave di tabella residence)' è obbligatorio";
							errfield = "residence";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 100 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "studenti": {
						if (R.Table.Columns.Contains("active") && R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R.Table.Columns.Contains("annotation") && R["annotation"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotazioni' può essere al massimo di 400 caratteri";
							errfield = "annotation";
							return false;
						}
						if (R.Table.Columns.Contains("badgecode") && R["badgecode"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Codice badge' può essere al massimo di 20 caratteri";
							errfield = "badgecode";
							return false;
						}
						if (R.Table.Columns.Contains("birthdate") && R["birthdate"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Data di nascita' è obbligatorio";
							errfield = "birthdate";
							return false;
						}
						if (R.Table.Columns.Contains("cf") && R["cf"].ToString().Trim().Length > 16) {
							errmess = "Attenzione! Il campo 'Codice fiscale' può essere al massimo di 16 caratteri";
							errfield = "cf";
							return false;
						}
						if (R.Table.Columns.Contains("extmatricula") && R["extmatricula"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Matricola' può essere al massimo di 40 caratteri";
							errfield = "extmatricula";
							return false;
						}
						if (R.Table.Columns.Contains("foreigncf") && R["foreigncf"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Codice fiscale estero' può essere al massimo di 40 caratteri";
							errfield = "foreigncf";
							return false;
						}
						if (R.Table.Columns.Contains("forename") && R["forename"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Nome' è obbligatorio";
							errfield = "forename";
							return false;
						}
						if (R.Table.Columns.Contains("forename") && R["forename"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Nome' può essere al massimo di 50 caratteri";
							errfield = "forename";
							return false;
						}
						if (R.Table.Columns.Contains("gender") && R["gender"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Sesso (M/F)' è obbligatorio";
							errfield = "gender";
							return false;
						}
						if (R.Table.Columns.Contains("idcity") && R["idcity"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Comune di nascita' è obbligatorio";
							errfield = "idcity";
							return false;
						}
						if (R.Table.Columns.Contains("idmaritalstatus") && R["idmaritalstatus"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Stato civile' può essere al massimo di 20 caratteri";
							errfield = "idmaritalstatus";
							return false;
						}
						if (R.Table.Columns.Contains("idnation") && R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Nazionalità' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R.Table.Columns.Contains("idreg") && R["idreg"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idreg";
							return false;
						}
						if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'Tipologia fiscale' può essere al massimo di 2 caratteri";
							errfield = "idregistryclass";
							return false;
						}
						if (R.Table.Columns.Contains("idtitle") && R["idtitle"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Titolo' può essere al massimo di 20 caratteri";
							errfield = "idtitle";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ubicazione' può essere al massimo di 50 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("maritalsurname") && R["maritalsurname"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Cognome acquisito' può essere al massimo di 50 caratteri";
							errfield = "maritalsurname";
							return false;
						}
						if (R.Table.Columns.Contains("p_iva") && R["p_iva"].ToString().Trim().Length > 15) {
							errmess = "Attenzione! Il campo 'Partita iva' può essere al massimo di 15 caratteri";
							errfield = "p_iva";
							return false;
						}
						if (R.Table.Columns.Contains("residence") && R["residence"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Residenza' è obbligatorio";
							errfield = "residence";
							return false;
						}
						if (R.Table.Columns.Contains("surname") && R["surname"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Cognome' è obbligatorio";
							errfield = "surname";
							return false;
						}
						if (R.Table.Columns.Contains("surname") && R["surname"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Cognome' può essere al massimo di 50 caratteri";
							errfield = "surname";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 100 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
			}
			//----------------------segreterie-------------------------------------------- end

			return true;
		}


		//----------------------segreterie-------------------------------------------- begin
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "!idregistryclass_registryclass_description", "Tipologia", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
				case "aziende": {
						DescribeAColumn(T, "!idregistryclass_registryclass_description", "Tipologia", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
				case "docenti": {
						DescribeAColumn(T, "idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
				case "istituti": {
						DescribeAColumn(T, "!idregistryclass_registryclass_description", "Tipologia", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
				case "istitutiesteri": {
						DescribeAColumn(T, "!idregistryclass_registryclass_description", "Tipologia", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
				case "studenti": {
						DescribeAColumn(T, "idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
					//----------------------segreterie-------------------------------------------- end
				case "instmuser": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						break;
					}
					//$DescribeAColumn$

			}
		}

		private bool IdGeoValido(DataRow Rcurrent, string table, string field) {
			try {
				DataRow Rgeo = Rcurrent.GetParentRow(table + "registry");
				if (Rgeo == null) return true;
				string idgeo = Rcurrent[field].ToString();
				DateTime datanascita = GetDateTime(Rcurrent["birthdate"].ToString(), true);
				DateTime datainizio = GetDateTime(Rgeo["start"].ToString(), true);
				DateTime datafine = GetDateTime(Rgeo["stop"].ToString(), false);
				if ((DateTime.Compare(datainizio, datanascita) <= 0) &&
					(DateTime.Compare(datanascita, datafine) <= 0))
					return true;
				return false;
			} catch (Exception E) {
				QueryCreator.MarkEvent("Metodo: Meta_registry.IdGeoValido() - Errore: " + E.Message);
				return true;
			}
		}

		private DateTime GetDateTime(string data, bool min) {
			try {
				return DateTime.Parse(data);
			} catch {
				if (min) return DateTime.MinValue;
				return DateTime.MaxValue;
			}
		}

		/// <summary>
		/// Se il campo di creditoredebitore non è valorizzato e
		/// il campo ha flagobbligatorio a S, restituisce false, altrimenti true
		/// </summary>
		/// <param name="Rprimary">Riga di creditoredebitore</param>
		/// <param name="field_primary">campo della tabella creditoredebitore</param>
		/// <param name="Rparent">Riga di cdtipologiaclassificazione</param>
		/// <param name="field_parent">campo "obbligatorio" della tabella cdtipologiaclassificazione</param>
		private bool CheckNOTNULL(DataRow Rprimary, string field_primary,
			DataRow Rparent, string field_parent) {

			if (Rprimary[field_primary].ToString() == "" &&
				ValoreCampoTrue(Rparent, field_parent)) {
				return false;
			}

			return true;
		}

		private bool ValoreCampoTrue(DataRow R, string field) {
			return (R[field].ToString().ToUpper() == "S");
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
					//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}



	}
}
