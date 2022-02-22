
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using q = metadatalibrary.MetaExpression;
using funzioni_configurazione;
using meta_flussocreditidetail;
using meta_flussocrediti;

namespace flussocreditidetail_default {
	public partial class FrmAnnullaDettaglio : MetaDataForm {

		IMetaDataDispatcher Disp;
		dsmeta DSClone;
		DataAccess Conn;
		MetaData Meta;
		private QueryHelper QHS;
		private CQueryHelper QHC;
		public DataTable Info;
		private object codiceBollettinoUnivoco;
 
 
		private ISecurity _security;

		public FrmAnnullaDettaglio(object codiceBollettinoUnivoco, dsmeta DS, MetaData Meta, IMetaDataDispatcher Disp, ISecurity _security)
		{
			InitializeComponent();
			this.Disp = Disp;
			this.Conn = Meta.Conn;
			this.DSClone = DS ;
			this.Meta=Meta;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			this._security = _security;
			this.codiceBollettinoUnivoco = codiceBollettinoUnivoco;
			txtCodiceBollettino.Text = codiceBollettinoUnivoco.ToString();
		}

		private void btnElaboraAnnullamento_Click(object sender, System.EventArgs e)
		{
			
			QueryCreator.MarkEvent("Inizio btnElaboraAnnullamento_Click");
			btnElaboraAnnullamento.Visible = false;


			var metaFlussoCrediti = Disp.Get("flussocrediti");
			metaFlussoCrediti.SetDefaults(DSClone.Tables["flussocrediti"]);

			var metaFlussoCreditiDetail = Disp.Get("flussocreditidetail");
			metaFlussoCreditiDetail.SetDefaults(DSClone.Tables["flussocreditidetail"]);

			Application.DoEvents();

          
			object startFlusso = DBNull.Value;
			object stopFlusso = DBNull.Value;
			object oCodiceBollettinoUnivoco = DBNull.Value;
			object oNewCodiceBollettinoUnivoco = DBNull.Value;
			object oDataContabile = _security.GetSys("datacontabile");
 
			q filterCreditidetail= q.constant(true);
 

			if (txtCodiceBollettino.Text != "")
			{
				object i = HelpForm.GetObjectFromString(typeof(string), txtCodiceBollettino.Text, "x.y.g");
				if (i == null)
				{
					show("Codice Bollettino Univoco non valido ", "Errore");
					btnElaboraAnnullamento.Visible = true;
					return;
				}
				oCodiceBollettinoUnivoco = i;
			}



			if ((oCodiceBollettinoUnivoco==DBNull.Value)&&(startFlusso==DBNull.Value))
					{
					show("E' necessario inserire almeno il codice bollettino ", "Errore");
					btnElaboraAnnullamento.Visible = true;
					return;
				}


			#region annullamento credito 
			string errore = "";

			var existentRowsToAnnull = DSClone.flussocreditidetail.safeMergeFromDb(Conn,
				q.eq("iduniqueformcode", oCodiceBollettinoUnivoco)  &  q.isNull("stop") &
				q.isNull("annulment") & filterCreditidetail);

			if (existentRowsToAnnull.Length == 0)
			{
				errore =
					$"Bollettino numero {oCodiceBollettinoUnivoco} non trovato (o già annullato) nei crediti esistenti. L'annullo di tale bollettino non sarà considerato.";
				show(errore, "Avviso");
				return;
			}


			DataRow[] rFlussoCreditiRows = DSClone.flussocrediti.get(Conn,
				q.eq("idflusso", existentRowsToAnnull[0]["idflusso"]));
			
			if (rFlussoCreditiRows.Length == 0)
			{
				errore =
					$"Flusso numero {existentRowsToAnnull[0]["idflusso"]} non trovato. L'annullo di tale bollettino non sarà considerato.";
				show(errore, "Avviso");
				return;
			}
				DataRow rFlussoCrediti = rFlussoCreditiRows[0];
				
			var rNewFlussoCrediti = metaFlussoCrediti.Get_New_Row(null, DSClone.Tables["flussocrediti"]);

			//copia alcuni campi dalla riga originale da annullare
			foreach (var field in new[] {
					"idestimkind",
					"idsor01", "idsor02","idsor03", "idsor04", "idsor05"

			})
			{
				rNewFlussoCrediti[field] = rFlussoCrediti[field];
			}

			rNewFlussoCrediti["datacreazioneflusso"] = _security.GetSys("datacontabile");
			rNewFlussoCrediti["flusso"] = DBNull.Value;
			rNewFlussoCrediti["istransmitted"] = "S"; //il flusso che creiamo si intenda già trasmesso da un programma esterno
			rNewFlussoCrediti["filename"] = DBNull.Value; ;
			rNewFlussoCrediti["docdate"] = oDataContabile;
			rNewFlussoCrediti["ct"] = DateTime.Now;
			rNewFlussoCrediti["cu"] = "importaFlussoCrediti_" + Conn.externalUser;
			rNewFlussoCrediti["lt"] = DateTime.Now;
			rNewFlussoCrediti["lu"] = "importaFlussoCrediti_" + Conn.externalUser;

			//Crea una riga di annullamento per ogni riga esistente da annullare e ne imposta il campo annullato
			foreach (var rToAnnull in existentRowsToAnnull)
			{
				
				//nuova riga di annullo che creiamo, deve avere la data fine validità stop
				//la vecchia riga deve avere la data di annullo 

				rToAnnull.annulmentValue = oDataContabile; //Imposta il campo ANNULLATO nel dettaglio credito esistent 
				
				var rNewFlussocreditiDetail =
					metaFlussoCreditiDetail.Get_New_Row(rNewFlussoCrediti, DSClone.Tables["flussocreditidetail"]) as
						flussocreditidetailRow;

				//copia alcuni campi dalla riga originale da annullare
				foreach (var field in new[] {
					"importoversamento", "idestimkind", "yestim", "nestim", "rownum", "idinvkind", "yinv",
					"ninv", "invrownum","tax","number","idlist","annotations",
					"idsor1","idsor2","idsor3","iuv",
					"nform",
					"expirationdate",
					"barcodevalue",
					"barcodeimage",
					"qrcodevalue",
					"qrcodeimage",
					"idfinmotive",//idCodiceCausaleFinanziaria;
					"iduniqueformcode",//oCodiceBollettinoUnivoco;
					"idaccmotiverevenue",//idcausaleEpRicavo;
					"idaccmotivecredit",//idcausaleEpCredito;

					"idaccmotiveundotax",//idcausaleEpRicavo;
					"idaccmotiveundotaxpost",//idcausaleEpRicavo;
					"stop",//oDataContabile;

					"competencystart",//competencystart;
					"competencystop",//competencystop;
					"description",//description;
					"cf",//oCodiceFiscaleStudente.ToString().ToUpper();
					"p_iva", 
					"idreg",//oIdreg;
					"idupb",//idupb;
					"idupb_iva"
				})
				{
					rNewFlussocreditiDetail[field] = rToAnnull[field];
				}

				//if (oNewCodiceBollettinoUnivoco != DBNull.Value)
				//{
				//	rNewFlussocreditiDetail["iduniqueformcode"] = oNewCodiceBollettinoUnivoco;
				//}
				// ReSharper disable once PossibleNullReferenceException

				rNewFlussocreditiDetail.stopValue = oDataContabile; //Imposta il campo DATA FINE VALIDITA' nel dettaglio credito nuovo
				rNewFlussocreditiDetail.flag = 0;
				rNewFlussocreditiDetail["ct"] = DateTime.Now;
				rNewFlussocreditiDetail["cu"] = "import_flussostudenti";
				rNewFlussocreditiDetail["lt"] = DateTime.Now;
				rNewFlussocreditiDetail["lu"] = "import_flussostudenti";

			}

			#endregion

			var myPostData = new Easy_PostData();
			myPostData.initClass(DSClone, Conn);
			var resSave = myPostData.DO_POST();

			if (!resSave)
			{
				show(this, "Errore nel salvataggio");
				btnElaboraAnnullamento.Visible = true;
				return;
			}
			else
			{
				show(this, "Elaborazione effettuata");
				//btnElaboraAnnullamento.Visible = true;
			}

			DataSet ds = new DataSet();
			ds.Merge(DSClone.flussocreditidetail);
			DataTable t = ds.Tables[0];
			t.TableName = "flussocreditidetail";
			dgrCreditiAnnullati.DataBindings.Clear();
			dgrCreditiAnnullati.DataSource = null;
			dgrCreditiAnnullati.TableStyles.Clear();
			dgrCreditiAnnullati.Tag = "flussocreditidetail.default_annullati";
			
			Meta.DescribeColumns(t,"default_annullati");
			HelpForm.SetDataGrid(dgrCreditiAnnullati,t);

			formatgrids fg = new formatgrids(dgrCreditiAnnullati);
			fg.AutosizeColumnWidth();
 
		}

