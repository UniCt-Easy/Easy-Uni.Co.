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
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace EasyInstall
{
	/// <summary>
	/// Summary description for Iva.
	/// </summary>
	public class Iva
	{
		/// <summary>
		/// Crea la tabella di mezzo tra invoicekind e ivaregisterkind
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool creaInvoicekindRegisterkind(Form form, DataAccess sourceConn, DataAccess destConn) {
			string query = "select distinct idinvkind=codicetipodoc, idivaregisterkind=codicetiporeg "
				+ "from tipodocoperiva "
				+ "join tipooperregiva on tipodocoperiva.codicetipoop=tipooperregiva.codicetipoop";
			DataTable t = Migrazione.eseguiQuery(sourceConn, query, form);
			if (t==null) return false;
			t.Columns.Add("ct", typeof(DateTime));
			t.Columns.Add("lt", typeof(DateTime));
			t.Columns.Add("cu", typeof(string), "'SA'");
			t.Columns.Add("lu", typeof(string), "'SA'");
			foreach (DataRow r in t.Rows) {
				r["ct"] = DateTime.Now;
				r["lt"] = DateTime.Now;
			}
			t.TableName = "invoicekindregisterkind";
			return Migrazione.lanciaScript(form,destConn, t, "tipodocoperiva, tipooperregiva -> invoicekindregisterkind");
		}

		private static bool migraTipoDocumentoIva(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
            string query = "select idinvkind = codicetipodoc, description = descrizione, "
                                + "ct = createtimestamp, cu = createuser, "
                            + "flagvariation = flagnotavariazione, "
                            + "flagbuysell = flagvenditaacquisto, "
                            + "lt = lastmodtimestamp, lu = lastmoduser "
                            + "from tipodocumentoiva";
            DataTable tInvoiceKind = Migrazione.eseguiQuery(sourceConn, query, form);

			if (tInvoiceKind == null) return false;
			tInvoiceKind.TableName = "invoicekind";
			tInvoiceKind.Columns.Add("flagmixed", typeof(string));
			tInvoiceKind.Columns.Add("active", typeof(string));
			query = "select distinct codicetipodoc, flagpromiscuo "
				+ "from tipodocoperiva "
				+ "join tipooperregiva on tipodocoperiva.codicetipoop=tipooperregiva.codicetipoop "
				+ "join tiporegistroiva on tipooperregiva.codicetiporeg=tiporegistroiva.codicetiporeg "
				+ "where classregistro <> 'P' ";
			DataTable t = Migrazione.eseguiQuery(sourceConn, query, form);
			if (t==null) return false;
			foreach (DataRow rIK in tInvoiceKind.Rows) {
				string q = "codicetipodoc="+QueryCreator.quotedstrvalue(rIK["idinvkind"], false);
				DataRow[] r = t.Select(q);
				if (r.Length > 0) {
					rIK["flagmixed"] = r[0]["flagpromiscuo"];
				}
				rIK["active"] = "S";
			}
			return Migrazione.lanciaScript(form, destConn, tInvoiceKind, "tipodocumentoiva -> invoicekind");
		}

		public static bool migraIvaProRata(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
			DataTable t = Migrazione.leggiETraduciTabella("iva_prorata", sourceConn, tColName, form, null, "ayear=datepart(year, datainizio)");
			if (t==null) return false;
			t.TableName = "iva_prorata";
			return Migrazione.lanciaScript(form, destConn, t, "iva_prorata -> iva_prorata");

		}

		public static bool migraIvaPromiscuo(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
			DataTable t = Migrazione.leggiETraduciTabella("iva_promiscuo", sourceConn, tColName, form, null, "ayear=datepart(year, datainizio)");
			if (t==null) return false;
			t.TableName = "iva_mixed";
			return Migrazione.lanciaScript(form,destConn, t, "iva_promiscuo -> iva_mixed");

		}

		public static bool migraInvoiceDeferred(Form form, DataAccess sourceConn, DataAccess destConn) {
			DataSet ds = destConn.CallSP("compute_invoicedeferred", new object[]{},false,0);
			if (ds == null) return false;
			return true;
		}

		public static bool migraSpeciali(Form form, DataAccess sourceConn, DataAccess destConn, 
			DataTable tColName) 
		{
			//registroiva, documentoiva -> invoicekindregisterkind
			if (!creaInvoicekindRegisterkind(form, sourceConn, destConn)) return false;
		
			//tipodocumentoiva -> invoicekind
			if (!migraTipoDocumentoIva(form, sourceConn, destConn, tColName)) return false;

			//iva_prorata -> iva_prorata
			if (!migraIvaProRata(form, sourceConn, destConn, tColName)) return false;

			//iva_promiscuo -> iva_mixed
			if (!migraIvaPromiscuo(form, sourceConn, destConn, tColName)) return false;

			//liquidazioneiva -> invoicedeferred
			return migraInvoiceDeferred(form, sourceConn, destConn);
		}

		/// <summary>
		/// Metodo da chiamare se il checkBox dell'IVA è checked.
		/// Migra tutte le tabelle dell'IVA, di configurazione e non.
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tTableName"></param>
		/// <param name="tColName"></param>
		public static bool migraIva(Form form, DataAccess sourceConn, DataAccess destConn, 
			DataTable tTableName, DataTable tColName) 
		{

			if (!migraSpeciali(form, sourceConn, destConn, tColName)) return false;

			
			string filtro = "tipocopia='copia' and copiato='N' and chk like '%Iva%'";

			DataRow[] rTableName = tTableName.Select(filtro);

			foreach (DataRow rTable in rTableName) {
				DataSet ds = new DataSet();
				DataTable t = Migrazione.leggiETraduciTabella(rTable["oldtable"].ToString(), sourceConn, tColName, form);
				if (t==null) return false;
				t.TableName = rTable["newtable"].ToString();
				ds.Tables.Add(t);
				rTable["copiato"] = "S";
				string nomeCopia = "Copia normali tabelle Iva";
				bool res= Migrazione.lanciaScript(form, destConn, t, nomeCopia);
				if (!res) return false;
			}
			return true;
		}

		public static void RifinisciDettagliFattura(Form form, DataAccess destConn){
			//Se non ci sono fatture esci
			int NFatture = destConn.RUN_SELECT_COUNT("invoice",null,false);
			if (NFatture==0) return;

			//Se non ci sono liquidazioni esci
			int NLiquid = destConn.RUN_SELECT_COUNT("ivapay",null,false);
			if (NLiquid==0) return;

			//Chiede
			if (MessageBox.Show(form,"Si desidera rifinire i dettagli fattura dell'ultimo esercizio per farli quadrare approssimativamente "+
				"con le liquidazioni  iva precedenti?","Conferma",MessageBoxButtons.YesNo)==DialogResult.No)return;

			object  esercmax= destConn.DO_READ_VALUE("accountingyear","flagexpensearrearscopy = 'S'","max(ayear)");
			if (esercmax==null) return;
			if (esercmax==DBNull.Value) return;
			esercmax = CfgFn.GetNoNullInt32(esercmax)+1;
			foreach(string spname in new string[]{
						"split_invoicedetail_expense",
						"split_invoicedetail_expense_nliqu",
						"split_invoicedetail_expensevar",
						"split_invoicedetail_expensevar_nliqu",
						"split_invoicedetail_income",
						"split_invoicedetail_income_nliqu",
						"split_invoicedetail_incomevar",
						"split_invoicedetail_incomevar_nliqu"
			}){
				MessageBox.Show("Eseguo "+spname);
				destConn.CallSP(spname,new object[1]{esercmax},false,0);
			}
			MessageBox.Show("Rifinitura effettuata.");
		}
	}
}
