/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Collections;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using q =  metadatalibrary.MetaExpression;


namespace notable_importazione {


	public partial class FrmNotable_Importazione : Form {


		// Se impostato a true consente l'importazione di fatture con ninv letto dal file
		// se impostato a false crea le fatture con un ninv arbitrario
		bool FlgImportaFatture = false;



		public FrmNotable_Importazione() {
			InitializeComponent();

			txtIntro.Text =
				"Questa procedura consente di importare dati da un'applicazione esterna. E' possibile importare " +
				"informazioni inerenti l'anagrafica, il patrimonio, il bilancio, i movimenti finanziari.\n" +
				"E' necessario procedere prima con l'anagrafica per poter far riferimento ad essa " +
				"nell'importazione del patrimonio o dei movimenti finanziari.";
			txtIntro.Select(0, 0);
		}

		CQueryHelper QHC;
		QueryHelper QHS;
		MetaData Meta;
		DataAccess Conn;

		public delegate bool ImportFun();

		struct ImportButton {
			public Button Btn;
			public ImportFun Fun;
			public string[] tracciato;
			public string tag;

			public ImportButton(Button Btn, ImportFun Fun, string[] tracciato, string tag) {
				this.Btn = Btn;
				this.Fun = Fun;
				this.tracciato = tracciato;
				this.tag = tag;
			}
		}

		ImportButton[] AllButton = null;

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			AllButton = new ImportButton[] {
				new ImportButton(btnAnagrafiche, ImportaAnagrafiche, tracciato_anagrafica, "1"),
				new ImportButton(btnResponsabili, ImportaResponsabili, tracciato_responsabile, "2"),
				new ImportButton(btnIndirizzi, ImportaIndirizzi, tracciato_indirizzi, "1.1"),
				new ImportButton(btnModPagamento, ImportaModPagamento, tracciato_modpag, "1.2"),
				new ImportButton(btnContatti, ImportaContatti, tracciato_contatti, "1.3"),
				new ImportButton(btnClassInv, ImportaClassInv, tracciato_classinventariale, "3"),
				new ImportButton(btnUbicazioni, ImportaUbicazioni, tracciato_ubicazioni, "4"),
				new ImportButton(btnVarPatr, ImportaVarPatr, tracciato_varpatr, "5"),
				new ImportButton(btnBuoniCar, ImportaBuoniCar, tracciato_buonicar, "6"),
				new ImportButton(btnBuoniScar, importaBuoniScarico, tracciato_buoniscar, "7"),
				new ImportButton(btnConsegnatari, ImportaConsegnatari, tracciato_consegnatari, "8"),
				new ImportButton(btnCespiti, ImportaCespiti, tracciato_cespiti, "9"),
				new ImportButton(btnCespitiSorico, ImportaCespitiConStoricoWithoutCheck, tracciato_cespitistorico,
					"10"),
				new ImportButton(btnCespitiCheck, ImportaCespitiConStoricoWithCheck, tracciato_cespitistorico, "35"),
				new ImportButton(btnAmmortamenti, ImportaAmmortamenti, tracciato_ammortamenti, "11"),
				new ImportButton(btnRivalutazioni, ImportaRivalutazioni, tracciato_rivalutazioni, "12"),
				new ImportButton(btnCessati, ImportaCessati, tracciato_cessati, "13"),
				new ImportButton(btnBilancio, ImportaBilancio, tracciato_bilancio, "14"),
				new ImportButton(btnUPB, ImportaUPB, tracciato_upb, "15"),
				new ImportButton(btnPrevBilancio, ImportaPrevisioniBilancio, tracciato_prevbil, "16"),
				new ImportButton(btnAvanzo, ImportaAvanzo, tracciato_avanzo, "17"),
				new ImportButton(btnVarBilancio, ImportaVarBilancio, tracciato_varbil, "18"),
				new ImportButton(btnManReve, ImportaManReve, tracciato_manreve, "19"),
				new ImportButton(btnMovFin, ImportaMovFin, tracciato_movfin, "20"),
				new ImportButton(btnVarMovFin, ImportaVarMovSenzaTrigger, tracciato_varmov, "21"),
				new ImportButton(btnClassificazioni, ImportaClassificazioni, tracciato_classificazioni, "22"),
				new ImportButton(btnClassMovimenti, ImportaClassMovimenti, tracciato_classmov, "23"),
				new ImportButton(btnClassBilancio, ImportaClassBilancio, tracciato_classfin, "24"),
				new ImportButton(btnClassAnagrafiche, ImportaClassAnagrafiche, tracciato_anagrafica, "25"),
				new ImportButton(btnImportaOrdini, ImportaCPassivi, tracciato_cpassivi, "26"),
				new ImportButton(btnImportaFatture, ImportaFatture, tracciato_fatture, "27"),
				new ImportButton(btnCreaFatture, CreaFatture, tracciato_fatture, "28"),
				new ImportButton(btnImportaAliquote, ImportaAliquoteIVA, tracciato_aliquoteiva, "29"),
				new ImportButton(btnClassificazioniIndirette, ImportaClassificazioniIndirette, tracciato_classindirette,
					"30"),
				new ImportButton(btnClassUPB, ImportaClassUPB, tracciato_classupb, "32"),
				new ImportButton(btnEsitazioni, ImportaEsitazioni, tracciato_movban, "33"),
				new ImportButton(btnPartitePendenti, ImportaPartitePendenti, tracciato_partitependenti, "34"),
				new ImportButton(btnPianoConti, ImportaPianoConti, tracciato_pianoconti, "36"),
				new ImportButton(btnImportaClassPianoConti, ImportaClassPianoConti, tracciato_classpianoconti, "37"),
				new ImportButton(btnFinLookup, ImportaConvertiBilancio, tracciato_convertibilancio, "38"),
				new ImportButton(btnVarMovFin, ImportaVarMovConTrigger, tracciato_varmov, "39"),
				new ImportButton(btnImportaContrattiAttivi, ImportaContrattiAttivi, tracciato_cattivi, "40"),
				new ImportButton(btnImportaTipiDocIVA, ImportaTipoDocIva, tracciato_tipodociva, "41"),
				new ImportButton(btnImportaTipiDocIvaAnnuale, ImportaTipoDocIvaAnnuale, tracciato_tipodocivaannuale,
					"42"),
				new ImportButton(btnImportaTipiRegistroIVA, ImportaTipoRegistroIva, tracciato_tiporegistroiva, "43"),
				new ImportButton(btnImportaTipiDocRegistriIVA, ImportaTipoDocIvaRegistroIva,
					tracciato_tipodocivaregistroiva, "44"),
				new ImportButton(btnImportaRegistriIVA, ImportaRegistroIva, tracciato_registroiva, "45"),
				new ImportButton(btnImportaScrittureEP, ImportaScrittureEP, tracciato_scrittureep, "46"),
				new ImportButton(btnImportaConvertiPianoConti, ImportaConvertiPianoConti, tracciato_convertipianoconti,
					"47"),
				new ImportButton(btnListClass, ImportaClassMerc, tracciato_classmerc, "48"),
				new ImportButton(btnListClassYear, ImportaClassMercAnnuale, tracciato_classmercannuale, "49"),
				new ImportButton(btnList, ImportaListino, tracciato_listino, "50"),

				new ImportButton(btnImportaCausali, ImportaCausali, tracciato_causali, "51"),
				new ImportButton(btnImportaAccountvar, ImportaAccountVar, tracciato_accountvar, "52"),
				new ImportButton(btnTipiContrattiCSA, ImportaTipoContrattoCsa, tracciato_tipocontrattocsa, "53"),
				new ImportButton(btnRegoleIndividuazioneCSA, ImportaRegoleTipiContrattoCSA,
					tracciato_regoletipocontrattocsa, "54"),
				new ImportButton(btnContributiTipoContrattoCSA, ImportaContributiTipiContrattoCSA,
					tracciato_contributitipocontrattocsa, "55"),
				new ImportButton(btnContrattiCSA, ImportaContrattiCSA, tracciato_contrattocsa, "56"),
				new ImportButton(btnMatricoleContrattiCSA, ImportaMatricoleContrattiCSA,
					tracciato_matricolecontrattocsa,
					"57"),
				new ImportButton(btnContributiContrattiCSA, ImportaContributiContrattoCSA, tracciato_contributicontrattocsa, "58"),
				new ImportButton(btnRipartContrattiCSA, ImportaRipContrattiCSA, tracciato_ripcontrattocsa, "59"),
				new ImportButton(btnRipartContributiContrattiCSA, ImportaRipContributoContrattiCSA,
					tracciato_ripcontributocontrattocsa, "60"),
				new ImportButton(btnImportaAccmotiveSorting, ImportaClassCausali, tracciato_classcausaliep, "61"),
				new ImportButton(btnAutoClassEntrate, ImportaAutoClassMovimenti_E, tracciato_autoclassmov, "62"),
				new ImportButton(btnAutoClassSpese, ImportaAutoClassMovimenti_S, tracciato_autoclassmov, "63"),
				new ImportButton(btnResponsabiliCespiti, ImportaResponsabiliCespiti, tracciato_responsabilicespiti,
					"64"),
				new ImportButton(btnUbicazioniCespiti, ImportaUbicazioniCespiti, tracciato_ubicazionicespiti, "65"),
				new ImportButton(btnSubConsegnatariCespiti, ImportaSubConsegnatariCespiti,
					tracciato_subconsegnataricespiti, "66"),
				new ImportButton(btnProfiloSISEST, ImportaProfiloSISEST, tracciato_ProfiloSISEST, "67"),
				new ImportButton(btnCausaleSISEST, ImportaCausaleSISEST, tracciato_CausaleSISEST, "68"),
				new ImportButton(btnRipartEPContrattiCSA, ImportaRipImpegniBudgetContrattiCSA,
					tracciato_ripmovbudgetcontrattocsa, "69"),
				new ImportButton(btnRipartEPContributiContrattiCSA, ImportaRipImpegniBudgetContributoContrattiCSA,
					tracciato_ripmovbudgetcontributocontrattocsa, "70"),
				new ImportButton(btnImportaEntiCsa, ImportaEntiCsa, tracciato_enticsa, "71"),
				new ImportButton(btnRipartUnicaContrattiCSA, ImportaRipUnicaContrattiCSA,
					tracciato_ripunicacontrattocsa, "72"),
				new ImportButton(btnRipartUnicaContributiContrattiCSA, ImportaRipUnicaContributoContrattiCSA,
					tracciato_ripunicacontributocontrattocsa, "73"),
				new ImportButton(btnImportEpexpEpacc, ImportaMovBudget, tracciato_movbudget, "74"),
				new ImportButton(btnImportEpexpvarEpexpvar, ImportaVarMovBudget_noTrigger, tracciato_varmovbudget,
					"75"),
				new ImportButton(btnImportEpexpvarEpexpvar_trg, ImportaVarMovBudget_Trigger, tracciato_varmovbudget,
					"76"),
                new ImportButton(btnFlussiStudenti, ImportCorsoLaurea, tracciato_corsolaurea, "77"),
                new ImportButton(btnAssociaTassaFlussiStudenti, ImportStipDecodifica, tracciato_stipdecodifica, "78"),
				new ImportButton(btnContributiContrattiCSAnuovaversione, ImportaContributiContrattoCSA_nuovagestione, tracciato_contributicontrattocsa_nuovaversione, "79")
			};

			foreach (ImportButton IB in AllButton) {
				IB.Btn.ContextMenu = CMenu;
			}

			if ((bool) Meta.GetSys("IsSystemAdmin") == false) {
				chkStoredProcedure.Checked = false;
				chkStoredProcedure.Visible = false;
				labSqlCmd.Visible = false;
				txtSPName.Visible = false;
			}
		}


		Hashtable hashCentralizedCategory = null;

		void CheckCentralizedCategory(DataTable CentralizedCategory, object idcentralizedcategory, string description) {
			int hCrono = metaprofiler.StartTimer("Checkcentralizedcategory()");
			if (hashCentralizedCategory == null) {
				hashCentralizedCategory = new Hashtable();
				foreach (DataRow RH in CentralizedCategory.Rows) {
					hashCentralizedCategory[RH["idcentralizedcategory"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashCentralizedCategory[idcentralizedcategory.ToString().ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return;
			}

			MetaData MetaCentralizedCategory = Meta.Dispatcher.Get("centralizedcategory");
			DataRow NewCentralizedCategory = MetaCentralizedCategory.Get_New_Row(null, CentralizedCategory);
			NewCentralizedCategory["idcentralizedcategory"] = idcentralizedcategory;
			NewCentralizedCategory["description"] = description;
			NewCentralizedCategory["active"] = 'S';
			NewCentralizedCategory["ct"] = DateTime.Now;
			NewCentralizedCategory["lt"] = DateTime.Now;
			NewCentralizedCategory["cu"] = "importazione";
			NewCentralizedCategory["lu"] = "importazione";
			hashCentralizedCategory[idcentralizedcategory.ToString().ToUpper()] = NewCentralizedCategory;
			metaprofiler.StopTimer(hCrono);
		}

		Hashtable hashRegistryKind = null;

		void CheckRegistryKind(DataTable RegistryKind, string sortcode, string description,
			object idregistrykind) {
			int hCrono = metaprofiler.StartTimer("CheckRegistryKind()");
			if (hashRegistryKind == null) {
				hashRegistryKind = new Hashtable();
				foreach (DataRow RH in RegistryKind.Rows) {
					hashRegistryKind[RH["idregistrykind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashRegistryKind[idregistrykind.ToString().ToUpper()] as DataRow;
			;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return;
			}

			MetaData MetaRegistryKind = Meta.Dispatcher.Get("registrykind");
			DataRow NewRegistryKind = MetaRegistryKind.Get_New_Row(null, RegistryKind);
			NewRegistryKind["idregistrykind"] = idregistrykind;
			NewRegistryKind["description"] = description;
			NewRegistryKind["sortcode"] = sortcode;
			NewRegistryKind["ct"] = DateTime.Now;
			NewRegistryKind["lt"] = DateTime.Now;
			NewRegistryKind["cu"] = "importazione";
			NewRegistryKind["lu"] = "importazione";
			hashRegistryKind[idregistrykind.ToString().ToUpper()] = NewRegistryKind;
			metaprofiler.StopTimer(hCrono);
			return;
		}



		Hashtable hashAddress = null;

		object GetAddress(DataTable Address, string codeaddress, string description) {
			if (hashAddress == null) {
				hashAddress = new Hashtable();
				foreach (DataRow RH in Address.Rows) {
					hashAddress[RH["codeaddress"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashAddress[codeaddress.ToString().ToUpper()] as DataRow;
			;
			if (RID != null) {
				return RID["idaddress"];
			}

			MetaData MetaAddress = Meta.Dispatcher.Get("address");
			DataRow NewAddress = MetaAddress.Get_New_Row(null, Address);
			NewAddress["description"] = description;
			NewAddress["codeaddress"] = codeaddress;
			NewAddress["active"] = "S";
			NewAddress["lt"] = DateTime.Now;
			NewAddress["lu"] = "importazione";
			hashAddress[codeaddress.ToString().ToUpper()] = NewAddress;
			return NewAddress["idaddress"];
		}




		private void btnProfiloSISEST_Click(object sender, EventArgs e) {
			ImportaProfiloSISEST();
		}

		string[] tracciato_ProfiloSISEST =
			new string[] {
				"codiceprofilo;Codice;Stringa;10",
				"ayear;Esercizio;Intero;4",
				"annoaccademico;Anno Accademico;Intero;2",
				"descrizione;Descrizione;Stringa;300",
				"importo_rata;Importo Rata;Numero;9",
				"importo_bollo;Importo Bollo;Numero;9",
				"importo_regionale;Importo Regionale;Numero;9",
				"importo_bollettino;Importo Bollettino;Numero;9",
				"active;Flag Attivo;Codificato;1;S|N"
			};

		private bool ImportaProfiloSISEST() {

			vistaProfiloSISEST D = new vistaProfiloSISEST();

			LeggiFile Reader = GetReader(tracciato_ProfiloSISEST);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			MetaData Meta_sisest_profilo = Meta.Dispatcher.Get("sisest_profilo");
			Meta_sisest_profilo.SetDefaults(D.Tables["sisest_profilo"]);

			List<string> to_sync = new List<string>();
			InitSpeedSaver(Conn, to_sync);

			Reader.GetNext();

			while (Reader.DataPresent()) {
				bool err = false;
				foreach (string fieldreq in new string[] {"ayear", "codiceprofilo", "annoaccademico"}) {
					if (Reader.getCurrField(fieldreq) == DBNull.Value) {
						SpeedSaver.AddError("Il campo " + fieldreq + " è vuoto alla riga:" + Reader.GetCurrRowNumber() +
						                    ".");
						err = true;
						break;
					}
				}

				if (err) {
					Reader.GetNext();
					continue;
				}

				DataRow SP = Meta_sisest_profilo.Get_New_Row(null, D.Tables["sisest_profilo"]);

				SP["codiceprofilo"] = Reader.getCurrField("codiceprofilo");
				SP["ayear"] = Reader.getCurrField("ayear");
				SP["annoaccademico"] = Reader.getCurrField("annoaccademico");
				SP["descrizione"] = Reader.getCurrField("descrizione");

				object importo_rata = Reader.getCurrField("importo_rata");
				if (importo_rata == DBNull.Value) {
					SP["importo_rata"] = 0;
				}
				else {
					SP["importo_rata"] = importo_rata;
				}

				object importo_bollo = Reader.getCurrField("importo_bollo");
				if (importo_bollo == DBNull.Value) {
					SP["importo_bollo"] = 0;
				}
				else {
					SP["importo_bollo"] = importo_bollo;
				}

				object importo_regionale = Reader.getCurrField("importo_regionale");
				if (importo_regionale == DBNull.Value) {
					SP["importo_regionale"] = 0;
				}
				else {
					SP["importo_regionale"] = importo_regionale;
				}

				object importo_bollettino = Reader.getCurrField("importo_bollettino");
				if (importo_bollettino == DBNull.Value) {
					SP["importo_bollettino"] = 0;
				}
				else {
					SP["importo_bollettino"] = importo_bollettino;
				}


				object active = DBNull.Value;
				if (Reader.getCurrField("active").ToString().ToUpper() == "N")
					active = "N";
				else
					active = "S";

				SP["active"] = active;

				SP["cu"] = "Importazione";
				SP["lu"] = "Importazione";
				SP["ct"] = DateTime.Now;
				SP["lt"] = DateTime.Now;

				Reader.GetNext();
			}

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}




		private void btnCausaleSISEST_Click(object sender, EventArgs e) {
			ImportaCausaleSISEST();
		}

		string[] tracciato_CausaleSISEST =
			new string[] {
				"codicecausale;Codice;Stringa;10",
				"ayear;Esercizio;Intero;4",
				"tiporiga;Tipo Riga;Stringa;10",
				"tipocompetenza;Tipo competenza:" +
				" A-Anno accademico 01/11/Eserc.Corrente-31/10/Eserc.Successivo," +
				" B-Anno corrente 01/01 -31/12," +
				" C-Anni precedenti;" +
				" Codificato;1;A|B|C",
				"descrizione;Descrizione;Stringa;300",
				"active;Flag Attivo;Codificato;1;S|N",
				"causalefinanziaria;Codice causale finanziaria;Stringa;50",
				"causalefinanziariaregionale;Codice causale regionale;Stringa;50",
				"causalefinanziariabollo;Codice causale bollo;Stringa;50",
				"causale;Codice causale;Stringa;50",
				"causalecredito;Codice causale credito;Stringa;50",
				"causalebollo;Codice causale Bollo;Stringa;50",
				"causalecreditobollo;Codice causale credito Bollo;Stringa;50",
				"causaleregionale;Codice causale Regionale;Stringa;50",
				"causalecreditoregionale;Codice causale credito Regionale;Stringa;50",
				"codicesiope;Codice classificazione siope;Stringa;50",
				"codicesiopebollo;Codice classificazione siope Bollo;Stringa;50",
				"codicesioperegionale;Codice classificazione siope Regionale;Stringa;50",
				"note;Note;Stringa;500",
			};

		private bool ImportaCausaleSISEST() {

			vistaCausaleSISEST D = new vistaCausaleSISEST();

			LeggiFile Reader = GetReader(tracciato_CausaleSISEST);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			MetaData Meta_sisest_causale = Meta.Dispatcher.Get("sisest_causale");
			Meta_sisest_causale.SetDefaults(D.Tables["sisest_causale"]);

			List<string> to_sync = new List<string>();
			InitSpeedSaver(Conn, to_sync);

			Reader.GetNext();

			while (Reader.DataPresent()) {
				bool err = false;
				foreach (string fieldreq in new string[] {
					"ayear", "codicecausale", "descrizione", "causalefinanziaria", "causale", "causalecredito",
					"codicesiope"
				}) {
					if (Reader.getCurrField(fieldreq) == DBNull.Value) {
						SpeedSaver.AddError("Il campo " + fieldreq + " è vuoto alla riga:" + Reader.GetCurrRowNumber() +
						                    ".");
						err = true;
						break;
					}
				}

				if (err) {
					Reader.GetNext();
					continue;
				}

				DataRow SC = Meta_sisest_causale.Get_New_Row(null, D.Tables["sisest_causale"]);
				DataTable AccMotive = Conn.RUN_SELECT("accmotive", "*", null, null, null, false);
				DataTable FinMotive = Conn.RUN_SELECT("finmotive", "*", null, null, null, false);

				DataTable SiopeSorting = D.Tables["sorting"];

				object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"),
					"idsorkind",
					null);

				string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
				Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);


				SC["codicecausale"] = Reader.getCurrField("codicecausale");
				SC["ayear"] = Reader.getCurrField("ayear");
				SC["tiporiga"] = Reader.getCurrField("tiporiga");
				SC["tipocompetenza"] = Reader.getCurrField("tipocompetenza");
				SC["descrizione"] = Reader.getCurrField("descrizione");
				SC["note"] = Reader.getCurrField("note");

				SC["idfinmotive"] = CheckFinMotive(FinMotive, Reader.getCurrField("causalefinanziaria"));
				SC["idfinmotive_regionale"] =
					CheckFinMotive(FinMotive, Reader.getCurrField("causalefinanziariaregionale"));
				SC["idfinmotive_bollo"] = CheckFinMotive(FinMotive, Reader.getCurrField("causalefinanziariabollo"));

				SC["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causale"));
				SC["idaccmotive_bollo"] = CheckAccMotive(AccMotive, Reader.getCurrField("causalebollo"));
				SC["idaccmotive_credit"] = CheckAccMotive(AccMotive, Reader.getCurrField("causalecredito"));
				SC["idaccmotive_bollo_credit"] = CheckAccMotive(AccMotive, Reader.getCurrField("causalecreditobollo"));
				SC["idaccmotive_regionale"] = CheckAccMotive(AccMotive, Reader.getCurrField("causaleregionale"));
				SC["idaccmotive_regionale_credit"] =
					CheckAccMotive(AccMotive, Reader.getCurrField("causalecreditoregionale"));




				string codicesiope = Reader.getCurrField("codicesiope").ToString();
				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						SC["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				codicesiope = Reader.getCurrField("codicesiopebollo").ToString();
				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						SC["idsor_siope_bollo"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				codicesiope = Reader.getCurrField("codicesioperegionale").ToString();
				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						SC["idsor_siope_regionale"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				object active = DBNull.Value;
				if (Reader.getCurrField("active").ToString().ToUpper() == "N")
					active = "N";
				else
					active = "S";

				SC["active"] = active;

				SC["cu"] = "Importazione";
				SC["lu"] = "Importazione";
				SC["ct"] = DateTime.Now;
				SC["lt"] = DateTime.Now;

				Reader.GetNext();
			}

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}




		string[] tracciato_responsabile =
			new string[] {
				"denominazione;usata negli elenchi;Stringa;150",
				"codicesezione;Codice sezione;Stringa;20",
				"descrsezione;Sezione;Stringa;150",
				"email;Email;Stringa;200",
				"telefono;Telefono;Stringa;30",
				"attivo;Flag Utilizzabile;Stringa;1",
				"userweb;Codice Utente WEB ;Stringa;40",
				"passwordweb; Password WEB;Stringa;40",
				"codtipoclass01;Codice Tipo class. 01;Stringa;20",
				"codclass01;Codice class. 01;Stringa;50",
				"codtipoclass02;Codice Tipo class. 02;Stringa;20",
				"codclass02;Codice class. 02;Stringa;50",
				"codtipoclass03;Codice tipo class. 03;Stringa;20",
				"codclass03;Codice class. 03;Stringa;50",
				"codtipoclass04;Codice Tipo class. 04;Stringa;20",
				"codclass04;Codice class. 04;Stringa;50",
				"codtipoclass05;Codice Tipo class. 05;Stringa;20",
				"codclass05;Codice class. 05;Stringa;50"
			};

		private void btnResponsabili_Click(object sender, EventArgs e) {
			ImportaResponsabili();
		}






		bool ImportaResponsabili() {

			LeggiFile Reader = GetReader(tracciato_responsabile);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaResponsabile();
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaData MetaDivision = Meta.Dispatcher.Get("division");

			DataTable Manager = D.Tables["manager"];
			DataTable Division = D.Tables["division"];

			MetaManager.SetDefaults(Manager);
			MetaDivision.SetDefaults(Division);

			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, null, null, false);

			List<string> to_sync = new List<string>();
			to_sync.Add("division");
			InitSpeedSaver(Conn, to_sync);


			int num = 0;
			Reader.GetNext();
			while (Reader.DataPresent()) {
				num++;
				//Aggiunge le informazioni della Sezione ove necessario
				string codicesezione = Reader.getCurrField("codicesezione").ToString();
				string descrsezione = Reader.getCurrField("descrsezione").ToString();

				DataRow[] rDiv = Division.Select(
					QHS.AppAnd(QHS.CmpEq("codedivision", codicesezione),
						QHS.CmpEq("description", descrsezione)));

				object iddivision = DBNull.Value;
				if (rDiv.Length > 0) {
					iddivision = rDiv[0]["iddivision"];
				}
				else {
					if (codicesezione != "") {
						DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
						NewDiv["description"] = descrsezione;
						NewDiv["codedivision"] = codicesezione;
						iddivision = NewDiv["iddivision"];
					}
				}

				object manager = Reader.getCurrField("denominazione");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) {
					string filter_exists = QHC.CmpEq("title", manager);
					if (Manager.Select(filter_exists).Length > 0) {
						Reader.GetNext();
						continue;
					}
				}

				DataRow NewManager = MetaManager.Get_New_Row(null, Manager);
				;
				NewManager["iddivision"] = iddivision;
				NewManager["title"] = Reader.getCurrField("denominazione");
				NewManager["email"] = Reader.getCurrField("email");
				NewManager["userweb"] = Reader.getCurrField("userweb");
				NewManager["wantswarn"] = NewManager["email"].ToString() != "" ? "S" : "N";
				NewManager["passwordweb"] = Reader.getCurrField("passwordweb");
				NewManager["phonenumber"] = Reader.getCurrField("telefono");
				string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
				bool err;
				//Verifica la presenza delle classificazioni
				for (int nsor = 1; nsor <= 5; nsor++) {
					NewManager["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
						Reader.getCurrField("codtipoclass0" + nsor.ToString()).ToString(),
						Reader.getCurrField("codclass0" + nsor.ToString()).ToString(),
						out err);
					if (err) {
						SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclass0" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}



				NewManager["active"] = Reader.getCurrField("attivo");
				NewManager["lt"] = DateTime.Now;
				NewManager["lu"] = "importazione";

				if (num >= 800) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					D.Tables["manager"].Clear();
					num = 0;
				}

				Reader.GetNext();
			}

			if (num > 0) {
				//Salva i dati
				SaveData(D, true);
				D.Tables["manager"].Clear();
			}

			Reader.Close();
			D.Clear();
			return ShowMessages();
		}

		Dictionary<string, int> MycatastaleCity = new Dictionary<string, int>();
		Dictionary<string, int> MycatastaleNation = new Dictionary<string, int>();

		public void GetCatastale(string codiceanag, object codice, out object idcity, out object idnation) {
			idcity = DBNull.Value;
			idnation = DBNull.Value;
			if (codice != DBNull.Value) {
				string code = codice.ToString().ToUpper();
				if (MycatastaleCity.ContainsKey(code)) {
					idcity = MycatastaleCity[code];
					if (Convert.ToInt32(idcity) != -1) return;
					return;
				}
				else {
					idcity = Conn.DO_READ_VALUE("geo_city_agencyview",
						QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
							QHS.CmpEq("value", code)
							//,QHS.IsNull("stop"), QHS.IsNull("newcity")
						), "idcity", null);
					if (idcity != null && idcity != DBNull.Value) {
						MycatastaleCity[code] = Convert.ToInt32(idcity);
						return;
					}
					else {
						MycatastaleCity[code] = -1;
					}

				}


				if (idcity == null || idcity == DBNull.Value) {
					idcity = DBNull.Value;
					if (MycatastaleNation.ContainsKey(code)) {
						idnation = MycatastaleNation[code];
						if (Convert.ToInt32(idnation) != -1)
							return;
						else {
							SpeedSaver.AddWarning("codice catastale non trovato:" + codice.ToString() +
							                      " per l'anagrafica di codice " + codiceanag);
						}
					}
					else {
						idnation = Conn.DO_READ_VALUE("geo_nation_agencyview",
							QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
								QHS.CmpEq("value", code)
								//,QHS.IsNull("stop"), QHS.IsNull("newnation")
							), "idnation", null);
						if (idnation == null || idnation == DBNull.Value) {
							idnation = DBNull.Value;
							SpeedSaver.AddWarning("codice catastale non trovato:" + codice.ToString() +
							                      " per l'anagrafica di codice " + codiceanag);
							MycatastaleNation[code] = -1;

						}
						else {
							MycatastaleNation[code] = Convert.ToInt32(idnation);
						}
					}
				}

			}
		}


		//tracciati: A;B;C;D;E
		// A = nome colonna
		// B = descrizione colonna
		// C = tipo colonna (Intero/Numero/Stringa/Codificato/Data)
		// D = lunghezza
		// E = eventuali valori codificati separati da |
		string[] tracciato_anagrafica =
			new string[] {
				"codice;Codice anagrafica;Intero;10",
				"tipologia;" +
				"21: Società, enti commerciali, ditte individuali e studi associati " +
				"22: Persona Fisica " +
				"23: Enti non commerciali ed istituzioni internazionali " +
				"24: Anagrafiche complementari " +
				"25: Non utilizzabile; " +
				"Codificato;" +
				"2;" +
				"21|22|23|24|25",
				"tiporesidenza;" +
				"I in Italia J in UE X extra UE;" +
				"Codificato;" +
				"1;" +
				"I|J|X",
				"denominazione;usata negli elenchi;Stringa;100",
				"nome;Nome;Stringa;50",
				"cognome;Cognome;Stringa;50",
				"sesso;Sesso;Codificato;1;M|F",
				"p_iva;P.Iva;Stringa;15",
				"cf;C.F.;Stringa;16",
				"cf_ext;C.F. Estero;Stringa;20",
				"datanasc;Data Nascita;Data;8",
				"localitanasc;Località Nascita;stringa;50",
				"catastalenasc;Codice catastale del comune o stato di nascita (sono i penultimi 4 caratteri del codice fiscale);Stringa;4",
				"matricola;Matricola;Stringa;40",
				"note;Note;Stringa;400",
				"esenteeq;Esente equitalia;Codificato;1;S|N",
				"cfduplicato;Ammetti codice fiscale duplicato;Codificato;1;S|N",
				"attiva;Anagrafica utilizzabile;Codificato;1;S|N",
				//indirizzo predefinito/residenza
				"dataind_res;Data inizio validità indirizzo predefinito;Data;8",
				"indirizzo_res;Indirizzo predefinito;Stringa;100",
				"cap_res;CAP indirizzo predefinito;Stringa;5",
				"ufficio_res;Ufficio predefinito;Stringa;50",
				"catastale_res;Codice catastale del comune o stato estero dell'indirizzo predefinito;Stringa;4",
				"localita_res;Località per l'indirizzo predefinito;Stringa;50",
				//domicilio fiscale ove diverso dal predefinito
				"dataind_dom;Data inizio validità dom.fiscale;Data;8",
				"indirizzo_dom;Indirizzo dom.fiscale;Stringa;100",
				"cap_dom;CAP indirizzo dom.fiscale;Stringa;5",
				"ufficio_dom;Ufficio dom.fiscale;Stringa;50",
				"catastale_dom;Codice catastale del comune del dom.fiscale;Stringa;4",
				"localita_dom;Località per il dom.fiscale;Stringa;50",




				"datainizioposgiurid;Data Inizio Posizione giuridica;Data;8",
				"imponpresunto;Imponibile presunto anno;Numero;22",
				"classestipendiale;Classe Stipendiale;Intero;8",
				"codicequalifica;Codice Qualifica (deve corrispondere ad un codice già presente nel db);Stringa;20",
				"id_class_centralizzata;ID classificazione centralizzata;Stringa;20",
				"descr_class_centralizzata;Descrizione class. centralizzata;Stringa;50",
				"id_tipo_anagrafica;ID tipo anagrafica;intero;4 ",
				"codice_tipo_anagrafica;Codice tipo anagrafica;Stringa;20",
				"descr_tipo_anagrafica;descrizione tipo anagrafica;Stringa;50",
				"idexternal;codice anagrafica esterno;intero;8",
				"bancaditalia;Regolarizza Riscossioni presso TPS Banca d'Italia;Codificato;1;S|N",
				"entepubblico;ente pubblico;Codificato;1;S|N"
			};

		LeggiFile GetReader(string[] tracciato) {
			LeggiFile Reader = new LeggiFile();
			bool res = false;
			if (chkStoredProcedure.Checked) {
				res = Reader.Init(Conn, tracciato, txtSPName.Text);
			}
			else {
				MyOpenFile.RestoreDirectory = true;
				DialogResult DR = MyOpenFile.ShowDialog(this);
				if (DR != DialogResult.OK) return null;
				res = Reader.Init(tracciato, MyOpenFile.FileName);
			}

			if (!res) {
				MessageBox.Show("Non è stato importato alcun dato", "Avviso");
				return null;
			}

			return Reader;

		}

		private void btnAnagrafiche_Click(object sender, EventArgs e) {
			ImportaAnagrafiche();
		}

		/// <summary>
		/// Importazione ANAGRAFICHE
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private bool ImportaAnagrafiche() {


			vistaAnagrafica D = new vistaAnagrafica();

			LeggiFile Reader = GetReader(tracciato_anagrafica);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			MetaData MetaRegistry = Meta.Dispatcher.Get("registry");
			MetaRegistry.SetDefaults(D.Tables["registry"]);
			MetaData MetaRegistryAddress = Meta.Dispatcher.Get("registryaddress");
			MetaRegistryAddress.SetDefaults(D.Tables["registryaddress"]);
			MetaData MetaRegistryPayM = Meta.Dispatcher.Get("registrypaymethod");
			MetaRegistryPayM.SetDefaults(D.Tables["registrypaymethod"]);
			MetaData MetaRegistryLegalStatus = Meta.Dispatcher.Get("registryplegalstatus");
			MetaRegistryLegalStatus.SetDefaults(D.Tables["registrylegalstatus"]);
			MetaData MetaRegistryTaxableStatus = Meta.Dispatcher.Get("registrytaxablestatus");
			MetaRegistryTaxableStatus.SetDefaults(D.Tables["registrytaxablestatus"]);
			MetaData MetaCentralizedCategory = Meta.Dispatcher.Get("centralizedcategory");
			MetaCentralizedCategory.SetDefaults(D.Tables["centralizedcategory"]);
			MetaData MetaRegistryKind = Meta.Dispatcher.Get("registrykind");
			MetaRegistryKind.SetDefaults(D.Tables["registrykind"]);

			DataTable CentralizedCategory = D.centralizedcategory;
			Conn.RUN_SELECT_INTO_TABLE(CentralizedCategory, null, null, null, false);
			DataTable RegistryKind = D.registrykind;
			Conn.RUN_SELECT_INTO_TABLE(RegistryKind, null, null, null, false);


			DataTable Residence = Conn.RUN_SELECT("residence", "*", null, null, null, false);
			Hashtable Hres = new Hashtable();
			foreach (DataRow RR in Residence.Select()) Hres[RR["coderesidence"]] = RR["idresidence"];

			DataTable Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
			Hashtable Hcur = new Hashtable();
			foreach (DataRow RCC in Currency.Select())
				Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

			DataTable Position = Conn.RUN_SELECT("position", "*", null, null, null, false);
			Hashtable HPosition = new Hashtable();
			foreach (DataRow RPOS in Position.Select()) HPosition[RPOS["codeposition"]] = RPOS["idposition"];

			object id_indirizzo_default = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"),
				"idaddress");
			object id_indirizzo_domdef = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"),
				"idaddress");

			if (id_indirizzo_default == null || id_indirizzo_default == DBNull.Value) {
				MessageBox.Show("Nel database manca il tipo indirizzo di codice 07_SW_DEF", "Errore");
				return false;
			}
			if (id_indirizzo_domdef == null || id_indirizzo_domdef == DBNull.Value) {
				MessageBox.Show("Nel database manca il tipo indirizzo di codice 07_SW_DOM", "Errore");
				return false;
			}

			List<string> to_sync = new List<string>();
			to_sync.Add("centralizedcategory");
			to_sync.Add("registrykind");
			InitSpeedSaver(Conn, to_sync);


			int num = 0;
			Reader.GetNext();
			int oldmax = 0;
			oldmax = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("registry", null, "max(idreg)")) + 1;

			while (Reader.DataPresent()) {
				num++;

				object title = Reader.getCurrField("denominazione");
				object attiva = Reader.getCurrField("attiva");
				object codice_esterno = Reader.getCurrField("idexternal");
				//verifica esistenza anagrafica se è presente un codice esterno
				if (chkEsistenza.Checked) {
					if (codice_esterno != DBNull.Value) {
						if (Conn.RUN_SELECT_COUNT("registry", QHS.CmpEq("idexternal", codice_esterno), false) > 0) {
							num = num - 1;
							Reader.GetNext();
							continue;
						}
					}


					string chkexists = QHS.CmpEq("title", title);
					object title_found = "";
					object idreg_found = Conn.DO_READ_VALUE("registry", chkexists, "idreg");
					if (idreg_found == null) idreg_found = DBNull.Value;

					if (idreg_found == DBNull.Value) {
						if (Reader.getCurrField("p_iva") != DBNull.Value) {
							chkexists = QHS.CmpEq("p_iva", Reader.getCurrField("p_iva"));
							idreg_found = Conn.DO_READ_VALUE("registry", chkexists, "idreg");
							if (idreg_found == null) idreg_found = DBNull.Value;
						}
					}

					if (idreg_found == DBNull.Value) {
						if (Reader.getCurrField("cf") != DBNull.Value) {
							chkexists = QHS.CmpEq("cf", Reader.getCurrField("cf"));
							idreg_found = Conn.DO_READ_VALUE("registry", chkexists, "idreg");
							if (idreg_found == null) idreg_found = DBNull.Value;
						}
					}

					if (idreg_found != DBNull.Value)
						title_found = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg_found), "title");


					if (idreg_found != DBNull.Value &&
					    title_found.ToString().Trim().ToLower() != title.ToString().Trim().ToLower()) {
						DialogResult dr = MessageBox.Show("considero l'anagrafica " + title_found.ToString()
						                                                            + " come se avesse denominazione " +
						                                                            title.ToString() +
						                                                            "? (idreg=" + idreg_found +
						                                                            ", codice esterno= " +
						                                                            Reader.getCurrField("idexternal")
							                                                            .ToString() + ")" +
						                                                            Reader.GetCurrRecord(), "Conferma",
							MessageBoxButtons.YesNo);
						if (dr != DialogResult.Yes) {
							//nulla di fatto, importa l'anagrafica regolarmente
							idreg_found = DBNull.Value;
						}

					}

					if (idreg_found != DBNull.Value) {
						Conn.RUN_SELECT_INTO_TABLE(D.Tables["registry"], null, QHS.CmpEq("idreg", idreg_found), null,
							false);
						//non la importa
						DataRow Curr = D.Tables["registry"].Select(QHC.CmpEq("idreg", idreg_found))[0];
						Curr["idexternal"] = Reader.getCurrField("idexternal");

						//chiude il loop
						if (num == 100) {
							//Salva i dati
							if (!SaveData(D, false)) break;
							num = 0;
							D.Tables["registrypaymethod"].Clear();
							D.Tables["registryaddress"].Clear();
							D.Tables["registry"].Clear();
						}

						Reader.GetNext();
						continue;

					}

				}

				if (!Hres.ContainsKey(Reader.getCurrField("tiporesidenza"))) {
					SpeedSaver.AddError("tipo residenza non specificato o errato per l'anagrafica " + title);
					Reader.GetNext();
					continue;
				}

				DataRow Reg = MetaRegistry.Get_New_Row(null, D.Tables["registry"]);
				RowChange.ClearAutoIncrement(D.Tables["registry"].Columns["idreg"]);

				object idcentralizedcategory = Reader.getCurrField("id_class_centralizzata");
				string descr_centralizedcategory = Reader.getCurrField("descr_class_centralizzata").ToString();
				if (idcentralizedcategory.ToString().Trim() != "") {
					CheckCentralizedCategory(CentralizedCategory, idcentralizedcategory, descr_centralizedcategory);
				}

				Reg["idcentralizedcategory"] = idcentralizedcategory;

				object idregistrykind = Reader.getCurrField("id_tipo_anagrafica");
				string code_registrykind = Reader.getCurrField("codice_tipo_anagrafica").ToString();
				string descr_registrykind = Reader.getCurrField("descr_tipo_anagrafica").ToString();
				if (idregistrykind.ToString().Trim() != "") {
					CheckRegistryKind(RegistryKind, code_registrykind, descr_registrykind, idregistrykind);
				}

				Reg["idregistrykind"] = idregistrykind;
				int idreg_to_use = oldmax++;
				if (Reader.getCurrField("codice") != DBNull.Value) {
					int N = CfgFn.GetNoNullInt32(Reader.getCurrField("codice"));
					if (N > 0) {
						idreg_to_use = N;
						oldmax--;
						if (idreg_to_use > oldmax) oldmax = idreg_to_use;
					}
				}

				Reg["idreg"] = idreg_to_use;
				Reg["idexternal"] = Reader.getCurrField("idexternal");
				Reg["idregistryclass"] = Reader.getCurrField("tipologia");
				if (Hres.ContainsKey(Reader.getCurrField("tiporesidenza"))) {
					Reg["residence"] = Hres[Reader.getCurrField("tiporesidenza")];
				}

				Reg["title"] = title;
				Reg["surname"] = Reader.getCurrField("cognome");
				Reg["forename"] = Reader.getCurrField("nome");
				Reg["gender"] = Reader.getCurrField("sesso");
				Reg["p_iva"] = Reader.getCurrField("p_iva");
				Reg["cf"] = Reader.getCurrField("cf");
				Reg["foreigncf"] = Reader.getCurrField("cf_ext");
				Reg["birthdate"] = SSToSmalldateTime(Reader.getCurrField("datanasc"));
				Reg["location"] = Reader.getCurrField("localitanasc");
				Reg["extmatricula"] = Reader.getCurrField("matricola");
				Reg["annotation"] = Reader.getCurrField("note");

				Reg["flagbankitaliaproceeds"] = Reader.getCurrField("bancaditalia");
				Reg["flag_pa"] = Reader.getCurrField("entepubblico");
				object idcity = DBNull.Value;
				object idnation = DBNull.Value;
				object cat = Reader.getCurrField("catastalenasc");
				GetCatastale(idreg_to_use.ToString(), cat, out idcity, out idnation);
				Reg["idcity"] = idcity;
				Reg["idnation"] = idnation;
				Reg["authorization_free"] = Reader.getCurrField("esenteeq");
				Reg["multi_cf"] = Reader.getCurrField("cfduplicato");
				Reg["active"] = attiva;

				//indirizzo predefinito/residenza
				object data_ind1 = SSToSmalldateTime(Reader.getCurrField("dataind_res"));
				if (data_ind1 != DBNull.Value) {
					DataRow RI1 = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
					RI1["idreg"] = idreg_to_use;
					RI1["start"] = data_ind1;
					RI1["idaddresskind"] = id_indirizzo_default;
					RI1["address"] = Reader.getCurrField("indirizzo_res");
					RI1["cap"] = Reader.getCurrField("cap_res");
					RI1["officename"] = Reader.getCurrField("ufficio_res");
					object idcity_res = DBNull.Value;
					object idnation_res = DBNull.Value;
					object cat_res = Reader.getCurrField("catastale_res");
					GetCatastale(idreg_to_use.ToString(), cat_res, out idcity_res, out idnation_res);
					RI1["idcity"] = idcity_res;
					RI1["idnation"] = idnation_res;
					if (idnation_res != DBNull.Value) {
						RI1["flagforeign"] = "S";
					}
					else {
						RI1["flagforeign"] = "N";
					}

					RI1["location"] = Reader.getCurrField("localita_res");
					RI1["active"] = "S";
				}
				else {
					foreach (
						string s in
						new string[] {"indirizzo_res", "cap_res", "ufficio_res", "catastale_res", "localita_res"}) {
						if (Reader.getCurrField(s) != DBNull.Value) {
							SpeedSaver.AddWarning("Il campo " + s + " = " + Reader.getCurrField(s).ToString()
							                      +
							                      " è valorizzato ma non verrà considerato perchè manca la Data inizio Indirizzo di Residenza"
							                      + " per l'anagrafica alla riga" + Reader.GetCurrRowNumber());
						}
					}
				}

				//domicilio fiscale ove diverso dal predefinito
				object data_ind2 = SSToSmalldateTime(Reader.getCurrField("dataind_dom"));
				if (data_ind2 != DBNull.Value) {
					DataRow RI2 = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
					RI2["idreg"] = idreg_to_use;
					RI2["start"] = data_ind2;
					RI2["idaddresskind"] = id_indirizzo_domdef;
					RI2["address"] = Reader.getCurrField("indirizzo_dom");
					RI2["cap"] = Reader.getCurrField("cap_dom");
					RI2["officename"] = Reader.getCurrField("ufficio_dom");
					object idcity_dom = DBNull.Value;
					object idnation_dom = DBNull.Value;
					object cat_dom = Reader.getCurrField("catastale_dom");
					GetCatastale(idreg_to_use.ToString(), cat_dom, out idcity_dom, out idnation_dom);
					RI2["idcity"] = idcity_dom;
					RI2["idnation"] = idnation_dom;
					if (idnation_dom != DBNull.Value) {
						RI2["flagforeign"] = "S";
					}
					else {
						RI2["flagforeign"] = "N";
					}

					RI2["location"] = Reader.getCurrField("localita_dom");
					RI2["active"] = "S";
				}
				else {
					foreach (
						string s in
						new string[] {"indirizzo_dom", "cap_dom", "ufficio_dom", "catastale_dom", "localita_dom"}) {
						if (Reader.getCurrField(s) != DBNull.Value) {
							SpeedSaver.AddWarning("Il campo " + s + " = " + Reader.getCurrField(s).ToString()
							                      +
							                      " è valorizzato ma non verrà considerato perchè manca la Data inizio Domicilio Fiscale"
							                      + " per l'anagrafica alla riga" + Reader.GetCurrRowNumber());
						}
					}
				}


				// inserimento inquadramento
				object codeposition = Reader.getCurrField("codicequalifica");
				object idposition = HPosition[codeposition.ToString().ToUpper()];

				if ((idposition != DBNull.Value) && (idposition != null)) {
					DataRow RLS = MetaRegistryLegalStatus.Get_New_Row(Reg, D.Tables["registrylegalstatus"]);
					RLS["idreg"] = idreg_to_use;
					RLS["active"] = "S";
					RLS["idposition"] = idposition;
					RLS["start"] = SSToSmalldateTime(Reader.getCurrField("datainizioposgiurid"));
					RLS["incomeclassvalidity"] = SSToSmalldateTime(Reader.getCurrField("datainizioposgiurid"));
					RLS["incomeclass"] = Reader.getCurrField("classestipendiale");
				}
				else {
					foreach (string s in new string[] {"datainizioposgiurid", "classestipendiale"}) {
						if (Reader.getCurrField(s) != DBNull.Value) {
							SpeedSaver.AddWarning("Il campo " + s + " = " + Reader.getCurrField(s).ToString()
							                      +
							                      " è valorizzato ma non verrà considerato perchè manca il Codice Qualifica"
							                      + " per l'anagrafica alla riga" + Reader.GetCurrRowNumber());
						}
					}
				}

				object supposedincome = Reader.getCurrField("imponpresunto");
				// inserimento reddito annuo presunto
				if (supposedincome != DBNull.Value) {
					DataRow RTS = MetaRegistryTaxableStatus.Get_New_Row(Reg, D.Tables["registrytaxablestatus"]);
					RTS["idreg"] = idreg_to_use;
					RTS["active"] = "S";
					RTS["start"] = SSToSmalldateTime(Reader.getCurrField("datainizioposgiurid"));
					RTS["supposedincome"] = supposedincome;
				}

				if (num == 100) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					num = 0;
					D.Tables["registrypaymethod"].Clear();
					D.Tables["registryaddress"].Clear();
					D.Tables["registry"].Clear();
				}

				Reader.GetNext();
			}

			if (num > 0) {
				//Salva i dati
				SaveData(D, true);
				D.Tables["registrypaymethod"].Clear();
				D.Tables["registryaddress"].Clear();
				D.Tables["registry"].Clear();
			}

			Reader.Close();
			D.Clear();
			return ShowMessages();

		}

		/// <summary>
		/// Restituisce TRUE se è tutto OK
		/// </summary>
		/// <returns></returns>
		bool ShowMessages() {
			while (SpeedSaver.GetRunningThreads() > 0) {
				Thread.Sleep(1000);
			}

			List<string> err = SpeedSaver.GetErrors();
			StringBuilder SB = new StringBuilder();
			foreach (string s in err) {
				SB.AppendLine(s);
			}

			txtErrori.Text = SB.ToString();

			List<string> warn = SpeedSaver.GetWarnings();
			SB = new StringBuilder();
			foreach (string s in warn) {
				SB.AppendLine(s);
			}

			txtAvvisi.Text = SB.ToString();

			if (SpeedSaver.GetErrorCondition()) {
				txtRisultato.Text = "Il salvataggio dei dati NON E' stato effettuato correttamente.";
			}
			else {
				txtRisultato.Text = "Dati salvati correttamente.";
			}

			tabControl1.SelectedTab = tabRisultati;
			bool res = !SpeedSaver.GetErrorCondition();
			SpeedSaver.Init(null, null);

			return res;
		}

		public void InitSpeedSaver(DataAccess Conn, List<string> lista) {
			if (chkMultiThread.Checked) {
				SpeedSaver.Init(Conn, lista);
			}
			else {
				SpeedSaver.Init(null, null);
			}
		}

		/// <summary>
		/// Restituisce TRUE se tutto OK
		/// </summary>
		/// <param name="D"></param>
		/// <param name="displayMsg"></param>
		/// <returns></returns>
		bool SaveData(DataSet D, bool displayMsg) {
			if (SpeedSaver.GetErrorCondition()) {
				if (displayMsg) {
					ShowMessages();
				}

				return false;
			}

			if (!D.HasChanges()) {
				SpeedSaver.AddWarning("Nessun dato da salvare");
			}
			else {
				if ((chkMultiThread.Checked == false) || !SpeedSaver.isInitialized()) {
					SpeedSaver.Save(Conn, D);
				}
				else {
					SpeedSaver.Save(D);
				}
			}

			bool res = !SpeedSaver.GetErrorCondition();

			//if (res == true && BatchIsRunning) return true;

			if (displayMsg) {
				ShowMessages();
			}

			return res;


			//int hSaveData = metaprofiler.StartTimer("Importazione - SaveData ");
			//PostData P = new PostData_Migrazione();
			//P.InitClass(D, Conn);
			//bool res = P.DO_POST();
			//if (displayMsg) {
			//    if (res) MessageBox.Show("Dati salvati correttamente");
			//    else MessageBox.Show("Dati non salvati.");
			//}
			//metaprofiler.StopTimer(hSaveData);


			//Application.DoEvents();
			//return res;
		}

		string[] tracciato_indirizzi =
			new string[] {
				"codice;Codice anagrafica;Intero;10",
				"codicetipoind;Codice tipo indirizzo;Stringa;20",
				"descrtipoind;Descrizione tipo indirizzo;Stringa;60",
				"datastart;Data inizio validità;Data;8",
				"datastop;Data fine validità;Data;8",
				"indirizzo;Indirizzo;Stringa;100",
				"cap;CAP;Stringa;5",
				"ufficio;Ufficio predefinito;Stringa;50",
				"catastale;Codice catastale del comune o stato estero;Stringa;4",
				"localita;Località;Stringa;50",
				"nazione;Nazione estera (deve essere uguale ad una del programma se presente);Stringa;65",
				"annotazioni;Annotazioni;Stringa;400",
				"enteprovenienza;Ente provenienza (per anagrafe prestazioni);Stringa;50",
				"attivo;Attivo;Codificato;1;S|N"
			};

		string[] tracciato_contatti =
			new string[] {
				"codice;Codice anagrafica;Intero;10",
				"telefono;Telefono;Stringa;50",
				"fax;Fax;Stringa;50",
				"email;Indirizzo e-mail;Stringa;200",
				"nomecontatto;Nome Contatto;Stringa;50",
				"predefinito;Flag predefinito;Codificato;1;S|N" //TASK 10698
			};

		string[] tracciato_modpag =
			new string[] {
				"codice;Codice anagrafica;Intero;10",

				//modalità di pagamento
				"tipomodpag;tipo modalità di pagamento " +
				"1-Assegno circolare  (non ammette delegato o coordinate bancarie) " +
				"3-Bonifico presso altre banche (non ammette delegato, coord.bancarie obbligatorie) " +
				"4-Bonifico presso istituto cassiere (non ammette delegato, coord.bancarie obbligatorie) " +
				"5-Conto corrente postale (ammette solo il cc) " +
				"6-Esclusiva cassiere (non ammette delegato o coord.bancarie) " +
				"7-Sportello (ammette delegato e  non ammette coord.bancarie);" +
				"Codificato;1;1|3|4|5|6|7",
				"nomemod;Nome modalità;Stringa;50",
				"descrmod;Nome modalità;Stringa;150",
				"abi;ABI;Stringa;10",
				"cab;CAB;Stringa;10",
				"cin;CIN;Stringa;5",
				"cc;Conto corrente;Stringa;30",
				"bic;Conto BIC/SWIFT;Stringa;20",
				"delegato;Codice delegato (di anagrafica);Intero;10",
				"valuta;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",
				"tiposcadenza;Tipo scadenza " +
				"1-data contabile,2-data documento," +
				"3-fine mese data contabile,4-fine mese data documento," +
				"5-Pagamento immediato;Codificato;1;1|2|3|4|5",
				"ggscadenza;Giorni dalla scadenza;intero;2",
				"iban;IBAN;Stringa;50",
				"extracode;Conto in banca d'Italia;Stringa;10",
				"refexternaldoc;Riferimento doc.esterno;Stringa;5",
				"txt;Note;Stringa;1000",
				"attivo;Attivo;Codificato;1;S|N",
				"flagstandard;Modalità predefinita;Codificato;1;S|N"
			};

		string[] tracciato_classinventariale = new string[] {
			"nliv;Numero Livello classificazione;Intero;1",
			"descrliv;Descrizione Livello classificazione;Stringa;30",
			"codiceclass;Codice classificazione inventariale;Stringa;20",
			"codiceparentclass;Codice classificazione inventariale del nodo PARENT di questo;Stringa;20",
			"descrclass;Descrizione voce classificazione;Stringa;150"
		};
		/*
		 * 
			"applicabilita_italia; Applicabilità in Fatture: italia;Codificato;1;S|N",
			"applicabilita_intraue; Applicabilità in Fatture: intraUE;Codificato;1;S|N",
			"applicabilita_extraue; Applicabilità in Fatture: extraUE;Codificato;1;S|N",
			"tipoattivita_istituzionale;Tipo Attività: Istituzionale;Codificato;1;S|N",
			"tipoattivita_commerciale;Tipo Attività: Commerciale ;Codificato;1;S|N",
			"tipoattivita_promiscua;Tipo Attività: Promiscua/Altro;Codificato;1;S|N",
			"naturaesenzione;Natura di esenzione: N1 - Escluse ex art.15, N2 - Non soggette, N3 - Non imponibili, N4 - Esenti, N5 - Regime del margine, N6 - Inversione contabile, N7 - IVA assolta in altro stato UE;Codificato;2;N1|N2|N3|N4|N5|N6|N7"

		 * */

		string[] tracciato_aliquoteiva = new string[] {
			"codtipoiva;Codice Tipo IVA;Stringa;20",
			"descrtipoiva; Descrizione Tipo IVA;Stringa;50",
			"aliquota;Aliquota iva;Numero;22",
			"tipoimposizione; Tipo imposizione " +
			" 1-Imponibile," +
			" 2-Non Imponibile," +
			" 3-Esente," +
			" 4-Non esposta in fattura," +
			" 5,Fuori Campo;" +
			" Codificato;1;1|2|3|4|5",
			"perc_indetraibilita;Percentuale di indetraibilità;Numero;22",
			"annotazioni;Annotazioni;Stringa;400",
			"attivo;Attivo;Codificato;1;S|N",
			"applicabilita_italia; Applicabilità in Fatture: italia;Codificato;1;S|N",
			"applicabilita_intraue; Applicabilità in Fatture: intraUE;Codificato;1;S|N",
			"applicabilita_extraue; Applicabilità in Fatture: extraUE;Codificato;1;S|N",
			"tipoattivita_istituzionale;Tipo Attività: Istituzionale;Codificato;1;S|N",
			"tipoattivita_commerciale;Tipo Attività: Commerciale ;Codificato;1;S|N",
			"tipoattivita_promiscua;Tipo Attività: Promiscua/Altro;Codificato;1;S|N",
			"naturaesenzione;Natura di esenzione: N1 - Escluse ex art.15, N2 - Non soggette, N3 - Non imponibili," +
			" N4 - Esenti, N5 - Regime del margine, N6 - Inversione contabile, N7 - IVA assolta in altro stato UE;Codificato;2;N1|N2|N3|N4|N5|N6|N7",
			"prorata_numeratore;Applicabilità al numeratore;Codificato;1;S|N",
			"prorata_denominatore;Applicabilità al denominatore;Codificato;1;S|N"
		};

		void CheckLivInventoryTree(DataTable Liv, int Nlevel, string leveldescr, string code) {
			//Crea ove assente il livello
			if (Liv.Select(QHC.CmpEq("nlevel", Nlevel)).Length > 0) return;
			DataRow RL = Liv.NewRow();
			RL["nlevel"] = Nlevel;
			RL["flag"] = 1; //Imposta tutti i livelli come alfanumerici
			RL["ct"] = DateTime.Now;
			RL["lt"] = DateTime.Now;
			RL["cu"] = "importazione";
			RL["lu"] = "importazione";
			RL["description"] = leveldescr;
			int prevLen = 0;
			for (int j = 1; j < Nlevel; j++) {
				DataRow PrevLiv = Liv.Select(QHC.CmpEq("nlevel", j))[0];
				prevLen += CfgFn.GetNoNullInt32(PrevLiv["codelen"]);
			}

			RL["codelen"] = code.Length - prevLen;
			Liv.Rows.Add(RL);

		}

		private void btnClassInv_Click(object sender, EventArgs e) {
			ImportaClassInv();
		}

		bool ImportaClassInv() {
			LeggiFile Reader = GetReader(tracciato_classinventariale);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			DataSet D = new vistaClassInventariale();

			MetaData MetaInvTree = Meta.Dispatcher.Get("inventorytree");
			DataTable InvTree = D.Tables["inventorytree"];
			DataTable InvTreeLevel = D.Tables["inventorysortinglevel"];
			Conn.RUN_SELECT_INTO_TABLE(InvTreeLevel, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InvTree, null, null, null, false);
			MetaInvTree.SetDefaults(InvTree);

			bool to_repeat = true;
			bool somethingdone = false;
			while (to_repeat) {
				to_repeat = false;
				somethingdone = false;

				Reader.Reset();

				Reader.GetNext();

				while (Reader.DataPresent()) {
					string filter_exists = QHC.CmpEq("codeinv", Reader.getCurrField("codiceclass"));
					if (InvTree.Select(filter_exists).Length > 0) {
						Reader.GetNext();
						continue;
					}


					//individua il nodo parent
					object parcode = Reader.getCurrField("codiceparentclass");
					DataRow RParInv = null;
					if (parcode != DBNull.Value) {
						string filter = QHC.CmpEq("codeinv", parcode);
						if (InvTree.Select(filter).Length == 0) {
							SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + parcode +
							                      " padre del nodo avente codice " +
							                      Reader.getCurrField("codiceclass").ToString());

							Reader.GetNext();
							to_repeat = true;
							continue;
						}

						RParInv = InvTree.Select(filter)[0];

					}

					//Aggiunge le informazioni di livello ove necessario
					int Nlev = CfgFn.GetNoNullInt32(Reader.getCurrField("nliv"));
					string levelname = Reader.getCurrField("descrliv").ToString();
					string code = Reader.getCurrField("codiceclass").ToString();
					CheckLivInventoryTree(InvTreeLevel, Nlev, levelname, code);

					DataRow Rinv = MetaInvTree.Get_New_Row(RParInv, InvTree);
					Rinv["codeinv"] = code;
					Rinv["nlevel"] = Nlev;
					Rinv["description"] = Reader.getCurrField("descrclass").ToString();
					Rinv["ct"] = DateTime.Now;
					Rinv["lt"] = DateTime.Now;
					Rinv["cu"] = "importazione";
					Rinv["lu"] = "importazione";
					somethingdone = true;
					Reader.GetNext();
				} //while (Reader.DataPresent()) 


				if (to_repeat && !somethingdone) {
					SpeedSaver.AddError("Ci sono nodi child senza parent,verificare.");
					to_repeat = false;
				}
			} // while (to_repeat) 

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				return ShowMessages();
			}

			//Imposta l'ultimo livello come operativo
			int MaxNlev = CfgFn.GetNoNullInt32(InvTreeLevel.Compute("max(nlevel)", null));
			DataRow LastLev = InvTreeLevel.Select(QHC.CmpEq("nlevel", MaxNlev))[0];
			LastLev["flag"] = CfgFn.GetNoNullInt32(LastLev["flag"]) | 2;

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		string[] tracciato_ubicazioni = new string[] {
			"nliv;Numero Livello ubicazione;Intero;1",
			"descrliv;Descrizione Livello ubicazione;Stringa;30",
			"codiceubic;Codice ubicazione;Stringa;50",
			"codiceparentubic;Codice ubicazione del nodo PARENT di questo;Stringa;50",
			"descrubic;Descrizione voce classificazione;Stringa;150",
			"resp;Responsabile;Stringa;150",
			"note;Note;Stringa;100"
		};

		void CheckLivUbicazioni(DataTable Liv, int Nlevel, string leveldescr, string code) {
			//Crea ove assente il livello
			if (Liv.Select(QHC.CmpEq("nlevel", Nlevel)).Length > 0) return;
			DataRow RL = Liv.NewRow();
			RL["nlevel"] = Nlevel;
			RL["flag"] = 1; //Imposta tutti i livelli come alfanumerici
			RL["ct"] = DateTime.Now;
			RL["lt"] = DateTime.Now;
			RL["cu"] = "importazione";
			RL["lu"] = "importazione";
			RL["description"] = leveldescr;
			int prevLen = 0;
			for (int j = 1; j < Nlevel; j++) {
				DataRow PrevLiv = Liv.Select(QHC.CmpEq("nlevel", j))[0];
				prevLen += CfgFn.GetNoNullInt32(PrevLiv["codelen"]);
			}

			RL["codelen"] = code.Length - prevLen;
			Liv.Rows.Add(RL);

		}

		private void btnUbicazioni_Click(object sender, EventArgs e) {
			ImportaUbicazioni();
		}

		bool ImportaUbicazioni() {

			LeggiFile Reader = GetReader(tracciato_ubicazioni);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			DataSet D = new vistaUbicazioni();

			MetaData MetaLocation = Meta.Dispatcher.Get("location");
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			DataTable Location = D.Tables["location"];
			DataTable LocationLevel = D.Tables["locationlevel"];
			DataTable Manager = D.Tables["manager"];
			DataTable Division = D.Tables["division"];
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("description", "Fittizia"), null, false);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(LocationLevel, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("manager");
			tosync.Add("division");
			tosync.Add("location");
			tosync.Add("locationlevel");
			InitSpeedSaver(Conn, null);

			MetaLocation.SetDefaults(Location);
			MetaDivision.SetDefaults(Division);

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}


			bool to_repeat = true;
			bool somedone = false;
			while (to_repeat) {
				to_repeat = false;
				somedone = false;

				Reader.Reset();

				Reader.GetNext();

				while (Reader.DataPresent()) {
					string filter_exists = QHC.CmpEq("locationcode", Reader.getCurrField("codiceubic"));
					if (Location.Select(filter_exists).Length > 0) {
						Reader.GetNext();
						continue;
					}

					//individua il nodo parent
					object parcode = Reader.getCurrField("codiceparentubic");
					DataRow RParInv = null;
					if (parcode != DBNull.Value) {
						string filter = QHC.CmpEq("locationcode", parcode);
						if (Location.Select(filter).Length == 0) {
							SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + parcode +
							                      " padre del nodo avente codice " +
							                      Reader.getCurrField("codiceubic").ToString()
							                      + " riga:" + Reader.GetCurrRowNumber());

							Reader.GetNext();
							to_repeat = true;
							continue;
						}

						RParInv = Location.Select(filter)[0];

					}

					//Aggiunge le informazioni di livello ove necessario
					int Nlev = CfgFn.GetNoNullInt32(Reader.getCurrField("nliv"));
					string levelname = Reader.getCurrField("descrliv").ToString();
					string code = Reader.getCurrField("codiceubic").ToString();
					string note = Reader.getCurrField("note").ToString();
					CheckLivInventoryTree(LocationLevel, Nlev, levelname, code);
					object manager = Reader.getCurrField("resp");
					object idman = DBNull.Value;
					if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision);

					DataRow Rinv = MetaLocation.Get_New_Row(RParInv, Location);

					//quello che viene dopo serve a far si che quando si ricalcola gli id effettivi, 
					//non coincidano con quelli suoi in memoria
					int myval = CfgFn.GetNoNullInt32(Rinv["idlocation"]);
					if (myval < 10000000) myval = 10000000;
					Rinv["idlocation"] = myval;

					Rinv["locationcode"] = code;
					Rinv["nlevel"] = Nlev;
					Rinv["description"] = Reader.getCurrField("descrubic").ToString();
					Rinv["ct"] = DateTime.Now;
					Rinv["lt"] = DateTime.Now;
					Rinv["cu"] = "importazione";
					Rinv["lu"] = "importazione";
					Rinv["idman"] = idman;
					Rinv["txt"] = note;
					Rinv["active"] = "S";
					somedone = true;

					Reader.GetNext();
				} //while (Reader.DataPresent()) 

				if (to_repeat && !somedone) {
					SpeedSaver.AddError("Ci sono nodi child senza parent,verificare.");
					to_repeat = false;
				}

			} // while (to_repeat) 

			Reader.Close();
			if (SpeedSaver.GetErrorCondition()) {
				return ShowMessages();

			}

			//Imposta l'ultimo livello come operativo
			int MaxNlev = CfgFn.GetNoNullInt32(LocationLevel.Compute("max(nlevel)", null));
			DataRow LastLev = LocationLevel.Select(QHC.CmpEq("nlevel", MaxNlev))[0];
			LastLev["flag"] = CfgFn.GetNoNullInt32(LastLev["flag"]) | 2;
			/*string stringa = "";
			foreach (DataRow R in D.Tables["location"].Rows) {
			     stringa = stringa + R["idlocation"].ToString() + 
			                    " parent " + R["paridlocation"].ToString() +
			                    " nlevel " + R["nlevel"].ToString() + " ";
			   
			}
			MessageBox.Show(stringa);*/

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		void CheckMovPhase(DataTable MovPhase, object nphase, object description) {
			string filter = QHC.CmpEq("nphase", nphase);
			if (MovPhase.Select(filter).Length > 0) return;
			MetaData MetaPhase = MetaData.GetMetaData(this, MovPhase.TableName);
			MetaPhase.SetDefaults(MovPhase);
			DataRow Rm = MetaPhase.Get_New_Row(null, MovPhase);
			Rm["nphase"] = nphase;
			Rm["description"] = description;

		}


		object GetSortingKind(DataTable Sortingkind,
			object codesorkind, object description,
			object start, object stop,
			object nphaseincome, object nphaseexpense

		) {
			if (Sortingkind.Select(QHC.CmpEq("codesorkind", codesorkind)).Length > 0)
				return Sortingkind.Select(QHC.CmpEq("codesorkind", codesorkind))[0]["idsorkind"];
			MetaData MetaSortingkind = MetaData.GetMetaData(this, "sortingkind");
			MetaSortingkind.SetDefaults(Sortingkind);
			DataRow Rm = MetaSortingkind.Get_New_Row(null, Sortingkind);
			Rm["codesorkind"] = codesorkind;
			Rm["description"] = description;
			Rm["start"] = start;
			Rm["stop"] = stop;
			Rm["nphaseincome"] = nphaseincome;
			Rm["nphaseexpense"] = nphaseexpense;
			Rm["active"] = "S";
			return Rm["idsorkind"];

		}

		void CheckSortingLevel(DataTable SortingLevel, object Nlev, object description, object idsorkind,
			object usable) {
			string filter = QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkind), QHC.CmpEq("nlevel", Nlev));
			if (SortingLevel.Select(filter).Length > 0) return;
			MetaData MetaSortingLevel = MetaData.GetMetaData(this, SortingLevel.TableName);
			MetaSortingLevel.ExtraParameter = idsorkind;
			MetaSortingLevel.SetDefaults(SortingLevel);
			DataRow Rm = MetaSortingLevel.Get_New_Row(null, SortingLevel);
			RowChange.ClearAutoIncrement(SortingLevel.Columns["nlevel"]);
			Rm["nlevel"] = Nlev;
			Rm["description"] = description;
			Rm["idsorkind"] = idsorkind;
			int flag = CfgFn.GetNoNullInt32(Rm["flag"]);
			if (usable.ToString().ToUpper() == "S") {
				flag = flag | 2;
			}
			else {
				flag = flag & 0xFD;
			}

			flag = flag | 1; //imposta alfanumerico
			Rm["flag"] = flag;

		}


		Hashtable hManager = null;

		object GetManager(DataTable Manager, string responsabile, object iddivision) {
			return GetManager(Manager, responsabile, iddivision, "S");
		}

		object GetManager(DataTable Manager, string responsabile, object iddivision, object financeactive) {
			responsabile = responsabile.Trim();
			if (hManager == null) {
				hManager = new Hashtable();
				foreach (DataRow R in Manager.Rows) {
					string kk = R["title"].ToString().Trim().ToUpper();
					hManager[kk] = R;
				}
			}

			string k = responsabile.ToUpper();
			DataRow f = hManager[k] as DataRow;
			if (f != null) return f["idman"];
			MetaData MetaManager = MetaData.GetMetaData(this, "manager");
			MetaManager.SetDefaults(Manager);
			DataRow Rm = MetaManager.Get_New_Row(null, Manager);
			Rm["title"] = responsabile;
			Rm["iddivision"] = iddivision;
			Rm["active"] = "S";
			if (Manager.Columns.Contains("financeactive")) {
				Rm["financeactive"] = financeactive;
			}

			if (Manager.Columns.Contains("wantswarn")) {
				Rm["wantswarn"] = "N";
			}

			hManager[k] = Rm;
			return Rm["idman"];
		}

		Hashtable hUnderwriter = null;

		object GetUnderwriter(DataTable Underwriter, string finanziatore) {
			if (hUnderwriter == null) {
				hUnderwriter = new Hashtable();
				foreach (DataRow R in Underwriter.Rows) {
					string kk = R["description"].ToString().ToUpper();
					hUnderwriter[kk] = R;
				}
			}

			string k = finanziatore.ToUpper();
			DataRow f = hUnderwriter[k] as DataRow;
			if (f != null) return f["idunderwriter"];
			MetaData MetaUnderwriter = MetaData.GetMetaData(this, "underwriter");
			MetaUnderwriter.SetDefaults(Underwriter);
			DataRow Ru = MetaUnderwriter.Get_New_Row(null, Underwriter);
			Ru["title"] = finanziatore;
			Ru["active"] = "S";
			hUnderwriter[k] = Ru;
			return Ru["idunderwriter"];
		}

		Hashtable hTreasurer = null;

		object GetTreasurer(DataTable Treasurer, object codice, object descr) {
			if (hTreasurer == null) {
				hTreasurer = new Hashtable();
				foreach (DataRow R in Treasurer.Select()) {
					string kk = R["codetreasurer"].ToString().ToUpper();
					hTreasurer[kk] = R;
				}
			}

			string k = codice.ToString().ToUpper();
			DataRow f = hTreasurer[k] as DataRow;
			if (f != null) return f["idtreasurer"];

			MetaData MetaTreasurer = MetaData.GetMetaData(this, "treasurer");
			MetaTreasurer.SetDefaults(Treasurer);
			DataRow Rm = MetaTreasurer.Get_New_Row(null, Treasurer);
			Rm["codetreasurer"] = codice;
			Rm["description"] = descr;
			Rm["flagdefault"] = "N";
			hTreasurer[k] = Rm;
			return Rm["idtreasurer"];
		}

		object CheckExistsTreasurer(DataTable Treasurer, object codice) {
			if (hTreasurer == null) {
				hTreasurer = new Hashtable();
				foreach (DataRow R in Treasurer.Select()) {
					string kk = R["codetreasurer"].ToString().ToUpper();
					hTreasurer[kk] = R;
				}
			}

			string k = codice.ToString().ToUpper();
			DataRow f = hTreasurer[k] as DataRow;
			if (f != null) return f["idtreasurer"];
			return null;
		}

		Hashtable hPayTrasm = null;

		object GetPaymentTransmission(DataTable PaymentTransmission, object anno, object numelenco, object idtreasurer,
			object datatrasmissione) {
			string key = anno.ToString() + "/" + numelenco.ToString();
			if (hPayTrasm == null) {
				hPayTrasm = new Hashtable();
				foreach (DataRow R in PaymentTransmission.Rows) {
					string Rkey = R["ypaymenttransmission"].ToString() + "/" + R["npaymenttransmission"].ToString();
					hPayTrasm[Rkey] = R;
				}
			}

			DataRow RR = hPayTrasm[key] as DataRow;
			if (RR != null) return RR["kpaymenttransmission"];
			MetaData MetaPaymentTransmission = MetaData.GetMetaData(this, "paymenttransmission");
			MetaPaymentTransmission.SetDefaults(PaymentTransmission);
			DataRow Rm = MetaPaymentTransmission.Get_New_Row(null, PaymentTransmission);
			RowChange.ClearAutoIncrement(PaymentTransmission.Columns["npaymenttransmission"]);
			Rm["ypaymenttransmission"] = anno;
			Rm["npaymenttransmission"] = numelenco;
			Rm["idtreasurer"] = idtreasurer;
			Rm["transmissiondate"] = ToSmalldateTime(datatrasmissione);
			Rm["transmissionkind"] = "I";
			Rm["flagmailsent"] = "S";
			hPayTrasm[key] = Rm;
			return Rm["kpaymenttransmission"];
		}


		Hashtable hProcTrasm = null;

		object GetProceedsTransmission(DataTable ProceedsTransmission, object anno, object numelenco,
			object idtreasurer,
			object datatrasmissione) {
			string key = anno.ToString() + "/" + numelenco.ToString();
			if (hProcTrasm == null) {
				hProcTrasm = new Hashtable();
				foreach (DataRow R in ProceedsTransmission.Rows) {
					string Rkey = R["yproceedstransmission"].ToString() + "/" + R["nproceedstransmission"].ToString();
					hProcTrasm[Rkey] = R;
				}
			}

			DataRow RR = hProcTrasm[key] as DataRow;
			if (RR != null) return RR["kproceedstransmission"];

			MetaData MetaProceedsTransmission = MetaData.GetMetaData(this, "proceedstransmission");
			MetaProceedsTransmission.SetDefaults(ProceedsTransmission);
			DataRow Rm = MetaProceedsTransmission.Get_New_Row(null, ProceedsTransmission);
			RowChange.ClearAutoIncrement(ProceedsTransmission.Columns["nproceedstransmission"]);
			Rm["yproceedstransmission"] = anno;
			Rm["nproceedstransmission"] = numelenco;
			Rm["idtreasurer"] = idtreasurer;
			Rm["transmissiondate"] = ToSmalldateTime(datatrasmissione);
			Rm["transmissionkind"] = "I";
			hProcTrasm[key] = Rm;
			return Rm["kproceedstransmission"];
		}

		Hashtable hStamp = null;

		object GetStampHandling(DataTable StampHandling, object codice, object descr) {
			StampHandling.CaseSensitive = false;
			if (hStamp == null) {
				hStamp = new Hashtable();
				foreach (DataRow R in StampHandling.Rows) {
					string Rkey = R["handlingbankcode"].ToString().ToUpper();
					hStamp[Rkey] = R;
				}
			}

			DataRow RR = hStamp[codice.ToString().ToUpper()] as DataRow;
			if (RR != null) return RR["idstamphandling"];

			if (StampHandling.Select(QHC.CmpEq("description", descr)).Length > 0) {
				//Esiste giò una riga con la stessa descrizione
				object newcode = StampHandling.Select(QHC.CmpEq("description", descr))[0]["handlingbankcode"];
				RR = hStamp[newcode.ToString().ToUpper()] as DataRow;
				hStamp[codice.ToString().ToUpper()] = RR;
				return RR["idstamphandling"];
			}

			MetaData MetaStampHandling = MetaData.GetMetaData(this, "stamphandling");
			MetaStampHandling.SetDefaults(StampHandling);
			DataRow Rm = MetaStampHandling.Get_New_Row(null, StampHandling);
			Rm["handlingbankcode"] = codice;
			Rm["description"] = descr;
			Rm["flagdefault"] = "N";
			Rm["active"] = "S";
			hStamp[codice.ToString().ToUpper()] = Rm;
			return Rm["idstamphandling"];
		}

		string[] tracciato_varpatr = new string[] {
			"tipo;Tipo variazione N=Normale,C=Consistenza iniziale;Codificato;1;N|C",
			"annovar;Anno variazione;Intero;4",
			"numvar;Numero variazione;Intero;6",
			"provv;Provvedimento;Stringa;150",
			"dataprovv;Data provvedimento;Data;8",
			"numprovv;Num.provvedimento;Stringa;15",
			"descr;Descrizione;Stringa;150",
			"data;Data contabile;Data;8",
			"codeinvagency;Codice Ente Inventariale;Stringa;20",
			"descrinvagency;Descrizione Ente Inventariale;Stringa;150",
			"codeinv;Codice Inventario;Stringa;20",
			"descrinv;Descrizione Inventario;Stringa;50",
			"codeinvkind;Codice Tipo Inventario;Stringa;20",
			"descrinvkind;Descr. Tipo Inventario;Stringa;50",
			"codeclass;Codice classificazione inventariale;Stringa;20",
			"descrdet;Descrizione Dettaglio;Stringa;150",
			"importo;Importo;Numero;22",
			"codicecausalecar;Codice Causale di carico;Stringa;10",
			"descrcausalecar;Descrizione Causale di carico;Stringa;30"
		};

		private void btnVarPatr_Click(object sender, EventArgs e) {
			ImportaVarPatr();
		}

		bool ImportaVarPatr() {
			LeggiFile Reader = GetReader(tracciato_varpatr);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaAssetVar();

			DataTable AssetVar = D.Tables["assetvar"];
			MetaData MetaAssetVar = Meta.Dispatcher.Get("assetvar");
			MetaAssetVar.SetDefaults(AssetVar);

			DataTable AssetVarDetail = D.Tables["assetvardetail"];
			MetaData MetaAssetVarDetail = Meta.Dispatcher.Get("assetvardetail");
			MetaAssetVarDetail.SetDefaults(AssetVarDetail);

			DataTable InvTree = D.Tables["inventorytree"];
			MetaData MetaInvTree = Meta.Dispatcher.Get("inventorytree");
			MetaInvTree.SetDefaults(InvTree);

			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);

			DataTable InventoryAgency = D.Tables["inventoryagency"];
			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			MetaInventoryAgency.SetDefaults(InventoryAgency);

			DataTable InventoryKind = D.Tables["inventorykind"];
			MetaData MetaInventoryKind = Meta.Dispatcher.Get("inventorykind");
			MetaInventoryKind.SetDefaults(InventoryKind);

			DataTable AssetLoadMotive = D.Tables["assetloadmotive"];
			MetaData MetaAssetLoadMotive = Meta.Dispatcher.Get("assetloadmotive");
			MetaAssetLoadMotive.SetDefaults(AssetLoadMotive);

            Conn.RUN_SELECT_INTO_TABLE(InvTree, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAgency, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadMotive, null, null, null, false);
 
            List<string> tosync = new List<string>();
			tosync.Add("inventorytree");
			tosync.Add("inventory");
			tosync.Add("inventorykind");
			tosync.Add("assetloadmotive");
			tosync.Add("inventoryagency");
			InitSpeedSaver(Conn, tosync);





			Reader.GetNext();

			while (Reader.DataPresent()) {


				//Aggiunge le informazioni di Ente Inventariale ove necessario
				string descrinvag = Reader.getCurrField("descrinvagency").ToString();
				string codeinvag = Reader.getCurrField("codeinvagency").ToString();
				object idinventoryagency = CheckinventoryAgency(InventoryAgency, codeinvag, descrinvag);


				//Aggiunge le informazioni di Tipo Inventario ove necessario
				string descrinvkind = Reader.getCurrField("descrinvkind").ToString();
				string codeinvkind = Reader.getCurrField("codeinvkind").ToString();
				object idinvkind = CheckinventoryKind(InventoryKind, codeinvkind, descrinvkind);

				//Aggiunge le informazioni di inventario ove necessario
				string descrinv = Reader.getCurrField("descrinv").ToString();
				string codeinv = Reader.getCurrField("codeinv").ToString();
				object idinventory = Checkinventory(Inventory, codeinv, descrinv, idinventoryagency, idinvkind);

				//Vede se c'è da aggiungere la variazione patrimoniale
				object yvar = Reader.getCurrField("annovar");
				object nvar = Reader.getCurrField("numvar");
				if (nvar == DBNull.Value) {
					SpeedSaver.AddError("Numero variazione non trovato per la variazione  del " + yvar +
					                    " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow RVar = null;
				string filtervar = QHC.AppAnd(QHC.CmpEq("yvar", yvar), QHC.CmpEq("nvar", nvar));
				if (AssetVar.Select(filtervar).Length > 0) {
					RVar = AssetVar.Select(filtervar)[0];
				}
				else {
					string tipo = Reader.getCurrField("tipo").ToString().ToUpper();
					int flag = tipo == "N" ? 1 : 0; //Normale=1, Iniziale=0
					object enactment = Reader.getCurrField("provv");
					object enactmentdate = Reader.getCurrField("dataprovv");
					object nenactment = Reader.getCurrField("numprovv");
					object description = Reader.getCurrField("descr");
					object adate = Reader.getCurrField("data");
					RVar = MetaAssetVar.Get_New_Row(null, AssetVar);
					RowChange.ClearAutoIncrement(AssetVar.Columns["nvar"]);
					RVar["flag"] = flag;
					RVar["enactment"] = enactment;
					RVar["enactmentdate"] = ToSmalldateTime(enactmentdate);
					RVar["nenactment"] = nenactment;
					RVar["description"] = description;
					RVar["adate"] = ToSmalldateTime(adate);
					RVar["idinventoryagency"] = idinventoryagency;
					RVar["yvar"] = yvar;
					RVar["nvar"] = nvar;
					RVar["ct"] = DateTime.Now;
					RVar["lt"] = DateTime.Now;
					RVar["cu"] = "importazione";
					RVar["lu"] = "importazione";
				}


				//Finalmente aggiunge il dettaglio variazione
				DataRow NewVarDetail = MetaAssetVarDetail.Get_New_Row(RVar, AssetVarDetail);
				NewVarDetail["amount"] = Reader.getCurrField("importo");
				NewVarDetail["description"] = Reader.getCurrField("descrdet");
				NewVarDetail["idinventory"] = idinventory;

				object idinv = DBNull.Value;
				string filterinvtree = QHC.CmpEq("codeinv", Reader.getCurrField("codeclass"));
				if (InvTree.Select(filterinvtree).Length > 0) {
					idinv = InvTree.Select(filterinvtree)[0]["idinv"];
				}
				else {
					idinv = 0;
					SpeedSaver.AddError("Classificazione inventariale di codice " + Reader.getCurrField("codeclass") +
					                    " non trovata per la variazione " + nvar.ToString() + " del " +
					                    yvar.ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber());
				}

				NewVarDetail["idinv"] = idinv;

				object idmot = CheckAssetLoadMotive(AssetLoadMotive,
					Reader.getCurrField("codicecausalecar").ToString(),
					Reader.getCurrField("descrcausalecar").ToString());

				NewVarDetail["idmot"] = idmot;
				NewVarDetail["ct"] = DateTime.Now;
				NewVarDetail["lt"] = DateTime.Now;
				NewVarDetail["cu"] = "importazione";
				NewVarDetail["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		Hashtable hashInventory = null;

		object Checkinventory(DataTable Inventory, string codeinventory, string description,
			object idinventoryagency, object idinventorykind) {
			int hCrono = metaprofiler.StartTimer("Checkinventory()");
			if (hashInventory == null) {
				hashInventory = new Hashtable();
				foreach (DataRow RH in Inventory.Rows) {
					hashInventory[RH["codeinventory"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashInventory[codeinventory.ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idinventory"];
			}

			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			DataRow NewInventory = MetaInventory.Get_New_Row(null, Inventory);
			NewInventory["idinventoryagency"] = idinventoryagency;
			NewInventory["idinventorykind"] = idinventorykind;
			NewInventory["startnumber"] = 0;
			NewInventory["flag"] = 0;
			NewInventory["active"] = 'S';
			NewInventory["codeinventory"] = codeinventory;
			NewInventory["description"] = description;
			NewInventory["ct"] = DateTime.Now;
			NewInventory["lt"] = DateTime.Now;
			NewInventory["cu"] = "importazione";
			NewInventory["lu"] = "importazione";
			hashInventory[codeinventory.ToString().ToUpper()] = NewInventory;
			metaprofiler.StopTimer(hCrono);
			return NewInventory["idinventory"];
		}

		Hashtable hashInventoryAgency = null;

		object CheckinventoryAgency(DataTable InventoryAgency, string codeinventoryagency, string description) {
			int hCrono = metaprofiler.StartTimer("CheckinventoryAgency()");
			if (hashInventoryAgency == null) {
				hashInventoryAgency = new Hashtable();
				foreach (DataRow RH in InventoryAgency.Rows) {
					hashInventoryAgency[RH["codeinventoryagency"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashInventoryAgency[codeinventoryagency.ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idinventoryagency"];
			}

			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			DataRow NewInventoryAgency = MetaInventoryAgency.Get_New_Row(null, InventoryAgency);
			NewInventoryAgency["codeinventoryagency"] = codeinventoryagency;
			NewInventoryAgency["description"] = description;
			NewInventoryAgency["active"] = 'S';
			NewInventoryAgency["ct"] = DateTime.Now;
			NewInventoryAgency["lt"] = DateTime.Now;
			NewInventoryAgency["cu"] = "importazione";
			NewInventoryAgency["lu"] = "importazione";
			hashInventoryAgency[codeinventoryagency.ToString().ToUpper()] = NewInventoryAgency;
			metaprofiler.StopTimer(hCrono);
			return NewInventoryAgency["idinventoryagency"];
		}


		Hashtable hashInventoryKind = null;

		object CheckinventoryKind(DataTable Inventorykind, string codeinventorykind, string description) {
			int hCrono = metaprofiler.StartTimer("CheckinventoryKind()");
			if (hashInventoryKind == null) {
				hashInventoryKind = new Hashtable();
				foreach (DataRow RH in Inventorykind.Rows) {
					hashInventoryKind[RH["codeinventorykind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashInventoryKind[codeinventorykind.ToUpper()] as DataRow;
			;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idinventorykind"];
			}

			MetaData MetaInventoryKind = Meta.Dispatcher.Get("inventorykind");
			DataRow NewInventoryKind = MetaInventoryKind.Get_New_Row(null, Inventorykind);
			NewInventoryKind["codeinventorykind"] = codeinventorykind;
			NewInventoryKind["description"] = description;
			NewInventoryKind["flag"] = 1; //Considera lo sconto ai fini della val. del cespite
			NewInventoryKind["active"] = 'S';
			NewInventoryKind["ct"] = DateTime.Now;
			NewInventoryKind["lt"] = DateTime.Now;
			NewInventoryKind["cu"] = "importazione";
			NewInventoryKind["lu"] = "importazione";
			hashInventoryKind[codeinventorykind.ToString().ToUpper()] = NewInventoryKind;
			metaprofiler.StopTimer(hCrono);
			return NewInventoryKind["idinventorykind"];
		}

		Hashtable hashAssetLoadKind = null;

		object CheckAssetLoadKind(DataTable AssetLoadKind, string codeassetloadkind, string description,
			object idinventory) {
			int hCrono = metaprofiler.StartTimer("CheckAssetLoadKind()");
			if (hashAssetLoadKind == null) {
				hashAssetLoadKind = new Hashtable();
				foreach (DataRow RH in AssetLoadKind.Rows) {
					hashAssetLoadKind[RH["codeassetloadkind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashAssetLoadKind[codeassetloadkind.ToUpper()] as DataRow;
			;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idassetloadkind"];
			}

			MetaData MetaAssetLoadKind = Meta.Dispatcher.Get("assetloadkind");
			DataRow NewAssetLoadKind = MetaAssetLoadKind.Get_New_Row(null, AssetLoadKind);
			NewAssetLoadKind["codeassetloadkind"] = codeassetloadkind;
			NewAssetLoadKind["description"] = description;
			NewAssetLoadKind["flag"] = 0; //Riparte da 0 ad ogni esercizio
			NewAssetLoadKind["startnumber"] = 0; //Num.iniziale 0
			NewAssetLoadKind["idinventory"] = idinventory;
			NewAssetLoadKind["active"] = 'S';
			NewAssetLoadKind["ct"] = DateTime.Now;
			NewAssetLoadKind["lt"] = DateTime.Now;
			NewAssetLoadKind["cu"] = "importazione";
			NewAssetLoadKind["lu"] = "importazione";
			hashAssetLoadKind[codeassetloadkind.ToString().ToUpper()] = NewAssetLoadKind;
			metaprofiler.StopTimer(hCrono);
			return NewAssetLoadKind["idassetloadkind"];
		}

		Hashtable hashInvTree = null;

		object Checkidinvtree(DataTable InvTree, string codeinv) {
			if (hashInvTree == null) {
				hashInvTree = new Hashtable();
				foreach (DataRow RH in InvTree.Rows) {
					hashInvTree[RH["codeinv"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashInvTree[codeinv.ToUpper()] as DataRow;
			;
			if (RID != null) {
				return RID["idinv"];
			}

			return DBNull.Value;
		}

		Hashtable hashLocation = null;

		object CheckidLocation(DataTable Location, string locationcode) {
			if (hashLocation == null) {
				hashLocation = new Hashtable();
				foreach (DataRow RH in Location.Rows) {
					hashLocation[RH["locationcode"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashLocation[locationcode.ToUpper()] as DataRow;
			;
			if (RID != null) {
				return RID["idlocation"];
			}

			return DBNull.Value;
		}

		Hashtable hashCostpartition = null;

		object CheckidCostpartition(DataTable Costpartition, string costpartitioncode) {
			if (hashCostpartition == null) {
				hashCostpartition = new Hashtable();
				foreach (DataRow RH in Costpartition.Rows) {
					hashCostpartition[RH["costpartitioncode"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashCostpartition[costpartitioncode.ToUpper()] as DataRow;
			if (RID != null) {
				return RID["idcostpartition"];
			}

			return DBNull.Value;
		}


		Hashtable hashAssetLoadMotive = null;

		object CheckAssetLoadMotive(DataTable AssetLoadMotive, string codemot, string description) {
			int hCrono = metaprofiler.StartTimer("CheckAssetLoadMotive()");
			if (hashAssetLoadMotive == null) {
				hashAssetLoadMotive = new Hashtable();
				foreach (DataRow RH in AssetLoadMotive.Rows) {
					hashAssetLoadMotive[RH["codemot"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashAssetLoadMotive[codemot.ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idmot"];
			}

			MetaData MetaAssetLoadMotive = Meta.Dispatcher.Get("assetloadmotive");
			DataRow NewAssetLoadMotive = MetaAssetLoadMotive.Get_New_Row(null, AssetLoadMotive);
			NewAssetLoadMotive["codemot"] = codemot;
			NewAssetLoadMotive["description"] = description;
			NewAssetLoadMotive["flag"] = 1; //Cespite nuovo
			NewAssetLoadMotive["active"] = 'S'; //Cespite nuovo
			NewAssetLoadMotive["ct"] = DateTime.Now;
			NewAssetLoadMotive["lt"] = DateTime.Now;
			NewAssetLoadMotive["cu"] = "importazione";
			NewAssetLoadMotive["lu"] = "importazione";
			hashAssetLoadMotive[codemot.ToUpper()] = NewAssetLoadMotive;
			metaprofiler.StopTimer(hCrono);
			return NewAssetLoadMotive["idmot"];
		}


		Hashtable hashAssetUnloadMotive = null;

		object CheckAssetUnloadMotive(DataTable AssetUnloadMotive, string codemot, string description) {
			int hCrono = metaprofiler.StartTimer("CheckAssetLoadMotive()");
			if (hashAssetUnloadMotive == null) {
				hashAssetUnloadMotive = new Hashtable();
				foreach (DataRow RH in AssetUnloadMotive.Rows) {
					hashAssetUnloadMotive[RH["codemot"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashAssetUnloadMotive[codemot.ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idmot"];
			}

			MetaData MetaAssetUnloadMotive = Meta.Dispatcher.Get("assetunloadmotive");
			DataRow NewAssetUnloadMotive = MetaAssetUnloadMotive.Get_New_Row(null, AssetUnloadMotive);
			NewAssetUnloadMotive["codemot"] = codemot;
			NewAssetUnloadMotive["description"] = description;
			NewAssetUnloadMotive["active"] = 'S'; //Cespite nuovo
			NewAssetUnloadMotive["ct"] = DateTime.Now;
			NewAssetUnloadMotive["lt"] = DateTime.Now;
			NewAssetUnloadMotive["cu"] = "importazione";
			NewAssetUnloadMotive["lu"] = "importazione";
			hashAssetUnloadMotive[codemot.ToUpper()] = NewAssetUnloadMotive;
			metaprofiler.StopTimer(hCrono);
			return NewAssetUnloadMotive["idmot"];
		}


		Hashtable hashFinVarKind = null;

		object CheckFinVarKind(DataTable FinVarKind, string codevarkind, string description) {
			int hCrono = metaprofiler.StartTimer("CheckFinVarKind()");
			if (hashFinVarKind == null) {
				hashFinVarKind = new Hashtable();
				foreach (DataRow RH in FinVarKind.Rows) {
					hashFinVarKind[RH["codevarkind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashFinVarKind[codevarkind.ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idfinvarkind"];
			}

			MetaData MetaFinVarKind = Meta.Dispatcher.Get("finvarkind");
			DataRow NewFinVarKind = MetaFinVarKind.Get_New_Row(null, FinVarKind);
			NewFinVarKind["codevarkind"] = codevarkind;
			NewFinVarKind["description"] = description;
			NewFinVarKind["ct"] = DateTime.Now;
			NewFinVarKind["lt"] = DateTime.Now;
			NewFinVarKind["cu"] = "importazione";
			NewFinVarKind["lu"] = "importazione";
			hashFinVarKind[codevarkind.ToUpper()] = NewFinVarKind;
			metaprofiler.StopTimer(hCrono);
			return NewFinVarKind["idfinvarkind"];
		}

		Hashtable hashExpenseYear = null;

		DataRow GetRowExpenseYear(string filter) {
			if (filter == null)
				return null;
			int hCrono = metaprofiler.StartTimer("GetRowExpenseYear()");
			if (hashExpenseYear == null) {
				hashExpenseYear = new Hashtable();
			}

			DataRow RID = hashExpenseYear[filter] as DataRow;
			metaprofiler.StopTimer(hCrono);
			if (RID != null) {
				return RID;
			}
			else {
				DataTable ExpenseView = Conn.RUN_SELECT("expenseview", "*", null, filter, null, false);
				if (ExpenseView.Rows.Count > 0) {
					RID = ExpenseView.Rows[0];
					hashExpenseYear[filter] = RID;
				}
			}

			return RID;
		}

		Hashtable hashEpexpYear = null;

		DataRow GetRowEpexpYear(string filter) {
			if (filter == null)
				return null;

			int hCrono = metaprofiler.StartTimer("GetRowEpexpYear()");
			if (hashEpexpYear == null) {
				hashEpexpYear = new Hashtable();
			}

			DataRow RID = hashEpexpYear[filter] as DataRow;
			metaprofiler.StopTimer(hCrono);
			if (RID != null) {
				return RID;
			}
			else {
				DataTable EpexpView = Conn.RUN_SELECT("epexpview", "*", null, filter, null, false);
				if (EpexpView.Rows.Count > 0) {
					RID = EpexpView.Rows[0];
					hashEpexpYear[filter] = RID;
				}
			}

			return RID;
		}

		Hashtable hashAccMotive = null;

		object CheckAccMotive(DataTable AccMotive, object codemotive) {
			if (codemotive == null || codemotive == DBNull.Value)
				return DBNull.Value;
			int hCrono = metaprofiler.StartTimer("CheckAccMotive()");
			if (hashAccMotive == null) {
				hashAccMotive = new Hashtable();
				foreach (DataRow RH in AccMotive.Rows) {
					hashAccMotive[RH["codemotive"].ToString().ToUpperInvariant()] = RH;
				}
			}

			DataRow RID = hashAccMotive[codemotive.ToString().ToUpperInvariant()] as DataRow;
			metaprofiler.StopTimer(hCrono);
			if (RID != null) {
				return RID["idaccmotive"];
			}

			return DBNull.Value;
		}

		Hashtable hashFinMotive = null;

		object CheckFinMotive(DataTable FincMotive, object codemotive) {
			if (codemotive == null || codemotive == DBNull.Value)
				return DBNull.Value;
			int hCrono = metaprofiler.StartTimer("CheckFinMotive()");
			if (hashFinMotive == null) {
				hashFinMotive = new Hashtable();
				foreach (DataRow RH in FincMotive.Rows) {
					hashFinMotive[RH["codemotive"].ToString().ToUpperInvariant()] = RH;
				}
			}

			DataRow RID = hashFinMotive[codemotive.ToString().ToUpperInvariant()] as DataRow;
			metaprofiler.StopTimer(hCrono);
			if (RID != null) {
				return RID["idfinmotive"];
			}

			return DBNull.Value;
		}


		object CheckInventoryAmortization(DataTable InventoryAmortization,
			string codeinventoryamortization, string description) {
			string filterinv = QHC.CmpEq("codeinventoryamortization", codeinventoryamortization);
			if (InventoryAmortization.Select(filterinv).Length > 0)
				return InventoryAmortization.Select(filterinv)[0]["idinventoryamortization"];
			MetaData MetaInventoryAmortization = Meta.Dispatcher.Get("inventoryamortization");
			DataRow NewInventoryAmortization = MetaInventoryAmortization.Get_New_Row(null, InventoryAmortization);
			NewInventoryAmortization["codeinventoryamortization"] = codeinventoryamortization;
			NewInventoryAmortization["description"] = description;
			NewInventoryAmortization["active"] = 'S';
			//bit 0  0=annuale, 1= mensile
			//bit 1  1=ufficiale
			//bit 2  1= applica sval. a valore comprensivo di iva
			//bit 3  1=ammortamento, 0=svalutazione
			NewInventoryAmortization["flag"] = 0 + 2 + 0 + 8; //annuale, ufficiale, non applica sval a iva, ammortamento
			NewInventoryAmortization["ct"] = DateTime.Now;
			NewInventoryAmortization["lt"] = DateTime.Now;
			NewInventoryAmortization["cu"] = "importazione";
			NewInventoryAmortization["lu"] = "importazione";
			return NewInventoryAmortization["idinventoryamortization"];
		}


		string[] tracciato_buonicar = new string[] {
			"codtipobuonocar;Codice tipo buono carico;Stringa;20",
			"descrtipobuonocar;Descr. tipo buono carico;Stringa;50",
			"codiceinv;Codice inventario;Stringa;20",
			"descrinv;Descrizione inventario;Stringa;50",
			"codeinvkind;Codice Tipo Inventario;Stringa;20",
			"descrinvkind;Descr. Tipo Inventario;Stringa;50",
			"codeinvagency;Codice Ente Inventariale;Stringa;20",
			"descrinvagency;Descrizione Ente Inventariale;Stringa;150",
			"annobuono;Anno buono carico;Intero;4",
			"numbuono;Numero buono carico;Intero;8",
			"codicecausalecar;Codice Causale di carico;Stringa;10",
			"descrcausalecar;Descrizione Causale di carico;Stringa;30",
			"doc;Documento buono carico;Stringa;35",
			"datadoc;Data documento buono carico;Data;8",
			"provv;Documento buono carico;Stringa;150",
			"dataprovv;Data documento buono carico;Data;8",
			"descrizione;Descrizione buono carico;Stringa;150",
			"databuono;Data buono carico;Data;8",
			"datarat;Data ratifica buono carico;Data;8",
			"cedente;Codice cedente (di anagrafica);Intero;10"
		};

		private void btnBuoniCar_Click(object sender, EventArgs e) {
			ImportaBuoniCar();
		}

		bool ImportaBuoniCar() {
			LeggiFile Reader = GetReader(tracciato_buonicar);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaBuoniCarico();

			DataTable AssetLoad = D.Tables["assetload"];
			MetaData MetaAssetLoad = Meta.Dispatcher.Get("assetload");
			MetaAssetLoad.SetDefaults(AssetLoad);

			DataTable AssetLoadKind = D.Tables["assetloadkind"];
			MetaData MetaAssetLoadKind = Meta.Dispatcher.Get("assetloadkind");
			MetaAssetLoadKind.SetDefaults(AssetLoadKind);


			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);

			DataTable InventoryAgency = D.Tables["inventoryagency"];
			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			MetaInventoryAgency.SetDefaults(InventoryAgency);

			DataTable InventoryKind = D.Tables["inventorykind"];
			MetaData MetaInventoryKind = Meta.Dispatcher.Get("inventorykind");
			MetaInventoryKind.SetDefaults(InventoryKind);

			DataTable AssetLoadMotive = D.Tables["assetloadmotive"];
			MetaData MetaAssetLoadMotive = Meta.Dispatcher.Get("assetloadmotive");
			MetaAssetLoadMotive.SetDefaults(AssetLoadMotive);


			//Conn.RUN_SELECT_INTO_TABLE(AssetLoad, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAgency, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadMotive, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("assetloadkind");
			tosync.Add("inventorykind");
			tosync.Add("inventoryagency");
			tosync.Add("inventory");
			tosync.Add("assetloadmotive");
			InitSpeedSaver(Conn, tosync);





			int num = 0;
			Reader.GetNext();
			int maxidassetload = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("assetload", null, "max(idassetload)")) + 1;
			while (Reader.DataPresent()) {
				object yassetload = Reader.getCurrField("annobuono");
				object nassetload = Reader.getCurrField("numbuono");



				//Aggiunge le informazioni di Ente Inventariale ove necessario
				string descrinvag = Reader.getCurrField("descrinvagency").ToString();
				string codeinvag = Reader.getCurrField("codeinvagency").ToString();
				object idinventoryagency = CheckinventoryAgency(InventoryAgency, codeinvag, descrinvag);

				//Aggiunge le informazioni di Tipo Inventario ove necessario
				string descrinvkind = Reader.getCurrField("descrinvkind").ToString();
				string codeinvkind = Reader.getCurrField("codeinvkind").ToString();
				object idinvkind = CheckinventoryKind(InventoryKind, codeinvkind, descrinvkind);

				//Aggiunge le informazioni di inventario ove necessario
				string descrinv = Reader.getCurrField("descrinv").ToString();
				string codeinv = Reader.getCurrField("codiceinv").ToString();
				object idinventory = Checkinventory(Inventory, codeinv, descrinv, idinventoryagency, idinvkind);

				//Aggiunge le informazioni di Tipo Buono Carico ove necessario
				string descrassetloadkind = Reader.getCurrField("descrtipobuonocar").ToString();
				string codeassetloadkind = Reader.getCurrField("codtipobuonocar").ToString();
				object idassetloadkind = CheckAssetLoadKind(AssetLoadKind, codeassetloadkind, descrassetloadkind,
					idinventory);


				if (yassetload != DBNull.Value) {
					string filterassload = QHS.AppAnd(QHS.CmpEq("idassetloadkind", idassetloadkind),
						QHS.CmpEq("yassetload", yassetload),
						QHS.CmpEq("nassetload", nassetload));
					if (Conn.RUN_SELECT_COUNT("assetload", filterassload, false) > 0) {
						Reader.GetNext();
						continue; //Buono già presente
					}

					string filterassloadc = QHC.AppAnd(QHC.CmpEq("idassetloadkind", idassetloadkind),
						QHC.CmpEq("yassetload", yassetload),
						QHC.CmpEq("nassetload", nassetload));
					if (AssetLoad.Select(filterassloadc).Length > 0) {
						Reader.GetNext();
						continue; //Tipo Buono già presente
					}

					object idmot = DBNull.Value;
					if (Reader.getCurrField("codicecausalecar").ToString() != "") {
						idmot = CheckAssetLoadMotive(AssetLoadMotive,
							Reader.getCurrField("codicecausalecar").ToString(),
							Reader.getCurrField("descrcausalecar").ToString());
					}

					DataRow NewAssetLoad = AssetLoad.NewRow();
					NewAssetLoad["idassetload"] = maxidassetload++;
					NewAssetLoad["idassetloadkind"] = idassetloadkind;
					NewAssetLoad["yassetload"] = yassetload;
					NewAssetLoad["nassetload"] = nassetload;
					NewAssetLoad["transmitted"] = "N";
					NewAssetLoad["ratificationdate"] = ToSmalldateTime(Reader.getCurrField("datarat"));
					NewAssetLoad["doc"] = Reader.getCurrField("doc");
					NewAssetLoad["docdate"] = ToSmalldateTime(Reader.getCurrField("datadoc"));
					NewAssetLoad["enactment"] = Reader.getCurrField("provv");
					NewAssetLoad["enactmentdate"] = ToSmalldateTime(Reader.getCurrField("dataprovv"));
					NewAssetLoad["description"] = Reader.getCurrField("descrizione");
					NewAssetLoad["adate"] = ToSmalldateTime(Reader.getCurrField("databuono"));
					NewAssetLoad["idreg"] = Reader.getCurrField("cedente");
					NewAssetLoad["idmot"] = idmot;
					NewAssetLoad["ct"] = DateTime.Now;
					NewAssetLoad["lt"] = DateTime.Now;
					NewAssetLoad["cu"] = "importazione";
					NewAssetLoad["lu"] = "importazione";
					AssetLoad.Rows.Add(NewAssetLoad);
				}

				num++;









				if (num >= 1000) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					D.Tables["assetload"].Clear();
					num = 0;
				}

				Reader.GetNext();
			}

			if (num > 0) {
				//Salva i dati
				SaveData(D, false);
				D.Tables["assetload"].Clear();
			}

			Reader.Close();
			return ShowMessages();

		}


		string[] tracciato_buoniscar = new string[] {
			"codtipobuonoscar;Codice tipo buono scarico;Stringa;20",
			"descrtipobuonoscar;Descr. tipo buono scarico;Stringa;50",
			"codiceinv;Codice inventario;Stringa;20",
			"descrinv;Descrizione inventario;Stringa;50",
			"codeinvkind;Codice Tipo Inventario;Stringa;20",
			"descrinvkind;Descr. Tipo Inventario;Stringa;50",
			"codeinvagency;Codice Ente Inventariale;Stringa;20",
			"descrinvagency;Descrizione Ente Inventariale;Stringa;150",
			"annobuono;Anno buono scarico;Intero;4",
			"numbuono;Numero buono scarico;Intero;8",
			"codicecausalescar;Codice Causale di scarico;Stringa;10",
			"descrcausalescar;Descrizione Causale di scarico;Stringa;30",
			"doc;Documento buono scarico;Stringa;35",
			"datadoc;Data documento buono scarico;Data;8",
			"provv;Documento buono scarico;Stringa;150",
			"dataprovv;Data documento buono scarico;Data;8",
			"descrizione;Descrizione buono scarico;Stringa;150",
			"databuono;Data buono scarico;Data;8",
			"datarat;Data ratifica buono scarico;Data;8",
			"cessionario;Codice cessionario (di anagrafica);Intero;10"
		};

		private void btnBuoniScar_Click(object sender, EventArgs e) {
			importaBuoniScarico();
		}

		bool importaBuoniScarico() {
			LeggiFile Reader = GetReader(tracciato_buoniscar);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaBuoniScarico();

			DataTable AssetUnload = D.Tables["assetunload"];
			MetaData MetaAssetUnload = Meta.Dispatcher.Get("assetunload");
			MetaAssetUnload.SetDefaults(AssetUnload);

			DataTable AssetUnloadKind = D.Tables["assetunloadkind"];
			MetaData MetaAssetUnloadKind = Meta.Dispatcher.Get("assetunloadkind");
			MetaAssetUnloadKind.SetDefaults(AssetUnloadKind);


			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);

			DataTable InventoryAgency = D.Tables["inventoryagency"];
			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			MetaInventoryAgency.SetDefaults(InventoryAgency);

			DataTable InventoryKind = D.Tables["inventorykind"];
			MetaData MetaInventoryKind = Meta.Dispatcher.Get("inventorykind");
			MetaInventoryKind.SetDefaults(InventoryKind);

			DataTable AssetUnloadMotive = D.Tables["assetunloadmotive"];
			MetaData MetaAssetUnloadMotive = Meta.Dispatcher.Get("assetunloadmotive");
			MetaAssetUnloadMotive.SetDefaults(AssetUnloadMotive);


			//Conn.RUN_SELECT_INTO_TABLE(AssetUnload, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetUnloadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAgency, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetUnloadMotive, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("assetunloadkind");
			tosync.Add("inventorykind");
			tosync.Add("inventoryagency");
			tosync.Add("inventory");
			tosync.Add("assetunloadmotive");
			InitSpeedSaver(Conn, tosync);




			int num = 0;
			Reader.GetNext();
			int maxidassetunload = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("assetunload", null, "max(idassetunload)")) +
			                       1;
			while (Reader.DataPresent()) {
				num++;
				object yassetunload = Reader.getCurrField("annobuono");
				object nassetunload = Reader.getCurrField("numbuono");

				//Aggiunge le informazioni di Ente Inventariale ove necessario
				string descrinvag = Reader.getCurrField("descrinvagency").ToString();
				string codeinvag = Reader.getCurrField("codeinvagency").ToString();
				object idinventoryagency = CheckinventoryAgency(InventoryAgency, codeinvag, descrinvag);


				//Aggiunge le informazioni di Tipo Inventario ove necessario
				string descrinvkind = Reader.getCurrField("descrinvkind").ToString();
				string codeinvkind = Reader.getCurrField("codeinvkind").ToString();
				object idinvkind = CheckinventoryKind(InventoryKind, codeinvkind, descrinvkind);

				//Aggiunge le informazioni di inventario ove necessario
				string descrinv = Reader.getCurrField("descrinv").ToString();
				string codeinv = Reader.getCurrField("codiceinv").ToString();
				object idinventory = Checkinventory(Inventory, codeinv, descrinv, idinventoryagency, idinvkind);


				//Aggiunge le informazioni di Tipo Buono Carico ove necessario
				string descrassetunloadkind = Reader.getCurrField("descrtipobuonoscar").ToString();
				string codeassetunloadkind = Reader.getCurrField("codtipobuonoscar").ToString();
				object idassetunloadkind = CheckAssetUnloadKind(AssetUnloadKind, codeassetunloadkind,
					descrassetunloadkind,
					idinventory);


				//string filterassunload = QHC.AppAnd(QHC.CmpEq("idassetunloadkind", idassetunloadkind),
				//            QHC.CmpEq("yassetunload", yassetunload),
				//            QHC.CmpEq("nassetunload", nassetunload));
				//if (AssetUnload.Select(filterassunload).Length > 0) {
				//    Reader.GetNext();
				//    continue; //Buono già presente
				//}


				object idmot = CheckAssetUnloadMotive(AssetUnloadMotive,
					Reader.getCurrField("codicecausalescar").ToString(),
					Reader.getCurrField("descrcausalescar").ToString());


				if (yassetunload != DBNull.Value) {
					DataRow NewAssetLoad = AssetUnload.NewRow();
					NewAssetLoad["idassetunload"] = maxidassetunload++;
					NewAssetLoad["idassetunloadkind"] = idassetunloadkind;
					NewAssetLoad["yassetunload"] = yassetunload;
					NewAssetLoad["nassetunload"] = nassetunload;
					NewAssetLoad["transmitted"] = "N";
					NewAssetLoad["ratificationdate"] = ToSmalldateTime(Reader.getCurrField("datarat"));
					NewAssetLoad["doc"] = Reader.getCurrField("doc");
					NewAssetLoad["docdate"] = ToSmalldateTime(Reader.getCurrField("datadoc"));
					NewAssetLoad["enactment"] = Reader.getCurrField("provv");
					NewAssetLoad["enactmentdate"] = ToSmalldateTime(Reader.getCurrField("dataprovv"));
					NewAssetLoad["description"] = Reader.getCurrField("descrizione");
					NewAssetLoad["adate"] = ToSmalldateTime(Reader.getCurrField("databuono"));
					NewAssetLoad["idreg"] = Reader.getCurrField("cessionario");
					NewAssetLoad["idmot"] = idmot;
					NewAssetLoad["ct"] = DateTime.Now;
					NewAssetLoad["lt"] = DateTime.Now;
					NewAssetLoad["cu"] = "importazione";
					NewAssetLoad["lu"] = "importazione";
					AssetUnload.Rows.Add(NewAssetLoad);
				}

				if (num >= 1000) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					D.Tables["assetunload"].Clear();
					num = 0;
				}

				Reader.GetNext();
			}

			if (num > 0) {
				//Salva i dati
				SaveData(D, false);
				D.Tables["assetunload"].Clear();
			}

			Reader.Close();
			return ShowMessages();
		}

		string[] tracciato_cespiti = new string[] {
			"tipocespite;Tipo Cespite (Cespite/Accessorio);Codificato;1;C|A",
			"codiceinv;Codice Inventario;Stringa;20",
			"descrinv;Descrizione Inventario;Stringa;50",
			"codeinvkind;Codice Tipo Inventario;Stringa;20",
			"descrinvkind;Descr. Tipo Inventario;Stringa;50",
			"codeinvagency;Codice Ente Inventariale;Stringa;20",
			"descrinvagency;Descrizione Ente Inventariale;Stringa;150",
			"numinv;Numero di inventario;Intero;8",
			"nprogr;Numero progressivo. 1 per i cespiti, 2 o più per gli accessori;Intero;5",
			//
			"codiceinv_prec;Codice Inventario di Provenienza;Stringa;20",
			"descrinv_prec;Descrizione Inventario di Provenienza;Stringa;50",
			"codeinvkind_prec;Codice Tipo Inventario di Provenienza;Stringa;20",
			"descrinvkind_prec;Descr. Tipo Inventario di Provenienza;Stringa;50",
			"codeinvagency_prec;Codice Ente Inventariale di Provenienza;Stringa;20",
			"descrinvagency_prec;Descrizione Ente Inventariale di Provenienza;Stringa;150",
			"numinv_prec;Numero di inventario di Provenienza;Intero;8",
			"nprogr_prec;Numero progressivo. di Provenienza, 1 per i cespiti, 2 o più per gli accessori;Intero;5",
			//
			"codiceinv_succ;Codice Inventario Successivo;Stringa;20",
			"descrinv_succ;Descrizione Inventario Successivo;Stringa;50",
			"codeinvkind_succ;Codice Tipo Inventario Successivo;Stringa;20",
			"descrinvkind_succ;Descr. Tipo Inventario Successivo;Stringa;50",
			"codeinvagency_succ;Codice Ente Inventariale Successivo;Stringa;20",
			"descrinvagency_succ;Descrizione Ente Inventariale Successivo;Stringa;150",
			"numinv_succ;Numero di inventario Successivo;Intero;8",
			"nprogr_succ;Numero progressivo Successivo, 1 per i cespiti, 2 o più per gli accessori;Intero;5",
			//
			"inizioesist;Inizio esistenza;Data;8",
			"codiceclass;Codice classificazione inventariale;Stringa;20",
			"descr;Descrizione Cespite;Stringa;150",
			"impon;Imponibile;Numero;22",
			"iva;Iva;Numero;22",
			"ivadetr;Iva Detraibile;Numero;22",
			"ivaperc;Aliquota Iva;Numero;22",
			"scontoperc;Percentuale Sconto;Numero;22",
			"codicecausalecar;Codice Causale di carico;Stringa;10",
			"descrcausalecar;Descrizione Causale di carico;Stringa;30",
			"codicecedente;Codice Cedente (di anagrafica);Intero;10",
			"datacar;Data di Carico;Data;8",
			"posseduto;Posseduto(S/N);Codificato;1;S|N",
			"includibuonocar;Da includere in buono di carico (S/N);Codificato;1;S|N",
			"codicetipobuonocar;Codice tipo buono carico;Stringa;20",
			"annobuonocar;Anno buono carico;Intero;4",
			"numbuonocar;Numero buono carico;Intero;8",
			"resp;Responsabile;Stringa;150",
			"codeubic;Codice ubicazione;Stringa;50",
			"subresp;SubConsegnatario;Stringa;150",
			"codiceupb;Codice UPB;Stringa;50",
			"includibuonoscar;Da includere in buono di scarico (S/N);Codificato;1;S|N",
			"codicetipobuonoscar;Codice tipo buono scarico;Stringa;20",
			"annobuonoscar;Anno buono scarico;Intero;4",
			"numbuonoscar;Numero buono scarico;Intero;8",
			"note;Note;Stringa;400",
			"intcode;Codice Listino;Stringa;50",
			"campiaggiuntivi;Campi Aggiuntivi Cespite;Stringa;4000",
			// Riferimenti alla riga del contratto passivo
			"codice_cpassivo;Codice tipo ordine;Stringa;20",
			"anno_cpassivo;Anno ordine;Intero;4",
			"numero_cpassivo;Numero ordine;Intero;8",
			"nriga_cpassivo;Numero riga ordine;Intero;6",
			//Riferimento alla riga fattura
			"codtipo_fattura; Codice Tipo Fattura;Stringa;20",
			"anno_fattura;Anno;Intero;4",
			"num_fattura;Numero Fattura;Intero;8",
			"nriga_fattura;Numero riga;Intero;6",
			"rfid;rfid;Stringa;30"
		};

		string[] tracciato_responsabilicespiti = new string[] {
			"codiceinv;Codice Inventario;Stringa;20",
			"descrinv;Descrizione Inventario;Stringa;50",
			"numinv;Numero di inventario;Intero;8",
			"nprogrmanager;Numero progressivo;Intero;5",
			"datainizio;Data inizio validità;Data;8",
			"manager;Denominazione manager;Stringa;150"
		};

		string[] tracciato_ubicazionicespiti = new string[] {
			"codiceinv;Codice Inventario;Stringa;20",
			"descrinv;Descrizione Inventario;Stringa;50",
			"numinv;Numero di inventario;Intero;8",
			"nprogrlocation;Numero progressivo;Intero;5",
			"datainizio;Data inizio validità;Data;8",
			"codeubic;Codice ubicazione;Stringa;50"
		};

		string[] tracciato_subconsegnataricespiti = new string[] {
			"codiceinv;Codice Inventario;Stringa;20",
			"descrinv;Descrizione Inventario;Stringa;50",
			"numinv;Numero di inventario;Intero;8",
			"nprogrsubmanager;Numero progressivo;Intero;5",
			"datainizio;Data inizio validità;Data;8",
			"subconsegnatario;Denominazione subconsegnatario;Stringa;150"
		};

		private void btnCespiti_Click(object sender, EventArgs e) {
			ImportaCespiti();
		}

		bool ImportaCespiti() {
			LeggiFile Reader = GetReader(tracciato_cespiti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaCespiti();



			DataTable AssetUnloadKind = D.Tables["assetunloadkind"];
			MetaData MetaAssetUnloadKind = Meta.Dispatcher.Get("assetunloadkind");
			MetaAssetUnloadKind.SetDefaults(AssetUnloadKind);

			DataTable AssetLoadKind = D.Tables["assetloadkind"];
			MetaData MetaAssetLoadKind = Meta.Dispatcher.Get("assetloadkind");
			MetaAssetLoadKind.SetDefaults(AssetLoadKind);


			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);

			DataTable InventoryAgency = D.Tables["inventoryagency"];
			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			MetaInventoryAgency.SetDefaults(InventoryAgency);

			DataTable InventoryKind = D.Tables["inventorykind"];
			MetaData MetaInventoryKind = Meta.Dispatcher.Get("inventorykind");
			MetaInventoryKind.SetDefaults(InventoryKind);

			DataTable InvTree = D.Tables["inventorytree"];
			MetaData MetaInvTree = Meta.Dispatcher.Get("inventorytree");
			MetaInvTree.SetDefaults(InvTree);

			DataTable AssetLoadMotive = D.Tables["assetloadmotive"];
			MetaData MetaAssetLoadMotive = Meta.Dispatcher.Get("assetloadmotive");
			MetaAssetLoadMotive.SetDefaults(AssetLoadMotive);

			DataTable Division = D.Tables["division"];
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaDivision.SetDefaults(Division);


			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);

			DataTable Location = D.Tables["location"];
			MetaData MetaLocation = Meta.Dispatcher.Get("location");
			MetaLocation.SetDefaults(Location);

			DataTable AssetAcquire = D.Tables["assetacquire"];
			MetaData MetaAssetAcquire = Meta.Dispatcher.Get("locationassetacquire");
			MetaAssetAcquire.SetDefaults(AssetAcquire);

			DataTable Asset = D.Tables["asset"];
			MetaData MetaAsset = Meta.Dispatcher.Get("asset");
			MetaAsset.SetDefaults(Asset);

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}


			DataTable AssetToLink = D.Tables["assettolink"];
			MetaData MetaAssetToLink = Meta.Dispatcher.Get("assettolink");
			MetaAsset.SetDefaults(AssetToLink);

			DataTable AssetView = D.Tables["assetview"];

			DataTable InvoiceKind = D.Tables["invoicekind"];
			Conn.RUN_SELECT_INTO_TABLE(InvoiceKind, null, null, null, false);

			Conn.RUN_SELECT_INTO_TABLE(AssetUnloadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAgency, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InvTree, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadMotive, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("codedivision", "Fittizia"), null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetToLink, null, null, null, false);

			Conn.RUN_SELECT_INTO_TABLE(D.Tables["list"], null, null, null, false);
			Dictionary<string, int> vociListino = new Dictionary<string, int>();
			foreach (DataRow r in D.Tables["list"].Select()) {
				vociListino[r["intcode"].ToString().ToLower()] = CfgFn.GetNoNullInt32(r["idlist"]);
			}

			List<string> tosync = new List<string>();
			tosync.Add("assetunloadkind");
			tosync.Add("assetloadkind");
			tosync.Add("inventorykind");
			tosync.Add("inventoryagency");
			tosync.Add("inventory");
			tosync.Add("inventorytree");
			tosync.Add("assetloadmotive");
			tosync.Add("manager");
			tosync.Add("location");
			tosync.Add("division");
			tosync.Add("assettolink");
			InitSpeedSaver(Conn, tosync);



			Hashtable Hash_idasset = new Hashtable();

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}

			int nmax_assetacquire = CfgFn.GetNoNullInt32(
				                        Conn.DO_READ_VALUE("assetacquire", null, "max(nassetacquire)")) + 1;

			int nmax_asset = CfgFn.GetNoNullInt32(
				                 Conn.DO_READ_VALUE("asset", null, "max(idasset)")) + 1;






			int num = 0;
			string codeinv_asset_prec = "";

			Reader.GetNext();
			while (Reader.DataPresent()) {
				string descrinv = Reader.getCurrField("descrinv").ToString();
				string codeinv = Reader.getCurrField("codiceinv").ToString();
				// numero dei cespiti elaborati >= 100 oppure cambio struttura inventariale
				if ((num >= 1000) || ((codeinv_asset_prec != codeinv) && (codeinv_asset_prec != ""))) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					D.Tables["assetacquire"].Clear();
					D.Tables["asset"].Clear(); // svuota asset e tabelle figlie
					D.Tables["assetlocation"].Clear();
					D.Tables["assetmanager"].Clear();
					D.Tables["assetsubmanager"].Clear();
					num = 0;
				}

				num++;
				int flag_assetacquire = 0;
				//bit 0= includi in buono carico
				//bit 1= cespite posseduto (0=nuovo)
				//bit 2= accessorio (0=cespite principale)
				string tipo = Reader.getCurrField("tipocespite").ToString().ToUpper();
				string posseduto = Reader.getCurrField("posseduto").ToString().ToUpper();
				if (tipo == "A") flag_assetacquire += 4;
				string includi_buonocar = Reader.getCurrField("includibuonocar").ToString().ToUpper();
				if (includi_buonocar == "S") flag_assetacquire += 1;
				if (posseduto == "S") flag_assetacquire += 2;

				int flag_asset = 0;
				//bit 0= includi in buono scarico
				//bit 1= cespite pronto per lo scarico
				string includi_buonoscar = Reader.getCurrField("includibuonoscar").ToString().ToUpper();
				if (includi_buonoscar == "S") flag_asset += 1;

				object ninventory = Reader.getCurrField("numinv");
				int idpiece = CfgFn.GetNoNullInt32(Reader.getCurrField("nprogr"));

				object yassetunload = Reader.getCurrField("annobuonoscar");
				object nassetunload = Reader.getCurrField("numbuonoscar");

				//Aggiunge le informazioni di Ente Inventariale ove necessario
				string descrinvag = Reader.getCurrField("descrinvagency").ToString();
				string codeinvag = Reader.getCurrField("codeinvagency").ToString();
				object idinventoryagency = CheckinventoryAgency(InventoryAgency, codeinvag, descrinvag);


				//Aggiunge le informazioni di Tipo Inventario ove necessario
				string descrinvkind = Reader.getCurrField("descrinvkind").ToString();
				string codeinvkind = Reader.getCurrField("codeinvkind").ToString();
				object idinvkind = CheckinventoryKind(InventoryKind, codeinvkind, descrinvkind);

				//Aggiunge le informazioni di inventario ove necessario
				object idinventory = Checkinventory(Inventory, codeinv, descrinv, idinventoryagency, idinvkind);
				object idmot = CheckAssetLoadMotive(AssetLoadMotive,
					Reader.getCurrField("codicecausalecar").ToString(),
					Reader.getCurrField("descrcausalecar").ToString());

				object manager = Reader.getCurrField("resp");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision);


				object submanager = Reader.getCurrField("subresp");
				object idsubman = DBNull.Value;
				if (submanager != DBNull.Value) idsubman = GetManager(Manager, submanager.ToString(), iddivision);



				object idassetunload = DBNull.Value;
				object codeassetunloadkind = Reader.getCurrField("codicetipobuonoscar");
				if (codeassetunloadkind != DBNull.Value) {
					string filterassunloadkind = QHC.CmpEq("codeassetunloadkind", codeassetunloadkind);
					object idassetunloadkind = DBNull.Value;
					if (AssetUnloadKind.Select(filterassunloadkind).Length > 0) {
						idassetunloadkind = AssetUnloadKind.Select(filterassunloadkind)[0]["idassetunloadkind"];
						string filterassunload = QHS.AppAnd(
							QHS.CmpEq("idassetunloadkind", idassetunloadkind),
							QHS.CmpEq("yassetunload", yassetunload),
							QHS.CmpEq("nassetunload", nassetunload));
						idassetunload = Conn.DO_READ_VALUE("assetunload", filterassunload, "idassetunload");
						if (idassetunload == DBNull.Value || idassetunload == null) {
							SpeedSaver.AddError("Il buono di scarico " + codeassetunloadkind + "/" +
							                    nassetunload.ToString() + " del " + yassetunload.ToString() +
							                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						SpeedSaver.AddError("Il tipo buono di scarico " + codeassetunloadkind +
						                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
					}
				}

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (!HUpb.ContainsKey(codeupb)) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:"
						                    + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					idupb = HUpb[codeupb];
				}

				object idassetload = DBNull.Value;
				object codeassetloadkind = Reader.getCurrField("codicetipobuonocar");
				object yassetload = Reader.getCurrField("annobuonocar");
				object nassetload = Reader.getCurrField("numbuonocar");
				idassetload = DBNull.Value;
				if (codeassetloadkind != DBNull.Value) {

					object idassetloadkind = GetidAssetLoadKind(AssetLoadKind, codeassetloadkind);
					if (idassetloadkind != DBNull.Value) {
						idassetload = GetidAssetLoad(idassetloadkind, yassetload, nassetload);
						if (idassetload == DBNull.Value || idassetload == null) {
							SpeedSaver.AddError("Il buono di carico " + codeassetloadkind + "/" +
							                    nassetload.ToString() + " del " + yassetload.ToString() +
							                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						SpeedSaver.AddError("Il tipo buono di carico " + codeassetloadkind +
						                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
					}
				}


				object idinv = Checkidinvtree(InvTree, Reader.getCurrField("codiceclass").ToString());
				;
				if (idinv == DBNull.Value) {
					idinv = 0;
					SpeedSaver.AddError("Classificazione inventariale di codice " + Reader.getCurrField("codiceclass") +
					                    " non trovata per il cespite n. " + ninventory.ToString() +
					                    " dell'inventario " +
					                    codeinv.ToString() +
					                    " Riga:" + Reader.GetCurrRowNumber());
				}

				object locationcode = Reader.getCurrField("codeubic");
				object idlocation = DBNull.Value;
				if (locationcode != DBNull.Value) {
					idlocation = CheckidLocation(Location, locationcode.ToString());

					if (idlocation == DBNull.Value) {
						SpeedSaver.AddError("Ubicazione di codice " + locationcode +
						                    " non trovata per il cespite n. " + ninventory.ToString() +
						                    " dell'inventario " + codeinv.ToString() +
						                    " Riga:" + Reader.GetCurrRowNumber());
					}
				}

				// Aggiunge le informazioni relativi ai cambi di inventario
				// che hanno coinvolto il cespite
				// Cerco di individuare il cespite di provenienza e destinazione 
				// se è stato già salvato su DB

				//Ente Inventariale precedente
				string descrinvag_prec = Reader.getCurrField("descrinvagency_prec").ToString();
				string codeinvag_prec = Reader.getCurrField("codeinvagency_prec").ToString();
				object idinventoryagency_prec = DBNull.Value;
				if (codeinvag_prec != "")
					idinventoryagency_prec = CheckinventoryAgency(InventoryAgency, codeinvag_prec, descrinvag_prec);

				//Tipo Inventario precedente
				string descrinvkind_prec = Reader.getCurrField("descrinvkind_prec").ToString();
				string codeinvkind_prec = Reader.getCurrField("codeinvkind_prec").ToString();
				object idinvkind_prec = DBNull.Value;
				if (codeinvkind_prec != "")
					idinvkind_prec = CheckinventoryKind(InventoryKind, codeinvkind_prec, descrinvkind_prec);

				//Inventario precedente
				string descrinv_prec = Reader.getCurrField("descrinv_prec").ToString();
				string codeinv_prec = Reader.getCurrField("codiceinv_prec").ToString();
				object idinventory_prec = DBNull.Value;
				if (codeinv_prec != "")
					idinventory_prec = Checkinventory(Inventory, codeinv_prec, descrinv_prec,
						idinventoryagency_prec, idinvkind_prec);
				//
				//Ente Inventariale successivo
				string descrinvag_succ = Reader.getCurrField("descrinvagency_succ").ToString();
				string codeinvag_succ = Reader.getCurrField("codeinvagency_succ").ToString();
				object idinventoryagency_succ = DBNull.Value;
				if (codeinvag_succ != "")
					idinventoryagency_succ = CheckinventoryAgency(InventoryAgency, codeinvag_succ, descrinvag_succ);

				//Tipo Inventario successivo
				string descrinvkind_succ = Reader.getCurrField("descrinvkind_succ").ToString();
				string codeinvkind_succ = Reader.getCurrField("codeinvkind_succ").ToString();
				object idinvkind_succ = DBNull.Value;
				if (codeinvkind_succ != "")
					idinvkind_succ = CheckinventoryKind(InventoryKind, codeinvkind_succ, descrinvkind_succ);

				//Inventario successivo
				string descrinv_succ = Reader.getCurrField("descrinv_succ").ToString();
				string codeinv_succ = Reader.getCurrField("codiceinv_succ").ToString();
				object idinventory_succ = DBNull.Value;
				if (codeinv_succ != "")
					idinventory_succ = Checkinventory(Inventory, codeinv_succ, descrinv_succ,
						idinventoryagency_succ, idinvkind_succ);

				//Numero di inventario e progressivo accessorio di provenienza e di destinazione
				object ninventory_prec = Reader.getCurrField("numinv_prec");
				int idpiece_prec = CfgFn.GetNoNullInt32(Reader.getCurrField("nprogr_prec"));

				object ninventory_succ = Reader.getCurrField("numinv_succ");
				int idpiece_succ = CfgFn.GetNoNullInt32(Reader.getCurrField("nprogr_succ"));

				object description = Reader.getCurrField("descr");
				if (description == DBNull.Value) {
					description = '.';
				}

				object intCode = Reader.getCurrField("intcode");
				object idlist = DBNull.Value;
				if (intCode != DBNull.Value) {
					if (vociListino.ContainsKey(intCode.ToString().ToLower())) {
						idlist = vociListino[intCode.ToString().ToLower()];
					}
					else {
						SpeedSaver.AddError("Voce di listino di codice " + intCode +
						                    " non trovata per il cespite n. " + ninventory.ToString() +
						                    " dell'inventario " + codeinv.ToString() +
						                    " Riga:" + Reader.GetCurrRowNumber());
					}
				}

				DataRow NewAssetAcquire = AssetAcquire.NewRow();
				NewAssetAcquire["nassetacquire"] = nmax_assetacquire++;
				NewAssetAcquire["abatable"] = CfgFn.GetNoNullDecimal(Reader.getCurrField("ivadetr"));
				NewAssetAcquire["adate"] = ToSmalldateTime(Reader.getCurrField("datacar"));
				NewAssetAcquire["description"] = description;
				NewAssetAcquire["transmitted"] = "N";
				NewAssetAcquire["discount"] = Reader.getCurrField("scontoperc");
				NewAssetAcquire["idreg"] = Reader.getCurrField("codicecedente");
				NewAssetAcquire["startnumber"] = ninventory; //1 carico - 1 cespite pari numero
				NewAssetAcquire["number"] = 1;
				NewAssetAcquire["tax"] = Reader.getCurrField("iva");
				NewAssetAcquire["taxable"] = Reader.getCurrField("impon");
				NewAssetAcquire["taxrate"] = Reader.getCurrField("ivaperc");
				NewAssetAcquire["idinventory"] = idinventory;
				NewAssetAcquire["idmot"] = idmot;
				NewAssetAcquire["idupb"] = idupb;
				NewAssetAcquire["idinv"] = idinv;
				NewAssetAcquire["idlist"] = idlist;
				NewAssetAcquire["idassetload"] = idassetload;
				NewAssetAcquire["flag"] = flag_assetacquire;
				NewAssetAcquire["ct"] = DateTime.Now;
				NewAssetAcquire["lt"] = DateTime.Now;
				NewAssetAcquire["cu"] = "importazione";
				NewAssetAcquire["lu"] = "importazione";

				if (Reader.getCurrField("codice_cpassivo") != DBNull.Value) {
					object idmankind = Reader.getCurrField("codice_cpassivo");
					object yman = Reader.getCurrField("anno_cpassivo");
					object nman = Reader.getCurrField("numero_cpassivo");
					object idgroup = Reader.getCurrField("nriga_cpassivo");

					string filterman = QHS.AppAnd(
						QHS.CmpEq("idmankind", idmankind), QHS.CmpEq("yman", yman),
						QHS.CmpEq("nman", nman), QHS.CmpEq("idgroup", idgroup));
					if (Conn.RUN_SELECT_COUNT("mandatedetail", filterman, false) == 0) {
						SpeedSaver.AddError("Dettaglio ordine  non trovato con filtro: " + filterman
						                                                                 + " alla riga " +
						                                                                 Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;

					}

					NewAssetAcquire["idmankind"] = idmankind;
					NewAssetAcquire["yman"] = yman;
					NewAssetAcquire["nman"] = nman;
					NewAssetAcquire["rownum"] = idgroup;
				}


				//TASK 10815

				string codtipofattura = Reader.getCurrField("codtipo_fattura").ToString();


				if (Reader.getCurrField("codtipo_fattura") != DBNull.Value) {
					object idinvoicekind = CheckExistsInvoiceKind(InvoiceKind, codtipofattura);
					if (idinvoicekind == null) {
						SpeedSaver.AddError("Tipo fattura  non trovato : " + codtipofattura + " alla riga " +
						                    Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					object yinv = Reader.getCurrField("anno_fattura");
					object ninv = Reader.getCurrField("num_fattura");
					object rownum = Reader.getCurrField("nriga_fattura");

					string filterinv = QHS.AppAnd(
						QHS.CmpEq("idinvkind", idinvoicekind), QHS.CmpEq("yinv", yinv),
						QHS.CmpEq("ninv", ninv), QHS.CmpEq("rownum", rownum));
					if (Conn.RUN_SELECT_COUNT("invoicedetail", filterinv, false) == 0) {
						SpeedSaver.AddError("Dettaglio fattura  non trovato con filtro: " + filterinv
						                                                                  + " alla riga " +
						                                                                  Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}


					NewAssetAcquire["idinvkind"] = idinvoicekind;
					NewAssetAcquire["yinv"] = yinv;
					NewAssetAcquire["ninv"] = ninv;
					NewAssetAcquire["invrownum"] = rownum;

				}


				AssetAcquire.Rows.Add(NewAssetAcquire);

				DataRow NewAsset = Asset.NewRow();
				string hashkey = ninventory.ToString() + "/" + codeinv;
				object idasset = DBNull.Value;
				if (idpiece == 1) {
					idasset = nmax_asset++;
					Hash_idasset[hashkey] = idasset;
				}
				else {
					if (Hash_idasset[hashkey] != null) {
						idasset = Hash_idasset[hashkey];
					}
					else {
						idasset = Conn.DO_READ_VALUE("assetview",
							QHS.AppAnd(QHS.CmpEq("ninventory", ninventory),
								QHS.CmpEq("idinventory", idinventory),
								QHS.CmpEq("idpiece", 1)), "idasset");
						if (idasset == null || idasset == DBNull.Value) {
							SpeedSaver.AddError(
								"E' necessario ordinare i cespiti in modo che gli accessori seguano i " +
								"cespiti principali. Problema con l'accessorio " +
								ninventory.ToString() + "-" + idpiece.ToString() + "/" + codeinv +
								" dell'inventario di codice " + idinventory +
								" Riga:" + Reader.GetCurrRowNumber());
							Reader.GetNext();
							continue;
						}
					}
				}

				// Cerco nel DB prima il cespite eventuale di destinazione 
				// Se esiste allora effettuo un inserimento nel DataTable, valorizzando idasset_prev e idpiece_prev
				object idasset_successivo = DBNull.Value;
				object idpiece_successivo = DBNull.Value;

				if (codeinv_succ != "") {

					/*
					  string filter_succ = QHS.AppAnd(QHS.CmpEq("codeinventory", codeinv_succ),
					                                QHS.CmpEq("ninventory", ninventory_succ),
					                                QHS.CmpEq("idpiece", idpiece_succ));
					if (Conn.RUN_SELECT_COUNT("assetview", filter_succ, false) > 0) {
					    idasset_successivo = Conn.DO_READ_VALUE("assetview", filter_succ, "idasset");
					    idpiece_successivo = Conn.DO_READ_VALUE("assetview", filter_succ, "idpiece");
					    string filter_asset_succ = QHC.AppAnd(QHC.CmpEq("idasset", idasset_successivo),
					                                          QHC.CmpEq("idpiece", idpiece_successivo));
					    Conn.RUN_SELECT_INTO_TABLE(Asset, null, filter_asset_succ, null, false);
					    // Verifico che sia presente invece in memoria
					    DataRow[] Asset_Succ = Asset.Select(filter_asset_succ);
					    if (Asset_Succ.Length > 0) {
					        Asset_Succ[0]["idasset_prev"] = idasset;
					        Asset_Succ[0]["idpiece_prev"] = idpiece;
					    }
					}
					// Verifico che il successivo sia presente invece in memoria  
					// perchè appartenente alla stessa struttura: 
					// (trattasi di cambio del solo numero inventario pertanto potrebbe rientrare
					// nell'attuale ciclo di elaborazione se non è stato già salvato sul db)
					else
					    if (codeinv == codeinv_succ) {
					        filter_succ = QHS.AppAnd(QHS.CmpEq("codeinventory", codeinv_succ),
					                                 QHS.CmpEq("ninventory", ninventory_succ),
					                                 QHS.CmpEq("idpiece", idpiece_succ));
					        DataRow[] Asset_Succ = Asset.Select(filter_succ);
					        if (Asset_Succ.Length > 0) {
					            Asset_Succ[0]["idasset_prev"] = idasset;
					            Asset_Succ[0]["idpiece_prev"] = idpiece;
					        }
					    }
					  */
					DataRow NewAssetToLink = AssetToLink.NewRow();
					NewAssetToLink["idasset"] = idasset;
					NewAssetToLink["idpiece"] = idpiece;
					NewAssetToLink["ninventory_tolink"] = ninventory_succ;
					NewAssetToLink["idpiece_tolink"] = idpiece_succ;
					NewAssetToLink["idinventory_tolink"] = idinventory_succ;
					NewAssetToLink["kind"] = "T";
					NewAssetToLink["ct"] = DateTime.Now;
					NewAssetToLink["cu"] = "importazione";
					NewAssetToLink["lt"] = DateTime.Now;
					NewAssetToLink["lu"] = "importazione";
					D.Tables["assettolink"].Rows.Add(NewAssetToLink);
				}

				object idasset_precedente = DBNull.Value;
				object idpiece_precedente = DBNull.Value;

				if (codeinv_prec != "") {
					/*
					string filter_prec = QHS.AppAnd(QHS.CmpEq("codeinventory", codeinv_prec),
					                                QHS.CmpEq("ninventory", ninventory_prec),
					                                QHS.CmpEq("idpiece", idpiece_prec));
					string filter_prec_dataset = QHC.AppAnd(QHC.CmpEq("codeinventory", codeinv_prec),
					                              QHC.CmpEq("ninventory", ninventory_prec),
					                              QHC.CmpEq("idpiece", idpiece_prec));

					if (Conn.RUN_SELECT_COUNT("assetview", filter_prec, false) > 0) {
					    idasset_precedente = Conn.DO_READ_VALUE("assetview", filter_prec, "idasset");
					    idpiece_precedente = Conn.DO_READ_VALUE("assetview", filter_prec, "idpiece");
					}
					else {
					    // Verifico che il precedente sia presente invece in memoria 
					    // perchè appartenente  alla stessa struttura: 
					    // (trattasi di cambio del solo numero inventario pertanto potrebbe rientrare
					    // nell'attuale ciclo di elaborazione se non è stato già salvato sul db)
					    if (codeinv == codeinv_prec) {
					        DataRow[] Asset_Prec = Asset.Select(filter_prec_dataset);
					        if (Asset_Prec.Length > 0) {
					            idasset_precedente = Asset_Prec[0]["idasset"];
					            idpiece_precedente = Asset_Prec[0]["idpiece"];
					        }
					    }
					}
					 * */
					DataRow NewAssetToLink = AssetToLink.NewRow();
					NewAssetToLink["idasset"] = idasset;
					NewAssetToLink["idpiece"] = idpiece;
					NewAssetToLink["ninventory_tolink"] = ninventory_prec;
					NewAssetToLink["idpiece_tolink"] = idpiece_prec;
					NewAssetToLink["idinventory_tolink"] = idinventory_prec;
					NewAssetToLink["kind"] = "F";
					NewAssetToLink["ct"] = DateTime.Now;
					NewAssetToLink["cu"] = "importazione";
					NewAssetToLink["lt"] = DateTime.Now;
					NewAssetToLink["lu"] = "importazione";
					D.Tables["assettolink"].Rows.Add(NewAssetToLink);
				}

				NewAsset["idasset"] = idasset;
				NewAsset["idpiece"] = idpiece;
				NewAsset["idasset_prev"] = idasset_precedente;
				NewAsset["idpiece_prev"] = idpiece_precedente;
				NewAsset["lifestart"] = Reader.getCurrField("inizioesist");
				NewAsset["nassetacquire"] = NewAssetAcquire["nassetacquire"];
				NewAsset["ninventory"] = ninventory;
				NewAsset["transmitted"] = "N";
				NewAsset["idassetunload"] = idassetunload;
				NewAsset["multifield"] = Reader.getCurrField("campiaggiuntivi");
				NewAsset["idinventory"] = idinventory;
				NewAsset["rfid"] = Reader.getCurrField("rfid");

				NewAsset["flag"] = flag_asset;
				NewAsset["ct"] = DateTime.Now;
				NewAsset["lt"] = DateTime.Now;
				NewAsset["cu"] = "importazione";
				NewAsset["lu"] = "importazione";
				NewAsset["txt"] = Reader.getCurrField("note").ToString();

				//Aggiunge il collegamento a ubicazione ove necessario
				if (idlocation != DBNull.Value && tipo == "C") {
					DataRow NewAssetLocation = D.Tables["assetlocation"].NewRow();
					NewAssetLocation["idassetlocation"] = 1;
					NewAssetLocation["idasset"] = idasset;
					NewAssetLocation["idlocation"] = idlocation;
					NewAssetLocation["ct"] = DateTime.Now;
					NewAssetLocation["lt"] = DateTime.Now;
					NewAssetLocation["cu"] = "importazione";
					NewAssetLocation["lu"] = "importazione";
					// valorizza ubicazione corrente
					NewAsset["idcurrlocation"] = idlocation;
					D.Tables["assetlocation"].Rows.Add(NewAssetLocation);
				}

				//Aggiunge il collegamento al responsabile ove necessario
				if (idman != DBNull.Value && tipo == "C") {
					DataRow NewAssetManager = D.Tables["assetmanager"].NewRow();
					NewAssetManager["idassetmanager"] = 1;
					NewAssetManager["idasset"] = idasset;
					NewAssetManager["idman"] = idman;
					NewAssetManager["ct"] = DateTime.Now;
					NewAssetManager["lt"] = DateTime.Now;
					NewAssetManager["cu"] = "importazione";
					NewAssetManager["lu"] = "importazione";
					// valorizza responsabile corrente
					NewAsset["idcurrman"] = idman;
					D.Tables["assetmanager"].Rows.Add(NewAssetManager);
				}

				//Aggiunge il collegamento al subconsegnatario ove necessario
				if (idsubman != DBNull.Value && tipo == "C") {
					DataRow NewAssetSubManager = D.Tables["assetsubmanager"].NewRow();
					NewAssetSubManager["idassetsubmanager"] = 1;
					NewAssetSubManager["idasset"] = idasset;
					NewAssetSubManager["idmanager"] = idsubman;
					NewAssetSubManager["ct"] = DateTime.Now;
					NewAssetSubManager["lt"] = DateTime.Now;
					NewAssetSubManager["cu"] = "importazione";
					NewAssetSubManager["lu"] = "importazione";
					// valorizza subconsegnatario corrente
					NewAsset["idcurrsubman"] = idsubman;
					D.Tables["assetsubmanager"].Rows.Add(NewAssetSubManager);
				}

				Asset.Rows.Add(NewAsset);

				codeinv_asset_prec = codeinv;
				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				return ShowMessages();
			}



			if (!SaveData(D, true)) return false;
			D.Tables["asset"].Clear(); // svuota asset e tabelle figlie
			D.Tables["assetlocation"].Clear();
			D.Tables["assetmanager"].Clear();


			if (AssetToLink.Select().Length > 0) {
				string deleteDoppioni = " DELETE FROM ASSETTOLINK WHERE " +
				                        " (SELECT COUNT(*) FROM ASSETTOLINK AS A " +
				                        " WHERE ASSETTOLINK.idinventory_tolink = A.idinventory_tolink " +
				                        " AND   ASSETTOLINK.ninventory_tolink  = A.ninventory_tolink " +
				                        " AND   ASSETTOLINK.idpiece_tolink     = A.idpiece_tolink " +
				                        " AND   ASSETTOLINK.kind = A.kind " +
				                        " ) >1 ";
				Conn.SQLRunner(deleteDoppioni);

			}

			DataRow[] AssetToLink_Succ = AssetToLink.Select(QHC.CmpEq("kind", "T"));
			if (AssetToLink_Succ.Length > 0) {
				string updateTo = " UPDATE 	ASSET  " +
				                  " SET 	ASSET.idasset_prev = ASSETTOLINK.idasset, " +
				                  " ASSET.idpiece_prev = ASSETTOLINK.idpiece " +
				                  " FROM  	ASSETTOLINK " +
				                  " JOIN  	ASSET ASSETLINKED " +
				                  " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
				                  " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
				                  " JOIN  ASSETACQUIRE ASSETACQUIRELINKED " +
				                  " ON  ASSETACQUIRELINKED.nassetacquire = ASSETLINKED.nassetacquire " +
				                  " AND  ASSETACQUIRELINKED.idinventory = ASSETTOLINK.idinventory_tolink " +
				                  " WHERE KIND = 'T'";
				Conn.SQLRunner(updateTo);
			}

			DataRow[] AssetToLink_Prec = AssetToLink.Select(QHC.CmpEq("kind", "F"));
			if (AssetToLink_Prec.Length > 0) {
				string updateFrom = " UPDATE 	ASSET  " +
				                    " SET 	ASSET.idasset_prev = ASSETLINKED.idasset, " +
				                    " ASSET.idpiece_prev = ASSETLINKED.idpiece " +
				                    " FROM  	ASSETVIEW ASSETLINKED " +
				                    " JOIN  	ASSETTOLINK " +
				                    " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
				                    " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
				                    " AND ASSETLINKED.idinventory = ASSETTOLINK.idinventory_tolink  " +
				                    " WHERE ASSETTOLINK.KIND = 'F' AND " +
				                    " ASSETTOLINK.idasset =  ASSET.idasset  AND " +
				                    " ASSETTOLINK.idpiece =  ASSET.idpiece  AND " +
				                    " ASSET.idasset_prev IS NULL ";
				Conn.SQLRunner(updateFrom);
			}

			return true;

		}

		string[] tracciato_ammortamenti = new string[] {
			"codiceinv;Codice inventario;Stringa;20",
			"numinv;Numero di inventario;Intero;8",
			"numprog;Numero progressivo cespite (1 per cespiti, >1 per accessori);Intero;5",
			"codtipoamm;Codice tipo ammortamento;Stringa;20",
			"descrtipoamm;Descrizione tipo ammortamento;Stringa;50",
			"valiniziale;Valore iniziale ai fini dell'ammortamento;Numero;22",
			"percamm;Percentuale ammortamento;Numero;22",
			"dataamm;Data ammortamento;Data;8",
			"codicetipobuonoscar;Codice tipo buono scarico;Stringa;20",
			"annobuonoscar;Anno buono scarico;Intero;4",
			"numbuonoscar;Numero buon scarico;Intero;8",
			"includibuonoscar;Da includere in buono di scarico (S/N);Codificato;1;S|N",
			"descr;Descrizione ammortamento;Stringa;150"
		};

		Hashtable hashAssetUnloadKind = null;

		object CheckAssetUnloadKind(DataTable AssetUnloadKind, string codeassetunloadkind, string description,
			object idinventory) {
			int hCrono = metaprofiler.StartTimer("CheckAssetUnloadKind()");
			if (hashAssetUnloadKind == null) {
				hashAssetUnloadKind = new Hashtable();
				foreach (DataRow RH in AssetUnloadKind.Rows) {
					hashAssetUnloadKind[RH["codeassetunloadkind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashAssetUnloadKind[codeassetunloadkind.ToUpper()] as DataRow;
			if (RID != null) {
				metaprofiler.StopTimer(hCrono);
				return RID["idassetunloadkind"];
			}

			MetaData MetaAssetUnloadKind = Meta.Dispatcher.Get("assetunloadkind");
			DataRow NewAssetUnloadKind = MetaAssetUnloadKind.Get_New_Row(null, AssetUnloadKind);
			NewAssetUnloadKind["codeassetunloadkind"] = codeassetunloadkind;
			NewAssetUnloadKind["description"] = description;
			NewAssetUnloadKind["flag"] = 0; //Riparte da 0 ad ogni esercizio
			NewAssetUnloadKind["startnumber"] = 0; //Num.iniziale 0
			NewAssetUnloadKind["idinventory"] = idinventory;
			NewAssetUnloadKind["ct"] = DateTime.Now;
			NewAssetUnloadKind["lt"] = DateTime.Now;
			NewAssetUnloadKind["cu"] = "importazione";
			NewAssetUnloadKind["lu"] = "importazione";
			hashAssetUnloadKind[codeassetunloadkind.ToString().ToUpper()] = NewAssetUnloadKind;
			metaprofiler.StopTimer(hCrono);
			return NewAssetUnloadKind["idassetunloadkind"];
		}


		object GetidAssetUnloadKind(DataTable AssUnloadKind, object codeassetunloadkind) {
			if (hashAssetUnloadKind == null) {
				hashAssetUnloadKind = new Hashtable();
				foreach (DataRow R in AssUnloadKind.Rows) {
					hashAssetUnloadKind[R["codeassetunloadkind"].ToString().ToUpper()] = R;
				}
			}

			DataRow RF = hashAssetUnloadKind[codeassetunloadkind.ToString().ToUpper()] as DataRow;
			if (RF != null) return RF["idassetunloadkind"];
			return DBNull.Value;
		}

		object GetidAssetLoadKind(DataTable AssLoadKind, object codeassetloadkind) {
			if (hashAssetLoadKind == null) {
				hashAssetLoadKind = new Hashtable();
				foreach (DataRow R in AssLoadKind.Rows) {
					hashAssetLoadKind[R["codeassetloadkind"].ToString().ToUpper()] = R;
				}
			}

			DataRow RF = hashAssetLoadKind[codeassetloadkind.ToString().ToUpper()] as DataRow;
			if (RF != null) return RF["idassetloadkind"];
			return DBNull.Value;
		}



		Hashtable hAssUnload = null;

		object GetidAssetUnload(DataTable AssUnload, object idunloadkind, object yassunl, object nassunl) {
			string key = idunloadkind.ToString().ToUpper() + "/" + yassunl.ToString() + "/" + nassunl.ToString();
			if (hAssUnload == null) {
				hAssUnload = new Hashtable();
				foreach (DataRow R in AssUnload.Rows) {
					string FR = R["idassetunloadkind"].ToString().ToUpper() + "/" +
					            R["yassetunload"].ToString() + "/" + R["nassetunload"];
					hAssUnload[FR] = R;
				}
			}

			DataRow RF = hAssUnload[key] as DataRow;
			if (RF != null) return RF["idassetunload"];
			return DBNull.Value;
		}

		Hashtable hAssLoad = null;

		object GetidAssetLoad(object idloadkind, object yassload, object nassload) {
			string key = idloadkind.ToString().ToUpper() + "/" + yassload.ToString() + "/" + nassload.ToString();
			if (hAssLoad == null) {
				hAssLoad = new Hashtable();
			}

			DataRow RF = hAssLoad[key] as DataRow;
			if (RF != null) return RF["idassetload"];
			object res = Conn.DO_READ_VALUE("assetload",
				QHS.AppAnd(QHS.CmpEq("idassetloadkind", idloadkind), QHS.CmpEq("yassetload", yassload),
					QHS.CmpEq("nassetload", nassload)), "idassetload");
			if (res == null) res = DBNull.Value;
			return res;
		}


		private void btnAmmortamenti_Click(object sender, EventArgs e) {
			ImportaAmmortamenti();
		}

		bool ImportaAmmortamenti() {
			LeggiFile Reader = GetReader(tracciato_ammortamenti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaAmmortamenti();


			DataTable AssetAmortization = D.Tables["assetamortization"];
			MetaData MetaAssetAmortization = Meta.Dispatcher.Get("assetamortization");
			MetaAssetAmortization.SetDefaults(AssetAmortization);

			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);


			DataTable AssetUnloadKind = D.Tables["assetunloadkind"];
			MetaData MetaAssetUnloadKind = Meta.Dispatcher.Get("assetunloadkind");
			MetaAssetUnloadKind.SetDefaults(AssetUnloadKind);

			DataTable InventoryAmortization = D.Tables["inventoryamortization"];
			MetaData MetaInventoryAmortization = Meta.Dispatcher.Get("inventoryamortization");
			MetaInventoryAmortization.SetDefaults(InventoryAmortization);

			DataTable AssetUnload = D.Tables["assetunload"];


			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetUnloadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAmortization, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetUnload, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("assetunloadkind");
			tosync.Add("inventory");
			tosync.Add("inventoryamortization");
			tosync.Add("assetunload");
			InitSpeedSaver(Conn, tosync);




			int num = 0;

			Reader.GetNext();
			//int maxidassetload = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("assetload", null, "max(idassetload)")) + 1;
			while (Reader.DataPresent()) {
				object perc = Reader.getCurrField("percamm");
				if (CfgFn.GetNoNullDecimal(perc) >= 0) {
					Reader.GetNext();
					continue;
				}

				if (num >= 1000) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					D.Tables["assetamortization"].Clear();
					num = 0;
				}

				num++;



				string codeinventory = Reader.getCurrField("codiceinv").ToString();
				object idinventory = DBNull.Value;
				string filteridinv = QHC.CmpEq("codeinventory", codeinventory);
				if (Inventory.Select(filteridinv).Length == 0) {
					SpeedSaver.AddError("Codice inventario " + codeinventory + " non trovato. Riga" +
					                    Reader.GetCurrRowNumber());
					idinventory = 0;
					;
				}
				else {
					idinventory = Inventory.Select(filteridinv)[0]["idinventory"];
				}

				int ninventory = CfgFn.GetNoNullInt32(Reader.getCurrField("numinv"));
				int idpiece = CfgFn.GetNoNullInt32(Reader.getCurrField("numprog"));

				//Determina idasset da idinventory+ninventory
				string filterasset = QHS.AppAnd(
					QHS.CmpEq("A1.idinventory", idinventory),
					QHS.CmpEq("A.ninventory", ninventory),
					QHS.CmpEq("A.idpiece", 1));

				object idasset = Conn.DO_SYS_CMD(
					"SELECT A.idasset from asset A join assetacquire A1 on A.nassetacquire =A1.nassetacquire WHERE " +
					filterasset, false);

				//Conn.DO_READ_VALUE("assetview", filterasset, "idasset");
				//if (idasset == null) idasset = 1; // poi questo deve essere tolto
				if (idasset == DBNull.Value || idasset == null) {
					SpeedSaver.AddError("Cespite " + ninventory.ToString() + "/" + codeinventory +
					                    " non trovato. Riga:" +
					                    Reader.GetCurrRowNumber());
					idasset = 0;
				}

				object yassetunload = Reader.getCurrField("annobuonoscar");
				object nassetunload = Reader.getCurrField("numbuonoscar");


				object idassetunload = DBNull.Value;
				object codeassetunloadkind = Reader.getCurrField("codicetipobuonoscar");
				if (codeassetunloadkind != DBNull.Value) {
					object idassetunloadkind = GetidAssetUnloadKind(AssetUnloadKind, codeassetunloadkind);
					if (idassetunloadkind != DBNull.Value) {
						idassetunload = GetidAssetUnload(AssetUnload, idassetunloadkind, yassetunload, nassetunload);
						if (idassetunload == DBNull.Value) {
							SpeedSaver.AddError("Il tipo buono di scarico  " + codeassetunloadkind + "/" +
							                    nassetunload.ToString() + " del " + yassetunload.ToString() +
							                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						SpeedSaver.AddError("Il tipo buono di scarico " + codeassetunloadkind +
						                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
					}
				}

				object idinventoryamortization = CheckInventoryAmortization(InventoryAmortization,
					Reader.getCurrField("codtipoamm").ToString(), Reader.getCurrField("descrtipoamm").ToString());

				object includi_buono = Reader.getCurrField("includibuonoscar");
				int flag = 0;
				if (includi_buono.ToString().ToUpper() == "S") flag += 1;
				//if (perc != DBNull.Value) {
				//    perc = -CfgFn.GetNoNullDecimal(perc)/100;
				//}

				DataRow NewAssetAmortization = MetaAssetAmortization.Get_New_Row(null, AssetAmortization);
				NewAssetAmortization["flag"] = flag;
				NewAssetAmortization["transmitted"] = "N";
				NewAssetAmortization["adate"] = ToSmalldateTime(Reader.getCurrField("dataamm"));
				NewAssetAmortization["amortizationquota"] = perc;
				NewAssetAmortization["assetvalue"] = Reader.getCurrField("valiniziale");
				NewAssetAmortization["description"] = Reader.getCurrField("descr");
				NewAssetAmortization["idasset"] = idasset;
				NewAssetAmortization["idpiece"] = idpiece;
				NewAssetAmortization["idassetunload"] = idassetunload;
				NewAssetAmortization["idinventoryamortization"] = idinventoryamortization;


				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		//tracciati: A;B;C;D;E
		// A = nome colonna
		// B = descrizione colonna
		// C = tipo colonna (Intero/Numero/Stringa/Codificato/Data)
		// D = lunghezza
		// E = eventuali valori codificati separati da |


		string[] tracciato_bilancio = new string[] {
			"nliv;Numero Livello Bilancio;Intero;1",
			"descrliv;Descrizione Livello Bilancio;Stringa;50",
			"codicebil;Codice Bilancio;Stringa;50",
			"ordinestampa;Ordine di stampa;Stringa;50",
			"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
			"anno;Anno;intero;4",
			"codiceparentbil;Codice bilancio del nodo PARENT di questo;Stringa;50",
			"descrbil;Descrizione voce bilancio;Stringa;150",
			"resp;Responsabile;Stringa;150",
			"datascad;Data scadenza;Data;8"
		};


		void CheckLivBilancio(DataTable Liv, int Nlevel, string leveldescr, string code, object ayear) {
			//Crea ove assente il livello
			if (Liv.Select(QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("nlevel", Nlevel))).Length > 0) return;
			DataRow RL = Liv.NewRow();
			RL["nlevel"] = Nlevel;
			RL["flag"] = 1; //Imposta tutti i livelli come alfanumerici
			RL["ayear"] = ayear;
			RL["ct"] = DateTime.Now;
			RL["lt"] = DateTime.Now;
			RL["cu"] = "importazione";
			RL["lu"] = "importazione";
			RL["description"] = leveldescr;
			int prevLen = 0;
			for (int j = 1; j < Nlevel; j++) {
				DataRow PrevLiv = Liv.Select(QHC.AppAnd(QHC.CmpEq("nlevel", j), QHC.CmpEq("ayear", ayear)))[0];
				prevLen += CfgFn.GetNoNullInt32(PrevLiv["flag"]) >> 8;
			}

			RL["flag"] = 1 + 2 + 4 + ((code.Length - prevLen) << 8); //alfanum,attivo, riparte da 1
			Liv.Rows.Add(RL);

		}

		string getFilterFin(string codefin, string finpart, object ayear) {
			string f = QHC.CmpEq("codefin", codefin);
			if (finpart.ToString().ToUpper() == "S") {
				f = QHC.AppAnd(f, QHC.BitSet("flag", 0));
			}
			else {
				f = QHC.AppAnd(f, QHC.BitClear("flag", 0));
			}

			f = QHC.AppAnd(f, QHC.CmpEq("ayear", ayear));
			return f;
		}

		string getSqlFilterFin(string codefin, string finpart, object ayear) {
			string f = QHS.CmpEq("codefin", codefin);
			if (finpart.ToString().ToUpper() == "S") {
				f = QHS.AppAnd(f, QHS.BitSet("flag", 0));
			}
			else {
				f = QHS.AppAnd(f, QHS.BitClear("flag", 0));
			}

			f = QHS.AppAnd(f, QHS.CmpEq("ayear", ayear));
			return f;
		}

		string getSqlFilterAcc(string codeacc, object ayear) {
			string f = QHS.CmpEq("codeacc", codeacc);

			f = QHS.AppAnd(f, QHS.CmpEq("ayear", ayear));
			return f;
		}

		string getSqlFilterPlAcc(string codeplaccount, object ayear) {
			string f = QHS.CmpEq("codeplaccount", codeplaccount);

			f = QHS.AppAnd(f, QHS.CmpEq("ayear", ayear));
			return f;
		}

		string getSqlFilterPatrimony(string codepatrimony, object ayear) {
			string f = QHS.CmpEq("codepatrimony", codepatrimony);

			f = QHS.AppAnd(f, QHS.CmpEq("ayear", ayear));
			return f;
		}

		Hashtable hFin = null;

		object getidFin(DataTable Fin, string codefin, string finpart, object ayear) {
			if (hFin == null) {
				hFin = new Hashtable();
				foreach (DataRow R in Fin.Rows) {
					int flag = CfgFn.GetNoNullInt32(R["flag"]);
					string part = (flag & 1) != 0 ? "S" : "E";
					string k = R["codefin"].ToString().ToUpper() + "/" + part + "/" + R["ayear"].ToString();
					hFin[k] = R;
				}
			}

			string kk = codefin.ToString().ToUpper() + "/" + finpart.ToUpper() + "/" + ayear.ToString();
			DataRow res = hFin[kk] as DataRow;
			if (res == null) return DBNull.Value;
			return res["idfin"];
		}

		private void btnBilancio_Click(object sender, EventArgs e) {
			ImportaBilancio();
		}

		Hashtable hAccount = null;

		object getidAcc(DataTable Account, string codeacc, object ayear) {
			if (hAccount == null) {
				hAccount = new Hashtable();
				foreach (DataRow R in Account.Rows) {

					string k = R["codeacc"].ToString().ToUpper() + "/" + R["ayear"].ToString();
					hAccount[k] = R;
				}
			}

			string kk = codeacc.ToString().ToUpper() + "/" + ayear.ToString();
			DataRow res = hAccount[kk] as DataRow;
			if (res == null) return DBNull.Value;
			return res["idacc"];
		}


		bool ImportaBilancio() {
			LeggiFile Reader = GetReader(tracciato_bilancio);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			DataSet D = new vistaBilancio();
			Conn.SQLRunner("ALTER TABLE  FIN DISABLE TRIGGER ALL");
			Conn.SQLRunner("ALTER TABLE  FINLAST DISABLE TRIGGER ALL");
			Conn.SQLRunner("ALTER TABLE  FINLEVEL DISABLE TRIGGER ALL");
			MetaData MetaFin = Meta.Dispatcher.Get("fin");
			MetaData MetaFinlast = Meta.Dispatcher.Get("finlast");
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaData MetaFinlevel = Meta.Dispatcher.Get("finlevel");
			MetaData MetaDivision = Meta.Dispatcher.Get("division");

			DataTable Fin = D.Tables["fin"];
			DataTable Finlast = D.Tables["finlast"];
			DataTable Manager = D.Tables["manager"];
			DataTable Finlevel = D.Tables["finlevel"];
			DataTable Division = D.Tables["division"];


			MetaFin.SetDefaults(Fin);
			MetaFinlast.SetDefaults(Finlast);
			MetaManager.SetDefaults(Manager);
			MetaFinlevel.SetDefaults(Finlevel);
			MetaDivision.SetDefaults(Division);

			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("description", "Fittizia"), null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["fin"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["finlevel"], null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("division");
			tosync.Add("fin");
			tosync.Add("finlevel");
			InitSpeedSaver(Conn, tosync);



			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}


			bool to_repeat = true;
			bool somethingdone = false;
			while (to_repeat) {
				to_repeat = false;
				somethingdone = false;

				Reader.Reset();

				Reader.GetNext();

				while (Reader.DataPresent()) {
					string codefin = Reader.getCurrField("codicebil").ToString();
					string partebil = Reader.getCurrField("partebil").ToString();
					object ayear = Reader.getCurrField("anno");
					object idfinexist = getidFin(Fin, codefin, partebil, ayear);
					if (idfinexist != DBNull.Value) {
						Reader.GetNext();
						continue;
					}

					//individua il nodo parent
					object parcode = Reader.getCurrField("codiceparentbil");
					object RParFin = DBNull.Value;
					if (parcode != DBNull.Value) {
						RParFin = getidFin(Fin, parcode.ToString(), partebil, ayear);

						if (RParFin == DBNull.Value) {
							SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + parcode +
							                      " padre del nodo avente codice " + codefin +
							                      " parte " + partebil + " anno " + ayear.ToString() +
							                      " alla riga:" + Reader.GetCurrRowNumber());

							Reader.GetNext();
							to_repeat = true;
							continue;
						}
					}

					//Aggiunge le informazioni di livello ove necessario
					int Nlev = CfgFn.GetNoNullInt32(Reader.getCurrField("nliv"));
					string levelname = Reader.getCurrField("descrliv").ToString();
					CheckLivBilancio(Finlevel, Nlev, levelname, codefin, ayear);

					Fin.Columns["ayear"].DefaultValue = ayear;
					DataRow Rfin = MetaFin.Get_New_Row(null, Fin);
					RowChange.ClearAutoIncrement(Fin.Columns["codefin"]);
					RowChange.ClearAutoIncrement(Fin.Columns["printingorder"]);
					Rfin["paridfin"] = RParFin;
					Rfin["codefin"] = codefin;
					Rfin["nlevel"] = Nlev;
					Rfin["ayear"] = ayear;
					Rfin["title"] = Reader.getCurrField("descrbil").ToString();
					Rfin["printingorder"] = Reader.getCurrField("ordinestampa").ToString();
					Rfin["ct"] = DateTime.Now;
					Rfin["lt"] = DateTime.Now;
					Rfin["cu"] = "importazione";
					Rfin["lu"] = "importazione";
					int flag = (partebil == "E") ? 0 : 1;
					Rfin["flag"] = flag;
					somethingdone = true;

					string kk = codefin.ToString().ToUpper() + "/" + partebil.ToUpper() + "/" + ayear.ToString();
					hFin[kk] = Rfin;

					Reader.GetNext();
				} //while (Reader.DataPresent()) 


				if (to_repeat && !somethingdone) {
					SpeedSaver.AddError("Ci sono nodi child senza parent,verificare. ");
					to_repeat = false;
				}
			} // while (to_repeat) 


			//Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				Conn.SQLRunner("ALTER TABLE  FIN ENABLE TRIGGER ALL");
				Conn.SQLRunner("ALTER TABLE  FINLAST ENABLE TRIGGER ALL");
				Conn.SQLRunner("ALTER TABLE  FINLEVEL ENABLE TRIGGER ALL");
				return false;
			}

			//Imposta l'ultimo livello come operativo
			int MaxNlev = CfgFn.GetNoNullInt32(Finlevel.Compute("max(nlevel)", null));
			DataRow LastLev = Finlevel.Select(QHC.CmpEq("nlevel", MaxNlev))[0];
			LastLev["flag"] = CfgFn.GetNoNullInt32(LastLev["flag"]) | 2;

			//Ora ricomincia da capo per i finlast
			Reader.Reset();


			Reader.GetNext();
			bool somethingskipped = false;
			while (Reader.DataPresent()) {
				object manager = Reader.getCurrField("resp");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision);

				object expiration = Reader.getCurrField("datascad");

				string codefin = Reader.getCurrField("codicebil").ToString();
				string finpart = Reader.getCurrField("partebil").ToString();
				object ayear = Reader.getCurrField("anno");

				string searchfin = getFilterFin(codefin, finpart, ayear);
				object currid = getidFin(Fin, codefin, finpart, ayear);
				// MessageBox.Show("foglia", codefin + " " + finpart + " " + ayear.ToString() + "chiave " + currid.ToString());
				string search_finchild = QHC.CmpEq("paridfin", currid);
				if (Fin.Select(search_finchild).Length > 0) {
					//Non è una foglia
					if (idman != DBNull.Value || expiration != DBNull.Value) somethingskipped = true;
				}
				else {
					MetaData.SetDefault(Finlast, "idfin", currid);
					DataRow Rfinlast = MetaFinlast.Get_New_Row(null, Finlast);
					MetaData.SetDefault(Finlast, "idfin", 0);
					//MessageBox.Show("foglia", codefin + " " + finpart + " " + ayear.ToString() + "chiave " + Rfinlast["idfin"].ToString());

					Rfinlast["expiration"] = expiration;
					Rfinlast["idman"] = idman;
					Rfinlast["ct"] = DateTime.Now;
					Rfinlast["lt"] = DateTime.Now;
					Rfinlast["cu"] = "importazione";
					Rfinlast["lu"] = "importazione";
				}

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			if (somethingskipped) {
				SpeedSaver.AddWarning("Alcune informazioni su scadenza o responsabile saranno scartate " +
				                      "poiché attribuite a voci articolate.");
			}

			bool res = SaveData(D, true);
			Conn.SQLRunner("ALTER TABLE FIN ENABLE TRIGGER ALL");
			Conn.SQLRunner("ALTER TABLE FINLAST ENABLE TRIGGER ALL");
			Conn.SQLRunner("ALTER TABLE FINLEVEL ENABLE TRIGGER ALL");
			Conn.SQLRunner("exec rebuild_finlink ");
			return res;
		}

		private object ToSmalldateTime(object data) {
			if (data == DBNull.Value)
				return data;
			data = ToCC.getDate(data);
			DateTime d = (DateTime) data;
			DateTime minValue = new DateTime(1900, 1, 1);
			if (d < minValue)
				return minValue;
			DateTime maxValue = new DateTime(2079, 06, 06);
			if (d > maxValue)
				return maxValue;

			return data;
		}

		private object ToDatetime(object data) {
			if (data == DBNull.Value)
				return data;
			data = ToCC.getDate(data);
			DateTime d = (DateTime) data;
			DateTime minValue = new DateTime(1753, 1, 1);
			if (d < minValue)
				return minValue;
			DateTime maxValue = new DateTime(9999, 12, 31);
			if (d > maxValue)
				return maxValue;

			return data;

		}

		private object ToDatetimeNoHours(object data) {
			if (data == DBNull.Value)
				return data;
			data = ToCC.getDate(data);
			DateTime d = (DateTime) data;

			int hours = d.Hour;
			int minutes = d.Minute;
			int seconds = d.Second;

			d = d.AddHours(-hours);
			d = d.AddMinutes(-minutes);
			d = d.AddSeconds(-seconds);

			DateTime minValue = new DateTime(1753, 1, 1);
			if (d < minValue)
				return minValue;
			DateTime maxValue = new DateTime(9999, 12, 31);
			if (d > maxValue)
				return maxValue;

			return d;
		}



		private object ToSmalldateTimeNoHours(object data) {
			if (data == DBNull.Value)
				return data;
			data = ToCC.getDate(data);
			DateTime d = (DateTime) data;

			int hours = d.Hour;
			int minutes = d.Minute;
			int seconds = d.Second;

			d = d.AddHours(-hours);
			d = d.AddMinutes(-minutes);
			d = d.AddSeconds(-seconds);

			DateTime minValue = new DateTime(1900, 1, 1);
			if (d < minValue)
				return minValue;
			DateTime maxValue = new DateTime(2079, 06, 06);
			if (d > maxValue)
				return maxValue;
			return d;
		}


		private object ToConvertDateInDocYear(object data, int ydoc) {
			if (data == DBNull.Value)
				return data;
			data = ToCC.getDate(data);
			DateTime d = (DateTime) data;

			int day = d.Day;
			int month = d.Month;
			int year = d.Year;

			if (year > CfgFn.GetNoNullInt32(ydoc))
				d = new DateTime(ydoc, 12, 31);
			return d;
		}

		string[] tracciato_upb = new string[] {
			"codiceupb;Codice UPB;Stringa;50",
			"ordinestampa;Ordine di stampa;Stringa;50",
			"codiceparentupb;Codice UPB del nodo PARENT di questo;Stringa;50",
			"descrupb;Descrizione UPB;Stringa;150",
			"resp;Responsabile;Stringa;150",
			"accertamentipregr;Accertamenti pregressi;Numero;22",
			"impegnipregr;Impegni pregressi;Numero;22",
			"finrich;Finanziamento Richiesto;Numero;22",
			"finacc;Finanziamento Accordato;Numero;22",
			"fincerto;Finanziamento Certo (Fondo) (S/N);Codificato;1;S|N",
			"attivo;Attivo (S/N);Codificato;1;S|N",
			"codcup; Codice Unico di Progetto;Stringa;15",
			"codtipoclass01;Codice Tipo class. 01;Stringa;20",
			"codclass01;Codice class. 01;Stringa;50",
			"codtipoclass02;Codice Tipo class. 02;Stringa;20",
			"codclass02;Codice class. 02;Stringa;50",
			"codtipoclass03;Codice tipo class. 03;Stringa;20",
			"codclass03;Codice class. 03;Stringa;50",
			"codtipoclass04;Codice Tipo class. 04;Stringa;20",
			"codclass04;Codice class. 04;Stringa;50",
			"codtipoclass05;Codice Tipo class. 05;Stringa;20",
			"codclass05;Codice class. 05;Stringa;50",
			"flagattivita;Flag Attività;Codificato;1;Q|I|C",
			"flagdidattica;Didattica (S/N);Codificato;1;S|N",
			"flagricerca;Ricerca;Codificato;1;S|N",
			"codicecass;Codice Cassiere;Stringa;20",
			"descrcass;Descrizione Cassiere;Stringa;150",
			"note;Note;Stringa;400",
			"scadenza;Scadenza;Data;8",
			"finaziatore;Ente Finanziatore;Stringa;50",
			"datainizio;Data inzio esistenza;Data;8",
			"datafine;Data fine;Data;8",
			"cig;Codice CIG;Stringa;10"
		};

		private void btnUPB_Click(object sender, EventArgs e) {
			ImportaUPB();
		}

		bool ImportaUPB() {
			LeggiFile Reader = GetReader(tracciato_upb);
			if (Reader == null) return false;

			ClearAllNonDBOHash();
			DataSet D = new vistaUPB();

			MetaData MetaUpb = Meta.Dispatcher.Get("upb");
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaData MetaUnderwriter = Meta.Dispatcher.Get("underwriter");
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaData MetaTreasurer = Meta.Dispatcher.Get("treasurer");

			DataTable Upb = D.Tables["upb"];
			Conn.RUN_SELECT_INTO_TABLE(Upb, null, null, null, false);

			DataTable Manager = D.Tables["manager"];
			DataTable Underwriter = D.Tables["underwriter"];
			DataTable Division = D.Tables["division"];
			DataTable Treasurer = D.Tables["treasurer"];




			MetaUpb.SetDefaults(Upb);
			MetaManager.SetDefaults(Manager);
			MetaUnderwriter.SetDefaults(Underwriter);
			MetaDivision.SetDefaults(Division);
			MetaTreasurer.SetDefaults(Treasurer);

			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("description", "Fittizia"), null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Underwriter, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Treasurer, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("division");
			tosync.Add("upb");
			tosync.Add("manager");
			tosync.Add("underwriter");
			tosync.Add("treasurer");
			InitSpeedSaver(Conn, tosync);



			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}



			bool to_repeat = true;
			bool somethingdone = false;
			bool err;
			while (to_repeat) {
				to_repeat = false;
				somethingdone = false;

				Reader.Reset();
				Reader.GetNext();

				while (Reader.DataPresent()) {
					string code = Reader.getCurrField("codiceupb").ToString();
					string filter_exists = QHC.CmpEq("codeupb", code);
					if (Upb.Select(filter_exists).Length > 0) {
						Reader.GetNext();
						continue;
					}

					//individua il nodo parent
					object parcode = Reader.getCurrField("codiceparentupb");
					DataRow RParUpb = null;
					if (parcode != DBNull.Value) {
						string filter = QHC.CmpEq("codeupb", parcode);
						if (Upb.Select(filter).Length == 0) {
							SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + parcode +
							                      " padre del nodo avente codice " +
							                      Reader.getCurrField("codiceupb").ToString() +
							                      " Riga:" + Reader.GetCurrRowNumber());

							Reader.GetNext();
							to_repeat = true;
							continue;
						}

						RParUpb = Upb.Select(filter)[0];

					}

					object manager = Reader.getCurrField("resp");
					object idman = DBNull.Value;
					if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString().TrimEnd(), iddivision);

					object active = DBNull.Value;
					if (Reader.getCurrField("attivo").ToString().ToUpper() == "S")
						active = "S";
					else
						active = "N";

					object assured = DBNull.Value;
					if (Reader.getCurrField("fincerto").ToString().ToUpper() == "S")
						assured = "S";
					else
						assured = "N";

					object s_flagactivity = Reader.getCurrField("flagattivita");
					object flagdidattica = Reader.getCurrField("flagdidattica");
					object flagricerca = Reader.getCurrField("flagricerca");
					int flagactivity = 4;
					if (s_flagactivity != null) {
						if (s_flagactivity.ToString().ToLower() == "i") flagactivity = 1;
						if (s_flagactivity.ToString().ToLower() == "c") flagactivity = 2;
					}

					int flagkind = 0;
					if (flagdidattica != null && flagdidattica.ToString().ToUpper() == "S") flagkind += 1;
					if (flagricerca != null && flagricerca.ToString().ToUpper() == "S") flagkind += 2;


					DataRow RUpb = MetaUpb.Get_New_Row(RParUpb, Upb);
					RUpb["codeupb"] = code;
					RUpb["title"] = Reader.getCurrField("descrupb").ToString();
					RUpb["printingorder"] = Reader.getCurrField("ordinestampa").ToString();
					RUpb["idman"] = idman;
					RUpb["requested"] = Reader.getCurrField("finrich");
					RUpb["granted"] = Reader.getCurrField("finacc");
					RUpb["previousassessment"] = Reader.getCurrField("accertamentipregr");
					RUpb["previousappropriation"] = Reader.getCurrField("impegnipregr");
					RUpb["active"] = active;
					RUpb["assured"] = assured;
					RUpb["expiration"] = ToDatetime(Reader.getCurrField("scadenza"));
					RUpb["cupcode"] = Reader.getCurrField("codcup");


					object underwriter = Reader.getCurrField("finanziatore");
					object idunderwriter = DBNull.Value;
					if (underwriter != DBNull.Value)
						idunderwriter = GetUnderwriter(Underwriter, underwriter.ToString());
					RUpb["idunderwriter"] = idunderwriter;
					RUpb["start"] = ToDatetime(Reader.getCurrField("datainizio"));
					RUpb["stop"] = ToDatetime(Reader.getCurrField("datafine"));
					RUpb["cigcode"] = Reader.getCurrField("cig");


					string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));

					for (int nsor = 1; nsor <= 5; nsor++) {
						RUpb["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
							Reader.getCurrField("codtipoclass0" + nsor.ToString()).ToString(),
							Reader.getCurrField("codclass0" + nsor.ToString()).ToString(),
							out err);
						if (err) {
							SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
							                    " di codice " + Reader.getCurrField("codclass0" + nsor.ToString()) +
							                    " inesistente alla riga " + Reader.GetCurrRowNumber());
						}
					}


					RUpb["flagactivity"] = flagactivity;
					RUpb["flagkind"] = flagkind;


					RUpb["ct"] = DateTime.Now;
					RUpb["lt"] = DateTime.Now;
					RUpb["cu"] = "importazione";
					RUpb["lu"] = "importazione";

					object descrcass = Reader.getCurrField("descrcass");
					object codicecass = Reader.getCurrField("codicecass");
					object idtreasurer = DBNull.Value;
					if (codicecass != DBNull.Value) idtreasurer = GetTreasurer(Treasurer, codicecass, descrcass);

					RUpb["idtreasurer"] = idtreasurer;

					RUpb["txt"] = Reader.getCurrField("note");
					somethingdone = true;
					Reader.GetNext();
				} //while (Reader.DataPresent()) 


				if (to_repeat && !somethingdone) {
					SpeedSaver.AddError("Ci sono nodi child senza parent,verificare. ");
					to_repeat = false;
				}
			} // while (to_repeat) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		string[] tracciato_varbil = new string[] {
			"anno;Anno;Intero;4",
			"tipovar;Tipo variazione: 1 Normale - 2 Ripartizione - 3 Assestamento - 4 Storno - 5 Iniziale;Codificato;1;1|2|3|4|5",
			"numprog;Numero progressivo (non ufficiale);Intero;6",
			"numuff;Numero ufficiale;Intero;6",
			"descrvar;Descrizione Variazione;Stringa;150",
			"numprovv;Numero provvedimento;Stringa;15",
			"provv;Descrizione Provvedimento;Stringa;150",
			"dataprovv;Data Provvedimento;Data;8",
			"datavar;Data Variazione;Data;8",
			"prevprinc;Variazione della prev. principale (S/N);Codificato;1;S|N",
			"prevsec;Variazione della prev. secondaria (S/N);Codificato;1;S|N",
			"crediti;Variazione della dotazione crediti (S/N);Codificato;1;S|N",
			"cassa;Variazione della dotazione cassa (S/N);Codificato;1;S|N",
			"codicebil;Codice bilancio;Stringa;50",
			"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
			"codiceupb;Codice UPB;Stringa;50",
			"importo;Importo variazione;Numero;22",
			"descr_dett;Descrizione dettaglio variazione;Stringa;150",
			"cod_tipoclass;Cdice tipo classificazione;Stringa;20",
			"descr_tipoclass;Descrizione Tipo classificazione;Stringa;150",
			"codicefinanziamento;Codice finanziamento;Stringa;50",
			"avanzopresunto;Avanzo presunto (S/N);Codificato;1;S|N",
			"prevanno_2;previsione principale anno + 1;Numero;22",
			"prevanno_3;previsione principale anno + 2;Numero;22",
			"residui;Residui presunti;Numero;22",
			"prevannoprecedente;Previsione anno precedente;Numero;22",
			"statovar;Stato Variazione: 1 Bozza - 2 Richiesta - 3 Da correggere - 4 Inserita - 5 Approvata - 6 Annullata;Codificato;1;1|2|3|4|5|6",
		};

		private void btnVarBilancio_Click(object sender, EventArgs e) {
			ImportaVarBilancio();
		}

		bool ImportaVarBilancio() {
			LeggiFile Reader = GetReader(tracciato_varbil);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaVarBil();

			DataTable FinVar = D.Tables["finvar"];
			MetaData MetaFinVar = Meta.Dispatcher.Get("finvar");
			MetaFinVar.SetDefaults(FinVar);

			DataTable FinVarDetail = D.Tables["finvardetail"];
			MetaData MetaFinVarDetail = Meta.Dispatcher.Get("finvardetail");
			MetaFinVarDetail.SetDefaults(FinVarDetail);

			DataTable Fin = D.Tables["fin"];
			MetaData MetaFin = Meta.Dispatcher.Get("fin");
			MetaFin.SetDefaults(Fin);

			DataTable Upb = D.Tables["upb"];
			MetaData MetaUpb = Meta.Dispatcher.Get("upb");
			MetaUpb.SetDefaults(Upb);

			DataTable Underwriting = D.Tables["underwriting"];
			MetaData MetaUnderwriting = Meta.Dispatcher.Get("underwriting");
			MetaUnderwriting.SetDefaults(Underwriting);

			DataTable FinVarKind = D.Tables["finvarkind"];
			MetaData MetaFinVarKind = Meta.Dispatcher.Get("finvarkind");
			MetaFinVarKind.SetDefaults(FinVarKind);


			Conn.RUN_SELECT_INTO_TABLE(Fin, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Upb, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Underwriting, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(FinVarKind, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("fin");
			tosync.Add("upb");
			tosync.Add("underwriting");
			tosync.Add("finvarkind");
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codefin = Reader.getCurrField("codicebil").ToString();
				string finpart = Reader.getCurrField("partebil").ToString();
				object ayear = Reader.getCurrField("anno");
				string searchfin = getFilterFin(codefin, finpart, ayear);
				if (Fin.Select(searchfin).Length == 0) {
					SpeedSaver.AddError("Voce di bilancio " + finpart + " - " + codefin + " del " + ayear.ToString() +
					                    " non è stata trovata");
					Reader.GetNext();
					continue;
				}

				object idfin = Fin.Select(searchfin)[0]["idfin"];

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				string searchupb = QHC.CmpEq("codeupb", codeupb);
				if (Upb.Select(searchupb).Length == 0) {
					SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				object idupb = Upb.Select(searchupb)[0]["idupb"];

				object idunderwriting = DBNull.Value;
				string codeunderwriting = Reader.getCurrField("codicefinanziamento").ToString();
				if (codeunderwriting != "") {
					string searchunderwriting = QHC.CmpEq("codeunderwriting", codeunderwriting);
					if (Underwriting.Select(searchunderwriting).Length == 0) {
						SpeedSaver.AddError("Il finanziamento di codice " + codeunderwriting + " non è stato trovato");
						Reader.GetNext();
						continue;
					}

					idunderwriting = Underwriting.Select(searchunderwriting)[0]["idunderwriting"];
				}

				object codevarkind = Reader.getCurrField("cod_tipoclass");
				string descrvarkind = Reader.getCurrField("descr_tipoclass").ToString();
				object idfinvarkind = DBNull.Value;
				if (codevarkind != DBNull.Value)
					idfinvarkind = CheckFinVarKind(FinVarKind, codevarkind.ToString(), descrvarkind);

				//Vede se c'è da aggiungere la variazione di bilancio
				object yvar = Reader.getCurrField("anno");
				object nvar = Reader.getCurrField("numprog");

				if (nvar == DBNull.Value) {
					SpeedSaver.AddError("Numero variazione non trovato per la variazione  del " + yvar +
					                    " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow RVar = null;
				string filtervar = QHC.AppAnd(QHC.CmpEq("yvar", yvar), QHC.CmpEq("nvar", nvar));
				if (FinVar.Select(filtervar).Length > 0) {
					RVar = FinVar.Select(filtervar)[0];
				}
				else {
					MetaData.SetDefault(FinVar, "yvar", yvar);
					RVar = MetaFinVar.Get_New_Row(null, FinVar);
					RowChange.ClearAutoIncrement(FinVar.Columns["nvar"]);

					object enactment = Reader.getCurrField("provv");
					object enactmentdate = Reader.getCurrField("dataprovv");
					object nenactment = Reader.getCurrField("numprovv");
					object description = Reader.getCurrField("descrvar");
					if (description.ToString().Trim() == "") description = ".";
					object adate = Reader.getCurrField("datavar");
					object tipovar = Reader.getCurrField("tipovar");
					RVar["variationkind"] = tipovar;
					object statovar = Reader.getCurrField("statovar");
					RVar["idfinvarstatus"] = statovar;
					RVar["flagprevision"] = Reader.getCurrField("prevprinc").ToString().ToUpper();
					RVar["flagsecondaryprev"] = Reader.getCurrField("prevsec").ToString().ToUpper();
					string flagcredit = Reader.getCurrField("crediti").ToString();
					if (flagcredit == "S") {
						RVar["flagcredit"] = "S";
					}
					else {
						RVar["flagcredit"] = "N";
					}

					string flagproceeds = Reader.getCurrField("cassa").ToString();
					if (flagproceeds == "S") {
						RVar["flagproceeds"] = "S";
					}
					else {
						RVar["flagproceeds"] = "N";
					}

					RVar["enactment"] = enactment;
					RVar["enactmentdate"] = ToSmalldateTime(enactmentdate);
					RVar["nenactment"] = nenactment;
					RVar["description"] = description;
					RVar["adate"] = ToSmalldateTimeNoHours(adate);
					RVar["yvar"] = yvar;
					RVar["nvar"] = nvar;
					RVar["nofficial"] = Reader.getCurrField("numuff");
					if (RVar["nofficial"] == DBNull.Value)
						RVar["official"] = 'N';
					else
						RVar["official"] = 'S';
					RVar["idfinvarkind"] = idfinvarkind;
					RVar["moneytransfer"] = "N";
					string avanzopresunto = Reader.getCurrField("avanzopresunto").ToString();
					if (avanzopresunto == "S") {
						RVar["varflag"] = 1;
					}
					else {
						RVar["varflag"] = 0;
					}

					RVar["ct"] = DateTime.Now;
					RVar["lt"] = DateTime.Now;
					RVar["cu"] = "importazione";
					RVar["lu"] = "importazione";
				}

				//Finalmente aggiunge il dettaglio variazione
				DataRow NewVarDetail = MetaFinVarDetail.Get_New_Row(RVar, FinVarDetail);
				NewVarDetail["amount"] = Reader.getCurrField("importo");
				NewVarDetail["prevision2"] = Reader.getCurrField("prevanno_2");
				NewVarDetail["prevision3"] = Reader.getCurrField("prevanno_3");
				NewVarDetail["residual"] = Reader.getCurrField("residui"); // 
				NewVarDetail["previousprevision"] = Reader.getCurrField("prevannoprecedente");
				NewVarDetail["description"] = Reader.getCurrField("descr_dett");
				NewVarDetail["idfin"] = idfin;
				NewVarDetail["idupb"] = idupb;
				NewVarDetail["idunderwriting"] = idunderwriting;
				NewVarDetail["ct"] = DateTime.Now;
				NewVarDetail["lt"] = DateTime.Now;
				NewVarDetail["cu"] = "importazione";
				NewVarDetail["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		string[] tracciato_prevbil = new string[] {
			"anno;Anno;Intero;4",
			"codicebil;Codice bilancio;Stringa;50",
			"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
			"codiceupb;Codice UPB;Stringa;50",
			"residuiprec;Residui iniziali anno precedente;Numero;22",
			"residuicorr;Residui iniziali anno corrente;Numero;22",
			"prevprincprev;previsione principale anno precedente;Numero;22",
			"prevsecprev;previsione secondaria anno precedente;Numero;22",
			"prevprinccorr;previsione principale anno corrente;Numero;22",
			"prevseccorr;previsione secondaria anno corrente;Numero;22",
			"prevanno_2;previsione principale anno + 1;Numero;22",
			"prevanno_3;previsione principale anno + 2;Numero;22",
			"prevanno_4;previsione principale anno + 3;Numero;22",
			"prevanno_5;previsione principale anno + 4;Numero;22"
		};

		private void btnPrevBilancio_Click(object sender, EventArgs e) {
			ImportaPrevisioniBilancio();
		}

		bool ImportaPrevisioniBilancio() {

			LeggiFile Reader = GetReader(tracciato_prevbil);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaPrevBilancio();


			Conn.SQLRunner("ALTER TABLE  FINYEAR DISABLE TRIGGER ALL");


			DataTable FinYear = D.Tables["finyear"];
			MetaData MetaFinYear = Meta.Dispatcher.Get("finyear");
			MetaFinYear.SetDefaults(FinYear);

			DataTable Fin = D.Tables["fin"];
			MetaData MetaFin = Meta.Dispatcher.Get("fin");
			MetaFin.SetDefaults(Fin);

			DataTable Upb = D.Tables["upb"];
			MetaData MetaUpb = Meta.Dispatcher.Get("upb");
			MetaUpb.SetDefaults(Upb);


			Conn.RUN_SELECT_INTO_TABLE(Fin, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Upb, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("fin");
			tosync.Add("upb");
			InitSpeedSaver(Conn, tosync);



			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codefin = Reader.getCurrField("codicebil").ToString();
				string finpart = Reader.getCurrField("partebil").ToString();
				object ayear = Reader.getCurrField("anno");
				string searchfin = getFilterFin(codefin, finpart, ayear);
				if (Fin.Select(searchfin).Length == 0) {
					SpeedSaver.AddError("Voce di bilancio " + finpart + " - " + codefin + " del " + ayear.ToString() +
					                    " non è stata trovata. Riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idfin = Fin.Select(searchfin)[0]["idfin"];

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				string searchupb = QHC.CmpEq("codeupb", codeupb);
				if (Upb.Select(searchupb).Length == 0) {
					SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idupb = Upb.Select(searchupb)[0]["idupb"];


				//Finalmente aggiunge il dettaglio variazione
				DataRow NewFinYear = MetaFinYear.Get_New_Row(null, FinYear);
				NewFinYear["currentarrears"] = Reader.getCurrField("residuicorr");
				NewFinYear["previousarrears"] = Reader.getCurrField("residuiprec");

				NewFinYear["previousprevision"] = Reader.getCurrField("prevprincprev");
				NewFinYear["previoussecondaryprev"] = Reader.getCurrField("prevseccorr");

				NewFinYear["prevision"] = Reader.getCurrField("prevprinccorr");
				NewFinYear["secondaryprev"] = Reader.getCurrField("prevseccorr");

				NewFinYear["prevision2"] = Reader.getCurrField("prevanno_2");
				NewFinYear["prevision3"] = Reader.getCurrField("prevanno_3");
				NewFinYear["prevision4"] = Reader.getCurrField("prevanno_4");
				NewFinYear["prevision5"] = Reader.getCurrField("prevanno_5");
				NewFinYear["ayear"] = Reader.getCurrField("anno");

				NewFinYear["idfin"] = idfin;
				NewFinYear["idupb"] = idupb;
				NewFinYear["ct"] = DateTime.Now;
				NewFinYear["lt"] = DateTime.Now;
				NewFinYear["cu"] = "importazione";
				NewFinYear["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool res = SaveData(D, true);
			Conn.SQLRunner("ALTER TABLE  FINYEAR ENABLE TRIGGER ALL");
			return res;
		}

		string[] tracciato_avanzo = new string[] {
			"ayear;Anno della previsione;Intero;4",
			"previsiondate;Data del bilancio di previsione;Data;8",
			"startfloatfund;Fondo Cassa all'1/1;Numero;22",
			"proceedstilldate;incassi dall'1/1 alla data;Numero;22",
			"paymentstilldate;pagamenti dall'1/1 alla data;Numero;22",
			"proceedstoendofyear;Incassi presunti dalla data al 31/12;Numero;22",
			"paymentstoendofyear;Pagamenti presunti dalla data al 31/12;Numero;22",
			"supposedpreviousrevenue;Residui attivi presunti degli anni precedenti;Numero;22",
			"supposedcurrentrevenue;Residui attivi presunti dell'anno;Numero;22",
			"supposedpreviousexpenditure;Residui passivi presunti degli anni precedenti;Numero;22",
			"supposedcurrentexpenditure;Residui passivi presunti dell'anno;Numero;22",
			"competencyproceeds;Incassi di competenza;Numero;22",
			"residualproceeds;Incassi in conto residui;Numero;22",
			"competencypayments;Pagamenti di competenza;Numero;22",
			"residualpayments;Pagamenti in conto residui;Numero;22",
			"previousrevenue;Residui attivi degli anni precedenti;Numero;22",
			"currentrevenue;Residui attivi dell'anno;Numero;22",
			"previousexpenditure;Residui passivi degli anni precedenti;Numero;22",
			"currentexpenditure;Residui passivi dell'anno;Numero;22"
		};


		private void btnAvanzo_Click(object sender, EventArgs e) {
			ImportaAvanzo();
		}

		bool ImportaAvanzo() {
			LeggiFile Reader = GetReader(tracciato_avanzo);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaAvanzo();

			DataTable Surplus = D.Tables["surplus"];
			MetaData MetaSurplus = Meta.Dispatcher.Get("surplus");
			MetaSurplus.SetDefaults(Surplus);

			Reader.GetNext();

			while (Reader.DataPresent()) {



				//Finalmente aggiunge il dettaglio variazione
				DataRow NewSurplus = MetaSurplus.Get_New_Row(null, Surplus);
				foreach (string track in tracciato_avanzo) {
					string[] fields = track.Split(';');
					string field = fields[0];
					NewSurplus[field] = Reader.getCurrField(field);
				}

				NewSurplus["ct"] = DateTime.Now;
				NewSurplus["lt"] = DateTime.Now;
				NewSurplus["cu"] = "importazione";
				NewSurplus["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}


		string[] tracciato_manreve = new string[] {
			"tipo;M=Mandato, R=Reversali;Codificato;1;M|R",
			"anno;Anno;Intero;4",
			"num;Numero;Intero;7",
			"natura;C=Competenza,R=residui,M=misto;Codificato;1;C|M|R",
			"codicecass;Codice Cassiere;Stringa;20",
			"descrcass;Descrizione Cassiere;Stringa;150",
			"codice;Codice Anagrafica;Stringa;10",
			"codicebil;Codice Bilancio;Stringa;50",
			"codbollo;Codice Trattamento Bollo;Stringa;4",
			"descrbollo;Descr. Trattamento Bollo;Stringa;50",
			"flagfrutt;Fruttifero S/N (solo per reversali);Codificato;1;S|N",
			"datacont;Data contabile;Data;8",
			"resp;Responsabile;Stringa;150",
			"numelenco;Numero elenco di trasmissione;Intero;6",
			"datatrasmissione;Data annullamento;Data;8",
			"dataannullamento;Data annullamento;Data;8",
			"datastampa;Data stampa;Data;8",
			"rif_esterno;Riferimento programma esterno;Stringa;200",
			"num_cassiere;Numero progressivo Cassiere;Intero;7"
		};



		private void btnManReve_Click(object sender, EventArgs e) {
			ImportaManReve();
		}

		bool ImportaManReve() {
			LeggiFile Reader = GetReader(tracciato_manreve);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaManReve();

			DataTable Payment = D.Tables["payment"];
			MetaData MetaPayment = Meta.Dispatcher.Get("payment");
			MetaPayment.SetDefaults(Payment);

			DataTable Proceeds = D.Tables["proceeds"];
			MetaData MetaProceeds = Meta.Dispatcher.Get("proceeds");
			MetaProceeds.SetDefaults(Proceeds);

			//DataTable Fin = D.Tables["fin"];
			//MetaData MetaFin = Meta.Dispatcher.Get("fin");
			//MetaFin.SetDefaults(Fin);

			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);

			DataTable Treasurer = D.Tables["treasurer"];
			MetaData MetaTreasurer = Meta.Dispatcher.Get("treasurer");
			MetaTreasurer.SetDefaults(Treasurer);

			DataTable StampHandling = D.Tables["stamphandling"];
			MetaData MetaStampHandling = Meta.Dispatcher.Get("stamphandling");
			MetaStampHandling.SetDefaults(StampHandling);

			DataTable PaymentTransmission = D.Tables["paymenttransmission"];
			MetaData MetaPaymentTransmission = Meta.Dispatcher.Get("paymenttransmission");
			MetaPaymentTransmission.SetDefaults(PaymentTransmission);

			DataTable ProceedsTransmission = D.Tables["proceedstransmission"];
			MetaData MetaProceedsTransmission = Meta.Dispatcher.Get("proceedstransmission");
			MetaProceedsTransmission.SetDefaults(ProceedsTransmission);




			DataTable Division = D.Tables["division"];
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaDivision.SetDefaults(Division);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("description", "Fittizia"), null, false);

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}

			//Conn.RUN_SELECT_INTO_TABLE(Fin, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			//Conn.RUN_SELECT_INTO_TABLE(Payment, null, null, null, false);
			//Conn.RUN_SELECT_INTO_TABLE(Proceeds, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Treasurer, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(StampHandling, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(PaymentTransmission, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(ProceedsTransmission, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("manager");
			tosync.Add("treasurer");
			tosync.Add("stamphandling");
			tosync.Add("paymenttransmission");
			tosync.Add("proceedstransmission");
			InitSpeedSaver(Conn, tosync);


			int numrows = 0;
			Reader.GetNext();

			while (Reader.DataPresent()) {
				numrows++;
				string tipo = Reader.getCurrField("tipo").ToString().ToUpper(); //M / R
				object num = Reader.getCurrField("num");
				object anno = Reader.getCurrField("anno");

				string table = (tipo == "M") ? "payment" : "proceeds";
				//string filter = (tipo == "M") ? QHC.AppAnd(QHC.CmpEq("ypay", anno), QHC.CmpEq("npay", num)) :
				//                QHC.AppAnd(QHC.CmpEq("ypro", anno), QHC.CmpEq("npro", num));
				//if (D.Tables[table].Select(filter).Length > 0) continue;

				string me = (tipo == "M")
					? "mandato " + num.ToString() + " del " + anno.ToString()
					: "reversale " + num.ToString() + " del " + anno.ToString();

				string finpart = (tipo == "M") ? "S" : "E";
				string codefin = Reader.getCurrField("codicebil").ToString();
				object ayear = Reader.getCurrField("anno");

				string searchfin = getSqlFilterFin(codefin, finpart, ayear);
				object idfin = DBNull.Value;
				if (codefin != "") {
					idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == DBNull.Value || idfin == null) {

						SpeedSaver.AddError(me + ": Voce di bilancio " + finpart + " - " + codefin + " del " +
						                    ayear.ToString() +
						                    " non è stata trovata, riga" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}


				object manager = Reader.getCurrField("resp");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision);



				object descrcass = Reader.getCurrField("descrcass");
				object codicecass = Reader.getCurrField("codicecass");
				object idtreasurer = DBNull.Value;
				if (codicecass != DBNull.Value) idtreasurer = GetTreasurer(Treasurer, codicecass, descrcass);


				object numelenco = Reader.getCurrField("numelenco");
				object idtrasm = DBNull.Value;
				if (numelenco != DBNull.Value) {
					if (tipo == "M")
						idtrasm = GetPaymentTransmission(PaymentTransmission, anno, numelenco, idtreasurer,
							Reader.getCurrField("datatrasmissione"));
					else
						idtrasm = GetProceedsTransmission(ProceedsTransmission, anno, numelenco, idtreasurer,
							Reader.getCurrField("datatrasmissione"));
				}

				object descrbollo = Reader.getCurrField("descrbollo");
				object codbollo = Reader.getCurrField("codbollo");
				object idstamphandling = DBNull.Value;
				if (codbollo != DBNull.Value) idstamphandling = GetStampHandling(StampHandling, codbollo, descrbollo);

				//"natura;C=Competenza,R=residui,M=misto;Codificato;1;C|M|R",
				string natura = Reader.getCurrField("natura").ToString().ToUpper();
				int flagres = 0;
				if (natura == "C") flagres = 1;
				if (natura == "M") flagres = 4;
				if (natura == "R") flagres = 2;

				//Finalmente aggiunge il mandato o la reversale
				if (tipo == "M") {
					int N = metaprofiler.StartTimer("metapay_newrow");
					DataRow RM = MetaPayment.Get_New_Row(null, Payment);
					metaprofiler.StopTimer(N);
					RowChange.ClearAutoIncrement(Payment.Columns["npay"]);
					RowChange.ClearAutoIncrement(Payment.Columns["npay_treasurer"]);
					RM["ypay"] = anno;
					RM["npay"] = num;
					RM["idfin"] = idfin;
					RM["idman"] = idman;
					RM["idtreasurer"] = idtreasurer;
					RM["idreg"] = Reader.getCurrField("codice");
					RM["adate"] = ToSmalldateTime(Reader.getCurrField("datacont"));
					RM["idstamphandling"] = idstamphandling;
					RM["kpaymenttransmission"] = idtrasm;
					int flag = CfgFn.GetNoNullInt32(RM["flag"]);
					flag = (flag & 0xF8) + flagres;
					RM["flag"] = flag;
					object dataannullamento = Reader.getCurrField("dataannullamento");
					object dataannullamento_new = ToConvertDateInDocYear(dataannullamento, CfgFn.GetNoNullInt32(anno));
					RM["annulmentdate"] = ToSmalldateTimeNoHours(dataannullamento_new);
					RM["printdate"] = ToSmalldateTime(Reader.getCurrField("datastampa"));
					RM["external_reference"] = Reader.getCurrField("rif_esterno");
					RM["npay_treasurer"] = Reader.getCurrField("num_cassiere");
				}
				else {
					DataRow RP = MetaProceeds.Get_New_Row(null, Proceeds);
					RowChange.ClearAutoIncrement(Proceeds.Columns["npro"]);
					RowChange.ClearAutoIncrement(Proceeds.Columns["npro_treasurer"]);
					RP["ypro"] = anno;
					RP["npro"] = num;
					RP["idfin"] = idfin;
					RP["idman"] = idman;
					RP["idtreasurer"] = idtreasurer;
					RP["idreg"] = Reader.getCurrField("codice");
					RP["adate"] = ToSmalldateTime(Reader.getCurrField("datacont"));
					RP["idstamphandling"] = idstamphandling;
					RP["kproceedstransmission"] = idtrasm;
					int flag = CfgFn.GetNoNullInt32(RP["flag"]);
					flag = (flag & 0xF8) + flagres;
					if (Reader.getCurrField("flagfrutt").ToString().ToUpper() == "S") {
						flag = flag | 8;
					}
					else {
						flag = flag & 0xF7;
					}

					RP["flag"] = flag;

					object dataannullamento = Reader.getCurrField("dataannullamento");
					object dataannullamento_new = ToConvertDateInDocYear(dataannullamento, CfgFn.GetNoNullInt32(anno));
					RP["annulmentdate"] = ToSmalldateTimeNoHours(dataannullamento_new);

					RP["printdate"] = ToSmalldateTime(Reader.getCurrField("datastampa"));
					RP["external_reference"] = Reader.getCurrField("rif_esterno");
					RP["npro_treasurer"] = Reader.getCurrField("num_cassiere");
				}

				if (numrows >= 1000) {
					//Salva i dati
					if (!SaveData(D, false)) break;
					D.Tables["payment"].Clear();
					D.Tables["proceeds"].Clear();
					numrows = 0;
					//Hashtable Hp = metaprofiler.totals;
				}

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		private static object SSToSmalldateTime(object data) {
			if (data == DBNull.Value) return data;
			if (data == null) return DBNull.Value;
			data = ToCC.getDate(data);
			if (!data.GetType().IsAssignableFrom(typeof(DateTime))) {
				MessageBox.Show("Non posso fare il cast di " + data.ToString() + " in una data");

			}

			DateTime d = (DateTime) data;
			DateTime minValue = new DateTime(1900, 1, 1);
			if (d < minValue)
				return minValue;
			DateTime maxValue = new DateTime(2079, 06, 06);
			if (d > maxValue)
				return maxValue;

			return data;
		}

		string[] tracciato_movfin = new string[] {
			"tipo;Tipo movimento (E=Entrata,S=Spesa);Codificato;1;E|S",
			"nliv;Numero fase;Intero;1",
			"descliv;Descrizione fase;Stringa;50",
			"last;Ultima fase;Codificato;1;S|N",
			"ymov;Esercizio movimento;Intero;4",
			"nmov;Numero movimento;Intero;8",
			"parentymov;Esercizio movimento Parent;Intero;4",
			"parentnmov;Numero movimento Parent;Intero;8",
			"description;Descrizione;Stringa;150",
			"doc;Documento;Stringa;35",
			"docdate;Data documento;Data;8",
			"adate;Data Contabile;Data;8",
			"idreg;Codice di anagrafica;Intero;10",
			"resp;Responsabile;Stringa;150",
			"ayear;Anno imputazione;Intero;4",
			"amount;Importo iniziale anno;Numero;22",
			"codiceupb;Codice upb;Stringa;50",
			"codicebil;Codice bilancio;Stringa;50",
			"nmanrev;Numero di mandato o reversale (solo ult.fasi);Intero;8",
			"tipomodpag;Tipo Modalità Pagamento (solo ult.fasi);Intero;8",
			"cc;Numero di conto corrente (solo ult.fase spesa);Stringa;30",
			"cin;Cin (solo ult.fase spesa);Stringa;2",
			"iban;IBAN (solo ult.fase spesa);Stringa;50",
			"idbank;ABI (solo ult.fase spesa);Stringa;20",
			"idcab;CAB (solo ult.fase spesa);Stringa;20",
			"biccode;Codice BIC-SWIFT(solo ult.fase spesa); Stringa;20",
			"numerocontobankitalia;Numero Conto Banca Italia per girofondi(solo ult.fase spesa); Stringa;10",
			"esentespesebancarie;Esente da Spese Bancarie(S/N);Codificato;1;S|N",
			"tipotrattamentospese;Tipologia trattamento Spese / idchargehandling;Intero;8", // leggere da configurazione e mettere idchargehandling    
			"paymentdescr;Descrizione pagamento (solo ult.fase spesa);Stringa;150",
			"note;Note;Stringa;400",
			"nbill;Numero sospeso;Intero;7",
			//Opzioni Tipo Pagamento
			"ammettidelegato;Ammetti delegato (S/N);Codificato;1;S|N", // paymethod_allowdeputy
			"idregdelegato;Codice di anagrafica del delegato;Intero;10",
			"stampaavvisopagamento;Stampa avviso pagamento(S/N);Codificato;1;S|N", // paymethod_flag
			"contocorrentepostale;Conto corrente postale (S/N);Codificato;1;S|N",
			"bonificosepa;Bonifico SEPA(S/N);Codificato;1;S|N",
			"bonificoestero;Bonifico Estero(S/N);Codificato;1;S|N",
			"coordbancarieobbligatorie;Coordinate Bancarie obbligatorie(S/N);Codificato;1;S|N",
			"coordbancariedanonspecificare;Coordinate Bancarie da non specificare(S/N);Codificato;1;S|N",
			"girofondi;Girofondi (S/N);Codificato;1;S|N",
			"girofondiordinaritabA;Girofondi Ordinari Tab A (S/N);Codificato;1;S|N",
			"girofondivincolatitabA;Girofondi Vincolati Tab B (S/N);Codificato;1;S|N",
			"girofondiordinaritabB;Girofondi Ordinari Tab B (S/N);Codificato;1;S|N",
			"girofondivincolatitabB;Girofondi Vincolati Tab B (S/N);Codificato;1;S|N",
			"tipocontabentericevente;Tipo Contabilità Ente Ricevente(F= Fruttifera,I=Infruttifera);Codificato;1;F|I",
			"sportello;Sportello(S/N);Codificato;1;S|N",
			"cig;codice CIG;Stringa;10",
			"cup;codice CUP;Stringa;15",
			"nsub;Numero progressivo sub bancario;Intero;7",
			"rif_esterno;Riferimento programma esterno;Stringa;200",
			"conto_debito_credito;Codice conto debito o credito;Stringa;50",
			//Prestazione
			"codtipoprestazione;Tipo prestazione/ codeser;Stringa;20", // leggere da configurazione e mettere codeser
			"datainizioprestazione;Data Inizio Prestazione;Data;8",
			"datafineprestazione;Data Fine Prestazione;Data;8",
			//Automatismi di pagamento principale
			"autokind;Codice Tipo Automatismo;Intero;8",
			"autocode;Informazione supplementare automatismo (codice ritenuta ecc.);Intero;8",
			"nlivpagprincipale;Numero fase del pagamento principale se automatismo;Intero;1",
			"ymovpagprincipale;Esercizio movimento principale se automatismo;Intero;4",
			"nmovpagprincipale;Numero movimento principale se automatismo;Intero;8",
			//Generazione automatismi su Pagamento principale
			"autoritengenerati;Automatismi Ritenute già Generati (S/N);Codificato;1;S|N",
			"autorecuperigenerati;Automatismi Recuperi già Generati (S/N);Codificato;1;S|N",
			//Importo Iva
			"ivaamount;Importo Iva ;Numero;22",
			//Economia di spesa associata
			//"nliveconomiaspesa;Numero fase del pagamento principale;Intero;1", // dovrebbe essere sempre fase uno
			"ymoveconomiaspesa;Esercizio movimento  fase uno economia spesa;Intero;4",
			"nmoveconomiaspesa;Numero movimento fase uno economia spesa;Intero;8",
		};

		string[] tracciato_movbudget = new string[] {
			"tipo;Tipo movimento (A=Accertamento/Preaccertamento,I=Impegno/Preimpegno);Codificato;1;A|I",
			"nliv;Numero fase;Intero;1",
			"descliv;Descrizione fase;Stringa;50",
			"ymov;Esercizio movimento;Intero;4",
			"nmov;Numero movimento;Intero;8",
			"parentymov;Esercizio movimento Parent;Intero;4",
			"parentnmov;Numero movimento Parent;Intero;8",
			"description;Descrizione;Stringa;150",
			"doc;Documento;Stringa;35",
			"docdate;Data documento;Data;8",
			"adate;Data Contabile;Data;8",
			"idreg;Codice di anagrafica;Intero;10",
			"resp;Responsabile;Stringa;150",
			"ayear;Anno imputazione;Intero;4",
			"amount;Importo iniziale anno;Numero;22",
			"amount2;Importo iniziale anno+1;Numero;22",
			"amount3;Importo iniziale anno+2;Numero;22",
			"amount4;Importo iniziale anno+3;Numero;22",
			"amount5;Importo iniziale anno+4;Numero;22",
			"codiceupb;Codice upb;Stringa;50",
			"codiceconto;Codice conto;Stringa;50",
			"note;Note;Stringa;400",
			"causale;Codice causale;Stringa;50",
			"flagvariation;Variazione (S/N);Codificato;1;S|N",
		};

		private void btnMovFin_Click(object sender, EventArgs e) {
			ImportaMovFin();
		}

		bool ImportaMovFin() {

			LeggiFile Reader = GetReader(tracciato_movfin);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			DataSet D = new VistaMovFin();

			//Conn.SQLRunner("ALTER TABLE  EXPENSE DISABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  EXPENSEYEAR DISABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  EXPENSELAST DISABLE TRIGGER ALL");

			//Conn.SQLRunner("ALTER TABLE  INCOME DISABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  INCOMEYEAR DISABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  INCOMELAST DISABLE TRIGGER ALL");

			DataTable Expense = D.Tables["expense"];
			MetaData MetaExpense = Meta.Dispatcher.Get("expense");
			MetaExpense.SetDefaults(Expense);

			DataTable Income = D.Tables["income"];
			MetaData MetaIncome = Meta.Dispatcher.Get("income");
			MetaIncome.SetDefaults(Income);

			DataTable ExpenseYear = D.Tables["expenseyear"];
			MetaData MetaExpenseYear = Meta.Dispatcher.Get("expenseyear");
			MetaExpenseYear.SetDefaults(ExpenseYear);

			DataTable IncomeYear = D.Tables["incomeyear"];
			MetaData MetaIncomeYear = Meta.Dispatcher.Get("incomeyear");
			MetaIncomeYear.SetDefaults(IncomeYear);

			DataTable ExpenseLast = D.Tables["expenselast"];
			MetaData MetaExpenseLast = Meta.Dispatcher.Get("expenselast");
			MetaExpenseLast.SetDefaults(ExpenseLast);

			DataTable IncomeLast = D.Tables["incomelast"];
			MetaData MetaIncomeLast = Meta.Dispatcher.Get("incomelast");
			MetaIncomeLast.SetDefaults(IncomeLast);

			DataTable ExpensePhase = D.Tables["expensephase"];
			MetaData MetaExpensePhase = Meta.Dispatcher.Get("expensephase");
			MetaExpenseLast.SetDefaults(ExpensePhase);

			DataTable IncomePhase = D.Tables["incomephase"];
			MetaData MetaIncomePhase = Meta.Dispatcher.Get("incomephase");
			MetaIncomeLast.SetDefaults(IncomePhase);

			DataTable Upb = D.Tables["upb"];
			MetaData MetaUpb = Meta.Dispatcher.Get("upb");
			MetaUpb.SetDefaults(Upb);

			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);

			MetaData MetaPaymentBank = Meta.Dispatcher.Get("payment_bank");
			DataTable PaymentBank = D.Tables["payment_bank"];
			MetaPaymentBank.SetDefaults(PaymentBank);

			MetaData MetaProceedsBank = Meta.Dispatcher.Get("proceeds_bank");
			DataTable ProceedsBank = D.Tables["proceeds_bank"];
			MetaProceedsBank.SetDefaults(ProceedsBank);

			DataTable Division = D.Tables["division"];
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaDivision.SetDefaults(Division);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("description", "Fittizia"), null, false);

			DataTable Account = Conn.RUN_SELECT("account", "*", null, null, null, false);

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}

			Conn.RUN_SELECT_INTO_TABLE(Upb, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);

			Conn.RUN_SELECT_INTO_TABLE(IncomePhase, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(ExpensePhase, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("manager");
			tosync.Add("upb");
			tosync.Add("incomephase");
			tosync.Add("expensephase");
			tosync.Add("division");
			InitSpeedSaver(Conn, tosync);

			Reader.GetNext();
			string last_sign = "X";
			int nrow = 0;
			while (Reader.DataPresent()) {
				string tipo = Reader.getCurrField("tipo").ToString().ToUpper(); // E/S
				object ymov = Reader.getCurrField("ymov");
				object nmov = Reader.getCurrField("nmov");
				object ayear = Reader.getCurrField("ayear");

				int nfase = CfgFn.GetNoNullInt32(Reader.getCurrField("nliv"));
				string sign = tipo + "-" + ymov.ToString() + "-" + nfase.ToString() + "-" + ayear.ToString();
				if ((nrow > 0) && (nrow > 1000 || sign != last_sign)) {
					//Salva i dati e azzera nrow
					//Form F = new formtest(D.Tables["expense"], D.Tables["expenseyear"]);

					//F.ShowDialog();

					if (!SaveData(D, false)) break;

					ExpenseLast.Clear();
					IncomeLast.Clear();
					ExpenseYear.Clear();
					IncomeYear.Clear();
					Expense.Clear();
					Income.Clear();
					PaymentBank.Clear();
					ProceedsBank.Clear();

					nrow = 0;
				}

				last_sign = sign;

				object nsub = Reader.getCurrField("nsub");
				object num = Reader.getCurrField("nmanrev");
				string table = (tipo == "S") ? "payment" : "proceeds";
				string kfield = (tipo == "S") ? "kpay" : "kpro";
				string manrev = (tipo == "S") ? "mandato" : "reversale";
				string filter = (tipo == "S")
					? QHS.AppAnd(QHS.CmpEq("ypay", ymov), QHS.CmpEq("npay", num))
					: QHS.AppAnd(QHS.CmpEq("ypro", ymov), QHS.CmpEq("npro", num));
				//string billkind = (tipo == "S") ? "D" : "C";
				object kpaymentproceeds = DBNull.Value;
				string me = Reader.getCurrField("descliv") + " num. " + num.ToString() + " del " + ymov.ToString();

				if (num.ToString() != "") {
					kpaymentproceeds = Conn.DO_READ_VALUE(table, filter, kfield);
					if (kpaymentproceeds == null) kpaymentproceeds = DBNull.Value;
					if (kpaymentproceeds == DBNull.Value) {
						SpeedSaver.AddError(me + ":" + manrev + " num." + num.ToString() + " del " + ymov.ToString() +
						                    " non trovata, riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

				}

				string finpart = tipo;
				string codefin = Reader.getCurrField("codicebil").ToString();
				string searchfin = getSqlFilterFin(codefin, finpart, ayear);
				object idfin = DBNull.Value;
				if (codefin != "") {
					idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == DBNull.Value || idfin == null) {
						SpeedSaver.AddError(me + ": Voce di bilancio " + finpart + " - " + codefin + " del " +
						                    ayear.ToString() +
						                    " non è stata trovata, riga" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}
				else {
					SpeedSaver.AddError(me + ": Voce di bilancio assente, riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				string searchupb = QHC.CmpEq("codeupb", codeupb);
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (Upb.Select(searchupb).Length == 0) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato, riga:" +
						                    Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					idupb = Upb.Select(searchupb)[0]["idupb"];
				}
				else {
					SpeedSaver.AddError(me + ": upb assente, riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}


				object manager = Reader.getCurrField("resp");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision);

				string fmov = QHS.AppAnd(QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov),
					QHS.CmpEq("nphase", nfase));

				string fparentmov = QHS.AppAnd(QHS.CmpEq("ymov", Reader.getCurrField("parentymov")),
					QHS.CmpEq("nmov", Reader.getCurrField("parentnmov")),
					QHS.CmpEq("nphase", nfase - 1));

				object descr;
				//Finalmente aggiunge il mandato o la reversale
				if (tipo == "S") {
					CheckMovPhase(D.Tables["expensephase"], nfase, Reader.getCurrField("descliv"));

					object paridexp = DBNull.Value;
					if (nfase > 1) {
						paridexp = Conn.DO_READ_VALUE("expense", fparentmov, "idexp");
						if (paridexp == DBNull.Value || paridexp == null) {
							SpeedSaver.AddError(me +
							                    ": movimento parent non trovato, possibile errato ordine righe file. Riga:"
							                    + Reader.GetCurrRowNumber());
							Reader.GetNext();
							paridexp = DBNull.Value;
							continue;
						}
					}


					DataRow RExp = null;
					object idexp = Conn.DO_READ_VALUE("expense", fmov, "idexp");
					bool new_idexp = false;
					//Creazione/recupero movimento di spesa
					if (idexp == null || idexp == DBNull.Value) {
						//Crea il movimento 
						RExp = MetaExpense.Get_New_Row(null, Expense);
						int idexp2 = CfgFn.GetNoNullInt32(RExp["idexp"]);
						if (idexp2 < 10000000) idexp2 = 10000000;
						RExp["idexp"] = idexp2;
						RowChange.ClearAutoIncrement(Expense.Columns["nmov"]);
						RExp["parentidexp"] = paridexp;
						RExp["nphase"] = nfase;
						RExp["ymov"] = ymov;
						RExp["nmov"] = nmov;
						descr = Reader.getCurrField("description");
						if (descr == DBNull.Value) {
							SpeedSaver.AddWarning(me + ": descrizione vuota sostituita con un punto. Riga:" +
							                      Reader.GetCurrRowNumber());
							descr = ".";
						}

						RExp["description"] = descr;
						RExp["doc"] = Reader.getCurrField("doc");
						RExp["cigcode"] = Reader.getCurrField("cig");
						RExp["cupcode"] = Reader.getCurrField("cup");
						RExp["docdate"] = ToSmalldateTime(Reader.getCurrField("docdate"));
						RExp["txt"] = Reader.getCurrField("note");
						RExp["adate"] = ToSmalldateTime(Reader.getCurrField("adate"));
						RExp["idreg"] = Reader.getCurrField("idreg");
						RExp["external_reference"] = Reader.getCurrField("rif_esterno");
						RExp["idman"] = idman;
						// Generazione automatismi
						RExp["autokind"] = Reader.getCurrField("autokind");
						RExp["autocode"] = Reader.getCurrField("autocode");
						// Lettura del pagamento principale se esiste e valorizzazione di idpayment sulla spesa
						object idpayment = DBNull.Value;
						object nfasepayment = Reader.getCurrField("nlvpagprincipale");
						object ymovpayment = Reader.getCurrField("ymovpagprincipale");
						object nmovpayment = Reader.getCurrField("nmovpagprincipale");

						if (ymovpayment != DBNull.Value) {
							string fpayment = QHS.AppAnd(QHS.CmpEq("ymov", ymovpayment),
								QHS.CmpEq("nmov", nmovpayment),
								QHS.CmpEq("nphase", nfasepayment));
							idpayment = Conn.DO_READ_VALUE("expense", fparentmov, "idexp");
							if (idpayment == DBNull.Value || idpayment == null) {
								SpeedSaver.AddError(me +
								                    ": movimento principale non trovato. Riga:"
								                    + Reader.GetCurrRowNumber());
								Reader.GetNext();
								idpayment = DBNull.Value;
								continue;
							}
						}

						RExp["idpayment"] = idpayment;
						// Lettura dell'economia di spesa principale se esiste e valorizzazione di idformerexpense sulla spesa
						object idformerexpense = DBNull.Value;
						object nfaseformerexpense = 1; // Reader.getCurrField("nlvpagprincipale");
						object ymoveconomiaspesa = Reader.getCurrField("ymoveconomiaspesa");
						object nmoveconomiaspesa = Reader.getCurrField("nmoveconomiaspesa");

						if (ymoveconomiaspesa != DBNull.Value) {
							string filterformerexpense = QHS.AppAnd(QHS.CmpEq("ymov", ymoveconomiaspesa),
								QHS.CmpEq("nmov", nmoveconomiaspesa),
								QHS.CmpEq("nphase", nfaseformerexpense));
							idformerexpense = Conn.DO_READ_VALUE("expense", filterformerexpense, "idexp");
							if (idformerexpense == DBNull.Value || idformerexpense == null) {
								SpeedSaver.AddError(me +
								                    ": movimento economia di spesa non trovato. Riga:"
								                    + Reader.GetCurrRowNumber());
								Reader.GetNext();
								idformerexpense = DBNull.Value;
								continue;
							}
						}

						RExp["idformerexpense"] = idformerexpense;
						new_idexp = true;

					}
					else {
						Conn.RUN_SELECT_INTO_TABLE(Expense, null, fmov, null, true);
						RExp = Expense.Select(QHC.CmpEq("idexp", idexp))[0];
					}

					bool new_expyear = true;
					//Verifica se esiste exp.year
					if (new_idexp == false) {
						string fltexpyear = QHS.AppAnd(QHS.CmpEq("idexp", idexp), QHS.CmpEq("ayear", ayear));
						if (Conn.RUN_SELECT_COUNT("expenseyear", fltexpyear, false) > 0) new_expyear = false;
					}

					if (new_expyear) {
						//Mette expenseyear 
						DataRow REY = MetaExpenseYear.Get_New_Row(RExp, ExpenseYear);
						REY["ayear"] = ayear;
						REY["idfin"] = idfin;
						REY["idupb"] = idupb;
						REY["amount"] = Reader.getCurrField("amount");

					}

					string is_last = Reader.getCurrField("last").ToString();
					bool new_explast = true;
					if (is_last == "N") {
						new_explast = false;
					}
					else {
						//Mette ExpenseLast ove necessario
						if (new_idexp == false) {
							string fltexplast = QHS.CmpEq("idexp", idexp);
							if (Conn.RUN_SELECT_COUNT("expenselast", fltexplast, false) > 0) new_explast = false;
						}
					}

					if (new_explast) {
//Mette expenselast
						DataRow REL = MetaExpenseLast.Get_New_Row(RExp, ExpenseLast);
						REL["kpay"] = kpaymentproceeds;
						object idpaymethod = Reader.getCurrField("tipomodpag");
						REL["idpaymethod"] = idpaymethod;
						foreach (
							string ff in new string[] {
								"cc", "cin", "iban", "idbank", "idcab", "paymentdescr", "biccode", "nbill", "ivaamount"
							})
							REL[ff] = Reader.getCurrField(ff);
						REL["idpay"] = nsub;
						int flag = 0;
						if (REL["nbill"] != DBNull.Value) {
							flag += 1;
						}

						REL["extracode"] = Reader.getCurrField("numerocontobankitalia");
						//n.Bit Flag Significato
						//0   Regolarizza disposizione di pagamento già effettuata
						//1   Gli automatismi ritenute e contributi SONO GIA' STATI  generati 
						//2   Gli automatismi recuperi sono stati già generati
						//3   Esente da spese bancarie
						object esentespesebancarie = Reader.getCurrField("esentespesebancarie");
						if (esentespesebancarie.ToString() == "S") flag += 8;
						REL["idchargehandling"] = Reader.getCurrField("tipotrattamentospese");
						REL["paymethod_allowdeputy"] = Reader.getCurrField("ammettidelegato");
						REL["iddeputy"] = Reader.getCurrField("idregdelegato");
						int paymethod_flag = 0;
						//n.Bit Significato paymethod_flag
						//0   Stampa avviso pagamento
						//1   Conto corrente postale
						//2   coordinate bancarie obbligatorie
						//3   coordinate bancarie da non specificare
						//6   girofondi
						//7   Sportello
						//8   girofondi ordinari tab A
						//9   girofondi vincolati tab A
						//10  girofondi ordinari tab B
						//11  girofondi vincolati tab B
						//12  Fruttifera(Tipo cont.ente ricevente girofondi)
						//13  bonifico SEPA
						//14  Bonifico estero

						var stampaavvisopagamento = Reader.getCurrField("stampaavvisopagamento").ToString().ToUpper();
						if ((stampaavvisopagamento != "") && (stampaavvisopagamento.ToString() == "S"))
							paymethod_flag += 1;

						var contocorrentepostale = Reader.getCurrField("contocorrentepostale").ToString().ToUpper();
						if ((contocorrentepostale != "") && (contocorrentepostale.ToString() == "S"))
							paymethod_flag += 2;

						var bonificosepa = Reader.getCurrField("bonificosepa").ToString().ToUpper();
						if ((bonificosepa != "") && (bonificosepa.ToString() == "S")) paymethod_flag += 2 ^ 13;

						var bonificoestero = Reader.getCurrField("bonificoestero").ToString().ToUpper();
						if ((bonificoestero != "") && (bonificoestero.ToString() == "S")) paymethod_flag += 2 ^ 14;

						var coordbancarieobbligatorie =
							Reader.getCurrField("coordbancarieobbligatorie").ToString().ToUpper();
						if ((coordbancarieobbligatorie != "") && (coordbancarieobbligatorie.ToString() == "S"))
							paymethod_flag += 2 ^ 2;

						var coordbancariedanonspecificare =
							Reader.getCurrField("coordbancariedanonspecificare").ToString().ToUpper();
						if ((coordbancariedanonspecificare != "") && (coordbancariedanonspecificare.ToString() == "S"))
							paymethod_flag += 2 ^ 3;

						var girofondi = Reader.getCurrField("girofondi").ToString().ToUpper();
						if ((girofondi != "") && (girofondi.ToString() == "S")) paymethod_flag += 2 ^ 6;

						var girofondiordinaritabA = Reader.getCurrField("girofondiordinaritabA").ToString().ToUpper();
						if ((girofondiordinaritabA != "") && (girofondiordinaritabA.ToString() == "S"))
							paymethod_flag += 2 ^ 8;

						var girofondivincolatitabA = Reader.getCurrField("girofondivincolatitabA").ToString().ToUpper();
						if ((girofondivincolatitabA != "") && (girofondivincolatitabA.ToString() == "S"))
							paymethod_flag += 2 ^ 9;

						var girofondiordinaritabB = Reader.getCurrField("girofondiordinaritabB").ToString().ToUpper();
						if ((girofondiordinaritabB != "") && (girofondiordinaritabB.ToString() == "S"))
							paymethod_flag += 2 ^ 10;

						var girofondivincolatitabB = Reader.getCurrField("girofondivincolatitabB").ToString().ToUpper();
						if ((girofondivincolatitabB != "") && (girofondivincolatitabB.ToString() == "S"))
							paymethod_flag += 2 ^ 11;

						var tipocontabentericevente =
							Reader.getCurrField("tipocontabentericevente").ToString().ToUpper();
						if ((tipocontabentericevente != "") && (tipocontabentericevente.ToString() == "F"))
							paymethod_flag += 2 ^ 12;

						var sportello = Reader.getCurrField("sportello").ToString().ToUpper();
						if ((sportello != "") && (sportello.ToString() == "F")) paymethod_flag += 2 ^ 7;
						REL["paymethod_flag"] = paymethod_flag;
						// Automatismi
						object autoritengenerati = Reader.getCurrField("autoritengenerati").ToString().ToUpper();
						flag += 2;
						object autorecuperigenerati = Reader.getCurrField("autorecuperigenerati").ToString().ToUpper();
						flag += 4;
						REL["flag"] = flag;
						var codtipoprestazione = Reader.getCurrField("codtipoprestazione");
						if (codtipoprestazione != DBNull.Value) {
							object idser = Conn.DO_READ_VALUE("service", QHS.CmpEq("codeser", codtipoprestazione),
								"idser");
							if (idser == DBNull.Value || idser == null) {
								SpeedSaver.AddError(me +
								                    ": codice  prestazione" + codtipoprestazione.ToString() +
								                    " non trovato. Riga:"
								                    + Reader.GetCurrRowNumber());
								Reader.GetNext();
								idser = DBNull.Value;
								continue;
							}
							else {
								REL["idser"] = idser;
								REL["servicestart"] = Reader.getCurrField("datainizioprestazione");
								REL["servicestop"] = Reader.getCurrField("datafineprestazione");
							}
						}

						object o_conto_debito_credito = Reader.getCurrField("conto_debito_credito");
						if (o_conto_debito_credito != DBNull.Value) {
							string conto_debito_credito = o_conto_debito_credito.ToString();
							object idacc = getidAcc(Account, conto_debito_credito, ayear);

							if (idacc == null || idacc == DBNull.Value) {
								SpeedSaver.AddError("Voce del piano dei conti " + conto_debito_credito + " del " +
								                    ayear.ToString() +
								                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
								Reader.GetNext();
								continue;
							}
							else {
								REL["idaccdebit"] = idacc;
							}
						}

						if (nsub != DBNull.Value) {
							DataRow pb = PaymentBank.NewRow();
							pb["kpay"] = kpaymentproceeds;
							pb["idpay"] = nsub;
							pb["amount"] = Reader.getCurrField("amount");
							object idreg = Reader.getCurrField("idreg");
							if (idreg == DBNull.Value) idreg = -1;
							pb["idreg"] = idreg;
							pb["nbill"] = Reader.getCurrField("nbill");
							pb["description"] = Reader.getCurrField("description");
							PaymentBank.Rows.Add(pb);
						}

					}

				} //if (tipo=="S")
				else {
					CheckMovPhase(D.Tables["incomephase"], nfase, Reader.getCurrField("descliv"));

					object paridinc = DBNull.Value;
					if (nfase > 1) {
						paridinc = Conn.DO_READ_VALUE("income", fparentmov, "idinc");
						if (paridinc == DBNull.Value || paridinc == null) {
							SpeedSaver.AddError(me +
							                    ": movimento parent non trovato, possibile errato ordine righe file. Riga:"
							                    + Reader.GetCurrRowNumber());
							paridinc = DBNull.Value;
							Reader.GetNext();
							continue;
						}
					}


					DataRow Rinc = null;
					object idinc = Conn.DO_READ_VALUE("income", fmov, "idinc");
					bool new_idinc = false;
					//Creazione/recupero movimento di spesa
					if (idinc == null || idinc == DBNull.Value) {
						//Crea il movimento 
						Rinc = MetaIncome.Get_New_Row(null, Income);
						int idinc2 = CfgFn.GetNoNullInt32(Rinc["idinc"]);
						if (idinc2 < 10000000) idinc2 = 10000000;
						Rinc["idinc"] = idinc2;
						RowChange.ClearAutoIncrement(Income.Columns["nmov"]);
						Rinc["parentidinc"] = paridinc;
						Rinc["nphase"] = nfase;
						Rinc["ymov"] = ymov;
						Rinc["nmov"] = nmov;
						descr = Reader.getCurrField("description");
						if (descr == DBNull.Value) {
							SpeedSaver.AddWarning(me + ": descrizione vuota sostituita con un punto. Riga:" +
							                      Reader.GetCurrRowNumber());
							descr = ".";
						}

						Rinc["description"] = descr;
						Rinc["doc"] = Reader.getCurrField("doc");
						Rinc["docdate"] = ToSmalldateTime(Reader.getCurrField("docdate"));
						Rinc["txt"] = Reader.getCurrField("note");
						Rinc["adate"] = ToSmalldateTime(Reader.getCurrField("adate"));
						Rinc["idreg"] = Reader.getCurrField("idreg");
						Rinc["external_reference"] = Reader.getCurrField("rif_esterno");
						Rinc["idman"] = idman;
						// Generazione automatismi
						Rinc["autokind"] = Reader.getCurrField("autokind");
						Rinc["autocode"] = Reader.getCurrField("autocode");
						// Lettura del pagamento principale se esiste e valorizzazione di idpayment sull'entrata
						object idpayment = DBNull.Value;
						object nfasepayment = Reader.getCurrField("nlvpagprincipale");
						object ymovpayment = Reader.getCurrField("ymovpagprincipale");
						object nmovpayment = Reader.getCurrField("nmovpagprincipale");
						if (ymovpayment != DBNull.Value) {
							string fpayment = QHS.AppAnd(QHS.CmpEq("ymov", ymovpayment),
								QHS.CmpEq("nmov", nmovpayment),
								QHS.CmpEq("nphase", nfasepayment));
							idpayment = Conn.DO_READ_VALUE("expense", fparentmov, "idexp");
							if (idpayment == DBNull.Value || idpayment == null) {
								SpeedSaver.AddError(me +
								                    ": movimento principale non trovato. Riga:"
								                    + Reader.GetCurrRowNumber());
								Reader.GetNext();
								idpayment = DBNull.Value;
								continue;
							}
						}

						Rinc["idpayment"] = idpayment;
						new_idinc = true;
					}
					else {
						Conn.RUN_SELECT_INTO_TABLE(Income, null, fmov, null, true);
						Rinc = Income.Select(QHC.CmpEq("idinc", idinc))[0];
					}

					bool new_incyear = true;
					//Verifica se esiste exp.year
					if (new_incyear == false) {
						string fltincyear = QHS.AppAnd(QHS.CmpEq("idinc", idinc), QHS.CmpEq("ayear", ayear));
						if (Conn.RUN_SELECT_COUNT("incomeyear", fltincyear, false) > 0) new_incyear = false;
					}

					if (new_incyear) {
						//Mette expenseyear 
						DataRow RIY = MetaIncomeYear.Get_New_Row(Rinc, IncomeYear);
						RIY["ayear"] = ayear;
						RIY["idfin"] = idfin;
						RIY["idupb"] = idupb;
						RIY["amount"] = Reader.getCurrField("amount");
					}

					string is_ilast = Reader.getCurrField("last").ToString();
					bool new_inclast = true;
					if (is_ilast == "N") {
						new_inclast = false;
					}
					else {
						//Mette ExpenseLast ove necessario
						if (new_idinc == false) {
							string fltinclast = QHS.CmpEq("idinc", idinc);
							if (Conn.RUN_SELECT_COUNT("incomelast", fltinclast, false) > 0) new_inclast = false;
						}
					}

					if (new_inclast) {
//Mette expenselast
						DataRow RIL = MetaIncomeLast.Get_New_Row(Rinc, IncomeLast);
						RIL["kpro"] = kpaymentproceeds;
						RIL["nbill"] = Reader.getCurrField("nbill");
						if (RIL["nbill"] != DBNull.Value) {
							RIL["flag"] = 1;
						}

						RIL["idpro"] = nsub;

						object o_conto_debito_credito = Reader.getCurrField("conto_debito_credito");
						if (o_conto_debito_credito != DBNull.Value) {
							string conto_debito_credito = o_conto_debito_credito.ToString();
							object idacc = getidAcc(Account, conto_debito_credito, ayear);

							if (idacc == null || idacc == DBNull.Value) {
								SpeedSaver.AddError("Voce del piano dei conti " + conto_debito_credito + " del " +
								                    ayear.ToString() +
								                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
								Reader.GetNext();
								continue;
							}
							else {
								RIL["idacccredit"] = idacc;
							}
						}


						if (nsub != DBNull.Value) {
							DataRow pb = ProceedsBank.NewRow();
							pb["kpro"] = kpaymentproceeds;
							pb["idpro"] = nsub;
							pb["amount"] = Reader.getCurrField("amount");
							object idreg = Reader.getCurrField("idreg");
							if (idreg == DBNull.Value) idreg = -1;
							pb["idreg"] = idreg;
							pb["nbill"] = Reader.getCurrField("nbill");
							pb["description"] = Reader.getCurrField("description");

							ProceedsBank.Rows.Add(pb);
						}
					}
				}

				nrow++;
				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();




			bool res = SaveData(D, true);
			//Conn.SQLRunner("ALTER TABLE  EXPENSE ENABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  EXPENSEYEAR ENABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  EXPENSELAST ENABLE TRIGGER ALL");

			//Conn.SQLRunner("ALTER TABLE  INCOME ENABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  INCOMEYEAR ENABLE TRIGGER ALL");
			//Conn.SQLRunner("ALTER TABLE  INCOMELAST ENABLE TRIGGER ALL");

			return res;
		}

		string[] tracciato_varmov = new string[] {
			"tipo;Tipo movimento (E=Var.Entrata,S=Var.Spesa);Codificato;1;E|S",
			"nliv;Numero fase movimento;Intero;1",
			"descliv;Descrizione fase movimento;Stringa;50",
			"ymov;Esercizio movimento;Intero;4",
			"nmov;Numero movimento;Intero;8",
			"yvar;Esercizio variazione;Intero;4",
			"nvar;Numero variazione;Intero;8",
			"description;Descrizione;Stringa;150",
			"doc;Documento;Stringa;35",
			"docdate;Data documento;Data;8",
			"adate;Data Contabile;Data;8",
			"amount;Importo variazione;Numero;22",
			"numelenco;Numero elenco di trasmissione;Intero;6",
			"datatrasmissione;Data documento;Data;8",
			"tipovar;Tipo variazione (1=normale, 2= annullamento totale, 3=annullamento parziale, 4= modifica dati trasmesssi);Codificato;1;1|2|3|4"
		};

		string[] tracciato_varmovbudget = new string[] {
			"tipo;Tipo movimento (A=Var.Accertamento/Preaccertamento,I=Var.Impegno/Preimpegno);Codificato;1;A|I",
			"nliv;Numero fase movimento;Intero;1",
			"descliv;Descrizione fase movimento;Stringa;50",
			"ymov;Esercizio movimento;Intero;4",
			"nmov;Numero movimento;Intero;8",
			"yvar;Esercizio variazione;Intero;4",
			"nvar;Numero variazione;Intero;8",
			"description;Descrizione;Stringa;150",
			"doc;Documento;Stringa;35",
			"docdate;Data documento;Data;8",
			"adate;Data Contabile;Data;8",
			"amount;Importo variazione;Numero;22",
			"amount2;Importo variazione anno+1;Numero;22",
			"amount3;Importo variazione anno+2;Numero;22",
			"amount4;Importo variazione anno+3;Numero;22",
			"amount5;Importo variazione anno+4;Numero;22"
		};

		private void btnVarMovFin_Click(object sender, EventArgs e) {
			ImportaVarMovFin(false);
		}

		bool ImportaVarMovConTrigger() {
			return ImportaVarMovFin(true);
		}

		bool ImportaVarMovSenzaTrigger() {
			return ImportaVarMovFin(false);
		}

		bool ImportaVarMovBudget_Trigger() {
			return ImportaVarMovBudget(true);
		}

		bool ImportaVarMovBudget_noTrigger() {
			return ImportaVarMovBudget(false);
		}

		bool ImportaVarMovBudget(bool triggerAbilitati) {
			LeggiFile Reader = GetReader(tracciato_varmovbudget);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaVarMovBudget();

			DataTable EpexpVar = D.Tables["epexpvar"];
			MetaData MetaEpExpVar = Meta.Dispatcher.Get("epexpvar");
			MetaEpExpVar.SetDefaults(EpexpVar);

			DataTable EpaccVar = D.Tables["epaccvar"];
			MetaData MetaEpaccVar = Meta.Dispatcher.Get("epaccvar");
			MetaEpaccVar.SetDefaults(EpaccVar);

			Reader.GetNext();

			List<string> tosync = new List<string>();
			InitSpeedSaver(Conn, tosync);

			if (!triggerAbilitati) {
				Conn.SQLRunner("ALTER TABLE  EPEXPVAR DISABLE TRIGGER ALL");
				Conn.SQLRunner("ALTER TABLE  EPACCVAR DISABLE TRIGGER ALL");
			}

			while (Reader.DataPresent()) {
				string tipo = Reader.getCurrField("tipo").ToString().ToUpper(); // A/I
				object ymov = Reader.getCurrField("ymov");
				object nmov = Reader.getCurrField("nmov");
				object nfase = Reader.getCurrField("nliv");
				object nvar = Reader.getCurrField("nvar");
				object yvar = Reader.getCurrField("yvar");

				if (nvar == null || nvar == DBNull.Value) {
					SpeedSaver.AddError("Campo mancante: n. variazione, riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				string fmovS = QHS.AppAnd(QHS.CmpEq("yepexp", ymov), QHS.CmpEq("nepexp", nmov),
					QHS.CmpEq("nphase", nfase));
				string fmovE = QHS.AppAnd(QHS.CmpEq("yepacc", ymov), QHS.CmpEq("nepacc", nmov),
					QHS.CmpEq("nphase", nfase));
				object idmov = DBNull.Value;
				//Finalmente aggiunge il mandato o la reversale
				if (tipo == "I")
					idmov = Conn.DO_READ_VALUE("epexp", fmovS, "idepexp");
				else
					idmov = Conn.DO_READ_VALUE("epacc", fmovE, "idepacc");


				string mov = Reader.getCurrField("descliv") + " num. " + nmov.ToString() + " del " + ymov.ToString();
				if (idmov == null || idmov == DBNull.Value) {
					SpeedSaver.AddError("Movimento non trovato: " + mov + ", riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow Var = null;
				if (tipo == "I") {
					string fltmovS = QHS.AppAnd(QHS.CmpEq("idepexp", idmov), QHS.CmpEq("nvar", nvar));
					if (Conn.RUN_SELECT_COUNT("epexpvar", fltmovS, false) > 0) {
						object max_nvar = Conn.DO_READ_VALUE("epexpvar", QHS.CmpEq("idepexp", idmov), "max(nvar)");
						nvar = CfgFn.GetNoNullInt32(max_nvar) + 1;
						//Reader.GetNext();
						//continue;
					}

					Var = MetaEpExpVar.Get_New_Row(null, EpexpVar);
					RowChange.ClearAutoIncrement(EpexpVar.Columns["nvar"]);
					Var["idepexp"] = idmov;

				}
				else {
					string fltmovI = QHS.AppAnd(QHS.CmpEq("idepacc", idmov), QHS.CmpEq("nvar", nvar));
					if (Conn.RUN_SELECT_COUNT("epaccvar", fltmovI, false) > 0) {
						object max_nvar = Conn.DO_READ_VALUE("epaccvar", QHS.CmpEq("idepacc", idmov), "max(nvar)");
						nvar = CfgFn.GetNoNullInt32(max_nvar) + 1;
						//Reader.GetNext();
						//continue;
					}

					Var = MetaEpaccVar.Get_New_Row(null, EpaccVar);
					RowChange.ClearAutoIncrement(EpaccVar.Columns["nvar"]);
					Var["idepacc"] = idmov;
				}

				foreach (string field in new string[] {
					"yvar", "description", "amount", "amount2", "amount3", "amount4", "amount5"
				}) Var[field] = Reader.getCurrField(field);
				Var["nvar"] = nvar;
				Var["adate"] = ToSmalldateTime(Reader.getCurrField("adate"));

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool res = SaveData(D, true);

			if (!triggerAbilitati) {
				Conn.SQLRunner("ALTER TABLE  epexpvar ENABLE TRIGGER ALL");
				Conn.SQLRunner("ALTER TABLE  epaccvar ENABLE TRIGGER ALL");
			}

			return res;
		}

		bool ImportaVarMovFin(bool triggerAbilitati) {
			LeggiFile Reader = GetReader(tracciato_varmov);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaVarMov();

			DataTable ExpenseVar = D.Tables["expensevar"];
			MetaData MetaExpenseVar = Meta.Dispatcher.Get("expensevar");
			MetaExpenseVar.SetDefaults(ExpenseVar);

			DataTable IncomeVar = D.Tables["incomevar"];
			MetaData MetaIncomeVar = Meta.Dispatcher.Get("incomevar");
			MetaIncomeVar.SetDefaults(IncomeVar);

			DataTable PaymentTransmission = D.Tables["paymenttransmission"];
			MetaData MetaPaymentTransmission = Meta.Dispatcher.Get("paymenttransmission");
			MetaPaymentTransmission.SetDefaults(PaymentTransmission);

			DataTable ProceedsTransmission = D.Tables["proceedstransmission"];
			MetaData MetaProceedsTransmission = Meta.Dispatcher.Get("proceedstransmission");
			MetaProceedsTransmission.SetDefaults(ProceedsTransmission);

			Conn.RUN_SELECT_INTO_TABLE(PaymentTransmission, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(ProceedsTransmission, null, null, null, false);

			Reader.GetNext();

			List<string> tosync = new List<string>();
			tosync.Add("paymenttransmission");
			tosync.Add("proceedstransmission");
			InitSpeedSaver(Conn, tosync);

			if (!triggerAbilitati) {
				Conn.SQLRunner("ALTER TABLE  EXPENSEVAR DISABLE TRIGGER ALL");
				Conn.SQLRunner("ALTER TABLE  INCOMEVAR DISABLE TRIGGER ALL");
			}

			while (Reader.DataPresent()) {
				string tipo = Reader.getCurrField("tipo").ToString().ToUpper(); // E/S
				object ymov = Reader.getCurrField("ymov");
				object nmov = Reader.getCurrField("nmov");
				object nfase = Reader.getCurrField("nliv");
				object nvar = Reader.getCurrField("nvar");
				object yvar = Reader.getCurrField("yvar");
				object tipovar = Reader.getCurrField("tipovar");
				if (tipovar == DBNull.Value) tipovar = 1;
				object autokind;
				switch (CfgFn.GetNoNullInt32(tipovar)) {
					case 1:
						autokind = DBNull.Value; //var. normale
						break;
					case 2:
						autokind = 11; //annullo totale
						break;
					case 3:
						autokind = 10; //annullo parziale
						break;
					case 4:
						autokind = 22; //modifica dati trasmessi
						break;
					default:
						autokind = DBNull.Value;
						break;
				}

				string fmov = QHS.AppAnd(QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov),
					QHS.CmpEq("nphase", nfase));
				object idmov = DBNull.Value;
				//Finalmente aggiunge il mandato o la reversale
				if (tipo == "S")
					idmov = Conn.DO_READ_VALUE("expense", fmov, "idexp");
				else
					idmov = Conn.DO_READ_VALUE("income", fmov, "idinc");


				string mov = Reader.getCurrField("descliv") + " num. " + nmov.ToString() + " del " + ymov.ToString();
				if (idmov == null || idmov == DBNull.Value) {
					SpeedSaver.AddError("Movimento non trovato: " + mov + ", riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow Var = null;
				if (tipo == "S") {
					string fltmovS = QHS.AppAnd(QHS.CmpEq("idexp", idmov), QHS.CmpEq("nvar", nvar));
					if (Conn.RUN_SELECT_COUNT("expensevar", fltmovS, false) > 0) {
						object max_nvar = Conn.DO_READ_VALUE("expensevar", QHS.CmpEq("idexp", idmov), "max(nvar)");
						nvar = CfgFn.GetNoNullInt32(max_nvar) + 1;
						//Reader.GetNext();
						//continue;
					}

					Var = MetaExpenseVar.Get_New_Row(null, ExpenseVar);
					RowChange.ClearAutoIncrement(ExpenseVar.Columns["nvar"]);
					Var["idexp"] = idmov;

				}
				else {
					string fltmovI = QHS.AppAnd(QHS.CmpEq("idinc", idmov), QHS.CmpEq("nvar", nvar));
					if (Conn.RUN_SELECT_COUNT("incomevar", fltmovI, false) > 0) {
						object max_nvar = Conn.DO_READ_VALUE("incomevar", QHS.CmpEq("idinc", idmov), "max(nvar)");
						nvar = CfgFn.GetNoNullInt32(max_nvar) + 1;
						//Reader.GetNext();
						//continue;
					}

					Var = MetaIncomeVar.Get_New_Row(null, IncomeVar);
					RowChange.ClearAutoIncrement(IncomeVar.Columns["nvar"]);
					Var["idinc"] = idmov;
				}

				Var["autokind"] = autokind;
				object numelenco = Reader.getCurrField("numelenco");
				object idtrasm = DBNull.Value;
				object idtreasurer = DBNull.Value;
				object kpaypro = DBNull.Value;
				if (numelenco != DBNull.Value) {
					if (tipo == "S") {
						kpaypro = Conn.DO_READ_VALUE("expenselast", QHS.CmpEq("idexp", idmov), "kpay");
						if (kpaypro != DBNull.Value && kpaypro != null) {
							idtreasurer = Conn.DO_READ_VALUE("payment", QHS.CmpEq("kpay", kpaypro), "idtreasurer");
							idtrasm = GetPaymentTransmission(PaymentTransmission, yvar, numelenco, idtreasurer,
								Reader.getCurrField("datatrasmissione"));
						}
					}
					else {
						kpaypro = Conn.DO_READ_VALUE("incomelast", QHS.CmpEq("idinc", idmov), "kpro");
						if (kpaypro != DBNull.Value && kpaypro != null) {
							idtreasurer = Conn.DO_READ_VALUE("proceeds", QHS.CmpEq("kpro", kpaypro), "idtreasurer");
							idtrasm = GetProceedsTransmission(ProceedsTransmission, yvar, numelenco, idtreasurer,
								Reader.getCurrField("datatrasmissione"));
						}
					}

				}

				if (tipo == "S")
					Var["kpaymenttransmission"] = idtrasm;
				else
					Var["kproceedstransmission"] = idtrasm;

				foreach (string field in new string[] {
					"yvar", "description", "doc", "amount"
				}) Var[field] = Reader.getCurrField(field);
				Var["nvar"] = nvar;
				Var["adate"] = ToSmalldateTime(Reader.getCurrField("adate"));
				Var["docdate"] = ToSmalldateTime(Reader.getCurrField("docdate"));

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool res = SaveData(D, true);

			if (!triggerAbilitati) {
				Conn.SQLRunner("ALTER TABLE  expensevar ENABLE TRIGGER ALL");
				Conn.SQLRunner("ALTER TABLE  incomevar ENABLE TRIGGER ALL");
			}

			return res;
		}


		string[] tracciato_classificazioni = new string[] {
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"descrsorkind;Descrizione tipo classificazione;Stringa;50",
			"startsorkind;anno inizio tipo classificazione;Intero;4",
			"stopsorkind;anno fine tipo classificazione;Intero;4",
			"nphaseincome;Livello associazione alle entrate del tipo classificazione;Intero;1",
			"nphaseexpense;Livello associazione alle spese del tipo classificazione;Intero;1",
			"sortcode;Codice classificazione;Stringa;50",
			"parentsortcode;Codice classificazione del nodo parent;Stringa;50",
			"printingorder;Ordine di stampa;Stringa;50",
			"nlevel;N. Livello classificazione;Intero;2",
			"usable;Livello operativo (S/N);Codificato;1;S|N",
			"descrlevel;Descrizione livello classificazione;Stringa;50",
			"description;Descrizione voce classificazione;Stringa;200",
			"startsorting;anno inizio voce classificazione;Intero;4",
			"stopsorting;anno fine voce classificazione;Intero;4",
			"movkind;tipo movimento (E/S);Codificato;1;E|S|X"
		};

		private void btnClassificazioni_Click(object sender, EventArgs e) {
			ImportaClassificazioni();
		}

		bool ImportaClassificazioni() {
			LeggiFile Reader = GetReader(tracciato_classificazioni);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			vistaClassificazioni D = new vistaClassificazioni();
			ClearDataSet.Clear(D);

			MetaData MetaSorting = Meta.Dispatcher.Get("sorting");
			MetaData MetaSortingLevel = Meta.Dispatcher.Get("sortinglevel");
			MetaData MetaSortingkind = Meta.Dispatcher.Get("sortingkind");
			DataTable Sorting = D.Tables["sorting"];
			DataTable SortingLevel = D.Tables["sortinglevel"];
			DataTable Sortingkind = D.Tables["sortingkind"];
			RowChange.MarkAsAutoincrement(Sorting.Columns["idsor"], null, null, 8);
			int baseIdSor = 9999000;

			Conn.RUN_SELECT_INTO_TABLE(SortingLevel, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Sortingkind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortinglevel");
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);

			MetaSorting.SetDefaults(Sorting);
			MetaSortingLevel.SetDefaults(SortingLevel);
			MetaSortingkind.SetDefaults(Sortingkind);

			bool to_repeat = true;
			bool somedone = false;
			while (to_repeat) {
				to_repeat = false;
				somedone = false;

				Reader.Reset();
				Reader.GetNext();

				while (Reader.DataPresent()) {

					//Verifica il tipo classificazione
					object idsorkind = GetSortingKind(Sortingkind,
						Reader.getCurrField("codesorkind"), Reader.getCurrField("descrsorkind"),
						Reader.getCurrField("startsorkind"), Reader.getCurrField("stopsorkind"),
						Reader.getCurrField("nphaseincome"), Reader.getCurrField("nphaseexpense"));

					string filter_exists =
						QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkind),
							QHC.CmpEq("sortcode", Reader.getCurrField("sortcode")));
					object kind = Reader.getCurrField("movkind");
					if (kind != null && kind != DBNull.Value && kind.ToString().ToUpper() != "X") {
						filter_exists = QHC.AppAnd(filter_exists, QHC.CmpEq("movkind", kind));
					}

					if (Sorting.Select(filter_exists).Length > 0) {
						Reader.GetNext();
						continue;
					}

					//individua il nodo parent
					object parcode = Reader.getCurrField("parentsortcode");
					DataRow RParSor = null;
					if (parcode != DBNull.Value) {
						string filter = QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkind),
							QHC.CmpEq("sortcode", parcode));
						string filterSQL = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
							QHS.CmpEq("sortcode", parcode));
						if (kind != null && kind != DBNull.Value && kind.ToString().ToUpper() != "X") {
							filterSQL = QHS.AppAnd(filterSQL, QHS.CmpEq("movkind", kind));
						}

						if (Sorting.Select(filter).Length == 0) {
							Conn.RUN_SELECT_INTO_TABLE(Sorting, null, filterSQL, null, false);
							if (Sorting.Select(filter).Length == 0) {
								SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + parcode +
								                      " padre del nodo avente codice " +
								                      Reader.getCurrField("codesorkind").ToString() +
								                      "-" + Reader.getCurrField("sortcode").ToString());
								Reader.GetNext();
								to_repeat = true;
								continue;
							}
						}

						RParSor = Sorting.Select(filter)[0];
					}

					//Aggiunge le informazioni di livello ove necessario
					int Nlev = CfgFn.GetNoNullInt32(Reader.getCurrField("nlevel"));
					string levelname = Reader.getCurrField("descrlevel").ToString();
					CheckSortingLevel(SortingLevel, Nlev, levelname, idsorkind, Reader.getCurrField("usable"));

					DataRow RSor = Sorting.NewRow();
					RSor["idsor"] = baseIdSor++;
					if (RParSor != null) {
						RSor["paridsor"] = RParSor["idsor"];
						RSor["idsorkind"] = RParSor["idsorkind"];
					}
					else {
						RSor["idsorkind"] = idsorkind;
					}


					RSor["sortcode"] = Reader.getCurrField("sortcode");
					RSor["nlevel"] = Nlev;
					if (kind != null && kind != DBNull.Value && kind.ToString().ToUpper() != "X") {
						RSor["movkind"] = kind;
					}

					RSor["description"] = Reader.getCurrField("description").ToString();
					RSor["printingorder"] = Reader.getCurrField("printingorder").ToString();
					RSor["start"] = Reader.getCurrField("startsorting");
					RSor["stop"] = Reader.getCurrField("stopsorting");
					RSor["ct"] = DateTime.Now;
					RSor["lt"] = DateTime.Now;
					RSor["cu"] = "importazione";
					RSor["lu"] = "importazione";
					Sorting.Rows.Add(RSor);
					somedone = true;

					Reader.GetNext();
				} //while (Reader.DataPresent()) 

				if (to_repeat && !somedone) {
					SpeedSaver.AddError("Ci sono nodi child senza parent,verificare. Riga:" +
					                    Reader.GetCurrRowNumber());
					to_repeat = false;
				}

			} // while (to_repeat) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		string[] tracciato_classmov = new string[] {
			"tipo;Tipo movimento (E=Entrata,S=Spesa);Codificato;1;E|S",
			"nliv;Numero fase movimento;Intero;1",
			"descliv;Descrizione fase movimento;Stringa;50",
			"ymov;Esercizio movimento;Intero;4",
			"nmov;Numero movimento;Intero;8",
			"amount;Importo variazione;Numero;22",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"description;Descrizione voce classificazione;Stringa;200",
			"ayear;Anno di imputazione della classificazione;Intero;4"
		};

		private void btnClassMovimenti_Click(object sender, EventArgs e) {
			ImportaClassMovimenti();
		}

		bool ImportaClassMovimenti() {
			LeggiFile Reader = GetReader(tracciato_classmov);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaClassMov();

			DataTable ExpenseSorted = D.Tables["expensesorted"];
			MetaData MetaExpenseSorted = Meta.Dispatcher.Get("expensesorted");
			MetaExpenseSorted.SetDefaults(ExpenseSorted);

			DataTable IncomeSorted = D.Tables["incomesorted"];
			MetaData MetaIncomeSorted = Meta.Dispatcher.Get("incomesorted");
			MetaIncomeSorted.SetDefaults(IncomeSorted);

			DataTable SortingKind = D.Tables["sortingkind"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);




			Reader.GetNext();
			int N = 0;
			string lastfilter = "";

			while (Reader.DataPresent()) {
				N = N + 1;
				string tipo = Reader.getCurrField("tipo").ToString().ToUpper(); // E/S
				object ymov = Reader.getCurrField("ymov");
				object nmov = Reader.getCurrField("nmov");
				object nfase = Reader.getCurrField("nliv");

				string fmov = QHS.AppAnd(QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov),
					QHS.CmpEq("nphase", nfase));
				object idmov = DBNull.Value;
				//Finalmente aggiunge il mandato o la reversale
				if (tipo == "S")
					idmov = Conn.DO_READ_VALUE("expense", fmov, "idexp");
				else
					idmov = Conn.DO_READ_VALUE("income", fmov, "idinc");


				string mov = Reader.getCurrField("descliv") + " num. " + nmov.ToString() + " del " + ymov.ToString();
				if (idmov == null || idmov == DBNull.Value) {
					SpeedSaver.AddError("Movimento non trovato: " + mov);
					Reader.GetNext();
					continue;
				}

				string searchsorkind = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkind"));
				if (SortingKind.Select(searchsorkind).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione non trovato: " +
					                    Reader.getCurrField("codesorkind").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkind = SortingKind.Select(searchsorkind)[0]["idsorkind"];

				string searchsor = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcode")));
				object idsor = Conn.DO_READ_VALUE("sorting", searchsor, "idsor");
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddWarning(mov + ": Classificazione non trovata: " +
					                      Reader.getCurrField("codesorkind").ToString() + "/" +
					                      Reader.getCurrField("sortcode").ToString() +
					                      " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				string currfilter = tipo + '-' + idmov + '-' + idsor;
				if (N > 100 && lastfilter != currfilter) {
					if (!SaveData(D, false)) break;
					N = 0;
					D.Tables["expensesorted"].Clear();
					D.Tables["incomesorted"].Clear();
				}

				lastfilter = currfilter;



				DataRow SorMov = null;

				if (tipo == "S") {
					MetaData.SetDefault(ExpenseSorted, "idsor", idsor);
					MetaData.SetDefault(ExpenseSorted, "idexp", idmov);
					SorMov = MetaExpenseSorted.Get_New_Row(null, ExpenseSorted);

				}
				else {
					MetaData.SetDefault(IncomeSorted, "idsor", idsor);
					MetaData.SetDefault(IncomeSorted, "idinc", idmov);
					SorMov = MetaIncomeSorted.Get_New_Row(null, IncomeSorted);

				}

				foreach (string field in new string[] {
					"amount", "description", "ayear"
				}) SorMov[field] = Reader.getCurrField(field);


				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		/*
		 * 
		 *  Corretto il tracciato a causa di un campo errato! datascadenzapag
		 * 
		        string[] tracciato_fatture =
		            new string[]{
		                        "tipologia;"+
		                                "21: Società, enti commerciali, ditte individuali e studi associati "+
		                                "22: Persona Fisica "+
		                                "23: Enti non commerciali ed istituzioni internazionali "+
		                                "24: Anagrafiche complementari "+
		                                "25: Non utilizzabile; "+
		                                "Codificato;"+
		                                "2;"+
		                                "21|22|23|24|25",
		                         "tiporesidenza;"+
		                                "I in Italia J in UE X extra UE;"+
		                                "Codificato;"+
		                                "1;"+
		                                "I|J|X",
		                        "denominazione;usata negli elenchi;Stringa;100",
		                        "nome;Nome;Stringa;50",
		                        "cognome;Cognome;Stringa;50",
		                        "sesso;Sesso;Codificato;1;M|F",
		                        "p_iva;P.Iva;Stringa;15",
		                        "cf;C.F.;Stringa;16",
		                        "cf_ext;C.F. Estero;Stringa;20",
		                        "datanasc;Data Nascita;Data;8",
		                        "localitanasc;Località Nascita;stringa;50",
		                        "catastalenasc;Codice catastale del comune o stato di nascita (sono i penultimi 4 caratteri del codice fiscale);Stringa;4",
		                        "matricola;Matricola;Stringa;40",
		                        "note;Note;Stringa;400",
		                        "esenteeq;Esente equitalia;Codificato;1;S|N",
		                        "cfduplicato;Ammetti codice fiscale duplicato;Codificato;1;S|N",
		                        "attiva;Anagrafica utilizzabile;Codificato;1;S|N",
		                        //indirizzo predefinito/residenza
		                        "dataind_res;Data inizio validità indirizzo predefinito;Data;8",
		                        "indirizzo_res;Indirizzo predefinito;Stringa;100",
		                        "cap_res;CAP indirizzo predefinito;Stringa;5",
		                        "ufficio_res;Ufficio predefinito;Stringa;50",
		                        "catastale_res;Codice catastale del comune o stato estero dell'indirizzo predefinito;Stringa;4",
		                        "localita_res;Località per l'indirizzo predefinito;Stringa;50",
		                        //domicilio fiscale ove diverso dal predefinito
		                        "dataind_dom;Data inizio validità dom.fiscale;Data;8",
		                        "indirizzo_dom;Indirizzo dom.fiscale;Stringa;100",
		                        "cap_dom;CAP indirizzo dom.fiscale;Stringa;5",
		                        "ufficio_dom;Ufficio dom.fiscale;Stringa;50",
		                        "catastale_dom;Codice catastale del comune del dom.fiscale;Stringa;4",
		                        "localita_dom;Località per il dom.fiscale;Stringa;50",
		                        //modalità di pagamento
		                        "tipomodpag;tipo modalità di pagamento "+
		                            "1-Assegno circolare  (non ammette delegato o coordinate bancarie) "+
		                            "3-Bonifico presso altre banche (non ammette delegato, coord.bancarie obbligatorie) "+
		                            "4-Bonifico presso istituto cassiere (non ammette delegato, coord.bancarie obbligatorie) "+
		                            "5-Conto corrente postale (ammette solo il cc) "+
		                            "6-Esclusiva cassiere (non ammette delegato o coord.bancarie) "+
		                            "7-Sportello (ammette delegato e  non ammette coord.bancarie);"+
		                            "Codificato;1;1|3|4|5|6|7",
		                        "nomemod;Nome modalità;Stringa;50",
		                        "abi;ABI;Stringa;10",
		                        "cab;CAB;Stringa;10",
		                        "cin;CIN;Stringa;5",
		                        "cc;Conto corrente;Stringa;30",
		                        "delegato;Codice delegato (di anagrafica);Intero;10",
		                        "valuta;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",
		                        "tiposcadenza;Tipo scadenza "+
		                            "1-data contabile,2-data documento,"+
		                            "3-fine mese data contabile,4-fine mese data documento,"+
		                            "5-Pagamento immediato;Codificato;1;1|2|3|4|5",
		                        "ggscadenza;Giorni dalla scadenza;intero;2",
		                        "iban;IBAN;Stringa;50",
		                        "datainizioposgiurid;Data Inizio Posizione giuridica;Data;8",
		                        "imponpresunto;Imponibile presunto anno;Numero;22",
		                        "classestipendiale;Classe Stipendiale;Intero;8",
		                        "codicequalifica;Codice Qualifica;Stringa;20",
		                        // Info generali fattura
		                        "codtipofattura; Codice Tipo Fattura;Stringa;20", 		   	
		                        "annofattura;Anno;Intero;4", 							
		                        "numfattura;Numero Fattura;Intero;8", 						
		                        "acquistovendita;Acquisto o Vendita (A/V);Codificato;1;A|V", 	   		
		                        "notacredito;Nota di Credito (S/N);Codificato;1;S|N",		   		
		                        "codtipofatturaprinc; Codice Tipo Fattura Principale (Note Credito);Stringa;20",  		
		                        "annofatturaprinc;Anno  Fattura Principale (Note Credito);Intero;4",  						
		                        "numfatturaprinc;Numero Fattura Principale (Note Credito);Intero;8", 							
		                        "descrfattura;Descrizione Fattura;Stringa;150", 				
		                        "codexpirationkind; Tipo Scadenza" 	+ 
		                            "1-DataContabile" 		+ 
		                            "2-Data Documento" 		+
		                            "3-Fine mese Data Documento" 	+
		                            "4-Fine Mese Data Contabile" 	+
		                            "5-Pagamento Immediato;" 	+ 
		                            "Codificato;1;1|2|3|4|5", 					
		                        "paymentexpiring;Data scadenza pagamento;Intero;8", 				
		                        "datadoctrasporto;Data Documento di Trasporto;Data;8",				
		                        "numdoctrasporto;Numero Documento di Trasporto;Stringa;25",			
		                        "codicecass;Codice Cassiere per Incasso (solo fatture di Vendita);Stringa;20",	
		                        "valuta;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",		
		                        "tassocambio;Tasso di Cambio della fattura (Euro/Valuta Estera, 1 se la Fattura è in EURO);Numero;22",					
		                        "doc;Documento Collegato;Stringa;35", 					
		                        "datadoc;Data documento collegato;Data;8", 					 
		                        "datafatt;Data contabile;Data;8",						
		                        "ivadifferita;Fattura a Iva Differita (S/N);Codificato;1;S|N",			
		                        "attivo;Attivo (S/N);Codificato;1;S|N", 					
		                        // Info dettaglio fattura
		                        "descrdettaglio;Descrizione Dettaglio Fattura;Stringa;150",			
		                        "codtipoiva;Codice Tipo IVA;Stringa;20", 					
		                        "iva;Importo IVA del dettaglio;Numero;22",							
		                        "ivaindetr; Importo IVA indetraibile del dettaglio;Numero;22",			
		                        "quantita;Quantita;Numero;22",							
		                        "impon;Imponibile UNITARIO;Numero;22",						
		                        "scontoperc;Percentuale Sconto;Numero;22",				
		                        "note;Note;Stringa;400",
		                        "flagutilizzabilecontab;Utilizzabile per la contabilizzazione;Codificato;1;S|N"
		         };

		*/

		string[] tracciato_cpassivi = new string[] {

			"idreg;Codice anagrafica;Intero;8",
			"anagrafica_dettaglio;Anagrafica in dettaglio contratto;Codificato;1;S|N",

			//Specifici per c.passivo
			"codice_cpassivo;Codice tipo ordine;Stringa;20",
			"anno_cpassivo;Anno ordine;Intero;4",
			"numero_cpassivo;Numero ordine;Intero;8",
			"datacont;Data contabile;Data;8",
			"indcons;Indirizzo consegna;Stringa;150",
			"datacons;Termine consegna;Stringa;50",
			"descrizione;Descrizione ordine;Stringa;150",
			"doc;Documento collegato;Stringa;35",
			"datadoc;Data documento;Data;8",

			"note_ordine;Note sull'ordine;Stringa;500",
			"codexpirationkind; Tipo Scadenza" +
			"1-DataContabile" +
			"2-Data Documento" +
			"3-Fine mese Data Documento" +
			"4-Fine Mese Data Contabile" +
			"5-Pagamento Immediato;" +
			"Codificato;1;1|2|3|4|5",
			"scadenzapag;scadenza pagamento;Intero;4",
			"valuta_ord;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",
			"tassocambio_ord;Tasso di Cambio dell'ordine(Euro/Valuta Estera, 1 se la Fattura è in EURO);Numero;22",
			"flagintracom;Intracom (S)/ExtraUE (X)/Italia(N);Codificato;1;S|X|N",
			"cigcode;CIG;Stringa;10",
			"riferimento;Riferimento;Stringa;150",
			"noterich;Note richiedente;Stringa;400",
			"resp;Responsabile;Stringa;150",
			"codtipoclass01;Codice Tipo class. 01;Stringa;20",
			"codclass01;Codice class. 01;Stringa;50",
			"codtipoclass02;Codice Tipo class. 02;Stringa;20",
			"codclass02;Codice class. 02;Stringa;50",
			"codtipoclass03;Codice tipo class. 03;Stringa;20",
			"codclass03;Codice class. 03;Stringa;50",
			"codtipoclass04;Codice Tipo class. 04;Stringa;20",
			"codclass04;Codice class. 04;Stringa;50",
			"codtipoclass05;Codice Tipo class. 05;Stringa;20",
			"codclass05;Codice class. 05;Stringa;50",
			"flagdanger;Materiale pericoloso;Codificato;1;S|N",
			"codclassanal1;Codice Classificazione Analitica 1;Stringa;50",
			"codclassanal2;Codice Classificazione Analitica 2;Stringa;50",
			"codclassanal3;Codice Classificazione Analitica 3;Stringa;50",
			"attivo;Attivo;Codificato;1;S|N",
			"causaledebito;Codice causale debito;Stringa;50",

			//Informazioni sui dettagli
			"nriga_cpassivo;Numero riga contratto;Intero;6",
			"descrdett;Descrizione dettaglio;Stringa;150",
			"promiscuo;Uso promiscuo;Codificato;1;S|N",

			"impon;Imponibile UNITARIO;Numero;22",
			"codtipoiva;Codice Tipo IVA;Stringa;20",
			"aliquota;Aliquota iva;Numero;22",
			"iva;Importo IVA del dettaglio;Numero;22",
			"ivaindetr; Importo IVA indetraibile del dettaglio;Numero;22",
			"quantita;Quantita;Numero;22",
			"scontoperc;Percentuale Sconto;Numero;22",



			"tipobene;Tipo bene: Inventariabile(A),Aumento di valore(P),Servizi(S),Magazzino(M),Altro(O) ;Codificato;1;A|P|S|M|O",
			"toinvoice;Proponi per inserimento in fatture;Codificato;1;S|N",
			"tipoattivita;Tipo Attività: Istituzionale(1),Commerciale(2),Promiscua(3),Qualsiasi/Non specificata(4);Codificato;1;1|2|3|4",
			"codiceupb;Codice UPB;Stringa;50",
			"nfasespesa;Numero fase spesa contabilizzazione;Intero;1",
			"esercmovspesacontimpon;Esercizio movimento spesa Cont. Imponibile;Intero;4 ",
			"nummovspesacontimpon;Numero movimento spesa Cont. Imponibile;Intero;8 ",
			"esercmovspesacontiva;Esercizio movimento spesa Cont. IVA;Intero;4 ",
			"nummovspesacontiva;Numero movimento spesa Cont. IVA;Intero;8 ",
			"va3type;Quadro VA3:  Beni ammortizzabili(S),Beni strumentali non ammortizzabili(N),Beni destinati alla rivendita(R), altri acquisti o importazioni(A);Codificato;1;S|N|R|A",
			"codiceinv;Codice inventario;Stringa;20",
			"compstart;Inizio competenza economica;Data;8",
			"compstop;Fine competenza economica;Data;8",
			"annotations;Appunti su dett.ordine;Stringa;400",
			"ivanotes;Note sull'iva;Stringa;400",
			"cupcodedett;Codice CUP dettaglio;Stringa;15",
			"cigcodedett;Codice CIG dettaglio;Stringa;10",
			"scaricoimm;Scarico immediato;Codificato;1;S|N",
			"causalecosto;Codice causale costo;Stringa;50",
			"rifesterno;Riferimento esterno (es.da migrazioni);Stringa;50",
			"intcode;Codice listino;Stringa;50",
			"codsiope;Codice Class. Siope;Stringa;50",
			"datacontab_dett;Data contabile dettaglio;Data;8",
			"annotazioni_regunico;Annotazioni (registro unico);Stringa;400",
			"dataricezione_regunico;Data ricezione documento(registro unico);Data;8",
			"numprotentrata_regunico; Numero protocollo di entrata (registro unico);Stringa;20",
			"annotazioniaccantonamento_bilancio; Imputazione Accantonamento;Stringa;60",
			"annotazioniaccantonamento_eserc_num;Accantonamento Anno/ Numero;Stringa;60",
			"annotazioniaccantonamento_data;Data Accantonamento;Data;8",
			"esito_gara;Esito della gara: Aggiudicata(A),Andata deserta(D),Senza esito per offerte non congrue(N);Codificato;1;A|D|N",
			"codice_rup; R.U.P. per ANAC(cod.anagrafica);Intero;8",
			"motivazioneaffidamentogara;Motivazione affidamento;Stringa;400",
			"datapubblicazionegara;Data pubblicazione;Data;8",
			"tipodatapubblicazione_gara;Tipo data pubblicazione: Perfezionamento contratto(C),Acquisto sul MEPA(M),Perfezionamento adesione ad accordo quadro(Q),Convenzione(V);Codificato;1;C|M|Q|N",
			"tipogara;Tipo gara:Bando(B),Avviso(AV),Affidamento(AF),Determina(DE);Codificato;2;B|AV|AF|DE",
			"tipo_competenzaeconomica;tipo_competenzaeconomica: Fattura da ricevere(F),Non generare ratei o scritture automatiche a fine anno(N),Genera rateo(S);Codificato;1;F|N|S",
			"naturadispesa_pcc;Natura di spesa PCC (COrrente o CApitale):Spesa Corrente(CO), Conto Capitale(CA);Codificato;2;CO|CA",
			"coderipartizionecosti;codice ripartizione dei costi (tabella costpartition);Stringa;50",
			"codeubic;ubicazione prefissata del bene;Stringa;50",
			"code_causaledebitopcc;codice causale debito pcc (tabella pccdebitmotive);Stringa;20",
			"code_statodebitopcc;codice stato debito(tabella pccdebitstatus);Stringa;9",



		};

		string[] tracciato_fatture =
			new string[] {
				"idreg;Codice anagrafica;Intero;8",
				"p_iva;P.Iva;Stringa;15",
				"cf;C.F.;Stringa;16",
				// Info generali fattura
				"codtipofattura; Codice Tipo Fattura;Stringa;20",
				"annofattura;Anno;Intero;4",
				"numfattura;Numero Fattura;Intero;8",
				"acquistovendita;Acquisto o Vendita (A/V);Codificato;1;A|V",
				"notacredito;Nota di Credito (S/N);Codificato;1;S|N",
				"codtipofatturaprinc; Codice Tipo Fattura Principale (Note Credito);Stringa;20",
				"annofatturaprinc;Anno  Fattura Principale (Note Credito);Intero;4",
				"numfatturaprinc;Numero Fattura Principale (Note Credito);Intero;8",
				"descrfattura;Descrizione Fattura;Stringa;150",
				"codexpirationkind; Tipo Scadenza" +
				"1-DataContabile" +
				"2-Data Documento" +
				"3-Fine mese Data Documento" +
				"4-Fine Mese Data Contabile" +
				"5-Pagamento Immediato;" +
				"Codificato;1;1|2|3|4|5",
				"paymentexpiring;Giorni scadenza pagamento;Intero;4",
				"datadoctrasporto;Data Documento di Trasporto;Data;8",
				"numdoctrasporto;Numero Documento di Trasporto;Stringa;25",
				"codicecass;Codice Cassiere per Incasso (solo fatture di Vendita);Stringa;20",
				"valuta_fatt;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",
				"tassocambio_fatt;Tasso di Cambio della fattura (Euro/Valuta Estera, 1 se la Fattura è in EURO);Numero;22",
				"doc;Documento Collegato;Stringa;35",
				"datadoc;Data documento collegato;Data;8",
				"datafatt;Data contabile;Data;8",
				"ivadifferita;Fattura a Iva Differita (S/N);Codificato;1;S|N",
				"attivo;Attivo (S/N);Codificato;1;S|N",
				"flagintracom;Intracom (S)/ExtraUE (X)/Italia(N);Codificato;1;S|X|N",
				"codtipoclass01;Codice Tipo class. 01;Stringa;20",
				"codclass01;Codice class. 01;Stringa;50",
				"codtipoclass02;Codice Tipo class. 02;Stringa;20",
				"codclass02;Codice class. 02;Stringa;50",
				"codtipoclass03;Codice tipo class. 03;Stringa;20",
				"codclass03;Codice class. 03;Stringa;50",
				"codtipoclass04;Codice Tipo class. 04;Stringa;20",
				"codclass04;Codice class. 04;Stringa;50",
				"codtipoclass05;Codice Tipo class. 05;Stringa;20",
				"codclass05;Codice class. 05;Stringa;50",
				"note_fatt;Note su fattura;Stringa;1000",
				"causaledebito;Codice causale debito o credito;Stringa;50",

				// Info dettaglio fattura
				"nriga_fatt;Numero riga;Intero;6",
				"descrdettaglio;Descrizione Dettaglio Fattura;Stringa;150",
				"annotazioni;Note su dettaglio fattura;Stringa;400",
				"codtipoiva;Codice Tipo IVA;Stringa;20",
				"iva;Importo IVA del dettaglio;Numero;22",
				"ivaindetr; Importo IVA indetraibile del dettaglio;Numero;22",
				"quantita;Quantita;Numero;22",
				"impon;Imponibile UNITARIO;Numero;22",
				"scontoperc;Percentuale Sconto;Numero;22",
				"codclassanal1;Codice Classificazione Analitica 1;Stringa;50",
				"codclassanal2;Codice Classificazione Analitica 2;Stringa;50",
				"codclassanal3;Codice Classificazione Analitica 3;Stringa;50",
				"nfasespesa;Numero fase spesa;Intero;1",
				"esercmovspesacontimpon;Esercizio movimento spesa Cont. Imponibile;Intero;4 ",
				"nummovspesacontimpon;Numero movimento spesa Cont. Imponibile;Intero;8 ",
				"esercmovspesacontiva;Esercizio movimento spesa Cont. IVA;Intero;4 ",
				"nummovspesacontiva;Numero movimento spesa Cont. IVA;Intero;8 ",
				"nfaseentrata;Numero fase entrata;Intero;1",
				"esercmoventratacontimpon;Esercizio movimento entrata Cont. Imponibile;Intero;4 ",
				"nummoventratacontimpon;Numero movimento entrata Cont. Imponibile;Intero;8 ",
				"esercmoventratacontiva;Esercizio movimento entrata Cont. IVA;Intero;4 ",
				"nummoventratacontiva;Numero movimento entrata Cont. IVA;Intero;8 ",
				//aggiunti ora
				"codiceupb;Codice UPB;Stringa;50",

				"codice_cpassivo;Codice tipo contratto passivo;Stringa;20",
				"anno_cpassivo;Anno contratto passivo;Intero;4",
				"numero_cpassivo;Numero contratto passivo;Intero;8",
				"nriga_cpassivo;Numero riga contratto passivo;Intero;6",

				"codice_cattivo;Codice tipo contratto attivo;Stringa;20",
				"anno_cattivo;Anno contratto attivo;Intero;4",
				"numero_cattivo;Numero contratto attivo;Intero;8",
				"nriga_cattivo;Numero riga contratto attivo;Intero;6",

				"idgroup;N.riga raggruppata;Intero;6",
				"prog_registro_unico;Codice Progressivo del Registro Unico;Numero;22",
				"numero_protocollo_entrata;Numero protocollo di entrata;Stringa;20",
				"dataricezione;Data ricezione;Data;8",
				"cigcode;CIG;Stringa;10",
				"cupcode;CUP;Stringa;15",
				"natura_spesa;Natura di spesa " +
				" CO-Spesa Corrente," +
				" CA-Conto Capitale," +
				" NA-Non applicabile;" +
				"Codificato;2;CO|CA|NA",
				"stato_debito;Stato del debito;" +
				"Codificato;9;ADEGLIQ|LIQ|LIQdaNL|LIQdaSOSP|NLdaLIQ|NLdaSOSP|NOLIQ|SOSP|SOSPdaLIQ|SOSPdaNL",
				"causale;Codice causale costo o ricavo;Stringa;50",

				//su fattura principale:
				"split_payment;Soggetto a split payment;Codificato;1;S|N",
				// dettaglio fattura elettronica
				"riferimentonormativo;Riferimento Normativo (Fattura Elettronica);Stringa;100",
				"codicetipo;Codice Tipo (Fattura Elettronica);Stringa;30",
				"codicevalore;Codice Valore (Fattura Elettronica);Stringa;30"

			};


		string[] tracciato_tiporegistroiva = new string[] {
			"codtiporegistroiva; Codice Tipo Registro IVA;Stringa;20",
			"descrtiporegistroiva;Descrizione Tipo Registro IVA;Stringa;50",
			"tipoprotocollo;Acquisto/Vendita/Protocollo Generale(A/V/P);Codificato;1;A|V|P",
			"attivita;Tipo Attività Istituzionale / Commerciale / Promiscua / Qualsiasi (S/N);Codificato;1;1|2|3|4",
			"registrocorrispettivi;Compensazione(S/N);Codificato;1;S|N",
			"codicecass;Codice Cassiere collegato;Stringa;20"
		};

		string[] tracciato_registroiva = new string[] {
			"annoregistrazione;Anno Registrazione;Intero;4",
			"numregistrazione;Numero Registrazione;Intero;8",
			"codtipofattura; Codice Tipo Fattura;Stringa;20",
			"codtiporegistroiva; Codice Tipo Registro IVA;Stringa;20",
			"annofattura;Anno;Intero;4",
			"numfattura;Numero Fattura;Intero;8",
			"numprotocollo;Numero Protocollo;Intero;8"
		};

		string[] tracciato_tipodociva = new string[] {
			"codtipofattura; Codice Tipo Fattura;Stringa;20",
			"descrtipofattura;Descrizione Tipo Fattura;Stringa;50",
			"acquisto_vendita;Acquisto/Vendita(A/V);Codificato;1;A|V",
			"numerazioneautomatica;Numerazione automatica(S/N);Codificato;1;S|N",
			"attivo;Attivo(S/N);Codificato;1;S|N",
			"notadicredito;Nota di Credito(S/N);Codificato;1;S|N",
			"fatturazione_elettronica;Fatturazione elettronica(S/N);Codificato;1;S|N",
			"codtipoautofattura;Codice Tipo AutoFattura;Stringa;20",
			"codstampa; Codice Stampa;Stringa;20",
			"intestazionereport;Intestazione Report;Stringa;150",
			"indirizzo;Indirizzo;Stringa;150",
			"codice_ipa;Indirizzo;Stringa;6",
			"riferimento_amministrazione;Indirizzo;Stringa;20",
			"codtipoclass01;Codice Tipo class. 01;Stringa;20",
			"codclass01;Codice class. 01;Stringa;50",
			"codtipoclass02;Codice Tipo class. 02;Stringa;20",
			"codclass02;Codice class. 02;Stringa;50",
			"codtipoclass03;Codice tipo class. 03;Stringa;20",
			"codclass03;Codice class. 03;Stringa;50",
			"codtipoclass04;Codice Tipo class. 04;Stringa;20",
			"codclass04;Codice class. 04;Stringa;50",
			"codtipoclass05;Codice Tipo class. 05;Stringa;20",
			"codclass05;Codice class. 05;Stringa;50"
		};

		string[] tracciato_tipodocivaannuale = new string[] {
			"anno;Anno;intero;4",
			"codtipofattura; Codice Tipo Fattura;Stringa;20",
			"codiceconto_sconto;Codice Conto per Sconto;Stringa;50",
			"codiceconto_ivaimmediata;Codice Conto per Iva Immediata;Stringa;50",
			"codiceconto_ivadifferita;Codice Conto per Iva Differita;Stringa;50",
			"codiceconto_ivaindetraibile;Codice Conto per Iva Indetraibile;Stringa;50",
			"codiceconto_intra_ivaimmediata;Codice Conto  per Iva Immediata (Intra-UE ed Extra-UE);Stringa;50",
			"codiceconto_intra_ivadifferita;Codice Conto per Iva Differita (Intra-UE ed Extra-UE);Stringa;50",
			"codiceconto_intra_ivaindetraibile;Codice Conto per Iva Indetraibile (Intra - UE ed Extra-UE);Stringa;50",
			"codiceconto_split_ivaimmediata;Codice Conto per Iva Immediata (Split);Stringa;50",
			"codiceconto_split_ivadifferita;Codice Conto per Iva Differita (Split);Stringa;50",
			"codiceconto_split_ivaindetraibile;Codice Conto per IVA Indetraibile (Split);Stringa;50"
		};


		string[] tracciato_tipodocivaregistroiva = new string[] {
			"codtipofattura; Codice Tipo Fattura;Stringa;20",
			"codtiporegistroiva; Codice Tipo Registro IVA;Stringa;20"
		};

		string[] tracciato_scrittureep = new string[] {
			"anno;Anno Scrittura;Intero;4",
			"numero;Numero Scrittura;Intero;8",
			"ndett;Numero Dettaglio Scrittura;Intero;8",
			"doc;Documento Collegato;Stringa;35",
			"datadoc;Data documento collegato;Data;8",
			"datacontabile;Data contabile;Data;8",
			"descrizione;Descrizione;Stringa;150",
			"tipo;Tipo Scrittura/1 Normale/2 Rateo/3 Risconto Rettifica/4 Accantonamento/5 Risconto Integrazione/6 Epilogo/7 Apertura/8 Rettifica progetti pluriennali/9 Riparto Risultato Economico/10 Rilevazione Risultato Economico/11 Epilogo conto economico/12 Epilogo stato patrimoniale/13 Assestamento Percentuale di Completamento/14 Chiusura ratei percentuale completamento/15 Integrazione risconti Commessa completata;Codificato;1;1|2|3|4|5|6|7|8|9|10|11|12|13|14|15",
			"bloccata;Bloccata(S/N);Codificato;1;S|N",
			"codtipoclass01;Codice Tipo class. 01;Stringa;20",
			"codclass01;Codice class. 01;Stringa;50",
			"codtipoclass02;Codice Tipo class. 02;Stringa;20",
			"codclass02;Codice class. 02;Stringa;50",
			"codtipoclass03;Codice tipo class. 03;Stringa;20",
			"codclass03;Codice class. 03;Stringa;50",
			"codtipoclass04;Codice Tipo class. 04;Stringa;20",
			"codclass04;Codice class. 04;Stringa;50",
			"codtipoclass05;Codice Tipo class. 05;Stringa;20",
			"codclass05;Codice class. 05;Stringa;50",
			"idrelated;ID Documento Collegato;Stringa;50",
			"dareavere;D per Dare A per Avere;Codificato;1;D|A",
			"importo;Importo;Numero;22",
			"compstart;Inizio competenza;Data;8",
			"compstop;Fine competenza;Data;8",
			"idreg;Codice anagrafica;Intero;10",
			"codclassanal1;Codice Classificazione Analitica 1;Stringa;50",
			"codclassanal2;Codice Classificazione Analitica 2;Stringa;50",
			"codclassanal3;Codice Classificazione Analitica 3;Stringa;50",
			"codiceupb;Codice UPB;Stringa;50",
			"codiceconto;Codice Conto;Stringa;50",
			"descrdettaglio;Descrizione Dettaglio;Stringa;400",
			"codimportazione;Codice Importazione;Stringa;200",
			"causale;Codice causale;Stringa;50",
			"ufficiale;Ufficiale(S/N);Codificato;1;S|N",
			"idrelated_det;ID Documento Collegato al dettaglio scrittura;Stringa;50",
			"aaimpegno;Anno impegno di budget;Intero;4",
			"nimpegno;Numero impegno di budget;Intero;8",
			"aaaccertamento;Anno accertamento di budget;Intero;4",
			"naccertamento;Numero accertamento di budget;Intero;8"
		};




		string[] tracciato_classmercannuale = new string[] {
			"anno; Anno;Intero;4",
			"codclassmerc; Codice Classificazione Merceologica;Stringa;50",
			"codnomenclaturacombinata; Codice Nomenclatura combinata;Stringa;1000",
			"codservinstrastat; Codice Servizi Intrastat;Stringa;100"
		};

		string[] tracciato_listino = new string[] {
			"codlistino; Codice Listino;Stringa;50",
			"descrlistino; Descrizione Listino;Stringa;150",
			"attivo; Attivo(S/N); Codificato;1;S|N",
			"dascaricare; Da Scaricare(S/N); Codificato;1;S|N",
			"scadenza; Articolo con data scadenza(S/N); Codificato;1;S|N",
			"datascadenza; Data Scadenza;Data;8",
			"codclassmerc; Codice Classificazione Merceologica;Stringa;50",
			"unitamisuracaricoscarico; Unità di Misura per Carico/Scarico;Stringa;50",
			"unitamisuraacquisto; Unità di Misura per Acquisto;Stringa;50",
			"coefficienteconversione; Coefficiente di Conversione;Intero;8",
			"scortamin;Scorta minima;Intero;6",
			"quantitariordino;Quantità per il riordino;Intero;6",
			"tempoapprovigionamento;Tempo di approvigionamento;Intero;6",
			"quantitamaxprenotabile;Quantità massima prenotabile;Intero;6"
		};

		private string BuildHashKey(object CF, object PIva, object CFExt, out bool valid) {
			valid = true;
			string HashKey = "";
			if (CF != DBNull.Value && CF != null)
				HashKey += CF.ToString().Trim();
			HashKey += "|";
			if (PIva != DBNull.Value && PIva != null)
				HashKey += PIva.ToString().Trim();
			HashKey += "|";
			if (CFExt != DBNull.Value && CFExt != null)
				HashKey += CFExt.ToString().Trim();

			if (HashKey == "||") {
				HashKey = "";
				valid = false;
			}

			return HashKey;
		}

		Hashtable hashMandateKind = null;

		/*Hashtable MandateKind = new Hashtable();
		foreach (DataRow MandateKindRow in MandateKindTbl.Select()) {
		    MandateKind[MandateKindRow["idmankind"]] = MandateKindRow["idmankind"];
		}*/


		object CheckMandateKind(DataTable MandateKind, string idmankind) {
			if (hashMandateKind == null) {
				hashMandateKind = new Hashtable();
				foreach (DataRow RH in MandateKind.Rows) {
					hashMandateKind[RH["idmankind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashMandateKind[idmankind.ToUpper()] as DataRow;
			;
			if (RID != null) {
				return RID["idmankind"];
			}

			MetaData MetaMandateKind = Meta.Dispatcher.Get("mandatekind");
			MetaMandateKind.SetDefaults(MandateKind);
			DataRow NewMandateKind = MetaMandateKind.Get_New_Row(null, MandateKind);
			NewMandateKind["idmankind"] = idmankind;
			NewMandateKind["description"] = idmankind;
			NewMandateKind["active"] = 'S';
			NewMandateKind["isrequest"] = 'N';
			NewMandateKind["ct"] = DateTime.Now;
			NewMandateKind["lt"] = DateTime.Now;
			NewMandateKind["cu"] = "importazione";
			NewMandateKind["lu"] = "importazione";
			hashMandateKind[idmankind.ToString().ToUpper()] = NewMandateKind;
			return NewMandateKind["idmankind"];
		}

		Hashtable hashEstimateKind = null;

		/*Hashtable MandateKind = new Hashtable();
		foreach (DataRow MandateKindRow in MandateKindTbl.Select()) {
		    MandateKind[MandateKindRow["idmankind"]] = MandateKindRow["idmankind"];
		}*/


		object CheckEstimateKind(DataTable EstimateKind, string idestimkind) {
			if (hashEstimateKind == null) {
				hashEstimateKind = new Hashtable();
				foreach (DataRow RH in EstimateKind.Rows) {
					hashEstimateKind[RH["idestimkind"].ToString().ToUpper()] = RH;
				}
			}

			DataRow RID = hashEstimateKind[idestimkind.ToUpper()] as DataRow;
			;
			if (RID != null) {
				return RID["idestimkind"];
			}

			MetaData MetaEstimateKind = Meta.Dispatcher.Get("estimatekind");
			MetaEstimateKind.SetDefaults(EstimateKind);
			DataRow NewEstimateKind = MetaEstimateKind.Get_New_Row(null, EstimateKind);
			NewEstimateKind["idestimkind"] = idestimkind;
			NewEstimateKind["description"] = idestimkind;
			NewEstimateKind["active"] = 'S';
			NewEstimateKind["ct"] = DateTime.Now;
			NewEstimateKind["lt"] = DateTime.Now;
			NewEstimateKind["cu"] = "importazione";
			NewEstimateKind["lu"] = "importazione";
			hashEstimateKind[idestimkind.ToString().ToUpper()] = NewEstimateKind;
			return NewEstimateKind["idestimkind"];
		}

		Hashtable hashIvaKind = null;

		object CheckIvaKind(DataTable IvaKind, string codeivakind, object aliquota) {
			if (hashIvaKind == null) {
				hashIvaKind = new Hashtable();
				foreach (DataRow RH in IvaKind.Rows) {
					hashIvaKind[RH["codeivakind"].ToString().ToUpper().Trim()] = RH;
				}
			}

			DataRow RID = hashIvaKind[codeivakind.ToUpper().Trim()] as DataRow;
			;
			if (RID != null) {
				return RID["idivakind"];
			}

			MetaData MetaIvaKind = Meta.Dispatcher.Get("ivakind");
			MetaIvaKind.SetDefaults(IvaKind);
			DataRow NewIvaKind = MetaIvaKind.Get_New_Row(null, IvaKind);
			NewIvaKind["codeivakind"] = codeivakind;
			NewIvaKind["description"] = codeivakind + " - IVA al " + aliquota.ToString() + " %";
			NewIvaKind["active"] = 'S';
			NewIvaKind["ct"] = DateTime.Now;
			NewIvaKind["lt"] = DateTime.Now;
			NewIvaKind["cu"] = "importazione";
			NewIvaKind["lu"] = "importazione";
			hashIvaKind[codeivakind.ToString().ToUpper().Trim()] = NewIvaKind;
			return NewIvaKind["idivakind"];
		}

		bool ImportaCPassivi() {
			LeggiFile Reader = GetReader(tracciato_cpassivi);
			if (Reader == null) return false;
			DataSet D = new vistaCpassivi();
			ClearAllNonDBOHash();
			MetaData MetaMandate = Meta.Dispatcher.Get("mandate");
			MetaMandate.SetDefaults(D.Tables["mandate"]);

			MetaData MetaMandateDetail = Meta.Dispatcher.Get("mandatedetail");
			MetaMandateDetail.SetDefaults(D.Tables["mandatedetail"]);

			DataTable MandateKind = D.Tables["mandatekind"];
			MetaData MetaMandateKind = Meta.Dispatcher.Get("mandatekind");

			DataTable IvaKind = D.Tables["ivakind"];
			MetaData MetaIvaKind = Meta.Dispatcher.Get("ivakind");

			Conn.RUN_SELECT_INTO_TABLE(MandateKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(IvaKind, null, null, null, false);

			// Lookup di INVOICEKIND (codtipofattura)
			//DataTable InvKindTbl = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
			//Hashtable InvKind = new Hashtable();
			//foreach (DataRow InvKindRow in InvKindTbl.Select()) InvKind[InvKindRow["codeinvkind"]] = InvKindRow["idinvkind"];


			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}

			DataTable InvTree = Conn.RUN_SELECT("inventorytree", "*", null, null, null, false);
			DataTable AccMotive = Conn.RUN_SELECT("accmotive", "*", null, null, null, false);

			DataTable Division = D.Tables["division"];
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaDivision.SetDefaults(Division);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("codedivision", "Fittizia"), null, false);

			GetSortCached.Init();
			int[] idsortingkind = new int[] {
				0, CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind2")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind3"))
			};

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}

			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);

			DataTable Location = D.Tables["location"];
			MetaData MetaLocation = Meta.Dispatcher.Get("location");
			MetaLocation.SetDefaults(Location);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);

			DataTable Costpartition = D.Tables["costpartition"];
			MetaData MetaCostpartition = Meta.Dispatcher.Get("costpartition");
			MetaCostpartition.SetDefaults(Costpartition);
			Conn.RUN_SELECT_INTO_TABLE(Costpartition, null, null, null, false);

			string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));

			// Lookup di Currency
			DataTable Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
			Hashtable Hcur = new Hashtable();
			foreach (DataRow RCC in Currency.Select())
				Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

			// Lookup di Listino

			Conn.RUN_SELECT_INTO_TABLE(D.Tables["list"], null, null, null, false);
			Dictionary<string, int> vociListino = new Dictionary<string, int>();
			foreach (DataRow r in D.Tables["list"].Select()) {
				vociListino[r["intcode"].ToString().ToLower()] = CfgFn.GetNoNullInt32(r["idlist"]);
			}

			// Lookup di IvaKind
			//DataTable IvaKind = Conn.RUN_SELECT("ivakind", "*", null, null, null, false);
			//Hashtable HIva = new Hashtable();
			//foreach (DataRow IvaKRow in IvaKind.Select()) HIva[IvaKRow["codeivakind"]] = IvaKRow["idivakind"];

			//// Lookup di Classificazione Analitica 1, Sara
			//int idsortingkind1 = CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1"));
			//string filterSort1 = QHS.CmpEq("idsorkind", idsortingkind1);
			//DataTable Sort1 = Conn.RUN_SELECT("sorting", "*", null, filterSort1, null, false);
			//Hashtable HSort1 = new Hashtable();
			//foreach (DataRow Sort1Row in Sort1.Select()) HSort1[Sort1Row["sortcode"]] = Sort1Row["idsor"];

			DataTable ExpirationKind = Conn.RUN_SELECT("expirationkind", "*", null, null, null, false);
			Hashtable HExpK = new Hashtable();
			foreach (DataRow ExpKRow in ExpirationKind.Select())
				HExpK[ExpKRow["shorttitle"]] = ExpKRow["idexpirationkind"];

			List<string> tosync = new List<string>();
			tosync.Add("registry");
			tosync.Add("mandatekind");
			tosync.Add("ivakind");
			tosync.Add("accmotive");
			tosync.Add("location");
			tosync.Add("costpartition");
			InitSpeedSaver(Conn, tosync);

			object idsorkind =
				Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind", null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["sorting"], null, filterSiope, null, false);


			Reader.Reset();
			string lastfilter = "";
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				object codtipoordine = "";
				object annoordine;
				object numordine;
				//if (MandateKind[Reader.getCurrField("codice_cpassivo")] != null) {

				string codice_cpassivo = Reader.getCurrField("codice_cpassivo").ToString();
				codtipoordine = CheckMandateKind(MandateKind, codice_cpassivo);
				/*}
				else {
				    SpeedSaver.AddError("Codice Tipo Ordine " + Reader.getCurrField("codice_cpassivo") + " non trovato alla linea "
				                + Reader.GetCurrRowNumber());
				    Reader.GetNext();
				    continue;
				}*/

				annoordine = Reader.getCurrField("anno_cpassivo");
				if (annoordine == DBNull.Value) {
					SpeedSaver.AddError("Attenzione. Esercizio Contrato non specificato alla Riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				numordine = Reader.getCurrField("numero_cpassivo");


				DataRow[] MandateFound = null;
				string mandatedbfilter = "";

				// Controlliamo PRIMA se esiste già un ordine con la terna nman+yman+codtipoordine
				mandatedbfilter = QHS.AppAnd(QHS.CmpEq("nman", numordine), QHS.CmpEq("yman", annoordine),
					QHS.CmpEq("idmankind", codtipoordine));
				DataTable DTMandate = Conn.RUN_SELECT("mandate", "*", null, mandatedbfilter, null, true);
				if (DTMandate.Rows.Count > 0) {
					// Errore! Nel DB è già presente una fattura con la terna indicata!
					SpeedSaver.AddError("Attenzione. E' già presente un ordine avente Anno:"
					                    + annoordine.ToString() + " numero:" + numordine.ToString() + " e codice:" +
					                    Reader.getCurrField("codice_cpassivo").ToString() + " - Riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				// Costruisci il filtro utilizzando l'ninv proveniente dal file
				mandatedbfilter = QHC.AppAnd(QHC.CmpEq("idmankind", codtipoordine), QHC.CmpEq("yman", annoordine),
					QHC.CmpEq("nman", numordine));

				if (N > 100 && lastfilter != mandatedbfilter) {
					if (!SaveData(D, false)) break;
					N = 0;
					D.Tables["mandate"].Clear();
					D.Tables["mandatedetail"].Clear();
					D.Tables["expensemandate"].Clear();
				}

				lastfilter = mandatedbfilter;



				MandateFound = D.Tables["mandate"].Select(mandatedbfilter);


				DataRow man;
				DataRow mandetail;
				string anagrafica_dettaglio = Reader.getCurrField("anagrafica_dettaglio").ToString().ToUpper();

				bool err;
				if (MandateFound == null || MandateFound.Length == 0) {
					// nuova fattura
					man = MetaMandate.Get_New_Row(null, D.Tables["mandate"]);

					// Forse va disabilitato l'autoincremento, altrimenti viene inserita più volte una testata...
					RowChange.ClearAutoIncrement(D.Tables["mandate"].Columns["nman"]);
					if (anagrafica_dettaglio == "N") {
						man["idreg"] = Reader.getCurrField("idreg");
					}

					man["idmankind"] = codtipoordine;
					man["yman"] = annoordine;
					man["nman"] = numordine;
					man["description"] = Reader.getCurrField("descrizione");
					man["adate"] = ToSmalldateTime(Reader.getCurrField("datacont"));

					man["idexpirationkind"] = Reader.getCurrField("codexpirationkind");
					// E' sbagliata nel tracciato? Int16, NON DATA
					man["paymentexpiring"] = Reader.getCurrField("scadenzapag");

					man["idaccmotivedebit"] = CheckAccMotive(AccMotive, Reader.getCurrField("causaledebito"));

					man["deliveryaddress"] = Reader.getCurrField("indcons");
					man["deliveryexpiration"] = Reader.getCurrField("datacons");


					if (Reader.getCurrField("valuta_ord") == DBNull.Value || Reader.getCurrField("valuta_ord") == null)
						man["idcurrency"] = DBNull.Value;
					else {
						if (Hcur[Reader.getCurrField("valuta_ord")] == null) {
							SpeedSaver.AddError("Codice valuta: " + Reader.getCurrField("valuta_ord").ToString() +
							                    " non trovato alla riga " + Reader.GetCurrRowNumber() +
							                    " del file di input.");
							Reader.GetNext();
							continue;
						}
						else
							man["idcurrency"] = Hcur[Reader.getCurrField("valuta_ord")];
					}

					man["registryreference"] = Reader.getCurrField("riferimento");


					man["exchangerate"] = Reader.getCurrField("tassocambio_ord");
					man["doc"] = Reader.getCurrField("doc");
					man["docdate"] = ToSmalldateTime(Reader.getCurrField("datadoc"));
					man["idmandatestatus"] = "5";

					man["active"] = Reader.getCurrField("attivo");
					man["flagintracom"] = Reader.getCurrField("flagintracom");

					man["cigcode"] = Reader.getCurrField("cigcode");
					man["applierannotations"] = Reader.getCurrField("noterich");
					man["flagdanger"] = Reader.getCurrField("flagdanger");
					man["txt"] = Reader.getCurrField("note_ordine");
					man["external_reference"] = Reader.getCurrField("rifesterno");

					man["resendingpcc"] = "N";

					object manager = Reader.getCurrField("resp");
					object idman = DBNull.Value;
					if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision, "S");
					man["idman"] = idman;

					//Verifica la presenza delle classificazioni
					for (int nsor = 1; nsor <= 5; nsor++) {
						man["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
							Reader.getCurrField("codtipoclass0" + nsor.ToString()).ToString(),
							Reader.getCurrField("codclass0" + nsor.ToString()).ToString(),
							out err);
						if (err) {
							SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
							                    " di codice " + Reader.getCurrField("codclass0" + nsor.ToString()) +
							                    " inesistente alla riga " + Reader.GetCurrRowNumber());

						}
					}

					man["annotations"] = Reader.getCurrField("annotazioni_regunico"); // Annotazioni (registro unico)
					man["arrivaldate"] =
						ToSmalldateTime(
							Reader.getCurrField(
								"dataricezione_regunico")); //   Data ricezione documento(registro unico)  
					man["arrivalprotocolnum"] =
						Reader.getCurrField(
							"numprotentrata_regunico"); //      Numero protocollo di entrata (registro unico)		
					man["subappropriation"] =
						Reader.getCurrField(
							"annotazioniaccantonamento_eserc_num"); //  Prenotazione Anno/ Numero        
					man["finsubappropriation"] =
						Reader.getCurrField("annotazioniaccantonamento_bilancio"); //    Imputazione Prenotazione    
					man["adatesubappropriation"] =
						ToSmalldateTime(Reader.getCurrField("annotazioniaccantonamento_data")); //Data Prenotazione   
					man["flagtenderresult"] = Reader.getCurrField("esito_gara"); //Esito della gara 
					man["idreg_rupanac"] =
						Reader.getCurrField(
							"codice_rup"); //R.U.P.Responsabile Unico del Procedimento per ANAC (idreg di registry)	
					man["motiveassignment"] =
						Reader.getCurrField("motivazioneaffidamentogara"); //      Motivazione affidamento 
					man["publishdate"] =
						ToSmalldateTime(Reader.getCurrField("datapubblicazionegara")); //Data pubblicazione      
					man["publishdatekind"] =
						Reader.getCurrField("tipodatapubblicazione_gara"); // Tipo data pubblicazione 
					man["tenderkind"] = Reader.getCurrField("tipogara"); //Tipo gara 
				}
				else {
					man = MandateFound[0];
				}

				mandetail = MetaMandateDetail.Get_New_Row(man, D.Tables["mandatedetail"]);
				RowChange.ClearAutoIncrement(D.Tables["mandatedetail"].Columns["rownum"]);

				mandetail["annotations"] = Reader.getCurrField("annotations");
				if (Reader.getCurrField("nriga_cpassivo") == DBNull.Value ||
				    Reader.getCurrField("nriga_cpassivo") == null) {
					SpeedSaver.AddError("Il 'Numero riga contratto' non è stato specificato alla riga " +
					                    Reader.GetCurrRowNumber() + " del file di input.");
				}

				mandetail["rownum"] = Reader.getCurrField("nriga_cpassivo");
				mandetail["assetkind"] = Reader.getCurrField("tipobene");
				mandetail["competencystart"] = Reader.getCurrField("compstart");
				mandetail["competencystop"] = Reader.getCurrField("compstop");
				mandetail["detaildescription"] = Reader.getCurrField("descrdett");
				mandetail["discount"] = Reader.getCurrField("scontoperc");
				mandetail["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causalecosto"));

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (!HUpb.ContainsKey(codeupb)) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:"
						                    + Reader.GetCurrRowNumber());
					}
					else {
						idupb = HUpb[codeupb];
					}
				}



				mandetail["idupb"] = idupb;

				mandetail["number"] = Reader.getCurrField("quantita");
				mandetail["npackage"] = Reader.getCurrField("quantita");

				mandetail["tax"] = Reader.getCurrField("iva");
				mandetail["taxable"] = Reader.getCurrField("impon");
				mandetail["taxrate"] = Reader.getCurrField("aliquota");
				mandetail["toinvoice"] = Reader.getCurrField("toinvoice");
				mandetail["flagmixed"] = Reader.getCurrField("promiscuo");
				mandetail["unabatable"] = Reader.getCurrField("ivaindetr");
				//Lui deve sempre valorizzare l'anagrafica nel dettaglio 
				//Se anagrafica_dettaglio = N, allora scrive quello principale, altrimenti quello indicato nel file.
				if (anagrafica_dettaglio == "N") {
					mandetail["idreg"] = man["idreg"];
				}
				else {
					mandetail["idreg"] = Reader.getCurrField("idreg");
				}

				object idinv = DBNull.Value;
				if (Reader.getCurrField("codiceinv") != DBNull.Value) {
					string filterinvtree = QHC.CmpEq("codeinv", Reader.getCurrField("codiceinv"));
					if (InvTree.Select(filterinvtree).Length > 0) {
						idinv = InvTree.Select(filterinvtree)[0]["idinv"];
					}
					else {
						idinv = 0;
						SpeedSaver.AddError("Classificazione inventariale di codice " +
						                    Reader.getCurrField("codiceinv") +
						                    " non trovata alla riga " + Reader.GetCurrRowNumber());
					}
				}

				mandetail["idinv"] = idinv;

				string codtipoiva = Reader.getCurrField("codtipoiva").ToString();
				object aliquota = Reader.getCurrField("aliquota");
				mandetail["idivakind"] = CheckIvaKind(IvaKind, codtipoiva, aliquota);
				mandetail["flagactivity"] = Reader.getCurrField("tipoattivita");
				mandetail["va3type"] = Reader.getCurrField("va3type");
				mandetail["ivanotes"] = Reader.getCurrField("ivanotes");
				mandetail["cupcode"] = Reader.getCurrField("cupcodedett");
				mandetail["cigcode"] = Reader.getCurrField("cigcodedett");
				mandetail["flagto_unload"] = Reader.getCurrField("scaricoimm");

				object intCode = Reader.getCurrField("intcode");
				object idlist = DBNull.Value;
				if (intCode != DBNull.Value) {
					if (vociListino.ContainsKey(intCode.ToString().ToLower())) {
						idlist = vociListino[intCode.ToString().ToLower()];
					}
					else {
						SpeedSaver.AddError("Voce di listino di codice " + intCode +
						                    " non trovata per il dettaglio contratto passivo " +
						                    " Riga:" + Reader.GetCurrRowNumber());
					}
				}

				mandetail["idlist"] = idlist;

				if (idlist != DBNull.Value) {
					var o = Conn.readObject("list", q.eq("idlist", idlist), "idunit,idpackage,unitsforpackage");
					foreach (string k in o.Keys) {
						mandetail[k] = o[k];
					}
				}


				mandetail["start"] = ToSmalldateTime(Reader.getCurrField("datacontab_dett"));


				string codicesiope = Reader.getCurrField("codsiope").ToString();

				if (codicesiope != "") {
					DataRow[] Rows = D.Tables["sorting"].Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						mandetail["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}


				//Dett.ordine
				//Verifica la presenza delle classificazioni
				for (int nsor = 1; nsor <= 3; nsor++) {
					mandetail["idsor" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
						idsortingkind[nsor],
						Reader.getCurrField("codclassanal" + nsor.ToString()).ToString(),
						out err);
					if (err) {
						SpeedSaver.AddError("Codice Classificazione Analitica n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclassanal" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}


				object nfasespesa = Reader.getCurrField("nfasespesa");
				object esercmovspesacontimpon = Reader.getCurrField("esercmovspesacontimpon");
				object nummovspesacontimpon = Reader.getCurrField("nummovspesacontimpon");
				object esercmovspesacontiva = Reader.getCurrField("esercmovspesacontiva");
				object nummovspesacontiva = Reader.getCurrField("nummovspesacontiva");

				if (nummovspesacontimpon != DBNull.Value) {
					string FiltroSpesaImpon = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesacontimpon),
						QHS.CmpEq("nmov", nummovspesacontimpon), QHS.CmpEq("nphase", nfasespesa),
						QHS.CmpEq("ayear", annoordine));
					object idSpesaImpon = Conn.DO_READ_VALUE("expenseview", FiltroSpesaImpon, "idexp");
					if (idSpesaImpon == null || idSpesaImpon == DBNull.Value) {
						string movSpesaImpon = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                     + " num. " +
						                                                     nummovspesacontimpon.ToString() + " del " +
						                                                     esercmovspesacontimpon.ToString() +
						                                                     " nell'anno " + annoordine;
						SpeedSaver.AddError("Movimento non trovato: " + movSpesaImpon + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						mandetail["idexp_taxable"] = idSpesaImpon;
					}
				}

				if (nummovspesacontiva != DBNull.Value) {
					string FiltroSpesaIVA = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesacontiva),
						QHS.CmpEq("nmov", nummovspesacontiva), QHS.CmpEq("nphase", nfasespesa),
						QHS.CmpEq("ayear", annoordine));
					object idSpesaIVA = Conn.DO_READ_VALUE("expenseview", FiltroSpesaIVA, "idexp");
					if (idSpesaIVA == null || idSpesaIVA == DBNull.Value) {
						string movSpesaIVA = "Movimento di spesa di fase " + nfasespesa.ToString() + " num. " +
						                     nummovspesacontiva.ToString() + " del " +
						                     esercmovspesacontiva.ToString() + " nell'anno " + annoordine;
						SpeedSaver.AddError("Movimento non trovato: " + movSpesaIVA + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						mandetail["idexp_iva"] = idSpesaIVA;
					}
				}

				mandetail["epkind"] = Reader.getCurrField("tipo_competenzaeconomica"); //Tipo EP 
				mandetail["expensekind"] =
					Reader.getCurrField("naturadispesa_pcc"); //Tipo spesa PCC (COrrente o CApitale)			
				mandetail["idpccdebitmotive"] =
					Reader.getCurrField("code_causaledebitopcc"); // id causale debito pcc (tabella pccdebitmotive)			
				mandetail["idpccdebitstatus"] =
					Reader.getCurrField("code_statodebitopcc"); // id stato debito(tabella pccdebitstatus)       

				//id ripartizione dei costi (tabella costpartition)		
				object costpartitioncode = Reader.getCurrField("coderipartizionecosti");
				object idcostpartition = DBNull.Value;
				if (costpartitioncode != DBNull.Value) {
					idcostpartition = CheckidCostpartition(Costpartition, costpartitioncode.ToString());
					if (idcostpartition == DBNull.Value) {
						SpeedSaver.AddError("Ripartizione Costi di codice " + costpartitioncode +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

				if (idcostpartition != DBNull.Value) {
					mandetail["idcostpartition"] = idcostpartition;
				}

				//codeubic: ubicazione prefissata del bene              
				object locationcode = Reader.getCurrField("codeubic");
				object idlocation = DBNull.Value;
				if (locationcode != DBNull.Value) {
					idlocation = CheckidLocation(Location, locationcode.ToString());
					if (idlocation == DBNull.Value) {
						SpeedSaver.AddError("Ubicazione di codice " + locationcode +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

				if (idlocation != DBNull.Value) {
					mandetail["idlocation"] = idlocation;
				}


				int movkind = 0;
				object idexptosearch = DBNull.Value;
				if (mandetail["idexp_taxable"] != DBNull.Value && mandetail["idexp_iva"] != DBNull.Value) {
					movkind = 1;
					idexptosearch = mandetail["idexp_taxable"];
				}

				if (mandetail["idexp_taxable"] != DBNull.Value && mandetail["idexp_iva"] == DBNull.Value) {
					movkind = 3;
					idexptosearch = mandetail["idexp_taxable"];
				}

				if (mandetail["idexp_taxable"] == DBNull.Value && mandetail["idexp_iva"] != DBNull.Value) {
					movkind = 2;
					idexptosearch = mandetail["idexp_iva"];
				}

				if (idexptosearch != DBNull.Value) {
					int nexpman = Conn.RUN_SELECT_COUNT("expensemandate", QHS.CmpEq("idexp", idexptosearch), false);
					if (nexpman == 0)
						nexpman = D.Tables["expensemandate"].Select(QHC.CmpEq("idexp", idexptosearch)).Length;
					if (nexpman == 0) {
						DataRow RExpMan = D.Tables["expensemandate"].NewRow();
						RExpMan["idexp"] = idexptosearch;
						RExpMan["movkind"] = movkind;
						foreach (string ff in new string[] {"idmankind", "yman", "nman"}) RExpMan[ff] = mandetail[ff];
						RExpMan["ct"] = DateTime.Now;
						RExpMan["lt"] = DateTime.Now;
						RExpMan["cu"] = "importazione";
						RExpMan["lu"] = "importazione";
						D.Tables["expensemandate"].Rows.Add(RExpMan);
					}
				}

				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		string[] tracciato_cattivi = new string[] {

			"idreg;Codice anagrafica;Intero;8",
			"anagrafica_dettaglio;Anagrafica in dettaglio contratto;Codificato;1;S|N",

			//Specifici per c.attivo
			"codice_cattivo;Codice tipo contratto;Stringa;20",
			"anno_contratto;Anno contratto;Intero;4",
			"numero_contratto;Numero contratto;Intero;8",
			"datacont;Data contabile;Data;8",
			"indcons;Indirizzo consegna;Stringa;150",
			"datacons;Termine consegna;Stringa;50",
			"descrizione;Descrizione contratto;Stringa;150",
			"doc;Documento collegato;Stringa;35",
			"datadoc;Data documento;Data;8",

			"note_contratto;Note sul contratto;Stringa;500",
			"codexpirationkind; Tipo Scadenza" +
			"1-DataContabile" +
			"2-Data Documento" +
			"3-Fine mese Data Documento" +
			"4-Fine Mese Data Contabile" +
			"5-Pagamento Immediato;" +
			"Codificato;1;1|2|3|4|5",
			"scadenza;scadenza;Intero;4",
			"valuta_cont;Codice valuta (ISO 4217, Euro=Eur, dollaro=USD..);Stringa;3",
			"tassocambio_cont;Tasso di Cambio del contratto(Euro/Valuta Estera, 1 se la Fattura è in EURO);Numero;22",
			"flagintracom;Intracom (S)/ExtraUE (X)/Italia(N);Codificato;1;S|X|N",
			"riferimento;Riferimento;Stringa;150",
			"resp;Responsabile;Stringa;150",
			"codtipoclass01;Codice Tipo class. 01;Stringa;20",
			"codclass01;Codice class. 01;Stringa;50",
			"codtipoclass02;Codice Tipo class. 02;Stringa;20",
			"codclass02;Codice class. 02;Stringa;50",
			"codtipoclass03;Codice tipo class. 03;Stringa;20",
			"codclass03;Codice class. 03;Stringa;50",
			"codtipoclass04;Codice Tipo class. 04;Stringa;20",
			"codclass04;Codice class. 04;Stringa;50",
			"codtipoclass05;Codice Tipo class. 05;Stringa;20",
			"codclass05;Codice class. 05;Stringa;50",


			"attivo;Attivo;Codificato;1;S|N",
			"causalecredito;Codice causale credito;Stringa;50",

			//Informazioni sui dettagli
			"nriga_cattivo;Numero riga contratto;Intero;6",
			"descrdett;Descrizione dettaglio;Stringa;150",

			"impon;Imponibile UNITARIO;Numero;22",
			"codtipoiva;Codice Tipo IVA;Stringa;20",
			"aliquota;Aliquota iva;Numero;22",
			"iva;Importo IVA del dettaglio;Numero;22",
			"quantita;Quantita;Numero;22",
			"scontoperc;Percentuale Sconto;Numero;22",

			"toinvoice;Proponi per inserimento in fatture;Codificato;1;S|N",
			"codiceupb;Codice UPB;Stringa;50",

			"nfaseentrata;Numero fase entrata contabilizzazione;Intero;1",
			"esercmoventratacontimpon;Esercizio movimento entrata Cont. Imponibile;Intero;4 ",
			"nummoventratacontimpon;Numero movimento entrata Cont. Imponibile;Intero;8 ",
			"esercmoventratacontiva;Esercizio movimento entrata Cont. IVA;Intero;4 ",
			"nummoventratacontiva;Numero movimento entrata Cont. IVA;Intero;8 ",

			"compstart;Inizio competenza economica;Data;8",
			"compstop;Fine competenza economica;Data;8",
			"annotations;Appunti su dett.ordine;Stringa;400",

			"causalericavo;Codice causale ricavo;Stringa;50",
			"intcode;Codice Listino;Stringa;50",
			"codsiope;Codice Class. Siope;Stringa;50",

			"rifesterno;Riferimento esterno (es.da migrazioni);Stringa;50",
			"codclassanal1;Codice Classificazione Analitica 1;Stringa;50",
			"codclassanal2;Codice Classificazione Analitica 2;Stringa;50",
			"codclassanal3;Codice Classificazione Analitica 3;Stringa;50",
			"causaleannullamento;Codice causale annullamento;Stringa;50"

		};


		bool ImportaContrattiAttivi() {
			LeggiFile Reader = GetReader(tracciato_cattivi);
			if (Reader == null)
				return false;
			DataSet D = new vistaCAttivi();
			ClearAllNonDBOHash();
			MetaData MetaEstimate = Meta.Dispatcher.Get("estimate");
			MetaEstimate.SetDefaults(D.Tables["estimate"]);

			MetaData MetaEstimateDetail = Meta.Dispatcher.Get("estimatedetail");
			MetaEstimateDetail.SetDefaults(D.Tables["estimatedetail"]);

			DataTable EstimateKind = D.Tables["estimatekind"];
			MetaData MetaEstimateKind = Meta.Dispatcher.Get("estimatekind");

			DataTable IvaKind = D.Tables["ivakind"];
			MetaData MetaIvaKind = Meta.Dispatcher.Get("ivakind");

			Conn.RUN_SELECT_INTO_TABLE(EstimateKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(IvaKind, null, null, null, false);


			DataTable List = Conn.RUN_SELECT("list", "idlist,intcode", null, null, null, false);
			Dictionary<string, int> vociListino = new Dictionary<string, int>();
			foreach (DataRow r in List.Select()) {
				vociListino[r["intcode"].ToString().ToLower()] = CfgFn.GetNoNullInt32(r["idlist"]);
			}


			object idsorkind =
				Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_E_18"), "idsorkind", null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["sorting"], null, filterSiope, null, false);

			// Lookup di INVOICEKIND (codtipofattura)
			//DataTable InvKindTbl = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
			//Hashtable InvKind = new Hashtable();
			//foreach (DataRow InvKindRow in InvKindTbl.Select()) InvKind[InvKindRow["codeinvkind"]] = InvKindRow["idinvkind"];


			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}


			DataTable AccMotive = Conn.RUN_SELECT("accmotive", "*", null, null, null, false);

			DataTable Division = D.Tables["division"];
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaDivision.SetDefaults(Division);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("codedivision", "Fittizia"), null, false);

			GetSortCached.Init();
			int[] idsortingkind = new int[] {
				0, CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind2")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind3"))
			};

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}

			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);

			string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));

			// Lookup di Currency
			DataTable Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
			Hashtable Hcur = new Hashtable();
			foreach (DataRow RCC in Currency.Select())
				Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

			// Lookup di IvaKind
			//DataTable IvaKind = Conn.RUN_SELECT("ivakind", "*", null, null, null, false);
			//Hashtable HIva = new Hashtable();
			//foreach (DataRow IvaKRow in IvaKind.Select()) HIva[IvaKRow["codeivakind"]] = IvaKRow["idivakind"];

			//// Lookup di Classificazione Analitica 1, Sara
			//int idsortingkind1 = CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1"));
			//string filterSort1 = QHS.CmpEq("idsorkind", idsortingkind1);
			//DataTable Sort1 = Conn.RUN_SELECT("sorting", "*", null, filterSort1, null, false);
			//Hashtable HSort1 = new Hashtable();
			//foreach (DataRow Sort1Row in Sort1.Select()) HSort1[Sort1Row["sortcode"]] = Sort1Row["idsor"];

			DataTable ExpirationKind = Conn.RUN_SELECT("expirationkind", "*", null, null, null, false);
			Hashtable HExpK = new Hashtable();
			foreach (DataRow ExpKRow in ExpirationKind.Select())
				HExpK[ExpKRow["shorttitle"]] = ExpKRow["idexpirationkind"];

			List<string> tosync = new List<string>();
			tosync.Add("registry");
			tosync.Add("estimatekind");
			tosync.Add("ivakind");
			tosync.Add("accmotive");
			InitSpeedSaver(Conn, tosync);


			Reader.Reset();
			string lastfilter = "";
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				object codtipocontratto = "";
				object annocontratto;
				object numcontratto;
				//if (MandateKind[Reader.getCurrField("codice_cpassivo")] != null) {

				string codice_cattivo = Reader.getCurrField("codice_cattivo").ToString();
				codtipocontratto = CheckEstimateKind(EstimateKind, codice_cattivo);
				/*}
				else {
				    SpeedSaver.AddError("Codice Tipo Ordine " + Reader.getCurrField("codice_cpassivo") + " non trovato alla linea "
				                + Reader.GetCurrRowNumber());
				    Reader.GetNext();
				    continue;
				}*/

				annocontratto = Reader.getCurrField("anno_contratto");
				numcontratto = Reader.getCurrField("numero_contratto");


				DataRow[] EstimateFound = null;
				string estimatedbfilter = "";

				// Controlliamo PRIMA se esiste già un ordine con la terna nman+yman+codtipoordine
				estimatedbfilter = QHS.AppAnd(QHS.CmpEq("nestim", numcontratto), QHS.CmpEq("yestim", annocontratto),
					QHS.CmpEq("idestimkind", codtipocontratto));
				DataTable DTContratto = Conn.RUN_SELECT("estimate", "*", null, estimatedbfilter, null, true);
				if (DTContratto.Rows.Count > 0) {
					// Errore! Nel DB è già presente una fattura con la terna indicata!
					SpeedSaver.AddError("Attenzione. E' già presente un contratto avente Anno:"
					                    + annocontratto.ToString() + " numero:" + numcontratto.ToString() +
					                    " e codice:" +
					                    Reader.getCurrField("codice_cattivo").ToString() + " - Riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				// Costruisci il filtro utilizzando l'ninv proveniente dal file
				estimatedbfilter = QHC.AppAnd(QHC.CmpEq("idestimkind", codtipocontratto),
					QHC.CmpEq("yestim", annocontratto), QHC.CmpEq("nestim", numcontratto));

				if (N > 100 && lastfilter != estimatedbfilter) {
					if (!SaveData(D, false))
						break;
					N = 0;
					D.Tables["estimate"].Clear();
					D.Tables["estimatedetail"].Clear();
					D.Tables["incomeestimate"].Clear();
				}

				lastfilter = estimatedbfilter;



				EstimateFound = D.Tables["estimate"].Select(estimatedbfilter);


				DataRow estimate;
				DataRow estimatedetail;
				string anagrafica_dettaglio = Reader.getCurrField("anagrafica_dettaglio").ToString().ToUpper();

				bool err;
				if (EstimateFound == null || EstimateFound.Length == 0) {
					// nuova fattura
					estimate = MetaEstimate.Get_New_Row(null, D.Tables["estimate"]);

					// Forse va disabilitato l'autoincremento, altrimenti viene inserita più volte una testata...
					RowChange.ClearAutoIncrement(D.Tables["estimate"].Columns["nestim"]);

					if (anagrafica_dettaglio == "N") {
						estimate["idreg"] = Reader.getCurrField("idreg");
					}

					estimate["idestimkind"] = codtipocontratto;
					estimate["yestim"] = annocontratto;
					estimate["nestim"] = numcontratto;
					estimate["description"] = Reader.getCurrField("descrizione");
					estimate["adate"] = ToSmalldateTime(Reader.getCurrField("datacont"));

					estimate["idexpirationkind"] = Reader.getCurrField("codexpirationkind");
					// E' sbagliata nel tracciato? Int16, NON DATA
					estimate["paymentexpiring"] = Reader.getCurrField("scadenzapag");

					estimate["idaccmotivecredit"] = CheckAccMotive(AccMotive, Reader.getCurrField("causalecredito"));

					estimate["deliveryaddress"] = Reader.getCurrField("indcons");
					estimate["deliveryexpiration"] = Reader.getCurrField("datacons");


					if (Reader.getCurrField("valuta_cont") == DBNull.Value ||
					    Reader.getCurrField("valuta_cont") == null)
						estimate["idcurrency"] = DBNull.Value;
					else {
						if (Hcur[Reader.getCurrField("valuta_cont")] == null) {
							SpeedSaver.AddError("Codice valuta: " + Reader.getCurrField("valuta_cont").ToString() +
							                    " non trovato alla riga " + Reader.GetCurrRowNumber() +
							                    " del file di input.");
							Reader.GetNext();
							continue;
						}
						else
							estimate["idcurrency"] = Hcur[Reader.getCurrField("valuta_cont")];
					}

					estimate["registryreference"] = Reader.getCurrField("riferimento");
					estimate["exchangerate"] = Reader.getCurrField("tassocambio_cont");
					estimate["doc"] = Reader.getCurrField("doc");
					estimate["docdate"] = ToSmalldateTime(Reader.getCurrField("datadoc"));

					estimate["active"] = Reader.getCurrField("attivo");
					estimate["flagintracom"] = Reader.getCurrField("flagintracom");

					estimate["txt"] = Reader.getCurrField("note_contratto");
					estimate["external_reference"] = Reader.getCurrField("rifesterno");


					object manager = Reader.getCurrField("resp");
					object idman = DBNull.Value;
					if (manager != DBNull.Value)
						idman = GetManager(Manager, manager.ToString(), iddivision, "S");
					estimate["idman"] = idman;

					//Verifica la presenza delle classificazioni
					for (int nsor = 1; nsor <= 5; nsor++) {
						estimate["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
							Reader.getCurrField("codtipoclass0" + nsor.ToString()).ToString(),
							Reader.getCurrField("codclass0" + nsor.ToString()).ToString(),
							out err);
						if (err) {
							SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
							                    " di codice " + Reader.getCurrField("codclass0" + nsor.ToString()) +
							                    " inesistente alla riga " + Reader.GetCurrRowNumber());

						}
					}

				}
				else {
					estimate = EstimateFound[0];
				}

				estimatedetail = MetaEstimateDetail.Get_New_Row(estimate, D.Tables["estimatedetail"]);
				RowChange.ClearAutoIncrement(D.Tables["estimatedetail"].Columns["rownum"]);

				estimatedetail["annotations"] = Reader.getCurrField("annotations");
				estimatedetail["rownum"] = Reader.getCurrField("nriga_cattivo");
				estimatedetail["competencystart"] = Reader.getCurrField("compstart");
				estimatedetail["competencystop"] = Reader.getCurrField("compstop");
				estimatedetail["detaildescription"] = Reader.getCurrField("descrdett");
				estimatedetail["discount"] = Reader.getCurrField("scontoperc");
				estimatedetail["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causalericavo"));
				estimatedetail["idaccmotiveannulment"] =
					CheckAccMotive(AccMotive, Reader.getCurrField("causaleannullamento"));

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (!HUpb.ContainsKey(codeupb)) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:"
						                    + Reader.GetCurrRowNumber());
					}
					else {
						idupb = HUpb[codeupb];
					}
				}

				estimatedetail["idupb"] = idupb;

				object intCode = Reader.getCurrField("intcode");
				object idlist = DBNull.Value;
				if (intCode != DBNull.Value) {
					if (vociListino.ContainsKey(intCode.ToString().ToLower())) {
						idlist = vociListino[intCode.ToString().ToLower()];
					}
					else {
						SpeedSaver.AddError("Voce di listino di codice " + intCode +
						                    " non trovata. Riga:"
						                    + Reader.GetCurrRowNumber());
					}
				}

				estimatedetail["idlist"] = idlist;

				estimatedetail["number"] = Reader.getCurrField("quantita");

				estimatedetail["tax"] = Reader.getCurrField("iva");
				estimatedetail["taxable"] = Reader.getCurrField("impon");
				estimatedetail["taxrate"] = Reader.getCurrField("aliquota");
				estimatedetail["toinvoice"] = Reader.getCurrField("toinvoice");


				estimatedetail["idreg"] = Reader.getCurrField("idreg");


				string codtipoiva = Reader.getCurrField("codtipoiva").ToString();
				object aliquota = Reader.getCurrField("aliquota");
				estimatedetail["idivakind"] = CheckIvaKind(IvaKind, codtipoiva, aliquota);


				//Dett.contratto
				//Verifica la presenza delle classificazioni
				for (int nsor = 1; nsor <= 3; nsor++) {
					estimatedetail["idsor" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
						idsortingkind[nsor],
						Reader.getCurrField("codclassanal" + nsor.ToString()).ToString(),
						out err);
					if (err) {
						SpeedSaver.AddError("Codice Classificazione Analitica n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclassanal" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

				string codicesiope = Reader.getCurrField("codsiope").ToString();

				if (codicesiope != "") {
					DataRow[] Rows = D.Tables["sorting"].Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						estimatedetail["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				object nfaseentrata = Reader.getCurrField("nfaseentrata");
				object esercmoventratacontimpon = Reader.getCurrField("esercmoventratacontimpon");
				object nummoventratacontimpon = Reader.getCurrField("nummoventratacontimpon");
				object esercmoventratacontiva = Reader.getCurrField("esercmoventratacontiva");
				object nummoventratacontiva = Reader.getCurrField("nummoventratacontiva");

				if (nummoventratacontimpon != DBNull.Value) {
					string FiltroEntrataImpon = QHS.AppAnd(QHS.CmpEq("ymov", esercmoventratacontimpon),
						QHS.CmpEq("nmov", nummoventratacontimpon), QHS.CmpEq("nphase", nfaseentrata),
						QHS.CmpEq("ayear", annocontratto));
					object idEntrataImpon = Conn.DO_READ_VALUE("incomeview", FiltroEntrataImpon, "idinc");
					if (idEntrataImpon == null || idEntrataImpon == DBNull.Value) {
						string movEntrataImpon = "Movimento di entrata di fase " + nfaseentrata.ToString()
						                                                         + " num. " +
						                                                         nummoventratacontimpon.ToString() +
						                                                         " del " +
						                                                         esercmoventratacontimpon.ToString() +
						                                                         " nell'anno " + annocontratto;
						SpeedSaver.AddError("Movimento non trovato: " + movEntrataImpon + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						estimatedetail["idinc_taxable"] = idEntrataImpon;
					}
				}

				if (nummoventratacontiva != DBNull.Value) {
					string FiltroEntrataIVA = QHS.AppAnd(QHS.CmpEq("ymov", esercmoventratacontiva),
						QHS.CmpEq("nmov", nummoventratacontiva), QHS.CmpEq("nphase", nfaseentrata),
						QHS.CmpEq("ayear", annocontratto));
					object idEntrataIVA = Conn.DO_READ_VALUE("incomeview", FiltroEntrataIVA, "idinc");
					if (idEntrataIVA == null || idEntrataIVA == DBNull.Value) {
						string movEntrataIVA = "Movimento di entrata di fase " + nfaseentrata.ToString() + " num. " +
						                       nummoventratacontiva.ToString() + " del " +
						                       esercmoventratacontiva.ToString() + " nell'anno " + annocontratto;
						SpeedSaver.AddError("Movimento non trovato: " + movEntrataIVA + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						estimatedetail["idinc_iva"] = idEntrataIVA;
					}
				}

				int movkind = 0;
				object idinctosearch = DBNull.Value;
				if (estimatedetail["idinc_taxable"] != DBNull.Value && estimatedetail["idinc_iva"] != DBNull.Value) {
					movkind = 1;
					idinctosearch = estimatedetail["idinc_taxable"];
				}

				if (estimatedetail["idinc_taxable"] != DBNull.Value && estimatedetail["idinc_iva"] == DBNull.Value) {
					movkind = 3;
					idinctosearch = estimatedetail["idinc_taxable"];
				}

				if (estimatedetail["idinc_taxable"] == DBNull.Value && estimatedetail["idinc_iva"] != DBNull.Value) {
					movkind = 2;
					idinctosearch = estimatedetail["idinc_iva"];
				}

				if (idinctosearch != DBNull.Value) {
					int nincman = Conn.RUN_SELECT_COUNT("incomeestimate", QHS.CmpEq("idinc", idinctosearch), false);
					if (nincman == 0)
						nincman = D.Tables["incomeestimate"].Select(QHC.CmpEq("idinc", idinctosearch)).Length;
					if (nincman == 0) {
						DataRow RIncMan = D.Tables["incomeestimate"].NewRow();
						RIncMan["idinc"] = idinctosearch;
						RIncMan["movkind"] = movkind;
						foreach (string ff in new string[] {"idestimkind", "yestim", "nestim"})
							RIncMan[ff] = estimatedetail[ff];
						RIncMan["ct"] = DateTime.Now;
						RIncMan["lt"] = DateTime.Now;
						RIncMan["cu"] = "importazione";
						RIncMan["lu"] = "importazione";
						D.Tables["incomeestimate"].Rows.Add(RIncMan);
					}
				}


				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;


		}


		private bool CreaFatture() {
			FlgImportaFatture = false;
			return ImportaCreaFatture();
		}

		private bool ImportaFatture() {
			FlgImportaFatture = true;
			return ImportaCreaFatture();
		}


		private bool ImportaTipoDocIva() {
			//   "codtipofattura; Codice Tipo Fattura;Stringa;20", 
			//   "descrtipofattura;Descrizione Tipo Fattura;Stringa;50",
			//   "acquisto_vendita;Acquisto/Vendita(A/V);Codificato;1;A|V",
			//   "numerazioneautomatica;Numerazione automatica(S/N);Codificato;1;S|N",
			//   "attivo;Attivo(S/N);Codificato;1;S|N",
			//   "notadicredito;Nota di Credito(S/N);Codificato;1;S|N",
			//   "autofattura;AutoFattura(S/N);Codificato;1;S|N",
			//   "soloentipubblici;Solo Enti Pubblici(S/N);Codificato;1;S|N",
			//   "escludientipubblici;Escludi Enti Pubblici(S/N);Codificato;1;S|N",
			//   "codtipoautofattura;Codice Tipo AutoFattura;Stringa;20", 
			//   "attivo;Attivo(S/N);Codificato;1;S|N",
			//   "fatturazione_elettronica;Fatturazione elettronica(S/N);Codificato;1;S|N",
			//   "codstampa; Codice Stampa;Stringa;20", 
			//   "intestazionereport;Intestazione Report;Stringa;150",
			//   "indirizzo;Indirizzo;Stringa;150",
			//   "codice_ipa;Indirizzo;Stringa;6",
			//   "riferimento_amministrazione;Indirizzo;Stringa;20",
			//   "codtipoclass01;Codice Tipo class. 01;Stringa;20",
			//   "codclass01;Codice class. 01;Stringa;50",
			//   "codtipoclass02;Codice Tipo class. 02;Stringa;20",
			//   "codclass02;Codice class. 02;Stringa;50",
			//   "codtipoclass03;Codice tipo class. 03;Stringa;20",
			//   "codclass03;Codice class. 03;Stringa;50",
			//   "codtipoclass04;Codice Tipo class. 04;Stringa;20",
			//   "codclass04;Codice class. 04;Stringa;50",
			//   "codtipoclass05;Codice Tipo class. 05;Stringa;20",
			//   "codclass05;Codice class. 05;Stringa;50" 
			LeggiFile Reader = GetReader(tracciato_tipodociva);
			if (Reader == null) return false;
			DataSet D = new vistaTipoDocIva();
			ClearAllNonDBOHash();
			MetaData MetaInvoiceKind = Meta.Dispatcher.Get("invoicekind");
			MetaInvoiceKind.SetDefaults(D.Tables["invoicekind"]);
			DataTable InvoiceKind = D.Tables["invoicekind"];
			Conn.RUN_SELECT_INTO_TABLE(InvoiceKind, null, null, null, false);

			DataTable InvoiceindYear = D.Tables["invoicekindyear"];
			MetaData MetaIvoicekindYear = Meta.Dispatcher.Get("invoicekindyear");
			MetaIvoicekindYear.SetDefaults(InvoiceindYear);

			List<string> tosync = new List<string>();
			tosync.Add("invoicekind");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				string codtipofattura;
				string descrtipofattura;
				string numerazioneautomatica;
				string codtipoautofattura;
				string attivo;
				string fatturazione_elettronica;
				object codstampa;
				object intestazionereport;
				object indirizzo;
				object codice_ipa;
				object riferimento_amministrazione;

				codtipofattura = Reader.getCurrField("codtipofattura").ToString();
				object idinvkind = CheckExistsInvoiceKind(InvoiceKind, codtipofattura);

				if ((idinvkind != DBNull.Value) && (idinvkind != null)) {
					SpeedSaver.AddError("Tipo Fattura " + codtipofattura +
					                    " già trovato alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow invoicekind;
				bool err;

				// nuovo tipo
				invoicekind = MetaInvoiceKind.Get_New_Row(null, D.Tables["invoicekind"]);
				// RowChange.ClearAutoIncrement(D.Tables["invoicekind"].Columns["idinvkind"]);

				invoicekind["codeinvkind"] = codtipofattura;
				descrtipofattura = Reader.getCurrField("descrtipofattura").ToString();
				invoicekind["description"] = descrtipofattura;

				numerazioneautomatica = Reader.getCurrField("numerazioneautomatica").ToString();
				invoicekind["flag_autodocnumbering"] = numerazioneautomatica;

				codtipoautofattura = Reader.getCurrField("codtipoautofattura").ToString();

				object idinvtipoautofattura = DBNull.Value;

				if (codtipoautofattura != "") {
					idinvtipoautofattura = CheckInvoiceKind(InvoiceKind, codtipoautofattura);
					if ((idinvtipoautofattura == DBNull.Value) || (idinvtipoautofattura == null)) {
						SpeedSaver.AddError("Tipo Auto Fattura " + codtipoautofattura +
						                    " già trovato alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekind["idinvkind_auto"] = idinvtipoautofattura;
				}


				codstampa = Reader.getCurrField("codstampa");
				invoicekind["printingcode"] = codstampa;
				intestazionereport = Reader.getCurrField("intestazionereport");
				indirizzo = Reader.getCurrField("indirizzo");
				codice_ipa = Reader.getCurrField("codice_ipa");
				riferimento_amministrazione = Reader.getCurrField("riferimento_amministrazione");
				invoicekind["header"] = intestazionereport;
				invoicekind["address"] = indirizzo;
				invoicekind["ipa_fe"] = codice_ipa;
				invoicekind["riferimento_amministrazione"] = riferimento_amministrazione;

				attivo = Reader.getCurrField("attivo").ToString();
				invoicekind["active"] = attivo;

				fatturazione_elettronica = Reader.getCurrField("fatturazione_elettronica").ToString();
				invoicekind["enable_fe"] = fatturazione_elettronica;

				//Verifica la presenza delle classificazioni
				for (int nsor = 1; nsor <= 5; nsor++) {
					invoicekind["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
						Reader.getCurrField("codtipoclass0" + nsor.ToString()).ToString(),
						Reader.getCurrField("codclass0" + nsor.ToString()).ToString(),
						out err);
					if (err) {
						SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclass0" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}
				// Contab. Mov. Entrata "invoicekind.flag:: 0";
				// Contab. Mov. Spesa  "invoicekind.flag:: #0";
				// Nota di Credito "invoicekind.flag: 2";
				// AutoFattura "invoicekind.flag: 3";
				// Escludi Enti Pubblici "invoicekind.flag: 5";
				// Solo Enti Pubblici  "invoicekind.flag: 4";

				int flag_inventorykind = 0;

				string acquisto_vendita = Reader.getCurrField("acquisto_vendita").ToString().ToUpper();
				string notadicredito = Reader.getCurrField("notadicredito").ToString().ToUpper();
				string autofattura = Reader.getCurrField("autofattura").ToString().ToUpper();
				string soloentipubblici = Reader.getCurrField("soloentipubblici").ToString().ToUpper();
				string escludientipubblici = Reader.getCurrField("escludientipubblici").ToString().ToUpper();

				if (acquisto_vendita == "V") flag_inventorykind += 1;
				if (notadicredito == "S") flag_inventorykind += 4;
				if (autofattura == "S") flag_inventorykind += 8;
				if (soloentipubblici == "S") flag_inventorykind += 16;
				if (escludientipubblici == "S") flag_inventorykind += 32;
				invoicekind["flag"] = flag_inventorykind;

				invoicekind["ct"] = DateTime.Now;
				invoicekind["lt"] = DateTime.Now;
				invoicekind["cu"] = "importazione";
				invoicekind["lu"] = "importazione";

				// Creazione Riga in invoicekindyear
				// nuovo tipo

				//MetaIvoicekindYear.Get_New_Row(invoicekind,InvoiceindYear);
				//MetaIvoicekindYear.SetDefaults(InvoiceindYear);


				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		string[] tracciato_accountvar = new string[] {
			"yvar;anno;Intero;4",
			"nvar;numero;Intero;7",
			"adate;Data contabile;Data;8",
			"description;Descrizione;Stringa;150",
			"annotation;Annotazioni;Stringa;400",
			"enactment;Provvedimento;Stringa;150",
			"nenactment;Numero Provvedimento;Intero;8",
			"enactmentdate;Data Provvedimento;Data;8",
			"enactmentnumber;Numero Atto Amministrativo;Intero;8",
			"idaccountvarstatus;Stato 1 Bozza, 2 Richiesta,3 Da Correggere, 4 Inserita, 5 Approvata, 6 Annullata;Codificato;1;1|2|3|4|5|6",
			"variationkind;Tipo variazione 1 normale, 3 Assestamento, 4 Storno, 5 iniziale;Codificato;1;1|3|4|5",
			"presunto;Presunto;Codificato;1;S|N",
			"reason;Motivazione;Stringa;400",
			"manager;Responsabile;Stringa;150",
			"underwritingkind;Fonte finanziamento C Contributo da terzi, I risorse da indebitamento, P Risorse proprie;Codificato;1;C|I|P",
			"amount;Importo anno;Numero;22",
			"amount2;Importo anno+1;Numero;22",
			"amount3;Importo anno+2;Numero;22",
			"amount4;Importo anno+3;Numero;22",
			"amount5;Importo anno+4;Numero;22",
			"codeacc;codice conto;Stringa;50",
			"codeupb;codice upb;Stringa;50",
			"costpartitioncode;codice ripartizione dei costi;Stringa;50",
			"descriptiondet;Descrizione dettaglio;Stringa;150",
			"annotationdet;Annotazioni dettaglio;Stringa;400",
			"sortcode1;Coord.analitica 1;Stringa;50",
			"sortcode2;Coord.analitica 2;Stringa;50",
			"sortcode3;Coord.analitica 3;Stringa;50",
			"sortcode01;Attr. sicurezza 1;Stringa;50",
			"sortcode02;Attr. sicurezza 2;Stringa;50",
			"sortcode03;Attr. sicurezza 3;Stringa;50",
			"sortcode04;Attr. sicurezza 4;Stringa;50",
			"sortcode05;Attr. sicurezza 5;Stringa;50",
            "codeclass;Codice classificazione inventariale;Stringa;20",
        };

		//tracciato unico per i contratti
		string[] tracciato_contrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"descrizionebreve;Descrizione sintetica Contratto;Stringa;50",
			"descrizione;Descrizione Contratto;Stringa;200",
			"codeupbcontratto;Cod. UPB Contratto CSA;Stringa;50",
			"codiceconto_main;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa_main;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesalordo;N.Fase Mov. spesa Lordo;Intero;4",
			"esercmovspesalordo;Eserc. Creazione Mov. Spesa Lordo;Intero;4",
			"nummovspesalordo;Numero Mov. Spesa Lordo;Intero;4",
			"conservannisuccessivi;Flag Conserva negli Anni successivi (Con Tipo Contr. Residui);Stringa;1",
			"ricreaincompetenza;Flag Ricrea Copia Contratto in Competenza negli Anni Successivi;Stringa;1",
			"attivo;Flag Attivo;Stringa;1",
			"codsiope;Codice Class. Siope;Stringa;50",
			"descrsiopeclass;Descr. Class. Siope;Stringa;200",
			"codicefinanziamento;Codice finanziamento;Stringa;50",
			"faseimpbudgetlordo;N.Fase Impegno Budget Lordo;Intero;4",
			"esercimpbudgetlordo;Eserc. Creazione Impegno Budget Lordo;Intero;4",
			"nummovimpbudgetlordo;Numero Impegno Budget Lordo;Intero;4"
		};

		string[] tracciato_ripcontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4"
		};

		string[] tracciato_ripmovbudgetcontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovbudget;Fase Mov. Budget (1 o 2) ;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4"
		};

		string[] tracciato_ripunicacontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"codiceupb;Cod. UPB;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4",
			"fasemovbudget;Fase Mov. Budget (1 o 2) ;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4",
			"codsiope;Codice Class. Siope;Stringa;50"
		};

		bool ImportaRipContrattiCSA() {
			/*
			string[] tracciato_ripcontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4"
			 * */
			LeggiFile Reader = GetReader(tracciato_ripcontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaRipContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Csa_ContractExpense = D.Tables["csa_contractexpense"];
			MetaData MetaCsa_Contractexpense = Meta.Dispatcher.Get("csa_contractexpense");
			MetaCsa_Contractexpense.SetDefaults(Csa_ContractExpense);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				MetaData.SetDefault(Csa_ContractExpense, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractExpense, "ayear", ayear);
				DataRow NewCsa_ContractExpense = MetaCsa_Contractexpense.Get_New_Row(null, Csa_ContractExpense);

				object nfasespesa = Reader.getCurrField("fasemovspesa");
				object esercmovspesa = Reader.getCurrField("esercmovspesa");
				object nummovspesa = Reader.getCurrField("nummovspesa");

				if (nummovspesa != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesa),
						QHS.CmpEq("nmov", nummovspesa), QHS.CmpEq("nphase", nfasespesa), QHS.CmpEq("ayear", ayear));
					object idSpesa = Conn.DO_READ_VALUE("expenseview", FiltroSpesa, "idexp");
					if (idSpesa == null || idSpesa == DBNull.Value) {
						string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                + " num. " + nummovspesa.ToString() + " del " +
						                                                esercmovspesa.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovspesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractExpense["idexp"] = idSpesa;
					}
				}


				object ndettaglio = Reader.getCurrField("ndettaglio");
				NewCsa_ContractExpense["ndetail"] = ndettaglio;
				object quota = Reader.getCurrField("quota");
				NewCsa_ContractExpense["quota"] = quota;

				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		bool ImportaRipImpegniBudgetContrattiCSA() {
			/*
			string[] tracciato_ripmovbudgetcontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovbudget;Fase Mov. Budget (1 o 2) ;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4"
			 * */
			LeggiFile Reader = GetReader(tracciato_ripmovbudgetcontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaRipImpegniBudgetContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Csa_ContractEpExp = D.Tables["csa_contractepexp"];
			MetaData MetaCsa_ContractEpExp = Meta.Dispatcher.Get("csa_contractepexp");
			MetaCsa_ContractEpExp.SetDefaults(Csa_ContractEpExp);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				MetaData.SetDefault(Csa_ContractEpExp, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractEpExp, "ayear", ayear);
				DataRow NewCsa_ContractEpExp = MetaCsa_ContractEpExp.Get_New_Row(null, Csa_ContractEpExp);

				object nfasemovbudget = Reader.getCurrField("fasemovbudget");
				object esercmovbudget = Reader.getCurrField("esercmovbudget");
				object nummovbudget = Reader.getCurrField("nummovbudget");

				if (nummovbudget != DBNull.Value) {
					string FiltroImpegnoBudget = QHS.AppAnd(QHS.CmpEq("yepexp", esercmovbudget),
						QHS.CmpEq("nepexp", nummovbudget), QHS.CmpEq("nphase", nfasemovbudget),
						QHS.CmpEq("ayear", ayear));
					object idEpExp = Conn.DO_READ_VALUE("epexpview", FiltroImpegnoBudget, "idepexp");
					if (idEpExp == null || idEpExp == DBNull.Value) {
						string movSpesa = "Movimento di Budget di fase " + nfasemovbudget.ToString()
						                                                 + " num. " + nummovbudget.ToString() +
						                                                 " del " +
						                                                 esercmovbudget.ToString() + " nell'anno " +
						                                                 ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovbudget + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractEpExp["idepexp"] = idEpExp;
					}
				}


				object ndettaglio = Reader.getCurrField("ndettaglio");
				NewCsa_ContractEpExp["ndetail"] = ndettaglio;
				object quota = Reader.getCurrField("quota");
				NewCsa_ContractEpExp["quota"] = quota;

				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		bool ImportaRipUnicaContrattiCSA() {
			/*
           -- DEFINIZIONE DEL TRACCIATO   --RIPARTIZIONE REGOLA SPECIFICA
			string[] tracciato_ripunicacontrattocsa = new string[] {
            "esercizio;Esercizio Imputazione Contratto;Intero;4",
            "eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
            "numerocontratto;Numero Contratto;Intero;4",
            "ndettaglio;Numero Dettaglio;Intero;4",
            "quota;Quota assegnazione;Numero;22",
            "codeupb;Cod. UPB;Stringa;50",
            "codiceconto;Cod. Conto EP Costo;Stringa;50",
            "codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
            "fasemovspesa;Fase Mov. spesa;Stringa;50",
            "esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
            "nummovspesa;Numero Mov. Spesa;Intero;4",
            "fasemovbudget;Fase Mov. Budget (1 o 2) ;Intero;4",
            "esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
            "nummovbudget;Numero Mov. Budget;Intero;4",
           "codsiope;Codice Class. Siope;Stringa;50",
		 };
             * */
			LeggiFile Reader = GetReader(tracciato_ripunicacontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaRipUnicaContrattiCSA();
			ClearAllNonDBOHash();
			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}

			DataTable Fin = D.Tables["fin"];

			DataTable SiopeSorting = D.Tables["sorting"];
			DataTable Csa_Contract_Partition = D.Tables["csa_contract_partition"];

			MetaData MetaCsa_Contract_Partition = Meta.Dispatcher.Get("csa_contract_partition");
			MetaCsa_Contract_Partition.SetDefaults(Csa_Contract_Partition);

			object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind",
				null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("account");
			tosync.Add("upb");
			tosync.Add("fin");
			InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				object ndettaglio = Reader.getCurrField("ndettaglio");

				// PK-- idcsa_contract, ayear, ndetail
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				string filterRipartizione = QHS.AppAnd(QHS.CmpEq("ayear", ayear),
					QHS.CmpEq("idcsa_contract", idcsa_contract),
					QHS.CmpEq("ndetail", ndettaglio));
				int count = Conn.RUN_SELECT_COUNT("csa_contract_partition", filterRipartizione, false);
				if (count > 0) {
					SpeedSaver.AddError("Una ripartizione regola specifica " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " dett. " + ndettaglio.ToString() +
					                    " è stata già trovata");
					Reader.GetNext();
					continue;
				}

				MetaData.SetDefault(Csa_Contract_Partition, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_Contract_Partition, "ayear", ayear);
				DataRow NewCsa_ContractPartition = MetaCsa_Contract_Partition.Get_New_Row(null, Csa_Contract_Partition);


				object nfasespesa = Reader.getCurrField("fasemovspesa");
				object esercmovspesa = Reader.getCurrField("esercmovspesa");
				object nummovspesa = Reader.getCurrField("nummovspesa");

				if (nummovspesa != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesa),
						QHS.CmpEq("nmov", nummovspesa), QHS.CmpEq("nphase", nfasespesa), QHS.CmpEq("ayear", ayear));
					DataRow imputazioneSpesa = GetRowExpenseYear(FiltroSpesa);
					if (imputazioneSpesa == null) {
						string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                + " num. " + nummovspesa.ToString() + " del " +
						                                                esercmovspesa.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError(movSpesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractPartition["idexp"] = imputazioneSpesa["idexp"];
						NewCsa_ContractPartition["idfin"] = imputazioneSpesa["idfin"];
						NewCsa_ContractPartition["idupb"] = imputazioneSpesa["idupb"];
					}
				}

				object nfasemovbudget = Reader.getCurrField("fasemovbudget");
				object esercmovbudget = Reader.getCurrField("esercmovbudget");
				object nummovbudget = Reader.getCurrField("nummovbudget");

				if (nummovbudget != DBNull.Value) {
					string FiltroImpegnoBudget = QHS.AppAnd(QHS.CmpEq("yepexp", esercmovbudget),
						QHS.CmpEq("nepexp", nummovbudget), QHS.CmpEq("nphase", nfasemovbudget),
						QHS.CmpEq("ayear", ayear));
					DataRow imputazioneImpegnoBudget = GetRowEpexpYear(FiltroImpegnoBudget);
					if (imputazioneImpegnoBudget == null) {
						string movSpesa = "Movimento di Budget di fase " + nfasemovbudget.ToString()
						                                                 + " num. " + nummovbudget.ToString() +
						                                                 " del " +
						                                                 esercmovbudget.ToString() + " nell'anno " +
						                                                 ayear;
						SpeedSaver.AddError(movSpesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractPartition["idepexp"] = imputazioneImpegnoBudget["idepexp"];
						NewCsa_ContractPartition["idacc"] = imputazioneImpegnoBudget["idacc"];
						NewCsa_ContractPartition["idupb"] = imputazioneImpegnoBudget["idupb"];
					}
				}

				string codeacc = Reader.getCurrField("codiceconto").ToString();

				if ((codeacc != "") && (NewCsa_ContractPartition["idacc"] == DBNull.Value)) {
					object idacc = getidAcc(Account, codeacc, ayear);

					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
						                    " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractPartition["idacc"] = idacc;
					}
				}

				string codiceupb = Reader.getCurrField("codiceupb").ToString();
				if ((codiceupb != "") && (NewCsa_ContractPartition["idupb"] == DBNull.Value)) {
					string searchupb = QHS.CmpEq("codeupb", codiceupb);

					if (!HUpb.ContainsKey(codiceupb)) {

						SpeedSaver.AddError("L'upb di codice " + codiceupb + " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						object idupb = HUpb[codiceupb];
						NewCsa_ContractPartition["idupb"] = idupb;
					}

				}

				string codicebilanciospesa = Reader.getCurrField("codicebilanciospesa").ToString();
				string codicesiope = Reader.getCurrField("codsiope").ToString();

				if ((codicebilanciospesa != "") && (NewCsa_ContractPartition["idfin"] == DBNull.Value)) {
					string searchfin = getFilterFin(codicebilanciospesa, "S", ayear);

					object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractPartition["idfin"] = idfin;
					}
				}


				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						NewCsa_ContractPartition["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				NewCsa_ContractPartition["ndetail"] = ndettaglio;
				object quota = Reader.getCurrField("quota");
				NewCsa_ContractPartition["quota"] = quota;

				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		string[] tracciato_ripcontributocontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4"
		};

		bool ImportaRipContributoContrattiCSA() {
			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4"
			 * */
			LeggiFile Reader = GetReader(tracciato_ripcontributocontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaRipContributiContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Csa_ContractTaxExpense = D.Tables["csa_contracttaxexpense"];
			MetaData MetaCsa_ContractTaxExpense = Meta.Dispatcher.Get("csa_contracttaxexpense");
			MetaCsa_ContractTaxExpense.SetDefaults(Csa_ContractTaxExpense);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}





				object vocecsa = Reader.getCurrField("vocecsa");
				string filterTax = QHS.AppAnd(QHS.CmpEq("idcsa_contract", idcsa_contract),
					QHS.CmpEq("vocecsa", vocecsa),
					QHS.CmpEq("ayear", ayear));
				object idcsacontracttax = Conn.DO_READ_VALUE("csa_contracttax", filterTax, "idcsa_contracttax");
				if ((idcsacontracttax == DBNull.Value) || (idcsacontracttax == null)) {
					SpeedSaver.AddError("Il dettaglio contratto " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() +
					                    " del " + ayear.ToString() +
					                    "della voce CSA" + vocecsa.ToString() + " non è stato trovato");

					Reader.GetNext();
					continue;
				}

				// Determino la riga di csa_contracttax di quel contratto riferito alla stessa voce csa
				MetaData.SetDefault(Csa_ContractTaxExpense, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractTaxExpense, "ayear", ayear);
				MetaData.SetDefault(Csa_ContractTaxExpense, "idcsa_contracttax", idcsacontracttax);

				DataRow NewCsa_ContractTaxExpense =
					MetaCsa_ContractTaxExpense.Get_New_Row(null, Csa_ContractTaxExpense);
				object nfasespesa = Reader.getCurrField("fasemovspesa");
				object esercmovspesa = Reader.getCurrField("esercmovspesa");
				object nummovspesa = Reader.getCurrField("nummovspesa");

				if (nummovspesa != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesa),
						QHS.CmpEq("nmov", nummovspesa), QHS.CmpEq("nphase", nfasespesa), QHS.CmpEq("ayear", ayear));
					object idSpesa = Conn.DO_READ_VALUE("expenseview", FiltroSpesa, "idexp");
					if (idSpesa == null || idSpesa == DBNull.Value) {
						string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                + " num. " + nummovspesa.ToString() + " del " +
						                                                esercmovspesa.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovspesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractTaxExpense["idexp"] = idSpesa;
					}
				}


				object ndettaglio = Reader.getCurrField("ndettaglio");
				NewCsa_ContractTaxExpense["ndetail"] = ndettaglio;
				object quota = Reader.getCurrField("quota");
				NewCsa_ContractTaxExpense["quota"] = quota;

				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		string[] tracciato_ripmovbudgetcontributocontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovbudget;Fase Mov. Budget;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4"
		};

		bool ImportaRipImpegniBudgetContributoContrattiCSA() {
			/*
			 * tracciato_ripmovbudgetcontributocontrattocsa = 
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"fasemovbudget;Fase Mov. Budget;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4"
			 * */
			LeggiFile Reader = GetReader(tracciato_ripmovbudgetcontributocontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaRipImpegniBudgetContributiContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Csa_ContractTaxEpExp = D.Tables["csa_contracttaxepexp"];
			MetaData MetaCsa_ContractTaxEpExp = Meta.Dispatcher.Get("csa_contracttaxepexp");
			MetaCsa_ContractTaxEpExp.SetDefaults(Csa_ContractTaxEpExp);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}





				object vocecsa = Reader.getCurrField("vocecsa");
				string filterTax = QHS.AppAnd(QHS.CmpEq("idcsa_contract", idcsa_contract),
					QHS.CmpEq("vocecsa", vocecsa),
					QHS.CmpEq("ayear", ayear));
				object idcsacontracttax = Conn.DO_READ_VALUE("csa_contracttax", filterTax, "idcsa_contracttax");
				if ((idcsacontracttax == DBNull.Value) || (idcsacontracttax == null)) {
					SpeedSaver.AddError("Il dettaglio contratto " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() +
					                    " del " + ayear.ToString() +
					                    "della voce CSA" + vocecsa.ToString() + " non è stato trovato");

					Reader.GetNext();
					continue;
				}

				// Determino la riga di csa_contracttax di quel contratto riferito alla stessa voce csa
				MetaData.SetDefault(Csa_ContractTaxEpExp, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractTaxEpExp, "ayear", ayear);
				MetaData.SetDefault(Csa_ContractTaxEpExp, "idcsa_contracttax", idcsacontracttax);

				DataRow NewCsa_ContractTaxEpExp = MetaCsa_ContractTaxEpExp.Get_New_Row(null, Csa_ContractTaxEpExp);
				object nfasemovbudget = Reader.getCurrField("fasemovbudget");
				object esercmovbudget = Reader.getCurrField("esercmovbudget");
				object nummovbudget = Reader.getCurrField("nummovbudget");

				if (nummovbudget != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("yepexp", esercmovbudget),
						QHS.CmpEq("nepexp", nummovbudget), QHS.CmpEq("nphase", nfasemovbudget),
						QHS.CmpEq("ayear", ayear));
					object idMovBudget = Conn.DO_READ_VALUE("epexpview", FiltroSpesa, "idepexp");
					if (idMovBudget == null || idMovBudget == DBNull.Value) {
						string movSpesa = "Movimento di spesa di fase " + nfasemovbudget.ToString()
						                                                + " num. " + nummovbudget.ToString() + " del " +
						                                                esercmovbudget.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovbudget + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractTaxEpExp["idepexp"] = idMovBudget;
					}
				}


				object ndettaglio = Reader.getCurrField("ndettaglio");
				NewCsa_ContractTaxEpExp["ndetail"] = ndettaglio;
				object quota = Reader.getCurrField("quota");
				NewCsa_ContractTaxEpExp["quota"] = quota;

				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		string[] tracciato_ripunicacontributocontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"codiceupb;Cod. UPB;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4",
			"fasemovbudget;Fase Mov. Budget;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4",
			"codsiope;Codice Class. Siope;Stringa;50",
		};

		bool ImportaRipUnicaContributoContrattiCSA() {
			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"ndettaglio;Numero Dettaglio;Intero;4",
			"quota;Quota assegnazione;Numero;22",
			"codeupb;Cod. UPB;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4",
			"fasemovbudget;Fase Mov. Budget;Intero;4",
			"esercmovbudget;Eserc. Creazione Mov. Budget;Intero;4",
			"nummovbudget;Numero Mov. Budget;Intero;4",
			"codsiope;Codice Class. Siope;Stringa;50",
             * */
			LeggiFile Reader = GetReader(tracciato_ripunicacontributocontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaRipUnicaContributiContrattiCSA();
			ClearAllNonDBOHash();
			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);


			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}

			DataTable Fin = D.Tables["fin"];

			DataTable SiopeSorting = D.Tables["sorting"];

			object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind",
				null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("account");
			tosync.Add("upb");
			tosync.Add("fin");
			InitSpeedSaver(Conn, tosync);
			DataTable Csa_ContractTax_Partition = D.Tables["csa_contracttax_partition"];
			MetaData MetaCsa_ContractTax_Partition = Meta.Dispatcher.Get("csa_contracttax_partition");
			MetaCsa_ContractTax_Partition.SetDefaults(Csa_ContractTax_Partition);


			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				object ndettaglio = Reader.getCurrField("ndettaglio");

				if (ndettaglio == DBNull.Value) {
					SpeedSaver.AddError("N. dettaglio non è stata trovato alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object vocecsa = Reader.getCurrField("vocecsa");
				string filterTax = QHS.AppAnd(QHS.CmpEq("idcsa_contract", idcsa_contract),
					QHS.CmpEq("vocecsa", vocecsa),
					QHS.CmpEq("ayear", ayear));
				object idcsacontracttax = Conn.DO_READ_VALUE("csa_contracttax", filterTax, "idcsa_contracttax");
				if ((idcsacontracttax == DBNull.Value) || (idcsacontracttax == null)) {
					SpeedSaver.AddError("Il dettaglio contratto " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() +
					                    " del " + ayear.ToString() +
					                    " della voce CSA" + vocecsa.ToString() + " non è stato trovato");

					Reader.GetNext();
					continue;
				}

				string filterRipartizione = QHS.AppAnd(filterTax,QHS.CmpEq("ndetail", ndettaglio));
				int count = Conn.RUN_SELECT_COUNT("csa_contracttax_partition", filterRipartizione, false);
				if (count > 0) {
					SpeedSaver.AddError("Una ripartizione controbuto regola specifica " + numerocontratto.ToString() +
					                    "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " della voce CSA" + vocecsa.ToString() +
					                    " dett. " + ndettaglio.ToString() +
					                    " è stata già trovata");
					Reader.GetNext();
					continue;
				}

				// Determino la riga di csa_contracttax di quel contratto riferito alla stessa voce csa
				MetaData.SetDefault(Csa_ContractTax_Partition, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractTax_Partition, "ayear", ayear);
				MetaData.SetDefault(Csa_ContractTax_Partition, "idcsa_contracttax", idcsacontracttax);

				DataRow NewCsa_ContractTax_Partition =
					MetaCsa_ContractTax_Partition.Get_New_Row(null, Csa_ContractTax_Partition);

				object nfasespesa = Reader.getCurrField("fasemovspesa");
				object esercmovspesa = Reader.getCurrField("esercmovspesa");
				object nummovspesa = Reader.getCurrField("nummovspesa");

				if (nummovspesa != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesa),
						QHS.CmpEq("nmov", nummovspesa), QHS.CmpEq("nphase", nfasespesa), QHS.CmpEq("ayear", ayear));
					DataRow imputazioneSpesa = GetRowExpenseYear(FiltroSpesa);
					if (imputazioneSpesa == null) {
						string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                + " num. " + nummovspesa.ToString() + " del " +
						                                                esercmovspesa.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError(movSpesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractTax_Partition["idexp"] = imputazioneSpesa["idexp"];
						NewCsa_ContractTax_Partition["idfin"] = imputazioneSpesa["idfin"];
						NewCsa_ContractTax_Partition["idupb"] = imputazioneSpesa["idupb"];
					}
				}


				object nfasemovbudget = Reader.getCurrField("fasemovbudget");
				object esercmovbudget = Reader.getCurrField("esercmovbudget");
				object nummovbudget = Reader.getCurrField("nummovbudget");

				if (nummovbudget != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("yepexp", esercmovbudget),
						QHS.CmpEq("nepexp", nummovbudget), QHS.CmpEq("nphase", nfasemovbudget),
						QHS.CmpEq("ayear", ayear));
					DataRow imputazioneMovBudget = GetRowEpexpYear(FiltroSpesa);
					if (imputazioneMovBudget == null) {
						string movSpesa = "Movimento di budget di fase " + nfasemovbudget.ToString()
						                                                 + " num. " + nummovbudget.ToString() +
						                                                 " del " +
						                                                 esercmovbudget.ToString() + " nell'anno " +
						                                                 ayear;
						SpeedSaver.AddError(movSpesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractTax_Partition["idepexp"] = imputazioneMovBudget["idepexp"];
						NewCsa_ContractTax_Partition["idacc"] = imputazioneMovBudget["idacc"];
						NewCsa_ContractTax_Partition["idupb"] = imputazioneMovBudget["idupb"];
					}
				}

				string codeacc = Reader.getCurrField("codiceconto").ToString();

				if ((codeacc != "") && (NewCsa_ContractTax_Partition["idacc"] == DBNull.Value)) {
					object idacc = getidAcc(Account, codeacc, ayear);

					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
						                    " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractTax_Partition["idacc"] = idacc;
					}
				}

				string codiceupb = Reader.getCurrField("codiceupb").ToString();
				if ((codiceupb != "") && (NewCsa_ContractTax_Partition["idupb"] == DBNull.Value)) {
					string searchupb = QHS.CmpEq("codeupb", codiceupb);

					if (!HUpb.ContainsKey(codiceupb)) {

						SpeedSaver.AddError("L'upb di codice " + codiceupb + " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						object idupb = HUpb[codiceupb];
						NewCsa_ContractTax_Partition["idupb"] = idupb;
					}

				}

				string codicebilanciospesa = Reader.getCurrField("codicebilanciospesa").ToString();
				string codicesiope = Reader.getCurrField("codsiope").ToString();

				if ((codicebilanciospesa != "") && (NewCsa_ContractTax_Partition["idfin"] == DBNull.Value)) {
					string searchfin = getFilterFin(codicebilanciospesa, "S", ayear);

					object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractTax_Partition["idfin"] = idfin;
					}
				}


				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						NewCsa_ContractTax_Partition["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}



				

				NewCsa_ContractTax_Partition["ndetail"] = ndettaglio;
				object quota = Reader.getCurrField("quota");
				NewCsa_ContractTax_Partition["quota"] = quota;

				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		string[] tracciato_tipocontrattocsa = new string[] {
			"anno;Anno;intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"descrtipocontratto;Descrizione Tipo Contratto CSA;Stringa;50",
			"conservannisuccessivi;Flag Conserva Tipo Contratto negli anni successivi;Stringa;1",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"codeupbtipocontratto;Cod. UPB Tipo Contratto CSA;Stringa;50",
			"codiceconto_main;Cod. Conto EP Costo Tipo Contratto;Stringa;50",
			"codicebilanciospesa_main;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"codsiope;Codice Class. Siope;Stringa;50",
			"codicefinanziamento;Codice finanziamento;Stringa;50"
		};


		string[] tracciato_contributitipocontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"vocecsa;Voce CSA;Stringa;200",
			"codiceupb;Cod. UPB Costo;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"codicesiope;Codice Class. Siope;Stringa;50"
		};


		bool ImportaContributiTipiContrattoCSA() {
			/*
			 "esercizio;Esercizio Imputazione Contratto;Intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"vocecsa;Voce CSA;Stringa;200",
			"codiceupb;Cod. UPB Costo;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"codsiope;Codice Class. Siope;Stringa;50"
			 * */
			LeggiFile Reader = GetReader(tracciato_contributitipocontrattocsa);
			if (Reader == null) return false;
			var D = new vistaContributiTipiContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}


			DataTable SiopeSorting = D.Tables["sorting"];

			DataTable Csa_ContractKind = D.csa_contractkind;
			MetaData MetaCsa_ContractKind = Meta.Dispatcher.Get("csa_contractkind");
			MetaCsa_ContractKind.SetDefaults(Csa_ContractKind);

			DataTable Csa_ContractKindData = D.csa_contractkinddata;
			MetaData MetaCsa_ContractKindData = Meta.Dispatcher.Get("csa_contractkinddata");
			MetaCsa_ContractKindData.SetDefaults(Csa_ContractKindData);

			Conn.RUN_SELECT_INTO_TABLE(Csa_ContractKind, null, null, null, false);

			object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind",
				null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object competenzaresidui = Reader.getCurrField("competenzaresidui");
				object codtipocontratto = Reader.getCurrField("codtipocontratto");

				string filterTipoContratto = QHC.AppAnd(QHC.CmpEq("flagcr", competenzaresidui),
					QHC.CmpEq("contractkindcode", codtipocontratto));
				// Trova il Tipo Contratto


				object idcsa_contractkind = Conn.DO_READ_VALUE("csa_contractkind", filterTipoContratto,
					"idcsa_contractkind");

				if ((idcsa_contractkind == DBNull.Value) || (idcsa_contractkind == null)) {
					SpeedSaver.AddError("Il tipo contratto di codice " + codtipocontratto + " del " + ayear.ToString() +
					                    " non è stato trovato");

					Reader.GetNext();
					continue;

				}

				MetaData.SetDefault(Csa_ContractKindData, "idcsa_contractkind", idcsa_contractkind);
				MetaData.SetDefault(Csa_ContractKindData, "ayear", ayear);
				DataRow NewCsa_ContractKindData = MetaCsa_ContractKindData.Get_New_Row(null, Csa_ContractKindData);

				string codeacc = Reader.getCurrField("codiceconto").ToString();

				if (codeacc != "") {

					object idacc = getidAcc(Account, codeacc, ayear);

					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
						                    " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractKindData["idacc"] = idacc;
					}
				}

				string codiceupb = Reader.getCurrField("codiceupb").ToString();
				if (codiceupb != "") {

					{
						string searchupb = QHC.CmpEq("codeupb", codiceupb);

						if (!HUpb.ContainsKey(codiceupb)) {

							SpeedSaver.AddError("L'upb di codice " + codiceupb + " non è stato trovato");
							Reader.GetNext();
							continue;
						}

						object idupb = HUpb[codiceupb];
						NewCsa_ContractKindData["idupb"] = idupb;
					}
				}



				string codicebilanciospesa = Reader.getCurrField("codicebilanciospesa").ToString();
				string codicesiope = Reader.getCurrField("codicesiope").ToString();

				if (codicebilanciospesa != "") {
					string searchfin = getFilterFin(codicebilanciospesa, "S", ayear);

					object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractKindData["idfin"] = idfin;
					}
				}


				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						NewCsa_ContractKindData["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				NewCsa_ContractKindData["vocecsa"] = Reader.getCurrField("vocecsa");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}


		string[] tracciato_regoletipocontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"capitolocsa;Capitolo CSA;Stringa;200",
			"ruolocsa;Ruolo CSA;Stringa;200"
		};

		bool ImportaRegoleTipiContrattoCSA() {
			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"capitolocsa;Capitolo CSA;Stringa;200",
			"ruolocsa;Ruolo CSA;Stringa;200"
			 * */
			LeggiFile Reader = GetReader(tracciato_regoletipocontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaContributiTipiContrattiCSA();
			ClearAllNonDBOHash();


			DataTable Csa_ContractKind = D.Tables["csa_contractkind"];
			MetaData MetaCsa_ContractKind = Meta.Dispatcher.Get("csa_contractkind");
			MetaCsa_ContractKind.SetDefaults(Csa_ContractKind);

			DataTable Csa_ContractKindRules = D.Tables["csa_contractkindrules"];
			MetaData MetaCsa_ContractKindRules = Meta.Dispatcher.Get("csa_contractkindrules");
			MetaCsa_ContractKindRules.SetDefaults(Csa_ContractKindRules);


			Conn.RUN_SELECT_INTO_TABLE(Csa_ContractKind, null, null, null, false);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object competenzaresidui = Reader.getCurrField("competenzaresidui");
				object codtipocontratto = Reader.getCurrField("codtipocontratto");
				object capitolocsa = Reader.getCurrField("capitolocsa");
				object ruolocsa = Reader.getCurrField("ruolocsa");
				string filterTipoContratto = QHC.AppAnd(QHC.CmpEq("flagcr", competenzaresidui),
					QHC.CmpEq("contractkindcode", codtipocontratto));
				// Trova il Tipo Contratto
				object idcsa_contractkind = Conn.DO_READ_VALUE("csa_contractkind", filterTipoContratto,
					"idcsa_contractkind");

				if ((idcsa_contractkind == DBNull.Value) || (idcsa_contractkind == null)) {
					SpeedSaver.AddError("Il tipo contratto di codice " + codtipocontratto + " del " + ayear.ToString() +
					                    " non è stato trovato");

					Reader.GetNext();
					continue;

				}

				MetaData.SetDefault(Csa_ContractKindRules, "idcsa_contractkind", idcsa_contractkind);
				MetaData.SetDefault(Csa_ContractKindRules, "ayear", ayear);
				DataRow NewCsa_ContractKindRules = MetaCsa_ContractKindRules.Get_New_Row(null, Csa_ContractKindRules);
				NewCsa_ContractKindRules["idcsa_contractkind"] = idcsa_contractkind;
				NewCsa_ContractKindRules["ayear"] = ayear;
				NewCsa_ContractKindRules["capitolocsa"] = capitolocsa;
				NewCsa_ContractKindRules["ruolocsa"] = ruolocsa;
				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}


		string[] tracciato_contributicontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"codeupb;Cod. UPB Costo;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4",
			"codsiope;Codice Class. Siope;Stringa;50",
			"faseimpbudget;Fase Impegno Budget;Intero;4",
			"esercimpbudget;Eserc. Creazione Impegno Budget;Intero;4",
			"nummovimpbudget;Numero Impegno Budget;Intero;4"
		};


		string[] tracciato_contributicontrattocsa_nuovaversione = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200"
		};


		bool ImportaContributiContrattoCSA() {

			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200",
			"codeupb;Cod. UPB Costo;Stringa;50",
			"codiceconto;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesa;Fase Mov. spesa;Stringa;50",
			"esercmovspesa;Eserc. Creazione Mov. Spesa;Intero;4",
			"nummovspesa;Numero Mov. Spesa;Intero;4",
			"codsiope;Codice Class. Siope;Stringa;50",
			"faseimpbudget;Fase Impegno Budget;Intero;4",
			"esercimpbudget;Eserc. Creazione Impegno Budget;Intero;4",
			"nummovimpbudget;Numero Impegno Budget;Intero;4"
			 * */
			LeggiFile Reader = GetReader(tracciato_contributicontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaContributiContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}



			DataTable SiopeSorting = D.Tables["sorting"];

			DataTable Csa_ContractKind = D.Tables["csa_contractkind"];
			MetaData MetaCsa_ContractKind = Meta.Dispatcher.Get("csa_contractkind");
			MetaCsa_ContractKind.SetDefaults(Csa_ContractKind);


			DataTable Csa_ContractTax = D.Tables["csa_contracttax"];
			MetaData MetaCsa_ContractTax = Meta.Dispatcher.Get("csa_contracttax");
			MetaCsa_ContractTax.SetDefaults(Csa_ContractTax);


			Conn.RUN_SELECT_INTO_TABLE(Csa_ContractKind, null, null, null, false);
			object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind",
				null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Tipo Contratto


				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;

				}

				MetaData.SetDefault(Csa_ContractTax, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractTax, "ayear", ayear);
				DataRow NewCsa_ContractTax = MetaCsa_ContractTax.Get_New_Row(null, Csa_ContractTax);
				string codeacc = Reader.getCurrField("codiceconto").ToString();
				if (codeacc != "") {
					object idacc = getidAcc(Account, codeacc, ayear);

					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
						                    " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {

						NewCsa_ContractTax["idacc"] = idacc;
					}
				}

				string codiceupb = Reader.getCurrField("codiceupb").ToString();

				if (codiceupb != "") {
					string searchupb = QHS.CmpEq("codeupb", codiceupb);

					if (!HUpb.ContainsKey(codiceupb)) {

						SpeedSaver.AddError("L'upb di codice " + codiceupb + " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						object idupb = HUpb[codiceupb];
						NewCsa_ContractTax["idupb"] = idupb;
					}

				}



				string codicebilanciospesa = Reader.getCurrField("codicebilanciospesa").ToString();
				string codicesiope = Reader.getCurrField("codsiope").ToString();

				if (codicebilanciospesa != "") {
					string searchfin = getFilterFin(codicebilanciospesa, "S", ayear);

					object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_ContractTax["idfin"] = idfin;
					}
				}


				if (codicesiope != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

					object idsor = DBNull.Value;
					if (Rows.Length > 0) {
						idsor = Rows[0]["idsor"];
						NewCsa_ContractTax["idsor_siope"] = idsor;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				NewCsa_ContractTax["vocecsa"] = Reader.getCurrField("vocecsa");
				object nfasespesa = Reader.getCurrField("fasemovspesa");
				object esercmovspesa = Reader.getCurrField("esercmovspesa");
				object nummovspesa = Reader.getCurrField("nummovspesa");

				if (nummovspesa != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesa),
						QHS.CmpEq("nmov", nummovspesa), QHS.CmpEq("nphase", nfasespesa), QHS.CmpEq("ayear", ayear));
					object idSpesa = Conn.DO_READ_VALUE("expenseview", FiltroSpesa, "idexp");
					if (idSpesa == null || idSpesa == DBNull.Value) {
						string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                + " num. " + nummovspesa.ToString() + " del " +
						                                                esercmovspesa.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovspesa + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractTax["idexp"] = idSpesa;
					}
				}

				object faseimpbudget = Reader.getCurrField("faseimpbudget");
				object esercimpbudget = Reader.getCurrField("esercimpbudget");
				object nummovimpbudget = Reader.getCurrField("nummovimpbudget");

				if (nummovimpbudget != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("yepexp", esercimpbudget),
						QHS.CmpEq("nepexp", nummovimpbudget), QHS.CmpEq("nphase", faseimpbudget),
						QHS.CmpEq("ayear", ayear));
					object idImpBudget = Conn.DO_READ_VALUE("epexpview", FiltroSpesa, "idepexp");
					if (idImpBudget == null || idImpBudget == DBNull.Value) {
						string movSpesa = "Movimento di budget di fase " + faseimpbudget.ToString()
						                                                 + " num. " + nummovimpbudget.ToString() +
						                                                 " del " +
						                                                 esercimpbudget.ToString() + " nell'anno " +
						                                                 ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovimpbudget + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_ContractTax["idepexp"] = idImpBudget;
					}
				}

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}


		bool ImportaContributiContrattoCSA_nuovagestione() {

			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"vocecsa;Voce CSA;Stringa;200"
			*/
			LeggiFile Reader = GetReader(tracciato_contributicontrattocsa_nuovaversione);
			if (Reader == null) return false;
			DataSet D = new vistaContributiContrattiCSA();
			ClearAllNonDBOHash();

			//DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);

			//DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			//Dictionary<string, string> HUpb = new Dictionary<string, string>();
			//foreach (DataRow r in UPB.Rows) {
			//	HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			//}

			//DataTable SiopeSorting = D.Tables["sorting"];

			DataTable Csa_ContractKind = D.Tables["csa_contractkind"];
			MetaData MetaCsa_ContractKind = Meta.Dispatcher.Get("csa_contractkind");
			MetaCsa_ContractKind.SetDefaults(Csa_ContractKind);


			DataTable Csa_ContractTax = D.Tables["csa_contracttax"];
			MetaData MetaCsa_ContractTax = Meta.Dispatcher.Get("csa_contracttax");
			MetaCsa_ContractTax.SetDefaults(Csa_ContractTax);


			Conn.RUN_SELECT_INTO_TABLE(Csa_ContractKind, null, null, null, false);

			// CLASSIFICAZIONI NO
			//object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind", null);
			//string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			//Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				string filterContratto = QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("ncontract", numerocontratto),
					QHC.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Tipo Contratto


				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
										eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
										" non è stato trovato");
					Reader.GetNext();
					continue;

				}

				MetaData.SetDefault(Csa_ContractTax, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractTax, "ayear", ayear);
				DataRow NewCsa_ContractTax = MetaCsa_ContractTax.Get_New_Row(null, Csa_ContractTax);
				//string codeacc = Reader.getCurrField("codiceconto").ToString();
				//if (codeacc != "") {
				//	object idacc = getidAcc(Account, codeacc, ayear);

				//	if (idacc == null || idacc == DBNull.Value) {
				//		SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
				//							" non è stato trovato");
				//		Reader.GetNext();
				//		continue;
				//	}
				//	else {

				//		NewCsa_ContractTax["idacc"] = idacc;
				//	}
				//}

				//string codiceupb = Reader.getCurrField("codiceupb").ToString();

				//if (codiceupb != "") {
				//	string searchupb = QHS.CmpEq("codeupb", codiceupb);

				//	if (!HUpb.ContainsKey(codiceupb)) {

				//		SpeedSaver.AddError("L'upb di codice " + codiceupb + " non è stato trovato");
				//		Reader.GetNext();
				//		continue;
				//	}
				//	else {
				//		object idupb = HUpb[codiceupb];
				//		NewCsa_ContractTax["idupb"] = idupb;
				//	}

				//}



				//string codicebilanciospesa = Reader.getCurrField("codicebilanciospesa").ToString();
				//string codicesiope = Reader.getCurrField("codsiope").ToString();

				//if (codicebilanciospesa != "") {
				//	string searchfin = getFilterFin(codicebilanciospesa, "S", ayear);

				//	object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
				//	if (idfin == null || idfin == DBNull.Value) {
				//		SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa +
				//							" non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
				//		Reader.GetNext();
				//		continue;
				//	}
				//	else {
				//		NewCsa_ContractTax["idfin"] = idfin;
				//	}
				//}


				//if (codicesiope != "") {
				//	DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope));

				//	object idsor = DBNull.Value;
				//	if (Rows.Length > 0) {
				//		idsor = Rows[0]["idsor"];
				//		NewCsa_ContractTax["idsor_siope"] = idsor;
				//	}
				//	else {
				//		SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope +
				//							" non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
				//		Reader.GetNext();
				//		continue;
				//	}
				//}

				NewCsa_ContractTax["vocecsa"] = Reader.getCurrField("vocecsa");
				//object nfasespesa = Reader.getCurrField("fasemovspesa");
				//object esercmovspesa = Reader.getCurrField("esercmovspesa");
				//object nummovspesa = Reader.getCurrField("nummovspesa");

				//if (nummovspesa != DBNull.Value) {
				//	string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesa),
				//		QHS.CmpEq("nmov", nummovspesa), QHS.CmpEq("nphase", nfasespesa), QHS.CmpEq("ayear", ayear));
				//	object idSpesa = Conn.DO_READ_VALUE("expenseview", FiltroSpesa, "idexp");
				//	if (idSpesa == null || idSpesa == DBNull.Value) {
				//		string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
				//														+ " num. " + nummovspesa.ToString() + " del " +
				//														esercmovspesa.ToString() + " nell'anno " +
				//														ayear;
				//		SpeedSaver.AddError("Movimento non trovato: " + nummovspesa + " alla riga:" +
				//							Reader.GetCurrRowNumber());
				//	}
				//	else {
				//		NewCsa_ContractTax["idexp"] = idSpesa;
				//	}
				//}

				//object faseimpbudget = Reader.getCurrField("faseimpbudget");
				//object esercimpbudget = Reader.getCurrField("esercimpbudget");
				//object nummovimpbudget = Reader.getCurrField("nummovimpbudget");

				//if (nummovimpbudget != DBNull.Value) {
				//	string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("yepexp", esercimpbudget),
				//		QHS.CmpEq("nepexp", nummovimpbudget), QHS.CmpEq("nphase", faseimpbudget),
				//		QHS.CmpEq("ayear", ayear));
				//	object idImpBudget = Conn.DO_READ_VALUE("epexpview", FiltroSpesa, "idepexp");
				//	if (idImpBudget == null || idImpBudget == DBNull.Value) {
				//		string movSpesa = "Movimento di budget di fase " + faseimpbudget.ToString()
				//														 + " num. " + nummovimpbudget.ToString() +
				//														 " del " +
				//														 esercimpbudget.ToString() + " nell'anno " +
				//														 ayear;
				//		SpeedSaver.AddError("Movimento non trovato: " + nummovimpbudget + " alla riga:" +
				//							Reader.GetCurrRowNumber());
				//	}
				//	else {
				//		NewCsa_ContractTax["idepexp"] = idImpBudget;
				//	}
				//}

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		string[] tracciato_matricolecontrattocsa = new string[] {
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"matricola;Matricola;Stringa;40",
			"cf;C.F.;Stringa;16",
			"codiceanagrafica;Codice anagrafica;Intero;10", //valorizziamo direttamente idreg
		};

		bool ImportaMatricoleContrattiCSA() {
			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"matricola;Matricola;Stringa;40",
			"cf;C.F.;Stringa;16",
			"codiceanagrafica;Codice anagrafica;Intero;10",  //valorizziamo direttamente idreg
			 * */
			LeggiFile Reader = GetReader(tracciato_matricolecontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaMatricoleContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Csa_ContractRegistry = D.Tables["csa_contractregistry"];
			MetaData MetaCsa_ContractRegistry = Meta.Dispatcher.Get("csa_contractregistry");
			MetaCsa_ContractRegistry.SetDefaults(Csa_ContractRegistry);

			//List<string> tosync = new List<string>();
			//tosync.Add("account");
			//tosync.Add("upb");
			//tosync.Add("fin");
			//tosync.Add("underwriting");
			//InitSpeedSaver(Conn, tosync);
			Reader.GetNext();
			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				object numerocontratto = Reader.getCurrField("numerocontratto");
				object eserccompetenzacontratto = Reader.getCurrField("eserccompetenzacontratto");
				object cf = Reader.getCurrField("cf");
				object matricola = Reader.getCurrField("matricola");
				object codiceanagrafica = Reader.getCurrField("codiceanagrafica");
				string filterContratto = QHS.AppAnd(QHS.CmpEq("ayear", ayear), QHS.CmpEq("ncontract", numerocontratto),
					QHS.CmpEq("ycontract", eserccompetenzacontratto));
				// Trova il Contratto
				object idcsa_contract = Conn.DO_READ_VALUE("csa_contract", filterContratto, "idcsa_contract");

				if ((idcsa_contract == DBNull.Value) || (idcsa_contract == null)) {
					SpeedSaver.AddError("Il contratto di codice " + numerocontratto.ToString() + "/" +
					                    eserccompetenzacontratto.ToString() + " del " + ayear.ToString() +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}


				// Trova L'anagrafica
				string filterAnagrafica = "";
				if (cf != DBNull.Value)
					filterAnagrafica = QHS.AppAnd(QHS.CmpEq("cf", cf), QHS.CmpEq("active", 'S'));
				if (codiceanagrafica != DBNull.Value)
					filterAnagrafica = QHS.AppAnd(QHS.CmpEq("idreg", codiceanagrafica), QHS.CmpEq("active", 'S'));
				object idreg = DBNull.Value;
				if ((codiceanagrafica != DBNull.Value) || (cf != DBNull.Value))
					idreg = Conn.DO_READ_VALUE("registry", filterAnagrafica, "idreg");

				if (((idreg == DBNull.Value) || (idreg == null)) &&
				    ((codiceanagrafica != DBNull.Value) || (cf != DBNull.Value))) {
					SpeedSaver.AddError("L'anagrafica numero / codice fiscale" + codiceanagrafica.ToString() + "/" +
					                    cf.ToString() +
					                    " non è stata trovata");
					Reader.GetNext();
					continue;
				}

				MetaData.SetDefault(Csa_ContractRegistry, "idcsa_contract", idcsa_contract);
				MetaData.SetDefault(Csa_ContractRegistry, "ayear", ayear);
				DataRow NewCsa_ContractRegistry = MetaCsa_ContractRegistry.Get_New_Row(null, Csa_ContractRegistry);
				NewCsa_ContractRegistry["idreg"] = idreg;
				NewCsa_ContractRegistry["extmatricula"] = Reader.getCurrField("matricola");
				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		Dictionary<string, object> csacontractkind = new Dictionary<string, object>();

		object CheckCsa_ContractKind(DataTable csa_contractkind, string codtipocontratto, string description, string cr,
			string flagkeepalive, object idunderwriting) {

			object idcsa_contractkind = DBNull.Value;
			if (csacontractkind.ContainsKey(codtipocontratto)) return csacontractkind[codtipocontratto];

			string filter = QHS.CmpEq("contractkindcode", codtipocontratto);
			idcsa_contractkind = Conn.DO_READ_VALUE("csa_contractkind",
				QHS.AppAnd(QHS.CmpEq("contractkindcode", codtipocontratto), QHS.CmpEq("flagcr", cr)),
				"idcsa_contractkind");

			if ((idcsa_contractkind == DBNull.Value) || (idcsa_contractkind == null)) {
				MetaData MetaCsa_contractkind = Meta.Dispatcher.Get("csa_contractkind");
				DataRow NewCsa_contractkind = MetaCsa_contractkind.Get_New_Row(null, csa_contractkind);
				NewCsa_contractkind["contractkindcode"] = codtipocontratto;
				NewCsa_contractkind["description"] = description;
				NewCsa_contractkind["flagkeepalive"] = flagkeepalive;
				NewCsa_contractkind["idunderwriting"] = idunderwriting;
				NewCsa_contractkind["flagcr"] = cr;
				NewCsa_contractkind["active"] = "S";
				NewCsa_contractkind["ct"] = DateTime.Now;
				NewCsa_contractkind["lt"] = DateTime.Now;
				NewCsa_contractkind["cu"] = "importazione";
				NewCsa_contractkind["lu"] = "importazione";
				csacontractkind[codtipocontratto] = NewCsa_contractkind["idcsa_contractkind"];
			}
			else {
				csacontractkind[codtipocontratto] = idcsa_contractkind;
			}

			return csacontractkind[codtipocontratto];
		}



		private bool ImportaTipoContrattoCsa() {
			//tracciato_tipocontrattocsa
			//"anno;Anno;intero;4",
			//"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			//"descrtipocontratto;Descrizione Tipo Contratto CSA;Stringa;50",
			//"conservannisuccessivi;Flag Attivo;Stringa;1",
			//"competenzaresidui;Flag Attivo;Stringa;1",
			// Tabella imputazione annuale
			//"codiceupb;Cod. UPB Tipo Contratto CSA;Stringa;50",
			//"codiceconto_main;Cod. Conto EP Costo Tipo Contratto;Stringa;50",
			//"codicebilanciospesa_main;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			//"codsiope_main;Codice Class. Siope;Stringa;50",
			//"codicefinanziamento;Cod. Finanziamento Tipo Contratto;Stringa;150",

			LeggiFile Reader = GetReader(tracciato_tipocontrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaTipoContrattiCSA();
			ClearAllNonDBOHash();
			MetaData MetaCsa_ContractKindYear = Meta.Dispatcher.Get("csa_contractkindyear");
			MetaCsa_ContractKindYear.SetDefaults(D.Tables["csa_contractkindyear"]);
			DataTable csa_contractkindyear = D.Tables["csa_contractkindyear"];
			Conn.RUN_SELECT_INTO_TABLE(csa_contractkindyear, null, null, null, false);

			DataTable csa_contractkind = D.Tables["csa_contractkind"];
			Conn.RUN_SELECT_INTO_TABLE(csa_contractkind, null, null, null, false);

			DataTable SiopeSorting = D.Tables["sorting"];
			MetaData MetaSiopeSorting = Meta.Dispatcher.Get("sorting");


			object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind",
				null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);


			DataTable Underwriting = D.Tables["underwriting"];
			MetaData MetaUnderwriting = Meta.Dispatcher.Get("underwriting");

			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}

			List<string> tosync = new List<string>();
			tosync.Add("csa_contractkind");
			tosync.Add("csa_contractkindyear");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				object anno;
				string codtipocontratto;
				string descrtipocontratto;
				string conservannisuccessivi;
				string competenzaresidui;
				string codiceupb;
				string codiceconto_main;
				string codicebilanciospesa_main;
				string codicesiope_main;

				anno = Reader.getCurrField("anno");
				codtipocontratto = Reader.getCurrField("codtipocontratto").ToString();

				descrtipocontratto = Reader.getCurrField("descrtipocontratto").ToString();
				conservannisuccessivi = Reader.getCurrField("conservannisuccessivi").ToString();
				competenzaresidui = Reader.getCurrField("competenzaresidui").ToString();
				codiceupb = Reader.getCurrField("codeupbtipocontratto").ToString();
				codiceconto_main = Reader.getCurrField("codiceconto_main").ToString();
				codicebilanciospesa_main = Reader.getCurrField("codicebilanciospesa_main").ToString();
				codicesiope_main = Reader.getCurrField("codsiope").ToString();

				object idunderwriting = DBNull.Value;
				string codeunderwriting = Reader.getCurrField("codicefinanziamento").ToString();
				if (codeunderwriting != "") {
					string searchunderwriting = QHC.CmpEq("codeunderwriting", codeunderwriting);
					if (Underwriting.Select(searchunderwriting).Length == 0) {
						SpeedSaver.AddError("Il finanziamento di codice " + codeunderwriting + " non è stato trovato");
						Reader.GetNext();
						continue;
					}

					idunderwriting = Underwriting.Select(searchunderwriting)[0]["idunderwriting"];

				}

				object idcsa_contractkind = CheckCsa_ContractKind(csa_contractkind, codtipocontratto,
					descrtipocontratto,
					competenzaresidui, conservannisuccessivi, idunderwriting);

				DataRow csa_contractkindyear_r;

				object idacc;
				// nuovo tipo contratto
				anno = Reader.getCurrField("anno").ToString();
				MetaData.SetDefault(D.Tables["csa_contractkindyear"], "idcsa_contractkind", idcsa_contractkind);
				MetaData.SetDefault(D.Tables["csa_contractkindyear"], "ayear", anno);
				csa_contractkindyear_r = MetaCsa_ContractKindYear.Get_New_Row(null, D.Tables["csa_contractkindyear"]);

				codiceconto_main = Reader.getCurrField("codiceconto_main").ToString();
				if (codiceconto_main != "") {

					idacc = getidAcc(Account, codiceconto_main, anno);
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_main + " del " + anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					csa_contractkindyear_r["idacc_main"] = idacc;
				}

				if (codiceupb != "") {
					string searchupb = QHS.CmpEq("codeupb", codiceupb);

					if (!HUpb.ContainsKey(codiceupb)) {

						SpeedSaver.AddError("UPB avente codice " + codiceupb +
						                    " non è stato trovato alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					object idupb = HUpb[codiceupb];
					csa_contractkindyear_r["idupb"] = idupb;
				}

				if (codicebilanciospesa_main != "") {
					string searchfin = getFilterFin(codicebilanciospesa_main, "S", anno);

					object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa_main +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					csa_contractkindyear_r["idfin_main"] = idfin;
				}


				if (codicesiope_main != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope_main));

					object idsor_main = DBNull.Value;
					if (Rows.Length > 0) {
						idsor_main = Rows[0]["idsor"];
						csa_contractkindyear_r["idsor_siope_main"] = idsor_main;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope_main +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				csa_contractkindyear_r["ct"] = DateTime.Now;
				csa_contractkindyear_r["lt"] = DateTime.Now;
				csa_contractkindyear_r["cu"] = "importazione";
				csa_contractkindyear_r["lu"] = "importazione";
				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}



		bool ImportaContrattiCSA() {
			/*
			"esercizio;Esercizio Imputazione Contratto;Intero;4",
			"codtipocontratto;Codice Tipo Contratto CSA;Stringa;20",
			"competenzaresidui;Competenza o Residui (C/R);Stringa;1",
			"eserccompetenzacontratto;Esercizio Competenza Contratto;Intero;4",
			"numerocontratto;Numero Contratto;Intero;4",
			"descrizionebreve;Descrizione sintetica Contratto;Stringa;50",
			"descrizione;Descrizione Contratto;Stringa;200",
			"codiceeupb;Cod. UPB Contratto CSA;Stringa;50",
			"codiceconto_main;Cod. Conto EP Costo;Stringa;50",
			"codicebilanciospesa_main;Cod. Bilancio Spesa per Imputazione Costo;Stringa;50",
			"fasemovspesalordo;Fase Mov. spesa Lordo;Stringa;50",
			"esercmovspesalordo;Eserc. Creazione Mov. Spesa Lordo;Intero;4",
			"nummovspesalordo;Numero Mov. Spesa Lordo;Intero;4",
			"conservannisuccessivi;Flag Conserva negli Anni successivi (Con Tipo Contr. Residui);Stringa;1",
			"ricreaincompetenza;Flag Ricrea Copia Contratto in Competenza negli Anni Successivi;Stringa;1",
			"attivo;Flag Attivo;Stringa;1",
			"codsiope;Codice Class. Siope;Stringa;50",
			"descrsiopeclass;Descr. Class. Siope;Stringa;200",
			"codfinanziamento;Codice Finanziamento;Stringa;50",
			"finanziamento;Descr. Finanziamento;Stringa;150",
			"faseimpbudgetlordo;Fase Impegno Budget Lordo;Intero;4",
			"esercimpbudgetlordo;Eserc. Creazione Impegno Budget Lordo;Intero;4",
			"nummovimpbudgetlordo;Numero Impegno Budget Lordo;Intero;4"
			 * */
			LeggiFile Reader = GetReader(tracciato_contrattocsa);
			if (Reader == null) return false;
			DataSet D = new vistaContrattiCSA();
			ClearAllNonDBOHash();

			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);


			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}

			DataTable Fin = D.Tables["fin"];

			DataTable Underwriting = D.Tables["underwriting"];

			DataTable SiopeSorting = D.Tables["sorting"];


			DataTable Csa_ContractKind = D.Tables["csa_contractkind"];
			MetaData MetaCsa_ContractKind = Meta.Dispatcher.Get("csa_contractkind");
			MetaCsa_ContractKind.SetDefaults(Csa_ContractKind);

			DataTable Csa_Contract = D.Tables["csa_contract"];
			MetaData MetaCsa_Contract = Meta.Dispatcher.Get("csa_contract");
			MetaCsa_Contract.SetDefaults(Csa_Contract);

			Conn.RUN_SELECT_INTO_TABLE(Underwriting, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Csa_ContractKind, null, null, null, false);

			object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind",
				null);

			string filterSiope = QHS.CmpEq("idsorkind", idsorkind);
			Conn.RUN_SELECT_INTO_TABLE(SiopeSorting, null, filterSiope, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("account");
			tosync.Add("upb");
			tosync.Add("fin");
			tosync.Add("underwriting");
			InitSpeedSaver(Conn, tosync);
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("esercizio");
				string codtipocontratto = Reader.getCurrField("codtipocontratto").ToString();
				string competenzaresidui = Reader.getCurrField("competenzaresidui").ToString();
				string filterTipoContratto = QHC.AppAnd(QHC.CmpEq("flagcr", competenzaresidui),
					QHC.CmpEq("contractkindcode", codtipocontratto));
				// Trova il Tipo Contratto


				object idcsa_contractkind = Conn.DO_READ_VALUE("csa_contractkind", filterTipoContratto,
					"idcsa_contractkind");

				if ((idcsa_contractkind == DBNull.Value) || (idcsa_contractkind == null)) {
					SpeedSaver.AddError("Il tipo contratto di codice " + codtipocontratto + " e competenza " +
					                    competenzaresidui + " del " + ayear.ToString() +
					                    " non è stato trovato");

					Reader.GetNext();
					continue;

				}

				DataRow NewCsa_Contract = MetaCsa_Contract.Get_New_Row(null, Csa_Contract);

				// Forse va disabilitato l'autoincremento, altrimenti viene inserita più volte una testata...
				//RowChange.ClearAutoIncrement(Csa_Contract.Columns["ncontract"]);
				NewCsa_Contract["idcsa_contractkind"] = idcsa_contractkind;

				string codeacc = Reader.getCurrField("codiceconto_main").ToString();

				if (codeacc != "") {
					object idacc = getidAcc(Account, codeacc, ayear);

					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
						                    " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_Contract["idacc_main"] = idacc;
					}
				}


				string codiceupb = Reader.getCurrField("codiceupb").ToString();
				if (codiceupb != "") {
					string searchupb = QHS.CmpEq("codeupb", codiceupb);

					if (!HUpb.ContainsKey(codiceupb)) {

						SpeedSaver.AddError("L'upb di codice " + codiceupb + " non è stato trovato");
						Reader.GetNext();
						continue;
					}
					else {
						object idupb = HUpb[codiceupb];
						NewCsa_Contract["idupb"] = idupb;
					}

				}

				string codicebilanciospesa_main = Reader.getCurrField("codicebilanciospesa_main").ToString();
				string codicesiope_main = Reader.getCurrField("codsiope").ToString();

				if (codicebilanciospesa_main != "") {
					string searchfin = getFilterFin(codicebilanciospesa_main, "S", ayear);

					object idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce Bilancio Spesa avente codice " + codicebilanciospesa_main +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else {
						NewCsa_Contract["idfin_main"] = idfin;
					}
				}


				if (codicesiope_main != "") {
					DataRow[] Rows = SiopeSorting.Select(QHC.CmpEq("sortcode", codicesiope_main));

					object idsor_main = DBNull.Value;
					if (Rows.Length > 0) {
						idsor_main = Rows[0]["idsor"];
						NewCsa_Contract["idsor_siope_main"] = idsor_main;
					}
					else {
						SpeedSaver.AddError("Classificazione Siope avente codice " + codicesiope_main +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				object nfasespesa = Reader.getCurrField("fasemovspesalordo");
				object esercmovspesalordo = Reader.getCurrField("esercmovspesalordo");
				object nummovspesalordo = Reader.getCurrField("nummovspesalordo");

				if (nummovspesalordo != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesalordo),
						QHS.CmpEq("nmov", nummovspesalordo), QHS.CmpEq("nphase", nfasespesa),
						QHS.CmpEq("ayear", ayear));
					object idSpesa = Conn.DO_READ_VALUE("expenseview", FiltroSpesa, "idexp");
					if (idSpesa == null || idSpesa == DBNull.Value) {
						string movSpesa = "Movimento di spesa di fase " + nfasespesa.ToString()
						                                                + " num. " + nummovspesalordo.ToString() +
						                                                " del " +
						                                                esercmovspesalordo.ToString();
						SpeedSaver.AddError("Movimento non trovato: " + nummovspesalordo + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_Contract["idexp_main"] = idSpesa;
					}
				}

				object faseimpbudgetlordo = Reader.getCurrField("faseimpbudgetlordo");
				object esercimpbudgetlordo = Reader.getCurrField("esercimpbudgetlordo");
				object nummovimpbudgetlordo = Reader.getCurrField("nummovimpbudgetlordo");

				if (nummovimpbudgetlordo != DBNull.Value) {
					string FiltroSpesa = QHS.AppAnd(QHS.CmpEq("yepexp", esercimpbudgetlordo),
						QHS.CmpEq("nepexp", nummovimpbudgetlordo), QHS.CmpEq("nphase", faseimpbudgetlordo),
						QHS.CmpEq("ayear", ayear));
					object idImpBudget = Conn.DO_READ_VALUE("epexpview", FiltroSpesa, "idepexp");
					if (idImpBudget == null || idImpBudget == DBNull.Value) {
						string movSpesa = "Movimento di spesa di fase " + faseimpbudgetlordo.ToString()
						                                                + " num. " + nummovimpbudgetlordo.ToString() +
						                                                " del " +
						                                                esercimpbudgetlordo.ToString() + " nell'anno " +
						                                                ayear;
						SpeedSaver.AddError("Movimento non trovato: " + nummovimpbudgetlordo + " alla riga:" +
						                    Reader.GetCurrRowNumber());
					}
					else {
						NewCsa_Contract["idepexp_main"] = idImpBudget;
					}
				}


				object idunderwriting = DBNull.Value;
				string codeunderwriting = Reader.getCurrField("codicefinanziamento").ToString();
				if (codeunderwriting != "") {
					string searchunderwriting = QHC.CmpEq("codeunderwriting", codeunderwriting);
					if (Underwriting.Select(searchunderwriting).Length == 0) {
						SpeedSaver.AddError("Il finanziamento di codice " + codeunderwriting + " non è stato trovato");
						Reader.GetNext();
						continue;
					}

					idunderwriting = Underwriting.Select(searchunderwriting)[0]["idunderwriting"];
					NewCsa_Contract["idunderwriting"] = idunderwriting;
				}

				NewCsa_Contract["description"] = Reader.getCurrField("descrizione");
				NewCsa_Contract["title"] = Reader.getCurrField("descrizionebreve");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}


		bool ImportaAccountVar() {
			LeggiFile Reader = GetReader(tracciato_accountvar);
			if (Reader == null) return false;
			var D = new vistaAccountVar();
			ClearAllNonDBOHash();


			DataTable AccountVar = D.accountvar;
			MetaData MetaAccountVar = Meta.Dispatcher.Get("accountvar");
			MetaAccountVar.SetDefaults(AccountVar);

			DataTable AccountVarDetail = D.accountvardetail;
			MetaData MetaAccountVarDetail = Meta.Dispatcher.Get("accountvardetail");
			MetaAccountVarDetail.SetDefaults(AccountVarDetail);

			DataTable Account = D.account;
			MetaData MetaAccount = Meta.Dispatcher.Get("account");
			MetaAccount.SetDefaults(Account);

			DataTable Upb = D.upb;
			MetaData MetaUpb = Meta.Dispatcher.Get("upb");
			MetaUpb.SetDefaults(Upb);

            DataTable InvTree = D.inventorytree;
            MetaData MetaInvTree = Meta.Dispatcher.Get("inventorytree");
            MetaInvTree.SetDefaults(InvTree);

            Conn.RUN_SELECT_INTO_TABLE(InvTree, null, null, null, false);

            int[] idsortingkind = new int[] {
				0, CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind2")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind3"))
			};
			int[] idsortingkind0 = new int[] {
				0, CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind01")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind02")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind03")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind04")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind05"))
			};



			Conn.RUN_SELECT_INTO_TABLE(Account, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Upb, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("account");
			tosync.Add("upb");
			InitSpeedSaver(Conn, tosync);

			bool err;
			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codeacc = Reader.getCurrField("codeacc").ToString();
				object ayear = Reader.getCurrField("yvar");
				string searchfin = getSqlFilterAcc(codeacc, ayear);
				DataRow[] foundAcc =
					Account.Select(QHC.AppAnd(QHC.CmpEq("codeacc", codeacc), QHC.CmpEq("ayear", ayear)));
				if (foundAcc.Length == 0) {
					SpeedSaver.AddError("Il conto di codice " + codeacc + " del " + ayear +
					                    " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				object idacc = foundAcc[0]["idacc"];

				string codeupb = Reader.getCurrField("codeupb").ToString();
				string searchupb = QHC.CmpEq("codeupb", codeupb);
				DataRow[] upbFound = Upb.Select(searchupb);
				if (upbFound.Length == 0) {
					SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato");
					Reader.GetNext();
					continue;
				}

				object idupb = upbFound[0]["idupb"];


				//Vede se c'è da aggiungere la variazione di bilancio
				object yvar = Reader.getCurrField("yvar");
				object nvar = Reader.getCurrField("nvar");

				if (nvar == DBNull.Value) {
					SpeedSaver.AddError("Numero variazione non trovato per la variazione  del " + yvar +
					                    " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow RVar;
				string filtervar = QHC.AppAnd(QHC.CmpEq("yvar", yvar), QHC.CmpEq("nvar", nvar));
				if (AccountVar.Select(filtervar).Length > 0) {
					RVar = AccountVar.Select(filtervar)[0];
				}
				else {
					MetaData.SetDefault(AccountVar, "yvar", yvar);
					RVar = MetaAccountVar.Get_New_Row(null, AccountVar);
					RowChange.ClearAutoIncrement(AccountVar.Columns["nvar"]);

					RVar["yvar"] = yvar;
					RVar["nvar"] = nvar;
					RVar["variationkind"] = Reader.getCurrField("variationkind");
					RVar["reason"] = Reader.getCurrField("reason");

					string presunto = Reader.getCurrField("presunto").ToString().ToUpper();
					int flag = presunto == "S" ? 1 : 0; 
					RVar["flag"] = flag;

					object idman = DBNull.Value;
					object man = Reader.getCurrField("manager");
					if (man != DBNull.Value) {
						idman = Conn.DO_READ_VALUE("manager", QHS.CmpEq("title", man), "idman");
						if (idman == null || idman == DBNull.Value) {
							SpeedSaver.AddError("Responsabile non trovato: " +
							                    Reader.getCurrField("manager").ToString() +
							                    " alla riga:" + Reader.GetCurrRowNumber()
							);
							Reader.GetNext();
							continue;
						}

						RVar["idman"] = idman;
					}

					RVar["adate"] = ToSmalldateTime(Reader.getCurrField("adate"));

					object description = Reader.getCurrField("description");
					if (description.ToString().Trim() == "") description = ".";
					RVar["description"] = description;
					RVar["annotation"] = Reader.getCurrField("annotation");

					RVar["enactment"] = Reader.getCurrField("enactment");
					RVar["enactmentdate"] = ToSmalldateTime(Reader.getCurrField("enactmentdate"));
					RVar["nenactment"] = Reader.getCurrField("nenactment");
					object idenactment = DBNull.Value;
					object enactmentnumber = Reader.getCurrField("enactmentnumber");
					if (enactmentnumber != DBNull.Value) {
						idenactment = Conn.DO_READ_VALUE("accountenactment", QHS.CmpEq("nenactment", enactmentnumber),
							"idenactment");
						if (idenactment == null || idenactment == DBNull.Value) {
							SpeedSaver.AddError("Atto Amministrativo non trovato: " +
							                    Reader.getCurrField("enactmentnumber").ToString() +
							                    " alla riga:" + Reader.GetCurrRowNumber()
							);
							Reader.GetNext();
							continue;
						}

						RVar["idenactment"] = idenactment;
					}

					RVar["idaccountvarstatus"] = Reader.getCurrField("idaccountvarstatus");


					for (int nsor = 1; nsor <= 5; nsor++) {
						RVar["idsor0" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
							idsortingkind0[nsor],
							Reader.getCurrField("sortcode0" + nsor.ToString()).ToString(),
							out err);
						if (err) {
							SpeedSaver.AddError("Codice Attributo di sicurezza n." + nsor.ToString() +
							                    " di codice " + Reader.getCurrField("sortcode0" + nsor.ToString()) +
							                    " inesistente alla riga " + Reader.GetCurrRowNumber());
						}
					}







					RVar["ct"] = DateTime.Now;
					RVar["lt"] = DateTime.Now;
					RVar["cu"] = "importazione";
					RVar["lu"] = "importazione";

				}

				//Finalmente aggiunge il dettaglio variazione
				DataRow NewVarDetail = MetaAccountVarDetail.Get_New_Row(RVar, AccountVarDetail);

				NewVarDetail["idacc"] = idacc;
				NewVarDetail["idupb"] = idupb;

				NewVarDetail["amount"] = Reader.getCurrField("amount");
				NewVarDetail["amount2"] = Reader.getCurrField("amount2");
				NewVarDetail["amount3"] = Reader.getCurrField("amount3");
				NewVarDetail["amount4"] = Reader.getCurrField("amount4");
				NewVarDetail["amount5"] = Reader.getCurrField("amount5");
				NewVarDetail["underwritingkind"] = Reader.getCurrField("underwritingkind");

				NewVarDetail["description"] = Reader.getCurrField("descriptiondet");
				NewVarDetail["annotation"] = Reader.getCurrField("annotationdet");

                object codeclass = Reader.getCurrField("codeclass");
                if (codeclass != DBNull.Value) {
                    object idinv = DBNull.Value;
                    string filterinvtree = QHC.CmpEq("codeinv", Reader.getCurrField("codeclass"));
                    if (InvTree.Select(filterinvtree).Length > 0) {
                        idinv = InvTree.Select(filterinvtree)[0]["idinv"];
                        NewVarDetail["idinv"] = idinv;
                    }
                    else {
                        SpeedSaver.AddError("Classificazione inventariale di codice " + Reader.getCurrField("codeclass") +
                                            " non trovata per la variazione " + nvar.ToString() + " del " +
                                            yvar.ToString() +
                                            " alla riga:" + Reader.GetCurrRowNumber());
                    }
                }
                object partCode = Reader.getCurrField("costpartitioncode");
				if (partCode != DBNull.Value) {
					object idpartition = Conn.DO_READ_VALUE("costpartition",
						QHS.CmpEq("costpartitioncode", partCode),
						"idcostpartition");
					if (idpartition == null) {
						SpeedSaver.AddError("La ripartizione costi di codice " + partCode +
						                    " non è stata trovata");
						Reader.GetNext();
						continue;
					}

					NewVarDetail["idcostpartition"] = idpartition;
				}


				for (int nsor = 1; nsor <= 3; nsor++) {
					NewVarDetail["idsor" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
						idsortingkind[nsor],
						Reader.getCurrField("sortcode" + nsor.ToString()).ToString(),
						out err);
					if (err) {
						SpeedSaver.AddError("Codice Coord. analitica n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("sortcode" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

				NewVarDetail["ct"] = DateTime.Now;
				NewVarDetail["lt"] = DateTime.Now;
				NewVarDetail["cu"] = "importazione";
				NewVarDetail["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		private bool ImportaScrittureEP() {

			LeggiFile Reader = GetReader(tracciato_scrittureep);
			if (Reader == null) return false;
			DataSet D = new vistaScritture();
			ClearAllNonDBOHash();
			MetaData MetaEntry = Meta.Dispatcher.Get("entry");
			MetaEntry.SetDefaults(D.Tables["entry"]);

			MetaData MetaEntryDetail = Meta.Dispatcher.Get("entrydetail");
			MetaEntryDetail.SetDefaults(D.Tables["entrydetail"]);

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}

			DataTable AccMotive = Conn.RUN_SELECT("accmotive", "*", null, null, null, false);

			GetSortCached.Init();
			int[] idsortingkind = new int[] {
				0, CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind2")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind3"))
			};

			string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));


			List<string> tosync = new List<string>();
			tosync.Add("registry");
			tosync.Add("accmotive");
			InitSpeedSaver(Conn, tosync);


			Reader.Reset();
			string lastfilter = "";
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				object annoscrittura;
				object numscrittura;

				//string codice_cpassivo = Reader.getCurrField("codice_cpassivo").ToString();
				//codtipoordine = CheckMandateKind(MandateKind, codice_cpassivo);

				annoscrittura = Reader.getCurrField("anno");
				numscrittura = Reader.getCurrField("numero");

				DataRow[] EntryFound = null;
				string entrydbfilter = "";

				// Controlliamo PRIMA se esiste già un ordine con la terna nman+yman+codtipoordine
				entrydbfilter = QHS.AppAnd(QHS.CmpEq("nentry", numscrittura), QHS.CmpEq("yentry", annoscrittura));
				DataTable DTEntry = Conn.RUN_SELECT("entry", "*", null, entrydbfilter, null, true);
				if (DTEntry.Rows.Count > 0) {
					// Errore! Nel DB è già presente una fattura con la coppia indicata!
					SpeedSaver.AddError("Attenzione. E' già presente una scrittura avente Anno:"
					                    + annoscrittura.ToString() + " numero:" + numscrittura.ToString() + " - Riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				// Costruisci il filtro utilizzando l'ninv proveniente dal file
				entrydbfilter = QHC.AppAnd(QHC.CmpEq("yentry", annoscrittura), QHC.CmpEq("nentry", numscrittura));

				if (N > 100 && lastfilter != entrydbfilter) {
					if (!SaveData(D, false)) break;
					N = 0;
					D.Tables["entry"].Clear();
					D.Tables["entrydetail"].Clear();
					//D.Tables["expensemandate"].Clear();
				}

				lastfilter = entrydbfilter;

				EntryFound = D.Tables["entry"].Select(entrydbfilter);
				DataRow entry;
				DataRow entrydetail;

				if (EntryFound == null || EntryFound.Length == 0) {
					// nuova fattura
					entry = MetaEntry.Get_New_Row(null, D.Tables["entry"]);

					RowChange.ClearAutoIncrement(D.Tables["entry"].Columns["nentry"]);


					//entry["idreg"] = Reader.getCurrField("idreg");
					entry["yentry"] = annoscrittura;
					entry["nentry"] = numscrittura;
					entry["description"] = Reader.getCurrField("descrizione");
					entry["adate"] = ToSmalldateTime(Reader.getCurrField("datacontabile"));
					entry["doc"] = Reader.getCurrField("doc");
					entry["docdate"] = ToSmalldateTime(Reader.getCurrField("datadoc"));
					entry["identrykind"] = Reader.getCurrField("tipo");
					entry["locked"] = Reader.getCurrField("bloccata");
					entry["idrelated"] = Reader.getCurrField("idrelated");

					object official = Reader.getCurrField("ufficiale");
					if (official != DBNull.Value)
						entry["official"] = official;

					bool err;
					//Verifica la presenza degli attr. di sicurezza
					for (int nsor = 1; nsor <= 5; nsor++) {
						object codiceclass = Reader.getCurrField("codtipoclass0" + nsor.ToString());
						object codiceTipoclass = Reader.getCurrField("codtipoclass0" + nsor.ToString());
						if ( codiceclass.ToString()=="") continue;
						if ( codiceTipoclass.ToString()=="") continue;
						
						entry["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
							codiceTipoclass.ToString(),
							codiceclass.ToString(),
							out err);
						if (err) {
							SpeedSaver.AddError(
								$"Codice Attributo n.{nsor} di codice {codiceclass}(tipo class{codiceTipoclass})  inesistente alla riga {Reader.GetCurrRowNumber()}");

						}
					}

				}
				else {
					entry = EntryFound[0];
				}

				entrydetail = MetaEntryDetail.Get_New_Row(entry, D.Tables["entrydetail"]);
				RowChange.ClearAutoIncrement(D.Tables["entrydetail"].Columns["ndetail"]);

				//entrydetail["annotations"] = Reader.getCurrField("annotations");
				entrydetail["ndetail"] = Reader.getCurrField("ndett");
				//entrydetail["assetkind"] = Reader.getCurrField("tipobene");

				entrydetail["competencystart"] = Reader.getCurrField("compstart");
				entrydetail["competencystop"] = Reader.getCurrField("compstop");

				entrydetail["description"] = Reader.getCurrField("descrdettaglio");

				entrydetail["idrelated"] = Reader.getCurrField("idrelated_det");

				string codiceconto = Reader.getCurrField("codiceconto").ToString();
				string searchconto;
				object idacc;

				if (codiceconto != "") {
					searchconto = getSqlFilterAcc(codiceconto, annoscrittura.ToString());
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto + " del " +
						                    annoscrittura.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					entrydetail["idacc"] = idacc;
				}


				entrydetail["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causale"));

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (!HUpb.ContainsKey(codeupb)) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:"
						                    + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else {
						idupb = HUpb[codeupb];
					}
				}


				string D_A = Reader.getCurrField("dareavere").ToString();
				decimal importo = CfgFn.GetNoNullDecimal(Reader.getCurrField("importo"));
				if (D_A.ToString().ToUpper() == "D") {
					importo = -importo;
				}

				entrydetail["idupb"] = idupb;
				entrydetail["idreg"] = Reader.getCurrField("idreg");
				entrydetail["amount"] = importo;
				entrydetail["importcode"] = Reader.getCurrField("codimportazione");


				//Dett.scrittura
				//Verifica la presenza delle classificazioni
				bool err1;
				for (int nsor = 1; nsor <= 3; nsor++) {
					entrydetail["idsor" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
						idsortingkind[nsor],
						Reader.getCurrField("codclassanal" + nsor.ToString()).ToString(),
						out err1);
					if (err1) {
						SpeedSaver.AddError("Codice Classificazione Analitica n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclassanal" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

				int esercizio = Conn.GetEsercizio();
				object nimpegno = Reader.getCurrField("nimpegno");
				object aaimpegno = Reader.getCurrField("aaimpegno");
				if (nimpegno != DBNull.Value) {
					string FiltroImpegnoBudget = QHS.AppAnd(QHS.CmpEq("yepexp", aaimpegno),
						QHS.CmpEq("nepexp", nimpegno), QHS.CmpEq("nphase", 2), QHS.CmpEq("ayear", esercizio));
					object idEpExp = Conn.DO_READ_VALUE("epexpview", FiltroImpegnoBudget, "idepexp");
					if (idEpExp == null || idEpExp == DBNull.Value) {
						string movSpesa = "Impegno di Budget di fase  num. " + nimpegno.ToString() + " del " +
						                  aaimpegno.ToString() + " nell'anno " + esercizio;
						SpeedSaver.AddError(movSpesa + " alla riga:" + Reader.GetCurrRowNumber());
					}
					else {
						entrydetail["idepexp"] = idEpExp;
					}
				}

				object naccertamento = Reader.getCurrField("naccertamento");
				object aaaccertamento = Reader.getCurrField("aaaccertamento");
				if (naccertamento != DBNull.Value) {
					string FiltroAccertamentoBudget = QHS.AppAnd(QHS.CmpEq("yepacc", aaaccertamento),
						QHS.CmpEq("nepacc", naccertamento), QHS.CmpEq("nphase", 2), QHS.CmpEq("ayear", esercizio));
					object idEpacc = Conn.DO_READ_VALUE("epaccview", FiltroAccertamentoBudget, "idepacc");
					if (idEpacc == null || idEpacc == DBNull.Value) {
						string mov = "Accertamento di Budget di fase  num. " + nimpegno.ToString() + " del " +
						             aaaccertamento.ToString() + " nell'anno " + esercizio;
						SpeedSaver.AddError(mov + " alla riga:" + Reader.GetCurrRowNumber());
					}
					else {
						entrydetail["idepacc"] = idEpacc;
					}
				}

				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		private bool ImportaTipoDocIvaAnnuale() {
			//"anno;Anno;intero;4",
			//"codtipofattura; Codice Tipo Fattura;Stringa;20", 
			//"codiceconto_sconto;Codice Conto per Sconto;Stringa;50",
			//"codiceconto_ivaimmediata;Codice Conto per Iva Immediata;Stringa;50",
			//"codiceconto_ivadifferita;Codice Conto per Iva Differita;Stringa;50",
			//"codiceconto_ivaindetraibile;Codice Conto per Iva Indetraibile;Stringa;50",
			//"codiceconto_intra_ivaimmediata;Codice Conto  per Iva Immediata (Intra - UE ed Extra-UE);Stringa;50",
			//"codiceconto_intra_ivadifferita;Codice Conto per Iva Differita (Intra - UE ed Extra-UE);Stringa;50",
			//"codiceconto_intra_ivaindetraibile;Codice Conto per Iva Indetraibile (Intra - UE ed Extra-UE);Stringa;50",
			//"codiceconto_split_ivaimmediata;Codice Conto per Iva Immediata (Split);Stringa;50",
			//"codiceconto_split_ivadifferita;Codice Conto per Iva Differita (Split);Stringa;50",
			//"codiceconto_split_ivaindetraibile;Codice Conto per IVA Indetraibile (Split);Stringa;50",

			LeggiFile Reader = GetReader(tracciato_tipodocivaannuale);
			if (Reader == null) return false;
			DataSet D = new vistaTipoDocIvaAnnuale();
			ClearAllNonDBOHash();
			MetaData MetaInvoiceKindYear = Meta.Dispatcher.Get("invoicekindyear");
			MetaInvoiceKindYear.SetDefaults(D.Tables["invoicekindyear"]);
			DataTable InvoiceKindYear = D.Tables["invoicekindyear"];
			Conn.RUN_SELECT_INTO_TABLE(InvoiceKindYear, null, null, null, false);

			DataTable InvoiceKind = D.Tables["invoicekind"];
			Conn.RUN_SELECT_INTO_TABLE(InvoiceKind, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("invoicekindyear");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				object anno;
				string codtipofattura;
				string codiceconto_sconto;
				string codiceconto_ivaimmediata;
				string codiceconto_ivadifferita;
				string codiceconto_ivaindetraibile;

				string codiceconto_intra_ivaimmediata;
				string codiceconto_intra_ivadifferita;
				string codiceconto_intra_ivaindetraibile;

				string codiceconto_split_ivaimmediata;
				string codiceconto_split_ivadifferita;
				string codiceconto_split_ivaindetraibile;

				codtipofattura = Reader.getCurrField("codtipofattura").ToString();

				object idinvkind = CheckExistsInvoiceKind(InvoiceKind, codtipofattura);

				if ((idinvkind == DBNull.Value) || (idinvkind == null)) {
					Reader.GetNext();
					continue;
				}


				DataRow invoicekindyear;
				string searchconto;
				object idacc;
				// nuovo tipo registro iva
				invoicekindyear = MetaInvoiceKindYear.Get_New_Row(null, D.Tables["invoicekindyear"]);

				invoicekindyear["idinvkind"] = idinvkind;
				anno = Reader.getCurrField("anno").ToString();
				invoicekindyear["ayear"] = anno;

				codiceconto_sconto = Reader.getCurrField("codiceconto_sconto").ToString();
				if (codiceconto_sconto != "") {
					searchconto = getSqlFilterAcc(codiceconto_sconto, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_sconto + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_discount"] = idacc;
				}

				codiceconto_ivaimmediata = Reader.getCurrField("codiceconto_ivaimmediata").ToString();

				if (codiceconto_ivaimmediata != "") {
					searchconto = getSqlFilterAcc(codiceconto_ivaimmediata, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_ivaimmediata + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc"] = idacc;
				}

				codiceconto_ivadifferita = Reader.getCurrField("codiceconto_ivadifferita").ToString();
				if (codiceconto_ivadifferita != "") {
					searchconto = getSqlFilterAcc(codiceconto_ivaimmediata, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_ivadifferita + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_deferred"] = idacc;
				}

				codiceconto_ivaindetraibile = Reader.getCurrField("codiceconto_ivaindetraibile").ToString();
				if (codiceconto_ivaindetraibile != "") {
					searchconto = getSqlFilterAcc(codiceconto_ivaindetraibile, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_ivaindetraibile + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_unabatable"] = idacc;
				}

				codiceconto_intra_ivaimmediata = Reader.getCurrField("codiceconto_intra_ivaimmediata").ToString();

				if (codiceconto_intra_ivaimmediata != "") {
					searchconto = getSqlFilterAcc(codiceconto_intra_ivaimmediata, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_intra_ivaimmediata + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_intra"] = idacc;
				}

				codiceconto_intra_ivadifferita = Reader.getCurrField("codiceconto_intra_ivadifferita").ToString();
				if (codiceconto_intra_ivadifferita != "") {
					searchconto = getSqlFilterAcc(codiceconto_intra_ivadifferita, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_intra_ivadifferita + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_deferred_intra"] = idacc;
				}

				codiceconto_intra_ivaindetraibile = Reader.getCurrField("codiceconto_intra_ivaindetraibile").ToString();
				if (codiceconto_intra_ivaindetraibile != "") {
					searchconto = getSqlFilterAcc(codiceconto_intra_ivaindetraibile, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_intra_ivaindetraibile + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_unabatable_intra"] = idacc;
				}

				codiceconto_split_ivaimmediata = Reader.getCurrField("codiceconto_split_ivaimmediata").ToString();
				if (codiceconto_split_ivaimmediata != "") {
					searchconto = getSqlFilterAcc(codiceconto_split_ivaimmediata, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_split_ivaimmediata + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_split"] = idacc;
				}

				codiceconto_split_ivadifferita = Reader.getCurrField("codiceconto_split_ivadifferita").ToString();
				if (codiceconto_split_ivadifferita != "") {
					searchconto = getSqlFilterAcc(codiceconto_split_ivadifferita, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_split_ivadifferita + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_deferred_split"] = idacc;
				}

				codiceconto_split_ivaindetraibile = Reader.getCurrField("codiceconto_split_ivaindetraibile").ToString();
				if (codiceconto_split_ivaindetraibile != "") {
					searchconto = getSqlFilterAcc(codiceconto_split_ivaindetraibile, anno);
					idacc = null;
					idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
					if (idacc == null || idacc == DBNull.Value) {
						SpeedSaver.AddError("Voce del piano dei conti " + codiceconto_split_ivaindetraibile + " del " +
						                    anno.ToString() +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invoicekindyear["idacc_unabatable_split"] = idacc;
				}

				invoicekindyear["ct"] = DateTime.Now;
				invoicekindyear["lt"] = DateTime.Now;
				invoicekindyear["cu"] = "importazione";
				invoicekindyear["lu"] = "importazione";
				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}



		private bool ImportaTipoRegistroIva() {
			//--"codtiporegistroiva; Codice Tipo Registro IVA;Stringa;20", 
			//--"descrtiporegistroiva;Descrizione Tipo Registro IVA;Stringa;50",
			//--"tipoprotocollo;Acquisto/Vendita/Protocollo Generale(A/V/P);Codificato;1;A|V|P",
			//--"attivita;Tipo Attività 1 Istituzionale / 2 Commerciale / 3 Promiscua / 4 Qualsiasi;Codificato;1;1|2|3|4",
			//--"registrocorrispettivi;Compensazione(S/N);Codificato;1;S|N",
			//--"codicecass;Codice Cassiere collegato;Stringa;20", 

			LeggiFile Reader = GetReader(tracciato_tiporegistroiva);
			if (Reader == null) return false;
			DataSet D = new vistaTipoRegistroIva();
			ClearAllNonDBOHash();
			MetaData MetaIvaRegisterKind = Meta.Dispatcher.Get("ivaregisterkind");
			MetaIvaRegisterKind.SetDefaults(D.Tables["ivaregisterkind"]);
			DataTable IvaRegisterKind = D.Tables["ivaregisterkind"];
			Conn.RUN_SELECT_INTO_TABLE(IvaRegisterKind, null, null, null, false);

			DataTable Treasurer = D.Tables["treasurer"];
			Conn.RUN_SELECT_INTO_TABLE(Treasurer, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("ivaregisterkind");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				string codtiporegistroiva;
				string descrtiporegistroiva;
				string tipoprotocollo;
				object attivita;
				string registrocorrispettivi;
				string codicecass;

				codtiporegistroiva = Reader.getCurrField("codtiporegistroiva").ToString();

				object idivaregisterkind = CheckExistsIvaRegisterKind(IvaRegisterKind, codtiporegistroiva);

				if ((idivaregisterkind != DBNull.Value) && (idivaregisterkind != null)) {

					SpeedSaver.AddError("Tipo Registro Iva " + codtiporegistroiva +
					                    " già trovato alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow ivaregisterkind;

				// nuovo tipo registro iva
				ivaregisterkind = MetaIvaRegisterKind.Get_New_Row(null, D.Tables["ivaregisterkind"]);

				ivaregisterkind["codeivaregisterkind"] = codtiporegistroiva;
				descrtiporegistroiva = Reader.getCurrField("descrtiporegistroiva").ToString();
				ivaregisterkind["description"] = descrtiporegistroiva;

				tipoprotocollo = Reader.getCurrField("tipoprotocollo").ToString();
				ivaregisterkind["registerclass"] = tipoprotocollo;

				attivita = Reader.getCurrField("attivita");
				ivaregisterkind["flagactivity"] = attivita;

				registrocorrispettivi = Reader.getCurrField("registrocorrispettivi").ToString();
				ivaregisterkind["compensation"] = registrocorrispettivi;

				codicecass = Reader.getCurrField("codicecass").ToString();
				object idtreasurer = DBNull.Value;
				if (codicecass != "") idtreasurer = CheckExistsTreasurer(Treasurer, codicecass);

				if (idtreasurer == null) idtreasurer = DBNull.Value;

				ivaregisterkind["idtreasurer"] = idtreasurer;

				ivaregisterkind["ct"] = DateTime.Now;
				ivaregisterkind["lt"] = DateTime.Now;
				ivaregisterkind["cu"] = "importazione";
				ivaregisterkind["lu"] = "importazione";
				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		private bool ImportaTipoDocIvaRegistroIva() {
			//"codtipofattura; Codice Tipo Fattura;Stringa;20", 
			//"codtiporegistroiva; Codice Tipo Registro IVA;Stringa;20"   

			LeggiFile Reader = GetReader(tracciato_tipodocivaregistroiva);
			if (Reader == null) return false;
			DataSet D = new vistaTipoDocIvaRegistroIva();
			ClearAllNonDBOHash();
			MetaData MetaInvoicekindRegisterKind = Meta.Dispatcher.Get("invoicekindregisterkind");
			MetaInvoicekindRegisterKind.SetDefaults(D.Tables["ivaregisterkind"]);
			DataTable InvoicekindRegisterKind = D.Tables["invoicekindregisterkind"];
			Conn.RUN_SELECT_INTO_TABLE(InvoicekindRegisterKind, null, null, null, false);

			DataTable InvoiceKind = D.Tables["invoicekind"];
			Conn.RUN_SELECT_INTO_TABLE(InvoiceKind, null, null, null, false);

			DataTable IvaRegisterKind = D.Tables["ivaregisterkind"];
			Conn.RUN_SELECT_INTO_TABLE(IvaRegisterKind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("invoicekindregisterkind");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				string codtipofattura;
				string codtiporegistroiva;

				codtipofattura = Reader.getCurrField("codtipofattura").ToString();
				object idinvoicekind = CheckExistsInvoiceKind(InvoiceKind, codtipofattura);

				if ((idinvoicekind == DBNull.Value) || (idinvoicekind == null)) {
					SpeedSaver.AddError("Tipo Documento IVA " + codtipofattura.ToString() +
					                    " inesistente alla riga " + Reader.GetCurrRowNumber());

					Reader.GetNext();
					continue;
				}

				codtiporegistroiva = Reader.getCurrField("codtiporegistroiva").ToString();
				object idivaregisterkind = CheckExistsIvaRegisterKind(IvaRegisterKind, codtiporegistroiva);
				if ((idivaregisterkind == DBNull.Value) || (idivaregisterkind == null)) {
					SpeedSaver.AddError("Tipo Registro IVA " + codtiporegistroiva.ToString() +
					                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				DataRow invoicekindregisterkind;

				// nuovo tipo registro iva
				invoicekindregisterkind = MetaInvoicekindRegisterKind.Get_New_Row(null,
					D.Tables["invoicekindregisterkind"]);
				invoicekindregisterkind["idinvkind"] = idinvoicekind;
				invoicekindregisterkind["idivaregisterkind"] = idivaregisterkind;

				invoicekindregisterkind["ct"] = DateTime.Now;
				invoicekindregisterkind["lt"] = DateTime.Now;
				invoicekindregisterkind["cu"] = "importazione";
				invoicekindregisterkind["lu"] = "importazione";
				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		private bool ImportaRegistroIva() {
			//"annoregistrazione;Anno Registrazione;Intero;4", 							
			//"numregistrazione;Numero Registrazione;Intero;8", 
			//"codtipofattura; Codice Tipo Fattura;Stringa;20", 
			//"codtiporegistroiva; Codice Tipo Registro IVA;Stringa;20", 
			//"annofattura;Anno;Intero;4", 							
			//"numfattura;Numero Fattura;Intero;8", 	 
			//"numprotocollo;Numero Protocollo;Intero;8"   

			LeggiFile Reader = GetReader(tracciato_registroiva);
			if (Reader == null) return false;
			DataSet D = new vistaRegistroIva();
			ClearAllNonDBOHash();
			MetaData MetaIvaRegister = Meta.Dispatcher.Get("ivaregister");
			MetaIvaRegister.SetDefaults(D.Tables["ivaregister"]);
			DataTable IvaRegister = D.Tables["ivaregister"];
			Conn.RUN_SELECT_INTO_TABLE(IvaRegister, null, null, null, false);

			DataTable Invoice = D.Tables["invoice"];
			Conn.RUN_SELECT_INTO_TABLE(Invoice, null, null, null, false);

			DataTable IvaRegisterKind = D.Tables["ivaregisterkind"];
			Conn.RUN_SELECT_INTO_TABLE(IvaRegisterKind, null, null, null, false);

			DataTable Invoicekind = D.Tables["invoicekind"];
			Conn.RUN_SELECT_INTO_TABLE(Invoicekind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("ivaregister");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			int N = 0;
			while (Reader.DataPresent()) {
				N++;
				string codtipofattura;
				string codtiporegistroiva;

				codtipofattura = Reader.getCurrField("codtipofattura").ToString();
				object idinvoicekind = CheckExistsInvoiceKind(Invoicekind, codtipofattura);

				if ((idinvoicekind == DBNull.Value) || (idinvoicekind == null)) {
					// Tipo Documento Iva  non trovato

					SpeedSaver.AddError("Tipo Documento Iva " + codtipofattura +
					                    " non trovato alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				codtiporegistroiva = Reader.getCurrField("codtiporegistroiva").ToString();
				object idivaregisterkind = CheckExistsIvaRegisterKind(IvaRegisterKind, codtiporegistroiva);
				if ((idivaregisterkind == DBNull.Value) || (idivaregisterkind == null)) {
					// Tipo Registro Iva  non trovato

					SpeedSaver.AddError("Tipo Registro Iva " + codtiporegistroiva +
					                    " non trovato alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				// Costruisci il filtro utilizzando l'ninv proveniente dal file
				object annofattura;
				object numerofattura;

				annofattura = Reader.getCurrField("annofattura");
				numerofattura = Reader.getCurrField("numfattura");
				//"numfattura;Numero Fattura;Intero;8", 

				string invoicefilter = QHC.AppAnd(QHC.CmpEq("idinvkind", idinvoicekind),
					QHC.CmpEq("yinv", annofattura), QHC.CmpEq("ninv", numerofattura));
				DataRow[] InvoiceFound = Invoice.Select(invoicefilter);
				if (InvoiceFound.Length == 0) {
					// Fattura non trovata
					SpeedSaver.AddError("Fattura " + codtipofattura +
					                    " anno" + annofattura.ToString() + "num." + numerofattura +
					                    " non trovato alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					Reader.GetNext();
					continue;
				}

				DataRow ivaregister;

				// nuova registrazione iva
				ivaregister = MetaIvaRegister.Get_New_Row(null, D.Tables["ivaregister"]);

				int annoregistrazione;
				int numregistrazione;
				int numeroprotocollo;

				annoregistrazione = Convert.ToInt32(Reader.getCurrField("annoregistrazione"));
				numregistrazione = Convert.ToInt32(Reader.getCurrField("numregistrazione"));
				numeroprotocollo = Convert.ToInt32(Reader.getCurrField("numprotocollo"));

				ivaregister["yivaregister"] = annoregistrazione;
				ivaregister["nivaregister"] = numregistrazione;
				ivaregister["idinvkind"] = idinvoicekind;
				ivaregister["yinv"] = annofattura;
				ivaregister["ninv"] = numerofattura;
				ivaregister["protocolnum"] = numeroprotocollo;
				ivaregister["idivaregisterkind"] = idivaregisterkind;
				ivaregister["ct"] = DateTime.Now;
				ivaregister["lt"] = DateTime.Now;
				ivaregister["cu"] = "importazione";
				ivaregister["lu"] = "importazione";

				Reader.GetNext();
			}

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}


		// Tipi documento Fattura
		Hashtable hashInvoiceKind = null;

		void ResetHashInvoiceKind() {
			if (hashInvoiceKind != null) {
				hashInvoiceKind.Clear();
			}

			hashInvoiceKind = null;
		}

		object CheckInvoiceKind(DataTable InvoiceKind, string codeinvkind) {
			string codeinvreal = codeinvkind.ToUpper().Trim();
			if (hashInvoiceKind == null) {
				hashInvoiceKind = new Hashtable();
				foreach (DataRow RH in InvoiceKind.Rows) {
					hashInvoiceKind[RH["codeinvkind"].ToString().ToUpper().Trim()] = RH;
				}
			}

			DataRow RID = hashInvoiceKind[codeinvreal] as DataRow;
			;
			if (RID != null) {
				return RID["idinvkind"];
			}

			MetaData MetaInvoiceKind = Meta.Dispatcher.Get("invoicekind");
			MetaInvoiceKind.SetDefaults(InvoiceKind);
			DataRow NewInvoiceKind = MetaInvoiceKind.Get_New_Row(null, InvoiceKind);
			NewInvoiceKind["codeinvkind"] = codeinvkind;
			NewInvoiceKind["description"] = "Fattura - " + codeinvkind.ToString();
			NewInvoiceKind["active"] = 'S';
			NewInvoiceKind["ct"] = DateTime.Now;
			NewInvoiceKind["lt"] = DateTime.Now;
			NewInvoiceKind["cu"] = "importazione";
			NewInvoiceKind["lu"] = "importazione";
			hashInvoiceKind[codeinvreal] = NewInvoiceKind;
			return NewInvoiceKind["idinvkind"];
		}

		object CheckExistsInvoiceKind(DataTable InvoiceKind, string codeinvkind) {
			string codeinvreal = codeinvkind.ToUpper().Trim();
			if (hashInvoiceKind == null) {
				hashInvoiceKind = new Hashtable();
				foreach (DataRow RH in InvoiceKind.Rows) {
					hashInvoiceKind[RH["codeinvkind"].ToString().ToUpper().Trim()] = RH;
				}
			}

			DataRow RID = hashInvoiceKind[codeinvreal] as DataRow;
			;
			if (RID != null) {
				return RID["idinvkind"];
			}
			else return null;
		}




		// Tipi Registro IVA
		Hashtable hashIvaRegisterKind = null;

		void ResetHashIvaRegisterKind() {
			if (hashIvaRegisterKind != null) {
				hashIvaRegisterKind.Clear();
			}

			hashIvaRegisterKind = null;
		}

		object CheckExistsIvaRegisterKind(DataTable IvaRegisterKind, string codeivaregisterkind) {
			string codeivaregisterkindreal = codeivaregisterkind.ToUpper().Trim();
			if (hashIvaRegisterKind == null) {
				hashIvaRegisterKind = new Hashtable();
				foreach (DataRow RH in IvaRegisterKind.Rows) {
					hashIvaRegisterKind[RH["codeivaregisterkind"].ToString().ToUpper().Trim()] = RH;
				}
			}

			DataRow RID = hashIvaRegisterKind[codeivaregisterkindreal] as DataRow;
			;
			if (RID != null) {
				return RID["idivaregisterkind"];
			}
			else return null;
		}

		private void CheckUniqueRegister(DataTable UniqueRegister, object prog_registro_unico, DataRow Rinvoice) {
			if (prog_registro_unico == DBNull.Value)
				return;
			if (Conn.RUN_SELECT_COUNT("uniqueregister", QHS.CmpEq("iduniqueregister", prog_registro_unico), false) > 0)
				return;
			if (UniqueRegister.Select(QHC.CmpEq("iduniqueregister", prog_registro_unico)).Length > 0)
				return;
			DataRow rUR = UniqueRegister.NewRow();
			rUR["iduniqueregister"] = prog_registro_unico;
			rUR["yinv"] = Rinvoice["yinv"];
			rUR["ninv"] = Rinvoice["ninv"];
			rUR["idinvkind"] = Rinvoice["idinvkind"];
			rUR["ct"] = DateTime.Now;
			rUR["lt"] = DateTime.Now;
			rUR["cu"] = "importazione";
			rUR["lu"] = "importazione";
			UniqueRegister.Rows.Add(rUR);
		}

		private bool ImportaCreaFatture() {
			LeggiFile Reader = GetReader(tracciato_fatture);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaFatture();

			MetaData MetaInvoice = Meta.Dispatcher.Get("invoice");
			MetaInvoice.SetDefaults(D.Tables["invoice"]);

			MetaData MetaInvoiceDetail = Meta.Dispatcher.Get("invoicedetail");
			MetaInvoiceDetail.SetDefaults(D.Tables["invoicedetail"]);

			DataTable UniqueRegister = D.Tables["uniqueregister"];
			//Conn.RUN_SELECT_INTO_TABLE(UniqueRegister, null, null, null, false);

			DataTable InvKind = D.Tables["invoicekind"];
			MetaData MetaInvKind = Meta.Dispatcher.Get("invoicekind");
			Conn.RUN_SELECT_INTO_TABLE(InvKind, null, null, null, false);

			DataTable AccMotive = Conn.RUN_SELECT("accmotive", "*", null, null, null, false);


			GetSortCached.Init();
			int[] idsortingkind = new int[] {
				0, CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind2")),
				CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind3"))
			};

			// Associa ad ninv del file di input, un ninv REALE proveniente dal dataset
			// va utilizzato solo se FlgImportaFatture=false
			Hashtable InvoiceHT = new Hashtable();


			string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));

			// Creazione delle HashTables di Lookup

			// Lookup di INVOICEKIND (codtipofattura)
			//DataTable InvKindTbl = Conn.RUN_SELECT("invoicekind", "*", null, null, null, false);
			//Hashtable InvKind = new Hashtable();
			//foreach (DataRow InvKindRow in InvKindTbl.Select()) InvKind[InvKindRow["codeinvkind"]] = InvKindRow["idinvkind"];

			// Lookup di TREASURER (Codice Cassiere per incasso)
			DataTable TreasurerTbl = Conn.RUN_SELECT("treasurer", "*", null, null, null, false);
			Hashtable Treasurer = new Hashtable();
			foreach (DataRow TreasurerRow in TreasurerTbl.Select())
				Treasurer[TreasurerRow["codetreasurer"]] = TreasurerRow["idtreasurer"];

			// Lookup di Currency
			DataTable Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
			Hashtable Hcur = new Hashtable();
			foreach (DataRow RCC in Currency.Select())
				Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

			// Lookup di IvaKind
			DataTable IvaKind = Conn.RUN_SELECT("ivakind", "*", null, null, null, false);
			Hashtable HIva = new Hashtable();
			foreach (DataRow IvaKRow in IvaKind.Select()) {
				HIva[IvaKRow["codeivakind"].ToString().ToUpper().Trim()] = IvaKRow["idivakind"];
			}

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}


			//// Lookup di Classificazione Analitica 1, Sara
			//int idsortingkind1 = CfgFn.GetNoNullInt32(Meta.GetSys("idsortingkind1"));
			//string filterSort1 = QHS.CmpEq("idsorkind", idsortingkind1);
			//DataTable Sort1 = Conn.RUN_SELECT("sorting", "*", null, filterSort1, null, false);
			//Hashtable HSort1 = new Hashtable();
			//foreach (DataRow Sort1Row in Sort1.Select()) HSort1[Sort1Row["sortcode"]] = Sort1Row["idsor"];

			DataTable ExpirationKind = Conn.RUN_SELECT("expirationkind", "*", null, null, null, false);
			Hashtable HExpK = new Hashtable();
			foreach (DataRow ExpKRow in ExpirationKind.Select())
				HExpK[ExpKRow["shorttitle"]] = ExpKRow["idexpirationkind"];

			List<string> tosync = new List<string>();
			tosync.Add("registry");
			tosync.Add("invoicekind");
			tosync.Add("uniqueregister");
			InitSpeedSaver(Conn, tosync);

			// Secondo loop, importazione propriamente detta
			Reader.Reset();

			Reader.GetNext();
			string lastfilter = "";

			bool err;
			int N = 0;
			while (Reader.DataPresent() && SpeedSaver.countMessages() < 1000) {
				N++;
				object codtipofattura = null;
				object annofattura;
				object numfattura;

				string codice_tipofattura = Reader.getCurrField("codtipofattura").ToString();
				if (codice_tipofattura == "") {
					SpeedSaver.AddError(
						$"Attenzione codice tipo fattura non trovato per la fattura  - Riga:{Reader.GetCurrRowNumber()}");
					Reader.GetNext();
					continue;
				}

				codtipofattura = CheckInvoiceKind(InvKind, codice_tipofattura);


				//if (InvKind[Reader.getCurrField("codtipofattura")] != null) {
				//    codtipofattura = InvKind[Reader.getCurrField("codtipofattura")];
				//}
				//else {
				//    SpeedSaver.AddError("Codice Tipo Fattura " + Reader.getCurrField("codtipofattura") + " non trovato alla linea "
				//        + Reader.GetCurrRowNumber());
				//    Reader.GetNext();
				//    continue;
				//}
				annofattura = Reader.getCurrField("annofattura");
				numfattura = Reader.getCurrField("numfattura");

				if (annofattura == DBNull.Value) {
					SpeedSaver.AddError(
						$"Attenzione anno fattura non trovato per la fattura  numero:{numfattura} e codice:{codice_tipofattura} - Riga:{Reader.GetCurrRowNumber()}");
					Reader.GetNext();
					continue;
				}
				// Se FlgImportaFatture=true, allora va disabilitata la generazione automatica di ninv
				// e NON si utilizza la HashTable, altrimenti si!

				// INOLTRE, se FlgImportaFatture=true, poichè come ninv viene utilizzato quello del file di input
				// devo PRIMA controllare che sul DB non esista una fattura con la stessa terna
				// ninv + yinv + codtipofattura

				//Controlla in memoria se esiste una fattura con questa chiave alternativa
				//Utilizzare però la hashtable!s
				string newfilter = QHS.AppAnd(QHS.CmpEq("ninv", numfattura), QHS.CmpEq("yinv", annofattura),
					QHS.CmpEq("codeinvkind", codice_tipofattura));
				if (N > 1000 && lastfilter != newfilter) {
					if (!SaveData(D, false)) break;

					N = 0;
					D.Tables["invoice"].Clear();
					D.Tables["invoicedetail"].Clear();
					D.Tables["expenseinvoice"].Clear();
					D.Tables["incomeinvoice"].Clear();
					InvoiceHT = new Hashtable();
					codtipofattura = CheckInvoiceKind(InvKind, codice_tipofattura);
				}

				lastfilter = newfilter;


				DataRow[] InvoiceFound = null;
				string invoicefilter = "";

				if (FlgImportaFatture) {
					// Controlliamo PRIMA se esiste già una fattura con la terna ninv+yinv+codfattura
					string invoicedbfilter = "";
					invoicedbfilter = QHS.AppAnd(QHS.CmpEq("ninv", numfattura), QHS.CmpEq("yinv", annofattura),
						QHS.CmpEq("codeinvkind", codice_tipofattura));
					int numFatt = Conn.RUN_SELECT_COUNT("invoiceview", invoicedbfilter, false);
					if (numFatt > 0) {
						// Errore! Nel DB è già presente una fattura con la terna indicata!
						SpeedSaver.AddError("Attenzione. E' già presente una fattura avente Anno:" +
						                    annofattura.ToString() +
						                    " numero:" + numfattura.ToString() + " e codice:" + codice_tipofattura
						                    + " - Riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					// Costruisci il filtro utilizzando l'ninv proveniente dal file
					invoicefilter = QHC.AppAnd(QHC.CmpEq("idinvkind", codtipofattura), QHC.CmpEq("yinv", annofattura),
						QHC.CmpEq("ninv", numfattura));
					InvoiceFound = D.Tables["invoice"].Select(invoicefilter);
				}
				else {
					// Costruisci il filtro utilizzando la HashTable InvoiceHT per interpretare l'ninv
					if (InvoiceHT[numfattura] != null) {
						invoicefilter = QHC.AppAnd(QHC.CmpEq("idinvkind", codtipofattura),
							QHC.CmpEq("yinv", annofattura),
							QHC.CmpEq("ninv", InvoiceHT[numfattura]));
						InvoiceFound = D.Tables["invoice"].Select(invoicefilter);
					}

				}



				DataRow invc;
				DataRow invcdetail;

				if (InvoiceFound == null || InvoiceFound.Length == 0) {
					// nuova fattura


					// Forse va disabilitato l'autoincremento, altrimenti viene inserita più volte una testata...
					if (FlgImportaFatture) {
						//RowChange.ClearAutoIncrement(D.Tables["invoice"].Columns["ninv"]);
						//RowChange.ClearCustomAutoIncrement(D.Tables["invoice"].Columns["ninv"]);
						invc = D.Tables["invoice"].NewRow();
						invc["idinvkind"] = codtipofattura;
						invc["yinv"] = annofattura;
						invc["ninv"] = numfattura;
						D.Tables["invoice"].Rows.Add(invc);
					}
					else {
						MetaData.SetDefault(D.Tables["invoice"], "yinv", annofattura);
						MetaData.SetDefault(D.Tables["invoice"], "idinvkind", codtipofattura);
						invc = MetaInvoice.Get_New_Row(null, D.Tables["invoice"]);
						//invc["idinvkind"] = codtipofattura;
						//invc["yinv"] = annofattura;
						InvoiceHT[numfattura] = invc["ninv"];

					}




					object idreg_found = Reader.getCurrField("idreg");

					if (idreg_found != DBNull.Value) {
						invc["idreg"] = idreg_found;
						object idreg_check = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg_found), "idreg");
						if (idreg_check == null || idreg_check == DBNull.Value) {
							SpeedSaver.AddError("Attenzione anagrafica di codice :" + idreg_found.ToString() +
							                    " non trovata per la fattura " + annofattura.ToString() +
							                    " numero:" + numfattura.ToString() + " e codice:" + codice_tipofattura
							                    + " - Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						string chkexists = "";
						if (idreg_found == null) idreg_found = DBNull.Value;

						if (idreg_found == DBNull.Value) {
							if (Reader.getCurrField("p_iva") != DBNull.Value) {
								chkexists = QHS.CmpEq("p_iva", Reader.getCurrField("p_iva"));
								idreg_found = Conn.DO_READ_VALUE("registry", chkexists, "idreg");
								if (idreg_found == null) idreg_found = DBNull.Value;
							}
						}

						if (idreg_found == DBNull.Value) {
							if (Reader.getCurrField("cf") != DBNull.Value) {
								chkexists = QHS.CmpEq("cf", Reader.getCurrField("cf"));
								idreg_found = Conn.DO_READ_VALUE("registry", chkexists, "idreg");
								if (idreg_found == null) idreg_found = DBNull.Value;
							}
						}

						invc["idreg"] = idreg_found;
					}



					//Dove vanno questi campi?
					//invc["acquistovendita"] = Reader.getCurrField("acquistovendita");
					//invc["notacredito"] = Reader.getCurrField("notacredito");


					object descr = Reader.getCurrField("descrfattura");
					if (descr == DBNull.Value) descr = ".";
					invc["description"] = descr;
					/* Stando al tracciato non va fatta nessuna transcodifica
					if (HExpK[Reader.getCurrField("codexpirationkind")] != null)
					    invc["idexpirationkind"] = Reader.getCurrField("codexpirationkind"); // Altra transcodifica da fare
					else
					{
					    MessageBox.Show("Codice Tipo scadenza " + Reader.getCurrField("codexpirationkind") + " inesistente alla linea " + RowIndex.ToString());
					    some_error = true;

					}

					
					*/

					invc["idexpirationkind"] = Reader.getCurrField("codexpirationkind");
					// E' sbagliata nel tracciato? Int16, NON DATA
					invc["paymentexpiring"] = Reader.getCurrField("paymentexpiring");


					invc["packinglistdate"] = ToSmalldateTime(Reader.getCurrField("datadoctrasporto"));
					invc["packinglistnum"] = Reader.getCurrField("numdoctrasporto");

					// Se non è specificato nel file di input si può mettere a DBNull.Value
					// se è specificato, ma non ha corrispondenza nella Hashtable, dev'essere notificato
					if (Reader.getCurrField("codicecass") == DBNull.Value || Reader.getCurrField("codicecass") == null)
						invc["idtreasurer"] = DBNull.Value;
					else {
						if (Treasurer[Reader.getCurrField("codicecass")] == null) {
							SpeedSaver.AddError("Codice Cassiere: " + Reader.getCurrField("codicecass").ToString() +
							                    " non trovato alla riga "
							                    + Reader.GetCurrRowNumber() + " del file di input.");
							Reader.GetNext();
							continue;
						}
						else
							invc["idtreasurer"] = Treasurer[Reader.getCurrField("codicecass")];
					}

					// Lo stesso vale per l'idcurrency
					if (Reader.getCurrField("valuta_fatt") == DBNull.Value ||
					    Reader.getCurrField("valuta_fatt") == null)
						invc["idcurrency"] = DBNull.Value;
					else {
						if (Hcur[Reader.getCurrField("valuta_fatt")] == null) {
							SpeedSaver.AddError("Codice valuta: " + Reader.getCurrField("valuta_fatt").ToString()
							                                      + " non trovato alla riga " +
							                                      Reader.GetCurrRowNumber()
							                                      + " del file di input.");

						}
						else
							invc["idcurrency"] = Hcur[Reader.getCurrField("valuta_fatt")];
					}


					invc["exchangerate"] = Reader.getCurrField("tassocambio_fatt");
					invc["doc"] = Reader.getCurrField("doc");
					invc["docdate"] = ToSmalldateTime(Reader.getCurrField("datadoc"));
					invc["adate"] = ToSmalldateTime(Reader.getCurrField("datafatt"));
					invc["flagdeferred"] = Reader.getCurrField("ivadifferita");
					invc["active"] = Reader.getCurrField("attivo");
					invc["flagintracom"] = Reader.getCurrField("flagintracom");
					invc["txt"] = Reader.getCurrField("note_fatt");

					object prog_registro_unico = Reader.getCurrField("prog_registro_unico");
					CheckUniqueRegister(UniqueRegister, prog_registro_unico, invc);

					invc["arrivalprotocolnum"] = Reader.getCurrField("numero_protocollo_entrata");
					invc["protocoldate"] = ToSmalldateTime(Reader.getCurrField("dataricezione"));
					//Verifica la presenza delle classificazioni
					for (int nsor = 1; nsor <= 5; nsor++) {
						invc["idsor0" + nsor.ToString()] = GetSortCached.GetSortK(Conn,
							Reader.getCurrField("codtipoclass0" + nsor.ToString()).ToString(),
							Reader.getCurrField("codclass0" + nsor.ToString()).ToString(),
							out err);
						if (err) {
							SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
							                    " di codice " + Reader.getCurrField("codclass0" + nsor.ToString()) +
							                    " inesistente alla riga " + Reader.GetCurrRowNumber());
						}
					}

					invc["flag_enable_split_payment"] = Reader.getCurrField("split_payment");
					invc["idaccmotivedebit"] = CheckAccMotive(AccMotive, Reader.getCurrField("causaledebito"));

				}
				else {
					invc = InvoiceFound[0];
				}



				if (FlgImportaFatture) {
					//RowChange.ClearAutoIncrement(D.Tables["invoicedetail"].Columns["rownum"]);
					var rownum = Reader.getCurrField("nriga_fatt");
					if (rownum == null || rownum == DBNull.Value) {
						SpeedSaver.AddError("Numero dettaglio mancante alla riga " + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					invcdetail = D.Tables["invoicedetail"].NewRow();
					invcdetail["idinvkind"] = codtipofattura;
					invcdetail["yinv"] = annofattura;
					invcdetail["ninv"] = numfattura;
					invcdetail["rownum"] = Reader.getCurrField("nriga_fatt");
					D.Tables["invoicedetail"].Rows.Add(invcdetail);
				}
				else {
					invcdetail = MetaInvoiceDetail.Get_New_Row(invc, D.Tables["invoicedetail"]);
				}

				// Legge i campi del dettaglio fattura
				invcdetail["detaildescription"] = Reader.getCurrField("descrdettaglio");
				object codtipoiva = Reader.getCurrField("codtipoiva").ToString().ToUpper().Trim();
				if (HIva[codtipoiva] != null)
					invcdetail["idivakind"] = HIva[codtipoiva];
				else {
					SpeedSaver.AddError(
						"Tipo iva " + codtipoiva + " inesistente alla riga " + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				invcdetail["tax"] = Reader.getCurrField("iva");
				invcdetail["unabatable"] = Reader.getCurrField("ivaindetr");
				invcdetail["number"] = Reader.getCurrField("quantita");
				invcdetail["npackage"] = Reader.getCurrField("quantita");
				invcdetail["taxable"] = Reader.getCurrField("impon");
				invcdetail["discount"] = Reader.getCurrField("scontoperc");
				invcdetail["annotations"] = Reader.getCurrField("annotazioni");

				invcdetail["cigcode"] = Reader.getCurrField("cigcode");
				invcdetail["cupcode"] = Reader.getCurrField("cupcode");
				invcdetail["idpccdebitstatus"] = Reader.getCurrField("stato_debito");
				invcdetail["expensekind"] = Reader.getCurrField("natura_spesa");

				if (Reader.getCurrField("idgroup") == DBNull.Value) {
					invcdetail["idgroup"] = Reader.getCurrField("nriga_fatt");
				}
				else {
					invcdetail["idgroup"] = Reader.getCurrField("idgroup");
				}

				object codtipofatturamain = DBNull.Value;
				if (Reader.getCurrField("codtipofatturaprinc") != DBNull.Value) {
					string codice_tipofatturaMain = Reader.getCurrField("codtipofatturaprinc").ToString();
					codtipofatturamain = CheckInvoiceKind(InvKind, codice_tipofatturaMain);
				}

				invcdetail["idinvkind_main"] = codtipofatturamain;
				invcdetail["yinv_main"] = Reader.getCurrField("annofatturaprinc");
				invcdetail["ninv_main"] = Reader.getCurrField("numfatturaprinc");

				for (int nsor = 1; nsor <= 3; nsor++) {
					invcdetail["idsor" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
						idsortingkind[nsor],
						Reader.getCurrField("codclassanal" + nsor.ToString()).ToString(),
						out err);
					if (err) {
						SpeedSaver.AddError("Codice Classificazione Analitica n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclassanal" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				string searchupb = QHC.CmpEq("codeupb", codeupb);
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (!HUpb.ContainsKey(codeupb)) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:"
						                    + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					idupb = HUpb[codeupb];
				}

				invcdetail["idupb"] = idupb;

				invcdetail["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causale"));

				object nfasespesa = Reader.getCurrField("nfasespesa");
				object esercmovspesacontimpon = Reader.getCurrField("esercmovspesacontimpon");
				object nummovspesacontimpon = Reader.getCurrField("nummovspesacontimpon");
				object esercmovspesacontiva = Reader.getCurrField("esercmovspesacontiva");
				object nummovspesacontiva = Reader.getCurrField("nummovspesacontiva");

				if (nummovspesacontimpon != DBNull.Value) {
					string FiltroSpesaImpon = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesacontimpon),
						QHS.CmpEq("nmov", nummovspesacontimpon), QHS.CmpEq("nphase", nfasespesa));
					object idSpesaImpon = Conn.DO_READ_VALUE("expense", FiltroSpesaImpon, "idexp");
					if (idSpesaImpon == null || idSpesaImpon == DBNull.Value) {
						string movSpesaImpon = "Movimento di spesa di fase " + nfasespesa.ToString() + " num. " +
						                       nummovspesacontimpon.ToString() + " del " +
						                       esercmovspesacontimpon.ToString();
						SpeedSaver.AddError("Movimento non trovato: " + movSpesaImpon
						                                              + " alla riga " + Reader.GetCurrRowNumber());
					}
					else {
						invcdetail["idexp_taxable"] = idSpesaImpon;
					}
				}

				if (nummovspesacontiva != DBNull.Value) {
					string FiltroSpesaIVA = QHS.AppAnd(QHS.CmpEq("ymov", esercmovspesacontiva),
						QHS.CmpEq("nmov", nummovspesacontiva), QHS.CmpEq("nphase", nfasespesa));
					object idSpesaIVA = Conn.DO_READ_VALUE("expense", FiltroSpesaIVA, "idexp");
					if (idSpesaIVA == null || idSpesaIVA == DBNull.Value) {
						string movSpesaIVA = "Movimento di spesa di fase " + nfasespesa.ToString() + " num. " +
						                     nummovspesacontiva.ToString() + " del " +
						                     esercmovspesacontiva.ToString();
						SpeedSaver.AddError("Movimento  non trovato: " + movSpesaIVA
						                                               + " alla riga " + Reader.GetCurrRowNumber());
					}
					else {
						invcdetail["idexp_iva"] = idSpesaIVA;
					}
				}

				int movkind = 0;
				object idexptosearch = DBNull.Value;
				if (invcdetail["idexp_taxable"] != DBNull.Value && invcdetail["idexp_iva"] != DBNull.Value) {
					movkind = 1;
					idexptosearch = invcdetail["idexp_taxable"];
				}

				if (invcdetail["idexp_taxable"] != DBNull.Value && invcdetail["idexp_iva"] == DBNull.Value) {
					movkind = 3;
					idexptosearch = invcdetail["idexp_taxable"];
				}

				if (invcdetail["idexp_taxable"] == DBNull.Value && invcdetail["idexp_iva"] != DBNull.Value) {
					movkind = 2;
					idexptosearch = invcdetail["idexp_iva"];
				}

				if (idexptosearch != DBNull.Value) {
					int nexpinv = Conn.RUN_SELECT_COUNT("expenseinvoice", QHS.CmpEq("idexp", idexptosearch), false);
					if (nexpinv == 0)
						nexpinv = D.Tables["expenseinvoice"].Select(QHC.CmpEq("idexp", idexptosearch)).Length;
					if (nexpinv == 0) {
						DataRow RExpInv = D.Tables["expenseinvoice"].NewRow();
						RExpInv["idexp"] = idexptosearch;
						RExpInv["movkind"] = movkind;
						foreach (string ff in new string[] {"idinvkind", "yinv", "ninv"}) RExpInv[ff] = invcdetail[ff];
						RExpInv["ct"] = DateTime.Now;
						RExpInv["lt"] = DateTime.Now;
						RExpInv["cu"] = "importazione";
						RExpInv["lu"] = "importazione";
						D.Tables["expenseinvoice"].Rows.Add(RExpInv);
					}
				}


				object nfaseentrata = Reader.getCurrField("nfaseentrata");
				object esercmoventratacontimpon = Reader.getCurrField("esercmoventratacontimpon");
				object nummoventratacontimpon = Reader.getCurrField("nummoventratacontimpon");
				object esercmoventratacontiva = Reader.getCurrField("esercmoventratacontiva");
				object nummoventratacontiva = Reader.getCurrField("nummoventratacontiva");


				if (nummoventratacontimpon != DBNull.Value) {
					string FiltroEntrataImpon = QHS.AppAnd(QHS.CmpEq("ymov", esercmoventratacontimpon),
						QHS.CmpEq("nmov", nummoventratacontimpon), QHS.CmpEq("nphase", nfaseentrata));
					object idEntrataImpon = Conn.DO_READ_VALUE("income", FiltroEntrataImpon, "idinc");
					if (idEntrataImpon == null || idEntrataImpon == DBNull.Value) {
						string movEntrataImpon = "Movimento di entrata di fase " + nfaseentrata.ToString() + " num. " +
						                         nummoventratacontimpon.ToString() + " del " +
						                         esercmoventratacontimpon.ToString();
						SpeedSaver.AddError("Movimento non trovato: " + movEntrataImpon
						                                              + " alla riga " + Reader.GetCurrRowNumber());
					}
					else {
						invcdetail["idinc_taxable"] = idEntrataImpon;
					}
				}

				if (nummoventratacontiva != DBNull.Value) {
					string FiltroEntrataIVA = QHS.AppAnd(QHS.CmpEq("ymov", esercmoventratacontiva),
						QHS.CmpEq("nmov", nummoventratacontiva), QHS.CmpEq("nphase", nfaseentrata));
					object idEntrataIVA = Conn.DO_READ_VALUE("income", FiltroEntrataIVA, "idinc");
					if (idEntrataIVA == null || idEntrataIVA == DBNull.Value) {
						string movEntrataIVA = "Movimento di entrata di fase " + nfaseentrata.ToString() + " num. " +
						                       nummoventratacontiva.ToString() + " del " +
						                       esercmoventratacontiva.ToString();
						SpeedSaver.AddError("Movimento  non trovato: " + movEntrataIVA
						                                               + " alla riga " + Reader.GetCurrRowNumber());
					}
					else {
						invcdetail["idinc_iva"] = idEntrataIVA;
					}
				}

				object idinctosearch = DBNull.Value;
				movkind = 0;
				if (invcdetail["idinc_taxable"] != DBNull.Value && invcdetail["idinc_iva"] != DBNull.Value) {
					movkind = 1;
					idinctosearch = invcdetail["idinc_taxable"];
				}

				if (invcdetail["idinc_taxable"] != DBNull.Value && invcdetail["idinc_iva"] == DBNull.Value) {
					movkind = 3;
					idinctosearch = invcdetail["idinc_taxable"];
				}

				if (invcdetail["idinc_taxable"] == DBNull.Value && invcdetail["idinc_iva"] != DBNull.Value) {
					movkind = 2;
					idinctosearch = invcdetail["idinc_iva"];
				}

				if (idinctosearch != DBNull.Value) {
					int nincinv = Conn.RUN_SELECT_COUNT("incomeinvoice", QHS.CmpEq("idinc", idinctosearch), false);
					if (nincinv == 0)
						nincinv = D.Tables["incomeinvoice"].Select(QHC.CmpEq("idinc", idinctosearch)).Length;
					if (nincinv == 0) {
						DataRow RIncInv = D.Tables["incomeinvoice"].NewRow();
						RIncInv["idinc"] = idinctosearch;
						RIncInv["movkind"] = movkind;
						foreach (string ff in new string[] {"idinvkind", "yinv", "ninv"}) RIncInv[ff] = invcdetail[ff];
						RIncInv["ct"] = DateTime.Now;
						RIncInv["lt"] = DateTime.Now;
						RIncInv["cu"] = "importazione";
						RIncInv["lu"] = "importazione";
						D.Tables["incomeinvoice"].Rows.Add(RIncInv);
					}
				}


				if (Reader.getCurrField("codice_cpassivo") != DBNull.Value) {
					object idmankind = Reader.getCurrField("codice_cpassivo");
					object yman = Reader.getCurrField("anno_cpassivo");
					object nman = Reader.getCurrField("numero_cpassivo");
					object manrownum = Reader.getCurrField("nriga_cpassivo");

					string filterman = QHS.AppAnd(
						QHS.CmpEq("idmankind", idmankind), QHS.CmpEq("yman", yman),
						QHS.CmpEq("nman", nman), QHS.CmpEq("rownum", manrownum));
					if (Conn.RUN_SELECT_COUNT("mandatedetail", filterman, false) == 0) {
						SpeedSaver.AddError("Dettaglio ordine  non trovato con filtro: " + filterman
						                                                                 + " alla riga " +
						                                                                 Reader.GetCurrRowNumber());

					}

					invcdetail["idmankind"] = idmankind;
					invcdetail["yman"] = yman;
					invcdetail["nman"] = nman;
					invcdetail["manrownum"] = manrownum;
				}


				if (Reader.getCurrField("codice_cattivo") != DBNull.Value) {
					object idestimkind = Reader.getCurrField("codice_cattivo");
					object yestim = Reader.getCurrField("anno_cattivo");
					object nestim = Reader.getCurrField("numero_cattivo");
					object estimrownum = Reader.getCurrField("nriga_cattivo");

					string filterestim = QHS.AppAnd(
						QHS.CmpEq("idestimkind", idestimkind), QHS.CmpEq("yestim", yestim),
						QHS.CmpEq("nestim", nestim), QHS.CmpEq("rownum", estimrownum));
					if (Conn.RUN_SELECT_COUNT("estimatedetail", filterestim, false) == 0) {
						SpeedSaver.AddError("Dettaglio contratto attivo  non trovato con filtro: " + filterestim
						                                                                           + " alla riga " +
						                                                                           Reader
							                                                                           .GetCurrRowNumber());
					}

					invcdetail["idestimkind"] = idestimkind;
					invcdetail["yestim"] = yestim;
					invcdetail["nestim"] = nestim;
					invcdetail["estimrownum"] = estimrownum;
				}



				// dettaglio fattura elettronica
				/*
                "riferimentonormativo;Riferimento Normativo (Fattura Elettronica);Stringa;100",
                "codicetipo;Codice Tipo (Fattura Elettronica);Stringa;30",
                "codicevalore;Codice Valore (Fattura Elettronica);Stringa;30"
                */

				object riferimentonormativo = Reader.getCurrField("riferimentonormativo");
				object codicetipo = Reader.getCurrField("codicetipo");
				object codicevalore = Reader.getCurrField("codicevalore");

				invcdetail["fereferencerule"] = riferimentonormativo;
				invcdetail["codicetipo"] = codicetipo;
				invcdetail["codicevalore"] = codicevalore;

				Reader.GetNext();

			}

			Reader.Close();


			bool LastRes = SaveData(D, true);
			ResetHashInvoiceKind();
			D.Clear();
			Treasurer.Clear();
			Hcur.Clear();
			HIva.Clear();
			HExpK.Clear();
			HUpb.Clear();
			InvoiceHT.Clear();

			Currency.Clear();
			IvaKind.Clear();
			TreasurerTbl.Clear();
			UPB.Clear();
			ExpirationKind.Clear();
			UniqueRegister.Clear();
			GC.Collect();
			System.Threading.Thread.Sleep(1000);
			Application.DoEvents();
			return LastRes;

		}


		string[] tracciato_consegnatari = new string[] {
			"codeinvagency;Codice Ente Inventariale;Stringa;20",
			"descrinvagency;Descrizione Ente Inventariale;Stringa;150",
			"inizio;Data nomina;Data;8",
			"nome; Denominazione Consegnatario; Stringa;150",
			"qualifica; Qualifica Consegnatario;Stringa;50"
		};

		private void btnConsegnatari_Click(object sender, EventArgs e) {
			ImportaConsegnatari();
		}

		bool ImportaConsegnatari() {
			LeggiFile Reader = GetReader(tracciato_consegnatari);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new VistaConsegnatari();


			DataTable AssetConsignee = D.Tables["assetconsignee"];
			MetaData MetaAssetLoad = Meta.Dispatcher.Get("assetconsignee");
			MetaAssetLoad.SetDefaults(AssetConsignee);

			DataTable InventoryAgency = D.Tables["inventoryagency"];
			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			MetaInventoryAgency.SetDefaults(InventoryAgency);

			Conn.RUN_SELECT_INTO_TABLE(InventoryAgency, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("inventoryagency");
			InitSpeedSaver(Conn, tosync);


			int num = 0;
			Reader.GetNext();
			while (Reader.DataPresent()) {
				num++;
				//Aggiunge le informazioni di Ente Inventariale ove necessario
				string descrinvag = Reader.getCurrField("descrinvagency").ToString();
				string codeinvag = Reader.getCurrField("codeinvagency").ToString();
				object idinventoryagency = CheckinventoryAgency(InventoryAgency, codeinvag, descrinvag);

				DataRow NewAssetConsignee = AssetConsignee.NewRow();
				NewAssetConsignee["idinventoryagency"] = idinventoryagency;
				NewAssetConsignee["title"] = Reader.getCurrField("nome");
				NewAssetConsignee["qualification"] = Reader.getCurrField("qualifica");
				NewAssetConsignee["start"] = Reader.getCurrField("inizio");
				NewAssetConsignee["lt"] = DateTime.Now;
				NewAssetConsignee["lu"] = "importazione";
				AssetConsignee.Rows.Add(NewAssetConsignee);

				if (num >= 1000) {
					//Salva i dati
					num = 0;
					if (!SaveData(D, false)) break;
					D.Tables["assetconsignee"].Clear();
				}

				Reader.GetNext();
			}

			if (num > 0) {
				//Salva i dati
				SaveData(D, true);
				D.Tables["assetconsignee"].Clear();
			}

			Reader.Close();
			return ShowMessages();


		}

		string[] tracciato_classfin = new string[] {
			"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
			"codicebil;Codice Bilancio;Stringa;50",
			"anno;Anno;Intero;4",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"quota;Quota assegnazione;Numero;22"
		};

		string[] tracciato_classcausaliep = new string[] {
			"codemotive;Codice causale;Stringa;50",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50"
		};

		string[] tracciato_classupb = new string[] {
			"codiceupb;Codice UPB;Stringa;50",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"quota;Quota assegnazione;Numero;22"
		};

		private void btnClassBilancio_Click(object sender, EventArgs e) {
			ImportaClassBilancio();
		}

		bool ImportaClassBilancio() {
			LeggiFile Reader = GetReader(tracciato_classfin);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaClassFin();

			DataTable FinSorting = D.Tables["finsorting"];
			MetaData MetaFinSorting = Meta.Dispatcher.Get("finsorting");
			MetaFinSorting.SetDefaults(FinSorting);


			DataTable SortingKind = D.Tables["sortingkind"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codefin = Reader.getCurrField("codicebil").ToString();
				string finpart = Reader.getCurrField("partebil").ToString();
				object ayear = Reader.getCurrField("anno");
				string searchfin = getSqlFilterFin(codefin, finpart, ayear);
				object idfin = null;
				idfin = Conn.DO_READ_VALUE("fin", searchfin, "idfin");
				if (idfin == null || idfin == DBNull.Value) {
					SpeedSaver.AddError("Voce di bilancio " + finpart + " - " + codefin + " del " + ayear.ToString() +
					                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}


				string searchsorkind = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkind"));
				if (SortingKind.Select(searchsorkind).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione non trovato: "
					                    + Reader.getCurrField("codesorkind") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkind = SortingKind.Select(searchsorkind)[0]["idsorkind"];

				string searchsor = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcode")));
				object idsor = Conn.DO_READ_VALUE("sorting", searchsor, "idsor");
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddError("Classificazione non trovata: " +
					                    Reader.getCurrField("codesorkind").ToString() + "/" +
					                    Reader.getCurrField("sortcode").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}


				MetaData.SetDefault(FinSorting, "idsor", idsor);
				MetaData.SetDefault(FinSorting, "idfin", idfin);
				DataRow FinSor = MetaFinSorting.Get_New_Row(null, FinSorting);
				FinSor["quota"] = Reader.getCurrField("quota");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		bool ImportaClassUPB() {
			LeggiFile Reader = GetReader(tracciato_classupb);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaClassUpb();

			DataTable UpbSorting = D.Tables["upbsorting"];
			MetaData MetaUpbSorting = Meta.Dispatcher.Get("upbsorting");
			MetaUpbSorting.SetDefaults(UpbSorting);


			DataTable SortingKind = D.Tables["sortingkind"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);

			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codeupb = Reader.getCurrField("codiceupb").ToString();
				string searchupb = QHS.CmpEq("codeupb", codeupb);
				object idupb = null;
				idupb = Conn.DO_READ_VALUE("upb", searchupb, "idupb");
				if (idupb == null || idupb == DBNull.Value) {
					SpeedSaver.AddError("Codice UPB " + codeupb + " non è stata trovata alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				string searchsorkind = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkind"));
				if (SortingKind.Select(searchsorkind).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione non trovato: "
					                    + Reader.getCurrField("codesorkind") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkind = SortingKind.Select(searchsorkind)[0]["idsorkind"];

				string searchsor = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcode")));
				object idsor = Conn.DO_READ_VALUE("sorting", searchsor, "idsor");
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddError("Classificazione non trovata: " +
					                    Reader.getCurrField("codesorkind").ToString() + "/" +
					                    Reader.getCurrField("sortcode").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}


				MetaData.SetDefault(UpbSorting, "idsor", idsor);
				MetaData.SetDefault(UpbSorting, "idupb", idupb);
				DataRow UpbSor = MetaUpbSorting.Get_New_Row(null, UpbSorting);
				UpbSor["quota"] = Reader.getCurrField("quota");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		bool ImportaClassificazioniIndirette() {
			LeggiFile Reader = GetReader(tracciato_classindirette);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaClassIndirette();

			DataAccess.SetTableForReading(D.Tables["sortingkind_source"], "sortingkind");
			DataAccess.SetTableForReading(D.Tables["sortingkind_dest"], "sortingkind");

			DataTable SortingTranslation = D.Tables["sortingtranslation"];
			MetaData MetaSortingTranslation = Meta.Dispatcher.Get("sortingtranslation");
			MetaSortingTranslation.SetDefaults(SortingTranslation);


			DataTable SortingKindSource = D.Tables["sortingkind_source"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKindSource, null, null, null, false);

			DataTable SortingKindDest = D.Tables["sortingkind_dest"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKindDest, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortingkind_source");
			tosync.Add("sortingkind_dest");
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();

			while (Reader.DataPresent()) {

				string searchsorkindSource = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkindsource"));

				if (SortingKindSource.Select(searchsorkindSource).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione Origine non trovato: "
					                    + Reader.getCurrField("codesorkindsource") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkindSource = SortingKindSource.Select(searchsorkindSource)[0]["idsorkind"];

				string searchsorSource = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkindSource),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcodesource")));
				object idsorSource = Conn.DO_READ_VALUE("sorting", searchsorSource, "idsor");
				if (idsorSource == null || idsorSource == DBNull.Value) {
					SpeedSaver.AddError("Classificazione Origine non trovata: " +
					                    Reader.getCurrField("codesorkindsource").ToString() + "/" +
					                    Reader.getCurrField("sortcodesource").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}

				string searchsorkindDest = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkinddest"));
				if (SortingKindDest.Select(searchsorkindDest).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione Destinazione non trovato: "
					                    + Reader.getCurrField("codesorkinddest") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkindDest = SortingKindDest.Select(searchsorkindDest)[0]["idsorkind"];

				string searchsorDest = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkindDest),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcodedest")));
				object idsorDest = Conn.DO_READ_VALUE("sorting", searchsorDest, "idsor");
				if (idsorDest == null || idsorDest == DBNull.Value) {
					SpeedSaver.AddError("Classificazione Destinazione non trovata: " +
					                    Reader.getCurrField("codesorkinddest").ToString() + "/" +
					                    Reader.getCurrField("sortcodedest").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}

				MetaData.SetDefault(SortingTranslation, "idsortingmaster", idsorSource);
				MetaData.SetDefault(SortingTranslation, "idsortingchild", idsorDest);
				DataRow RSortingTranslation = MetaSortingTranslation.Get_New_Row(null, SortingTranslation);
				RSortingTranslation["numerator"] = Reader.getCurrField("numeratore");
				RSortingTranslation["denominator"] = Reader.getCurrField("denominatore");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		string[] tracciato_classanag = new string[] {
			"idreg;Codice Anagrafica;Intero;10",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"quota;Quota assegnazione;Numero;22"
		};

		private void btnClassAnagrafiche_Click(object sender, EventArgs e) {
			ImportaClassAnagrafiche();
		}

		bool ImportaClassAnagrafiche() {
			LeggiFile Reader = GetReader(tracciato_classanag);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaClassAnag();

			DataTable RegistrySorting = D.Tables["registrysorting"];
			MetaData MetaRegistrySorting = Meta.Dispatcher.Get("registrysorting");
			MetaRegistrySorting.SetDefaults(RegistrySorting);


			DataTable SortingKind = D.Tables["sortingkind"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKind, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();

			while (Reader.DataPresent()) {
				object idreg = Reader.getCurrField("idreg");

				string searchsorkind = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkind"));
				if (SortingKind.Select(searchsorkind).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione non trovato: "
					                    + Reader.getCurrField("codesorkind")
					                    + " alla riga " + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkind = SortingKind.Select(searchsorkind)[0]["idsorkind"];

				string searchsor = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcode")));
				object idsor = Conn.DO_READ_VALUE("sorting", searchsor, "idsor");
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddError("Classificazione non trovata: " +
					                    Reader.getCurrField("codesorkind").ToString() + "/" +
					                    Reader.getCurrField("sortcode").ToString() +
					                    " alla riga " + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}


				MetaData.SetDefault(RegistrySorting, "idsor", idsor);
				MetaData.SetDefault(RegistrySorting, "idreg", idreg);
				DataRow FinSor = MetaRegistrySorting.Get_New_Row(null, RegistrySorting);
				FinSor["quota"] = Reader.getCurrField("quota");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;


		}

		public string GetTracciato(string[] tracciato) {
			string res = "";
			int pos = 0;
			foreach (string t in tracciato) {
				string[] ss = t.Split(';');
				string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
				               ss[3].PadLeft(4) +
				               " Tipo: " + ss[2].PadLeft(15);
				if (ss[2].ToLower() == "codificato") {
					field += " Codifica:" + ss[4];
				}

				field += " Descrizione: " + ss[1];
				field += "\r\n";
				pos += CfgFn.GetNoNullInt32(ss[3]);
				res += field;
			}

			return res;
		}

		public DataTable GetTableTracciato(string[] tracciato) {
			int pos = 0;
			DataTable T = new DataTable("t");
			T.Columns.Add("nome", typeof(string));
			T.Columns.Add("posizione", typeof(int));
			T.Columns.Add("lunghezza", typeof(string));
			T.Columns.Add("tipo", typeof(string));
			T.Columns.Add("codifica", typeof(string));
			T.Columns.Add("Descrizione", typeof(string));

			foreach (string t in tracciato) {
				DataRow r = T.NewRow();
				string[] ss = t.Split(';');
				r["nome"] = ss[0];
				r["posizione"] = pos;
				r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
				r["tipo"] = ss[2];
				if (ss.Length == 5) r["codifica"] = ss[4];
				r["Descrizione"] = ss[1];
				pos += CfgFn.GetNoNullInt32(ss[3]);
				T.Rows.Add(r);
			}

			return T;
		}



		private void MenuEnterPwd_Click(object sender, EventArgs e) {
			if (sender == null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;
			string tracciato = "";
			DataTable TableTracciato = null;
			foreach (ImportButton IB in AllButton) {
				if (IB.Btn == mysender) {
					tracciato = GetTracciato(IB.tracciato);
					TableTracciato = GetTableTracciato(IB.tracciato);
					break;
				}
			}

			FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
			FT.ShowDialog();

		}

		private void menuItem1_Click(object sender, EventArgs e) {
			if (sender == null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;
			string[] tracciato = null;
			DataTable TableTracciato = null;
			foreach (ImportButton IB in AllButton) {
				if (IB.Btn == mysender) {
					tracciato = IB.tracciato;
					TableTracciato = GetTableTracciato(IB.tracciato);
					break;
				}
			}

			LeggiFile Reader = GetReader(tracciato);
			if (Reader == null) return;

			Reader.GetNext();
			string rec = Reader.GetCurrRecord();

			Reader.Close();
			FrmShowTracciato FT = new FrmShowTracciato(rec, TableTracciato, "primo record");
			FT.ShowDialog();


		}



		public class LeggiFile {
			string[] tracciato;

			FileStream FS;

			//StreamReader SR;
			BufferedStream BF;
			string currrecord;

			public int GetCurrRowNumber() {
				return nrigacorrente - 1;
			}

			int len = 0; //Lunghezza del tracciato

			public LeggiFile() {

			}

			bool excel = false;
			bool datatable = false;
			Microsoft.Office.Interop.Excel.Application xlApp = null;
			Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
			Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
			int nrigacorrente = 1;

			DataTable SPTable = null;

			public bool Init(DataAccess Conn, string[] tracciato, string sqltext) {
				this.tracciato = tracciato;
				len = 0;
				currrecord = "";
				SPTable = Conn.SQLRunner(sqltext, false, 0);
				datatable = true;
				if (SPTable == null) {
					MessageBox.Show("Il comando SQL " + sqltext + " non ha restituito una tabella.", "Avviso");
					return false;
				}

				return true;
			}

			public void Reset() {
				nrigacorrente = 1;
				currrecord = "";
				if (datatable) {
					return;
				}

				if (excel) {
					return;
				}

				FS.Seek(0, SeekOrigin.Begin);
			}

			public bool Init(string[] tracciato, string filename) {
				this.tracciato = tracciato;
				len = 0;
				currrecord = "";
				for (int i = 0; i < tracciato.Length; i++) {
					string[] par = tracciato[i].Split(';');
					len += Convert.ToInt32(par[3]);
				}

				if (filename.EndsWith("xls") || filename.EndsWith("xlsx")) {
					try {
						xlApp = new Microsoft.Office.Interop.Excel.Application();
						xlWorkBook = xlApp.Workbooks.Open(filename, 0, true /* impostare a false se non è readonly */,
							5,
							"", "", true,
							Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
							//Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
							"\t", //delimiter
							false, //editable
							false, //Notify
							0, true, 1, 0);
						xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
						excel = true;
					}
					catch (Exception E) {
						QueryCreator.ShowException(E);
						return false;
					}

				}
				else {
					try {
						FS = new FileStream(filename, FileMode.Open);
						BF = new BufferedStream(FS, 10000000);
					}
					catch (Exception E) {
						QueryCreator.ShowException(E);
						return false;
					}
				}

				return true;
			}

			public void Close() {
				if (SPTable != null) {
					SPTable.Clear();
					SPTable = null;
				}

				if (excel && xlApp != null) {
					xlApp.Quit();
					releaseObject(xlApp);
					releaseObject(xlWorkBook);
					releaseObject(xlWorkSheet);
					xlApp = null;
					return;
				}

				if (BF != null) {
					BF.Close();
					BF.Dispose();
					BF = null;
				}

				if (FS != null) {
					FS.Close();
					FS.Dispose();
					FS = null;
				}

			}

			private void releaseObject(object obj) {
				try {
					System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
					obj = null;
				}
				catch (Exception ex) {
					obj = null;
					MessageBox.Show("Unable to release the Object " + ex.ToString());
				}
				finally {
					GC.Collect();
				}
			}


			Hashtable H = new Hashtable();

			public bool DataPresent() {
				if (H == null) return false;
				return true;

			}

			/// <summary>
			/// Estrae un campo, restituisce null su errori
			/// </summary>
			/// <param name="S"></param>
			/// <param name="tracciato_field"></param>
			/// <returns></returns>
			object GetField(string S, int start, string tracciato_field, out string fieldname, out int toskip) {
				string[] ff = tracciato_field.Split(';');
				fieldname = ff[0];
				int len = Convert.ToInt32(ff[3]);
				string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
				toskip = len;
				string val = S.Substring(start, len).Trim();
				if (val == "") return DBNull.Value;
				try {
					switch (ftype) {
						case "intero": {
							string X = val.Trim().TrimStart('0');
							if (X == "") return 0;
							return Convert.ToInt32(X);
						}

						case "stringa":
							return val.TrimEnd(new char[] {' '});
						case "numero":
							return Convert.ToDecimal(val);
						case "data":
							return ToDatetime(new DateTime(Convert.ToInt32(val.Substring(4)),
								Convert.ToInt32(val.Substring(2, 2).TrimStart('0')),
								Convert.ToInt32(val.Substring(0, 2).TrimStart('0'))));
						case "codificato": {
							string[] codici = ff[4].Split('|');
							for (int i = 0; i < codici.Length; i++) {
								if (val.ToLower() == codici[i].ToLower()) return val;
							}

							SpeedSaver.AddError("Valore non previsto nella decodifica del campo " + fieldname +
							                    " di tipo " + ftype + " e di valore " +
							                    val.Trim().TrimStart('0') + " nella riga " + S);
							return null;
						}

						default: {
							SpeedSaver.AddError("Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
							                    " e di valore " +
							                    val.Trim().TrimStart('0') + " nella riga " + S);
							return null;
						}
					}
				}
				catch {
					SpeedSaver.AddError("Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
					                    " e di valore " +
					                    val.Trim().TrimStart('0') + " nella riga " + S);
					return null;
				}
			}


			object ExcelGetField(object val, object val2, string tracciato_field, out string fieldname) {
				string[] ff = tracciato_field.Split(';');
				fieldname = ff[0];
				int len = Convert.ToInt32(ff[3]);
				string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
				if (val == null) return DBNull.Value;
				if (val == DBNull.Value) return val;
				if (val.ToString().Trim() == "") return DBNull.Value;
				try {
					switch (ftype) {
						case "intero": {
							string X = val.ToString().Trim().TrimStart('0');
							if (X == "") return 0;
							return Convert.ToInt32(X);
						}

						case "stringa": {
							string Y = val.ToString().TrimEnd(new char[] {' '});
							if (Y.Length > len) {
								return Y.Substring(0, len);
							}
							else {
								return Y;
							}
						}

						case "numero":
							return Convert.ToDecimal(val);
						case "data": // DateTime.FromOADate and DateTime.ToOADate
							if (val2.GetType() == typeof(string)) {
								string[] gma = val2.ToString().Split('/');
								return
									ToDatetime(new DateTime(Convert.ToInt32(gma[2]), Convert.ToInt32(gma[1]),
										Convert.ToInt32(gma[0])));
							}
							else {
								return ToDatetime(DateTime.FromOADate(Convert.ToDouble(val2)));
							}

						//return new DateTime(Convert.ToInt32(val.Substring(4)),
						//                            Convert.ToInt32(val.Substring(2, 2).TrimStart('0')),
						//                            Convert.ToInt32(val.Substring(0, 2).TrimStart('0')));
						case "codificato": {
							string[] codici = ff[4].Split('|');
							for (int i = 0; i < codici.Length; i++) {
								if (val.ToString().ToLower() == codici[i].ToLower()) return val;
							}

							SpeedSaver.AddError("Valore non previsto nella decodifica del campo " + fieldname +
							                    " di tipo " + ftype + " e di valore " +
							                    val.ToString().Trim().TrimStart('0') + " nella riga " +
							                    nrigacorrente.ToString());
							return null;
						}

						default: {
							SpeedSaver.AddError("Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
							                    " e di valore " +
							                    val.ToString().Trim().TrimStart('0') + " nella riga " +
							                    nrigacorrente.ToString());
							//SpeedSaver.AddError("Errore interno nel tracciato per tipo " + ftype);
							return null;
						}
					}
				}
				catch {
					SpeedSaver.AddError("Errore nella decodifica del campo " + fieldname + " di tipo " + ftype +
					                    " e di valore " +
					                    val.ToString().Trim().TrimStart('0') + " nella riga " +
					                    nrigacorrente.ToString());
					return null;
				}
			}


			bool DataTableGetNext() {
				int myrow = nrigacorrente - 1;
				if (myrow >= SPTable.Rows.Count) {
					H = null;
					return false;
				}

				if (H == null) H = new Hashtable();
				DataRow R = SPTable.Rows[myrow];
				currrecord = "";
				string fieldname = "";
				object O = "";
				string ftype = "";
				for (int i = 0; i < tracciato.Length; i++) {
					try {
						string fmt = tracciato[i];
						string[] ff = fmt.Split(';');
						fieldname = ff[0];
						ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
						int len = Convert.ToInt32(ff[3]);

						if (SPTable.Columns.Contains(fieldname)) {
							O = R[fieldname];
							if (O.ToString().Trim() == "")
								O = DBNull.Value;


							if (ftype == "stringa" && O != DBNull.Value) {
								string Y = O.ToString().TrimEnd();
								if (Y.Length > len) {
									O = Y.Substring(0, len);
								}
								else {
									O = Y;
								}
							}

							if (O.GetType() == typeof(DateTime))
								O = ToDatetime(O);
							H[fieldname] = O;
							if (O != DBNull.Value)
								currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
						}
						else {
							H[fieldname] = DBNull.Value;
						}
					}
					catch (Exception e) {
						throw new Exception("Errore alla riga:" + nrigacorrente.ToString() +
						                    " nell'interpretazione del campo " +
						                    fieldname + " il cui tipo dovrebbe essere " + ftype +
						                    " ed il cui valore è " + O.ToString() + "\r\nMessaggio:\r\n" + e.Message +
						                    "\r\n" + e.StackTrace);
					}
				}

				nrigacorrente++;
				return true;

			}

			private object ToDatetime(object data) {
				if (data == DBNull.Value)
					return data;

				DateTime d = (DateTime) data;
				DateTime minValue = new DateTime(1753, 1, 1);
				if (d < minValue)
					return minValue;
				DateTime maxValue = new DateTime(9999, 12, 31);
				if (d > maxValue)
					return maxValue;

				return data;

			}

			/// <summary>
			/// Returns false if no more data
			/// </summary>
			/// <returns></returns>
			bool ExcelGetNext() {
				string lastcol = ExcelColumnFromNumber(tracciato.Length);
				string row = nrigacorrente.ToString();
				bool somedata = false;
				object[] celle = new object[tracciato.Length];
				object[] celle2 = new object[tracciato.Length];

				int HTestHash = metaprofiler.StartTimer("Test HashTable");
				int ncol = tracciato.Length;
				Microsoft.Office.Interop.Excel.Range testCell = null;
				int ntry = 0;
				while (true) {
					ntry++;
					try {
						testCell = xlWorkSheet.Range[ExcelColumnFromNumber(1) + nrigacorrente.ToString(),
							ExcelColumnFromNumber(ncol) + nrigacorrente.ToString()];
						break;
					}
					catch (Exception E) {
						if (ntry == 10) throw E;
						Thread.Sleep(100 * ntry);

					}
				}

				object[,] Xcelle =
					(object[,])
					testCell.get_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault);
				object[,] Xcelle2 = (object[,]) testCell.Value2;
				for (int i = 0; i < tracciato.Length; i++) {
					object getvalue = Xcelle[1, i + 1];
					celle[i] = getvalue;
					celle2[i] = Xcelle2[1, i + 1];
					if (getvalue == null) {
						continue;
					}

					if (getvalue.ToString() != "") {
						somedata = true;
						//break;
					}
				}

				metaprofiler.StopTimer(HTestHash);
				if (!somedata) {
					H = null;
					return false;
				}
				//Excel.Range R = xlWorkSheet.Range["A"+row , lastcol+row];

				int HFillHash = metaprofiler.StartTimer("Fill HashTable");
				if (H == null) H = new Hashtable();
				currrecord = "";

				for (int i = 0; i < tracciato.Length; i++) {
					string fieldname;
					string fmt = tracciato[i];
					object O = null;

					int hprof = metaprofiler.StartTimer("ExcelGetField");
					O = ExcelGetField(celle[i], celle2[i], fmt, out fieldname);
					metaprofiler.StopTimer(hprof);

					if (O == null) {
						metaprofiler.StopTimer(HFillHash);
						H = null;
						return false;
					}

					currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
					H[fieldname] = O; //HH
				}

				nrigacorrente++;
				metaprofiler.StopTimer(HFillHash);
				//Application.DoEvents();
				return true;
			}

			string ExcelColumnFromNumber(int column) {
				int hprof = metaprofiler.StartTimer("ExcelColumnFromNumber");
				string columnString = "";
				int columnNumber = column;
				while (columnNumber > 0) {
					int currentLetterNumber = (columnNumber - 1) % 26;
					char currentLetter = (char) (currentLetterNumber + 65);
					columnString = currentLetter + columnString;
					columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
				}

				metaprofiler.StopTimer(hprof);
				return columnString;
			}

			int NumberFromExcelColumn(string column) {
				int retVal = 0;
				string col = column.ToUpper();
				for (int iChar = col.Length - 1; iChar >= 0; iChar--) {
					char colPiece = col[iChar];
					int colNum = colPiece - 64;
					retVal = retVal + colNum * (int) Math.Pow(26, col.Length - (iChar + 1));
				}

				return retVal;
			}


			/// <summary>
			/// Returns false if no more data
			/// </summary>
			/// <returns></returns>
			public bool GetNext() {
				if (datatable) return DataTableGetNext();
				if (excel) return ExcelGetNext();

				if (BF == null) {
					H = null;
					return false;
				}

				if (BF.Position >= BF.Length) {
					H = null;
					return false;
				}

				byte[] buffer = new byte[len + 2];
				//Legge una riga dal file
				int HBFRead = metaprofiler.StartTimer("BF.Read(buffer)");
				int count = BF.Read(buffer, 0, len + 2);
				metaprofiler.StopTimer(HBFRead);
				if (count < len) {
					H = null;
					return false;
				}

				int currpos = 0;
				string S = Encoding.Default.GetString(buffer);
				currrecord = "";
				int HFillHash = metaprofiler.StartTimer("Fill HashTable");
				if (H == null) H = new Hashtable();
				//Hashtable HH = new Hashtable();
				for (int i = 0; i < tracciato.Length; i++) {
					int toskip = 0;
					string fieldname;
					string fmt = tracciato[i];
					object O = GetField(S, currpos, fmt, out fieldname, out toskip);
					if (O == null) {
						metaprofiler.StopTimer(HFillHash);
						H = null;
						return false;
					}

					currrecord += "[" + fieldname + "=" + O.ToString() + "] ";
					H[fieldname] = O; //HH
					currpos += toskip;
				}

				metaprofiler.StopTimer(HFillHash);
				//Application.DoEvents();
				//H = HH;
				return true;

			}

			public string GetCurrRecord() {
				return currrecord;
			}

			public object getCurrField(string fieldname) {
				if (H == null) return DBNull.Value;
				if (H[fieldname] == null) {
					//SpeedSaver.AddError("Campo " + fieldname + " non trovato nel tracciato");
					return DBNull.Value;
				}

				return H[fieldname];
			}

		}

		private void button1_Click_1(object sender, EventArgs e) {
			string deleteDoppioni = " DELETE FROM ASSETTOLINK WHERE " +
			                        " (SELECT COUNT(*) FROM ASSETTOLINK AS A " +
			                        " WHERE ASSETTOLINK.idinventory_tolink = A.idinventory_tolink " +
			                        " AND   ASSETTOLINK.ninventory_tolink  = A.ninventory_tolink " +
			                        " AND   ASSETTOLINK.idpiece_tolink     = A.idpiece_tolink " +
			                        " AND   ASSETTOLINK.kind = A.kind " +
			                        " ) >1 ";
			Conn.SQLRunner(deleteDoppioni);

			string updateTo = " UPDATE 	ASSET  " +
			                  " SET 	ASSET.idasset_prev = ASSETTOLINK.idasset, " +
			                  " ASSET.idpiece_prev = ASSETTOLINK.idpiece " +
			                  " FROM  	ASSETTOLINK " +
			                  " JOIN  	ASSET ASSETLINKED " +
			                  " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
			                  " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
			                  " JOIN  ASSETACQUIRE ASSETACQUIRELINKED " +
			                  " ON  ASSETACQUIRELINKED.nassetacquire = ASSETLINKED.nassetacquire " +
			                  " AND  ASSETACQUIRELINKED.idinventory = ASSETTOLINK.idinventory_tolink " +
			                  " WHERE KIND = 'T'";
			Conn.SQLRunner(updateTo);


			string updateFrom = " UPDATE 	ASSET   " +
			                    " SET 	ASSET.idasset_prev = ASSETLINKED.idasset, " +
			                    " ASSET.idpiece_prev = ASSETLINKED.idpiece " +
			                    " FROM  	ASSETTOLINK " +
			                    " JOIN  	ASSET ASSETLINKED " +
			                    " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
			                    " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
			                    " JOIN  ASSETACQUIRE ASSETACQUIRELINKED " +
			                    " ON  ASSETACQUIRELINKED.nassetacquire = ASSETLINKED.nassetacquire " +
			                    " AND  ASSETACQUIRELINKED.idinventory = ASSETTOLINK.idinventory_tolink " +
			                    " WHERE KIND = 'F'";
			Conn.SQLRunner(updateFrom);
		}

		private void button1_Click_2(object sender, EventArgs e) {
			string updateTo = " UPDATE 	ASSET  " +
			                  " SET 	ASSET.idasset_prev = ASSETTOLINK.idasset, " +
			                  " ASSET.idpiece_prev = ASSETTOLINK.idpiece " +
			                  " FROM  	ASSETTOLINK " +
			                  " JOIN  	ASSET ASSETLINKED " +
			                  " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
			                  " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
			                  " JOIN  ASSETACQUIRE ASSETACQUIRELINKED " +
			                  " ON  ASSETACQUIRELINKED.nassetacquire = ASSETLINKED.nassetacquire " +
			                  " AND  ASSETACQUIRELINKED.idinventory = ASSETTOLINK.idinventory_tolink " +
			                  " WHERE KIND = 'T'";
			Conn.SQLRunner(updateTo);

			string updateFrom = " UPDATE 	ASSET   " +
			                    " SET 	ASSET.idasset_prev = ASSETLINKED.idasset, " +
			                    " ASSET.idpiece_prev = ASSETLINKED.idpiece " +
			                    " FROM  	ASSETTOLINK " +
			                    " JOIN  	ASSET ASSETLINKED " +
			                    " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
			                    " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
			                    " JOIN  ASSETACQUIRE ASSETACQUIRELINKED " +
			                    " ON  ASSETACQUIRELINKED.nassetacquire = ASSETLINKED.nassetacquire " +
			                    " AND  ASSETACQUIRELINKED.idinventory = ASSETTOLINK.idinventory_tolink " +
			                    " WHERE KIND = 'F'";
			Conn.SQLRunner(updateFrom);

		}

		private void tabPage2_PropertyChanged(Crownwood.Magic.Controls.TabPage page,
			Crownwood.Magic.Controls.TabPage.Property prop, object oldValue) {

		}

		public class CreaAnagrafica {
			public MetaData MetaRegistry;
			public MetaData MetaRegistryAddress;
			public MetaData MetaRegistryPayM;
			public DataTable Residence;
			public Hashtable Hres;
			public DataTable Currency;
			public Hashtable Hcur;

			public DataTable Position;
			public Hashtable HPosition;

			public Int32 MaxKeyValue;
			public bool ErrorStatus;
			public string ErrorMessage;

			public CreaAnagrafica(DataSet DS, DataAccess Conn, MetaData Meta) {
				// Inizializza i metadati
				MetaRegistry = Meta.Dispatcher.Get("registry");
				MetaRegistry.SetDefaults(DS.Tables["registry"]);
				MetaRegistryAddress = Meta.Dispatcher.Get("registryaddress");
				MetaRegistryAddress.SetDefaults(DS.Tables["registryaddress"]);
				MetaRegistryPayM = Meta.Dispatcher.Get("registrypaymethod");
				MetaRegistryPayM.SetDefaults(DS.Tables["registrypaymethod"]);


				// Riempie le Hashtables di transcodifica
				Residence = Conn.RUN_SELECT("residence", "*", null, null, null, false);
				Hres = new Hashtable();
				foreach (DataRow RR in Residence.Select()) Hres[RR["coderesidence"]] = RR["idresidence"];

				Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
				Hcur = new Hashtable();
				foreach (DataRow RCC in Currency.Select())
					Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

			}

			public DataRow Crea(LeggiFile Reader, DataSet D, DataAccess Conn) {
				CQueryHelper QHC = new CQueryHelper();
				QueryHelper QHS = Conn.GetQueryHelper();

				object id_indirizzo_default = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"),
					"idaddress");
				object id_indirizzo_domdef = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"),
					"idaddress");

				DataRow Reg = MetaRegistry.Get_New_Row(null, D.Tables["registry"]);

				// Controlla preventivamente se c'è un record, trova il max e somma 100000
				if (D.Tables["registry"].Rows.Count == 1) {
					object MaxValue = Conn.DO_READ_VALUE("registry", null, "MAX(idreg)");
					Int32 MaxIntValue = (Int32) MaxValue + 100000;
					Reg["idreg"] = MaxIntValue;
					MaxKeyValue = MaxIntValue;
				}
				else {
					MaxKeyValue++;
					Reg["idreg"] = MaxKeyValue;
				}

				Reg["idregistryclass"] = Reader.getCurrField("tipologia");
				Reg["residence"] = Hres[Reader.getCurrField("tiporesidenza")];
				Reg["title"] = Reader.getCurrField("denominazione");
				Reg["surname"] = Reader.getCurrField("cognome");
				Reg["forename"] = Reader.getCurrField("nome");
				Reg["gender"] = Reader.getCurrField("sesso");
				Reg["p_iva"] = Reader.getCurrField("p_iva");
				Reg["cf"] = Reader.getCurrField("cf");
				Reg["foreigncf"] = Reader.getCurrField("cf_ext");
				Reg["birthdate"] = SSToSmalldateTime(Reader.getCurrField("datanasc"));
				Reg["location"] = Reader.getCurrField("localitanasc");
				Reg["extmatricula"] = Reader.getCurrField("matricola");
				Reg["annotation"] = Reader.getCurrField("note");
				object idcity = DBNull.Value;
				object idnation = DBNull.Value;
				object cat = Reader.getCurrField("catastalenasc");
				this.GetCatastale(Reg["idreg"].ToString(), cat, out idcity, out idnation, Conn);
				if (ErrorStatus) return null;
				Reg["idcity"] = idcity;
				Reg["idnation"] = idnation;
				Reg["authorization_free"] = Reader.getCurrField("esenteeq");
				Reg["multi_cf"] = Reader.getCurrField("cfduplicato");

				string AnagIsActive = Reader.getCurrField("attiva").ToString();
				if (AnagIsActive != null && AnagIsActive != "")
					Reg["active"] = Reader.getCurrField("attiva");
				else
					Reg["active"] = "N";

				//indirizzo predefinito/residenza
				object data_ind1 = SSToSmalldateTime(Reader.getCurrField("dataind_res"));
				if (data_ind1 != DBNull.Value) {
					DataRow RI1 = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
					RI1["idreg"] = Reg["idreg"];
					RI1["start"] = data_ind1;
					RI1["idaddresskind"] = id_indirizzo_default;
					RI1["address"] = Reader.getCurrField("indirizzo_res");
					RI1["cap"] = Reader.getCurrField("cap_res");
					RI1["officename"] = Reader.getCurrField("ufficio_res");
					object idcity_res = DBNull.Value;
					object idnation_res = DBNull.Value;
					object cat_res = Reader.getCurrField("catastale_res");
					this.GetCatastale(Reg["idreg"].ToString(), cat_res, out idcity_res, out idnation_res, Conn);
					if (ErrorStatus) return null;
					RI1["idcity"] = idcity_res;
					RI1["idnation"] = idnation_res;
					if (idnation_res != DBNull.Value) {
						RI1["flagforeign"] = "S";
					}
					else {
						RI1["flagforeign"] = "N";
					}

					RI1["location"] = Reader.getCurrField("localita_res");
					RI1["active"] = "S";
				}

				//domicilio fiscale ove diverso dal predefinito
				object data_ind2 = SSToSmalldateTime(Reader.getCurrField("dataind_dom"));
				if (data_ind2 != DBNull.Value) {
					DataRow RI2 = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
					RI2["idreg"] = Reg["idreg"];
					RI2["start"] = data_ind2;
					RI2["idaddresskind"] = id_indirizzo_domdef;
					RI2["address"] = Reader.getCurrField("indirizzo_dom");
					RI2["cap"] = Reader.getCurrField("cap_dom");
					RI2["officename"] = Reader.getCurrField("ufficio_dom");
					object idcity_dom = DBNull.Value;
					object idnation_dom = DBNull.Value;
					object cat_dom = Reader.getCurrField("catastale_dom");
					this.GetCatastale(Reg["idreg"].ToString(), cat_dom, out idcity_dom, out idnation_dom, Conn);
					if (ErrorStatus) return null;
					RI2["idcity"] = idcity_dom;
					RI2["idnation"] = idnation_dom;
					if (idnation_dom != DBNull.Value) {
						RI2["flagforeign"] = "S";
					}
					else {
						RI2["flagforeign"] = "N";
					}

					RI2["location"] = Reader.getCurrField("localita_dom");
					RI2["active"] = "S";
				}

				object idpaymethod = Reader.getCurrField("tipomodpag");
				if (idpaymethod != DBNull.Value) {
					DataRow RP = MetaRegistryPayM.Get_New_Row(Reg, D.Tables["registrypaymethod"]);
					RP["idreg"] = Reg["idreg"];
					RP["idpaymethod"] = idpaymethod;
					RP["regmodcode"] = Reader.getCurrField("nomemod");
					RP["paymentdescr"] = Reader.getCurrField("descrmod");
					RP["idbank"] = Reader.getCurrField("abi");
					RP["idcab"] = Reader.getCurrField("cab");
					RP["cin"] = Reader.getCurrField("cin");
					RP["cc"] = Reader.getCurrField("cc");
					RP["active"] = "S";
					RP["flagstandard"] = "S";
					RP["iddeputy"] = Reader.getCurrField("delegato");
					object codecurrency = Reader.getCurrField("valuta");
					if (codecurrency == DBNull.Value) codecurrency = "EUR";
					RP["idcurrency"] = Hcur[codecurrency.ToString().ToUpper()];
					RP["idexpirationkind"] = Reader.getCurrField("tiposcadenza");
					RP["paymentexpiring"] = Reader.getCurrField("ggscadenza");
					RP["iban"] = Reader.getCurrField("iban");
				}

				return Reg;
			}

			private void GetCatastale(string codiceanag, object codice, out object idcity, out object idnation,
				DataAccess Conn) {
				CQueryHelper QHC = new CQueryHelper();
				QueryHelper QHS = Conn.GetQueryHelper();

				idcity = DBNull.Value;
				idnation = DBNull.Value;
				if (codice != DBNull.Value) {
					idcity = Conn.DO_READ_VALUE("geo_city_agencyview",
						QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
							QHS.CmpEq("value", codice)
							//,QHS.IsNull("stop"), QHS.IsNull("newcity")
						), "idcity", null);
					if (idcity == null) {
						idcity = DBNull.Value;
						idnation = Conn.DO_READ_VALUE("geo_nation_agencyview",
							QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
								QHS.CmpEq("value", codice)
								//,QHS.IsNull("stop"), QHS.IsNull("newnation")
							), "idnation", null);
						if (idnation == null) {
							idnation = DBNull.Value;
							ErrorStatus = true;
							ErrorMessage = "codice catastale non trovato:" + codice.ToString() +
							               " per l'anagrafica di codice:" + codiceanag;
						}
					}
				}
			}



		}

		private void btnImportaFatture_Click(object sender, EventArgs e) {
			ImportaFatture();
		}

		private void btnCreaFatture_Click(object sender, EventArgs e) {
			CreaFatture();
		}

		string[] tracciato_rivalutazioni = new string[] {
			"codiceinv;Codice inventario;Stringa;20",
			"numinv;Numero di inventario;Intero;8",
			"numprog;Numero progressivo cespite (1 per cespiti, >1 per accessori);Intero;5",
			"codtiporiv;Codice tipo ammortamento;Stringa;20",
			"descrtiporiv;Descrizione tipo rivalutazione;Stringa;50",
			"valiniziale;Valore iniziale ai fini della rivalutazione;Numero;22",
			"percriv;Percentuale rivalutazione;Numero;22",
			"datariv;Data rivalutazione;Data;8",
			"codicetipobuonocar;Codice tipo buono carico;Stringa;20",
			"annobuonocar;Anno buono carico;Intero;4",
			"numbuonocar;Numero buon carico;Intero;8",
			"includibuonocar;Da includere in buono di carico (S/N);Codificato;1;S|N",
			"descr;Descrizione rivalutazione;Stringa;150"
		};

		private void btnRivalutazioni_Click(object sender, EventArgs e) {
			ImportaRivalutazioni();
		}

		bool ImportaRivalutazioni() {
			LeggiFile Reader = GetReader(tracciato_rivalutazioni);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaAmmortamenti();


			DataTable AssetAmortization = D.Tables["assetamortization"];
			MetaData MetaAssetAmortization = Meta.Dispatcher.Get("assetamortization");
			MetaAssetAmortization.SetDefaults(AssetAmortization);

			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);


			DataTable AssetLoadKind = D.Tables["assetloadkind"];
			MetaData MetaAssetLoadKind = Meta.Dispatcher.Get("assetloadkind");
			MetaAssetLoadKind.SetDefaults(AssetLoadKind);

			DataTable InventoryAmortization = D.Tables["inventoryamortization"];
			MetaData MetaInventoryAmortization = Meta.Dispatcher.Get("inventoryamortization");
			MetaInventoryAmortization.SetDefaults(InventoryAmortization);

			//DataTable AssetLoad = D.Tables["assetload"];


			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAmortization, null, null, null, false);
			//Conn.RUN_SELECT_INTO_TABLE(AssetLoad, null, null, null, false);


			List<string> tosync = new List<string>();
			tosync.Add("inventory");
			tosync.Add("assetloadkind");
			tosync.Add("inventoryamortization");
			InitSpeedSaver(Conn, tosync);



			int num = 0;

			Reader.GetNext();
			//int maxidassetload = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("assetload", null, "max(idassetload)")) + 1;
			while (Reader.DataPresent()) {
				object perc = Reader.getCurrField("percriv");
				if (CfgFn.GetNoNullDecimal(perc) <= 0) {
					Reader.GetNext();
					continue;
				}

				if (num >= 1000) {
					//Salva i dati
					num = 0;
					if (!SaveData(D, false)) break;
					D.Tables["assetamortization"].Clear();
				}

				num++;



				string codeinventory = Reader.getCurrField("codiceinv").ToString();
				object idinventory = DBNull.Value;
				string filteridinv = QHC.CmpEq("codeinventory", codeinventory);
				if (Inventory.Select(filteridinv).Length == 0) {
					SpeedSaver.AddError("Codice inventario " + codeinventory + " non trovato. Riga:"
					                    + Reader.GetCurrRowNumber());
					idinventory = 0;
					;
				}
				else {
					idinventory = Inventory.Select(filteridinv)[0]["idinventory"];
				}

				int ninventory = CfgFn.GetNoNullInt32(Reader.getCurrField("numinv"));
				int idpiece = CfgFn.GetNoNullInt32(Reader.getCurrField("numprog"));

				//Determina idasset da idinventory+ninventory
				string filterasset = QHS.AppAnd(
					QHS.CmpEq("A1.idinventory", idinventory),
					QHS.CmpEq("A.ninventory", ninventory),
					QHS.CmpEq("A.idpiece", 1));

				object idasset = Conn.DO_SYS_CMD(
					"SELECT A.idasset from asset A join assetacquire A1 on A.nassetacquire =A1.nassetacquire WHERE " +
					filterasset, false);

				//Conn.DO_READ_VALUE("assetview", filterasset, "idasset");
				//if (idasset == null) idasset = 1; // poi questo deve essere tolto
				if (idasset == DBNull.Value || idasset == null) {
					SpeedSaver.AddError("Cespite " + ninventory.ToString() + "/" + codeinventory + " non trovato. Riga:"
					                    + Reader.GetCurrRowNumber());
					idasset = 0;
				}

				object yassetload = Reader.getCurrField("annobuonocar");
				object nassetload = Reader.getCurrField("numbuonocar");


				object idassetload = DBNull.Value;
				object codeassetloadkind = Reader.getCurrField("codicetipobuonocar");
				if (codeassetloadkind != DBNull.Value) {
					object idassetloadkind = GetidAssetLoadKind(AssetLoadKind, codeassetloadkind);
					if (idassetloadkind != DBNull.Value) {
						idassetload = GetidAssetLoad(idassetloadkind, yassetload, nassetload);
						if (idassetload == DBNull.Value) {
							SpeedSaver.AddError("Il tipo buono di carico  " + codeassetloadkind + "/" +
							                    nassetload.ToString() + " del " + yassetload.ToString() +
							                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						SpeedSaver.AddError("Il tipo buono di carico " + codeassetloadkind +
						                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
					}
				}

				object idinventoryamortization = CheckInventoryAmortization(InventoryAmortization,
					Reader.getCurrField("codtiporiv").ToString(), Reader.getCurrField("descrtiporiv").ToString());

				object includi_buono = Reader.getCurrField("includibuonocar");
				int flag = 0;
				if (includi_buono.ToString().ToUpper() == "S") flag += 1;
				//if (perc != DBNull.Value) {
				//    perc = -CfgFn.GetNoNullDecimal(perc)/100;
				//}

				DataRow NewAssetAmortization = MetaAssetAmortization.Get_New_Row(null, AssetAmortization);
				NewAssetAmortization["flag"] = flag;
				NewAssetAmortization["transmitted"] = "N";
				NewAssetAmortization["adate"] = ToSmalldateTime(Reader.getCurrField("datariv"));
				NewAssetAmortization["amortizationquota"] = perc;
				NewAssetAmortization["assetvalue"] = Reader.getCurrField("valiniziale");
				NewAssetAmortization["description"] = Reader.getCurrField("descr");
				NewAssetAmortization["idasset"] = idasset;
				NewAssetAmortization["idpiece"] = idpiece;
				NewAssetAmortization["idassetload"] = idassetload;
				NewAssetAmortization["idinventoryamortization"] = idinventoryamortization;


				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		string[] tracciato_cespitistorico = new string[] {
			"tipocespite;Tipo Cespite (Cespite/Accessorio);Codificato;1;C|A",
			"codiceinv;Codice Inventario;Stringa;20",
			"descrinv;Descrizione Inventario;Stringa;50",
			"codeinvkind;Codice Tipo Inventario;Stringa;20",
			"descrinvkind;Descr. Tipo Inventario;Stringa;50",
			"codeinvagency;Codice Ente Inventariale;Stringa;20",
			"descrinvagency;Descrizione Ente Inventariale;Stringa;150",
			"numinv;Numero di inventario;Intero;8",
			"nprogr;Numero progressivo. 1 per i cespiti, 2 o più per gli accessori;Intero;5",
			//
			"codiceinv_prec;Codice Inventario di Provenienza;Stringa;20",
			"descrinv_prec;Descrizione Inventario di Provenienza;Stringa;50",
			"codeinvkind_prec;Codice Tipo Inventario di Provenienza;Stringa;20",
			"descrinvkind_prec;Descr. Tipo Inventario di Provenienza;Stringa;50",
			"codeinvagency_prec;Codice Ente Inventariale di Provenienza;Stringa;20",
			"descrinvagency_prec;Descrizione Ente Inventariale di Provenienza;Stringa;150",
			"numinv_prec;Numero di inventario di Provenienza;Intero;8",
			"nprogr_prec;Numero progressivo. di Provenienza, 1 per i cespiti, 2 o più per gli accessori;Intero;5",
			//
			"codiceinv_succ;Codice Inventario Successivo;Stringa;20",
			"descrinv_succ;Descrizione Inventario Successivo;Stringa;50",
			"codeinvkind_succ;Codice Tipo Inventario Successivo;Stringa;20",
			"descrinvkind_succ;Descr. Tipo Inventario Successivo;Stringa;50",
			"codeinvagency_succ;Codice Ente Inventariale Successivo;Stringa;20",
			"descrinvagency_succ;Descrizione Ente Inventariale Successivo;Stringa;150",
			"numinv_succ;Numero di inventario Successivo;Intero;8",
			"nprogr_succ;Numero progressivo Successivo, 1 per i cespiti, 2 o più per gli accessori;Intero;5",
			//
			"inizioesist;Inizio esistenza;Data;8",
			"codiceclass;Codice classificazione inventariale;Stringa;20",
			"descr;Descrizione Cespite;Stringa;150",
			"impon;Imponibile;Numero;22",
			"iva;Iva;Numero;22",
			"ivadetr;Iva Detraibile;Numero;22",
			"ivaperc;Aliquota Iva;Numero;22",
			"scontoperc;Percentuale Sconto;Numero;22",
			"valorestorico;Valore Storico;Numero;22",
			"codicecausalecar;Codice Causale di carico;Stringa;10",
			"descrcausalecar;Descrizione Causale di carico;Stringa;30",
			"codicecedente;Codice Cedente (di anagrafica);Intero;10",
			"datacar;Data di Carico;Data;8",
			"posseduto;Posseduto(S/N);Codificato;1;S|N",
			"includibuonocar;Da includere in buono di carico (S/N);Codificato;1;S|N",
			"codicetipobuonocar;Codice tipo buono carico;Stringa;20",
			"annobuonocar;Anno buono carico;Intero;4",
			"numbuonocar;Numero buono carico;Intero;8",
			"resp;Responsabile;Stringa;150",
			"codeubic;Codice ubicazione;Stringa;50",
			"subresp;SubConsegnatario;Stringa;150",
			"codiceupb;Codice UPB;Stringa;50",
			"includibuonoscar;Da includere in buono di scarico (S/N);Codificato;1;S|N",
			"codicetipobuonoscar;Codice tipo buono scarico;Stringa;20",
			"annobuonoscar;Anno buono scarico;Intero;4",
			"numbuonoscar;Numero buono scarico;Intero;8",
			"note;Note;Stringa;400",
			"intcode;Codice Listino;Stringa;50",
			"campiaggiuntivi;Campi Aggiuntivi Cespite;Stringa;4000",
			// Riferimenti alla riga del contratto passivo
			"codice_cpassivo;Codice tipo ordine;Stringa;20",
			"anno_cpassivo;Anno ordine;Intero;4",
			"numero_cpassivo;Numero ordine;Intero;8",
			"ngruppo_cpassivo;Numero gruppo ordine;Intero;6",
			"rfid;rfid;Stringa;30"
		};


		private void btnCespitiSorico_Click(object sender, EventArgs e) {
			ImportaCespitiConStoricoWithoutCheck();
		}

		bool ImportaCespitiConStoricoWithCheck() {
			return ImportaCespitiConStorico(true);
		}

		bool ImportaCespitiConStoricoWithoutCheck() {
			return ImportaCespitiConStorico(false);
		}

		bool ImportaCespitiConStorico(bool withCheck) {
			// Stessa funzione dell'importazione Cespite, ma in più importa
			// il valore storico del cespite
			LeggiFile Reader = GetReader(tracciato_cespitistorico);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaCespiti();


			DataTable AssetUnloadKind = D.Tables["assetunloadkind"];
			MetaData MetaAssetUnloadKind = Meta.Dispatcher.Get("assetunloadkind");
			MetaAssetUnloadKind.SetDefaults(AssetUnloadKind);

			DataTable AssetLoadKind = D.Tables["assetloadkind"];
			MetaData MetaAssetLoadKind = Meta.Dispatcher.Get("assetloadkind");
			MetaAssetLoadKind.SetDefaults(AssetLoadKind);


			DataTable Inventory = D.Tables["inventory"];
			MetaData MetaInventory = Meta.Dispatcher.Get("inventory");
			MetaInventory.SetDefaults(Inventory);

			DataTable InventoryAgency = D.Tables["inventoryagency"];
			MetaData MetaInventoryAgency = Meta.Dispatcher.Get("inventoryagency");
			MetaInventoryAgency.SetDefaults(InventoryAgency);

			DataTable InventoryKind = D.Tables["inventorykind"];
			MetaData MetaInventoryKind = Meta.Dispatcher.Get("inventorykind");
			MetaInventoryKind.SetDefaults(InventoryKind);

			DataTable InvTree = D.Tables["inventorytree"];
			MetaData MetaInvTree = Meta.Dispatcher.Get("inventorytree");
			MetaInvTree.SetDefaults(InvTree);

			DataTable AssetLoadMotive = D.Tables["assetloadmotive"];
			MetaData MetaAssetLoadMotive = Meta.Dispatcher.Get("assetloadmotive");
			MetaAssetLoadMotive.SetDefaults(AssetLoadMotive);

			DataTable Division = D.Tables["division"];
			MetaData MetaDivision = Meta.Dispatcher.Get("division");
			MetaDivision.SetDefaults(Division);


			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);

			DataTable Location = D.Tables["location"];
			MetaData MetaLocation = Meta.Dispatcher.Get("location");
			MetaLocation.SetDefaults(Location);

			DataTable AssetAcquire = D.Tables["assetacquire"];
			MetaData MetaAssetAcquire = Meta.Dispatcher.Get("locationassetacquire");
			MetaAssetAcquire.SetDefaults(AssetAcquire);

			DataTable Asset = D.Tables["asset"];
			MetaData MetaAsset = Meta.Dispatcher.Get("asset");
			MetaAsset.SetDefaults(Asset);


			DataTable AssetToLink = D.Tables["assettolink"];
			MetaData MetaAssetToLink = Meta.Dispatcher.Get("assettolink");
			MetaAsset.SetDefaults(AssetToLink);

			DataTable AssetView = D.Tables["assetview"];

			DataTable UPB = Conn.RUN_SELECT("upb", "idupb,codeupb", null, null, null, false);
			Dictionary<string, string> HUpb = new Dictionary<string, string>();
			foreach (DataRow r in UPB.Rows) {
				HUpb[r["codeupb"].ToString()] = r["idupb"].ToString();
			}


			Conn.RUN_SELECT_INTO_TABLE(D.Tables["list"], null, null, null, false);
			Dictionary<string, int> vociListino = new Dictionary<string, int>();
			foreach (DataRow r in D.Tables["list"].Select()) {
				vociListino[r["intcode"].ToString().ToLower()] = CfgFn.GetNoNullInt32(r["idlist"]);
			}

			Conn.RUN_SELECT_INTO_TABLE(AssetUnloadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryKind, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InventoryAgency, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(InvTree, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetLoadMotive, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Division, null, QHS.CmpEq("codedivision", "Fittizia"), null, false);
			Conn.RUN_SELECT_INTO_TABLE(AssetToLink, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("assetunloadkind");
			tosync.Add("assetloadkind");
			tosync.Add("inventoryagency");
			tosync.Add("inventory");
			tosync.Add("inventorytree");
			tosync.Add("assetloadmotive");
			tosync.Add("manager");
			tosync.Add("location");
			tosync.Add("division");
			tosync.Add("assettolink");
			InitSpeedSaver(Conn, tosync);




			Hashtable Hash_idasset = new Hashtable();

			object iddivision = DBNull.Value;
			if (Division.Rows.Count > 0) {
				iddivision = Division.Rows[0]["iddivision"];
			}
			else {
				DataRow NewDiv = MetaDivision.Get_New_Row(null, Division);
				NewDiv["description"] = "Fittizia";
				NewDiv["codedivision"] = "fittizia";
				iddivision = NewDiv["iddivision"];
			}

			int nmax_assetacquire = CfgFn.GetNoNullInt32(
				                        Conn.DO_READ_VALUE("assetacquire", null, "max(nassetacquire)")) + 1;

			int nmax_asset = CfgFn.GetNoNullInt32(
				                 Conn.DO_READ_VALUE("asset", null, "max(idasset)")) + 1;








			int num = 0;
			string codeinv_asset_prec = "";

			Reader.GetNext();
			while (Reader.DataPresent()) {
				string descrinv = Reader.getCurrField("descrinv").ToString();
				string codeinv = Reader.getCurrField("codiceinv").ToString();
				object ninventory = Reader.getCurrField("numinv");
				int idpiece = CfgFn.GetNoNullInt32(Reader.getCurrField("nprogr"));

				// numero dei cespiti elaborati >= 100 oppure cambio struttura inventariale
				if ((num >= 1000) || ((codeinv_asset_prec != codeinv) && (codeinv_asset_prec != ""))) {
					//Salva i dati
					num = 0;
					if (!SaveData(D, false)) break;
					D.Tables["assetacquire"].Clear();
					D.Tables["asset"].Clear(); // svuota asset e tabelle figlie
					D.Tables["assetlocation"].Clear();
					D.Tables["assetmanager"].Clear();
					D.Tables["assetsubmanager"].Clear();
				}


				if (withCheck) {
					int n_ex = Conn.RUN_SELECT_COUNT("assetview",
						QHS.AppAnd(QHS.CmpEq("ninventory", ninventory), QHS.CmpEq("codeinventory", codeinv),
							QHS.CmpEq("idpiece", idpiece)), false);
					if (n_ex > 0) {
						SpeedSaver.AddWarning("Cespite n." + ninventory + " dell'inventario di codice " + codeinv +
						                      " n.parte:" + idpiece.ToString() +
						                      " saltato perché già presente.");
						Reader.GetNext();
						continue;
					}
				}

				num++;

				int flag_assetacquire = 0;
				//bit 0= includi in buono carico
				//bit 1= cespite posseduto (0=nuovo)
				//bit 2= accessorio (0=cespite principale)
				string tipo = Reader.getCurrField("tipocespite").ToString().ToUpper();
				string posseduto = Reader.getCurrField("posseduto").ToString().ToUpper();
				if (tipo == "A") flag_assetacquire += 4;
				string includi_buonocar = Reader.getCurrField("includibuonocar").ToString().ToUpper();
				if (includi_buonocar == "S") flag_assetacquire += 1;
				if (posseduto == "S") flag_assetacquire += 2;

				int flag_asset = 0;
				//bit 0= includi in buono scarico
				//bit 1= cespite pronto per lo scarico
				string includi_buonoscar = Reader.getCurrField("includibuonoscar").ToString().ToUpper();
				if (includi_buonoscar == "S") flag_asset += 1;




				object yassetunload = Reader.getCurrField("annobuonoscar");
				object nassetunload = Reader.getCurrField("numbuonoscar");

				//Aggiunge le informazioni di Ente Inventariale ove necessario
				string descrinvag = Reader.getCurrField("descrinvagency").ToString();
				string codeinvag = Reader.getCurrField("codeinvagency").ToString();
				object idinventoryagency = CheckinventoryAgency(InventoryAgency, codeinvag, descrinvag);


				//Aggiunge le informazioni di Tipo Inventario ove necessario
				string descrinvkind = Reader.getCurrField("descrinvkind").ToString();
				string codeinvkind = Reader.getCurrField("codeinvkind").ToString();
				object idinvkind = CheckinventoryKind(InventoryKind, codeinvkind, descrinvkind);

				//Aggiunge le informazioni di inventario ove necessario
				object idinventory = Checkinventory(Inventory, codeinv, descrinv, idinventoryagency, idinvkind);

				object idmot = CheckAssetLoadMotive(AssetLoadMotive,
					Reader.getCurrField("codicecausalecar").ToString(),
					Reader.getCurrField("descrcausalecar").ToString());

				object manager = Reader.getCurrField("resp");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), iddivision, "N");



				object submanager = Reader.getCurrField("subresp");
				object idsubman = DBNull.Value;
				if (submanager != DBNull.Value) idsubman = GetManager(Manager, submanager.ToString(), iddivision);


				object idassetunload = DBNull.Value;
				object codeassetunloadkind = Reader.getCurrField("codicetipobuonoscar");
				if (codeassetunloadkind != DBNull.Value) {
					string filterassunloadkind = QHC.CmpEq("codeassetunloadkind", codeassetunloadkind);
					object idassetunloadkind = DBNull.Value;
					if (AssetUnloadKind.Select(filterassunloadkind).Length > 0) {
						idassetunloadkind = AssetUnloadKind.Select(filterassunloadkind)[0]["idassetunloadkind"];
						string filterassunload = QHS.AppAnd(
							QHS.CmpEq("idassetunloadkind", idassetunloadkind),
							QHS.CmpEq("yassetunload", yassetunload),
							QHS.CmpEq("nassetunload", nassetunload));
						idassetunload = Conn.DO_READ_VALUE("assetunload", filterassunload, "idassetunload");
						if (idassetunload == DBNull.Value || idassetunload == null) {
							SpeedSaver.AddError("Il buono di scarico " + codeassetunloadkind + "/" +
							                    nassetunload.ToString() + " del " + yassetunload.ToString() +
							                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						SpeedSaver.AddError("Il tipo buono di scarico " + codeassetunloadkind +
						                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
					}
				}


				object idassetload = DBNull.Value;
				object codeassetloadkind = Reader.getCurrField("codicetipobuonocar");
				object yassetload = Reader.getCurrField("annobuonocar");
				object nassetload = Reader.getCurrField("numbuonocar");
				idassetload = DBNull.Value;
				if (codeassetloadkind != DBNull.Value) {

					object idassetloadkind = GetidAssetLoadKind(AssetLoadKind, codeassetloadkind);
					if (idassetloadkind != DBNull.Value) {
						idassetload = GetidAssetLoad(idassetloadkind, yassetload, nassetload);
						if (idassetload == DBNull.Value || idassetload == null) {
							SpeedSaver.AddError("Il buono di carico " + codeassetloadkind + "/" +
							                    nassetload.ToString() + " del " + yassetload.ToString() +
							                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
						}
					}
					else {
						SpeedSaver.AddError("Il tipo buono di carico " + codeassetloadkind +
						                    " non è stato trovato. Riga:" + Reader.GetCurrRowNumber());
					}
				}


				object idinv = Checkidinvtree(InvTree, Reader.getCurrField("codiceclass").ToString());
				;
				if (idinv == DBNull.Value) {
					idinv = 0;
					SpeedSaver.AddError("Classificazione inventariale di codice " + Reader.getCurrField("codiceclass") +
					                    " non trovata per il cespite n. " + ninventory.ToString() +
					                    " dell'inventario " + codeinv.ToString() + " alla riga:" +
					                    Reader.GetCurrRowNumber());
				}

				object locationcode = Reader.getCurrField("codeubic");
				object idlocation = DBNull.Value;
				if (locationcode != DBNull.Value) {
					idlocation = CheckidLocation(Location, locationcode.ToString());

					if (idlocation == DBNull.Value) {
						SpeedSaver.AddError("Ubicazione di codice " + locationcode +
						                    " non trovata per il cespite n. " + ninventory.ToString()
						                    + " dell'inventario " + codeinv.ToString() +
						                    " alla riga:" + Reader.GetCurrRowNumber());
					}
				}

				// Aggiunge le informazioni relativi ai cambi di inventario
				// che hanno coinvolto il cespite
				// Cerco di individuare il cespite di provenienza e destinazione 
				// se è stato già salvato su DB

				//Ente Inventariale precedente
				string descrinvag_prec = Reader.getCurrField("descrinvagency_prec").ToString();
				string codeinvag_prec = Reader.getCurrField("codeinvagency_prec").ToString();
				object idinventoryagency_prec = DBNull.Value;
				if (codeinvag_prec != "")
					idinventoryagency_prec = CheckinventoryAgency(InventoryAgency, codeinvag_prec, descrinvag_prec);

				//Tipo Inventario precedente
				string descrinvkind_prec = Reader.getCurrField("descrinvkind_prec").ToString();
				string codeinvkind_prec = Reader.getCurrField("codeinvkind_prec").ToString();
				object idinvkind_prec = DBNull.Value;
				if (codeinvkind_prec != "")
					idinvkind_prec = CheckinventoryKind(InventoryKind, codeinvkind_prec, descrinvkind_prec);

				//Inventario precedente
				string descrinv_prec = Reader.getCurrField("descrinv_prec").ToString();
				string codeinv_prec = Reader.getCurrField("codiceinv_prec").ToString();
				object idinventory_prec = DBNull.Value;
				if (codeinv_prec != "")
					idinventory_prec = Checkinventory(Inventory, codeinv_prec, descrinv_prec,
						idinventoryagency_prec, idinvkind_prec);
				//
				//Ente Inventariale successivo
				string descrinvag_succ = Reader.getCurrField("descrinvagency_succ").ToString();
				string codeinvag_succ = Reader.getCurrField("codeinvagency_succ").ToString();
				object idinventoryagency_succ = DBNull.Value;
				if (codeinvag_succ != "")
					idinventoryagency_succ = CheckinventoryAgency(InventoryAgency, codeinvag_succ, descrinvag_succ);

				//Tipo Inventario successivo
				string descrinvkind_succ = Reader.getCurrField("descrinvkind_succ").ToString();
				string codeinvkind_succ = Reader.getCurrField("codeinvkind_succ").ToString();
				object idinvkind_succ = DBNull.Value;
				if (codeinvkind_succ != "")
					idinvkind_succ = CheckinventoryKind(InventoryKind, codeinvkind_succ, descrinvkind_succ);

				//Inventario successivo
				string descrinv_succ = Reader.getCurrField("descrinv_succ").ToString();
				string codeinv_succ = Reader.getCurrField("codiceinv_succ").ToString();
				object idinventory_succ = DBNull.Value;
				if (codeinv_succ != "")
					idinventory_succ = Checkinventory(Inventory, codeinv_succ, descrinv_succ,
						idinventoryagency_succ, idinvkind_succ);

				//Numero di inventario e progressivo accessorio di provenienza e di destinazione
				object ninventory_prec = Reader.getCurrField("numinv_prec");
				int idpiece_prec = CfgFn.GetNoNullInt32(Reader.getCurrField("nprogr_prec"));

				object ninventory_succ = Reader.getCurrField("numinv_succ");
				int idpiece_succ = CfgFn.GetNoNullInt32(Reader.getCurrField("nprogr_succ"));

				object description = Reader.getCurrField("descr");
				if (description == DBNull.Value) {
					description = '.';
				}

				object intCode = Reader.getCurrField("intcode");
				object idlist = DBNull.Value;
				if (intCode != DBNull.Value) {
					if (vociListino.ContainsKey(intCode.ToString().ToLower())) {
						idlist = vociListino[intCode.ToString().ToLower()];
					}
					else {
						SpeedSaver.AddError("Voce di listino di codice " + intCode +
						                    " non trovata per il cespite n. " + ninventory.ToString() +
						                    " dell'inventario " + codeinv.ToString() +
						                    " Riga:" + Reader.GetCurrRowNumber());
					}
				}

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (!HUpb.ContainsKey(codeupb)) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato. Riga:"
						                    + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					idupb = HUpb[codeupb];
				}

				DataRow NewAssetAcquire = AssetAcquire.NewRow();
				NewAssetAcquire["nassetacquire"] = nmax_assetacquire++;
				NewAssetAcquire["abatable"] = Reader.getCurrField("ivadetr");
				NewAssetAcquire["adate"] = ToSmalldateTime(Reader.getCurrField("datacar"));
				NewAssetAcquire["description"] = description;
				NewAssetAcquire["transmitted"] = "N";
				NewAssetAcquire["discount"] = Reader.getCurrField("scontoperc");
				NewAssetAcquire["idreg"] = Reader.getCurrField("codicecedente");
				NewAssetAcquire["startnumber"] = ninventory; //1 carico - 1 cespite pari numero
				NewAssetAcquire["number"] = 1;
				NewAssetAcquire["tax"] = CfgFn.GetNoNullDecimal(Reader.getCurrField("iva"));
				NewAssetAcquire["taxable"] = Reader.getCurrField("impon");
				NewAssetAcquire["taxrate"] = Reader.getCurrField("ivaperc");
				NewAssetAcquire["idinventory"] = idinventory;
				NewAssetAcquire["idupb"] = idupb;
				NewAssetAcquire["idmot"] = idmot;
				NewAssetAcquire["idinv"] = idinv;
				NewAssetAcquire["idlist"] = idlist;
				NewAssetAcquire["idassetload"] = idassetload;
				NewAssetAcquire["flag"] = flag_assetacquire;
				NewAssetAcquire["historicalvalue"] = Reader.getCurrField("valorestorico");
				NewAssetAcquire["ct"] = DateTime.Now;
				NewAssetAcquire["lt"] = DateTime.Now;
				NewAssetAcquire["cu"] = "importazione";
				NewAssetAcquire["lu"] = "importazione";

				if (Reader.getCurrField("codice_cpassivo") != DBNull.Value) {
					object idmankind = Reader.getCurrField("codice_cpassivo");
					object yman = Reader.getCurrField("anno_cpassivo");
					object nman = Reader.getCurrField("numero_cpassivo");
					object idgroup = Reader.getCurrField("ngruppo_cpassivo");

					string filterman = QHS.AppAnd(
						QHS.CmpEq("idmankind", idmankind), QHS.CmpEq("yman", yman),
						QHS.CmpEq("nman", nman), QHS.CmpEq("idgroup", idgroup));
					if (Conn.RUN_SELECT_COUNT("mandatedetail", filterman, false) == 0) {
						SpeedSaver.AddError("Dettaglio ordine  non trovato con filtro: " + filterman
						                                                                 + " alla riga " +
						                                                                 Reader.GetCurrRowNumber());

					}

					NewAssetAcquire["idmankind"] = idmankind;
					NewAssetAcquire["yman"] = yman;
					NewAssetAcquire["nman"] = nman;
					NewAssetAcquire["rownum"] = idgroup;
				}

				AssetAcquire.Rows.Add(NewAssetAcquire);


				DataRow NewAsset = Asset.NewRow();
				string hashkey = ninventory.ToString() + "/" + codeinv;
				object idasset = DBNull.Value;
				if (idpiece == 1) {
					idasset = nmax_asset++;
					Hash_idasset[hashkey] = idasset;
				}
				else {
					if (Hash_idasset[hashkey] != null) {
						idasset = Hash_idasset[hashkey];
					}
					else {
						idasset = Conn.DO_READ_VALUE("assetview",
							QHS.AppAnd(QHS.CmpEq("ninventory", ninventory),
								QHS.CmpEq("idinventory", idinventory),
								QHS.CmpEq("idpiece", 1)), "idasset");
						if (idasset == null || idasset == DBNull.Value) {
							SpeedSaver.AddError(
								"E' necessario ordinare i cespiti in modo che gli accessori seguano i " +
								"cespiti principali. Problema con l'accessorio " +
								ninventory.ToString() + "-" + idpiece.ToString() + "/" + codeinv +
								" dell'inventario di codice " + idinventory +
								" alla riga:" + Reader.GetCurrRowNumber());
							Reader.GetNext();
							continue;
						}
					}
				}

				// Cerco nel DB prima il cespite eventuale di destinazione 
				// Se esiste allora effettuo un inserimento nel DataTable, valorizzando idasset_prev e idpiece_prev
				object idasset_successivo = DBNull.Value;
				object idpiece_successivo = DBNull.Value;

				if (codeinv_succ != "") {

					/*
					  string filter_succ = QHS.AppAnd(QHS.CmpEq("codeinventory", codeinv_succ),
					                                QHS.CmpEq("ninventory", ninventory_succ),
					                                QHS.CmpEq("idpiece", idpiece_succ));
					if (Conn.RUN_SELECT_COUNT("assetview", filter_succ, false) > 0) {
					    idasset_successivo = Conn.DO_READ_VALUE("assetview", filter_succ, "idasset");
					    idpiece_successivo = Conn.DO_READ_VALUE("assetview", filter_succ, "idpiece");
					    string filter_asset_succ = QHC.AppAnd(QHC.CmpEq("idasset", idasset_successivo),
					                                          QHC.CmpEq("idpiece", idpiece_successivo));
					    Conn.RUN_SELECT_INTO_TABLE(Asset, null, filter_asset_succ, null, false);
					    // Verifico che sia presente invece in memoria
					    DataRow[] Asset_Succ = Asset.Select(filter_asset_succ);
					    if (Asset_Succ.Length > 0) {
					        Asset_Succ[0]["idasset_prev"] = idasset;
					        Asset_Succ[0]["idpiece_prev"] = idpiece;
					    }
					}
					// Verifico che il successivo sia presente invece in memoria  
					// perchè appartenente alla stessa struttura: 
					// (trattasi di cambio del solo numero inventario pertanto potrebbe rientrare
					// nell'attuale ciclo di elaborazione se non è stato già salvato sul db)
					else
					    if (codeinv == codeinv_succ) {
					        filter_succ = QHS.AppAnd(QHS.CmpEq("codeinventory", codeinv_succ),
					                                 QHS.CmpEq("ninventory", ninventory_succ),
					                                 QHS.CmpEq("idpiece", idpiece_succ));
					        DataRow[] Asset_Succ = Asset.Select(filter_succ);
					        if (Asset_Succ.Length > 0) {
					            Asset_Succ[0]["idasset_prev"] = idasset;
					            Asset_Succ[0]["idpiece_prev"] = idpiece;
					        }
					    }
					  */
					DataRow NewAssetToLink = AssetToLink.NewRow();
					NewAssetToLink["idasset"] = idasset;
					NewAssetToLink["idpiece"] = idpiece;
					NewAssetToLink["ninventory_tolink"] = ninventory_succ;
					NewAssetToLink["idpiece_tolink"] = idpiece_succ;
					NewAssetToLink["idinventory_tolink"] = idinventory_succ;
					NewAssetToLink["kind"] = "T";
					NewAssetToLink["ct"] = DateTime.Now;
					NewAssetToLink["cu"] = "importazione";
					NewAssetToLink["lt"] = DateTime.Now;
					NewAssetToLink["lu"] = "importazione";
					D.Tables["assettolink"].Rows.Add(NewAssetToLink);
				}

				object idasset_precedente = DBNull.Value;
				object idpiece_precedente = DBNull.Value;

				if (codeinv_prec != "") {
					/*
					string filter_prec = QHS.AppAnd(QHS.CmpEq("codeinventory", codeinv_prec),
					                                QHS.CmpEq("ninventory", ninventory_prec),
					                                QHS.CmpEq("idpiece", idpiece_prec));
					string filter_prec_dataset = QHC.AppAnd(QHC.CmpEq("codeinventory", codeinv_prec),
					                              QHC.CmpEq("ninventory", ninventory_prec),
					                              QHC.CmpEq("idpiece", idpiece_prec));

					if (Conn.RUN_SELECT_COUNT("assetview", filter_prec, false) > 0) {
					    idasset_precedente = Conn.DO_READ_VALUE("assetview", filter_prec, "idasset");
					    idpiece_precedente = Conn.DO_READ_VALUE("assetview", filter_prec, "idpiece");
					}
					else {
					    // Verifico che il precedente sia presente invece in memoria 
					    // perchè appartenente  alla stessa struttura: 
					    // (trattasi di cambio del solo numero inventario pertanto potrebbe rientrare
					    // nell'attuale ciclo di elaborazione se non è stato già salvato sul db)
					    if (codeinv == codeinv_prec) {
					        DataRow[] Asset_Prec = Asset.Select(filter_prec_dataset);
					        if (Asset_Prec.Length > 0) {
					            idasset_precedente = Asset_Prec[0]["idasset"];
					            idpiece_precedente = Asset_Prec[0]["idpiece"];
					        }
					    }
					}
					 * */
					DataRow NewAssetToLink = AssetToLink.NewRow();
					NewAssetToLink["idasset"] = idasset;
					NewAssetToLink["idpiece"] = idpiece;
					NewAssetToLink["ninventory_tolink"] = ninventory_prec;
					NewAssetToLink["idpiece_tolink"] = idpiece_prec;
					NewAssetToLink["idinventory_tolink"] = idinventory_prec;
					NewAssetToLink["kind"] = "F";
					NewAssetToLink["ct"] = DateTime.Now;
					NewAssetToLink["cu"] = "importazione";
					NewAssetToLink["lt"] = DateTime.Now;
					NewAssetToLink["lu"] = "importazione";
					D.Tables["assettolink"].Rows.Add(NewAssetToLink);
				}

				NewAsset["idasset"] = idasset;
				NewAsset["idpiece"] = idpiece;
				NewAsset["idasset_prev"] = idasset_precedente;
				NewAsset["idpiece_prev"] = idpiece_precedente;
				NewAsset["lifestart"] = Reader.getCurrField("inizioesist");
				NewAsset["nassetacquire"] = NewAssetAcquire["nassetacquire"];
				NewAsset["ninventory"] = ninventory;
				NewAsset["idinventory"] = idinventory;
				NewAsset["transmitted"] = "N";
				NewAsset["idassetunload"] = idassetunload;
				NewAsset["multifield"] = Reader.getCurrField("campiaggiuntivi");
				;
				NewAsset["flag"] = flag_asset;
				NewAsset["ct"] = DateTime.Now;
				NewAsset["lt"] = DateTime.Now;
				NewAsset["cu"] = "importazione";
				NewAsset["lu"] = "importazione";
				NewAsset["txt"] = Reader.getCurrField("note").ToString();

				NewAsset["rfid"] = Reader.getCurrField("rfid");


				//Aggiunge il collegamento a ubicazione ove necessario
				if (idlocation != DBNull.Value && tipo == "C") {
					DataRow NewAssetLocation = D.Tables["assetlocation"].NewRow();
					NewAssetLocation["idassetlocation"] = 1;
					NewAssetLocation["idasset"] = idasset;
					NewAssetLocation["idlocation"] = idlocation;
					NewAssetLocation["ct"] = DateTime.Now;
					NewAssetLocation["lt"] = DateTime.Now;
					NewAssetLocation["cu"] = "importazione";
					NewAssetLocation["lu"] = "importazione";
					// Aggiorno la location corrente in Asset
					NewAsset["idcurrlocation"] = idlocation;
					D.Tables["assetlocation"].Rows.Add(NewAssetLocation);
				}

				//Aggiunge il collegamento al responsabile ove necessario
				if (idman != DBNull.Value && tipo == "C") {
					DataRow NewAssetManager = D.Tables["assetmanager"].NewRow();
					NewAssetManager["idassetmanager"] = 1;
					NewAssetManager["idasset"] = idasset;
					NewAssetManager["idman"] = idman;
					NewAssetManager["ct"] = DateTime.Now;
					NewAssetManager["lt"] = DateTime.Now;
					NewAssetManager["cu"] = "importazione";
					NewAssetManager["lu"] = "importazione";
					// Aggiorno responsabile corrente in Asset
					NewAsset["idcurrman"] = idman;
					D.Tables["assetmanager"].Rows.Add(NewAssetManager);
				}

				//Aggiunge il collegamento al subconsegnatario ove necessario
				if (idsubman != DBNull.Value && tipo == "C") {
					DataRow NewAssetSubManager = D.Tables["assetsubmanager"].NewRow();
					NewAssetSubManager["idassetsubmanager"] = 1;
					NewAssetSubManager["idasset"] = idasset;
					NewAssetSubManager["idmanager"] = idsubman;
					NewAssetSubManager["ct"] = DateTime.Now;
					NewAssetSubManager["lt"] = DateTime.Now;
					NewAssetSubManager["cu"] = "importazione";
					NewAssetSubManager["lu"] = "importazione";
					// Aggiorno sub consegnatario corrente in Asset
					NewAsset["idcurrsubman"] = idsubman;
					D.Tables["assetsubmanager"].Rows.Add(NewAssetSubManager);
				}

				Asset.Rows.Add(NewAsset);

				//if (some_error)
				//{
				//    Reader.Close();
				//    SpeedSaver.AddError("Dati non salvati a causa degli errori");

				//    return;
				//}
				codeinv_asset_prec = codeinv;
				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				return ShowMessages();
			}

			if (num > 0) {
				//Salva i dati
				if (!SaveData(D, true)) return false;
				D.Tables["asset"].Clear(); // svuota asset e tabelle figlie
				D.Tables["assetlocation"].Clear();
				D.Tables["assetmanager"].Clear();
			}

			if (AssetToLink.Select().Length > 0) {
				string deleteDoppioni = " DELETE FROM ASSETTOLINK WHERE " +
				                        " (SELECT COUNT(*) FROM ASSETTOLINK AS A " +
				                        " WHERE ASSETTOLINK.idinventory_tolink = A.idinventory_tolink " +
				                        " AND   ASSETTOLINK.ninventory_tolink  = A.ninventory_tolink " +
				                        " AND   ASSETTOLINK.idpiece_tolink     = A.idpiece_tolink " +
				                        " AND   ASSETTOLINK.kind = A.kind " +
				                        " ) >1 ";
				Conn.SQLRunner(deleteDoppioni);

			}

			DataRow[] AssetToLink_Succ = AssetToLink.Select(QHC.CmpEq("kind", "T"));
			if (AssetToLink_Succ.Length > 0) {
				string updateTo = " UPDATE 	ASSET  " +
				                  " SET 	ASSET.idasset_prev = ASSETTOLINK.idasset, " +
				                  " ASSET.idpiece_prev = ASSETTOLINK.idpiece " +
				                  " FROM  	ASSETTOLINK " +
				                  " JOIN  	ASSET ASSETLINKED " +
				                  " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
				                  " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
				                  " JOIN  ASSETACQUIRE ASSETACQUIRELINKED " +
				                  " ON  ASSETACQUIRELINKED.nassetacquire = ASSETLINKED.nassetacquire " +
				                  " AND  ASSETACQUIRELINKED.idinventory = ASSETTOLINK.idinventory_tolink " +
				                  " WHERE KIND = 'T'";
				Conn.SQLRunner(updateTo);
			}

			DataRow[] AssetToLink_Prec = AssetToLink.Select(QHC.CmpEq("kind", "F"));
			if (AssetToLink_Prec.Length > 0) {
				string updateFrom = " UPDATE 	ASSET  " +
				                    " SET 	ASSET.idasset_prev = ASSETLINKED.idasset, " +
				                    " ASSET.idpiece_prev = ASSETLINKED.idpiece " +
				                    " FROM  	ASSETVIEW ASSETLINKED " +
				                    " JOIN  	ASSETTOLINK " +
				                    " ON ASSETLINKED.idpiece = ASSETTOLINK.idpiece_tolink " +
				                    " AND ASSETLINKED.ninventory = ASSETTOLINK.ninventory_tolink " +
				                    " AND ASSETLINKED.idinventory = ASSETTOLINK.idinventory_tolink  " +
				                    " WHERE ASSETTOLINK.KIND = 'F' AND " +
				                    " ASSETTOLINK.idasset =  ASSET.idasset  AND " +
				                    " ASSETTOLINK.idpiece =  ASSET.idpiece  AND " +
				                    " ASSET.idasset_prev IS NULL ";
				Conn.SQLRunner(updateFrom);
			}

			return true;
		}

		//private void EsportaDati(object sender, EventArgs e) {
		//    if (sender == null) return;
		//    if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
		//    object mysender = ((MenuItem)sender).Parent.GetContextMenu().SourceControl;
		//    string tracciato = "";
		//    foreach (ImportButton Ib in AllButton) {
		//        if (mysender == Ib.Btn) {
		//            tracciato = GetTracciato(Ib.tracciato);
		//            break;
		//        }
		//    }

		//    FrmShowTracciato FT = new FrmShowTracciato(tracciato, "struttura");
		//    FT.ShowDialog();
		//}


		string[] tracciato_cessati = new string[] {
			"idmanager;Codice responsabile dip. origine;Intero;6",
			"diporigine;Codice Dip. Origine;Stringa;50",
			"dipdest;Codice Dip. Destinazione;Stringa;50",
			"title;Denominazione responsabile;Stringa;150"
		};


		private void btnCessati_Click(object sender, EventArgs e) {
			ImportaCessati();
		}

		bool ImportaCessati() {
			LeggiFile Reader = GetReader(tracciato_cessati);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaCessati();


			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);

			List<string> tosync = new List<string>();
			tosync.Add("manager");
			InitSpeedSaver(Conn, tosync);



			DataTable Lookup_Manager = D.Tables["lookup_manager"];

			int num = 0;
			Reader.GetNext();
			while (Reader.DataPresent()) {
				object idmanager = Reader.getCurrField("idmanager");
				string diporigine = Reader.getCurrField("diporigine").ToString();
				string dipdest = Reader.getCurrField("dipdest").ToString();
				string title = Reader.getCurrField("title").ToString();
				object idman = DBNull.Value;

				string filter = QHC.CmpEq("idman", idmanager);
				DataRow[] found = Manager.Select(filter);
				if (found.Length == 0) {
					SpeedSaver.AddError("Responsabile di codice " + idmanager.ToString() +
					                    " non trovato nel dipartimento corrente. Riga:" + Reader.GetCurrRowNumber());
				}
				else {
					string mytitle = found[0]["title"].ToString();
					if (mytitle.ToLower() == title.ToLower()) {
						idman = idmanager;
					}
					else {
						SpeedSaver.AddError("Il responsabile di codice " + idmanager.ToString() +
						                    " ha una descrizione (" + mytitle +
						                    ") diversa da quella del file importato (" + title + "). Riga:"
						                    + Reader.GetCurrRowNumber());
					}
				}

				if (idman != DBNull.Value) {
					DataRow NewManLookup = Lookup_Manager.NewRow();
					NewManLookup["idmanager"] = idman;
					NewManLookup["diporigine"] = diporigine;
					NewManLookup["dipdest"] = dipdest;
					NewManLookup["title"] = title;
					Lookup_Manager.Rows.Add(NewManLookup);
					num++;
				}



				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		private void btnImportaOrdini_Click(object sender, EventArgs e) {
			ImportaCPassivi();
		}

		private void tabControl1_SelectionChanged(object sender, EventArgs e) {

		}

		bool BatchIsRunning = false;
		bool BatchMustStop = false;

		private void btnAvviaBatch_Click(object sender, EventArgs e) {
			btnAvviaBatch.Visible = false;
			try {
				btnInterrompiBatch.Visible = true;
				BatchMustStop = false;
				BatchIsRunning = true;
				EseguiBatch();
			}
			finally {
				SpeedSaver.ClearErrorContext();
				BatchIsRunning = false;
				BatchMustStop = false;
				btnAvviaBatch.Visible = true;
				btnInterrompiBatch.Visible = false;
			}

		}

		private void btnInterrompiBatch_Click(object sender, EventArgs e) {
			if (BatchIsRunning) BatchMustStop = true;
			btnInterrompiBatch.Visible = false;
		}

		/// <summary>
		/// Restituisce true se OK
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		bool ExecuteImport(string code) {
			code = code.Trim();
			foreach (ImportButton IB in AllButton) {
				if (IB.tag == code) return IB.Fun();
			}

			MessageBox.Show("Funzione di importazione " + code + " non riconosciuta nel batch.", "Errore");
			return false;
		}

		//string lastdep = "-";

		void EseguiBatch() {
			DataAccess SavedConn = Conn;
			StringReader SR = new StringReader(txtBatch.Text);
			string line = SR.ReadLine();
			while (line != null) {
				line = line.Trim();
				if (line == "") {
					line = SR.ReadLine();
					continue;
				}

				txtLastLine.Text = line;
				SpeedSaver.SetErrorContext(line);
				bool res = EseguiRigaBatch(line);
				if (!res) break;
				GC.Collect();
				Application.DoEvents();
				if (BatchMustStop) {
					MessageBox.Show("Batch interrotto dall'utente.", "Avviso");
					break;
				}

				line = SR.ReadLine();
			}

			SR.Close();

			Conn = SavedConn;
		}

		DataAccess GetDataAccess(string user, string pwd, string dep) {
			string errore;
			string dettaglio;
			Easy_DataAccess Dest = Easy_DataAccess.getEasyDataAccess("Source DB",
				/* server*/ Meta.Conn.GetSys("server").ToString(),
				/* database */ Meta.Conn.GetSys("database").ToString(),
				user, pwd, null, dep,
				Convert.ToInt32(Meta.Conn.GetSys("esercizio")),
				Convert.ToDateTime(Meta.Conn.GetSys("datacontabile"))
				, out errore, out dettaglio);
			if (Dest == null || errore != null) {
				QueryCreator.ShowError(this, errore, dettaglio);
				if (Dest != null) Dest.Destroy();
				return null;
			}

			return Dest;
		}

		void ClearAllNonDBOHash() {
			if (hManager != null) {
				hManager.Clear();
				hManager = null;
			}

			if (hashLocation != null) {
				hashLocation.Clear();
				hashLocation = null;
			}

			if (hashFinVarKind != null) {
				hashFinVarKind.Clear();
				hashFinVarKind = null;
			}

			if (hUnderwriter != null) {
				hUnderwriter.Clear();
				hUnderwriter = null;
			}

			if (hashInventory != null) {
				hashInventory.Clear();
				hashInventory = null;
			}

			if (hashInventoryAgency != null) {
				hashInventoryAgency.Clear();
				hashInventoryAgency = null;
			}


			if (hashInventoryKind != null) {
				hashInventoryKind.Clear();
				hashInventoryKind = null;
			}

			if (hashAssetLoadKind != null) {
				hashAssetLoadKind.Clear();
				hashAssetLoadKind = null;
			}

			if (hashAssetUnloadKind != null) {
				hashAssetUnloadKind.Clear();
				hashAssetUnloadKind = null;
			}

			if (hPayTrasm != null) {
				hPayTrasm.Clear();
				hPayTrasm = null;
			}

			if (hProcTrasm != null) {
				hProcTrasm.Clear();
				hProcTrasm = null;
			}



			if (hAssUnload != null) {
				hAssUnload.Clear();
				hAssUnload = null;
			}

			if (hAssLoad != null) {
				hAssLoad.Clear();
				hAssLoad = null;
			}

			if (hFin != null) {
				hFin.Clear();
				hFin = null;
			}

			if (hashMandateKind != null) {
				hashMandateKind.Clear();
				hashMandateKind = null;
			}

			if (hashEstimateKind != null) {
				hashEstimateKind.Clear();
				hashEstimateKind = null;
			}

			if (hashIvaKind != null) {
				hashIvaKind.Clear();
				hashIvaKind = null;
			}

			if (hashInvoiceKind != null) {
				hashInvoiceKind.Clear();
				hashInvoiceKind = null;
			}

			if (hashIvaRegisterKind != null) {
				hashIvaRegisterKind.Clear();
				hashIvaRegisterKind = null;
			}


			if (hTreasurer != null) {
				hTreasurer.Clear();
				hTreasurer = null;
			}

			if (hConto != null) {
				hConto.Clear();
				hConto = null;
			}

			if (hAccount != null) {
				hAccount.Clear();
				hAccount = null;
			}

			//DBO
			if (hStamp != null) {
				hStamp.Clear();
				hStamp = null;
			}

			if (hashAccMotive != null) {
				hashAccMotive.Clear();
				hashAccMotive = null;
			}

			if (hashInvTree != null) {
				hashInvTree.Clear();
				hashInvTree = null;
			}

			if (hashAssetLoadMotive != null) {
				hashAssetLoadMotive.Clear();
				hashAssetLoadMotive = null;
			}

			if (hashAssetUnloadMotive != null) {
				hashAssetUnloadMotive.Clear();
				hashAssetUnloadMotive = null;
			}


			if (hashCentralizedCategory != null) {
				hashCentralizedCategory.Clear();
				hashCentralizedCategory = null;
			}

			if (hashRegistryKind != null) {
				hashRegistryKind.Clear();
				hashRegistryKind = null;
			}

			if (hashAddress != null) {
				hashAddress.Clear();
				hashAddress = null;
			}






		}

		/// <summary>
		/// Restituisce TRUE se ok
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		bool EseguiRigaBatch(string line) {
			int pos1 = line.IndexOf(';');
			if (pos1 < 0) {
				MessageBox.Show("Errore: comando batch " + line + " malformato.", "Errore");
				return false;
			}

			int pos2 = line.IndexOf(';', pos1 + 1);
			if (pos2 < 0 || pos2 == pos1 + 1) {
				MessageBox.Show("Errore: comando batch " + line + " malformato.", "Errore");
				return false;
			}

			string codicedip = line.Substring(0, pos1);
			string codicefun = line.Substring(pos1 + 1, (pos2 - pos1) - 1);
			//if (codicedip != lastdep) {
			ClearAllNonDBOHash();
			//  lastdep = codicedip;
			//}

			//Cambia la variabile Conn del form con una nuova connessione
			Conn = GetDataAccess(txtNomeBatch.Text, txtPasswordBatch.Text, codicedip);
			if (Conn == null) return false;

			txtSPName.Text = line.Substring(pos2 + 1);
			chkStoredProcedure.Checked = true;
			bool res = ExecuteImport(codicefun);
			txtSPName.Text = "";
			chkStoredProcedure.Checked = false;

			//distrugge questa nuova connessione
			if (Conn != null) {
				Conn.Close();
				Conn.Destroy();
				Conn = null;
			}

			return res;
		}

		private void btnIndirizzi_Click(object sender, EventArgs e) {
			ImportaIndirizzi();
		}

		bool ImportaIndirizzi() {

			vistaIndirizzi D = new vistaIndirizzi();

			LeggiFile Reader = GetReader(tracciato_indirizzi);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			MetaData MetaRegistryAddress = Meta.Dispatcher.Get("registryaddress");
			MetaRegistryAddress.SetDefaults(D.Tables["registryaddress"]);
			DataTable RegistryAddress = D.Tables["registryaddress"];
			DataTable Address = D.Tables["address"];
			Conn.RUN_SELECT_INTO_TABLE(Address, null, null, null, false);

			DataTable Nation = Conn.RUN_SELECT("geo_nation", "*", null, QHS.IsNull("stop"), null, false);
			Hashtable HNation = new Hashtable();
			foreach (DataRow RNation in Nation.Rows) {
				HNation[RNation["title"].ToString().ToUpper()] = RNation["idnation"];
			}

			List<string> to_sync = new List<string>();
			to_sync.Add("address");
			InitSpeedSaver(Conn, to_sync);


			Reader.GetNext();

			int num = 0;
			while (Reader.DataPresent()) {
				bool err = false;
				foreach (string fieldreq in new string[] {"codicetipoind", "codice", "datastart"}) {
					if (Reader.getCurrField(fieldreq) == DBNull.Value) {
						SpeedSaver.AddError("Il campo " + fieldreq + " è vuoto alla riga:" + Reader.GetCurrRowNumber() +
						                    ".");
						err = true;
						break;
					}
				}

				if (err) {
					Reader.GetNext();
					continue;
				}

				object codice = Reader.getCurrField("codice");
				object idaddresskind = GetAddress(Address, Reader.getCurrField("codicetipoind").ToString(),
					Reader.getCurrField("descrtipoind").ToString());
				MetaData.SetDefault(RegistryAddress, "idaddresskind", idaddresskind);
				MetaData.SetDefault(RegistryAddress, "idreg", codice);
				MetaData.SetDefault(RegistryAddress, "start", Reader.getCurrField("datastart"));
				DataRow RegAddr = MetaRegistryAddress.Get_New_Row(null, RegistryAddress);
				RegAddr["active"] = Reader.getCurrField("attivo");
				RegAddr["stop"] = Reader.getCurrField("datastop");
				RegAddr["address"] = Reader.getCurrField("indirizzo");
				RegAddr["annotations"] = Reader.getCurrField("annotazioni");
				RegAddr["cap"] = Reader.getCurrField("cap");
				object nazione = Reader.getCurrField("nazione");
				if (nazione.ToString() == "") {
					object idcity = DBNull.Value;
					object idnation = DBNull.Value;

					object cat = Reader.getCurrField("catastale");
					GetCatastale(codice.ToString(), cat, out idcity, out idnation);
					RegAddr["idcity"] = idcity;
					RegAddr["idnation"] = idnation;
					if (idnation != DBNull.Value) {
						RegAddr["flagforeign"] = "S";
					}
					else {
						RegAddr["flagforeign"] = "N";
					}

				}
				else {
					RegAddr["flagforeign"] = "S";
					object idnation = HNation[nazione.ToString().ToUpper()];
					if (idnation != null) {
						RegAddr["idnation"] = idnation;
					}
					else {
						SpeedSaver.AddError("Nazione: " + nazione.ToString() + " non trovata  alla riga " +
						                    Reader.GetCurrRowNumber().ToString());
						idnation = DBNull.Value;

					}
				}

				RegAddr["officename"] = Reader.getCurrField("ufficio");
				RegAddr["stop"] = Reader.getCurrField("datastop");
				RegAddr["location"] = Reader.getCurrField("localita");
				RegAddr["recipientagency"] = Reader.getCurrField("enteprovenienza");
				RegAddr["location"] = Reader.getCurrField("localita");

				RegAddr["cu"] = "Importazione";
				RegAddr["lu"] = "Importazione";


				if (num >= 1000) {
					//Salva i dati
					num = 0;
					if (!SaveData(D, false)) break;
					;
					D.Tables["registryaddress"].Clear();
				}

				num++;
				Reader.GetNext();
			}

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		private void btnModPagamento_Click(object sender, EventArgs e) {
			ImportaModPagamento();
		}

		bool ImportaModPagamento() {

			vistaModPagamento D = new vistaModPagamento();

			LeggiFile Reader = GetReader(tracciato_modpag);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataTable Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
			Hashtable Hcur = new Hashtable();
			foreach (DataRow RCC in Currency.Select())
				Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

			MetaData MetaRegistryPayM = Meta.Dispatcher.Get("registrypaymethod");
			MetaRegistryPayM.SetDefaults(D.Tables["registrypaymethod"]);
			DataTable RegistryPayM = D.Tables["registrypaymethod"];

			List<string> to_sync = new List<string>();
			InitSpeedSaver(Conn, to_sync);


			Reader.GetNext();
			int num = 0;
			while (Reader.DataPresent()) {
				bool err = false;
				foreach (string fieldreq in new string[] {"codice"}) {
					if (Reader.getCurrField(fieldreq) == DBNull.Value) {
						SpeedSaver.AddError("Il campo " + fieldreq + " è vuoto alla riga:" + Reader.GetCurrRowNumber() +
						                    ".");
						err = true;
						break;
					}
				}

				if (err) {
					Reader.GetNext();
					continue;
				}

				object codice = Reader.getCurrField("codice");
				MetaData.SetDefault(D.Tables["registrypaymethod"], "idreg", CfgFn.GetNoNullInt32(codice));
				DataRow RP = MetaRegistryPayM.Get_New_Row(null, D.Tables["registrypaymethod"]);
				RP["idpaymethod"] = Reader.getCurrField("tipomodpag");
				RP["regmodcode"] = Reader.getCurrField("nomemod");
				RP["paymentdescr"] = Reader.getCurrField("descrmod");
				RP["idbank"] = Reader.getCurrField("abi");
				RP["idcab"] = Reader.getCurrField("cab");
				RP["cin"] = Reader.getCurrField("cin");
				RP["cc"] = Reader.getCurrField("cc");
				RP["biccode"] = Reader.getCurrField("bic");
				RP["active"] = "S";
				RP["flagstandard"] = "S";
				RP["iddeputy"] = Reader.getCurrField("delegato");
				object codecurrency = Reader.getCurrField("valuta");
				if (codecurrency == DBNull.Value) codecurrency = "EUR";
				if (Hcur[codecurrency.ToString().ToUpper()] == null) {
					SpeedSaver.AddError("Codice valuta:" + codecurrency + " non trovato alla riga " +
					                    Reader.GetCurrRowNumber());
				}
				else {
					RP["idcurrency"] = Hcur[codecurrency.ToString().ToUpper()];
				}

				RP["idexpirationkind"] = Reader.getCurrField("codexpirationkind");
				RP["paymentexpiring"] = Reader.getCurrField("ggscadenza");
				RP["iban"] = Reader.getCurrField("iban");
				RP["extracode"] = Reader.getCurrField("extracode");
				RP["refexternaldoc"] = Reader.getCurrField("refexternaldoc");
				RP["txt"] = Reader.getCurrField("txt");
				RP["active"] = Reader.getCurrField("attivo");
				RP["flagstandard"] = Reader.getCurrField("flagstandard");

				RP["cu"] = "Importazione";
				RP["lu"] = "Importazione";


				if (num >= 1000) {
					//Salva i dati
					num = 0;
					if (!SaveData(D, false)) break;
					;
					D.Tables["registrypaymethod"].Clear();
				}

				num++;

				Reader.GetNext();
			}

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;


		}

		private void btnContatti_Click(object sender, EventArgs e) {
			ImportaContatti();
		}

		bool ImportaContatti() {

			vistaContatti D = new vistaContatti();

			LeggiFile Reader = GetReader(tracciato_contatti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			MetaData MetaRegistryReference = Meta.Dispatcher.Get("registryreference");
			MetaRegistryReference.SetDefaults(D.Tables["registryreference"]);
			DataTable RegistryPayM = D.Tables["registryreference"];

			List<string> to_sync = new List<string>();
			InitSpeedSaver(Conn, to_sync);

			Reader.GetNext();

			while (Reader.DataPresent()) {
				bool err = false;
				foreach (string fieldreq in new string[] {"codice"}) {
					if (Reader.getCurrField(fieldreq) == DBNull.Value) {
						SpeedSaver.AddError("Il campo " + fieldreq + " è vuoto alla riga:" + Reader.GetCurrRowNumber() +
						                    ".");
						err = true;
						break;
					}
				}

				if (err) {
					Reader.GetNext();
					continue;
				}

				object codice = Reader.getCurrField("codice");
				MetaData.SetDefault(D.Tables["registryreference"], "idreg", CfgFn.GetNoNullInt32(codice));
				DataRow RP = MetaRegistryReference.Get_New_Row(null, D.Tables["registryreference"]);
				if (Reader.getCurrField("nomecontatto") != DBNull.Value) {
					RP["referencename"] = Reader.getCurrField("nomecontatto");
				}

				RP["email"] = Reader.getCurrField("email");
				RP["faxnumber"] = Reader.getCurrField("fax");
				RP["phonenumber"] = Reader.getCurrField("telefono");

				object flagdefault = DBNull.Value;
				if (Reader.getCurrField("predefinito").ToString().ToUpper() == "S")
					flagdefault = "S";
				else
					flagdefault = "N";

				RP["flagdefault"] = flagdefault; //TASK 10698

				RP["cu"] = "Importazione";
				RP["lu"] = "Importazione";

				Reader.GetNext();
			}

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		private void btnImportaAliquote_Click(object sender, EventArgs e) {
			ImportaAliquoteIVA();
		}

		bool ImportaAliquoteIVA() {
			vistaAliquoteIVA D = new vistaAliquoteIVA();

			LeggiFile Reader = GetReader(tracciato_aliquoteiva);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			MetaData MetaIvaKind = Meta.Dispatcher.Get("ivakind");
			MetaIvaKind.SetDefaults(D.Tables["ivakind"]);
			DataTable IvaKind = D.Tables["ivakind"];

			List<string> to_sync = new List<string>();
			InitSpeedSaver(Conn, to_sync);

			Reader.GetNext();
			/*
			"applicabilita_italia; Applicabilità in Fatture: italia;Codificato;1;S|N",
			"applicabilita_intraue; Applicabilità in Fatture: intraUE;Codificato;1;S|N",
			"applicabilita_extraue; Applicabilità in Fatture: extraUE;Codificato;1;S|N",
			"tipoattivita_istituzionale;Tipo Attività: Istituzionale;Codificato;1;S|N",
			"tipoattivita_commerciale;Tipo Attività: Commerciale ;Codificato;1;S|N",
			"tipoattivita_promiscua;Tipo Attività: Promiscua/Altro;Codificato;1;S|N",
			"naturaesenzione;Natura di esenzione: N1 - Escluse ex art.15, N2 - Non soggette, N3 - Non imponibili, N4 - Esenti, N5 - Regime del margine, N6 - Inversione contabile, N7 - IVA assolta in altro stato UE;Codificato;2;N1|N2|N3|N4|N5|N6|N7"
			"prorata_numeratore;Applicabilità al numeratore;Codificato;1;S|N",
			"prorata_denominatore;Applicabilità al denominatore;Codificato;1;S|N"
			 * * */
			while (Reader.DataPresent()) {
				int flag = 0;

				object codice = Reader.getCurrField("codice");
				DataRow IK = MetaIvaKind.Get_New_Row(null, D.Tables["ivakind"]);
				IK["codeivakind"] = Reader.getCurrField("codtipoiva").ToString().Trim();
				IK["description"] = Reader.getCurrField("descrtipoiva");
				IK["rate"] = Reader.getCurrField("aliquota");
				IK["active"] = Reader.getCurrField("attivo");
				IK["idivataxablekind"] = Reader.getCurrField("tipoimposizione");
				IK["unabatabilitypercentage"] = Reader.getCurrField("perc_indetraibilita");
				IK["annotations"] = Reader.getCurrField("annotazioni");
				//bit 0= Istituzionale
				//bit 1= Commerciale
				//bit 2= Promiscua/Altro
				//bit 6= italia
				//bit 7= intraUE
				//bit 8= extraUE

				string applicabilita_italia = Reader.getCurrField("applicabilita_italia").ToString().ToUpper();
				string applicabilita_intraue = Reader.getCurrField("applicabilita_intraue").ToString().ToUpper();
				string applicabilita_extraue = Reader.getCurrField("applicabilita_extraue").ToString().ToUpper();
				if (applicabilita_italia == "S") flag += 64; // italia
				if (applicabilita_intraue == "S") flag += 128; // intraUE 
				if (applicabilita_extraue == "S") flag += 256; // extraUE 

				string tipoattivita_istituzionale =
					Reader.getCurrField("tipoattivita_istituzionale").ToString().ToUpper();
				string tipoattivita_commerciale = Reader.getCurrField("tipoattivita_commerciale").ToString().ToUpper();
				string tipoattivita_promiscua = Reader.getCurrField("tipoattivita_promiscua").ToString().ToUpper();
				if (tipoattivita_istituzionale == "S") flag += 1; //Istituzionale 
				if (tipoattivita_commerciale == "S") flag += 2; //Commerciale
				if (tipoattivita_promiscua == "S") flag += 4; //Promiscua/Altro

				string prorata_numeratore = Reader.getCurrField("prorata_numeratore").ToString().ToUpper();
				string prorata_denominatore = Reader.getCurrField("prorata_denominatore").ToString().ToUpper();
				if (prorata_numeratore == "S") flag += 8; //  numeratore
				if (prorata_denominatore == "S") flag += 16; // denominatore 


				IK["flag"] = CfgFn.GetNoNullInt32(IK["flag"]) + flag;
				IK["idfenature"] = Reader.getCurrField("naturaesenzione");
				IK["cu"] = "Importazione";
				IK["lu"] = "Importazione";

				Reader.GetNext();
			}

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		string[] tracciato_classindirette = new string[] {
			"codesorkindsource;Codice tipo classificazione origine;Stringa;20",
			"sortcodesource;Codice classificazione origine;Stringa;50",
			"codesorkinddest;Codice tipo classificazione destinazione;Stringa;20",
			"sortcodedest;Codice classificazione destinazione;Stringa;50",
			"numeratore;Numeratore della porzione;Numero;22",
			"denominatore;Denominatore della porzione;Numero;22"
		};



		private void btnClassificazioniIndirette_Click(object sender, EventArgs e) {
			ImportaClassificazioniIndirette();
		}

		private void btnClassUPB_Click(object sender, EventArgs e) {
			ImportaClassUPB();
		}

		private void btnEsitazioni_Click(object sender, EventArgs e) {
			ImportaEsitazioni();
		}

		string[] tracciato_movban = new string[] {
			"tipo;Tipo movimento (E=Entrata,S=Spesa);Codificato;1;E|S",
			"yban;Esercizio movimento bancario;Intero;4",
			"nban;Numero movimento bancario;Intero;8",
			"ydoc;Esercizio documento;Intero;4",
			"ndoc;Numero documento;Intero;8",
			"transactiondate;Data operazione;Data;8",
			"valuedate;Data valuta;Data;8",
			"nsub;N. subordinativo;Intero;6",
			"amount;Importo;Numero;22",
			"motive;Causale;Stringa;150"
		};

		bool ImportaEsitazioni() {
			LeggiFile Reader = GetReader(tracciato_movban);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaEsitazioni();
			MetaData MetaBT = Meta.Dispatcher.Get("banktransaction");

			DataTable BT = D.Tables["banktransaction"];
			MetaBT.SetDefaults(BT);

			List<string> tosync = new List<string>();
			InitSpeedSaver(Conn, tosync);

			int nrow = 0;
			Reader.Reset();
			Reader.GetNext();

			while (Reader.DataPresent()) {
				if (nrow > 1000) {
					//Salva i dati e azzera nrow
					//Form F = new formtest(D.Tables["expense"], D.Tables["expenseyear"]);

					//F.ShowDialog();
					nrow = 0;
					if (!SaveData(D, false)) break;
					BT.Clear();
				}

				int yban = CfgFn.GetNoNullInt32(Reader.getCurrField("yban"));

				DataRow Rbt = MetaBT.Get_New_Row(null, BT);
				string kind = Reader.getCurrField("tipo").ToString();
				Rbt["kind"] = (kind == "E") ? "C" : "D";
				int ndoc = CfgFn.GetNoNullInt32(Reader.getCurrField("ndoc"));
				int ydoc = CfgFn.GetNoNullInt32(Reader.getCurrField("ydoc"));
				int nban = CfgFn.GetNoNullInt32(Reader.getCurrField("nban"));

				object nsub = Reader.getCurrField("nsub");
				string table = (kind == "S") ? "payment" : "proceeds";
				string kfield = (kind == "S") ? "kpay" : "kpro";
				string manrev = (kind == "S") ? "mandato" : "reversale";
				string filter = (kind == "S")
					? QHS.AppAnd(QHS.CmpEq("ypay", ydoc), QHS.CmpEq("npay", ndoc))
					: QHS.AppAnd(QHS.CmpEq("ypro", ydoc), QHS.CmpEq("npro", ndoc));

				object kpaymentproceeds = DBNull.Value;
				string me = "Mov.bancario num. " + nban.ToString() + " del " + yban.ToString();

				kpaymentproceeds = Conn.DO_READ_VALUE(table, filter, kfield);
				if (kpaymentproceeds == null) kpaymentproceeds = DBNull.Value;
				if (kpaymentproceeds == DBNull.Value) {
					SpeedSaver.AddError(me + ":" + manrev + " num." + ndoc.ToString() + " del " + ydoc.ToString() +
					                    " non trovata, riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				foreach (string field in new string[] {
					"yban", "transactiondate", /*"nban",*/
					"valuedate", "motive", "amount"
				}) {
					Rbt[field] = Reader.getCurrField(field);
				}

				Rbt[kfield] = kpaymentproceeds;
				if (kind == "E") {
					Rbt["idpro"] = Reader.getCurrField("nsub");
				}
				else {
					Rbt["idpay"] = Reader.getCurrField("nsub");
				}

				Reader.GetNext();
				nrow++;

			} //while (Reader.DataPresent()) 

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		private void btnPartitePendenti_Click(object sender, EventArgs e) {
			ImportaPartitePendenti();
		}

		string[] tracciato_partitependenti = new string[] {
			"anno;Anno;Intero;4",
			"num;Numero partita pendente;Intero;6",
			"tipo;Tipo partita pendete(Credito/Debito);Codificato;1;C|D",
			"anagrafica;Denominazione anagrafica;Stringa;150",
			"importoapertura;Importo Apertura;Numero;22",
			"importocoperto;Importo Coperto;Numero;22",
			"importochiusura;Importo Chiusura;Numero;22",
			"data;Data contabile;Data;8",
			"attiva;Da regolarizzare;Codificato;1;S|N",
			"causale;Causale;Stringa;150",
			"codicecass;Codice Cassiere;Stringa;20",
			"descrcass;Descrizione Cassiere;Stringa;150",
			"note;Note per la regolarizzazione;Stringa;400"
		};

		bool ImportaPartitePendenti() {
			LeggiFile Reader = GetReader(tracciato_partitependenti);
			if (Reader == null)
				return false;

			DataSet D = new vistaPartitePendenti();
			MetaData MetaBill = Meta.Dispatcher.Get("bill");
			MetaData MetaTreasurer = Meta.Dispatcher.Get("treasurer");

			DataTable Bill = D.Tables["bill"];
			DataTable Treasurer = D.Tables["treasurer"];

			MetaBill.SetDefaults(Bill);
			MetaTreasurer.SetDefaults(Treasurer);

			Conn.RUN_SELECT_INTO_TABLE(Treasurer, null, null, null, false);
			List<string> tosync = new List<string>();
			tosync.Add("bill");
			tosync.Add("treasurer");
			InitSpeedSaver(Conn, tosync);

			int nrow = 0;
			Reader.Reset();
			Reader.GetNext();
			List<string> prevbill = new List<string>();

			while (Reader.DataPresent()) {
				if (nrow > 1000) {
					nrow = 0;
					if (!SaveData(D, false)) break;
					Bill.Clear();
				}

				DataRow Rbill = Bill.NewRow();
				Rbill["billkind"] = Reader.getCurrField("tipo");
				Rbill["ybill"] = Reader.getCurrField("anno");
				int nbill = CfgFn.GetNoNullInt32(Reader.getCurrField("num"));
				if (nbill == 0) {
					SpeedSaver.AddWarning("La partita pendente " + Reader.getCurrField("tipo") + "/" +
					                      Rbill["ybill"].ToString() +
					                      "/" + Reader.getCurrField("num").ToString()
					                      + " non ha un numero intero e sarà scartata.");
					Reader.GetNext();
					nrow++;
					continue;
				}

				string curr = Reader.getCurrField("tipo") + "/" + Rbill["ybill"].ToString() + "/" + nbill.ToString();
				if (prevbill.Contains(curr)) {
					SpeedSaver.AddWarning("La partita pendente " + Reader.getCurrField("tipo") + "/" +
					                      Rbill["ybill"].ToString() +
					                      "/" + Reader.getCurrField("num").ToString()
					                      +
					                      " è DUPLICATA (dopo la conversione della stringa numero_bolletta in numero) e sarà scartata.");
					Reader.GetNext();
					nrow++;
					continue;
				}

				prevbill.Add(curr);

				Rbill["nbill"] = nbill;
				Rbill["banknum"] = nbill;
				Rbill["registry"] = Reader.getCurrField("anagrafica");
				Rbill["covered"] = Reader.getCurrField("importocoperto");
				Rbill["total"] = Reader.getCurrField("importoapertura");
				Rbill["reduction"] = Reader.getCurrField("importochiusura");
				Rbill["adate"] = ToSmalldateTime(Reader.getCurrField("data"));
				Rbill["active"] = Reader.getCurrField("attiva");
				Rbill["motive"] = Reader.getCurrField("causale");
				object descrcass = Reader.getCurrField("descrcass");
				object codicecass = Reader.getCurrField("codicecass");
				object idtreasurer = DBNull.Value;
				if (codicecass != DBNull.Value)
					idtreasurer = GetTreasurer(Treasurer, codicecass, descrcass);

				Rbill["idtreasurer"] = idtreasurer;
				Rbill["regularizationnote"] = Reader.getCurrField("note");

				Bill.Rows.Add(Rbill);
				Reader.GetNext();
				nrow++;

			} //while (Reader.DataPresent()) 

			Reader.Close();
			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		private void btnCespitiCheck_Click(object sender, EventArgs e) {
			ImportaCespitiConStorico(true);
		}

		private void btnImportaPianoConti_Click(object sender, EventArgs e) {
			ImportaPianoConti();
		}





		string[] tracciato_pianoconti = new string[] {
			"nliv;Numero Livello Conto;Intero;1",
			"descrliv;Descrizione Livello Conto;Stringa;50",
			"codiceconto;Codice Conto;Stringa;50",
			"ordinestampa;Ordine di stampa;Stringa;50",
			"anno;Anno;intero;4",
			"codiceparentconto;Codice conto del nodo PARENT di questo;Stringa;50",
			"title;Descrizione conto;Stringa;150",
			"competenza;Flag competenza;Codificato;1;S|N",
			"contoordine;Flag conto d'ordine;Codificato;1;S|N",
			"idaccountkind;chiave tipo conto (di tabella accountkind);Stringa;20",
			"flagcliente;Flag registra cliente;Codificato;1;S|N",
			"flagupb;Flag registra UPB;Codificato;1;S|N",
			"flagutile;Flag utile;Codificato;1;S|N",
			"flagperdita;Flag perdita;Codificato;1;S|N",
			"flagignoracliente;Ignora cliente in epilogo;Codificato;1;S|N",
			"flagignoraupb;Ignora upb in epilogo;Codificato;1;S|N",
			"flagignoramovbudget;Ignora Mov. Budget;Codificato;1;S|N",
			"movbudgetnonattesonellescritture;Mov. budget non atteso nelle scritture (per diagnostiche);Codificato;1;S|N",
			"codicecontoeconomico;Codice conto economico associato;Stringa;50",
			"flagsegnopositivocontoeconomico;Segno positivo conto economico;Codificato;1;S|N",
			"costi_ricavi; Costi Ricavi; Codificato;1;C|R",
			"codicestatopatrimoniale;Codice stato patrimoniale;Stringa;50",
			"flagsegnopositivostatopatrimoniale;Segno positivo stato patrimoniale;Codificato;1;S|N",
			"attivita_passivita; Attività Passività; Codificato;1;A|P",
			"flagabilitaprevisionebudget;Flag Abilita Previsione Budget;Codificato;1;S|N",
			"sortcode_economico;Codice di budget economico;Stringa;50",
			"sortcode_investimenti;Codice di budget investimenti;Stringa;50",
			"flaguso_rateiattivi;Ratei attivi;Codificato;1;S|N",
			"flaguso_rateipassivi;Ratei Passivi;Codificato;1;S|N",
			"flaguso_riscontiattivi;Risconti attivi;Codificato;1;S|N",
			"flaguso_riscontipassivi;Risconti passivi;Codificato;1;S|N",
			"flaguso_contodebito;Conto debito;Codificato;1;S|N",
			"flaguso_contocredito;Conto credito;Codificato;1;S|N",
			"flaguso_costo;Costo;Codificato;1;S|N",
			"flaguso_ricavo;Ricavo;Codificato;1;S|N",
			"flaguso_immobilizzazioni;Immobilizzazioni;Codificato;1;S|N",
			"flaguso_avanzolibero;Avanzo libero;Codificato;1;S|N",
			"flaguso_avanzovincolato;Avanzo vincolato;Codificato;1;S|N",
			"flaguso_riserva;Riserva;Codificato;1;S|N",
			"flaguso_fondoaccantonamento;Fondo accantonamento;Codificato;1;S|N"
		};


		void CheckLivPianoConti(DataTable Liv, int Nlevel, string leveldescr, object ayear) {
			//Crea ove assente il livello
			if (Liv.Select(QHC.AppAnd(QHC.CmpEq("ayear", ayear), QHC.CmpEq("nlevel", Nlevel))).Length > 0) return;
			DataRow RL = Liv.NewRow();
			RL["nlevel"] = Nlevel;
			RL["ayear"] = ayear;
			RL["ct"] = DateTime.Now;
			RL["lt"] = DateTime.Now;
			RL["cu"] = "importazione";
			RL["lu"] = "importazione";
			RL["description"] = leveldescr;

			RL["flagusable"] = "S";
			Liv.Rows.Add(RL);

		}

		string getFilterConto(string codeconto, object ayear) {
			string f = QHC.CmpEq("codeacc", codeconto);
			f = QHC.AppAnd(f, QHC.CmpEq("ayear", ayear));
			return f;
		}

		string getSqlFilterConto(string codeconto, object ayear) {
			string f = QHS.CmpEq("codeacc", codeconto);
			f = QHS.AppAnd(f, QHS.CmpEq("ayear", ayear));
			return f;
		}


		Hashtable hConto = null;

		DataRow getRowAcc(DataTable Account, string codeacc, object ayear) {
			if (hConto == null) {
				hConto = new Hashtable();
				foreach (DataRow R in Account.Rows) {
					string k = R["codeacc"].ToString().ToUpper() + "/" + R["ayear"].ToString();
					hConto[k] = R;
				}
			}

			string kk = codeacc.ToString().ToUpper() + "/" + ayear.ToString();
			DataRow res = hConto[kk] as DataRow;
			return res;
		}

		Hashtable hIntrastatCode = null;

		DataRow getRowIntrastatCode(DataTable Intrastatcode, string code, object ayear) {
			if (hIntrastatCode == null) {
				hIntrastatCode = new Hashtable();
				foreach (DataRow R in Intrastatcode.Rows) {
					string k = R["code"].ToString().ToUpper() + "/" + R["ayear"].ToString();
					hIntrastatCode[k] = R;
				}
			}

			string kk = code.ToString().ToUpper() + "/" + ayear.ToString();
			DataRow res = hIntrastatCode[kk] as DataRow;
			return res;
		}

		Hashtable hIntrastatService = null;

		DataRow getRowIntrastatService(DataTable Intrastatservice, string code, object ayear) {
			if (hIntrastatService == null) {
				hIntrastatService = new Hashtable();
				foreach (DataRow R in Intrastatservice.Rows) {
					string k = R["code"].ToString().ToUpper() + "/" + R["ayear"].ToString();
					hIntrastatService[k] = R;
				}
			}

			string kk = code.ToString().ToUpper() + "/" + ayear.ToString();
			DataRow res = hIntrastatService[kk] as DataRow;
			return res;
		}



		Hashtable hListino = null;

		DataRow getRowList(DataTable List, string codlist) {
			if (hListino == null) {
				hListino = new Hashtable();
				foreach (DataRow R in List.Rows) {
					string k = R["intcode"].ToString().ToUpper();
					hListino[k] = R;
				}
			}

			string kk = codlist.ToString().ToUpper();
			DataRow res = hListino[kk] as DataRow;
			return res;
		}

		Hashtable hIntrastatSupplyMethod = null;

		DataRow getRowIntrastatSupplyMethod(DataTable IntrastatSupplyMethod, string code) {
			if (hIntrastatSupplyMethod == null) {
				hIntrastatSupplyMethod = new Hashtable();
				foreach (DataRow R in IntrastatSupplyMethod.Rows) {
					string k = R["code"].ToString().ToUpper();
					hIntrastatSupplyMethod[k] = R;
				}
			}

			string kk = code.ToString().ToUpper();
			DataRow res = hIntrastatSupplyMethod[kk] as DataRow;
			return res;
		}


		Hashtable hInvTree = null;

		DataRow getRowInvTree(DataTable InventoryTree, string code) {
			if (hInvTree == null) {
				hInvTree = new Hashtable();
				foreach (DataRow R in InventoryTree.Rows) {
					string k = R["codeinv"].ToString().ToUpper();
					hInvTree[k] = R;
				}
			}

			string kk = code.ToString().ToUpper();
			DataRow res = hInvTree[kk] as DataRow;
			return res;
		}

		Hashtable hAccMotive = null;

		DataRow getRowAccMotive(DataTable AccMotive, string code) {
			if (hAccMotive == null) {
				hAccMotive = new Hashtable();
				foreach (DataRow R in AccMotive.Rows) {
					string k = R["codemotive"].ToString().ToUpper();
					hAccMotive[k] = R;
				}
			}

			string kk = code.ToString().ToUpper();
			DataRow res = hAccMotive[kk] as DataRow;
			return res;
		}




		Hashtable hListClass = null;

		DataRow getRowListClass(DataTable ListClass, string codelistclass) {
			if (codelistclass == null) return null;
			if (hListClass == null) {
				hListClass = new Hashtable();
				foreach (DataRow R in ListClass.Rows) {
					string k = R["codelistclass"].ToString().ToUpper();
					hListClass[k] = R;
				}
			}

			string kk = codelistclass.ToString().ToUpper();
			DataRow res = hListClass[kk] as DataRow;
			return res;
		}

		Hashtable hUnit = null;

		DataRow getRowUnit(DataTable Unit, string unit) {
			if (hUnit == null) {
				hUnit = new Hashtable();
				foreach (DataRow R in Unit.Rows) {
					string k = R["description"].ToString().ToUpper();
					hUnit[k] = R;
				}
			}

			string kk = unit.ToString().ToUpper();
			DataRow res = hUnit[kk] as DataRow;
			return res;
		}

		Hashtable hPackage = null;

		DataRow getRowPackage(DataTable Package, string package) {
			if (hPackage == null) {
				hPackage = new Hashtable();
				foreach (DataRow R in Package.Rows) {
					string k = R["description"].ToString().ToUpper();
					hPackage[k] = R;
				}
			}

			string kk = package.ToString().ToUpper();
			DataRow res = hPackage[kk] as DataRow;
			return res;
		}


		bool ImportaPianoConti() {
			LeggiFile Reader = GetReader(tracciato_pianoconti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			string[] fields_uso = new string[] {
				"flaguso_rateiattivi", "flaguso_rateipassivi", "flaguso_riscontiattivi", "flaguso_riscontipassivi",
				"flaguso_contodebito", "flaguso_contocredito", "flaguso_costo", "flaguso_ricavo",
				"flaguso_immobilizzazioni",
				"flaguso_avanzolibero", "flaguso_avanzovincolato", "flaguso_riserva", "flaguso_fondoaccantonamento"
			};

			DataSet D = new vistaPianoConti();
			MetaData MetaAccount = Meta.Dispatcher.Get("account");
			MetaData MetaAccountlevel = Meta.Dispatcher.Get("accountlevel");

			DataTable Acc = D.Tables["account"];
			DataTable Acclevel = D.Tables["accountlevel"];

			object idsorkind = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "BUDGET_UFF"),
				"idsorkind");

			GetSortCached.Init();

			MetaAccount.SetDefaults(Acc);
			MetaAccountlevel.SetDefaults(Acclevel);

			Conn.RUN_SELECT_INTO_TABLE(Acc, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Acclevel, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("account");
			tosync.Add("accountlevel");
			InitSpeedSaver(Conn, tosync);

			//"codicecontoeconomico;Codice conto economico associato;Stringa;50",
			//"flagsegnopositivocontoeconomico;Segno positivo conto economico;Codificato;1;S|N",
			//"codicestatopatrimoniale;Codice stato patrimoniale;Stringa;50",
			//"flagsegnopositivostatopatrimoniale;Segno positivo stato patrimoniale;Codificato;1;S|N"

			bool to_repeat = true;
			bool somethingdone = false;
			while (to_repeat) {
				to_repeat = false;
				somethingdone = false;

				Reader.Reset();

				Reader.GetNext();

				while (Reader.DataPresent()) {
					string codeacc = Reader.getCurrField("codiceconto").ToString();
					object ayear = Reader.getCurrField("anno");
					if (ayear == DBNull.Value) {
						SpeedSaver.AddWarning("Non è stato trovato l'anno " +
						                      " alla riga:" + Reader.GetCurrRowNumber());

						Reader.GetNext();
						to_repeat = false;
						continue;
					}

					if (CfgFn.GetNoNullInt32(ayear) < 2000 || CfgFn.GetNoNullInt32(ayear) > 2100) {
						SpeedSaver.AddWarning("L'anno è sbagliato (" + ayear + ") alla riga:" +
						                      Reader.GetCurrRowNumber());

						Reader.GetNext();
						to_repeat = false;
						continue;
					}

					object idaccexist = getRowAcc(Acc, codeacc, ayear);
					if (idaccexist != null) {
						Reader.GetNext();
						continue;
					}

					//individua il nodo parent
					object parcode = Reader.getCurrField("codiceparentconto");
					DataRow RParAcc = null;
					if (parcode != DBNull.Value) {
						RParAcc = getRowAcc(Acc, parcode.ToString(), ayear);

						if (RParAcc == null) {
							SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + parcode +
							                      " padre del nodo avente codice " + codeacc +
							                      " anno " + ayear.ToString() +
							                      " alla riga:" + Reader.GetCurrRowNumber());

							Reader.GetNext();
							to_repeat = true;
							continue;
						}
					}

					object idplaccount = DBNull.Value;
					object codeplaccount = Reader.getCurrField("codicecontoeconomico");
					object costi_ricavi = Reader.getCurrField("costi_ricavi");
					if (codeplaccount != DBNull.Value) {
						string searchcontoeconomico = getSqlFilterPlAcc(codeplaccount.ToString(), ayear);
						if (costi_ricavi != DBNull.Value) {
							searchcontoeconomico =
								QHS.AppAnd(searchcontoeconomico, QHS.CmpEq("placcpart", costi_ricavi));
						}

						idplaccount = Conn.DO_READ_VALUE("placcount", searchcontoeconomico, "idplaccount");
						if (idplaccount == null || idplaccount == DBNull.Value) {
							SpeedSaver.AddError("Voce del conto economico " + costi_ricavi + "-" +
							                    codeplaccount.ToString() + " del " +
							                    ayear.ToString() +
							                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
							Reader.GetNext();
							continue;
						}
					}

					object idpatrimony = DBNull.Value;
					object codepatrimony = Reader.getCurrField("codicestatopatrimoniale");
					object attivita_passivita = Reader.getCurrField("attivita_passivita");
					if (codepatrimony != DBNull.Value) {
						string searchpatrimony = getSqlFilterPatrimony(codepatrimony.ToString(), ayear);
						if (attivita_passivita != DBNull.Value) {
							searchpatrimony = QHS.AppAnd(searchpatrimony, QHS.CmpEq("patpart", attivita_passivita));
						}

						idpatrimony = Conn.DO_READ_VALUE("patrimony", searchpatrimony, "idpatrimony");
						if (idpatrimony == null || idpatrimony == DBNull.Value) {
							SpeedSaver.AddError("Voce dello stato patrimoniale " + attivita_passivita + "-" +
							                    codepatrimony.ToString() + " del " +
							                    ayear.ToString() +
							                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
							Reader.GetNext();
							continue;
						}
					}

					bool error = false;
					string sortcode_economico = Reader.getCurrField("sortcode_economico").ToString();
					object idsor_economico = GetSortCached.GetSortK(Conn, "BUDGET_UFF", sortcode_economico, out error);
					if (error) {
						SpeedSaver.AddError(
							string.Format("Codice di budget economico '{0}' non trovato alla riga: {1}.",
								sortcode_economico, Reader.GetCurrRowNumber())
						);
						Reader.GetNext();
						continue;
					}

					string sortcode_investimenti = Reader.getCurrField("sortcode_investimenti").ToString();
					object idsor_investimenti = GetSortCached.GetSortK(Conn, "BUDGET_UFF", sortcode_investimenti,
						out error);
					if (error) {
						SpeedSaver.AddError(
							string.Format("Codice di budget investimenti '{0}' non trovato alla riga: {1}.",
								sortcode_investimenti, Reader.GetCurrRowNumber())
						);
						Reader.GetNext();
						continue;
					}


					//Aggiunge le informazioni di livello ove necessario
					int Nlev = CfgFn.GetNoNullInt32(Reader.getCurrField("nliv"));
					string levelname = Reader.getCurrField("descrliv").ToString();
					CheckLivPianoConti(Acclevel, Nlev, levelname, ayear);

					Acc.Columns["ayear"].DefaultValue = ayear;
					DataRow Racc = MetaAccount.Get_New_Row(RParAcc, Acc);
					RowChange.ClearAutoIncrement(Acc.Columns["codeacc"]);
					RowChange.ClearAutoIncrement(Acc.Columns["printingorder"]);
					Racc["codeacc"] = codeacc;
					Racc["nlevel"] = Nlev;
					Racc["ayear"] = ayear;
					Racc["title"] = Reader.getCurrField("title").ToString();
					Racc["printingorder"] = Reader.getCurrField("ordinestampa").ToString();
					Racc["ct"] = DateTime.Now;
					Racc["lt"] = DateTime.Now;
					Racc["cu"] = "importazione";
					Racc["lu"] = "importazione";
					int flag_uso = 0;
					int mask = 1;
					for (int indice_flag = 0; indice_flag < fields_uso.Length; indice_flag++) {
						object fvalue = Reader.getCurrField(fields_uso[indice_flag]);
						if (fvalue.ToString().ToUpper() == "S") {
							flag_uso = flag_uso | mask;
						}

						mask = mask << 1;
					}

					Racc["flagaccountusage"] = flag_uso;

					int flag = 0;
					object flagcompetency = Reader.getCurrField("competenza");
					if (flagcompetency != DBNull.Value)
						Racc["flagcompetency"] = flagcompetency;
					if (Reader.getCurrField("contoordine").ToString() == "S") flag += 4;

					object flagregistry = Reader.getCurrField("flagcliente");
					if (flagregistry != DBNull.Value)
						Racc["flagregistry"] = flagregistry;
					Racc["idaccountkind"] = Reader.getCurrField("idaccountkind");

					object flagupb = Reader.getCurrField("flagupb");
					if (flagupb != DBNull.Value)
						Racc["flagupb"] = flagupb;

					object flagprofit = Reader.getCurrField("flagutile");
					if (flagprofit != DBNull.Value)
						Racc["flagprofit"] = flagprofit;

					object flagloss = Reader.getCurrField("flagperdita");
					if (flagloss != DBNull.Value)
						Racc["flagloss"] = flagloss;

					object flagenablebudgetprev = Reader.getCurrField("flagabilitaprevisionebudget");
					if (flagenablebudgetprev != DBNull.Value)
						Racc["flagenablebudgetprev"] = flagenablebudgetprev;

					if (Reader.getCurrField("flagignoracliente").ToString() == "S") flag += 1;
					if (Reader.getCurrField("flagignoraupb").ToString() == "S") flag += 2;
					if (Reader.getCurrField("flagignoramovbudget").ToString() == "S") flag += 8;
					if (Reader.getCurrField("movbudgetnonattesonellescritture").ToString() == "S") flag += 16;

					Racc["flag"] = flag;

					Racc["idplaccount"] = idplaccount;
					Racc["idpatrimony"] = idpatrimony;
					Racc["idsor_economicbudget"] = idsor_economico;
					Racc["idsor_investmentbudget"] = idsor_investimenti;

					object placcount_sign = Reader.getCurrField("flagsegnopositivocontoeconomico");
					if (placcount_sign != DBNull.Value)
						Racc["placcount_sign"] = placcount_sign;
					object patrimony_sign = Reader.getCurrField("flagsegnopositivostatopatrimoniale");
					if (patrimony_sign != DBNull.Value)
						Racc["patrimony_sign"] = patrimony_sign;

					somethingdone = true;

					string kk = codeacc.ToString().ToUpper() + "/" + ayear.ToString();
					hConto[kk] = Racc;

					Reader.GetNext();
				} //while (Reader.DataPresent()) 


				if (to_repeat && !somethingdone) {
					SpeedSaver.AddError("Ci sono nodi child senza parent,verificare. ");
					to_repeat = false;
				}
			} // while (to_repeat) 

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				return false;
			}




			bool res = SaveData(D, true);

			return res;
		}

		private void btnImportaClassPianoConti_Click(object sender, EventArgs e) {
			ImportaClassPianoConti();
		}

		bool ImportaClassPianoConti() {
			LeggiFile Reader = GetReader(tracciato_classpianoconti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			DataSet D = new vistaClassPianoConti();
			DataTable AccountSorting = D.Tables["accountsorting"];
			MetaData MetaAccountSorting = Meta.Dispatcher.Get("accountsorting");
			MetaAccountSorting.SetDefaults(AccountSorting);


			DataTable SortingKind = D.Tables["sortingkind"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codeacc = Reader.getCurrField("codiceconto").ToString();
				object ayear = Reader.getCurrField("anno");
				string searchconto = getSqlFilterAcc(codeacc, ayear);
				object idacc = null;
				idacc = Conn.DO_READ_VALUE("account", searchconto, "idacc");
				if (idacc == null || idacc == DBNull.Value) {
					SpeedSaver.AddError("Voce del piano dei conti " + codeacc + " del " + ayear.ToString() +
					                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}


				string searchsorkind = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkind"));
				if (SortingKind.Select(searchsorkind).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione non trovato: "
					                    + Reader.getCurrField("codesorkind") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkind = SortingKind.Select(searchsorkind)[0]["idsorkind"];

				string searchsor = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcode")));
				object idsor = Conn.DO_READ_VALUE("sorting", searchsor, "idsor");
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddError("Classificazione non trovata: " +
					                    Reader.getCurrField("codesorkind").ToString() + "/" +
					                    Reader.getCurrField("sortcode").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}


				MetaData.SetDefault(AccountSorting, "idsor", idsor);
				MetaData.SetDefault(AccountSorting, "idacc", idacc);
				DataRow AccSor = MetaAccountSorting.Get_New_Row(null, AccountSorting);
				AccSor["quota"] = Reader.getCurrField("quota");

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		string[] tracciato_classpianoconti = new string[] {
			"anno;Anno;intero;4",
			"codiceconto;Codice Conto;Stringa;50",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"quota;Quota assegnazione;Numero;22"
		};

		string[] tracciato_convertibilancio = new string[] {
			"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
			"oldanno;Anno;intero;4",
			"oldcodicebil;Codice Bilancio;Stringa;50",
			"newcodicebil;Codice Bilancio;Stringa;50"
		};

		string[] tracciato_convertipianoconti = new string[] {
			"oldanno;Anno;intero;4",
			"oldcodicepianoconti;Codice Piano dei Conti;Stringa;50",
			"newcodicepianoconti;Codice Piano dei Conti;Stringa;50"
		};



		string[] tracciato_causali = new[] {
			"codemotive;Codice causale;Stringa;50",
			"parentcodemotive;Codice causale parent;Stringa;50",
			"flagamm;Utilizzabile dall'amministrazione;Codificato;1;S|N",
			"flagdep;Utilizzabile dal dipartimento;Codificato;1;S|N",
			"expensekind;Natura di spesa: CO conto COrrente o CA conto CApitale;Codificato;2;CO|CA",
			"title;Denominazione;Stringa;150",
			"active;attivo;Codificato;1;S|N",
			"ayear;anno;Numero;4",
			"codeacc;Codice conto;Stringa;50",
			"applicabilita;codici applicabilità separati da virgole (ammorta appcontrib " +
			" apprit car_ces clawback cococo cococo_deb dipen dipen_deb fatacq fatacq_deb fatacqvar " +
			" fatven fatven_cred fatvenvar fondoeco linkexpense linkincome liqivacred liqivadeb liqrit " +
			" missioni missioni_deb payment prestocc prestocc_deb prestprof prestprof_deb proceeds registry_cred " +
			" registry_deb scar_ammorta scar_ces spesaocc spesaprof;Stringa;500",
			"flagvietasalvataggiofattura_inassenzacontratto;Vieta il salvataggio della fattura in assenza di contratto;Codificato;1;S|N",

		};

		bool ImportaCausali() {
			LeggiFile Reader = GetReader(tracciato_causali);
			if (Reader == null) return false;

			ClearAllNonDBOHash();
			DataSet D = new vistaCausaleContabile();
			DataTable AccMotive = D.Tables["accmotive"];
			DataTable AccMotiveDetail = D.Tables["accmotivedetail"];
			DataTable AccMotiveOp = D.Tables["accmotiveepoperation"];

			Conn.RUN_SELECT_INTO_TABLE(AccMotive, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AccMotiveDetail, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(AccMotiveOp, null, null, null, false);
			MetaData metaAccMotive = Meta.Dispatcher.Get("accmotive");
			MetaData metaAccMotiveDet = Meta.Dispatcher.Get("accmotivedetail");
			MetaData metaAccMotiveOp = Meta.Dispatcher.Get("accmotiveepoperation");
			metaAccMotive.SetDefaults(AccMotive);
			metaAccMotiveDet.SetDefaults(AccMotiveDetail);
			metaAccMotiveOp.SetDefaults(AccMotiveOp);

			List<string> tosync = new List<string>();
			InitSpeedSaver(Conn, tosync);
			DataTable Account = Conn.RUN_SELECT("account", "idacc,ayear,codeacc", null, null, null, false);

			Reader.Reset();
			Reader.GetNext();
			while (Reader.DataPresent()) {
				DataRow parentRow = null;
				object parentcodemotive = Reader.getCurrField("parentcodemotive");
				if (parentcodemotive != DBNull.Value) {
					if (AccMotive.Select(QHC.CmpEq("codemotive", parentcodemotive)).Length == 0) {
						SpeedSaver.AddError("Non è stato trovato la causale avente codice " + parentcodemotive +
						                    " alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					parentRow = AccMotive.Select(QHC.CmpEq("codemotive", parentcodemotive))[0];
				}

				string codeMotive = Reader.getCurrField("codemotive").ToString();
				DataRow rAccMot;
				if (AccMotive.Select(QHC.CmpEq("codemotive", codeMotive)).Length == 0) {
					//string idprefix = Conn.GetEsercizio().ToString().Substring(2, 2);
					if (parentRow != null) {
						MetaData.SetDefault(AccMotive, "paridaccmotive", parentRow["idaccmotive"]);
					}


					rAccMot = metaAccMotive.Get_New_Row(parentRow, AccMotive);
					foreach (
						string field in
						new string[] {"codemotive", "active", "flagamm", "flagdep", "expensekind", "title"}) {
						rAccMot[field] = Reader.getCurrField(field).ToString();
					}

					int flag = 0;
					if (Reader.getCurrField("flagvietasalvataggiofattura_inassenzacontratto").ToString() == "S")
						flag += 1;
					rAccMot["flag"] = flag;
					rAccMot["ct"] = DateTime.Now;
					rAccMot["lt"] = DateTime.Now;
					rAccMot["cu"] = "importazione";
					rAccMot["lu"] = "importazione";
				}
				else {
					rAccMot = AccMotive.Select(QHC.CmpEq("codemotive", codeMotive))[0];
				}

				object oCodeAcc = Reader.getCurrField("codeacc");
				if (oCodeAcc != DBNull.Value && oCodeAcc.ToString() != "") {
					string codeacc = Reader.getCurrField("codeacc").ToString();
					object ayear = Reader.getCurrField("ayear");
					object idacc = getidAcc(Account, codeacc, ayear);
					if (idacc == DBNull.Value) {
						SpeedSaver.AddError("Non è stato trovato il conto avente codice " + codeacc +
						                    " alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					DataRow[] foundDetail = AccMotiveDetail.Select(QHC.AppAnd(
						QHC.CmpEq("ayear", ayear), QHC.CmpEq("idacc", idacc),
						QHC.CmpEq("idaccmotive", rAccMot["idaccmotive"])));
					if (foundDetail.Length == 0) {
						MetaData.SetDefault(AccMotiveDetail, "idacc", idacc);
						MetaData.SetDefault(AccMotiveDetail, "ayear", ayear);
						DataRow rAccMotiveDetail = metaAccMotiveDet.Get_New_Row(rAccMot, AccMotiveDetail);

						rAccMotiveDetail["ct"] = DateTime.Now;
						rAccMotiveDetail["lt"] = DateTime.Now;
						rAccMotiveDetail["cu"] = "importazione";
						rAccMotiveDetail["lu"] = "importazione";
					}
				}

				object applicabilita = Reader.getCurrField("applicabilita");
				if (applicabilita != DBNull.Value) {
					string[] apply = applicabilita.ToString().ToLowerInvariant().Split(',');
					foreach (string idepoperation in apply) {
						string toconsider = idepoperation.Trim().ToLower();
						if (toconsider == "") continue;
						DataRow[] foundEpOp = AccMotiveOp.Select(QHC.AppAnd(
							QHC.CmpEq("idepoperation", toconsider),
							QHC.CmpEq("idaccmotive", rAccMot["idaccmotive"])));
						if (foundEpOp.Length == 0) {
							MetaData.SetDefault(AccMotiveOp, "idepoperation", toconsider);
							DataRow rAccMotiveOp = metaAccMotiveOp.Get_New_Row(rAccMot, AccMotiveOp);
							rAccMotiveOp["ct"] = DateTime.Now;
							rAccMotiveOp["lt"] = DateTime.Now;
							rAccMotiveOp["cu"] = "importazione";
							rAccMotiveOp["lu"] = "importazione";
						}
					}
				}

				Reader.GetNext();
			}

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				return false;
			}

			//Form F = new formtest(D.Tables["accmotive"], D.Tables["accmotivedetail"], D.Tables["accmotiveepoperation"]);
			//F.ShowDialog();
			bool res = SaveData(D, true);

			D.Clear();
			return res;
		}

		private void btnFinLookup_Click(object sender, EventArgs e) {
			ImportaConvertiBilancio();
		}

		bool ImportaConvertiBilancio() {
			LeggiFile Reader = GetReader(tracciato_convertibilancio);
			if (Reader == null) return false;

			ClearAllNonDBOHash();

			DataSet D = new vistaConvertiBilancio();
			DataTable Finlookup = D.Tables["finlookup"];
			Conn.SQLRunner("ALTER TABLE  FINLOOKUP DISABLE TRIGGER ALL");
			MetaData MetaFinlookup = Meta.Dispatcher.Get("finlookup");
			MetaFinlookup.SetDefaults(Finlookup);
			DataTable Fin = D.Tables["fin"];

			Conn.RUN_SELECT_INTO_TABLE(D.Tables["fin"], null, null, null, false);
			List<string> tosync = new List<string>();
			tosync.Add("finlookup");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			while (Reader.DataPresent()) {
				//"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
				//"oldanno;Anno;intero;4",
				//"oldcodicebil;Codice Bilancio;Stringa;50",
				//"newcodicebil;Codice Bilancio;Stringa;50"
				string partebil = Reader.getCurrField("partebil").ToString();
				object ayear = Reader.getCurrField("oldanno");
				string oldcodefin = Reader.getCurrField("oldcodicebil").ToString();

				int newayear = CfgFn.GetNoNullInt32(ayear) + 1;
				object oldidfinexist = getidFin(Fin, oldcodefin, partebil, ayear);
				if (oldidfinexist == DBNull.Value) {
					Reader.GetNext();
					SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + oldcodefin +
					                      " parte " + partebil + " anno " + ayear.ToString() +
					                      " alla riga:" + Reader.GetCurrRowNumber());
					continue;
				}

				object newcodefin = Reader.getCurrField("newcodicebil");
				object newidfinexists = DBNull.Value;
				if (newcodefin != DBNull.Value) {
					newidfinexists = getidFin(Fin, newcodefin.ToString(), partebil, newayear);

					if (newidfinexists == DBNull.Value) {
						SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + newcodefin.ToString() +
						                      " parte " + partebil + " anno " + newayear.ToString() +
						                      " alla riga:" + Reader.GetCurrRowNumber());

						Reader.GetNext();
						continue;
					}
				}


				DataRow RfinLookup = MetaFinlookup.Get_New_Row(null, Finlookup);

				RfinLookup["oldidfin"] = oldidfinexist;
				RfinLookup["newidfin"] = newidfinexists;
				RfinLookup["ct"] = DateTime.Now;
				RfinLookup["lt"] = DateTime.Now;
				RfinLookup["cu"] = "importazione";
				RfinLookup["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				Conn.SQLRunner("ALTER TABLE  FINLOOKUP ENABLE TRIGGER ALL");
				return false;
			}

			bool res = SaveData(D, true);
			Conn.SQLRunner("ALTER TABLE FINLOOKUP ENABLE TRIGGER ALL");

			D.Clear();
			return res;
		}

		string[] tracciato_classmerc = new string[] {
			"codclassmerc; Codice Classificazione Merceologica;Stringa;50",
			"descrclassmerc;Denominazione Classificazione Merceologica;Stringa;150",
			"attivo;Attivo(S/N);Codificato;1;S|N",
			"codclassmercpadre; Codice Classificazione Merceologica Padre;Stringa;50",
			"ordinestampa; Ordine Stampa;Stringa;20",
			"autorizzazione_richiesta;Richiede Autorizzazione del Responsabile (S/N);Codificato;1;S|N",
			"tipologiaquadrovf25;Tipologia Beni (Quadro VF25)(S Ammortizzabili/N Strumentali non ammortizzabili/R Destinati alla rivendita/A Altri acquisti e importazioni);Codificato;1;S|N|R|A",
			"tipologiapatrimonio;Tipologia Beni (Patrimonio)(A Inventariabile/P Aumento di Valore/S Servizi/M Magazzino/O Altro);Codificato;1;A|P|S|M|O",
			"tipologiablacklist;Tipologia Operazioni con Paesi a Fiscalità Privilegiata (Blacklist)(0 Beni/1 Servizi/2 Non specificato);Codificato;1;0|1|2",
			"tipologiaintra12;Tipologia Operazioni(Intra12)(B Beni/S Servizi);Codificato;1;B|S",
			"codmoderogazioneintra12; Codice Modalità Erogazione (Intra12);Stringa;20",
			"codclassinventariale;Codice Tipo Class. Inventariale;Stringa;20",
			"codcausaleep;Codice Causale EP;Stringa;50",
			"visibilemagazzino;Visibile nelle prenotazioni di magazzino e nella vetrina;Codificato;1;S|N",
			"visibilec_passivi;Visibile nei Contratti Passivi;Codificato;1;S|N",
			"visibilec_attivi;Visibile nei Contratti Attivi;Codificato;1;S|N"

		};

		bool ImportaClassMerc() {
			LeggiFile Reader = GetReader(tracciato_classmerc);
			if (Reader == null) return false;


			var D = new vistaListClass();
			MetaData MetaListClass = Meta.Dispatcher.Get("listclass");

			DataTable ListClass = D.listclass;

			DataTable IntrastatSupplyMethod = D.Tables["intrastatsupplymethod"];
			DataTable AccMotive = D.Tables["accmotive"];
			DataTable InventoryTree = D.Tables["inventorytree"];

			MetaListClass.SetDefaults(ListClass);

			Conn.RUN_SELECT_INTO_TABLE(D.Tables["listclass"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["intrastatsupplymethod"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["inventorytree"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["accmotive"], null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("listclassyear");

			InitSpeedSaver(Conn, tosync);

			Reader.Reset();

			Reader.GetNext();

			while (Reader.DataPresent()) {

				object ayear = Reader.getCurrField("anno");
				object idlistclass = DBNull.Value;
				string codclassmerc = Reader.getCurrField("codclassmerc").ToString();
				if (codclassmerc != "") {
					DataRow listclassexists = getRowListClass(ListClass, codclassmerc);
					if (listclassexists != null) {
						Reader.GetNext();
						continue;
					}
				}
				else {
					SpeedSaver.AddError("Non è stato specificato codice Classificazione Merceologica codclassmerc" +
					                    " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				//individua il nodo parent
				object paridlistclass = DBNull.Value;
				object parcode = Reader.getCurrField("codclassmercpadre");
				DataRow RParListClass = null;
				if (parcode != DBNull.Value) {
					RParListClass = getRowListClass(ListClass, parcode.ToString());

					if (RParListClass == null) {
						SpeedSaver.AddError("Non è stato trovato il nodo avente codice " + parcode +
						                    " padre del nodo avente codice " + codclassmerc +
						                    " alla riga:" + Reader.GetCurrRowNumber());

						Reader.GetNext();
						continue;
					}
					else {
						paridlistclass = RParListClass["idlistclass"];
					}
				}
				//else {
				//    SpeedSaver.AddError("Non è stato specificato il nodo   codice padre " +
				//                        " alla riga:" + Reader.GetCurrRowNumber());
				//    Reader.GetNext();
				//    continue;
				//}


				object idintrastatsupplymethod = DBNull.Value;
				string codmoderogazioneintra12 = Reader.getCurrField("codmoderogazioneintra12").ToString();
				if (codmoderogazioneintra12 != "") {

					DataRow intrastatsupplymethodexists = getRowIntrastatSupplyMethod(IntrastatSupplyMethod,
						codmoderogazioneintra12);
					if (intrastatsupplymethodexists == null) {
						SpeedSaver.AddError("Modalità erogazione servizio " + codmoderogazioneintra12 +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idintrastatsupplymethod = intrastatsupplymethodexists["idintrastatcode"];
				}


				object idinv = DBNull.Value;
				string codeinv = Reader.getCurrField("codclassinventariale").ToString();
				if (codeinv != "") {

					DataRow invtreeeexists = getRowInvTree(InventoryTree, codeinv);
					if (invtreeeexists == null) {
						SpeedSaver.AddError("Codice Class. Inventariale " + codeinv +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idinv = invtreeeexists["idinv"];
				}


				object idaccmotive = DBNull.Value;
				string codcausaleep = Reader.getCurrField("codcausaleep").ToString();
				if (codcausaleep != "") {

					DataRow accmotiveexists = getRowAccMotive(AccMotive, codcausaleep);
					if (accmotiveexists == null) {
						SpeedSaver.AddError("Codice Causale EP" + codcausaleep +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idaccmotive = accmotiveexists["idaccmotive"];
				}


				DataRow RListClass = MetaListClass.Get_New_Row(RParListClass, ListClass);
				RListClass["codelistclass"] = Reader.getCurrField("codlistino").ToString();
				RListClass["paridlistclass"] = paridlistclass;
				RListClass["codelistclass"] = codclassmerc;
				RListClass["printingorder"] = Reader.getCurrField("ordinestampa").ToString();
				RListClass["title"] = Reader.getCurrField("descrclassmerc").ToString();
				RListClass["authrequired"] = Reader.getCurrField("autorizzazione_richiesta").ToString();
				RListClass["assetkind"] = Reader.getCurrField("tipologiapatrimonio").ToString();
				RListClass["va3type"] = Reader.getCurrField("tipologiaquadrovf25").ToString();
				RListClass["intra12operationkind"] = Reader.getCurrField("tipologiaintra12").ToString();
				RListClass["active"] = Reader.getCurrField("attivo").ToString();
				RListClass["idintrastatsupplymethod"] = idintrastatsupplymethod;
				RListClass["idinv"] = idinv;
				RListClass["idaccmotive"] = idaccmotive;
				RListClass["flag"] = Reader.getCurrField("tipologiablacklist");
				RListClass["ct"] = DateTime.Now;
				RListClass["lt"] = DateTime.Now;
				RListClass["cu"] = "importazione";
				RListClass["lu"] = "importazione";
				int flag = 0;
				if (Reader.getCurrField("visibilemagazzino").ToString() == "S") flag += 1;
				if (Reader.getCurrField("visibilec_passivi").ToString() == "S") flag += 2;
				if (Reader.getCurrField("visibilec_attivi").ToString() == "S") flag += 4;
				RListClass["flagvisiblekind"] = flag;

				string k = RListClass["codelistclass"].ToString().ToUpper();
				hListClass[k] = RListClass;

				Reader.GetNext();

			}

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				return false;
			}

			bool res = SaveData(D, true);

			return res;

		}

		bool ImportaClassMercAnnuale() {
			//string[] tracciato_classmercannuale = new string[] {
			//     "anno; Anno;Intero;4", 
			//     "codclassmerc; Codice Classificazione Merceologica;Stringa;8", 
			//     "codnomenclaturacombinata; Codice Nomenclatura combinata;Stringa;1000",
			//     "codservinstrastat; Codice Servizi Intrastat;Stringa;100",
			//};

			LeggiFile Reader = GetReader(tracciato_classmercannuale);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			var D = new vistaListClassYear();
			MetaData MetaListClassYear = Meta.Dispatcher.Get("listclassyear");
			MetaData MetaIntrastatCode = Meta.Dispatcher.Get("intrastatcode");
			MetaData MetaIntrastatService = Meta.Dispatcher.Get("intrastatservice");

			DataTable ListClass = D.listclass;
			DataTable ListClassYear = D.listclassyear;
			DataTable IntrastatCode = D.intrastatcode;
			DataTable IntrastatService = D.intrastatservice;

			MetaListClassYear.SetDefaults(ListClassYear);

			Conn.RUN_SELECT_INTO_TABLE(ListClass, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(ListClassYear, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(IntrastatCode, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(IntrastatService, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("listclassyear");

			InitSpeedSaver(Conn, tosync);

			Reader.Reset();

			Reader.GetNext();

			while (Reader.DataPresent()) {

				object ayear = Reader.getCurrField("anno");
				object idlistclass = DBNull.Value;
				string codclassmerc = Reader.getCurrField("codclassmerc").ToString();
				if (codclassmerc != "") {

					DataRow listclassexists = getRowListClass(ListClass, codclassmerc);
					if (listclassexists == null) {
						SpeedSaver.AddError("Classificazione Merceologica " + codclassmerc +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idlistclass = listclassexists["idlistclass"];
				}

				object idintrastatcode = DBNull.Value;
				string codnomenclaturacombinata = Reader.getCurrField("codnomenclaturacombinata").ToString();
				if (codnomenclaturacombinata != "") {

					DataRow intrastatcodexists = getRowIntrastatCode(IntrastatCode, codnomenclaturacombinata, ayear);
					if (intrastatcodexists == null) {
						SpeedSaver.AddError("Nomenclatura Combinata " + codnomenclaturacombinata +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idintrastatcode = intrastatcodexists["idintrastatcode"];
				}


				object idintrastatservice = DBNull.Value;
				string codservinstrastat = Reader.getCurrField("codservinstrastat").ToString();
				if (codservinstrastat != "") {

					DataRow intrastatserviceexists = getRowIntrastatService(IntrastatService, codservinstrastat,
						ayear);
					if (intrastatserviceexists == null) {
						SpeedSaver.AddError("Codice Servizio Intrastat " + codservinstrastat +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idintrastatservice = intrastatserviceexists["idintrastatservice"];
				}


				DataRow RListClassYear = MetaListClassYear.Get_New_Row(null, ListClassYear);
				RListClassYear["ayear"] = Reader.getCurrField("anno");
				RListClassYear["idlistclass"] = idlistclass;
				RListClassYear["idintrastatcode"] = idintrastatcode;
				RListClassYear["idintrastatservice"] = idintrastatservice;
				RListClassYear["ct"] = DateTime.Now;
				RListClassYear["lt"] = DateTime.Now;
				RListClassYear["cu"] = "importazione";
				RListClassYear["lu"] = "importazione";

				Reader.GetNext();
			}

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				return false;
			}




			bool res = SaveData(D, true);

			return res;
		}

		bool ImportaListino() {
			/*       
		 string[] tracciato_listino = new string[] {
			    "codlistino; Codice Classificazione Merceologica;Stringa;36", 
			    "descrlistino; Descrizione Listino;Stringa;150",
			    "attivo; Attivo(S/N); Codificato;1;S|N",
		 *      "dascaricare; Da Scaricare(S/N); Codificato;1;S|N",
			    "scadenza; Articolo con data scadenza(S/N); Codificato;1;S|N",
			    "datascadenza; Data Scadenza;Data;8",
			    "codclassmerc; Codice Classificazione Merceologica;Stringa;8", 
			    "unitamisuracaricoscarico; Unità di Misura per Carico/Scarico;Stringa;50", 
			    "unitamisuraacquisto; Unità di Misura per Acquisto;Stringa;50", 
		 *    "coefficienteconversione; Coefficiente di Conversione;Intero;8", 
			    "codclassmerc; Codice Classificazione Merceologica;Stringa;8", 
			    "scortamin;Scorta minima;Intero;6",
			    "quantitariordino;Quantità per il riordino;Intero;6",
			    "tempoapprovigionamento;Tempo di approvigionamento;Intero;6",
			    "quantitamaxprenotabile;Quantità massima prenotabile;Intero;6"
		};
		*/
			LeggiFile Reader = GetReader(tracciato_listino);
			if (Reader == null) return false;


			DataSet D = new vistaList();
			MetaData MetaList = Meta.Dispatcher.Get("list");
			//MetaData MetaUnit = Meta.Dispatcher.Get("unit");
			//MetaData MetaPackage = Meta.Dispatcher.Get("package");

			DataTable List = D.Tables["list"];
			DataTable Unit = D.Tables["unit"];
			DataTable Package = D.Tables["package"];
			DataTable ListClass = D.Tables["listclass"];

			MetaList.SetDefaults(List);



			Conn.RUN_SELECT_INTO_TABLE(D.Tables["list"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["unit"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["package"], null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(D.Tables["listclass"], null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("list");

			InitSpeedSaver(Conn, tosync);




			Reader.Reset();

			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codelist = Reader.getCurrField("codlistino").ToString();

				object codelistexist = getRowList(List, codelist);
				if (codelistexist != null) {
					Reader.GetNext();
					continue;
				}

				object idlistclass = DBNull.Value;
				string codclassmerc = Reader.getCurrField("codclassmerc").ToString();
				if (codclassmerc != "") {

					DataRow listclassexists = getRowListClass(ListClass, codclassmerc);
					if (listclassexists == null) {
						SpeedSaver.AddError("Classificazione Merceologica " + codclassmerc +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idlistclass = listclassexists["idlistclass"];
				}

				object idunit = DBNull.Value;
				string unitamisuracaricoscarico = Reader.getCurrField("unitamisuracaricoscarico").ToString();
				if (unitamisuracaricoscarico != "") {

					DataRow unitexists = getRowUnit(Unit, unitamisuracaricoscarico);
					if (unitexists == null) {
						SpeedSaver.AddError("Unità di Misura per carico e scarico " + unitamisuracaricoscarico +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idunit = unitexists["idunit"];
				}

				object idpackage = DBNull.Value;
				string unitamisuraacquisto = Reader.getCurrField("unitamisuraacquisto").ToString();
				if (unitamisuraacquisto != "") {

					DataRow packageexists = getRowPackage(Package, unitamisuraacquisto);
					if (packageexists == null) {
						SpeedSaver.AddError("Unità di Misura per l'acquisto " + unitamisuraacquisto +
						                    " non è stata trovata alla riga:" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
					else
						idpackage = packageexists["idpackage"];
				}

				DataRow RList = MetaList.Get_New_Row(null, List);

				RList["intcode"] = Reader.getCurrField("codlistino").ToString();
				RList["description"] = Reader.getCurrField("descrlistino").ToString();

				RList["validitystop"] = Reader.getCurrField("datascadenza");
				RList["active"] = Reader.getCurrField("attivo").ToString();
				RList["idpackage"] = idpackage;
				RList["idunit"] = idunit;
				RList["unitsforpackage"] = Reader.getCurrField("coefficienteconversione");
				RList["has_expiry"] = Reader.getCurrField("scadenza");
				RList["idlistclass"] = idlistclass;

				RList["nmin"] = Reader.getCurrField("scortamin");
				RList["ntoreorder"] = Reader.getCurrField("quantitariordino");
				RList["tounload"] = Reader.getCurrField("dascaricare").ToString();
				RList["timesupply"] = Reader.getCurrField("tempoapprovigionamento");
				RList["nmaxorder"] = Reader.getCurrField("quantitamaxprenotabile");

				RList["ct"] = DateTime.Now;
				RList["lt"] = DateTime.Now;
				RList["cu"] = "importazione";
				RList["lu"] = "importazione";

				string kk = codelist.ToString().ToUpper();
				hListino[kk] = RList;

				Reader.GetNext();
			} //while (Reader.DataPresent()) 



			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				return false;
			}




			bool res = SaveData(D, true);

			return res;

		}

		bool ImportaConvertiPianoConti() {
			LeggiFile Reader = GetReader(tracciato_convertipianoconti);
			if (Reader == null) return false;

			ClearAllNonDBOHash();

			DataSet D = new vistaConvertiPianoConti();
			DataTable Accountlookup = D.Tables["accountlookup"];
			Conn.SQLRunner("ALTER TABLE  ACCOUNTLOOKUP DISABLE TRIGGER ALL");
			MetaData MetaAccountlookup = Meta.Dispatcher.Get("accountlookup");
			MetaAccountlookup.SetDefaults(Accountlookup);
			DataTable Account = D.Tables["account"];

			Conn.RUN_SELECT_INTO_TABLE(D.Tables["account"], null, null, null, false);
			List<string> tosync = new List<string>();
			tosync.Add("accountlookup");
			InitSpeedSaver(Conn, tosync);

			Reader.Reset();
			Reader.GetNext();
			while (Reader.DataPresent()) {
				object ayear = Reader.getCurrField("oldanno");
				object oldcodeacc = Reader.getCurrField("oldcodicepianoconti");

				if (oldcodeacc == DBNull.Value) {
					SpeedSaver.AddWarning("Manca il codice vecchio conto " + oldcodeacc.ToString() +
					                      " anno " + ayear.ToString() +
					                      " alla riga:" + Reader.GetCurrRowNumber());

					Reader.GetNext();
					continue;
				}

				int newayear = CfgFn.GetNoNullInt32(ayear) + 1;
				object oldidaccexists = getidAcc(Account, oldcodeacc.ToString(), ayear); // Metodo da realizzare
				if (oldidaccexists == DBNull.Value) {
					Reader.GetNext();
					SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + oldcodeacc +
					                      " anno " + ayear.ToString() +
					                      " alla riga:" + Reader.GetCurrRowNumber());
					continue;
				}

				object newcodeacc = Reader.getCurrField("newcodicepianoconti");
				object newidaccexists = DBNull.Value;
				if (newcodeacc != DBNull.Value) {
					newidaccexists = getidAcc(Account, newcodeacc.ToString(), newayear);

					if (newidaccexists == DBNull.Value) {
						SpeedSaver.AddWarning("Non è stato trovato il nodo avente codice " + newcodeacc.ToString() +
						                      " anno " + newayear.ToString() +
						                      " alla riga:" + Reader.GetCurrRowNumber());

						Reader.GetNext();
						continue;
					}
				}

				if (newcodeacc == DBNull.Value) {
					SpeedSaver.AddWarning("Manca il codice nuovo conto " + newcodeacc.ToString() +
					                      " anno " + newayear.ToString() +
					                      " alla riga:" + Reader.GetCurrRowNumber());

					Reader.GetNext();
					continue;
				}


				DataRow RAccountLookup = MetaAccountlookup.Get_New_Row(null, Accountlookup);

				RAccountLookup["oldidacc"] = oldidaccexists;
				RAccountLookup["newidacc"] = newidaccexists;
				RAccountLookup["ct"] = DateTime.Now;
				RAccountLookup["lt"] = DateTime.Now;
				RAccountLookup["cu"] = "importazione";
				RAccountLookup["lu"] = "importazione";

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();

			if (SpeedSaver.GetErrorCondition()) {
				ShowMessages();
				Conn.SQLRunner("ALTER TABLE  ACCOUNTLOOKUP ENABLE TRIGGER ALL");
				return false;
			}

			bool res = SaveData(D, true);
			Conn.SQLRunner("ALTER TABLE ACCOUNTLOOKUP ENABLE TRIGGER ALL");

			D.Clear();
			return res;
		}

		private void btnVarMovTrg_Click(object sender, EventArgs e) {
			ImportaVarMovFin(true);
		}

		private void btnImportaContrattiAttivi_Click(object sender, EventArgs e) {
			ImportaContrattiAttivi();
		}

		private void btnImportaTipiDocIVA_Click(object sender, EventArgs e) {
			ImportaTipoDocIva();
		}

		private void btnImportaTipiRegistroIVA_Click(object sender, EventArgs e) {
			ImportaTipoRegistroIva();
		}

		private void btnImportaTipiDocRegistriIVA_Click(object sender, EventArgs e) {
			ImportaTipoDocIvaRegistroIva();
		}

		private void btnImportaRegistriIVA_Click(object sender, EventArgs e) {
			ImportaRegistroIva();
		}

		private void btnImportaTipiDocIvaAnnuale_Click(object sender, EventArgs e) {
			ImportaTipoDocIvaAnnuale();
		}

		private void btnImportaScrittureEP_Click(object sender, EventArgs e) {
			ImportaScrittureEP();
		}

		private void btnImportaConvertiPianoConti_Click(object sender, EventArgs e) {
			ImportaConvertiPianoConti();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnListClass_Click(object sender, EventArgs e) {
			ImportaClassMerc();
		}

		private void btnImportaCausali_Click(object sender, EventArgs e) {
			ImportaCausali();
		}





		private void btnListClassYear_Click(object sender, EventArgs e) {
			ImportaClassMercAnnuale();
		}

		private void btnList_Click(object sender, EventArgs e) {
			ImportaListino();
		}

		private void btnImportaAccountvar_Click(object sender, EventArgs e) {
			ImportaAccountVar();
		}

		private void chkEsistenza_CheckedChanged(object sender, EventArgs e) {

		}

		private void btnTipiContrattiCSA_Click(object sender, EventArgs e) {
			ImportaTipoContrattoCsa();
		}

		private void btnRegoleIndividuazioneCSA_Click(object sender, EventArgs e) {
			ImportaRegoleTipiContrattoCSA();
		}

		private void btnContributiTipoContrattoCSA_Click(object sender, EventArgs e) {
			ImportaContributiTipiContrattoCSA();
		}

		private void btnContrattiCSA_Click(object sender, EventArgs e) {
			ImportaContrattiCSA();
		}

		private void btnMatricoleContrattiCSA_Click(object sender, EventArgs e) {
			ImportaMatricoleContrattiCSA();
		}

		private void btnContributiContrattiCSA_Click(object sender, EventArgs e) {
			ImportaContributiContrattoCSA();
		}

		private void btnRipartContrattiCSA_Click(object sender, EventArgs e) {
			ImportaRipContrattiCSA();
		}

		private void btnRipartContributiContrattiCSA_Click(object sender, EventArgs e) {
			ImportaRipContributoContrattiCSA();
		}

		private void btnImportaAccmotiveSorting_Click(object sender, EventArgs e) {
			ImportaClassCausali();
		}



		bool ImportaClassCausali() {
			/*
			 *     string[] tracciato_classcausaliep = new string[] {
			"codemotive;Codice causale;Stringa;50",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"quota;Quota assegnazione;Numero;22"
			 * */
			LeggiFile Reader = GetReader(tracciato_classcausaliep);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaClassCausaliEp();

			DataTable AccmotiveSorting = D.Tables["accmotivesorting"];
			MetaData MetaAccmotiveSorting = Meta.Dispatcher.Get("accmotivesorting");
			MetaAccmotiveSorting.SetDefaults(AccmotiveSorting);


			DataTable SortingKind = D.Tables["sortingkind"];
			Conn.RUN_SELECT_INTO_TABLE(SortingKind, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("sortingkind");
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();

			while (Reader.DataPresent()) {

				object codemotive = Reader.getCurrField("codemotive");
				object idaccmotive = null;
				idaccmotive = Conn.DO_READ_VALUE("accmotive", QHC.CmpEq("codemotive", codemotive), "idaccmotive");
				if (idaccmotive == null || idaccmotive == DBNull.Value) {
					SpeedSaver.AddError("Non è stato trovato la causale avente codice " + codemotive +
					                    " alla riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				string searchsorkind = QHC.CmpEq("codesorkind", Reader.getCurrField("codesorkind"));
				if (SortingKind.Select(searchsorkind).Length == 0) {
					SpeedSaver.AddError("Tipo classificazione non trovato: "
					                    + Reader.getCurrField("codesorkind") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsorkind = SortingKind.Select(searchsorkind)[0]["idsorkind"];

				string searchsor = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind),
					QHS.CmpEq("sortcode", Reader.getCurrField("sortcode")));
				object idsor = Conn.DO_READ_VALUE("sorting", searchsor, "idsor");
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddError("Classificazione non trovata: " +
					                    Reader.getCurrField("codesorkind").ToString() + "/" +
					                    Reader.getCurrField("sortcode").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}


				MetaData.SetDefault(AccmotiveSorting, "idsor", idsor);
				MetaData.SetDefault(AccmotiveSorting, "idaccmotive", idaccmotive);
				DataRow AccMotiveSor = MetaAccmotiveSorting.Get_New_Row(null, AccmotiveSorting);


				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;

		}

		string[] tracciato_autoclassmov = new string[] {
			"ayear;Esercizio;Intero;4",
			"codesorkind;Codice tipo classificazione;Stringa;20",
			"sortcode;Codice classificazione;Stringa;50",
			"codesorkindreg;Codice tipo classificazione anagrafica;Stringa;20",
			"sortcodereg;Codice classificazione anagrafica;Stringa;50",
			"numeratore;Numeratore della porzione;Numero;22",
			"denominatore;Denominatore della porzione;Numero;22",
			"codeupb;Codice upb;Stringa;50",
			"codicebil;Codice bilancio;Stringa;50",
			"partebil;Parte Bilancio (E/S);Codificato;1;E|S",
			"resp;Responsabile;Stringa;150",
		};

		private void btnAutoClassEntrate_Click(object sender, EventArgs e) {
			ImportaAutoClassMovimenti_E();
		}

		private void btnAutoClassSpese_Click(object sender, EventArgs e) {
			ImportaAutoClassMovimenti_S();
		}

		bool ImportaAutoClassMovimenti_E() {
			return ImportaAutoClassMovimenti("E");

		}

		bool ImportaAutoClassMovimenti_S() {
			return ImportaAutoClassMovimenti("S");

		}

		bool ImportaAutoClassMovimenti(string E_S) {
			/*
			 ayear (chiave)
			 idautosort (incrementale) (chiave)
			 idupb null
			 idfin null
			 idman null

			idsor null
			idsorkind null

			idsorreg null
			idsorkindreg   null

			numerator
			denominator
			 */
			LeggiFile Reader = GetReader(tracciato_autoclassmov);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaAutoclassMov();


			string tablename = E_S == "E" ? "autoincomesorting" : "autoexpensesorting";
			DataTable AutoMov = D.Tables[tablename];
			MetaData MetaAuto = Meta.Dispatcher.Get(tablename);
			MetaAuto.SetDefaults(AutoMov);





			List<string> tosync = new List<string>();
			InitSpeedSaver(Conn, tosync);


			Reader.GetNext();
			bool error;

			while (Reader.DataPresent()) {
				object idsorkind = GetSortCached.GetIdSortkind(Conn, Reader.getCurrField("codesorkind").ToString(),
					out error);

				if (idsorkind == DBNull.Value) {
					SpeedSaver.AddError("Tipo classificazione non trovato: "
					                    + Reader.getCurrField("codesorkind") + " alla riga:" +
					                    Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				object idsor = GetSortCached.GetSortK(Conn, Reader.getCurrField("codesorkind").ToString(),
					Reader.getCurrField("sortcode").ToString(), out error);
				if (idsor == null || idsor == DBNull.Value) {
					SpeedSaver.AddError("Classificazione Origine non trovata: " +
					                    Reader.getCurrField("codesorkind").ToString() + "/" +
					                    Reader.getCurrField("sortcode").ToString() +
					                    " alla riga:" + Reader.GetCurrRowNumber()
					);
					Reader.GetNext();
					continue;
				}

				object idsorkindReg = DBNull.Value;
				object idsorReg = DBNull.Value;
				if (Reader.getCurrField("codesorkindreg") != DBNull.Value) {
					idsorkindReg = GetSortCached.GetIdSortkind(Conn, Reader.getCurrField("codesorkindreg").ToString(),
						out error);

					if (idsorkindReg == DBNull.Value) {
						SpeedSaver.AddError("Tipo classificazione Anagrafica non trovato: "
						                    + Reader.getCurrField("codesorkindreg") + " alla riga:" +
						                    Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					idsorReg = GetSortCached.GetSortK(Conn, Reader.getCurrField("codesorkindreg").ToString(),
						Reader.getCurrField("sortcodereg").ToString(), out error);
					if (idsorReg == DBNull.Value) {
						SpeedSaver.AddError("Classificazione Anagrafica non trovata: " +
						                    Reader.getCurrField("codesorkindreg").ToString() + "/" +
						                    Reader.getCurrField("codesorkindreg").ToString() +
						                    " alla riga:" + Reader.GetCurrRowNumber()
						);
						Reader.GetNext();
						continue;
					}
				}

				object idfin = DBNull.Value;
				object codefin = Reader.getCurrField("codicebil");
				if (codefin != DBNull.Value) {
					idfin = Conn.DO_READ_VALUE("fin", QHS.AppAnd(
						QHS.CmpEq("codefin", codefin),
						QHS.CmpEq("ayear", Reader.getCurrField("ayear")),
						(E_S == "E" ? QHS.BitClear("flag", 0) : QHS.BitSet("flag", 0))
					), "idfin");
					if (idfin == null || idfin == DBNull.Value) {
						SpeedSaver.AddError("Voce di bilancio non trovata: " +
						                    Reader.getCurrField("codefin").ToString() + "/" +
						                    Reader.getCurrField("ayear").ToString() +
						                    " alla riga:" + Reader.GetCurrRowNumber()
						);
						Reader.GetNext();
						continue;
					}
				}

				object idupb = DBNull.Value;
				object codeupb = Reader.getCurrField("codeupb");
				if (codeupb != DBNull.Value) {
					idupb = Conn.DO_READ_VALUE("upb", QHS.CmpEq("codeupb", codeupb), "idupb");
					if (idupb == null || idupb == DBNull.Value) {
						SpeedSaver.AddError("UPB non trovato: " +
						                    Reader.getCurrField("codeupb").ToString() +
						                    " alla riga:" + Reader.GetCurrRowNumber()
						);
						Reader.GetNext();
						continue;
					}
				}

				object idman = DBNull.Value;
				object man = Reader.getCurrField("resp");
				if (man != DBNull.Value) {
					idman = Conn.DO_READ_VALUE("manager", QHS.CmpEq("title", man), "idman");
					if (idman == null || idman == DBNull.Value) {
						SpeedSaver.AddError("Responsabile non trovato: " +
						                    Reader.getCurrField("resp").ToString() +
						                    " alla riga:" + Reader.GetCurrRowNumber()
						);
						Reader.GetNext();
						continue;
					}
				}

				MetaData.SetDefault(AutoMov, "ayear", Reader.getCurrField("ayear"));
				DataRow RAuto = MetaAuto.Get_New_Row(null, AutoMov);
				RAuto["numerator"] = Reader.getCurrField("numeratore");
				RAuto["denominator"] = Reader.getCurrField("denominatore");
				RAuto["idupb"] = idupb;
				RAuto["idfin"] = idfin;
				RAuto["idsorkind"] = idsorkind;
				RAuto["idsor"] = idsor;
				RAuto["idman"] = idman;
				RAuto["idsorkindreg"] = idsorkindReg;
				RAuto["idsorreg"] = idsorReg;

				Reader.GetNext();
			} //while (Reader.DataPresent()) 

			Reader.Close();


			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		private void btnResponsabiliCespiti_Click(object sender, EventArgs e) {
			ImportaResponsabiliCespiti();
		}

		private void btnUbicazioniCespiti_Click(object sender, EventArgs e) {
			ImportaUbicazioniCespiti();
		}

		private void btnSubConsegnatariCespiti_Click(object sender, EventArgs e) {
			ImportaSubConsegnatariCespiti();
		}

		bool ImportaResponsabiliCespiti() {
			//string[] tracciato_responsabilicespiti = new string[] {
			//"codiceinv;Codice Inventario;Stringa;20",
			//"descrinv;Descrizione Inventario;Stringa;50",
			//"numinv;Numero di inventario;Intero;8",
			//"nprogrmanager;Numero progressivo;Intero;5",
			//"datainizio;Data inizio validità;Data;8",
			//"manager;Denominazione manager;Stringa;150"
			// };

			LeggiFile Reader = GetReader(tracciato_responsabilicespiti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaResponsabiliCespiti();
			MetaData MetaAssetManager = Meta.Dispatcher.Get("assetmanager");
			MetaAssetManager.SetDefaults(D.Tables["assetmanager"]);
			DataTable AssetManager = D.Tables["assetmanager"];
			Conn.RUN_SELECT_INTO_TABLE(AssetManager, null, null, null, false);
			DataTable Inventory = D.Tables["inventory"];
			DataTable Manager = D.Tables["manager"];
			DataTable Location = D.Tables["location"];
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("inventory");
			tosync.Add("manager");
			tosync.Add("location");
			InitSpeedSaver(Conn, tosync);
			// Inizio il ciclo sulle righe
			Reader.Reset();
			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codeinventory = Reader.getCurrField("codiceinv").ToString();
				object idinventory = DBNull.Value;
				string filteridinv = QHC.CmpEq("codeinventory", codeinventory);
				if (Inventory.Select(filteridinv).Length == 0) {
					SpeedSaver.AddError("Codice inventario " + codeinventory + " non trovato. Riga" +
					                    Reader.GetCurrRowNumber());
					idinventory = 0;
				}
				else {
					idinventory = Inventory.Select(filteridinv)[0]["idinventory"];
				}

				int ninventory = CfgFn.GetNoNullInt32(Reader.getCurrField("numinv"));
				int idpiece = 1;

				//Determina idasset da idinventory+ninventory
				string filterasset = QHS.AppAnd(
					QHS.CmpEq("A1.idinventory", idinventory),
					QHS.CmpEq("A.ninventory", ninventory),
					QHS.CmpEq("A.idpiece", idpiece));

				object idasset = Conn.DO_SYS_CMD(
					"SELECT A.idasset from asset A join assetacquire A1 on A.nassetacquire =A1.nassetacquire WHERE " +
					filterasset, false);

				if (idasset == DBNull.Value || idasset == null) {
					SpeedSaver.AddError("Cespite " + ninventory.ToString() + "/" + codeinventory +
					                    " non trovato. Riga:" +
					                    Reader.GetCurrRowNumber());
					idasset = 0;
				}

				// Ricerca del responsabile
				object manager = Reader.getCurrField("manager");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) {
					string filter_exists = QHC.CmpEq("title", manager);
					if (Manager.Select(filter_exists).Length > 0) {
						idman = Manager.Select(filter_exists)[0]["idman"];
					}
					else {
						SpeedSaver.AddError("Responsabile " + manager.ToString() + " non trovato. Riga:" +
						                    Reader.GetCurrRowNumber());
					}
				}

				DataRow NewAssetManager = MetaAssetManager.Get_New_Row(null, AssetManager);
				NewAssetManager["idasset"] = idasset;
				NewAssetManager["idassetmanager"] = Reader.getCurrField("nprogrmanager");
				NewAssetManager["start"] = ToSmalldateTime(Reader.getCurrField("datainizio"));
				NewAssetManager["idman"] = idman;
				NewAssetManager["ct"] = DateTime.Now;
				NewAssetManager["lt"] = DateTime.Now;
				NewAssetManager["cu"] = "importazione";
				NewAssetManager["lu"] = "importazione";


				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			foreach (DataRow r in D.Tables["assetmanager"].Rows) {
				var sql = @"update asset set idcurrman = (select top 1 idman from assetmanager 
                                where assetmanager.idasset = asset.idasset 
                                order by isnull(start,'1900-01-01') desc),
                                lt = GetDate(), lu = 'upd_currman_import'
                            where " + QHS.AppAnd(QHS.CmpEq("idasset", r["idasset"]), QHS.CmpEq("idpiece", 1));
				Conn.SQLRunner(sql, true);
			}

			D.Clear();
			return LastRes;

		}

		bool ImportaUbicazioniCespiti() {
			//string[] tracciato_ubicazionicespiti = new string[] {
			//"codiceinv;Codice Inventario;Stringa;20",
			//"descrinv;Descrizione Inventario;Stringa;50",
			//"numinv;Numero di inventario;Intero;8",
			//"nprogrlocation;Numero progressivo;Intero;5",
			//"datainizio;Data inizio validità;Data;8",
			//"codeubic;Codice ubicazione;Stringa;50"
			//};

			LeggiFile Reader = GetReader(tracciato_ubicazionicespiti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaUbicazioniCespiti();
			MetaData MetaAssetLocation = Meta.Dispatcher.Get("assetlocation");
			MetaAssetLocation.SetDefaults(D.Tables["assetlocation"]);
			DataTable AssetLocation = D.Tables["assetlocation"];
			Conn.RUN_SELECT_INTO_TABLE(AssetLocation, null, null, null, false);
			DataTable Inventory = D.Tables["inventory"];
			DataTable Manager = D.Tables["manager"];
			DataTable Location = D.Tables["location"];
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("inventory");
			tosync.Add("manager");
			tosync.Add("location");
			InitSpeedSaver(Conn, tosync);
			// Inizio il ciclo sulle righe
			Reader.Reset();
			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codeinventory = Reader.getCurrField("codiceinv").ToString();
				object idinventory = DBNull.Value;
				string filteridinv = QHC.CmpEq("codeinventory", codeinventory);
				if (Inventory.Select(filteridinv).Length == 0) {
					SpeedSaver.AddError("Codice inventario " + codeinventory + " non trovato. Riga" +
					                    Reader.GetCurrRowNumber());
					idinventory = 0;
				}
				else {
					idinventory = Inventory.Select(filteridinv)[0]["idinventory"];
				}

				int ninventory = CfgFn.GetNoNullInt32(Reader.getCurrField("numinv"));
				int idpiece = 1;

				//Determina idasset da idinventory+ninventory
				string filterasset = QHS.AppAnd(
					QHS.CmpEq("A1.idinventory", idinventory),
					QHS.CmpEq("A.ninventory", ninventory),
					QHS.CmpEq("A.idpiece", idpiece));

				object idasset = Conn.DO_SYS_CMD(
					"SELECT A.idasset from asset A join assetacquire A1 on A.nassetacquire =A1.nassetacquire WHERE " +
					filterasset, false);

				if (idasset == DBNull.Value || idasset == null) {
					SpeedSaver.AddError("Cespite " + ninventory.ToString() + "/" + codeinventory +
					                    " non trovato. Riga:" +
					                    Reader.GetCurrRowNumber());
					idasset = 0;
				}

				// Ricerca del responsabile
				object codeubic = Reader.getCurrField("codeubic");
				object idlocation = DBNull.Value;
				if (codeubic != DBNull.Value) {
					string filter_exists = QHC.CmpEq("locationcode", codeubic);
					if (Location.Select(filter_exists).Length > 0) {
						idlocation = Location.Select(filter_exists)[0]["idlocation"];
					}
					else {
						SpeedSaver.AddError("Ubicazione " + codeubic.ToString() + " non trovato. Riga:" +
						                    Reader.GetCurrRowNumber());
					}
				}

				DataRow NewAssetLocation = MetaAssetLocation.Get_New_Row(null, AssetLocation);
				NewAssetLocation["idasset"] = idasset;
				NewAssetLocation["idassetlocation"] = Reader.getCurrField("nprogrlocation");
				NewAssetLocation["start"] = ToSmalldateTime(Reader.getCurrField("datainizio"));
				NewAssetLocation["idlocation"] = idlocation;
				NewAssetLocation["ct"] = DateTime.Now;
				NewAssetLocation["lt"] = DateTime.Now;
				NewAssetLocation["cu"] = "importazione";
				NewAssetLocation["lu"] = "importazione";


				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			foreach (DataRow r in D.Tables["assetlocation"].Rows) {
				/*
				 * 
				    
				 */
				var sql = @"update asset set idcurrlocation = (select top 1 idlocation from assetlocation 
                                where assetlocation.idasset = asset.idasset 
                                order by isnull(start,'1900-01-01') desc),
                                lt = GetDate(), lu = 'upd_currloc_import'
                            where " + QHS.AppAnd(QHS.CmpEq("idasset", r["idasset"]), QHS.CmpEq("idpiece", 1));
				Conn.SQLRunner(sql, true);
			}

			D.Clear();
			return LastRes;
		}

		bool ImportaSubConsegnatariCespiti() {
			//string[] tracciato_subconsegnataricespiti = new string[] {
			//      "codiceinv;Codice Inventario;Stringa;20",
			//      "descrinv;Descrizione Inventario;Stringa;50",
			//      "numinv;Numero di inventario;Intero;8",
			//      "nprogrsubmanager;Numero progressivo;Intero;5",
			//      "datainizio;Data inizio validità;Data;8",
			//      "subconsegnatario;Denominazione subconsegnatario;Stringa;150"
			//  };

			LeggiFile Reader = GetReader(tracciato_subconsegnataricespiti);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaSubConsegnatariCespiti();
			MetaData MetaAssetSubManager = Meta.Dispatcher.Get("assetsubmanager");
			MetaAssetSubManager.SetDefaults(D.Tables["assetsubmanager"]);
			DataTable AssetSubManager = D.Tables["assetsubmanager"];
			Conn.RUN_SELECT_INTO_TABLE(AssetSubManager, null, null, null, false);
			DataTable Inventory = D.Tables["inventory"];
			DataTable Manager = D.Tables["manager"];
			DataTable Location = D.Tables["location"];
			Conn.RUN_SELECT_INTO_TABLE(Inventory, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Location, null, null, null, false);

			List<string> tosync = new List<string>();
			tosync.Add("inventory");
			tosync.Add("manager");
			tosync.Add("location");
			InitSpeedSaver(Conn, tosync);
			// Inizio il ciclo sulle righe
			Reader.Reset();
			Reader.GetNext();

			while (Reader.DataPresent()) {
				string codeinventory = Reader.getCurrField("codiceinv").ToString();
				object idinventory = DBNull.Value;
				string filteridinv = QHC.CmpEq("codeinventory", codeinventory);
				if (Inventory.Select(filteridinv).Length == 0) {
					SpeedSaver.AddError("Codice inventario " + codeinventory + " non trovato. Riga" +
					                    Reader.GetCurrRowNumber());
					idinventory = 0;
				}
				else {
					idinventory = Inventory.Select(filteridinv)[0]["idinventory"];
				}

				int ninventory = CfgFn.GetNoNullInt32(Reader.getCurrField("numinv"));
				int idpiece = 1;

				//Determina idasset da idinventory+ninventory
				string filterasset = QHS.AppAnd(
					QHS.CmpEq("A1.idinventory", idinventory),
					QHS.CmpEq("A.ninventory", ninventory),
					QHS.CmpEq("A.idpiece", idpiece));

				object idasset = Conn.DO_SYS_CMD(
					"SELECT A.idasset from asset A join assetacquire A1 on A.nassetacquire =A1.nassetacquire WHERE " +
					filterasset, false);

				if (idasset == DBNull.Value || idasset == null) {
					SpeedSaver.AddError("Cespite " + ninventory.ToString() + "/" + codeinventory +
					                    " non trovato. Riga:" +
					                    Reader.GetCurrRowNumber());
					idasset = 0;
				}

				// Ricerca del responsabile
				object manager = Reader.getCurrField("subconsegnatario");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) {
					string filter_exists = QHC.CmpEq("title", manager);
					if (Manager.Select(filter_exists).Length > 0) {
						idman = Manager.Select(filter_exists)[0]["idman"];
					}
					else {
						SpeedSaver.AddError("Subconsegnatario " + manager.ToString() + " non trovato. Riga:" +
						                    Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}

				DataRow NewAssetSubManager = MetaAssetSubManager.Get_New_Row(null, AssetSubManager);
				NewAssetSubManager["idasset"] = idasset;
				NewAssetSubManager["idassetsubmanager"] = Reader.getCurrField("nprogrsubmanager");
				NewAssetSubManager["start"] = ToSmalldateTime(Reader.getCurrField("datainizio"));
				NewAssetSubManager["idmanager"] = idman;
				NewAssetSubManager["ct"] = DateTime.Now;
				NewAssetSubManager["lt"] = DateTime.Now;
				NewAssetSubManager["cu"] = "importazione";
				NewAssetSubManager["lu"] = "importazione";


				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			foreach (DataRow r in D.Tables["assetsubmanager"].Rows) {
				var sql = @"update asset set idcurrsubman = (select top 1 idman from assetsubmanager 
                                where assetsubmanager.idasset = asset.idasset 
                                order by isnull(start,'1900-01-01') desc),
                                lt = GetDate(), lu = 'upd_currsubman_import'
                            where " + QHS.AppAnd(QHS.CmpEq("idasset", r["idasset"]), QHS.CmpEq("idpiece", 1));
				Conn.SQLRunner(sql, true);
			}

			D.Clear();
			return LastRes;
		}

		private void btnRipartEPContrattiCSA_Click(object sender, EventArgs e) {
			ImportaRipImpegniBudgetContrattiCSA();
		}

		private void btnRipartEPContributiContrattiCSA_Click(object sender, EventArgs e) {
			ImportaRipImpegniBudgetContributoContrattiCSA();
		}

		private void btnImportaEntiCsa_Click(object sender, EventArgs e) {
			ImportaEntiCsa();
		}

		string[] tracciato_enticsa = new string[] {
			"ente;Ente CSA;Stringa;200",
			"descrizione;Descrizione;Stringa;200",
			"anagrafica;Anagrafica;Stringa;100",
			"interno;Ente interno (S/N);Codificato;1;S|N",
			"modalitapag;Nome Modalità pagamento;Stringa;50",
			"vocecsa;Voce Csa;Stringa;200",
			"versamentiposticipati;Versamenti Posticipati (S/N);Codificato;1;S|N",
			"nonassociaresospeso;Non associare sospeso (S/N);Codificato;1;S|N"
		};

		bool ImportaEntiCsa() {

			LeggiFile Reader = GetReader(tracciato_enticsa);
			if (Reader == null) return false;
			ClearAllNonDBOHash();
			DataSet D = new vistaEntiCsa();
			MetaData MetaCsaAgency = Meta.Dispatcher.Get("csa_agency");
			MetaCsaAgency.SetDefaults(D.Tables["csa_agency"]);
			DataTable CsaAgency = D.Tables["csa_agency"];

			MetaData MetaCsaAgencyPay = Meta.Dispatcher.Get("csa_agencypaymethod");
			MetaCsaAgencyPay.SetDefaults(D.Tables["csa_agencypaymethod"]);
			DataTable CsaAgencyPay = D.Tables["csa_agencypaymethod"];


			Conn.RUN_SELECT_INTO_TABLE(CsaAgency, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(CsaAgencyPay, null, null, null, false);
			List<string> tosync = new List<string>();
			tosync.Add("inventory");
			tosync.Add("manager");
			tosync.Add("location");
			InitSpeedSaver(Conn, tosync);
			// Inizio il ciclo sulle righe
			Reader.Reset();
			Reader.GetNext();

			while (Reader.DataPresent()) {
				object ente = Reader.getCurrField("ente");
				object description = Reader.getCurrField("descrizione");
				object isinternal = Reader.getCurrField("interno");
				object versamentiposticipati = Reader.getCurrField("versamentiposticipati");
				object nonassociaresospeso = Reader.getCurrField("nonassociaresospeso");
				string title = Reader.getCurrField("anagrafica").ToString();
				object vocecsa = Reader.getCurrField("vocecsa");
				object regmodcode = Reader.getCurrField("modalitapag");
				string chkexists = QHS.AppAnd(QHS.CmpEq("title", title), QHS.CmpEq("active", "S"));
				object idreg_found = Conn.DO_READ_VALUE("registry", chkexists, "idreg");
				if (idreg_found == null) idreg_found = DBNull.Value;
				DataRow NewCsaAgencyRow;
				DataRow[] main = CsaAgency.Select(QHC.CmpEq("description", description));
				if (main.Length > 0) {
					NewCsaAgencyRow = main[0];
				}
				else {
					NewCsaAgencyRow = MetaCsaAgency.Get_New_Row(null, CsaAgency);
					NewCsaAgencyRow["description"] = description;
				}

				NewCsaAgencyRow["ente"] = description;
				NewCsaAgencyRow["idreg"] = idreg_found;
				NewCsaAgencyRow["isinternal"] = isinternal;
				int flag = 0;
				if (versamentiposticipati.ToString().ToUpper() == "S") {
					flag = flag | 1;
				}

				if (nonassociaresospeso.ToString().ToUpper() == "S") {
					flag = flag | 2;
				}

				NewCsaAgencyRow["flag"] = flag;
				if (vocecsa == DBNull.Value || regmodcode == DBNull.Value) {
					Reader.GetNext();
					continue;
				}






				DataRow[] mainpay = CsaAgencyPay.Select(QHC.AppAnd(
					QHC.CmpEq("idcsa_agency", NewCsaAgencyRow["idcsa_agency"]), QHC.CmpEq("vocecsa", vocecsa)));
				DataRow CsaPayRow;
				if (mainpay.Length > 0) {
					CsaPayRow = mainpay[0];
				}
				else {
					CsaPayRow = MetaCsaAgencyPay.Get_New_Row(NewCsaAgencyRow, CsaAgencyPay);
					CsaPayRow["vocecsa"] = vocecsa;
				}

				object idregistrypaymethod = Conn.DO_READ_VALUE("registrypaymethod",
					QHS.AppAnd(QHS.CmpEq("idreg", idreg_found), QHS.CmpEq("regmodcode", regmodcode)),
					"idregistrypaymethod");
				if (idregistrypaymethod == null || idregistrypaymethod == DBNull.Value) {
					SpeedSaver.AddError($"modalità di pagamento {regmodcode} non trovata per anagrafica {title}");
					Reader.GetNext();
					continue;
				}

				CsaPayRow["idregistrypaymethod"] = idregistrypaymethod;
				CsaPayRow["idreg"] = idreg_found;


				Reader.GetNext();

			} //while (Reader.DataPresent()) 

			Reader.Close();

			bool LastRes = SaveData(D, true);
			D.Clear();
			return LastRes;
		}

		private void btnRipartUnicaContrattiCSA_Click(object sender, EventArgs e) {
			ImportaRipUnicaContrattiCSA();
		}

		private void btnRipartUnicaContributiContrattiCSA_Click(object sender, EventArgs e) {
			ImportaRipUnicaContributoContrattiCSA();
		}

		private void btnImportEpexpEpacc_Click(object sender, EventArgs e) {
			ImportaMovBudget();
		}

		bool ImportaMovBudget() {

			LeggiFile Reader = GetReader(tracciato_movbudget);
			if (Reader == null) return false;
			ClearAllNonDBOHash();

			DataSet D = new VistaMovBudget();

			DataTable EpExp = D.Tables["epexp"];
			MetaData MetaEpExp = Meta.Dispatcher.Get("epexp");
			MetaEpExp.SetDefaults(EpExp);

			DataTable EpAcc = D.Tables["epacc"];
			MetaData MetaEpAcc = Meta.Dispatcher.Get("epacc");
			MetaEpAcc.SetDefaults(EpAcc);

			DataTable EpExpYear = D.Tables["epexpyear"];
			MetaData MetaEpExpYear = Meta.Dispatcher.Get("epexpyear");
			MetaEpExpYear.SetDefaults(EpExpYear);

			DataTable EpAccYear = D.Tables["epaccyear"];
			MetaData MetaEpAccYear = Meta.Dispatcher.Get("epaccyear");
			MetaEpAccYear.SetDefaults(EpAccYear);

			DataTable Upb = D.Tables["upb"];
			MetaData MetaUpb = Meta.Dispatcher.Get("upb");
			MetaUpb.SetDefaults(Upb);

			DataTable Manager = D.Tables["manager"];
			MetaData MetaManager = Meta.Dispatcher.Get("manager");
			MetaManager.SetDefaults(Manager);

			Conn.RUN_SELECT_INTO_TABLE(Upb, null, null, null, false);
			Conn.RUN_SELECT_INTO_TABLE(Manager, null, null, null, false);
			DataTable AccMotive = Conn.RUN_SELECT("accmotive", "*", null, null, null, false);
			List<string> tosync = new List<string>();
			tosync.Add("manager");
			tosync.Add("upb");
			InitSpeedSaver(Conn, tosync);

			Reader.GetNext();
			string last_sign = "X";
			int nrow = 0;
			while (Reader.DataPresent()) {
				string tipo = Reader.getCurrField("tipo").ToString().ToUpper(); // A/I
				object yep = Reader.getCurrField("ymov");
				object nep = Reader.getCurrField("nmov");
				object ayear = Reader.getCurrField("ayear");
				object adate = Reader.getCurrField("adate");
				object docdate = Reader.getCurrField("docdate");
				int nfase = CfgFn.GetNoNullInt32(Reader.getCurrField("nliv"));
				string sign = tipo + "-" + yep.ToString() + "-" + nfase.ToString() + "-" + ayear.ToString();
				if ((nrow > 0) && (nrow > 1000 || sign != last_sign)) {
					if (!SaveData(D, false)) break;

					EpAccYear.Clear();
					EpAccYear.Clear();
					EpExp.Clear();
					EpAcc.Clear();

					nrow = 0;
				}

				last_sign = sign;

				string me = Reader.getCurrField("descliv") + " del " + yep.ToString();

				//string finpart = tipo;
				string codeacc = Reader.getCurrField("codiceconto").ToString();
				string searchAcc = getSqlFilterAcc(codeacc, ayear);
				object idacc = DBNull.Value;
				if (codeacc != "") {
					idacc = Conn.DO_READ_VALUE("account", searchAcc, "idacc");
					if (idacc == DBNull.Value || idacc == null) {
						SpeedSaver.AddError(me + ": Conto " + codeacc + " del " +
						                    ayear.ToString() +
						                    " non è stato trovato, riga" + Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}
				}
				else {
					SpeedSaver.AddError(me + ": Conto assente, riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}

				string codeupb = Reader.getCurrField("codiceupb").ToString();
				string searchupb = QHC.CmpEq("codeupb", codeupb);
				object idupb = DBNull.Value;
				if (codeupb != "") {
					if (Upb.Select(searchupb).Length == 0) {
						SpeedSaver.AddError("L'upb di codice " + codeupb + " non è stato trovato, riga:" +
						                    Reader.GetCurrRowNumber());
						Reader.GetNext();
						continue;
					}

					idupb = Upb.Select(searchupb)[0]["idupb"];
				}
				else {
					SpeedSaver.AddError(me + ": upb assente, riga:" + Reader.GetCurrRowNumber());
					Reader.GetNext();
					continue;
				}


				object manager = Reader.getCurrField("resp");
				object idman = DBNull.Value;
				if (manager != DBNull.Value) idman = GetManager(Manager, manager.ToString(), null);

				string fmovS = QHS.AppAnd(QHS.CmpEq("yepexp", yep), QHS.CmpEq("nepexp", nep),
					QHS.CmpEq("nphase", nfase));
				string fmovE = QHS.AppAnd(QHS.CmpEq("yepacc", yep), QHS.CmpEq("nepacc", nep),
					QHS.CmpEq("nphase", nfase));
				string fparentmovS = QHS.AppAnd(QHS.CmpEq("yepexp", Reader.getCurrField("parentymov")),
					QHS.CmpEq("nepexp", Reader.getCurrField("parentnmov")),
					QHS.CmpEq("nphase", nfase - 1));
				string fparentmovE = QHS.AppAnd(QHS.CmpEq("yepacc", Reader.getCurrField("parentymov")),
					QHS.CmpEq("nepacc", Reader.getCurrField("parentnmov")),
					QHS.CmpEq("nphase", nfase - 1));
				object descr;
				//Impegno - preimpegno di budget
				if (tipo == "I") {
					object paridepexp = DBNull.Value;
					if (nfase > 1) {
						paridepexp = Conn.DO_READ_VALUE("epexp", fparentmovS, "idepexp");
						if (paridepexp == DBNull.Value || paridepexp == null) {
							SpeedSaver.AddError(me +
							                    ": movimento parent non trovato, possibile errato ordine righe file. Riga:"
							                    + Reader.GetCurrRowNumber());
							Reader.GetNext();
							paridepexp = DBNull.Value;
							continue;
						}
					}


					DataRow RExp = null;
					object idepexp = Conn.DO_READ_VALUE("epexp", fmovS, "idepexp");
					bool new_idepexp = false;
					//Creazione/recupero movimento di spesa
					if (idepexp == null || idepexp == DBNull.Value) {
						//Crea il movimento 
						RExp = MetaEpExp.Get_New_Row(null, EpExp);
						int idepexp2 = CfgFn.GetNoNullInt32(RExp["idepexp"]);
						if (idepexp2 < 10000000) idepexp2 = 10000000;
						RExp["idepexp"] = idepexp2;
						RowChange.ClearAutoIncrement(EpExp.Columns["nepexp"]);
						RExp["paridepexp"] = paridepexp;
						RExp["nphase"] = nfase;
						RExp["yepexp"] = yep;
						RExp["nepexp"] = nep;
						descr = Reader.getCurrField("description");
						if (descr == DBNull.Value) {
							SpeedSaver.AddWarning(me + ": descrizione vuota sostituita con un punto. Riga:" +
							                      Reader.GetCurrRowNumber());
							descr = ".";
						}

						RExp["idreg"] = Reader.getCurrField("idreg");
						RExp["description"] = descr;
						RExp["doc"] = Reader.getCurrField("doc");
						RExp["docdate"] = ToSmalldateTimeNoHours(docdate);
						RExp["txt"] = Reader.getCurrField("note");
						RExp["adate"] = ToSmalldateTimeNoHours(adate);
						RExp["idman"] = idman;
						object flagvariation = Reader.getCurrField("flagvariation");
						if (flagvariation != DBNull.Value) {
							RExp["flagvariation"] = flagvariation;
						}
						else {
							RExp["flagvariation"] = "N";
						}

						RExp["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causale"));
						new_idepexp = true;

					}
					else {
						Conn.RUN_SELECT_INTO_TABLE(EpExp, null, fmovS, null, true);
						RExp = EpExp.Select(QHC.CmpEq("idepexp", idepexp))[0];
					}

					bool new_epexpyear = true;
					//Verifica se esiste exp.year
					if (new_idepexp == false) {
						string fltexpyear = QHS.AppAnd(QHS.CmpEq("idepexp", idepexp), QHS.CmpEq("ayear", ayear));
						if (Conn.RUN_SELECT_COUNT("epexpyear", fltexpyear, false) > 0) new_epexpyear = false;
					}

					if (new_epexpyear) {
						object amount = Reader.getCurrField("amount"); 
						if (amount == DBNull.Value) {
							RExp.RejectChanges();
							SpeedSaver.AddWarning(me + ": campo importo iniziale mancante. Riga:" +
							                      Reader.GetCurrRowNumber());
							continue;
						}

						//Mette expenseyear 
						DataRow REY = MetaEpExpYear.Get_New_Row(RExp, EpExpYear);
						REY["ayear"] = ayear;
						REY["idacc"] = idacc;
						REY["idupb"] = idupb;
						REY["amount"] = Reader.getCurrField("amount");
						REY["amount2"] = Reader.getCurrField("amount2");
						REY["amount3"] = Reader.getCurrField("amount3");
						REY["amount4"] = Reader.getCurrField("amount4");
						REY["amount5"] = Reader.getCurrField("amount5");
					}

				} //if (tipo=="I")
				else {
					object paridepacc = DBNull.Value;
					if (nfase > 1) {
						paridepacc = Conn.DO_READ_VALUE("epacc", fparentmovE, "idepacc");
						if (paridepacc == DBNull.Value || paridepacc == null) {
							SpeedSaver.AddError(me +
							                    ": movimento parent non trovato, possibile errato ordine righe file. Riga:"
							                    + Reader.GetCurrRowNumber());
							paridepacc = DBNull.Value;
							Reader.GetNext();
							continue;
						}
					}


					DataRow Rinc = null;
					object idepacc = Conn.DO_READ_VALUE("epacc", fmovE, "idepacc");
					bool new_idepacc = false;
					//Creazione/recupero movimento di spesa
					if (idepacc == null || idepacc == DBNull.Value) {
						//Crea il movimento 
						Rinc = MetaEpAcc.Get_New_Row(null, EpAcc);
						int idepacc2 = CfgFn.GetNoNullInt32(Rinc["idepacc"]);
						if (idepacc2 < 10000000) idepacc2 = 10000000;
						Rinc["idepacc"] = idepacc2;
						RowChange.ClearAutoIncrement(EpAcc.Columns["nepacc"]);
						Rinc["paridepacc"] = paridepacc;
						Rinc["nphase"] = nfase;
						Rinc["yepacc"] = yep;
						Rinc["nepacc"] = nep;
						descr = Reader.getCurrField("description");
						if (descr == DBNull.Value) {
							SpeedSaver.AddWarning(me + ": descrizione vuota sostituita con un punto. Riga:" +
							                      Reader.GetCurrRowNumber());
							descr = ".";
						}

						Rinc["description"] = descr;
						Rinc["doc"] = Reader.getCurrField("doc");
						Rinc["docdate"] = ToSmalldateTimeNoHours(docdate);
						Rinc["txt"] = Reader.getCurrField("note");
						Rinc["adate"] = ToSmalldateTimeNoHours(adate);
						Rinc["idman"] = idman;
						Rinc["idreg"] = Reader.getCurrField("idreg");
						object flagvariation = Reader.getCurrField("flagvariation");
						if (flagvariation != DBNull.Value) {
							Rinc["flagvariation"] = flagvariation;
						}
						else {
							Rinc["flagvariation"] = "N";
						}

						Rinc["idaccmotive"] = CheckAccMotive(AccMotive, Reader.getCurrField("causale"));
						new_idepacc = true;
					}
					else {
						Conn.RUN_SELECT_INTO_TABLE(EpAcc, null, fmovE, null, true);
						Rinc = EpAcc.Select(QHC.CmpEq("idepacc", idepacc))[0];
					}

					bool new_incyear = true;
					//Verifica se esiste exp.year
					if (new_incyear == false) {
						string fltincyear = QHS.AppAnd(QHS.CmpEq("idepacc", idepacc), QHS.CmpEq("ayear", ayear));
						if (Conn.RUN_SELECT_COUNT("epaccyear", fltincyear, false) > 0) new_incyear = false;
					}

					if (new_incyear) {
						//Mette expenseyear 
						DataRow RIY = MetaEpAccYear.Get_New_Row(Rinc, EpAccYear);
						RIY["ayear"] = ayear;
						RIY["idacc"] = idacc;
						RIY["idupb"] = idupb;
						RIY["amount"] = Reader.getCurrField("amount");
						RIY["amount2"] = Reader.getCurrField("amount2");
						RIY["amount3"] = Reader.getCurrField("amount3");
						RIY["amount4"] = Reader.getCurrField("amount4");
						RIY["amount5"] = Reader.getCurrField("amount5");
					}

				}

				nrow++;
				Reader.GetNext();
			}

			Reader.Close();

			bool res = SaveData(D, true);
			return res;
		}

		private void btnImportEpexpvarEpexpvar_Click(object sender, EventArgs e) {
			ImportaVarMovBudget(false);
		}

		private void btnImportEpexpvarEpexpvar_trg_Click(object sender, EventArgs e) {
			ImportaVarMovBudget(true);
		}

		private void btnFlussiStudenti_Click(object sender, EventArgs e) {
            ImportCorsoLaurea();
		}

		string[] tracciato_corsolaurea = new string[] {
            "idstipcorsolaurea;ID Corso di Laurea;Intero;10",
			"codicecorsolaurea;Codice Corso di Laurea;Stringa;20",
            "descrizionecorsolaurea;Descrizione Corso di Laurea;Stringa;200",
            "codicedipartimento;Codice Dipartimento;Stringa;20",
            "descrizionedipartimento;Descrizione Dipartimento;Stringa;120",
            "codicepercorso;Codice Percorso;Stringa;20",
            "descrizionepercorso;Descrizione Percorso;Stringa;200",
            "anno;Anno;Intero;4",
			"codicesede;Codice Sede;Stringa;20",
			"descrizionesede;Descrizione Sede;Stringa;120",
            "codiceupb;Codice upb;Stringa;50",
			"descrizione;Descrizione;Stringa;200",
			"codicecausale;Codice Causale;Stringa;20",
			"descrizionecausale;Descrizione Causale;Stringa;200",
			"codicetassa;Codice Tassa;Stringa;50",
			"codicevoce;Codice Voce;Stringa;50",
			"codclass1;Codice class. 1;Stringa;50",
			"codclass2;Codice class. 2;Stringa;50",
			"codclass3;Codice class. 3;Stringa;50",
		};

        bool ImportCorsoLaurea() {
			LeggiFile Reader = GetReader(tracciato_corsolaurea);

			object idtipoclass1 = Conn.readValue("config", q.eq("ayear", Conn.GetEsercizio()), "idsortingkind1");
			object idtipoclass2 = Conn.readValue("config", q.eq("ayear", Conn.GetEsercizio()), "idsortingkind2");
			object idtipoclass3 = Conn.readValue("config", q.eq("ayear", Conn.GetEsercizio()), "idsortingkind3");
			if (idtipoclass1 == DBNull.Value) idtipoclass1 = null;
			if (idtipoclass2 == DBNull.Value) idtipoclass2 = null;
			if (idtipoclass3 == DBNull.Value) idtipoclass3 = null;

			int[] idsortingkind = new int[] {0, CfgFn.GetNoNullInt32(idtipoclass1),CfgFn.GetNoNullInt32(idtipoclass2),CfgFn.GetNoNullInt32(idtipoclass3)};
			if (Reader == null)
				return false;

			ClearAllNonDBOHash();
			DataSet dataset = new vistaCorsoLaurea();

			DataTable CorsoLaurea = dataset.Tables["stip_corsolaurea"];
			MetaData MetaCorsoLaurea = Meta.Dispatcher.Get("stip_corsolaurea");
			MetaCorsoLaurea.SetDefaults(CorsoLaurea);
            GetSortCached.Init();

            Dictionary<String, String> dictUPB = new Dictionary<string, string>();
			Dictionary<String, int> dictTassa = new Dictionary<string, int>();
			Dictionary<String, int> dictVoce = new Dictionary<string, int>();

			List<string> tosync = new List<string>();
			InitSpeedSaver(Conn, tosync);

            DataRow[] stipRow = null;
            q filter;

            Reader.GetNext();

			while (Reader.DataPresent()) {
				object idstiptassa = DBNull.Value;
				string codicetassa = Reader.getCurrField("codicetassa").ToString();

				if (codicetassa != "") {
					if (!dictTassa.ContainsKey(codicetassa)) {
						idstiptassa = Conn.readValue("stip_tassa", q.eq("codicetassa", codicetassa), "idstiptassa");

						if (idstiptassa == DBNull.Value || idstiptassa == null) {
							SpeedSaver.AddError($"La Tassa di codice {codicetassa} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
							Reader.GetNext();
							continue;
						}

						
						dictTassa.Add(codicetassa, Int32.Parse(idstiptassa.ToString()));
					}
					else {
						idstiptassa = dictTassa[codicetassa];
					}
				}

				object idstipvoce= DBNull.Value;
				string codicevoce = Reader.getCurrField("codicevoce").ToString();

				if (codicevoce != "") {
					if (!dictVoce.ContainsKey(codicevoce)) {
						idstipvoce = Conn.readValue("stip_voce", q.eq("codicevoce", codicevoce), "idstipvoce");

						if (idstipvoce == DBNull.Value || idstipvoce == null) {
							SpeedSaver.AddError($"La Voce di codice {codicevoce} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
							Reader.GetNext();
							continue;
						}
						dictVoce.Add(codicevoce, Int32.Parse(idstipvoce.ToString()));
					}
					else {
						idstipvoce = dictVoce[codicevoce];
					}
				}


                // Campi Filtro
                if (Reader.getCurrField("idstipcorsolaurea").ToString() != "") {
                    stipRow = CorsoLaurea._get(Conn, q.eq("idstipcorsolaurea", Reader.getCurrField("idstipcorsolaurea")));

                    if (stipRow.Length == 0) {
                        SpeedSaver.AddError($"idstipcorsolaurea {Reader.getCurrField("idstipcorsolaurea").ToString()} non presente, riga:{Reader.GetCurrRowNumber()}");
                        Reader.GetNext();

                        continue;
                    }
                }

                else {
	                if (Reader.getCurrField("codicecorsolaurea").ToString() == "") {
		                SpeedSaver.AddError($"CodiceCorsoLaurea non presente, riga:{Reader.GetCurrRowNumber()}");
		                Reader.GetNext();

		                continue;
	                }

	                if (Reader.getCurrField("codicedipartimento").ToString() == "") {
		                SpeedSaver.AddError($"Codicedipartimento non presente, riga:{Reader.GetCurrRowNumber()}");
		                Reader.GetNext();
		                continue;
	                }

	                if (Reader.getCurrField("codicepercorso").ToString() == "") {
		                SpeedSaver.AddError($"Codicepercorso non presente, riga:{Reader.GetCurrRowNumber()}");
		                Reader.GetNext();

		                continue;
	                }

	                filter = q.eq("codicecorsolaurea", Reader.getCurrField("codicecorsolaurea"));
	                string message = "Codicecorsolaurea " + Reader.getCurrField("codicecorsolaurea").ToString();

	                filter &= q.eq("codicedipartimento", Reader.getCurrField("codicedipartimento"));
	                message += ", Codicedipartimento " + Reader.getCurrField("codicedipartimento").ToString();

	                filter &= q.eq("codicepercorso", Reader.getCurrField("codicepercorso"));
	                message += ", Codicepercorso " + Reader.getCurrField("codicepercorso").ToString();

	                if (idstiptassa == DBNull.Value) {
		                filter &= q.isNull("idstiptassa");
	                }
	                else {
		                filter &= q.eq("idstiptassa", idstiptassa);
	                }

	                if (idstipvoce == DBNull.Value) {
		                filter &= q.isNull("idstipvoce");
	                }
	                else {
		                filter &= q.eq("idstipvoce", idstipvoce);
	                }

	                if (Reader.getCurrField("anno").ToString() != "") {
		                filter &= q.eq("anno", Reader.getCurrField("anno"));
		                message += ", Anno " + Reader.getCurrField("anno").ToString();
	                }
	                
	                stipRow = CorsoLaurea._get(Conn, filter);

	                if (stipRow.Length != 0 && stipRow.Length > 1) {
		                SpeedSaver.AddWarning($"La riga con filtro {message} è stata ignorata perchè ambigua, riga:{Reader.GetCurrRowNumber()}");
		                Reader.GetNext();
		                continue;
	                }
	                if(stipRow.Length == 0) {
		                stipRow = new DataRow[] { MetaCorsoLaurea.Get_New_Row(null, CorsoLaurea) };
		                stipRow[0]["codicecorsolaurea"] = Reader.getCurrField("codicecorsolaurea");
		                stipRow[0]["codicedipartimento"] = Reader.getCurrField("codicedipartimento");
		                stipRow[0]["codicepercorso"] = Reader.getCurrField("codicepercorso");
		                stipRow[0]["idstiptassa"] = idstiptassa;
		                stipRow[0]["idstipvoce"] =idstipvoce;
	                }
                }

				DataRow stip_corsolaurea = stipRow[0];

                // Campi Modificabili
                // descrizionecorsolaurea
                stip_corsolaurea["descrizionecorsolaurea"] = DBNull.Value;

                if (Reader.getCurrField("descrizionecorsolaurea").ToString() != "") {
					stip_corsolaurea["descrizionecorsolaurea"] = Reader.getCurrField("descrizionecorsolaurea").ToString();
				}

                // dipartimento
                stip_corsolaurea["dipartimento"] = DBNull.Value;

                if (Reader.getCurrField("descrizionedipartimento").ToString() != "") {
                    stip_corsolaurea["dipartimento"] = Reader.getCurrField("descrizionedipartimento").ToString();
                }

                // percorso
                stip_corsolaurea["percorso"] = DBNull.Value;

                if (Reader.getCurrField("descrizionepercorso").ToString() != "") {
                    stip_corsolaurea["percorso"] = Reader.getCurrField("descrizionepercorso").ToString();
                }

                // anno
                stip_corsolaurea["anno"] = DBNull.Value;

                if (Reader.getCurrField("anno").ToString() != "") {
                    stip_corsolaurea["anno"] = Reader.getCurrField("anno").ToString();
                }

                // codicesede
                if (Reader.getCurrField("codicesede").ToString() == "") {
                    SpeedSaver.AddError($"Codicesede non presente, riga:{Reader.GetCurrRowNumber()}");
                    stip_corsolaurea.RejectChanges();
                    Reader.GetNext();

                    continue;
                }

                else {
                    stip_corsolaurea["codicesede"] = Reader.getCurrField("codicesede").ToString();
                }

                // sede
                stip_corsolaurea["sede"] = DBNull.Value;

                if (Reader.getCurrField("descrizionesede").ToString() != "") {
					stip_corsolaurea["sede"] = Reader.getCurrField("descrizionesede").ToString();
				}

                // codicecausale
                stip_corsolaurea["codicecausale"] = DBNull.Value;

                if (Reader.getCurrField("codicecausale").ToString() != "") {
					stip_corsolaurea["codicecausale"] = Reader.getCurrField("codicecausale").ToString();
				}

                // causale
                stip_corsolaurea["causale"] = DBNull.Value;

                if (Reader.getCurrField("descrizionecausale").ToString() != "") {
					stip_corsolaurea["causale"] = Reader.getCurrField("descrizionecausale").ToString();
				}

                // descrizione
                stip_corsolaurea["descrizione"] = DBNull.Value;

                if (Reader.getCurrField("descrizione").ToString() != "") {
					stip_corsolaurea["descrizione"] = Reader.getCurrField("descrizione").ToString();
				}

                // idupb
                stip_corsolaurea["idupb"] = DBNull.Value;
                string codeupb = Reader.getCurrField("codiceupb").ToString();

				if (codeupb != "") {
					if (!dictUPB.ContainsKey(codeupb)) {
						object idupb = Conn.readValue("upb", q.eq("codeupb", codeupb), "idupb");
						
						if (idupb == DBNull.Value || idupb == null) {
							SpeedSaver.AddError($"L'upb di codice {codeupb} non è stato trovato, riga:{Reader.GetCurrRowNumber()}");
							stip_corsolaurea.RejectChanges();
							Reader.GetNext();

							continue;
						}

						stip_corsolaurea["idupb"] = idupb;
						dictUPB.Add(codeupb, idupb.ToString());
					}
					else {
						stip_corsolaurea["idupb"] = dictUPB[codeupb];
					}
				}

              
                

				// idsor1, idsor2, idsor3
				bool error = false;

				for (int nsor = 1; nsor <= 3; nsor++) {
					stip_corsolaurea["idsor" + nsor.ToString()] = GetSortCached.GetSortN(Conn,
						idsortingkind[nsor],
						Reader.getCurrField("codclass" + nsor.ToString()).ToString(), out error);

					if (error) {
						SpeedSaver.AddError("Codice Attributo n." + nsor.ToString() +
						                    " di codice " + Reader.getCurrField("codclass" + nsor.ToString()) +
						                    " inesistente alla riga " + Reader.GetCurrRowNumber());
					}
				}

                Reader.GetNext();
			}

			Reader.Close();
			bool result = SaveData(dataset, true);
			dataset.Clear();

			return result;
		}

		private void btnAssociaTassaFlussiStudenti_Click(object sender, EventArgs e) {
            ImportStipDecodifica();
		}

		string[] tracciato_stipdecodifica = new string[] {
            "idstipdecodifica;ID Decodifica;Intero;10",
            "codicetassa;Codice Tassa;Stringa;50",
            "codicevoce;Codice Voce;Stringa;50",
            "idstipcorsolaurea;ID Corso di Laurea;Intero;10",
            "causalericavo;Codice causale ricavo; Stringa;50",
            "causalecredito;Codice causale di credito; Stringa;50",
            "causalebilancioentrata;Codice causale bilancio di entrata;Stringa;50",
            "causaleannulloentroanno; Codice causale di annullo entro l'anno di emissione; Stringa;50",
            "causaleannullooltreanno; Codice causale di annullo oltre l'anno di emissione; Stringa;50",
            "tipocontratto;Tipo contratto attivo; Stringa;20",
        };

		bool ImportStipDecodifica() {
            LeggiFile Reader = GetReader(tracciato_stipdecodifica);

            if (Reader == null)
                return false;

            ClearAllNonDBOHash();
            DataSet dataset = new vistaStipDecodifica();

            DataTable StipDecodifica = dataset.Tables["stip_decodifica"];
            MetaData MetaStipDecodifica = Meta.Dispatcher.Get("stip_decodifica");
            MetaStipDecodifica.SetDefaults(StipDecodifica);

            List<int> dictCorsolaurea = new List<int>();
            List<string> dictEstimate = new List<string>();
            Dictionary<String, int> dictTassa = new Dictionary<string, int>();
            Dictionary<String, int> dictVoce = new Dictionary<string, int>();
            Dictionary<String, String> dictAccmotive = new Dictionary<string, string>();
            Dictionary<String, String> dictFinmotive = new Dictionary<string, string>();

            List<string> tosync = new List<string>();
            InitSpeedSaver(Conn, tosync);

            DataRow[] stipRow = null;
            q filter;

            Reader.GetNext();

            while (Reader.DataPresent()) {
                if (Reader.getCurrField("codicetassa").ToString() == "") {
                    SpeedSaver.AddError($"codicetassa non presente, riga:{Reader.GetCurrRowNumber()}");
                    Reader.GetNext();

                    continue;
                }

                if (Reader.getCurrField("codicevoce").ToString() == "") {
                    SpeedSaver.AddError($"codicevoce non presente, riga:{Reader.GetCurrRowNumber()}");
                    Reader.GetNext();

                    continue;
                }

                if (Reader.getCurrField("idstipdecodifica").ToString() != "") {
                    stipRow = StipDecodifica._get(Conn, q.eq("idstipdecodifica", Reader.getCurrField("idstipdecodifica")));

                    if (stipRow.Length == 0) {
                        SpeedSaver.AddError($"idstipdecodifica {Reader.getCurrField("idstipdecodifica").ToString()} non presente, riga:{Reader.GetCurrRowNumber()}");
                        Reader.GetNext();

                        continue;
                    }
                }

                else {
                    stipRow = new DataRow[] { MetaStipDecodifica.Get_New_Row(null, StipDecodifica) };
                }

                DataRow stip_decodifica = stipRow[0];

                // idstiptassa
                string codicetassa = Reader.getCurrField("codicetassa").ToString();

                if (!dictTassa.ContainsKey(codicetassa)) {
                    object idstiptassa = Conn.readValue("stip_tassa", q.eq("codicetassa", codicetassa), "idstiptassa");

                    if (idstiptassa == DBNull.Value || idstiptassa == null) {
                        SpeedSaver.AddError($"La Tassa di codice {codicetassa} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                        Reader.GetNext();

                        continue;
                    }

                    stip_decodifica["idstiptassa"] = idstiptassa;
                    dictTassa.Add(codicetassa, Int32.Parse(idstiptassa.ToString()));
                }
                else {
                    stip_decodifica["idstiptassa"] = dictTassa[codicetassa];
                }

                // idstipvoce
                string codicevoce = Reader.getCurrField("codicevoce").ToString();

                if (!dictVoce.ContainsKey(codicevoce)) {
                    object idstipvoce = Conn.readValue("stip_voce", q.eq("codicevoce", codicevoce), "idstipvoce");

                    if (idstipvoce == DBNull.Value || idstipvoce == null) {
                        SpeedSaver.AddError($"La Voce di codice {codicevoce} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                        Reader.GetNext();

                        continue;
                    }

                    stip_decodifica["idstipvoce"] = idstipvoce;
                    dictVoce.Add(codicevoce, Int32.Parse(idstipvoce.ToString()));
                }
                else {
                    stip_decodifica["idstipvoce"] = dictVoce[codicevoce];
                }

                // idstipcorsolaurea
                stip_decodifica["idstipcorsolaurea"] = DBNull.Value;
                string idcorsolaurea = Reader.getCurrField("idstipcorsolaurea").ToString();

                if (idcorsolaurea != "") {
                    if (!dictCorsolaurea.Contains(Int32.Parse(idcorsolaurea))) {
                        object idstipcorsolaurea = Conn.readValue("stip_corsolaurea", q.eq("idstipcorsolaurea", idcorsolaurea), "idstipcorsolaurea");

                        if (idstipcorsolaurea == DBNull.Value || idstipcorsolaurea == null) {
                            SpeedSaver.AddError($"Il Corso di laurea con ID {idcorsolaurea} non è stato trovato, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idstipcorsolaurea"] = idstipcorsolaurea;
                        dictCorsolaurea.Add(Int32.Parse(idcorsolaurea));
                    }
                    else {
                        stip_decodifica["idstipcorsolaurea"] = idcorsolaurea;
                    }
                }

                // idfinmotive
                stip_decodifica["idfinmotive"] = DBNull.Value;
                string causalebilancioentrata = Reader.getCurrField("causalebilancioentrata").ToString();

                if (causalebilancioentrata != "") {
                    if (!dictFinmotive.ContainsKey(causalebilancioentrata)) {
                        object idfinmotive = Conn.readValue("finmotive", q.eq("codemotive", causalebilancioentrata), "idfinmotive");

                        if (idfinmotive == DBNull.Value || idfinmotive == null) {
                            SpeedSaver.AddError($"La Causale di annullo oltre l'anno con codice {causalebilancioentrata} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idfinmotive"] = idfinmotive;
                        dictFinmotive.Add(causalebilancioentrata, idfinmotive.ToString());
                    }
                    else {
                        stip_decodifica["idfinmotive"] = dictFinmotive[causalebilancioentrata];
                    }
                }

                // idaccmotiverevenue
                stip_decodifica["idaccmotiverevenue"] = DBNull.Value;
                string causalericavo = Reader.getCurrField("causalericavo").ToString();

                if (causalericavo != "") {
                    if (!dictAccmotive.ContainsKey(causalericavo)) {
                        object idaccmotiverevenue = Conn.readValue("accmotive", q.eq("codemotive", causalericavo), "idaccmotive");

                        if (idaccmotiverevenue == DBNull.Value || idaccmotiverevenue == null) {
                            SpeedSaver.AddError($"La Causale di ricavo con codice {causalericavo} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idaccmotiverevenue"] = idaccmotiverevenue;
                        dictAccmotive.Add(causalericavo, idaccmotiverevenue.ToString());
                    }
                    else {
                        stip_decodifica["idaccmotiverevenue"] = dictAccmotive[causalericavo];
                    }
                }

                // idaccmotivecredit
                stip_decodifica["idaccmotivecredit"] = DBNull.Value;
                string causalecredito = Reader.getCurrField("causalecredito").ToString();

                if (causalecredito != "") {
                    if (!dictAccmotive.ContainsKey(causalecredito)) {
                        object idaccmotivecredit = Conn.readValue("accmotive", q.eq("codemotive", causalecredito), "idaccmotive");

                        if (idaccmotivecredit == DBNull.Value || idaccmotivecredit == null) {
                            SpeedSaver.AddError($"La Causale di credito con codice {causalecredito} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idaccmotivecredit"] = idaccmotivecredit;
                        dictAccmotive.Add(causalecredito, idaccmotivecredit.ToString());
                    }
                    else {
                        stip_decodifica["idaccmotivecredit"] = dictAccmotive[causalecredito];
                    }
                }

                // idaccmotiveundotax
                stip_decodifica["idaccmotiveundotax"] = DBNull.Value;
                string causaleannulloentroanno = Reader.getCurrField("causaleannulloentroanno").ToString();

                if (causaleannulloentroanno != "") {
                    if (!dictAccmotive.ContainsKey(causaleannulloentroanno)) {
                        object idaccmotiveundotax = Conn.readValue("accmotive", q.eq("codemotive", causaleannulloentroanno), "idaccmotive");

                        if (idaccmotiveundotax == DBNull.Value || idaccmotiveundotax == null) {
                            SpeedSaver.AddError($"La Causale di annullo entro l'anno con codice {causaleannulloentroanno} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idaccmotiveundotax"] = idaccmotiveundotax;
                        dictAccmotive.Add(causaleannulloentroanno, idaccmotiveundotax.ToString());
                    }
                    else {
                        stip_decodifica["idaccmotiveundotax"] = dictAccmotive[causaleannulloentroanno];
                    }
                }

                // idaccmotiveundotaxpost
                stip_decodifica["idaccmotiveundotaxpost"] = DBNull.Value;
                string causaleannullooltreanno = Reader.getCurrField("causaleannullooltreanno").ToString();

                if (causaleannullooltreanno != "") {
                    if (!dictAccmotive.ContainsKey(causaleannullooltreanno)) {
                        object idaccmotiveundotaxpost = Conn.readValue("accmotive", q.eq("codemotive", causaleannullooltreanno), "idaccmotive");

                        if (idaccmotiveundotaxpost == DBNull.Value || idaccmotiveundotaxpost == null) {
                            SpeedSaver.AddError($"La Causale di annullo oltre l'anno con codice {causaleannullooltreanno} non è stata trovata, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idaccmotiveundotaxpost"] = idaccmotiveundotaxpost;
                        dictAccmotive.Add(causaleannullooltreanno, idaccmotiveundotaxpost.ToString());
                    }
                    else {
                        stip_decodifica["idaccmotiveundotaxpost"] = dictAccmotive[causaleannullooltreanno];
                    }
                }

                // idestimkind
                stip_decodifica["idestimkind"] = DBNull.Value;
                string tipocontratto = Reader.getCurrField("tipocontratto").ToString();

                if (tipocontratto != "") {
                    if (!dictEstimate.Contains(tipocontratto)) {
                        object idestimkind = Conn.readValue("estimatekind", q.eq("idestimkind", tipocontratto), "idestimkind");

                        if (idestimkind == DBNull.Value || idestimkind == null) {
                            SpeedSaver.AddError($"Il tipo contratto attivo con codice {tipocontratto} non è stato trovato, riga:{Reader.GetCurrRowNumber()}");
                            Reader.GetNext();

                            continue;
                        }

                        stip_decodifica["idestimkind"] = idestimkind;
                        dictEstimate.Add(idestimkind.ToString());
                    }
                    else {
                        stip_decodifica["idestimkind"] = tipocontratto;
                    }
                }

                Reader.GetNext();
            }

            Reader.Close();
            bool result = SaveData(dataset, true);
            dataset.Clear();

            return result;
        }

		private void btnContributiContrattiCSAnuovaversione_Click(object sender, EventArgs e) {
			ImportaContributiContrattoCSA_nuovagestione();
		}
	}



	class PostData_Migrazione : PostData {
        override public string GetOptimisticClause(DataRow R) {
            if (R.Table.PrimaryKey != null) {
                if ((R.Table.Columns["lu"] != null) &&
                    (R.Table.Columns["lt"] != null) &&
                    R.Table.PrimaryKey.Length > 0) {
                    int keylen = R.Table.PrimaryKey.Length;
                    DataColumn[] Cs = new DataColumn[keylen + 2];
                    for (int i = 0; i < keylen; i++) Cs[i] = R.Table.PrimaryKey[i];
                    Cs[keylen] = R.Table.Columns["lu"];
                    Cs[keylen + 1] = R.Table.Columns["lt"];
                    return QueryCreator.WHERE_REL_CLAUSE(R, Cs, Cs, DataRowVersion.Original, true);
                }
            }
            return base.GetOptimisticClause(R);
        }
    }

    public class SpeedSaveThread {
        DataAccess Conn;
        DataSet D;

        public SpeedSaveThread(DataAccess Conn, DataSet D) {
            this.Conn = Conn;
            this.D = D;
            SpeedSaver.IncThreads();
        }

        public void SaveData() {
            //if (SpeedSaver.GetErrorCondition()) {
            //    SpeedSaver.DecThreads();
            //    return;
            //}

            int save = metaprofiler.StartTimer("DO_POST()");
            try {
                PostData P = new PostData_Migrazione();
                P.InitClass(D, Conn);
                bool res = P.DO_POST();
                if (!res) {
                    SpeedSaver.AddError("Errore nel salvataggio dei dati:" + P.Conn.LastError);
                    SpeedSaver.SetErrorCondition();
                }
            }
            finally {
                SpeedSaver.DecThreads();
            }
            Application.DoEvents();
            GC.Collect();
            metaprofiler.StopTimer(save);
        }

    }

    public static class GetSortCached {
        static Dictionary<string, SortingHash> allsortkind = new Dictionary<string, SortingHash>();
        static Dictionary<int, string> allsortcode = new Dictionary<int, string>();

        public static void Init() {
            foreach (SortingHash sh in allsortkind.Values) {
                sh.Clear();
            }
            allsortkind.Clear();
            allsortcode.Clear();
            allsortkind = new Dictionary<string, SortingHash>();
            allsortcode = new Dictionary<int, string>();
        }

        public static object GetIdSortkind(DataAccess Conn, string codtipoclass, out bool error) {
            error = false;
            if (codtipoclass == null || codtipoclass.ToString().Trim() == "") return DBNull.Value;

            if (!allsortkind.ContainsKey(codtipoclass)) {
                QueryHelper QHS = Conn.GetQueryHelper();
                object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", codtipoclass), "idsorkind");
                if (idsorkind == null || idsorkind == DBNull.Value) {
                    error = true;
                    return DBNull.Value;
                }
                allsortkind[codtipoclass] = new SortingHash(Conn, CfgFn.GetNoNullInt32(idsorkind));
            }

            SortingHash H = allsortkind[codtipoclass];
            return H.tipoclass;
        }

        public static object GetSortK(DataAccess Conn, string codtipoclass, string codiceclas, out bool error) {
            error = false;
            if (codtipoclass == null || codtipoclass.ToString().Trim() == "") return DBNull.Value;
            if (codiceclas == null || codiceclas.ToString().Trim() == "") return DBNull.Value;

            if (!allsortkind.ContainsKey(codtipoclass)) {
                QueryHelper QHS = Conn.GetQueryHelper();
                object idsorkind = Conn.DO_READ_VALUE("sortingkind",
                    QHS.CmpEq("codesorkind", codtipoclass), "idsorkind");
                allsortkind[codtipoclass] = new SortingHash(Conn, CfgFn.GetNoNullInt32(idsorkind));
            }

            SortingHash H = allsortkind[codtipoclass];
            object res = H.GetidSor(codiceclas);
            if (res == DBNull.Value) error = true;
            return res;
        }

        public static object GetSortN(DataAccess Conn, int idsorkind, string codiceclas, out bool error) {
            error = false;
            if (idsorkind == 0) return DBNull.Value;
            if (codiceclas == null || codiceclas.ToString().Trim() == "") return DBNull.Value;

            if (!allsortcode.ContainsKey(idsorkind)) {
                QueryHelper QHS = Conn.GetQueryHelper();
                object codesorkind = Conn.DO_READ_VALUE("sortingkind",
                    QHS.CmpEq("idsorkind", idsorkind), "codesorkind");
                allsortcode[idsorkind] = codesorkind.ToString();
            }
            string codtipoclass = allsortcode[idsorkind];
            return GetSortK(Conn, codtipoclass, codiceclas, out error);
        }
    }


    public static class SpeedSaver {
        static bool global_res = false;
        static int nThreadsRunning = 0;
        private static List<string> warnings = new List<string>();
        private static List<string> errors = new List<string>();

        private static string ErrorContext = "";

        public static void SetErrorContext(string S) {
            lock (myLocker) {
                ErrorContext = S;
            }
        }

        public static void ClearErrorContext() {
            lock (myLocker) {
                ErrorContext = "";
            }
        }

        public static string GetErrorContext() {
            string S;
            lock (myLocker) {
                S = ErrorContext + "";
            }
            if (S == "") return "";
            return "(" + S + ")";
        }


        static DataAccess Conn;
        private static object myLocker = new object();
        static List<DataSet> ToSave = new List<DataSet>();
        static List<string> syncTables;

        public static void Init(DataAccess Conn, List<string> SyncTables) {
            SpeedSaver.Conn = Conn;
            if (SyncTables == null) SyncTables = new List<string>();
            SpeedSaver.syncTables = SyncTables;
            Reset();
        }

        public static bool isInitialized() {
            return (Conn != null);
        }

        public static void SetErrorCondition() {
            lock (myLocker) {
                global_res = true;
            }
        }

        public static bool GetErrorCondition() {
            bool res = false;
            lock (myLocker) {
                res = global_res;
            }
            return res;
        }


        public static void IncThreads() {
            lock (myLocker) {
                nThreadsRunning++;
            }
        }

        public static void DecThreads() {
            lock (myLocker) {
                nThreadsRunning--;
            }
        }

        public static int GetRunningThreads() {
            int N;
            lock (myLocker) {
                N = nThreadsRunning;
            }
            return N;

        }

        public static void Save(DataAccess Conn, DataSet D) {
            SpeedSaveThread SS = new SpeedSaveThread(Conn, D);
            SS.SaveData();
        }


        public static void Save(DataSet D) {

            bool to_sync = false;
            foreach (string t in syncTables) {
                DataTable Chg = D.Tables[t].GetChanges();
                if (Chg == null) continue;
                if (Chg.Rows.Count > 0) {
                    to_sync = true;
                    break;
                }
            }
            if (to_sync) {
                SpeedSaveThread SS = new SpeedSaveThread(Conn, D);
                SS.SaveData();
                return;
            }

            DataSet DD = D.Copy();
            DD.EnforceConstraints = false;
            foreach (DataTable T in D.Tables) {
                RowChange.CopyAutoIncrementProperties(T, DD.Tables[T.TableName]);
            }
            SpeedSaveThread SST = new SpeedSaveThread(Conn.Duplicate(), DD);
            new Thread(new ThreadStart(SST.SaveData)).Start();
        }

        public static void AddWarning(string warn) {
            lock (warnings) {
                warnings.Add(GetErrorContext() + warn);
            }
        }

        private static List<string> CloneList(List<string> L) {
            List<string> L2 = new List<string>();
            foreach (string s in L) L2.Add(s);
            return L2;

        }

        public static void AddError(string error) {
            lock (errors) {
                errors.Add(GetErrorContext() + error);
                SetErrorCondition();
            }
        }

        public static List<string> GetWarnings() {
            lock (warnings) {
                return CloneList(warnings);
            }
        }

        public static int countMessages() {
            return warnings.Count + errors.Count;
        }

        public static List<string> GetErrors() {
            lock (errors) {
                return CloneList(errors);
            }
        }


        public static void Reset() {
            warnings = new List<string>();
            errors = new List<string>();
            lock (myLocker) {
                global_res = false;
            }

        }
    }

    public static class ToCC {
        public static object getDate(object o) {
            if (o == null) return null;
            if (o == DBNull.Value) return null;
            if (o.GetType().IsAssignableFrom(typeof(DateTime))) return o;

            DateTime d;
            bool res = DateTime.TryParse(o.ToString(), out d);
            if (res) return d;
            return o;
        }

    }
}