		private void datagrid_DoubleClick(object sender, EventArgs e) {
			// permette la selezione di una riga per visualizzarla richiamando edit type specifico per ciascun grid
			//
			//dgrCreditiAnnullati
			DataGrid dataGrid = (DataGrid) sender;
			DataRow RigaSelezionata = getGridCurrentRow(dataGrid);
			string tableName = "";
			string viewName = "";
			string listType = "";
			string editType = "";
		 
	 
			tableName = "flussocreditidetail";
			listType = "default_annullati";
			editType = "default";
		 

			if (RigaSelezionata == null)
				return;
			visualizzaRigaSelezionata(RigaSelezionata, tableName, viewName, listType, editType);
		}


		private void visualizzaRigaSelezionata(DataRow Riga, string table, string view, string listType,
			string editType) {
			if (Riga == null) return;
			string filter = QueryCreator.WHERE_KEY_CLAUSE(Riga, DataRowVersion.Default, true);
			if (editType == null) editType = "default";
			var MElenco = Disp.Get(table);
			if (MElenco == null) return;

			bool result = MElenco.Edit(this, editType, false);
			//DataRow R = MElenco.SelectOne(listType, filter, null, null);
			MElenco.SelectRow(Riga, listType);
		}

		private static DataRow getGridCurrentRow(DataGrid g) {
			var dsv = (DataSet) g.DataSource;
			var tv = dsv?.Tables[g.DataMember];
			if (tv == null) return null;

			if (tv.Rows.Count == 0) return null;
			DataRowView dv;
			try {
				dv = (DataRowView) g.BindingContext[dsv, tv.TableName].Current;
			}
			catch {
				dv = null;
			}

			return dv?.Row;
		}



		//void impostaCaption(DataTable dt) {
	 
		//			dt.Columns["codice_fiscale_studente"].Caption = "Cod. Fiscale Studente";
		//			dt.Columns["causale"].Caption = "Causale";
		//			dt.Columns["codice_bollettino_univoco"].Caption = "Cod. Bollettino Univoco";
		//			dt.Columns["operazione"].Caption = "Operazione";
		//			dt.Columns["data_inizio_competenza"].Caption = "Data Inizio Competenza";
		//			dt.Columns["data_fine_competenza"].Caption = "Data Fine Competenza";
		//			dt.Columns["codice_causale_ep_ricavo"].Caption = "Causale EP Ricavo o di Annullamento";
		//			dt.Columns["codice_causale_ep_credito"].Caption = "Causale EP Credito";
		//			dt.Columns["codice_causale_finanziaria"].Caption = "Causale finanziaria";
		//			dt.Columns["codice_upb"].Caption = "Codice UPB";
		//			dt.Columns["importo"].Caption = "Importo";
		//			dt.Columns["iva"].Caption = "Iva";
		//			dt.Columns["codice_tipo_contratto"].Caption = "Codice Tipo Contratto";
		//			dt.Columns["data_contabile"].Caption = "Data Contabile";
		//			dt.Columns["nome_studente"].Caption = "Nome studente";
		//			dt.Columns["cognome_studente"].Caption = "Cognome studente";
				 
		//		}

		 
	}
}
