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
using metadatalibrary;
using System.Windows.Forms;
using System.Data;
using System.IO;
using generaSQL;
using LiveUpdate;
using System.Collections;
using funzioni_configurazione;
using System.Text;

namespace Install
{
	/// <summary>
	/// Summary description for Upb.
	/// </summary>
	public class Upb
	{
		/// <summary>
		/// Parte 1.2. Inserimento dei FdR negli UPB
		/// Strategia: Se il fondo di ricerca ha un'unica suddivisione, verrà inserito un UPB di 2° livello
		/// Se il fondo ha più suddivisioni, verrà inserito un UPB di 2° livello che rappresenta il fondo
		/// e tanti UPB di 3° livello per quante sono le suddivisioni
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		private static DataTable inserisciFondiNegliUpb(Form form, DataAccess sourceConn, DataTable tUpb, out bool fondiMigrati) {
			fondiMigrati = false;
			DataTable tFdrUpb = new DataTable();
			tFdrUpb.Columns.Add("idres", typeof(string));
			tFdrUpb.Columns.Add("idpar", typeof(string));
			tFdrUpb.Columns.Add("idupb", typeof(string));
			DataTable t1 = sourceConn.RUN_SELECT("persbilancio", "codfaseimpegno, codfaseaccertamento", "esercizio desc", null, "1", true);
			object appropriationPhaseCode = t1.Rows[0]["codfaseimpegno"];
			object assessmentPhaseCode = t1.Rows[0]["codfaseaccertamento"];
			string q2 = "SELECT idres=fondoricerca.codicefondo, idpar=ripfondiricerca.codiceripartizione, "
				+ "title_res=fondoricerca.denominazione, title_par=ripfondiricerca.denominazione, "
				+ "idunderwriter=fondoricerca.codiceentefin, active=fondoricerca.flagutilizzabile, "
				+ "idman_res=fondoricerca.codiceresponsabile, idman_par=ripfondiricerca.codiceresponsabile, "
				+ "requested_res=fondoricerca.finrichiesto, requested_par=ripfondiricerca.finrichiesto, "
				+ "granted_res=fondoricerca.finaccordato, granted_par=ripfondiricerca.finaccordato, "
				+ "expiration_res=fondoricerca.scadenza "
				+ "FROM fondoricerca "
				+ "JOIN ripfondiricerca "
				+ "ON fondoricerca.codicefondo = ripfondiricerca.codicefondo "
				+ "ORDER BY fondoricerca.codicefondo, ripfondiricerca.codiceripartizione ";
			DataTable t2 = Migrazione.eseguiQuery(sourceConn, q2, form);
			if (t2 == null) return null;

			DialogResult dr = MessageBox.Show(form, "Vuoi migrare i fondi di ricerca negli UPB?", "", MessageBoxButtons.YesNo);
			fondiMigrati = dr == DialogResult.Yes;
			if (dr != DialogResult.Yes) {
				string idUpbLibero = "0001";
				foreach(DataRow r in t2.Rows) {
					int conta = CfgFn.GetNoNullInt32(tUpb.Compute("count(codeupb)",
					"codeupb="+QueryCreator.quotedstrvalue(r["idres"], false)));
					if (conta == 0)	tFdrUpb.Rows.Add(new object[] {r["idres"], DBNull.Value, idUpbLibero});
					tFdrUpb.Rows.Add(new object[] {r["idres"], r["idpar"], idUpbLibero});
				}
				return tFdrUpb;
			}

			string msgAss = "Si vuole calcolare gli accertamenti degli anni precedenti considerando" +
				" come accertato la somma delle previsioni di spesa delle suddivisioni?";
			DialogResult drAss = MessageBox.Show(form, msgAss, "", MessageBoxButtons.YesNo);

			foreach (DataRow r in t2.Rows) {
				int conta = CfgFn.GetNoNullInt32(tUpb.Compute("count(codeupb)",
					"codeupb="+QueryCreator.quotedstrvalue(r["idres"], false)));
				string idUpbRes = "";
				DataRow rUpb1;
				if (conta == 0) {
					// Conto il numero di UPB presenti sullo stesso livello di quello che sto per inserire
					// in modo da calcolare l'ID come il numero dei fratelli + 1
					int fratelloCorrente = 1 + CfgFn.GetNoNullInt32(tUpb.Compute("count(paridupb)", "paridupb='0001'"));
					idUpbRes = "0001" + fratelloCorrente.ToString().PadLeft(4, '0');
					rUpb1 = tUpb.NewRow();
					rUpb1["idupb"] = idUpbRes;
					rUpb1["codeupb"] = r["idres"];
					rUpb1["title"] = r["title_res"];
					rUpb1["cu"] = "SA";
					rUpb1["ct"] = DateTime.Now;
					rUpb1["lu"] = "'SA'";
					rUpb1["lt"] = DateTime.Now;
					rUpb1["printingorder"] = r["idres"];
					rUpb1["paridupb"] = "0001";
					rUpb1["idunderwriter"] = r["idunderwriter"];
					rUpb1["idman"] = r["idman_res"];
					rUpb1["requested"] = r["requested_res"];
					rUpb1["granted"] = r["granted_res"];
					rUpb1["expiration"] = r["expiration_res"];
					rUpb1["assured"] = "S";
					rUpb1["active"] = r["active"];
					tUpb.Rows.Add(rUpb1);
				}
				else {
					rUpb1 = tUpb.Select("(codeupb = "+ QueryCreator.quotedstrvalue(r["idres"],false) + ")")[0];
					idUpbRes = rUpb1["idupb"].ToString();
				}

				string q3 = "(codicefondo=" + QueryCreator.quotedstrvalue(r["idres"], true)
					+ ") and (codiceripartizione=" + QueryCreator.quotedstrvalue(r["idpar"], true)
					+ ") and (codicefase=" + QueryCreator.quotedstrvalue(appropriationPhaseCode, true) 
					+ ")";

				object previousAppropriation = sourceConn.DO_READ_VALUE("totfondospesaprec", q3, "importo");

				string q4 = "(codicefondo=" + QueryCreator.quotedstrvalue(r["idres"], true)
					+ ") and (codiceripartizione=" + QueryCreator.quotedstrvalue(r["idpar"], true)
					+ ") and (codicefase=" + QueryCreator.quotedstrvalue(assessmentPhaseCode, true) 
					+ ")";

				decimal prevAss = 0;
				if (drAss == DialogResult.Yes) {
					string qAss = "SELECT " +
						"ISNULL(" +
						" (SELECT SUM(previsionespese) " +
						" FROM previsioneripfondi " +
						" WHERE codicefondo = " + QueryCreator.quotedstrvalue(r["idres"], true) +
						" AND codiceripartizione = " + QueryCreator.quotedstrvalue(r["idpar"], true) +
						"),0) + " +
						"ISNULL(" +
						" (SELECT SUM(totfondo.totvarspese) " +
						" FROM totfondo " +
						" WHERE codicefondo = " + QueryCreator.quotedstrvalue(r["idres"], true) +
						" AND codiceripartizione = " + QueryCreator.quotedstrvalue(r["idpar"], true) +
						"),0) - " +
						"ISNULL(" +
						" (SELECT SUM(totale) " +
						" FROM totfondoentrata " +
						" WHERE codicefondo = " + QueryCreator.quotedstrvalue(r["idres"], true) +
						" AND codiceripartizione = " + QueryCreator.quotedstrvalue(r["idpar"], true) +
						" AND codicefase = " + QueryCreator.quotedstrvalue(assessmentPhaseCode, true) + "),0)";

					DataTable tAss = DataAccess.SQLRunner(sourceConn, qAss);

					if (tAss == null) return null;
					if (tAss.Rows.Count > 0) {
						prevAss = CfgFn.GetNoNullDecimal(tAss.Rows[0][0]);
					}
				}
				else {
					object previousAssessment = sourceConn.DO_READ_VALUE("totfondoentrataprec", q4, "importo");
					prevAss = CfgFn.GetNoNullDecimal(previousAssessment);
				}

				int contaSuddivisioni = sourceConn.RUN_SELECT_COUNT("ripfondiricerca", 
					"codicefondo="+QueryCreator.quotedstrvalue(r["idres"], true), true);
				if (contaSuddivisioni > 1) {
					// Individuo il padre dell'UPB che sto per inserire e successivamente mi conto quanti figli ha il padre
					// per assegnare l'ID al nuovo UPB
					object padreSuddivisione = idUpbRes;
//						tUpb.Compute("MIN(idupb)", "codeupb="+
//						QueryCreator.quotedstrvalue(r["idres"],false)+"");
					int figlioCorrente = 1 + CfgFn.GetNoNullInt32(tUpb.Compute("count(paridupb)", 
						"paridupb="+QueryCreator.quotedstrvalue(padreSuddivisione,false)+""));
					string idUpbPar = padreSuddivisione + figlioCorrente.ToString().PadLeft(4, '0');
					DataRow rUpb2 = tUpb.NewRow();
					rUpb2["idupb"] = idUpbPar;
					rUpb2["codeupb"] = r["idres"]+"/"+r["idpar"];
					rUpb2["title"] = r["title_par"];
					rUpb2["paridupb"] = padreSuddivisione;
					rUpb2["idman"] = r["idman_par"];
					rUpb2["requested"] = r["requested_par"];
					rUpb2["granted"] = r["granted_par"];
					rUpb2["previousappropriation"] = previousAppropriation;
					rUpb2["previousassessment"] = prevAss;
					rUpb2["expiration"] = r["expiration_res"];
					rUpb2["cu"] = "SA";
					rUpb2["ct"] = DateTime.Now;
					rUpb2["lu"] = "'SA'";
					rUpb2["lt"] = DateTime.Now;
					rUpb2["assured"] = "S";
                    rUpb2["printingorder"] = r["idres"] + "/" + r["idpar"];
					rUpb2["active"] = r["active"];
					tUpb.Rows.Add(rUpb2);

					// Viene aggiunta una riga nella tabella temporanea con il solo codice del FdR se ci sono più
					// suddivisioni legate ad esso
					string filtroFondo = "(idres = " + QueryCreator.quotedstrvalue(r["idres"],false)
						+ ") AND (idpar is null)";
					int contaFdr = CfgFn.GetNoNullInt32(tFdrUpb.Compute("count(idres)", filtroFondo));
					if (contaFdr == 0) {
						tFdrUpb.Rows.Add(new object[] {r["idres"], DBNull.Value, idUpbRes});
					}
					tFdrUpb.Rows.Add(new object[] {r["idres"], r["idpar"], idUpbPar});
				}
                else
                {
                    rUpb1["previousappropriation"] = previousAppropriation;
                    rUpb1["previousassessment"] = prevAss;
                    tFdrUpb.Rows.Add(new object[] { r["idres"], r["idpar"], idUpbRes });
                }
			}
			return tFdrUpb;
		}

		/// <summary>
		/// Parte 1.3. Inserimento dei CdS negli UPB
		/// Strategia: Vengono creati UPB di 2° livello e successivi in base alla struttura del CdS
		/// </summary>
		/// <param name="sourceConn"></param>
		private static DataTable inserisciCdsNegliUpb(Form form, DataAccess sourceConn, DataTable tUpb, out bool centriMigrati) {
			centriMigrati = false;
			DataTable tCdsUpb = new DataTable();
			tCdsUpb.Columns.Add("idcen", typeof(string));
			tCdsUpb.Columns.Add("idupb", typeof(string));
			string q1 = "SELECT DISTINCT idcen=SUBSTRING(idcentrospesa,3,LEN(idcentrospesa)), "
				+ "centercode=codicecentrospesa, "
				+ "paridcen=CASE "
				+ "WHEN LEN(livsupidcentrospesa) <= 2 THEN NULL "
				+ "ELSE SUBSTRING(livsupidcentrospesa,3,LEN(livsupidcentrospesa)) "
				+ "END, "
				+ "idman_cen = "
				+ "(SELECT TOP 1 codiceresponsabile FROM centrospesa cs "
				+ " WHERE SUBSTRING(cs.idcentrospesa,3,LEN(cs.idcentrospesa)) = "
				+ " SUBSTRING(centrospesa.idcentrospesa,3,LEN(centrospesa.idcentrospesa))),"
				+ " title_cen=denominazione, "
				+ "parcentercode=(SELECT TOP 1 c2.codicecentrospesa FROM centrospesa c2 "
				+ "WHERE SUBSTRING(c2.idcentrospesa,3,LEN(c2.idcentrospesa)) = SUBSTRING(centrospesa.livsupidcentrospesa,3,LEN(centrospesa.livsupidcentrospesa))) "
				+ "FROM centrospesa "
				+ "ORDER BY SUBSTRING(idcentrospesa,3,LEN(idcentrospesa))";

			DataTable t1 = Migrazione.eseguiQuery(sourceConn, q1, form);
			if (t1 == null) return null;

			DialogResult dr = MessageBox.Show(form, "Vuoi migrare i centri di spesa negli UPB?", "", MessageBoxButtons.YesNo);
			centriMigrati = (dr == DialogResult.Yes);
			if (dr != DialogResult.Yes) {
				string idUpbLibero = "0001";
				foreach(DataRow r in t1.Rows) {
					tCdsUpb.Rows.Add(new object[] {r["idcen"], idUpbLibero});
				}
				return tCdsUpb;
			}

			foreach (DataRow r in t1.Rows) {
				int conta = CfgFn.GetNoNullInt32(tUpb.Compute("count(codeupb)",
							"codeupb="+QueryCreator.quotedstrvalue(r["centercode"], false)));
				if (conta == 0) {
					string parIdUpb_cen = "0001";
					if (r["paridcen"] != DBNull.Value) {
						DataRow[] righe = tUpb.Select("codeupb="+QueryCreator.quotedstrvalue(r["parcentercode"], false));
						if (righe.Length>0){
							parIdUpb_cen = (string) righe[0]["idupb"];
						}
						else {
							MessageBox.Show("E' stato trovato il centro di spesa"+
								r["centercode"].ToString()+
									" con un rif. a padre inesistente");
						}
					}
					int upbCen_Corrente = 1 + CfgFn.GetNoNullInt32(tUpb.Compute("count(paridupb)",
						"paridupb=" + QueryCreator.quotedstrvalue(parIdUpb_cen, true)));
					string idUpbCorr = parIdUpb_cen + upbCen_Corrente.ToString().PadLeft(4, '0');
					
					DataRow rUpb = tUpb.NewRow();
					rUpb["idupb"] = idUpbCorr;
					rUpb["codeupb"] = r["centercode"];
					rUpb["title"] = r["title_cen"];
					rUpb["cu"] = "SA";
					rUpb["ct"] = DateTime.Now;
					rUpb["lu"] = "'SA'";
					rUpb["lt"] = DateTime.Now;
					rUpb["printingorder"] = r["centercode"];
					rUpb["paridupb"] = parIdUpb_cen;
					rUpb["idman"] = r["idman_cen"];
					rUpb["assured"] = "N";
					rUpb["active"] = "S";
					tUpb.Rows.Add(rUpb);
					tCdsUpb.Rows.Add(new object[] {r["idcen"], idUpbCorr});
				}
			}
			return tCdsUpb;
		}

		/// <summary>
		/// Sezione 1. Riempimento della tabella UPB
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tFdrUpb"></param>
		/// <param name="tCdsUpb"></param>
		/// <returns>TRUE: Non si sono verificati errori; FALSE: Si sono verificati errori</returns>
		public static bool creaTabellaUpb(Form form, DataAccess sourceConn, DataAccess destConn, 
			out DataTable tFdrUpb, out DataTable tCdsUpb) 
		{
			VistaUpb ds = new VistaUpb();

			// Parte 1.1. Inserimento del nodo root
			DataRow rUpb = ds.upb.NewRow();
			rUpb["idupb"] = "0001";
			rUpb["codeupb"] = "dipartimento";
            rUpb["title"] = "dipartimento";
			rUpb["cu"] = "SA";
			rUpb["ct"] = DateTime.Now;
			rUpb["lu"] = "'SA'";
			rUpb["lt"] = DateTime.Now;
            rUpb["printingorder"] = "dipartimento";
			ds.upb.Rows.Add(rUpb);
			rUpb["assured"] = "N";
			rUpb["active"] = "S";


			bool fondiMigrati, centriMigrati;
			tFdrUpb = inserisciFondiNegliUpb(form, sourceConn, ds.upb, out fondiMigrati);
			tCdsUpb = inserisciCdsNegliUpb(form, sourceConn, ds.upb, out centriMigrati);

			if (tFdrUpb == null) return false;
			if (tCdsUpb == null) return false;

			if (!fondiMigrati && !centriMigrati) {
				DialogResult dr = MessageBox.Show(form, "Vuoi migrare la tabella UPB?", "", MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes) {
					string query = "select idupb, codeupb, title, paridupb, idunderwriter, idman, requested, granted, "
						+ "previousappropriation, previousassessment, expiration, txt, rtf, "
						+ "cu=createuser, ct=createtimestamp, lu=lastmoduser, lt=lastmodtimestamp, "
						+ "assured, printingorder, active "
						+ "from upb";
					DataTable tUpb = Migrazione.eseguiQuery(sourceConn, query, form);
					if (tUpb==null) return false;
					tUpb.TableName = "upb";
					return Migrazione.lanciaScript(form, destConn, tUpb, "upb -> upb");
				}
			}

			int count = destConn.RUN_SELECT_COUNT("upb", "idupb='0001'", false);
			if (count > 0) {
				DataRow[] rUpbLibero = ds.upb.Select("idupb='0001'");
				foreach (DataRow r in rUpbLibero) {
					ds.upb.Rows.Remove(r);
				}
			}
			return Migrazione.lanciaScript(form, destConn, ds, "fondoricerca, ripfondiricerca, centrospesa -> upb");
		}


		/// <summary>
		/// Parte 2.3. Riempimento della Tabella UPBSORTING
		/// Passo 2.3.1. Travaso delle classificazioni dei fondi e delle suddivisioni
		/// </summary>
		public static bool migraDaFdrAdUpbSorting(Form form, DataAccess sourceConn, DataAccess destConn,
			DataTable tFdrUpb) 
		{
			foreach (DataRow rFdr in tFdrUpb.Select(null, "idres,idpar,idupb")) {
				string filtro = "codicefondo="+QueryCreator.quotedstrvalue(rFdr["idres"], true);
				int contaFigli1 = sourceConn.RUN_SELECT_COUNT("ripfondiricerca", filtro, true);
				int ctr = sourceConn.RUN_SELECT_COUNT("classtreeripartizioni", filtro, true);
				int ctf = sourceConn.RUN_SELECT_COUNT("classtreefondo", filtro, true);
				if ((ctr + ctf > 0)&&((ctr==0)||(ctf>0)||(contaFigli1==1)||(rFdr["idpar"]!=DBNull.Value))) {
					string whereFondo = "WHERE codicefondo = " + QueryCreator.quotedstrvalue(rFdr["idres"], true);
					string andRipartizione = " AND codiceripartizione = " + QueryCreator.quotedstrvalue(rFdr["idpar"], true);
					string q = "SELECT idsorkind=codicetipoclass, idsor=idclass, idupb="
						+ QueryCreator.quotedstrvalue(rFdr["idupb"], true)
						+ ", cu=createuser, ct=createtimestamp, "
						+ "lu=lastmoduser, lt=lastmodtimestamp, quota ";
					// Caso 1: Esiste la classificazione del fondo ma non delle suddivisioni
					// Inserisco la classificazione del fondo per tutte le ripartizioni
					if ((ctr == 0)&&(ctf > 0)) {
						q += QueryCreator.quotedstrvalue(rFdr["idupb"], true) 
							+ "FROM classtreefondo " + whereFondo;
					}
					// Caso 2: Esistono le classificazioni delle suddivisioni ma non del fondo
					if ((ctr > 0) && (ctf == 0)) {
						q += "FROM classtreeripartizioni " + whereFondo + andRipartizione;
//						if ((contaFigli1 != 1)&&(rFdr["idpar"] is DBNull)) {
//							q += " and 0=1";
//						}
					}
					// Caso 3: Esistono entrambe le classificazioni
					if ((ctr > 0) && (ctf > 0)) {
						if (contaFigli1 == 1) {
							q += "FROM classtreeripartizioni " + whereFondo + andRipartizione;
						} else {
							if (rFdr["idpar"] is DBNull) {
								q += "FROM classtreefondo " + whereFondo;
							} else {
								q += "FROM classtreeripartizioni " + whereFondo + andRipartizione;
							}
						}
					}
					DataTable tUpbSorting = Migrazione.eseguiQuery(sourceConn, q, form);
					if (tUpbSorting==null) return false;
					tUpbSorting.TableName = "upbsorting";
					bool res=Migrazione.lanciaScript(form, destConn, tUpbSorting, "classtreefondo e classtreeripartizioni -> ubpsorting");
					if (!res)return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Passo 2.3.2. Travaso delle classificazioni dei centri di spesa
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tCdrUpb"></param>
		public static bool migraDaCdsAdUpbSorting(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tCdrUpb) {
			string q = 	"SELECT DISTINCT idsorkind=codicetipoclass, idsor=idclass, idcen=SUBSTRING(idcentrospesa,3,LEN(idcentrospesa)),"
				+ " quota=AVG(quota) FROM classtreecentrospesa "
				+ "GROUP BY codicetipoclass, idclass, SUBSTRING(idcentrospesa,3,LEN(idcentrospesa))";
			DataTable tUpbSorting = Migrazione.eseguiQuery(sourceConn, q, form);
			if (tUpbSorting==null) return false;
			tUpbSorting.Columns.Add("idupb", typeof(string));
			tUpbSorting.Columns.Add("cu", typeof(string));
			tUpbSorting.Columns.Add("ct",typeof(DateTime));
			tUpbSorting.Columns.Add("lu", typeof(string));
			tUpbSorting.Columns.Add("lt",typeof(DateTime));
			foreach (DataRow r in tUpbSorting.Rows) {
				DataRow[] rCdrUpb = tCdrUpb.Select("idcen="+QueryCreator.quotedstrvalue(r["idcen"], false));
				if (rCdrUpb.Length > 0) {
					r["idupb"] = rCdrUpb[0]["idupb"];
				}
				r["cu"] = "SA";
				r["ct"] = DateTime.Now;
				r["lu"] = "'SA'";
				r["lt"] = DateTime.Now;
			}
			tUpbSorting.Columns.Remove("idcen");
			tUpbSorting.TableName = "upbsorting";

			return Migrazione.lanciaScript(form, destConn, tUpbSorting, "classtreecentrospesa -> ubpsorting");
		}


		/// <summary>
		/// Sezione 3. Aggiornamento delle tabelle EXPENSEYEAR ed INCOMEYEAR
		/// Parte 3.1. Aggiornamento della Tabella EXPENSEYEAR
		/// </summary>
		public static bool migraImputazioneEOS(string eos, Form form, DataAccess sourceConn, DataAccess destConn,
			DataTable tFdrUpb, DataTable tCdsUpb, DataTable tUpbLookup) {
			string maxFaseEOS = (string) sourceConn.DO_READ_VALUE("fase"+eos+"", null, "MAX(codicefase)");
			string q0 = "select esercizio, codfaseimpegno,codfaseaccertamento, tipoprevprincipale, tipoprevsecondaria=isnull(tipoprevsecondaria,'A') from persbilancio";
			DataTable tPersBil = Migrazione.eseguiQuery(sourceConn, q0, form);
			if (tPersBil==null) return false;
			string q1 = "select yvar, maxnvar=max(nvar) from finvar group by yvar";
			DataTable tContaFinVar = Migrazione.eseguiQuery(destConn, q1, form);
			if (tContaFinVar==null) return false;

			string nuovoNome = eos == "spesa" ? "exp" : "inc";
			string qEOSY = "select amount=imput.importo, ayear=esercizio, "
				+ "ct=imput.createtimestamp, cu=imput.createuser, flagarrear=flagcompetenza, "
				+ "idcen=idcentrospesa, id"+nuovoNome+"=imput.id"+eos+", "
				+ "idfin=idbilancio, idmul=idbilpluriennale, lt=imput.lastmodtimestamp, "
				+ "lu=imput.lastmoduser, nphase=imput.codicefase, "
				+ "idres=codicefondo, idpar=codiceripartizione "
				+ "from imputazione"+eos+" imput "
				+ "left outer join "+eos+" on "+eos+".id"+eos+"=imput.id"+eos+" ";

			DataTable tEOSYear = Migrazione.eseguiQuery(sourceConn, qEOSY, form);
			if (tEOSYear==null) return false;
			tEOSYear.Columns.Add("idupb",typeof(string));

			VistaUpb ds = new VistaUpb();

			// Passo 3.1.1. Associo gli UPB a tutti i movimenti di "+eos+" con un centro di "+eos+" associato
			foreach (DataRow r in tEOSYear.Rows) {
				r["idupb"] = getIdupbFromFinAndCen(r["idfin"], r["idcen"], tUpbLookup, tCdsUpb);
			}
			// Passo 3.1.2. Associo gli UPB a tutti i movimenti di "+eos+" con un fondo di ricerca associato
			
			// Attenzione! Se si è deciso di non migrare i fondi di ricerca
			// non occorrerà fare gli storni di bilancio, in quanto l'UPB di partenza risulterebbe lo stesso di arrivo,
			int totRighe = tFdrUpb.Select().Length;
			int totRigheUpbRoot = tFdrUpb.Select("(idupb = '0001')").Length;
			bool effettuaStorni = CfgFn.GetNoNullInt32(totRighe) != CfgFn.GetNoNullInt32(totRigheUpbRoot);
			if (effettuaStorni) {
				DialogResult dr = MessageBox.Show(form,"Si vuol procedere agli storni di bilancio dall'UPB Libero"
					+ " agli UPB associati ai Fondi di Ricerca?", "", MessageBoxButtons.YesNo);
				effettuaStorni = effettuaStorni && (dr == DialogResult.Yes);
			}
			foreach (DataRow rFdrUpb in tFdrUpb.Rows) {
				string idUpb = (string) rFdrUpb["idupb"];
				if (rFdrUpb["idpar"]==DBNull.Value) continue;
				string filtroFdrUpb = QueryCreator.WHERE_COLNAME_CLAUSE(rFdrUpb,
					new string[] {"idres", "idpar"}, DataRowVersion.Current, false);
				if (!assegnaUpbAdImputazioneEStorna_perFdR(form, eos, sourceConn, tEOSYear, 
					rFdrUpb["idres"].ToString(), rFdrUpb["idpar"].ToString(), idUpb, tContaFinVar,
					maxFaseEOS,	tPersBil, tFdrUpb, effettuaStorni, ds)) return false;
			}
			//-- Passo 3.1.3. Associo l'UPB a tutti i movimenti di spesa rimanenti
			foreach (DataRow r in tEOSYear.Select("idupb is null")) {
				r["idupb"] = "0001";
			}

			tEOSYear.Columns.Remove("idres");
			tEOSYear.Columns.Remove("idpar");
			tEOSYear.Columns.Remove("idcen");
			tEOSYear.Columns.Remove("idmul");

			tEOSYear.TableName = eos=="spesa" ? "expenseyear" : "incomeyear";
			ds.Tables.Add(tEOSYear);
			return Migrazione.lanciaScript(form, destConn, ds, "imputazione"+eos+" -> "+tEOSYear.TableName+", finvar e finvardetail");
		}

		/// <summary>
		/// Metodo che assegna alle tabelle expenseyear/incomeyear l'upb corrispondente ai FdR e contemporaneamente
		/// storna la previsione dall'UPB libero al nuovo UPB 
		/// </summary>
		/// <param name="form">Form chiamante</param>
		/// <param name="eos">entrata: Per la gestione di incomeyear; spesa: Per la gestione di expenseyear</param>
		/// <param name="sourceConn">Connessione Sorgente</param>
		/// <param name="tEOSYear">Tabella delle imputazioni dei movimenti di entrata o spesa</param>
		/// <param name="codiceFondo">Codice del FdR</param>
		/// <param name="codiceRipartizione">Codice della Ripartizione</param>
		/// <param name="idUpb">ID dell'UPB</param>
		/// <param name="tContaFinVar">Tabella delle variazione di bilancio</param>
		/// <param name="maxFaseEOS">Massima fase di entrata/spesa</param>
		/// <param name="tPersBil">Tabella di configurazione del bilancio</param>
		/// <param name="ds">DataSet</param>
		private static bool assegnaUpbAdImputazioneEStorna_perFdR(Form form, string eos,
			DataAccess sourceConn, DataTable tEOSYear, string codiceFondo, string codiceRipartizione, 
			string idUpb, DataTable tContaFinVar,
			string maxFaseEOS, DataTable tPersBil, DataTable tFdrUpb,
			bool effettuaStorni, VistaUpb ds) 
		{
			string filtroResPar = "idres="+QueryCreator.quotedstrvalue(codiceFondo, true)
				+ "and idpar="+QueryCreator.quotedstrvalue(codiceRipartizione, true);
			DataRow[] rEY = tEOSYear.Select(filtroResPar);
			ArrayList al = new ArrayList();
			

			foreach (DataRow r in rEY) {
				r["idupb"] = idUpb;
				short esercVariazione = (short) r["ayear"];
				if (!effettuaStorni) continue;
				if (!al.Contains(esercVariazione)) {
					al.Add(esercVariazione);
                    if(tPersBil.Select("esercizio=" + esercVariazione).Length == 0) continue;
					DataRow rPersBil = tPersBil.Select("esercizio="+esercVariazione)[0];
					string tipoPrevPrincipale = (string) rPersBil["tipoprevprincipale"];
					string tipoPrevSecondaria =  rPersBil["tipoprevsecondaria"].ToString();
					object codFaseCompetenza=
						eos=="spesa"? rPersBil["codfaseimpegno"]:rPersBil["codfaseaccertamento"];
					string vecchioNome = eos == "spesa" ? "exp" : "inc";
                    // Qui ci va un if sull'esercizio!!!
                    object ultimo = sourceConn.DO_READ_VALUE("esercizio", "(flagtrasfconfigbilancio = 'S')", "max(esercizio)");
                    if ((ultimo != null) && (ultimo != DBNull.Value)) {
                        int lastYear = 1 + CfgFn.GetNoNullInt32(ultimo);
                        if (esercVariazione != lastYear) {
                            // Parte 5.2. Aggiornamento delle previsioni legati ai movimenti associati alle voci di bilancio/U.P.B. inserite in FINYEAR
                            if (!stornaDaLiberoAdUpb(form, sourceConn, eos, true, tipoPrevPrincipale, esercVariazione, tContaFinVar,
                                codiceFondo, codiceRipartizione,
                                (string)r["idupb"], codFaseCompetenza, maxFaseEOS, ds)) return false;

                            if (tipoPrevSecondaria == "S") {
                                if (!stornaDaLiberoAdUpb(form, sourceConn, eos, false, "S", esercVariazione, tContaFinVar,
                                    codiceFondo, codiceRipartizione,
                                    (string)r["idupb"], codFaseCompetenza, maxFaseEOS, ds)) return false;
                            }
                        }
                    }
				}
			}
			return true;
		}

		private static bool stornaPrevisioneDaLiberoAFdR_MonoCapitolo(string eos, Form form, DataAccess sourceConn,
			DataAccess destConn, DataTable tFdrUpb) {
			object ayear = sourceConn.DO_READ_VALUE("esercizio", "flagtrasfconfigbilancio = 'S'", "MAX(esercizio)");
			if ((ayear == null) || (ayear == DBNull.Value)) return true;

			int fromYear = Convert.ToInt32(ayear);
			int toYear = 1 + fromYear;
			
			DataTable tPrevision = new DataTable();
			tPrevision.Columns.Add("idres", typeof(string));
			tPrevision.Columns.Add("idpar", typeof(string));
			tPrevision.Columns.Add("idupb", typeof(string));
			tPrevision.Columns.Add("idfin", typeof(string));
			tPrevision.Columns.Add("amount", typeof(decimal));

			string tImpMovName = "";
			string tMovName = "";
			string tVarName = "";
			string tMovPrecName = "";
			string tVarRipName = "";
			string idbilField = "";
			string idmovField = "";
			string nphaseField = "";
			string prevField = "";
			string tPhaseName = "";

			if (eos == "S") {
				tImpMovName = "imputazionespesa";
				tMovName = "spesa";
				tVarName = "variazionespesa";
				tMovPrecName = "totfondospesaprec";
				tVarRipName = "varripfondispese";
				idbilField = "idbilanciospesa";
				idmovField = "idspesa";
				nphaseField = "codfaseimpegno";
				prevField = "previsionespese";
				tPhaseName = "fasespesa";
			}
			else {
				tImpMovName = "imputazioneentrata";
				tMovName = "entrata";
				tVarName = "variazioneentrata";
				tMovPrecName = "totfondoentrataprec";
				tVarRipName = "varripfondientrate";
				idbilField = "idbilancioentrata";
				idmovField = "identrata";
				nphaseField = "codfaseaccertamento";
				prevField = "previsioneentrate";
				tPhaseName = "faseentrata";
			}
		
            // In base alla configurazione di bilancio devo riempirmi l'array delle fasi!!!!!
            object mainPrev = sourceConn.DO_READ_VALUE("persbilancio", "esercizio = '" + fromYear + "'", "tipoprevprincipale");
            object secPrev = sourceConn.DO_READ_VALUE("persbilancio", "esercizio = '" + fromYear + "'", "tipoprevsecondaria");

            if (mainPrev == null) {
                MessageBox.Show("Non è stata impostata la previsione principale di bilancio nell'esercizio " + fromYear);
                return false;
            }
            int totFasiDaConsiderare = 1;
            if ((secPrev != null) && (secPrev != DBNull.Value) && (secPrev.ToString().ToUpper() == "S")) {
                totFasiDaConsiderare++;
            }
            string [] elencoFasi = new string[totFasiDaConsiderare];

            object finPhase = sourceConn.DO_READ_VALUE("persbilancio", "esercizio = '" + fromYear + "'", nphaseField);
            object maxPhase = sourceConn.DO_READ_VALUE(tPhaseName, null, "MAX(codicefase)");

            string mp = mainPrev.ToString().ToUpper();

            switch (mp) {
                case "C": {
                        if ((finPhase == null) || (finPhase == DBNull.Value)) {
                            string nFase = (eos == "S") ? "impegno" : "accertamento";
                            MessageBox.Show("Non è stata impostata la fase relativa all'" + nFase + " nell'esercizio " + fromYear);
                            return false;
                        }
                        elencoFasi[0] = finPhase.ToString();

                        if ((secPrev != null) && (secPrev != DBNull.Value) && (secPrev.ToString().ToUpper() == "S")) {
                            if ((maxPhase == null) || (maxPhase == DBNull.Value)) {
                                string parte = (eos == "S") ? "spesa" : "entrata";
                                MessageBox.Show("Non esistono fasi di " + parte);
                                return false;
                            }
                            elencoFasi[1] = maxPhase.ToString();
                        }
                        break;
                    }

                case "S": {
                        if ((maxPhase == null) || (maxPhase == DBNull.Value)) {
                            string parte = (eos == "S") ? "spesa" : "entrata";
                            MessageBox.Show("Non esistono fasi di " + parte);
                            return false;
                        }
                        elencoFasi[0] = maxPhase.ToString();
                        break;
                    }
            }

			string filename = "fondi.txt";
			StreamWriter fsw = new StreamWriter(filename, true, Encoding.Default);

			decimal totPrevisioneDisp = 0;
			string testataFile = (eos == "S") ? "MIGRAZIONE SUDDIVISIONE IN SPESA" : "MIGRAZIONE SUDDIVISIONE IN ENTRATA";
			fsw.WriteLine(testataFile);

			foreach(string currPhase in elencoFasi) {
				foreach(DataRow rSuddivisione in tFdrUpb.Select("(idres is not null) and (idpar is not null)")) {
					string idRes = rSuddivisione["idres"].ToString();
					string idPar = rSuddivisione["idpar"].ToString();
					string idBilNew = "";
					string fSudd_Uni = "(codicefondo = " + QueryCreator.quotedstrvalue(idRes, true)
						+ ") AND (codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true)
						+ ") AND (esercizio = '" + fromYear + "')";

					object idbil = sourceConn.DO_READ_VALUE("previsioneripfondi", fSudd_Uni, idbilField);

					string log_text = "";
					if ((idbil == null) || (idbil == DBNull.Value)) {
						string sqlCmd = "SELECT COUNT(DISTINCT IMP.idbilancio)" +
							" FROM " + tMovName + " MOV " +
							" JOIN " + tImpMovName + " IMP " +
							" ON MOV." + idmovField + " = IMP." + idmovField +
							" WHERE MOV.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
							" AND MOV.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
							" AND MOV.codicefase = '" + currPhase + 
							"' AND IMP.esercizio = '" + fromYear + "'";

						DataTable t = sourceConn.SQLRunner(sqlCmd);
						if ((t == null)|| (t.Rows.Count == 0)) {
							log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
								+ " non migrato. Errore nella query sul COUNT di IDBILANCIO. Ramo idbil IS NULL";
							fsw.WriteLine(log_text);
							continue;
						}

						int nRow = CfgFn.GetNoNullInt32(t.Rows[0][0]);
						if (nRow != 1) {
							log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
								+ " non migrato. Ci sono più voci di bilancio associate alla suddivisione. Ramo idbil IS NULL";
							fsw.WriteLine(log_text);
							continue;
						}
						string sqlCmd2 = "SELECT DISTINCT IMP.idbilancio" +
							" FROM " + tMovName + " MOV " +
							" JOIN " + tImpMovName + " IMP " +
							" ON MOV." + idmovField + " = IMP." + idmovField +
							" WHERE MOV.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
							" AND MOV.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
							" AND MOV.codicefase = '" + currPhase + 
							"' AND IMP.esercizio = '" + fromYear + "'";

						DataTable tB = sourceConn.SQLRunner(sqlCmd2);
						if ((tB == null) || (tB.Rows.Count == 0)) {
							log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
								+ " non migrato. Errore nella query sul DISTINCT delle voci di bilancio. Ramo idbil IS NULL";
							fsw.WriteLine(log_text);
							continue;
						}
						if (tB.Rows[0][0].ToString() == "") {
							log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
								+ " non migrato. Voce di bilancio vuota. Ramo idbil IS NULL";
							fsw.WriteLine(log_text);
							continue;
						}
						idbil = tB.Rows[0][0];
					}

                    string q1 = "SELECT ISNULL((SELECT SUM(" + prevField + ")" +
                        " FROM previsioneripfondi " +
                        " WHERE codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                        " AND codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
                        " AND esercizio <= '" + fromYear +
						"'),0) + " +
						"ISNULL((SELECT SUM(importo) " +
						" FROM " + tVarRipName +
						" WHERE codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
						" AND codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
						" AND esercizio <= '" + fromYear + 
						"'),0) - (" +
						" ISNULL((SELECT SUM(importo) " +
						" FROM " + tMovName + " MOV " +
						" WHERE codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
						" AND codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
						" AND MOV.codicefase = '" + currPhase +
                        "' AND MOV.esercmovimento <= '" + fromYear +
						"'),0) + " +
						" ISNULL((SELECT SUM(V.importo) " +
						" FROM " + tVarName + " V " +
						" JOIN " + tMovName + " M " +
						" ON M." + idmovField + " = V." + idmovField +
						" WHERE M.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
						" AND M.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
						" AND M.codicefase = '" + currPhase +
                        "' AND V.esercvariazione <= '" + fromYear +
						"'),0) + " +
						" ISNULL((SELECT SUM(importo) " +
						" FROM " + tMovPrecName +
						" WHERE codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
						" AND codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
						" AND codicefase = '" + currPhase + "'),0))";

					DataTable t2 = sourceConn.SQLRunner(q1);
					if (t2 == null) {
						log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
							+ " non migrato. Errore nella query che calcola la previsione disponibile. Ramo in comune";
						fsw.WriteLine(log_text);
						fsw.Close();
						return false;
					}
					totPrevisioneDisp = CfgFn.GetNoNullDecimal(t2.Rows[0][0]);

					if (totPrevisioneDisp == 0) {
						log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
							+ " non migrato ... previsione disponibile = 0";
						fsw.WriteLine(log_text);
						continue;
					}

					string f_ConvBil = "(oldidbilancio = " + QueryCreator.quotedstrvalue(idbil, true) + ")";
					object b = sourceConn.DO_READ_VALUE("convertbilancio", f_ConvBil, "newidbilancio");
					if ((b != null) && (b != DBNull.Value)) {
						idBilNew = b.ToString();
					}
					else {
						idBilNew = toYear.ToString().Substring(2) + idbil.ToString().Substring(2);
					}

					DataRow rPrevision = tPrevision.NewRow();

					rPrevision["idres"] = rSuddivisione["idres"];
					rPrevision["idpar"] = rSuddivisione["idpar"];
					rPrevision["idupb"] = rSuddivisione["idupb"];
					rPrevision["idfin"] = idBilNew;
					rPrevision["amount"] = totPrevisioneDisp;

					tPrevision.Rows.Add(rPrevision);
				}

				if (tPrevision.Rows.Count > 0) {
					DataTable tFinVar = DataAccess.CreateTableByName(destConn, "finvar", "*");
					tFinVar.TableName = "finvar";
					DataTable tFinVarDetail = DataAccess.CreateTableByName(destConn, "finvardetail", "*");
					tFinVarDetail.TableName = "finvardetail";

					object n = destConn.DO_READ_VALUE("finvar", "(yvar = '" + toYear + "')", "MAX(nvar)");
					int numVariazione = 1 + CfgFn.GetNoNullInt32(n);

					DataRow rFinVar = tFinVar.NewRow();

                    string flagMain = "";
                    string flagSecondary = "";

                    // Se ci sono più fasi da considerare vuol dire che mi trovo in una configurazione
                    // di COMPETENZA e CASSA => I flag verranno valorizzati alternativamente in base alla fase che
                    // sto analizzando
                    // Se invece esiste una sola fase vuol dire che mi trovo in una configurazione di
                    // COMPETENZA o CASSA => Il flag della previsione principale viene sempre valorizzato a S
                    // mentre quello della seconda sempre a N
                    if (elencoFasi.Length > 1) {
                        flagMain = (currPhase == finPhase.ToString()) ? "S" : "N";
                        flagSecondary = (currPhase == maxPhase.ToString()) ? "S" : "N";
                    }
                    else {
                        flagMain = "S";
                        flagSecondary = "N";
                    }

					rFinVar["yvar"] = toYear;
					rFinVar["nvar"] = numVariazione;
					rFinVar["adate"] = new DateTime(toYear, 1, 1);
					rFinVar["description"] = "Storno da UPB 0001 a UPB ex F.d.R.";
					rFinVar["enactment"] = DBNull.Value;
					rFinVar["enactmentdate"] = DBNull.Value;
					rFinVar["flagcredit"] = "N";
                    rFinVar["flagprevision"] = flagMain;
					rFinVar["flagproceeds"] = "N";
                    rFinVar["flagsecondaryprev"] = flagSecondary;
					rFinVar["nenactment"] = DBNull.Value;
					rFinVar["variationkind"] = "S";
					rFinVar["rtf"] = DBNull.Value;
					rFinVar["txt"] = DBNull.Value;
					rFinVar["ct"] = DateTime.Now;
					rFinVar["cu"] = "Software and More";
					rFinVar["lt"] = DateTime.Now;
					rFinVar["lu"] = "'Software and More'";

					tFinVar.Rows.Add(rFinVar);

					foreach(DataRow rPrevision in tPrevision.Rows) {
						string filterVar = "(idupb = '0001') AND (idfin = " + QueryCreator.quotedstrvalue(rPrevision["idfin"],false) + ")";
						DataRow [] ROWS = tFinVarDetail.Select(filterVar);
						if (ROWS.Length > 0) {
							DataRow rFinVarUpbMain = ROWS[0];
							rFinVarUpbMain["amount"] = CfgFn.GetNoNullDecimal(rFinVarUpbMain["amount"]) -
								CfgFn.GetNoNullDecimal(rPrevision["amount"]);
						}
						else {
							DataRow rFinVarUpbMain = tFinVarDetail.NewRow();
							rFinVarUpbMain["yvar"] = rFinVar["yvar"];
							rFinVarUpbMain["nvar"] = rFinVar["nvar"];
							rFinVarUpbMain["idupb"] = "0001";
							rFinVarUpbMain["idfin"] = rPrevision["idfin"];
							rFinVarUpbMain["amount"] = - CfgFn.GetNoNullDecimal(rPrevision["amount"]);
							rFinVarUpbMain["description"] = "Storno di previsione per F.d.R.";
							rFinVarUpbMain["ct"] = DateTime.Now;
							rFinVarUpbMain["cu"] = "Software and More";
							rFinVarUpbMain["lt"] = DateTime.Now;
							rFinVarUpbMain["lu"] = "'Software and More'";

							tFinVarDetail.Rows.Add(rFinVarUpbMain);
						}

						string filterVar2 = "(idupb = " + QueryCreator.quotedstrvalue(rPrevision["idupb"], false) +
							") AND (idfin = " + QueryCreator.quotedstrvalue(rPrevision["idfin"], false) + ")";

						DataRow [] ROWS2 = tFinVarDetail.Select(filterVar2);
						if (ROWS2.Length > 0) {
							DataRow rFinVarFdr = ROWS2[0];
							rFinVarFdr["amount"] = CfgFn.GetNoNullDecimal(rFinVarFdr["amount"]) +
								CfgFn.GetNoNullDecimal(rPrevision["amount"]);
						}
						else {
							DataRow rFinVarFdr = tFinVarDetail.NewRow();
							rFinVarFdr["yvar"] = rFinVar["yvar"];
							rFinVarFdr["nvar"] = rFinVar["nvar"];
							rFinVarFdr["idupb"] = rPrevision["idupb"];
							rFinVarFdr["idfin"] = rPrevision["idfin"];
							rFinVarFdr["amount"] = CfgFn.GetNoNullDecimal(rPrevision["amount"]);
							rFinVarFdr["description"] = "Storno di previsione per F.d.R.";
							rFinVarFdr["ct"] = DateTime.Now;
							rFinVarFdr["cu"] = "Software and More";
							rFinVarFdr["lt"] = DateTime.Now;
							rFinVarFdr["lu"] = "'Software and More'";

							tFinVarDetail.Rows.Add(rFinVarFdr);
						}
						string log_text = "Fondo " + rPrevision["idres"].ToString() + " Suddivisione " + rPrevision["idpar"].ToString()
							+ " migrato!";
						fsw.WriteLine(log_text);
					}
					DataSet ds = new DataSet();
					ds.Tables.Add(tFinVar);
					ds.Tables.Add(tFinVarDetail);

					if (!Migrazione.lanciaScript(form, destConn, ds, "storni ultimo anno da UPB principale a UPB F.d.R.")) {
						fsw.Close();
						return false;
					}
                    tPrevision.Clear();
				}
			}
			fsw.Close();
			return true;
		}

        /// <summary>
        /// Metodo che storna i crediti e la cassa dall'UPB dipartimento all'UPB dei fondi di ricerca secondo la formula
        /// ACCERTATO - IMPEGNATO al 31.12.2006 per i crediti
        /// INCASSATO - PAGATO al 31.12.2006 per gli incassi
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <param name="tFdrUpb"></param>
        /// <returns></returns>
        private static bool stornaCreditiCassaDaLiberoAFdR_MonoCapitolo(Form form, DataAccess sourceConn,
            DataAccess destConn, DataTable tFdrUpb) {
            object ayear = sourceConn.DO_READ_VALUE("esercizio", "flagtrasfconfigbilancio = 'S'", "MAX(esercizio)");
            if ((ayear == null) || (ayear == DBNull.Value)) return true;

            int fromYear = Convert.ToInt32(ayear);
            int toYear = 1 + fromYear;

            string filter_yvar = "(esercvariazione <= " + fromYear + ")";
            string filter_yass = "(esercassegnazione <= " + fromYear + ")";

            object v_cr = sourceConn.DO_READ_VALUE("variazionecrediti", filter_yvar, "COUNT(*)");
            object a_cr = sourceConn.DO_READ_VALUE("assegnazionecrediti", filter_yass, "COUNT(*)");

            bool generaCrediti = (CfgFn.GetNoNullInt32(v_cr) + CfgFn.GetNoNullInt32(a_cr) > 0);

            object v_ca = sourceConn.DO_READ_VALUE("variazionecassa", filter_yvar, "COUNT(*)");
            object a_ca = sourceConn.DO_READ_VALUE("assegnazioneincassi", filter_yass, "COUNT(*)");

            bool generaIncassi = (CfgFn.GetNoNullInt32(v_ca) + CfgFn.GetNoNullInt32(a_ca) > 0);

            if (!(generaCrediti || generaIncassi)) return true;

            if (generaCrediti) {
                object appPhase = sourceConn.DO_READ_VALUE("persbilancio", "(esercizio = " + fromYear + ")", "codfaseimpegno");
                if ((appPhase == null) || (appPhase == DBNull.Value)) {
                    MessageBox.Show(form, "Non è stata definita la fase di impegno", "Errore");
                    return false;
                }
                object assPhase = sourceConn.DO_READ_VALUE("persbilancio", "(esercizio = " + fromYear + ")", "codfaseaccertamento");
                if ((assPhase == null) || (assPhase == DBNull.Value)) {
                    MessageBox.Show(form, "Non è stata definita la fase di accertamento", "Errore");
                    return false;
                }
                generaVariazione_CC(form, sourceConn, destConn, tFdrUpb, appPhase, assPhase, "C");
            }

            if (generaIncassi) {
                object maxPhaseE = sourceConn.DO_READ_VALUE("fasespesa", null, "MAX(codicefase)");
                if ((maxPhaseE == null) || (maxPhaseE == DBNull.Value)) {
                    MessageBox.Show(form, "Non esistono fasi di spesa", "Errore");
                    return false;
                }
                object maxPhaseI = sourceConn.DO_READ_VALUE("faseentrata", null, "MAX(codicefase)");
                if ((maxPhaseI == null) || (maxPhaseI == DBNull.Value)) {
                    MessageBox.Show(form, "Non esistono fasi di entrata", "Errore");
                    return false;
                }
                generaVariazione_CC(form, sourceConn, destConn, tFdrUpb, maxPhaseE, maxPhaseI, "P");
            }

            return true;
        }

        /// <summary>
        /// Metodo che calcola le variazioni per la dotazione crediti/incassi
        /// </summary>
        /// <param name="sourceConn">Connessione Sorgente</param>
        /// <param name="destConn">Connessione Destinazione</param>
        /// <param name="tFdrUpb">Tabella di Lookup Fondi di Ricerca - U.P.B.</param>
        /// <param name="currPhaseE">Fase di Spesa</param>
        /// <param name="currPhaseI">Fase di Entrata</param>
        /// <param name="c_p">Flag che indica se stiamo stornando i crediti o gli incassi.
        /// Valori ammessi C: Crediti; P: Incassi</param>
        /// <returns></returns>
        private static bool generaVariazione_CC(Form form, DataAccess sourceConn, DataAccess destConn,
            DataTable tFdrUpb, object currPhaseE, object currPhaseI, string c_p) {

            object ayear = sourceConn.DO_READ_VALUE("esercizio", "flagtrasfconfigbilancio = 'S'", "MAX(esercizio)");
            if ((ayear == null) || (ayear == DBNull.Value)) return true;

            int fromYear = Convert.ToInt32(ayear);
            int toYear = 1 + fromYear;

            DataTable tPrevision = new DataTable();
            tPrevision.Columns.Add("idres", typeof(string));
            tPrevision.Columns.Add("idpar", typeof(string));
            tPrevision.Columns.Add("idupb", typeof(string));
            tPrevision.Columns.Add("idfin", typeof(string));
            tPrevision.Columns.Add("amount", typeof(decimal));

            foreach (DataRow rSuddivisione in tFdrUpb.Select("(idres is not null) and (idpar is not null)")) {
                string idRes = rSuddivisione["idres"].ToString();
                string idPar = rSuddivisione["idpar"].ToString();
                string idBilNew = "";
                string fSudd_Uni = "(codicefondo = " + QueryCreator.quotedstrvalue(idRes, true)
                    + ") AND (codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true)
                    + ") AND (esercizio = '" + fromYear + "')";

                object idbil = sourceConn.DO_READ_VALUE("previsioneripfondi", fSudd_Uni, "idbilanciospesa");

                if ((idbil == null) || (idbil == DBNull.Value)) {
                    string sqlCmd = "SELECT COUNT(DISTINCT IMP.idbilancio)" +
                        " FROM spesa MOV " +
                        " JOIN imputazionespesa IMP " +
                        " ON MOV.idspesa = IMP.idspesa " +
                        " WHERE MOV.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                        " AND MOV.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
                        " AND MOV.codicefase = '" + currPhaseE +
                        "' AND IMP.esercizio = '" + fromYear + "'";

                    DataTable t = sourceConn.SQLRunner(sqlCmd);
                    if ((t == null) || (t.Rows.Count == 0)) {
                        continue;
                    }

                    int nRow = CfgFn.GetNoNullInt32(t.Rows[0][0]);
                    if (nRow != 1) {
                        continue;
                    }

                    string sqlCmd2 = "SELECT DISTINCT IMP.idbilancio" +
                        " FROM spesa MOV " +
                        " JOIN imputazionespesa IMP " +
                        " ON MOV.idspesa = IMP.idspesa " +
                        " WHERE MOV.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                        " AND MOV.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
                        " AND MOV.codicefase = '" + currPhaseE +
                        "' AND IMP.esercizio = '" + fromYear + "'";

                    DataTable tB = sourceConn.SQLRunner(sqlCmd2);
                    if ((tB == null) || (tB.Rows.Count == 0)) {
                        continue;
                    }
                    if (tB.Rows[0][0].ToString() == "") {
                        continue;
                    }
                    idbil = tB.Rows[0][0];
                }

                string q1 = "SELECT ISNULL((SELECT importo " +
                    " FROM totfondoentrataprec te " +
                    " WHERE codicefase = '" + currPhaseI + "'" +
                    " AND te.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                    " AND te.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) + "),0) " +
                    " + ISNULL((SELECT SUM(totale) " +
                    " FROM totfondoentrata te " +
                    " WHERE esercizio <= " + fromYear +
                    " AND te.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                    " AND te.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
                    " AND codicefase = '" + currPhaseI + "'),0) " +
                    " - ISNULL((SELECT importo " +
                    " FROM totfondospesaprec ts " +
                    " WHERE codicefase = '" + currPhaseE + "'" +
                    " AND ts.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                    " AND ts.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) + "),0) " +
                    " - ISNULL((SELECT SUM(totale) " +
                    " FROM totfondospesa ts " +
                    " WHERE esercizio <= " + fromYear +
                    " AND ts.codicefondo = " + QueryCreator.quotedstrvalue(idRes, true) +
                    " AND ts.codiceripartizione = " + QueryCreator.quotedstrvalue(idPar, true) +
                    " AND codicefase = '" + currPhaseE + "'),0) ";

                DataTable t2 = sourceConn.SQLRunner(q1);
                if (t2 == null) {
                    string log_text = "Fondo " + rSuddivisione["idres"].ToString() + " Suddivisione " + rSuddivisione["idpar"].ToString()
                        + " non migrato. Errore nella query che calcola la previsione disponibile. Ramo in comune";
                    MessageBox.Show(form, log_text, "Errore");
                    return false;
                }
                decimal totDifferenza = CfgFn.GetNoNullDecimal(t2.Rows[0][0]);

                if (totDifferenza == 0) {
                    continue;
                }

                string f_ConvBil = "(oldidbilancio = " + QueryCreator.quotedstrvalue(idbil, true) + ")";
                object b = sourceConn.DO_READ_VALUE("convertbilancio", f_ConvBil, "newidbilancio");
                if ((b != null) && (b != DBNull.Value)) {
                    idBilNew = b.ToString();
                }
                else {
                    idBilNew = toYear.ToString().Substring(2) + idbil.ToString().Substring(2);
                }

                DataRow rPrevision = tPrevision.NewRow();

                rPrevision["idres"] = rSuddivisione["idres"];
                rPrevision["idpar"] = rSuddivisione["idpar"];
                rPrevision["idupb"] = rSuddivisione["idupb"];
                rPrevision["idfin"] = idBilNew;
                rPrevision["amount"] = totDifferenza;

                tPrevision.Rows.Add(rPrevision);
            }

            if (tPrevision.Rows.Count > 0) {
                DataTable tFinVar = DataAccess.CreateTableByName(destConn, "finvar", "*");
                tFinVar.TableName = "finvar";
                DataTable tFinVarDetail = DataAccess.CreateTableByName(destConn, "finvardetail", "*");
                tFinVarDetail.TableName = "finvardetail";

                object n = destConn.DO_READ_VALUE("finvar", "(yvar = '" + toYear + "')", "MAX(nvar)");
                int numVariazione = 1 + CfgFn.GetNoNullInt32(n);

                string flagCredit = (c_p == "C") ? "S" : "N";
                string flagProceeds = (c_p == "P") ? "S" : "N";
                DataRow rFinVar = tFinVar.NewRow();

                rFinVar["yvar"] = toYear;
                rFinVar["nvar"] = numVariazione;
                rFinVar["adate"] = new DateTime(toYear, 1, 1);
                rFinVar["description"] = "Storno da UPB 0001 a UPB ex F.d.R.";
                rFinVar["enactment"] = DBNull.Value;
                rFinVar["enactmentdate"] = DBNull.Value;
                rFinVar["flagcredit"] = flagCredit;
                rFinVar["flagprevision"] = "N";
                rFinVar["flagproceeds"] = flagProceeds;
                rFinVar["flagsecondaryprev"] = "N";
                rFinVar["nenactment"] = DBNull.Value;
                rFinVar["variationkind"] = "S";
                rFinVar["rtf"] = DBNull.Value;
                rFinVar["txt"] = DBNull.Value;
                rFinVar["ct"] = DateTime.Now;
                rFinVar["cu"] = "Software and More";
                rFinVar["lt"] = DateTime.Now;
                rFinVar["lu"] = "'Software and More'";

                tFinVar.Rows.Add(rFinVar);

                foreach (DataRow rPrevision in tPrevision.Rows) {
                    string filterVar = "(idupb = '0001') AND (idfin = " + QueryCreator.quotedstrvalue(rPrevision["idfin"], false) + ")";
                    DataRow[] ROWS = tFinVarDetail.Select(filterVar);
                    if (ROWS.Length > 0) {
                        DataRow rFinVarUpbMain = ROWS[0];
                        rFinVarUpbMain["amount"] = CfgFn.GetNoNullDecimal(rFinVarUpbMain["amount"]) -
                            CfgFn.GetNoNullDecimal(rPrevision["amount"]);
                    }
                    else {
                        string descr_detail = "";
                        if (c_p == "C") {
                            descr_detail = "Storno di crediti per F.d.R.";
                        }
                        else {
                            descr_detail = "Storno di cassa per F.d.R.";
                        }
                        DataRow rFinVarUpbMain = tFinVarDetail.NewRow();
                        rFinVarUpbMain["yvar"] = rFinVar["yvar"];
                        rFinVarUpbMain["nvar"] = rFinVar["nvar"];
                        rFinVarUpbMain["idupb"] = "0001";
                        rFinVarUpbMain["idfin"] = rPrevision["idfin"];
                        rFinVarUpbMain["amount"] = -CfgFn.GetNoNullDecimal(rPrevision["amount"]);
                        rFinVarUpbMain["description"] = descr_detail;
                        rFinVarUpbMain["ct"] = DateTime.Now;
                        rFinVarUpbMain["cu"] = "Software and More";
                        rFinVarUpbMain["lt"] = DateTime.Now;
                        rFinVarUpbMain["lu"] = "'Software and More'";

                        tFinVarDetail.Rows.Add(rFinVarUpbMain);
                    }

                    string filterVar2 = "(idupb = " + QueryCreator.quotedstrvalue(rPrevision["idupb"], false) +
                        ") AND (idfin = " + QueryCreator.quotedstrvalue(rPrevision["idfin"], false) + ")";

                    DataRow[] ROWS2 = tFinVarDetail.Select(filterVar2);
                    if (ROWS2.Length > 0) {
                        DataRow rFinVarFdr = ROWS2[0];
                        rFinVarFdr["amount"] = CfgFn.GetNoNullDecimal(rFinVarFdr["amount"]) +
                            CfgFn.GetNoNullDecimal(rPrevision["amount"]);
                    }
                    else {
                        DataRow rFinVarFdr = tFinVarDetail.NewRow();
                        rFinVarFdr["yvar"] = rFinVar["yvar"];
                        rFinVarFdr["nvar"] = rFinVar["nvar"];
                        rFinVarFdr["idupb"] = rPrevision["idupb"];
                        rFinVarFdr["idfin"] = rPrevision["idfin"];
                        rFinVarFdr["amount"] = CfgFn.GetNoNullDecimal(rPrevision["amount"]);
                        rFinVarFdr["description"] = "Storno di previsione per F.d.R.";
                        rFinVarFdr["ct"] = DateTime.Now;
                        rFinVarFdr["cu"] = "Software and More";
                        rFinVarFdr["lt"] = DateTime.Now;
                        rFinVarFdr["lu"] = "'Software and More'";

                        tFinVarDetail.Rows.Add(rFinVarFdr);
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(tFinVar);
                ds.Tables.Add(tFinVarDetail);

                if (!Migrazione.lanciaScript(form, destConn, ds, "storni crediti/incassi ultimo anno da UPB principale a UPB F.d.R.")) {
                    return false;
                }
                tPrevision.Clear();
            }

            return true;
        }
		/// <summary>
		/// Metodo che assegna alle tabelle expenseyear/incomeyear l'upb corrispondente ai CdS e contemporaneamente
		/// storna la previsione dall'UPB libero al nuovo UPB 
		/// </summary>
		/// <param name="form">Form Chiamante</param>
		/// <param name="eos">entrata: Per la gestione di incomeyear; spesa: Per la gestione di expenseyear</param>
		/// <param name="sourceConn">Connessione Sorgente</param>
		/// <param name="tEOSYear">Tabella delle imputazioni dei movimenti di entrata o spesa</param>
		/// <param name="filtroCdsUpb">Filtro sul Centro di Spesa</param>
		/// <param name="idUpb">ID dell'UPB</param>
		/// <param name="ds">DataSet</param>
		private static void assegnaUpbAdImputazione_perCdS(Form form, string eos,
			DataAccess sourceConn, DataTable tEOSYear, string filtroCdsUpb,
			string idUpb, VistaUpb ds) 
		{
			DataRow[] rEY = tEOSYear.Select(filtroCdsUpb);
			foreach (DataRow r in rEY) {
				r["idupb"] = idUpb;
			}
		}


		/// <summary>
		/// Sezione 4. Aggiornamento della tabella PETTYCASHOPERATION
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tFdrUpb"></param>
		/// <param name="tCdsUpb"></param>
		private static bool migraOpFondoPiccoleSpese(Form form, DataAccess sourceConn, DataAccess destConn,
			DataTable tColName, DataTable tFdrUpb, DataTable tCdsUpb, DataTable tUpblookup) {
			DataTable tPettyCashOperation =
				Migrazione.leggiETraduciTabella("opfondopiccolespese", sourceConn, tColName, form, null, 
				"idcen=idcentrospesa, idres=codicefondo, idpar=codiceripartizione");
			if (tPettyCashOperation==null) return false;
			tPettyCashOperation.TableName = "pettycashoperation";
			tPettyCashOperation.Columns.Add("idupb",typeof(string));
			foreach (DataRow r in tPettyCashOperation.Rows) {
				object idUpb = getIdupbFromFinAndCen(r["idfin"], r["idcen"], tUpblookup, tCdsUpb);
				if (idUpb.ToString() != "0001") {
					// Parte 4.1. Assegnazione dell'UPB alle operazioni associate a centri di spesa
					r["idupb"] = idUpb;
				} else {
					string filtroFdrUpb = QueryCreator.WHERE_COLNAME_CLAUSE(r,
						new string[] {"idres","idpar"}, DataRowVersion.Current, false);
					DataRow[] rFdrUpb = tFdrUpb.Select(filtroFdrUpb);
					if (rFdrUpb.Length > 0) {
						// Parte 4.2. Assegnazione dell'UPB alle operazioni associate a fondi di ricerca
						r["idupb"] = rFdrUpb[0]["idupb"];
					}
				}
			}
			// Parte 4.3. Assegnazione dell'UPB a tutte le operazioni non assegnate 
			foreach (DataRow r in tPettyCashOperation.Select("(idfin is not null) and (idupb is null)")) {
				r["idupb"] = "0001";
			}
			tPettyCashOperation.Columns.Remove("idcen");
			tPettyCashOperation.Columns.Remove("idres");
			tPettyCashOperation.Columns.Remove("idpar");
			return Migrazione.lanciaScript(form, destConn, tPettyCashOperation, "opfondopiccolespese -> pettycashoperation");
		}

		private static int getNVarForYVar(int esercVariazione, DataTable tFinVar, DataTable tContaFinVar) {
			object o = tFinVar.Compute("max(nvar)", "yvar="+esercVariazione);
			if (o is DBNull) {
				DataRow[] r = tContaFinVar.Select("yvar="+esercVariazione);
				o = (r.Length>0) ? r[0]["maxnvar"] : 0;
			}
			return 1 + (int) o;
		}

		private static bool stornaDaLiberoAdUpb(Form form, DataAccess sourceConn, string eos, bool isPrincipale, string previsionKind, 
			int esercVariazione, DataTable tContaFinVar,
			string codiceFondo, string codiceRipartizione, string idUpb,
			object codFaseImpegno, string maxFase, VistaUpb ds) 
		{
			int numVariazione = getNVarForYVar(esercVariazione, ds.finvar, tContaFinVar);
			string descrizione = "Storno da UPB Dipartimento a UPB dei Fondi di Ricerca (migrazione automatica)";
			string query = "SELECT yvar="+esercVariazione
				+ ", nvar="+numVariazione
				+ ", idfin=idbilancio, idupb="
				+ QueryCreator.quotedstrvalue(idUpb, true)
				+ ", amount=SUM(importo"+eos+".importocorrente), ct=" + QueryCreator.quotedstrvalue(DateTime.Now, true)
				+ ", cu='SA', description=" 
				+ QueryCreator.quotedstrvalue(descrizione, true)
				+ ", lt=" + QueryCreator.quotedstrvalue(DateTime.Now, true)
				+ ", lu='''SA''' "
				+ "FROM "+eos+" "
				+ "JOIN imputazione"+eos+" "
				+ "ON "+eos+".id"+eos+" = imputazione"+eos+".id"+eos+" "
				+ "JOIN importo"+eos+" "
				+ "ON importo"+eos+".id"+eos+" = imputazione"+eos+".id"+eos+" "
				+ "AND importo"+eos+".esercizio = imputazione"+eos+".esercizio"
				+ " WHERE imputazione"+eos+".esercizio = "+esercVariazione
				+ " AND "+eos+".codicefondo="+QueryCreator.quotedstrvalue(codiceFondo, true)
				+ " AND "+eos+".codiceripartizione="+QueryCreator.quotedstrvalue(codiceRipartizione, true);

			if (previsionKind == "C") {
				query += " AND "+eos+".codicefase = " 
					+ QueryCreator.quotedstrvalue(codFaseImpegno, true)
					+ " AND imputazione"+eos+".flagcompetenza = 'C'"
					+ " group by imputazione"+eos+".idbilancio";
			}

			if (previsionKind == "S") {
				query += " AND "+eos+".codicefase = " 
					+ QueryCreator.quotedstrvalue(maxFase, true)
					+ " group by imputazione"+eos+".idbilancio";
			}
			
			string fEsisteVar = "(yvar = '" + esercVariazione + "')";
			if (previsionKind == "C") {
				fEsisteVar += " AND (flagprevision = 'S') AND (flagsecondaryprev = 'N')";
			}
			else {
				fEsisteVar += " AND (flagprevision = 'N') AND (flagsecondaryprev = 'S')";
			}

			DataTable tPrevisione = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tPrevisione==null) return false;
            if (tPrevisione.Rows.Count == 0) return true;

			DataRow rFinVar;
			if (ds.finvar.Select(fEsisteVar).Length > 0) {
				rFinVar = ds.finvar.Select(fEsisteVar)[0];
				numVariazione = CfgFn.GetNoNullInt32(rFinVar["nvar"]);
			}
			else {
                DateTime aDate = new DateTime(esercVariazione, 1, 1);
				rFinVar = ds.finvar.NewRow();
				rFinVar["yvar"] = esercVariazione;
				rFinVar["nvar"] = numVariazione;
				rFinVar["description"] = descrizione;
                rFinVar["adate"] = aDate;
				rFinVar["flagcredit"] = "N";
				rFinVar["flagprevision"] = isPrincipale ? "S" : "N";
				rFinVar["flagproceeds"] = "N";
				rFinVar["flagsecondaryprev"] = isPrincipale ? "N" : "S";
				rFinVar["variationkind"] = "S";
				rFinVar["ct"] = DateTime.Now;
				rFinVar["cu"] = "SA";
				rFinVar["lt"] = DateTime.Now;
				rFinVar["lu"] = "'SA'";
				ds.finvar.Rows.Add(rFinVar);
			}

			DataTable tFinVarDetail = ds.Tables["finvardetail"];
			
			foreach (DataRow r in tPrevisione.Select()) {
				//DataRow rFinVarDetail = tFinVarDetail.NewRow();
				DataRow rFinVarDetailMainUpb;
				string fMain = "(yvar = '" + esercVariazione + "') AND (nvar = '" + numVariazione
					+ "') AND (idfin = " + QueryCreator.quotedstrvalue(r["idfin"], false)
					+ ") AND (idupb = '0001')";
				DataRow [] DETAILMAIN = tFinVarDetail.Select(fMain);
				if (DETAILMAIN.Length > 0) {
					rFinVarDetailMainUpb = DETAILMAIN[0];
					rFinVarDetailMainUpb["amount"] = CfgFn.GetNoNullDecimal(rFinVarDetailMainUpb["amount"]) -
						CfgFn.GetNoNullDecimal(r["amount"]);
				}
				else {
					rFinVarDetailMainUpb = tFinVarDetail.NewRow();

					rFinVarDetailMainUpb["yvar"] = esercVariazione;
					rFinVarDetailMainUpb["nvar"] = numVariazione;
					rFinVarDetailMainUpb["idupb"] = "0001";
					rFinVarDetailMainUpb["idfin"] = r["idfin"];
					rFinVarDetailMainUpb["description"] = "Storno per F.d.R.";
					rFinVarDetailMainUpb["amount"] = - CfgFn.GetNoNullDecimal(r["amount"]);
					rFinVarDetailMainUpb["cu"] = "Software and More";
					rFinVarDetailMainUpb["ct"] = DateTime.Now;
					rFinVarDetailMainUpb["lu"] = "'Software and More'";
					rFinVarDetailMainUpb["lt"] = DateTime.Now;
					
					tFinVarDetail.Rows.Add(rFinVarDetailMainUpb);
				}

				DataRow rFinVarDetail;
				string f = "(yvar = '" + esercVariazione + "') AND (nvar = '" + numVariazione
					+ "') AND (idfin = " + QueryCreator.quotedstrvalue(r["idfin"], false)
					+ ") AND (idupb = " + QueryCreator.quotedstrvalue(r["idupb"], false) + ")";
				DataRow [] DETAIL = tFinVarDetail.Select(f);
				if (DETAIL.Length > 0) {
					rFinVarDetail = DETAIL[0];
					rFinVarDetail["amount"] = CfgFn.GetNoNullDecimal(rFinVarDetail["amount"]) +
						CfgFn.GetNoNullDecimal(r["amount"]);
				}
				else {
					rFinVarDetail = tFinVarDetail.NewRow();

					rFinVarDetail["yvar"] = esercVariazione;
					rFinVarDetail["nvar"] = numVariazione;
					rFinVarDetail["idupb"] = r["idupb"];
					rFinVarDetail["idfin"] = r["idfin"];
					rFinVarDetail["description"] = "Storno per F.d.R.";
					rFinVarDetail["amount"] = CfgFn.GetNoNullDecimal(r["amount"]);
					rFinVarDetail["cu"] = "Software and More";
					rFinVarDetail["ct"] = DateTime.Now;
					rFinVarDetail["lu"] = "'Software and More'";
					rFinVarDetail["lt"] = DateTime.Now;

					tFinVarDetail.Rows.Add(rFinVarDetail);
				}
			}
			return true;
		}


		/// <summary>
		/// Copia le previsioni iniziali dalla tabella "bilancio" alla tabella "finyear"
		/// ponendo sempre idupb=0001 (upb libero)
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraBilancioinFinYear(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tUpbLookup) {
			string q = "select idfin=idbilancio, idupb='0001', prevision=preveserciziocorr, "
				+ "secondaryprev=prevseceserciziocorr, previousprevision=prevesercizioprec, "
				+ "previoussecondaryprev=prevsecesercizioprec, currentarrears=ripartizionecorr, "
				+ "previousarrears=ripartizioneprec, "
				+ "ct=bilancio.createtimestamp, cu=bilancio.createuser, "
				+ "lt=bilancio.lastmodtimestamp, lu=bilancio.lastmoduser, ayear=bilancio.esercizio "
				+ "FROM bilancio join livellobilancio " 
				+ "ON bilancio.codicelivello = livellobilancio.codicelivello "
				+ "AND bilancio.esercizio = livellobilancio.esercizio "
				+ "WHERE livellobilancio.flagoperativo = 'S'";
			DataTable t = Migrazione.eseguiQuery(sourceConn, q, form);
			if (t==null) return false;
			t.TableName = "finyear";
			foreach (DataRow r in t.Rows) {
				r["idupb"] = getIdupbFromFinAndCen(r["idfin"], DBNull.Value, tUpbLookup, null);
			}
			Migrazione.lanciaScript(form, destConn, t, "bilancio -> finyear");
			return true;
		}

		public static bool migraBilancioInFin(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tColName) {
			DataTable tFin = Migrazione.leggiETraduciTabella("bilancio", sourceConn, tColName, form);
			if (tFin==null) return false;
			tFin.TableName = "fin";
			return Migrazione.lanciaScript(form, destConn, tFin, "bilancio -> fin");
		}

/// <summary>
/// Copia variazionebilancio, variazionecrediti e variazionecassa in finvar
/// e copia dettvarbilancio, dettvarcrediti e dettvarcassa in finvardetail.
/// Elimino eventuali duplicati in finvardetail andando a settare opportunamente
/// flagprevision, flagsecondaryprev, flagcredit e flagproceeds
/// </summary>
/// <param name="form"></param>
/// <param name="sourceConn"></param>
/// <param name="destConn"></param>
		public static bool migraVariazioni(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tUpblookup) {
			int VARBILANCIO=0, VARBILPRIM=1, VARBILSEC=2, VARCREDITI=3, VARCASSA=4;
			//Mi calcolo il minimo ed il massimo esercvariazione usati in 
			//variazionebilancio, variazionecrediti e variazionecassa
			short min = short.MaxValue;
			short max = short.MinValue;
			foreach (string s in new string[] {"bilancio","cassa","crediti"}) {
				string qMinMax = "select min(esercvariazione), max(esercvariazione) from variazione"+s;
				DataTable t = Migrazione.eseguiQuery(sourceConn, qMinMax, form);
				if (t==null) return false;
				if (t.Rows[0][0] != DBNull.Value) {
					short m = (short) t.Rows[0][0];
					if (m < min) {
						min = m;
					}
				}
				if (t.Rows[0][1] != DBNull.Value) {
					short M = (short) t.Rows[0][1];
					if (M > max) {
						max = M;
					}
				}
			}
			//Scorro sugli esercvariazione
			for (short esercVariazione=min; esercVariazione<=max; esercVariazione++) {
				string queryV = "select yvar=esercvariazione, nvar=numvariazione, "
					+ "description=descrizione, enactment=provvedimento, "
					+ "variationkind=tipovariazione, nenactment=numprovved, "
					+ "enactmentdate=dataprovved, adate=datacontabile, txt=notes, "
					+ "rtf=olenotes, cu=createuser, ct=createtimestamp, "
					+ "lu=lastmoduser, lt=lastmodtimestamp, ";

				string queryVar = queryV
					+ "tipo=case tipoprevisione when 'P' then "
					+ VARBILPRIM+" else "
					+ VARBILSEC+" end, "
					+ "flagprevision=case tipoprevisione when 'P' then 'S' else 'N' end,"
					+ "flagcredit='N', flagproceeds='N', "
					+ "flagsecondaryprev=case tipoprevisione when 'P' then 'N' else 'S' end "
					+ "from variazionebilancio where esercvariazione="+esercVariazione
					+ " union all "
					+ queryV
					+ "tipo="
					+ VARCREDITI
					+ ", flagprevision='N', flagcredit='S', flagproceeds='N', flagsecondaryprev='N' "
					+ "from variazionecrediti where esercvariazione="+esercVariazione
					+ " union all "
					+ queryV
					+ "tipo="
					+ VARCASSA
					+ ", flagprevision='N', flagcredit='N', flagproceeds='S', flagsecondaryprev='N' "
					+ "from variazionecassa where esercvariazione="+esercVariazione;
				//Copio variazionebilancio, variazionecrediti e variazionecassa in tFinVar
				DataTable tFinVar = Migrazione.eseguiQuery(sourceConn, queryVar, form);
				if (tFinVar==null) return false;

				string queryD = "select idupb='0001', yvar=esercvariazione, "
					+ "nvar=numvariazione, idfin=idbilancio, description=descrizione, "
					+ "amount=importo, cu=createuser, ct=createtimestamp, "
					+ "lu=lastmoduser, lt=lastmodtimestamp, tipo=";
				string queryDett = queryD
					+ VARBILANCIO
					+ " from dettvarbilancio where esercvariazione="+esercVariazione
					+ " union all "
					+ queryD
					+ VARCREDITI
					+ " from dettvarcrediti where esercvariazione="+esercVariazione
					+ " union all "
					+ queryD
					+ VARCASSA
					+ " from dettvarcassa where esercvariazione="+esercVariazione;
				//Copio dettvarbilancio, dettvarcrediti, dettvarcassa in tFinVarDetail
				DataTable tFinVarDetail = Migrazione.eseguiQuery(sourceConn, queryDett, form);
				if (tFinVarDetail==null) return false;

				tFinVar.Columns.Add("stringa", typeof(string));
				//Aggiungo una colonna stringa che mette in fin
				foreach (DataRow rVar in tFinVar.Rows) {
					string filtro = "nvar=" + rVar["nvar"] + " and tipo=";
					int tipo = CfgFn.GetNoNullInt32( rVar["tipo"]);
					if ((tipo == VARBILPRIM)||(tipo == VARBILSEC)) {
						filtro += VARBILANCIO;
					} else {
						filtro += rVar["tipo"];
					}
					DataRow[] rDett = tFinVarDetail.Select(filtro, "idfin");
					string stringa = "";
					foreach (DataRow r in rDett) {
						stringa += r["idfin"]+"."+r["amount"]+";";
					}
					rVar["stringa"] = stringa;
				}

				int[] tipoVar = {VARBILPRIM, VARBILSEC, VARCASSA, VARCREDITI};
				int[] tipoDett = {VARBILANCIO, VARBILANCIO, VARCASSA, VARCREDITI};
                string[] flag = { "flagprevision", "flagsecondaryprev", "flagproceeds", "flagcredit" };

				for (int i=0; i<tipoVar.Length-1; i++) {
					DataRow[] rTipo1 = tFinVar.Select("tipo="+tipoVar[i]);
					foreach (DataRow r1 in rTipo1) {
						for (int j=i+1; j<tipoVar.Length; j++) {
							string filtroVar = "tipo=" + tipoVar[j] + " and stringa='" + r1["stringa"] + "'";
							DataRow[] rTipo2 = tFinVar.Select(filtroVar);
							if (rTipo2.Length > 0) {
								string filtroDett = "tipo=" + tipoDett[j] + " and nvar=" + rTipo2[0]["nvar"];
								DataRow[] rDett = tFinVarDetail.Select(filtroDett);
								foreach (DataRow r in rDett) {
									tFinVarDetail.Rows.Remove(r);
								}
								tFinVar.Rows.Remove(rTipo2[0]);
								r1[flag[j]] = "S";
							}
						}
					}
				}
				string filtroVarBil = "tipo in ("+VARBILPRIM+","+VARBILSEC+")";
				int primaVarNonBil = 1 + CfgFn.GetNoNullInt32(tFinVar.Compute("max(nvar)", filtroVarBil));
                
				DataRow[] superstiti = tFinVar.Select("not "+filtroVarBil);
                for(int i = 0;i < superstiti.Length;i++) {
                    string filtroDett = "tipo=" + superstiti[i]["tipo"] + " and nvar=" + superstiti[i]["nvar"];
                    DataRow[] rDett = tFinVarDetail.Select(filtroDett);
                    superstiti[i]["nvar"] = i + 190000;
                    foreach(DataRow r in rDett) {
                        r["nvar"] = i + 190000;
                    }
                }

				for (int i=0; i<superstiti.Length; i++) {
					string filtroDett = "tipo=" + superstiti[i]["tipo"] + " and nvar=" + superstiti[i]["nvar"];
					DataRow[] rDett = tFinVarDetail.Select(filtroDett);
					superstiti[i]["nvar"] = i + primaVarNonBil;
					foreach (DataRow r in rDett) {
						r["nvar"] = i + primaVarNonBil;
					}
				}
				DataSet ds = new DataSet();
				tFinVar.Columns.Remove("tipo");
				tFinVar.Columns.Remove("stringa");
				tFinVar.TableName = "finvar";
				ds.Tables.Add(tFinVar);

				tFinVarDetail.Columns.Remove("tipo");
				tFinVarDetail.TableName = "finvardetail";
				ds.Tables.Add(tFinVarDetail);

//				if (tUpblookup!=null) {
//					foreach (DataRow r in tFinVarDetail.Rows) {
//						r["idupb"] = getIdupbFromIdcen(r["idfin"], r["idcen"], tUpblookup);
//					}
//				}

				bool res=Migrazione.lanciaScript(form, destConn, ds, "variazioni ("+esercVariazione+") -> finvar e finvardetail");
				if (!res) return false;
			}
			return true;
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="eos"></param>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tCdsUpb"></param>
		public static bool migraAssCentroEOS(string eos, Form form, DataAccess sourceConn, DataAccess destConn, DataTable tCdsUpb, DataTable tUpbLookup) {
			VistaUpb ds = new VistaUpb();
			string q1 = "select yvar, maxnvar=max(nvar) from finvar group by yvar";
			DataTable tContaFinVar = Migrazione.eseguiQuery(destConn, q1, form);
			if (tContaFinVar==null) return false;

			string[] discriminante = null;
			string query = "";

			if (eos == "entrata") {
				discriminante = new string[] {"yvar"};
				query = "select yvar=esercassegnazione, idcen=idcentrospesa, "
					+ "idfin=idbilancio, amount=sum(importo), "
					+ "flagprevision='S', flagcredit='N', flagproceeds='N' "
					+ "from asscentroentrata "
					+ "group by esercassegnazione, idcentrospesa, idbilancio";
			}
			else {
				discriminante = new string[] {"yvar", "flagprevision", "flagcredit", "flagproceeds"};
				query = "select yvar=esercassegnazione, idcen=idcentrospesa, "
					+ "idfin=idbilancio, amount=sum(importo), "
					+ "flagprevision=flagprevisione, flagcredit=flagcrediti, flagproceeds=flagincassi "
					+ "from asscentrospesa "
					+ "group by esercassegnazione, idcentrospesa, idbilancio, flagprevisione, flagcrediti, flagincassi";
			}

			DataTable tApp = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tApp == null) return false;

			tApp.Columns.Add("nvar", typeof(int));

			foreach (DataRow r in tApp.Rows) {
				string filtro = QueryCreator.WHERE_COLNAME_CLAUSE(r, discriminante, DataRowVersion.Current, false);
				DataRow[] righeFinVar = ds.finvar.Select(filtro);
				if (righeFinVar.Length == 0) {
					short anno = (short) r["yvar"];
					DataRow rFinVar = ds.finvar.NewRow();
                    rFinVar["adate"] = new DateTime(anno, 1, 1);
					rFinVar["ct"] = DateTime.Now;
					rFinVar["cu"] = "SA";
					string descrizione = "Assegnazione ai centri di "+eos+" (anno="+r["yvar"];
					if (eos=="spesa") {
						descrizione += "; previsione="+r["flagprevision"]+"; crediti="+r["flagcredit"]+"; incassi="+r["flagproceeds"];
					}
					rFinVar["description"] = descrizione+")";
					rFinVar["flagcredit"] = r["flagcredit"];
					rFinVar["flagprevision"] = r["flagprevision"];
					rFinVar["flagproceeds"] = r["flagproceeds"];
					rFinVar["flagsecondaryprev"] = "N";
					rFinVar["lt"] = DateTime.Now;
					rFinVar["lu"] = "'SA'";
					rFinVar["nvar"] = getNVarForYVar(anno, ds.finvar, tContaFinVar);
					rFinVar["variationkind"] = "S";
					rFinVar["yvar"] = r["yvar"];
					ds.finvar.Rows.Add(rFinVar);
					r["nvar"] = rFinVar["nvar"];
				} else {
					r["nvar"] = righeFinVar[0]["nvar"];
				}
			}

			foreach (DataRow r1 in tApp.Select()) {
				object idUpb = getIdupbFromFinAndCen(r1["idfin"], r1["idcen"], tUpbLookup, tCdsUpb);
				if (idUpb.ToString() == "0001") {
					MessageBox.Show(form, "Impossibile tradurre una riga di assegnazione al centro di "
						+ eos + "; idcentrospesa="+QueryCreator.quotedstrvalue(r1["idcen"], false), "Errore nella tabella asscentro"+eos);
					continue;
					//r1.Delete();
				}
				else {
					string filtro1 = QueryCreator.WHERE_COLNAME_CLAUSE(r1, new string[] {"idfin","nvar","yvar"}, DataRowVersion.Current, false)
						+ " and (idupb="+QueryCreator.quotedstrvalue(idUpb, false)+")";
					DataRow[] righeFVD1 = ds.finvardetail.Select(filtro1);
					if (righeFVD1.Length > 0) {
						righeFVD1[0]["amount"] = CfgFn.GetNoNullDecimal(righeFVD1[0]["amount"])
							+ CfgFn.GetNoNullDecimal(r1["amount"]);
					} else {
						DataRow rFinVarDetail = ds.finvardetail.NewRow();
						foreach(DataColumn cApp in tApp.Columns) {
							if (ds.finvardetail.Columns.Contains(cApp.ColumnName)) {
								rFinVarDetail[cApp.ColumnName] = r1[cApp.ColumnName];
							}
						}

						rFinVarDetail["idupb"] = idUpb;
						rFinVarDetail["ct"] = DateTime.Now;
						rFinVarDetail["lt"] = DateTime.Now;
						rFinVarDetail["cu"] = "Software and More";
						rFinVarDetail["lu"] = "'Software and More'";
						rFinVarDetail["description"] = "Cds="+r1["idcen"]
							+"; Storno Upb da 0001 a "+idUpb + " (migrazione automatica)";

						ds.finvardetail.Rows.Add(rFinVarDetail);
					}

					string filtro2 = QueryCreator.WHERE_COLNAME_CLAUSE(r1, new string[] {"idfin","nvar","yvar"}, DataRowVersion.Current, false)
						+ " and (idupb='0001')";
					DataRow[] righeFVD2 = ds.finvardetail.Select(filtro2);
					if (righeFVD2.Length > 0) {
						righeFVD2[0]["amount"] = CfgFn.GetNoNullDecimal(righeFVD2[0]["amount"])
							- CfgFn.GetNoNullDecimal(r1["amount"]);
					} else {
						DataRow r2 = ds.finvardetail.NewRow();
						foreach (DataColumn c in ds.finvardetail.Columns) {
							switch (c.ColumnName) {
								case "amount": r2["amount"] = - Convert.ToDecimal(r1["amount"]);
									break;
								case "idupb": r2["idupb"] = "0001";
									break;
								case "ct": 
									r2["ct"] = DateTime.Now;
									break;
								case "lt":
									r2["lt"] = DateTime.Now;
									break;
								case "cu":
									r2["cu"] = "Software and More";
									break;
								case "lu":
									r2["lu"] = "'Software and More'";
									break;
                                case "description":
                                    r2["description"] = "Storno da Upb Dipartimento a upb per C.d.S.";
                                    break;
								default: {
									if (r1.Table.Columns.Contains(c.ColumnName)) {
										r2[c] = r1[c.ColumnName];
									}
									break;
								}
							}
						}
						ds.finvardetail.Rows.Add(r2);
					}

					if (righeFVD1.Length > 0) {
						r1.Delete();
					}
				}
			}
			ds.finvardetail.AcceptChanges();
			return Migrazione.lanciaScript(form, destConn, ds, "asscentro"+eos+" -> finvar e finvardetail");
		}

			
		/// <summary>
		/// Copia autoclassentrata in autoincomesorting o autoclassspesa in autoexpensesorting
		/// trasforma il centro di spesa in upb 
		/// </summary>
		/// <param name="eos"></param>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tCdsUpb"></param>
		public static bool migraAutoClassEOS(string eos, Form form, DataAccess sourceConn, DataAccess destConn, 
			DataTable tCdsUpb, DataTable tUpbLookup) {
			string query = "select ayear=esercizio, ct=createtimestamp, cu=createuser, "
				+ "defaultn1, defaultn2, defaultn3, defaultn4, defaultn5, "
				+ "defaults1, defaults2, defaults3, defaults4, defaults5, "
				+ "defaultv1, defaultv2, defaultv3, defaultv4, defaultv5, "
				+ "denominator=denominatore, flagnodate=flagignoradate, idautosort=idautoclass, "
				+ "idcen=idcentrospesa, idfin=idbilancio, idman=codiceresponsabile, "
				+ "idsor=idclass, idsorkind=codicetipoclass, idsorkindreg=codicetipoclasscreddeb, "
				+ "idsorreg=idclasscreddeb,  lt=lastmodtimestamp, lu=lastmoduser, numerator=numeratore "
				+ "from autoclass"+eos;

			DataTable tAutoEOSSorting = Migrazione.eseguiQuery(sourceConn, query, form);			
			if (tAutoEOSSorting==null) return false;
			tAutoEOSSorting.Columns.Add("idupb",typeof(string));

			foreach (DataRow r in tAutoEOSSorting.Rows) {
				r["idupb"] = getIdupbFromFinAndCen(r["idfin"], r["idcen"], tUpbLookup, tCdsUpb);
//				DataRow[] rCdsUpb = tCdsUpb.Select("idcen="	+ QueryCreator.quotedstrvalue(r["idcen"], false));
//				if (rCdsUpb.Length > 0) {
//					r["idupb"] = rCdsUpb[0]["idupb"];
//				}
			}

			string nuovoNome = eos == "spese" ? "expense" : "income";
			tAutoEOSSorting.TableName = "auto"+nuovoNome+"sorting";
			DataSet ds = new DataSet();
			ds.Tables.Add(tAutoEOSSorting);

			return Migrazione.lanciaScript(form, destConn, ds, "autoclass"+eos+" -> "+tAutoEOSSorting.TableName);
		}


		private static object getIdupbFromFinAndCen(object idFin, object idCen, DataTable tUpbLookup, DataTable tCdsUpb) {
			if (tUpbLookup != null) {
				string filteridcen;
				bool IdCenNotNull=false;
				if ((idCen==DBNull.Value)||(idCen==null)||(idCen.ToString()=="")){
					filteridcen="(idcen is null)";
				}
				else  {
					filteridcen="(idcen="+QueryCreator.quotedstrvalue(idCen, false)+")";
					IdCenNotNull=true;
				}


				DataRow[] rupb2 = tUpbLookup.Select(filteridcen+
										" and ("
										+ QueryCreator.quotedstrvalue(idFin, false)
											+ " like idfin+'%')");
				if (rupb2.Length > 0) {
					return rupb2[0]["idupb"];
				}
				DataRow[] rupb1 = tUpbLookup.Select(filteridcen);
				if (rupb1.Length > 0 && IdCenNotNull) {
					return rupb1[0]["idupb"];
				}

				DataRow[] rupb3 = tUpbLookup.Select("("+QueryCreator.quotedstrvalue(idFin, false)
											+ " like idfin+'%')");
				if (rupb3.Length > 0) {
					return rupb3[0]["idupb"];
				}
				if (IdCenNotNull){
					MessageBox.Show("E' stato azzerato l'upb di un mov. con centro di spesa di id "+idCen.ToString()+
						" e idbilancio "+idFin.ToString());
				}

				return "0001";

			}

			if (idCen is string && idCen.ToString()!="") {
				DataRow[] rCdsUpb = tCdsUpb.Select("idcen="+QueryCreator.quotedstrvalue(((string)idCen).Remove(0,2), false));
				if (rCdsUpb.Length > 0) {
					return rCdsUpb[0]["idupb"];
				}
				else  {
					MessageBox.Show("E' stato azzerato l'upb di un mov. con centro di spesa di id "+idCen.ToString());
					return "0001";
				}
			}
			return "0001";
		}

		/// <summary>
		/// Copia filtraclassentrata in sortingincomefilter o filtraclassspesa in sortingexpensefilter
		/// trasformando il centro di spesa in upb
		/// </summary>
		/// <param name="eos"></param>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tCdsUpb"></param>
		public static bool migraFiltraClassEOS(string eos, Form form, DataAccess sourceConn, DataAccess destConn, DataTable tCdsUpb, DataTable tUpbLookup) {
			string query = "select ayear=esercizio, ct=createtimestamp, cu=createuser, "
				+ "idautosort=idautoclass, idcen=idcentrospesa, idfin=idbilancio, "
				+ "idman=codiceresponsabile, idsor=idclass, idsorkind=codicetipoclass, "
				+ "idsorkindreg=codicetipoclasscreddeb, idsorreg=idclasscreddeb, "
				+ "jointolessspecifics=flagunisciamenospecifici, "
				+ "lt=lastmodtimestamp, lu=lastmoduser "
				+ "from filtraclass"+eos;

			DataTable tSortingEOSFilter = Migrazione.eseguiQuery(sourceConn, query, form);
			if (tSortingEOSFilter==null) return false;
			tSortingEOSFilter.Columns.Add("idupb",typeof(string));

			foreach (DataRow r in tSortingEOSFilter.Rows) {
				r["idupb"] = getIdupbFromFinAndCen(r["idfin"], r["idcen"], tUpbLookup, tCdsUpb);
			}

			string nuovoNome = eos == "spese" ? "expense" : "income";
			tSortingEOSFilter.TableName = "sorting"+nuovoNome+"filter";
			DataSet ds = new DataSet();
			ds.Tables.Add(tSortingEOSFilter);

			return Migrazione.lanciaScript(form, destConn, ds, "filtraclass"+eos+" -> "+tSortingEOSFilter.TableName);
		}



		public static bool esportaTipoClassMovimentiApplicabile(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tTableName) {
			string q = "select idsorkind=codicetipoclass, ct=createtimestamp, cu=createuser, "
				+ "lt=lastmodtimestamp, lu=lastmoduser, tablename=nometabella "
				+ "from tipoclassmovimentiapplicabile";
			DataTable tSortingApplicability = Migrazione.eseguiQuery(sourceConn, q, form);
			if (tSortingApplicability==null) return false;
			tSortingApplicability.Columns.Add("colonnatemp",typeof(int));

//			DataTable tTableName = sourceConn.RUN_SELECT("tablename", null, null, null, null, true);

			foreach (DataRow r in tSortingApplicability.Select()) {
				string nomeTabella = (string) r["tablename"];
				if ((nomeTabella=="centrospesa")||(nomeTabella=="fondoricerca")||(nomeTabella=="ripfondiricerca")) {
					r["tablename"] = "upb";
					string filtro = QueryCreator.WHERE_COLNAME_CLAUSE(r,
						new string[] {"tablename", "idsorkind"}, DataRowVersion.Current, false)
						+ " and (colonnatemp is not null)";
					DataRow[] rUguali = tSortingApplicability.Select(filtro);
					foreach (DataRow rU in rUguali) {
						rU.Delete();
						rU.AcceptChanges();
					}
				} else {
					DataRow[] rTN = tTableName.Select("oldtable=" + QueryCreator.quotedstrvalue(nomeTabella, false));
					if (rTN.Length > 0) {
						r["tablename"] = rTN[0]["newtable"];
					} else {
						MessageBox.Show(form, "In tabelleclassificabili esiste il seguente nome di tabella non traducibile:\n"+r["tablename"]);
						return false;
					}
				}
				r["colonnatemp"] = 1;
			}
			tSortingApplicability.Columns.Remove("colonnatemp");
			tSortingApplicability.TableName = "sortingapplicability";
			DataSet ds = new DataSet();
			ds.Tables.Add(tSortingApplicability);

			return Migrazione.lanciaScript(form, destConn, ds, "tabelleclassificabili -> sortingapplicability");
		}

		public static bool troncaNLivelliDiBilancio(Form form, DataAccess destConn, int NUMLIVELLIDACANCELLARE) {
			int esercizio = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("fin", null, "max(ayear)"));
			string es100 = esercizio.ToString().Remove(0,2);

			string query = "delete fin where ayear ="+esercizio
				+ " and idfin not like '"+es100
				+ "e000100010%' and idfin not like '"+es100
				+ "s000100010%'";
			if (destConn.SQLRunner(query,false,3600) == null) {
				MessageBox.Show(form, destConn.LastError);
				return false;
			}

			query = "delete finsorting where idfin like '"+es100+"%'"
				+ " and idfin not like '"+es100
				+ "e000100010%' and idfin not like '"+es100
				+ "s000100010%'";
			if (destConn.SQLRunner(query,false,3600) == null) {
				MessageBox.Show(form, destConn.LastError);
				return false;
			}

			query = "delete finyear where idfin like '"+es100+"%'"	
				+ " and idfin not like '"+es100
				+ "e000100010%' and idfin not like '"+es100
				+ "s000100010%'";
			if (destConn.SQLRunner(query,false,3600) == null) {
				MessageBox.Show(form, destConn.LastError);
				return false;
			}
			
			DataTable tFinLevel = DataAccess.RUN_SELECT(destConn, "finlevel", null, "nlevel", 
				"ayear="+esercizio, null, null, false);
			int posCodeFin = 1;
			for (int i=0; i<NUMLIVELLIDACANCELLARE; i++) {
				posCodeFin += (short) tFinLevel.Rows[i]["codelen"];
			}
			int posIdFin =  4*(1+NUMLIVELLIDACANCELLARE);
			query = "update fin set "
				+ "idfin=left(idfin,3)+substring(idfin,"+posIdFin+",100), "
				+ "nlevel=nlevel-"+NUMLIVELLIDACANCELLARE+", "
				+ "paridfin=left(paridfin,3)+substring(paridfin,"+posIdFin+",100), "
				+ "codefin=substring(fin.codefin,"+posCodeFin+",100), "
				+ "printingorder=substring(fin.printingorder,"+posCodeFin+",100) "
				+ "where ayear ="+esercizio 
				+ " and nlevel>"+NUMLIVELLIDACANCELLARE;
			string errMsg;
			if (destConn.SQLRunner(query, 3600, out errMsg) == null) {
				MessageBox.Show(form, errMsg);
				return false;
			}

			query = "delete finlevel where ayear="+esercizio+" and nlevel<="+NUMLIVELLIDACANCELLARE;
			if (destConn.SQLRunner(query, 3600, out errMsg) == null) {
				MessageBox.Show(form, errMsg);
				return false;
			}

			query = "update finlevel set nlevel=nlevel-"+NUMLIVELLIDACANCELLARE+" where ayear="+esercizio;
			if (destConn.SQLRunner(query, 3600, out errMsg) == null) {
				MessageBox.Show(form, errMsg);
				return false;
			}

			string[,] campi = {{
				"finyear","idfin"}, {
				"finvardetail","idfin"}, {
				"finsorted","idfin"}, {
				"autoincomesorting","idfin"}, { 
				"autoexpensesorting","idfin"}, {
				"pettycashoperation","idfin"}, {
				"sortingincomefilter","idfin"}, {
				"sortingexpensefilter","idfin"}, {
				"incomeyear","idfin"}, {
				"expenseyear","idfin"}, {
				"creditpart","idfin"}, {
				"proceedspart","idfin"}, {
				"finbalancedetail","idfin"}, {
				"prevfindetail","idfin"}, {
				"proceeds","idfin"}, {
				"payment","idfin"}, {
				"finsorting","idfin"}, {
				"invoicesetup","idfinivapayment"}, {
				"invoicesetup","idfinivarefund"}, {
				"itinerationsetup","idfinexpense"}, {
				"taxsetup","idfinadmintax"}, {
				"taxsetup","idfinexpensecontra"}, {
				"taxsetup","idfinincomecontra"}, {
				"partincomesetup","idfinexpense"}, {
				"partincomesetup","idfinincome"}, {
				"pettycashsetup","idfinexpense"}, {
				"pettycashsetup","idfinincome"}};
			

			for (int i=0; i<campi.GetLength(0); i++) {
				query = "update "+campi[i,0]+" set "
					+ campi[i,1]+"=left("+campi[i,1]+",3)+substring("+campi[i,1]+","+posIdFin+",100) "
					+ "where left("+campi[i,1]+",2)='"+es100+"'";
				if (destConn.SQLRunner(query, 3600, out errMsg) == null) {
					MessageBox.Show(form, errMsg);
					return false;
				}
			}
			return true;
		}


		public static bool EffettuaControlli(Form form, DataAccess SourceConn){
            int TIMEOUT = 600;
			string query = "select * from bilancio B where "+
				"not exists (select * from bilancio BB where B.livsupidbilancio= BB.idbilancio)"+
				"and B.codicelivello>1";
			int NFinNoParent=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NFinNoParent>0) {
				MessageBox.Show("Ci sono voci di bilancio senza voce genitore ");
				return false;
			}
			query = "select * from imputazionespesa S where "+
				"not exists (select * from bilancio B where B.idbilancio= S.idbilancio)"+
				"and S.idbilancio is not null";
			int NExpNoFin= CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NExpNoFin>0) {
				if(MessageBox.Show(form,"Ci sono movimenti di spesa con capitoli inesistenti. Proseguo comunque? ","Avviso",
						MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}
			query = "select * from imputazionespesa S where "+
				"not exists (select * from centrospesa C where C.idcentrospesa= S.idcentrospesa)"+
				"and S.idcentrospesa is not null";
			int NExpNoCen= CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NExpNoCen>0) {
				if (MessageBox.Show("Ci sono movimenti di spesa con centrospesa inesistente. Proseguo comunque? ","Avviso",
						MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}

			query = "select * from spesa S where "+
				"not exists (select * from ripfondiricerca R where R.codicefondo= S.codicefondo and R.codiceripartizione=S.codiceripartizione)"+
				"and S.codicefondo is not null and S.codiceripartizione is not null";
			int NExpNoFon= CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NExpNoFon>0) {
				if (MessageBox.Show("Ci sono movimenti di spesa con fondo ricerca inesistente. Proseguo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}



			query = "select * from imputazioneentrata E where "+
				"not exists (select * from bilancio B where B.idbilancio= E.idbilancio)"+
				"and E.idbilancio is not null";
			int NIncNoFin= CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NIncNoFin>0) {
				if (MessageBox.Show("Ci sono movimenti di entrata con capitoli inesistenti. Proseguo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}
			query = "select * from imputazioneentrata E where "+
				"not exists (select * from centrospesa C where C.idcentrospesa= E.idcentrospesa)"+
				"and E.idcentrospesa is not null";
			int NIncNoCen= CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NIncNoCen>0) {
				if(MessageBox.Show("Ci sono movimenti di entrata con centrospesa inesistente. Proseguo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}

			query = "select * from entrata E where "+
				"not exists (select * from ripfondiricerca R where R.codicefondo= E.codicefondo and R.codiceripartizione=E.codiceripartizione)"+
				"and E.codicefondo is not null and E.codiceripartizione is not null";
			int NIncNoFon= CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NIncNoFon>0) {
				if (MessageBox.Show("Ci sono movimenti di entrata con fondo ricerca inesistente. Proseguo comunque? ","Avviso",
					MessageBoxButtons.YesNo)==DialogResult.No)
					return false;
			}

			
			query = "select * from centrospesa C where "+
				"not exists (select * from centrospesa CC where C.livsupidcentrospesa= CC.idcentrospesa)"+
				"and C.codicelivello>1";
			int NCenNoParent=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NCenNoParent>0) {
				MessageBox.Show("Ci sono voci di centrospesa  senza voce genitore ");
				return false;
			}


			query = "select * from ripfondiricerca R where "+
				"not exists (select * from fondoricerca F where F.codicefondo= R.codicefondo)";
			
			int NRipNoFondo=CfgFn.GetNoNullInt32( SourceConn.DO_SYS_CMD(query,true));			
			if (NRipNoFondo>0) {
				MessageBox.Show("Ci sono ripartizioni fondi di fondi non esistenti");
				return false;
			}
            object ayear = SourceConn.DO_READ_VALUE("esercizio", "flagtrasfconfigbilancio = 'S'", "MAX(esercizio)");
            string fromYear = ayear.ToString();
            if (fromYear != "")
            {
                //x MARIA .... METTI QUI LA QUERY
                query = "SELECT COUNT(*) " +
                        "FROM ripfondiricerca RIP " +
                        "JOIN fondoricerca  F " +
                        "ON  F.codicefondo = RIP.codicefondo " +
                        "LEFT OUTER JOIN previsioneripfondi PREV " +
                        "ON PREV.codicefondo = RIP.codicefondo " +
                        "AND PREV.codiceripartizione = RIP.codiceripartizione " +
                        "AND PREV.esercizio = " + fromYear + " " +
                        "WHERE   PREV.idbilancioentrata is  null " +
                        "AND " +
                        "(SELECT COUNT(DISTINCT idbilancio) FROM imputazioneentrata IE " +
                        "JOIN entrata E " +
                        "ON E.codicefondo = RIP.codicefondo AND " +
                        "E.codiceripartizione = RIP.codiceripartizione " +
                        "WHERE IE.identrata = E.identrata " +
                        "AND IE.esercizio   = " + fromYear + " " +  
                        ") >1";

                int NRipNoBil = CfgFn.GetNoNullInt32(SourceConn.DO_SYS_CMD(query, true));
                if (NRipNoBil > 0)
                {
                    if (MessageBox.Show("Ci sono ripartizioni fondi senza capitolo di entrata e più capitoli usati in accertamenti. Proseguo comunque? ", "Avviso",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
                }

                query = "SELECT COUNT(*) " +
                        "FROM ripfondiricerca RIP " +
                        "JOIN fondoricerca  F " +
                        "ON  F.codicefondo = RIP.codicefondo " +
                        "LEFT OUTER JOIN previsioneripfondi PREV " +
                        "ON PREV.codicefondo = RIP.codicefondo " +
                        "AND PREV.codiceripartizione = RIP.codiceripartizione " +
                        "AND PREV.esercizio = " + fromYear + " " + 
                        "WHERE PREV.idbilanciospesa is  null " +
                        "AND " +
                        "(SELECT COUNT(DISTINCT idbilancio) FROM imputazionespesa IMS " +
                        "JOIN spesa S " +
                        "ON S.codicefondo = RIP.codicefondo AND " +
                        "S.codiceripartizione = RIP.codiceripartizione " +
                        "WHERE IMS.idspesa = S.idspesa " +
                        "AND IMS.esercizio   = " + fromYear + " " +
                        ") >1";

                NRipNoBil = CfgFn.GetNoNullInt32(SourceConn.DO_SYS_CMD(query, true));
                if (NRipNoBil > 0)
                {
                    if (MessageBox.Show("Ci sono ripartizioni fondi senza capitolo di spesa e più capitoli usati in impegni. Proseguo comunque? ", "Avviso",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
                }

                query = "SELECT RFR.codicefondo, RFR.codiceripartizione, " 
                    + " ISNULL("
                    + " (SELECT SUM(TF.previsionespese)"
                    + " FROM previsioneripfondi TF"
                    + "	WHERE TF.codicefondo = RFR.codicefondo"
                    + " AND TF.codiceripartizione = RFR.codiceripartizione)"
                    + " ,0) + "
                    + " ISNULL("
                    + " (SELECT SUM(VR.importo)"
                    + " FROM varripfondispese VR"
                    + " WHERE VR.codicefondo = RFR.codicefondo"
                    + " AND VR.codiceripartizione = RFR.codiceripartizione)"
                    + " ,0) -"
                    + " ISNULL("
                    + " (SELECT SUM(TFS.totale)"
                    + " FROM totfondospesa TFS"
                    + " WHERE TFS.codicefondo = RFR.codicefondo"
                    + " AND TFS.codiceripartizione = RFR.codiceripartizione"
                    + " AND TFS.codicefase = "
                    + " (SELECT TOP 1 codfaseimpegno"
                    + " FROM persbilancio"
                    + " WHERE codfaseimpegno IS NOT NULL))"
                    + " ,0) - "
                    + " ISNULL("
                    + " (SELECT SUM(TFSP.importo)"
                    + " FROM totfondospesaprec TFSP"
                    + " WHERE RFR.codicefondo = TFSP.codicefondo"
                    + " AND RFR.codiceripartizione = TFSP.codiceripartizione"
                    + " AND TFSP.codicefase = "
                    + " (SELECT TOP 1 codfaseimpegno"
                    + " FROM persbilancio"
                    + " WHERE codfaseimpegno IS NOT NULL))"
                    + " ,0) as previsione"
                    + " FROM ripfondiricerca RFR"
                    + " WHERE "
                    + " ISNULL("
                    + " (SELECT SUM(TF.previsionespese)"
                    + " FROM previsioneripfondi TF"
                    + " WHERE TF.codicefondo = RFR.codicefondo"
                    + " AND TF.codiceripartizione = RFR.codiceripartizione)"
                    + " ,0) +"
                    + " ISNULL("
                    + " (SELECT SUM(VR.importo)"
                    + " FROM varripfondispese VR"
                    + " WHERE VR.codicefondo = RFR.codicefondo"
                    + " AND VR.codiceripartizione = RFR.codiceripartizione)"
                    + " ,0) -"
                    + " ISNULL("
                    + " (SELECT SUM(TFS.totale)"
                    + " FROM totfondospesa TFS "
                    + " WHERE TFS.codicefondo = RFR.codicefondo"
                    + " AND TFS.codiceripartizione = RFR.codiceripartizione"
                    + " AND TFS.codicefase = "
                    + " (SELECT TOP 1 codfaseimpegno"
                    + " FROM persbilancio"
                    + " WHERE codfaseimpegno IS NOT NULL))"
                    + " ,0)-"
                    + " ISNULL("
                    + " (SELECT SUM(TFSP.importo)"
                    + " FROM totfondospesaprec TFSP"
                    + " WHERE RFR.codicefondo = TFSP.codicefondo"
                    + " AND RFR.codiceripartizione = TFSP.codiceripartizione"
                    + " AND TFSP.codicefase = "
                    + " (SELECT TOP 1 codfaseimpegno"
                    + " FROM persbilancio"
                    + " WHERE codfaseimpegno IS NOT NULL))"
                    + " ,0) < 0"
                    + " GROUP BY RFR.codicefondo, RFR.codiceripartizione";

                //int nFondiSforati = CfgFn.GetNoNullInt32(SourceConn.DO_SYS_CMD(query, true));
                DataTable tFondiSforati = SourceConn.SQLRunner(query, true, TIMEOUT);
                if (tFondiSforati.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(tFondiSforati, "Le seguenti suddivisioni hanno una previsione negativa:", "Si vuole proseguire?").ShowDialog(form);
                    if (dr != DialogResult.Yes) return false;
                }

                int anno = CfgFn.GetNoNullInt32(SourceConn.DO_READ_VALUE("esercizio", "(flagtrasfbilancio = 'S')", "MAX(esercizio)"));
                DialogResult drAss = MessageBox.Show("E' già stato fatto l'assestamento per l'esercizio in corso?", "Domanda", MessageBoxButtons.YesNo);
                if (drAss != DialogResult.Yes) {
                    object tipoPrevPrinc = SourceConn.DO_READ_VALUE("persbilancio", "(esercizio = " + anno + ")", "tipoprevprincipale");
                    if (tipoPrevPrinc == null) {
                        MessageBox.Show("Errore nell'interrogazione di PERSBILANCIO!!!");
                        return false;
                    }
                    string querySuVarResiduiS = "";
                    if (tipoPrevPrinc.ToString().ToUpper() == "C") {
                        querySuVarResiduiS =
                        " ISNULL("
                        + " (SELECT -SUM(VS.importo)"
                        + " FROM variazionespesa VS JOIN spesa MOV"
                        + " ON VS.idspesa = MOV.idspesa"
                        + " JOIN imputazionespesa IMPU"
                        + " ON IMPU.idspesa = MOV.idspesa"
                        + " AND VS.esercvariazione = IMPU.esercizio"
                        + " WHERE VS.esercvariazione = " + fromYear
                        + " AND IMPU.flagcompetenza = 'R'"
                        + " AND MOV.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL)"
                        + " AND IMPU.idbilancio = tab.idbilanciospesa)"
                        + ",0)";
                    }
                    else {
                        querySuVarResiduiS = " 0 ";
                    }
                    // Fai un tipo di query
                    query = "SELECT	bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio,"
                    + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                    + " ISNULL(AVG(TBS.totalecompetenza),0) + "
                    + querySuVarResiduiS
                    + " - SUM(tab.previsione)"
                    + " FROM "
                    + " (SELECT "
                    + " P0.codicefondo, P0.codiceripartizione,"
                    + " ISNULL(P0.idbilanciospesa,"
                    + " (SELECT TOP 1 I.idbilancio"
                    + " FROM spesa S"
                    + " JOIN imputazionespesa I"
                    + " ON S.idspesa = I.idspesa"
                    + " WHERE S.codicefondo = P0.codicefondo"
                    + " AND S.codiceripartizione = P0.codiceripartizione"
                    + " AND I.esercizio = P0.esercizio)) AS idbilanciospesa,"
                    + " ISNULL("
                    + " (SELECT SUM(previsionespese)"
                    + " FROM previsioneripfondi P1"
                    + " WHERE P1.codicefondo = P0.codicefondo"
                    + " AND P1.codiceripartizione = P0.codiceripartizione"
                    + " AND P1.esercizio <= P0.esercizio)"
                    + " ,0) +"
                    + " ISNULL("
                    + " (SELECT SUM(importo)"
                    + " FROM varripfondispese VR"
                    + " WHERE VR.codicefondo = P0.codicefondo"
                    + " AND VR.codiceripartizione = P0.codiceripartizione"
                    + " AND VR.esercizio <= P0.esercizio)"
                    + " ,0) -"
                    + " ISNULL("
                    + " (SELECT SUM(totale)"
                    + " FROM totfondospesa TFS"
                    + " WHERE P0.codicefondo = TFS.codicefondo"
                    + " AND P0.codiceripartizione = TFS.codiceripartizione"
                    + " AND TFS.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL)"
                    + " AND TFS.esercizio <= P0.esercizio)"
                    + " ,0) -"
                    + " ISNULL("
                    + " (SELECT SUM(importo)"
                    + " FROM totfondospesaprec TFSP "
                    + " WHERE P0.codicefondo = TFSP.codicefondo"
                    + " AND P0.codiceripartizione = TFSP.codiceripartizione"
                    + " AND TFSP.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL))"
                    + " ,0) AS previsione"
                    + " FROM previsioneripfondi P0"
                    + " WHERE esercizio = " + anno
                    + " AND (idbilanciospesa IS NOT NULL"
                    + " OR idbilanciospesa IS NULL "
                    + " AND"
                    + " (SELECT COUNT(DISTINCT I.idbilancio)"
                    + " FROM spesa S"
                    + " JOIN imputazionespesa I"
                    + " ON S.idspesa = I.idspesa"
                    + " WHERE S.codicefondo = P0.codicefondo"
                    + " AND S.codiceripartizione = P0.codiceripartizione"
                    + " AND I.esercizio = P0.esercizio) = 1"
                    + " )"
                    + " GROUP BY P0.codicefondo, P0.codiceripartizione, P0.idbilanciospesa, P0.esercizio) AS tab"
                    + " LEFT OUTER JOIN totbilancio TB"
                    + " ON TB.idbilancio = tab.idbilanciospesa"
                    + " LEFT OUTER JOIN totbilanciospesa TBS"
                    + " ON TBS.idbilancio = tab.idbilanciospesa"
                    + " AND TBS.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL)"
                    + " JOIN bilancio"
                    + " ON bilancio.idbilancio = tab.idbilanciospesa"
                    + " GROUP BY tab.idbilanciospesa,"
                    + " bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio"
                    + " HAVING"
                    + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                    + " ISNULL(AVG(TBS.totalecompetenza),0) -"
                    + " SUM(tab.previsione) < 0";
                }
                else {
                    query = "SELECT	bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio,"
                    + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                    + " ISNULL(AVG(TBS.totalecompetenza),0) - "
                    + " SUM(tab.previsione)"
                    + " FROM "
                    + " (SELECT "
                    + " P0.codicefondo, P0.codiceripartizione,"
                    + " ISNULL(P0.idbilanciospesa,"
                    + " (SELECT TOP 1 I.idbilancio"
                    + " FROM spesa S"
                    + " JOIN imputazionespesa I"
                    + " ON S.idspesa = I.idspesa"
                    + " WHERE S.codicefondo = P0.codicefondo"
                    + " AND S.codiceripartizione = P0.codiceripartizione"
                    + " AND I.esercizio = P0.esercizio)) AS idbilanciospesa,"
                    + " ISNULL("
                    + " (SELECT SUM(previsionespese)"
                    + " FROM previsioneripfondi P1"
                    + " WHERE P1.codicefondo = P0.codicefondo"
                    + " AND P1.codiceripartizione = P0.codiceripartizione"
                    + " AND P1.esercizio <= P0.esercizio)"
                    + " ,0) +"
                    + " ISNULL("
                    + " (SELECT SUM(importo)"
                    + " FROM varripfondispese VR"
                    + " WHERE VR.codicefondo = P0.codicefondo"
                    + " AND VR.codiceripartizione = P0.codiceripartizione"
                    + " AND VR.esercizio <= P0.esercizio)"
                    + " ,0) -"
                    + " ISNULL("
                    + " (SELECT SUM(totale)"
                    + " FROM totfondospesa TFS"
                    + " WHERE P0.codicefondo = TFS.codicefondo"
                    + " AND P0.codiceripartizione = TFS.codiceripartizione"
                    + " AND TFS.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL)"
                    + " AND TFS.esercizio <= P0.esercizio)"
                    + " ,0) -"
                    + " ISNULL("
                    + " (SELECT SUM(importo)"
                    + " FROM totfondospesaprec TFSP "
                    + " WHERE P0.codicefondo = TFSP.codicefondo"
                    + " AND P0.codiceripartizione = TFSP.codiceripartizione"
                    + " AND TFSP.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL))"
                    + " ,0) AS previsione"
                    + " FROM previsioneripfondi P0"
                    + " WHERE esercizio = " + (anno + 1)
                    + " AND (idbilanciospesa IS NOT NULL"
                    + " OR idbilanciospesa IS NULL "
                    + " AND"
                    + " (SELECT COUNT(DISTINCT I.idbilancio)"
                    + " FROM spesa S"
                    + " JOIN imputazionespesa I"
                    + " ON S.idspesa = I.idspesa"
                    + " WHERE S.codicefondo = P0.codicefondo"
                    + " AND S.codiceripartizione = P0.codiceripartizione"
                    + " AND I.esercizio = P0.esercizio) = 1"
                    + " )"
                    + " GROUP BY P0.codicefondo, P0.codiceripartizione, P0.idbilanciospesa, P0.esercizio) AS tab"
                    + " LEFT OUTER JOIN totbilancio TB"
                    + " ON TB.idbilancio = tab.idbilanciospesa"
                    + " LEFT OUTER JOIN totbilanciospesa TBS"
                    + " ON TBS.idbilancio = tab.idbilanciospesa"
                    + " AND TBS.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL)"
                    + " JOIN bilancio"
                    + " ON bilancio.idbilancio = tab.idbilanciospesa"
                    + " GROUP BY tab.idbilanciospesa,"
                    + " bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio"
                    + " HAVING"
                    + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                    + " ISNULL(AVG(TBS.totalecompetenza),0) -"
                    + " SUM(tab.previsione) < 0";
                }


                DataTable tCapitoloCalderoneConPrevNegativa_S = SourceConn.SQLRunner(query, true, TIMEOUT);
                if (tCapitoloCalderoneConPrevNegativa_S.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(tCapitoloCalderoneConPrevNegativa_S, "I seguenti capitoli di spesa non hanno sufficiente previsione per stornare i fondi se si procedesse si avrebbero questi valori:", "Si vuole proseguire?").ShowDialog(form);
                    if (dr != DialogResult.Yes) return false;
                }

                if (drAss != DialogResult.Yes) {
                    object tipoPrevPrinc = SourceConn.DO_READ_VALUE("persbilancio", "(esercizio = " + anno + ")", "tipoprevprincipale");
                    if (tipoPrevPrinc == null) {
                        MessageBox.Show("Errore nell'interrogazione di PERSBILANCIO!!!");
                        return false;
                    }

                    string querySuVarResiduiE = "";
                    if (tipoPrevPrinc.ToString().ToUpper() == "C") {
                        querySuVarResiduiE =
                        " ISNULL("
                        + " (SELECT -SUM(VE.importo)"
                        + " FROM variazioneentrata VE JOIN entrata MOV"
                        + " ON VE.identrata = MOV.identrata"
                        + " JOIN imputazioneentrata IMPU"
                        + " ON IMPU.identrata = MOV.identrata"
                        + " AND VE.esercvariazione = IMPU.esercizio"
                        + " WHERE VE.esercvariazione = " + fromYear
                        + " AND IMPU.flagcompetenza = 'R'"
                        + " AND MOV.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL)"
                        + " AND IMPU.idbilancio = tab.idbilancioentrata)"
                        + ",0)";
                    }
                    else {
                        querySuVarResiduiE = " 0 ";
                    }

                    query = "SELECT	bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio,"
                        + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                        + " ISNULL(AVG(TBS.totalecompetenza),0) + "
                        + querySuVarResiduiE
                        + " - SUM(tab.previsione)"
                        + " FROM "
                        + " (SELECT "
                        + " P0.codicefondo, P0.codiceripartizione,"
                        + " ISNULL(P0.idbilancioentrata,"
                        + " (SELECT TOP 1 I.idbilancio"
                        + " FROM entrata S"
                        + " JOIN imputazioneentrata I"
                        + " ON S.identrata = I.identrata"
                        + " WHERE S.codicefondo = P0.codicefondo"
                        + " AND S.codiceripartizione = P0.codiceripartizione"
                        + " AND I.esercizio = P0.esercizio)) AS idbilancioentrata,"
                        + " ISNULL("
                        + " (SELECT SUM(previsioneentrate)"
                        + " FROM previsioneripfondi P1"
                        + " WHERE P1.codicefondo = P0.codicefondo"
                        + " AND P1.codiceripartizione = P0.codiceripartizione"
                        + " AND P1.esercizio <= P0.esercizio)"
                        + " ,0) +"
                        + " ISNULL("
                        + " (SELECT SUM(importo)"
                        + " FROM varripfondientrate VR"
                        + " WHERE VR.codicefondo = P0.codicefondo"
                        + " AND VR.codiceripartizione = P0.codiceripartizione"
                        + " AND VR.esercizio <= P0.esercizio)"
                        + " ,0) -"
                        + " ISNULL("
                        + " (SELECT SUM(totale)"
                        + " FROM totfondoentrata TFS"
                        + " WHERE P0.codicefondo = TFS.codicefondo"
                        + " AND P0.codiceripartizione = TFS.codiceripartizione"
                        + " AND TFS.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL)"
                        + " AND TFS.esercizio <= P0.esercizio)"
                        + " ,0) -"
                        + " ISNULL("
                        + " (SELECT SUM(importo)"
                        + " FROM totfondoentrataprec TFSP "
                        + " WHERE P0.codicefondo = TFSP.codicefondo"
                        + " AND P0.codiceripartizione = TFSP.codiceripartizione"
                        + " AND TFSP.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL))"
                        + " ,0) AS previsione"
                        + " FROM previsioneripfondi P0"
                        + " WHERE esercizio = " + anno
                        + " AND (idbilancioentrata IS NOT NULL"
                        + " OR idbilancioentrata IS NULL "
                        + " AND"
                        + " (SELECT COUNT(DISTINCT I.idbilancio)"
                        + " FROM entrata S"
                        + " JOIN imputazioneentrata I"
                        + " ON S.identrata = I.identrata"
                        + " WHERE S.codicefondo = P0.codicefondo"
                        + " AND S.codiceripartizione = P0.codiceripartizione"
                        + " AND I.esercizio = P0.esercizio) = 1"
                        + " )"
                        + " GROUP BY P0.codicefondo, P0.codiceripartizione, P0.idbilancioentrata, P0.esercizio) AS tab"
                        + " LEFT OUTER JOIN totbilancio TB"
                        + " ON TB.idbilancio = tab.idbilancioentrata"
                        + " LEFT OUTER JOIN totbilancioentrata TBS"
                        + " ON TBS.idbilancio = tab.idbilancioentrata"
                        + " AND TBS.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL)"
                        + " JOIN bilancio"
                        + " ON bilancio.idbilancio = tab.idbilancioentrata"
                        + " GROUP BY tab.idbilancioentrata,"
                        + " bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio"
                        + " HAVING"
                        + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                        + " ISNULL(AVG(TBS.totalecompetenza),0) -"
                        + " SUM(tab.previsione) < 0";
                }
                else {
                    query = "SELECT	bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio,"
                       + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                       + " ISNULL(AVG(TBS.totalecompetenza),0) - "
                       + " SUM(tab.previsione)"
                       + " FROM "
                       + " (SELECT "
                       + " P0.codicefondo, P0.codiceripartizione,"
                       + " ISNULL(P0.idbilancioentrata,"
                       + " (SELECT TOP 1 I.idbilancio"
                       + " FROM entrata S"
                       + " JOIN imputazioneentrata I"
                       + " ON S.identrata = I.identrata"
                       + " WHERE S.codicefondo = P0.codicefondo"
                       + " AND S.codiceripartizione = P0.codiceripartizione"
                       + " AND I.esercizio = P0.esercizio)) AS idbilancioentrata,"
                       + " ISNULL("
                       + " (SELECT SUM(previsioneentrate)"
                       + " FROM previsioneripfondi P1"
                       + " WHERE P1.codicefondo = P0.codicefondo"
                       + " AND P1.codiceripartizione = P0.codiceripartizione"
                       + " AND P1.esercizio <= P0.esercizio)"
                       + " ,0) +"
                       + " ISNULL("
                       + " (SELECT SUM(importo)"
                       + " FROM varripfondientrate VR"
                       + " WHERE VR.codicefondo = P0.codicefondo"
                       + " AND VR.codiceripartizione = P0.codiceripartizione"
                       + " AND VR.esercizio <= P0.esercizio)"
                       + " ,0) -"
                       + " ISNULL("
                       + " (SELECT SUM(totale)"
                       + " FROM totfondoentrata TFS"
                       + " WHERE P0.codicefondo = TFS.codicefondo"
                       + " AND P0.codiceripartizione = TFS.codiceripartizione"
                       + " AND TFS.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL)"
                       + " AND TFS.esercizio <= P0.esercizio)"
                       + " ,0) -"
                       + " ISNULL("
                       + " (SELECT SUM(importo)"
                       + " FROM totfondoentrataprec TFSP "
                       + " WHERE P0.codicefondo = TFSP.codicefondo"
                       + " AND P0.codiceripartizione = TFSP.codiceripartizione"
                       + " AND TFSP.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL))"
                       + " ,0) AS previsione"
                       + " FROM previsioneripfondi P0"
                       + " WHERE esercizio = " + (anno + 1)
                       + " AND (idbilancioentrata IS NOT NULL"
                       + " OR idbilancioentrata IS NULL "
                       + " AND"
                       + " (SELECT COUNT(DISTINCT I.idbilancio)"
                       + " FROM entrata S"
                       + " JOIN imputazioneentrata I"
                       + " ON S.identrata = I.identrata"
                       + " WHERE S.codicefondo = P0.codicefondo"
                       + " AND S.codiceripartizione = P0.codiceripartizione"
                       + " AND I.esercizio = P0.esercizio) = 1"
                       + " )"
                       + " GROUP BY P0.codicefondo, P0.codiceripartizione, P0.idbilancioentrata, P0.esercizio) AS tab"
                       + " LEFT OUTER JOIN totbilancio TB"
                       + " ON TB.idbilancio = tab.idbilancioentrata"
                       + " LEFT OUTER JOIN totbilancioentrata TBS"
                       + " ON TBS.idbilancio = tab.idbilancioentrata"
                       + " AND TBS.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL)"
                       + " JOIN bilancio"
                       + " ON bilancio.idbilancio = tab.idbilancioentrata"
                       + " GROUP BY tab.idbilancioentrata,"
                       + " bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio"
                       + " HAVING"
                       + " ISNULL(AVG(TB.totpreveserciziocorr),0) + ISNULL(AVG(TB.totvarprevisione),0) -"
                       + " ISNULL(AVG(TBS.totalecompetenza),0) -"
                       + " SUM(tab.previsione) < 0";
                }
                DataTable tCapitoloCalderoneConPrevNegativa_E = SourceConn.SQLRunner(query, true, TIMEOUT);
                if (tCapitoloCalderoneConPrevNegativa_E.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(tCapitoloCalderoneConPrevNegativa_E, "I seguenti capitoli di entrata non hanno sufficiente previsione per stornare i fondi se si procedesse si avrebbero questi valori:", "Si vuole proseguire?").ShowDialog(form);
                    if (dr != DialogResult.Yes) return false;
                }

                query = "SELECT E.esercmovimento,E.nummovimento, E.importo as ImportoOriginale, I.importo as ImportoImputazione from entrata E join imputazioneentrata I on " +
                        "  E.identrata=I.identrata where " +
                        "  I.esercizio= E.esercmovimento and " +
                        "  isnull(E.importo,0)<>isnull(I.importo,0)";
                DataTable EntrateConImpEsercizioIncoerente = SourceConn.SQLRunner(query, true, TIMEOUT);
                if(EntrateConImpEsercizioIncoerente.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(EntrateConImpEsercizioIncoerente, 
                        "I seguenti mov. di entrata risultano avere un importo esercizio incoerente con quello della prima imputazione", "Si vuole proseguire?").ShowDialog(form);
                    if(dr != DialogResult.Yes) return false;
                }

                int annoCorrente = (drAss == DialogResult.Yes) ? anno + 1 : anno;
                string qCrediti = "SELECT bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio, " +
                    " ISNULL(AVG(TB.totvarcrediti),0) + ISNULL(AVG(TB.totasscrediti),0) - " +
                    " SUM(tab.differenza) FROM " +
	                " (SELECT P0.codicefondo, P0.codiceripartizione, " +
		            " ISNULL(P0.idbilanciospesa, " +
			        " (SELECT TOP 1 I.idbilancio " +
			        " FROM spesa S JOIN imputazionespesa I " +
				    " ON S.idspesa = I.idspesa " +
			        " WHERE S.codicefondo = P0.codicefondo " +
				    " AND S.codiceripartizione = P0.codiceripartizione " +
				    " AND I.esercizio = P0.esercizio)) AS idbilanciospesa, " +
		            " ISNULL((SELECT SUM(totale) " +
			        " FROM totfondoentrata TFS " + 
			        " WHERE P0.codicefondo = TFS.codicefondo " +
				    " AND P0.codiceripartizione = TFS.codiceripartizione " +
				    " AND TFS.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL) " +
				    " AND TFS.esercizio <= P0.esercizio),0) + " +
		            " ISNULL((SELECT SUM(importo) " +
			        " FROM totfondoentrataprec TFSP " +
			        " WHERE P0.codicefondo = TFSP.codicefondo " +
				    " AND P0.codiceripartizione = TFSP.codiceripartizione " +
				    " AND TFSP.codicefase = (SELECT TOP 1 codfaseaccertamento FROM persbilancio WHERE codfaseaccertamento IS NOT NULL)) " +
		            " ,0) - " +
		            " ISNULL((SELECT SUM(totale) " +
			        " FROM totfondospesa TFS " +
			        " WHERE P0.codicefondo = TFS.codicefondo " +
				    " AND P0.codiceripartizione = TFS.codiceripartizione " +
				    " AND TFS.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL) " +
				    " AND TFS.esercizio <= P0.esercizio),0) - " +
		            " ISNULL((SELECT SUM(importo) " +
			        " FROM totfondospesaprec TFSP " +
			        " WHERE P0.codicefondo = TFSP.codicefondo " +
				    " AND P0.codiceripartizione = TFSP.codiceripartizione " +
				    " AND TFSP.codicefase = (SELECT TOP 1 codfaseimpegno FROM persbilancio WHERE codfaseimpegno IS NOT NULL)) " +
		            " ,0) AS differenza " +
	                " FROM previsioneripfondi P0 " +
                    " WHERE esercizio = " + annoCorrente +
		            " AND (idbilanciospesa IS NOT NULL OR idbilanciospesa IS NULL " +
			        " AND (SELECT COUNT(DISTINCT I.idbilancio) " +
                    " FROM spesa S JOIN imputazionespesa I " +
					" ON S.idspesa = I.idspesa " +
				    " WHERE S.codicefondo = P0.codicefondo " +
				    " AND S.codiceripartizione = P0.codiceripartizione " +
				    " AND I.esercizio = P0.esercizio) = 1) " +
	                " GROUP BY P0.codicefondo, P0.codiceripartizione, P0.idbilanciospesa, P0.esercizio) AS tab " +
                    " LEFT OUTER JOIN totbilancio TB ON TB.idbilancio = tab.idbilanciospesa " +
                    " JOIN bilancio	ON bilancio.idbilancio = tab.idbilanciospesa " +
                    " GROUP BY tab.idbilanciospesa, bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio " +
                    " HAVING ISNULL(AVG(TB.totvarcrediti),0) + ISNULL(AVG(TB.totasscrediti),0) - SUM(tab.differenza) < 0";
                DataTable tCapitoloCalderoneConCreditiNegativi = SourceConn.SQLRunner(qCrediti, true, TIMEOUT);
                if (tCapitoloCalderoneConCreditiNegativi.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(tCapitoloCalderoneConCreditiNegativi, "I seguenti capitoli di spesa non hanno sufficienti crediti per stornare i fondi se si procedesse si avrebbero questi valori:", "Si vuole proseguire?").ShowDialog(form);
                    if (dr != DialogResult.Yes) return false;
                }

                string qIncassi = "SELECT bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio, " +
                    " ISNULL(AVG(TB.totvarcassa),0) + ISNULL(AVG(TB.totasscassa),0) - " +
                    " SUM(tab.differenza) FROM " +
                    " (SELECT P0.codicefondo, P0.codiceripartizione, " +
                    " ISNULL(P0.idbilanciospesa, " +
                    " (SELECT TOP 1 I.idbilancio " +
                    " FROM spesa S JOIN imputazionespesa I " +
                    " ON S.idspesa = I.idspesa " +
                    " WHERE S.codicefondo = P0.codicefondo " +
                    " AND S.codiceripartizione = P0.codiceripartizione " +
                    " AND I.esercizio = P0.esercizio)) AS idbilanciospesa, " +
                    " ISNULL((SELECT SUM(totale) " +
                    " FROM totfondoentrata TFS " +
                    " WHERE P0.codicefondo = TFS.codicefondo " +
                    " AND P0.codiceripartizione = TFS.codiceripartizione " +
                    " AND TFS.codicefase = (SELECT MAX(codicefase) FROM faseentrata) " +
                    " AND TFS.esercizio <= P0.esercizio),0) + " +
                    " ISNULL((SELECT SUM(importo) " +
                    " FROM totfondoentrataprec TFSP " +
                    " WHERE P0.codicefondo = TFSP.codicefondo " +
                    " AND P0.codiceripartizione = TFSP.codiceripartizione " +
                    " AND TFSP.codicefase = (SELECT MAX(codicefase) FROM faseentrata)) " +
                    " ,0) - " +
                    " ISNULL((SELECT SUM(totale) " +
                    " FROM totfondospesa TFS " +
                    " WHERE P0.codicefondo = TFS.codicefondo " +
                    " AND P0.codiceripartizione = TFS.codiceripartizione " +
                    " AND TFS.codicefase = (SELECT MAX(codicefase) FROM fasespesa) " +
                    " AND TFS.esercizio <= P0.esercizio),0) - " +
                    " ISNULL((SELECT SUM(importo) " +
                    " FROM totfondospesaprec TFSP " +
                    " WHERE P0.codicefondo = TFSP.codicefondo " +
                    " AND P0.codiceripartizione = TFSP.codiceripartizione " +
                    " AND TFSP.codicefase = (SELECT MAX(codicefase) FROM fasespesa)) " +
                    " ,0) AS differenza " +
                    " FROM previsioneripfondi P0 " +
                    " WHERE esercizio = " + annoCorrente +
                    " AND (idbilanciospesa IS NOT NULL OR idbilanciospesa IS NULL " +
                    " AND (SELECT COUNT(DISTINCT I.idbilancio) " +
                    " FROM spesa S JOIN imputazionespesa I " +
                    " ON S.idspesa = I.idspesa " +
                    " WHERE S.codicefondo = P0.codicefondo " +
                    " AND S.codiceripartizione = P0.codiceripartizione " +
                    " AND I.esercizio = P0.esercizio) = 1) " +
                    " GROUP BY P0.codicefondo, P0.codiceripartizione, P0.idbilanciospesa, P0.esercizio) AS tab " +
                    " LEFT OUTER JOIN totbilancio TB ON TB.idbilancio = tab.idbilanciospesa " +
                    " JOIN bilancio	ON bilancio.idbilancio = tab.idbilanciospesa " +
                    " GROUP BY tab.idbilanciospesa, bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio " +
                    " HAVING ISNULL(AVG(TB.totvarcassa),0) + ISNULL(AVG(TB.totasscassa),0) - SUM(tab.differenza) < 0";
                DataTable tCapitoloCalderoneConIncassiNegativi = SourceConn.SQLRunner(qIncassi, true, TIMEOUT);
                if (tCapitoloCalderoneConIncassiNegativi.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(tCapitoloCalderoneConIncassiNegativi, "I seguenti capitoli di entrata non hanno sufficiente incassi per stornare i fondi se si procedesse si avrebbero questi valori:", "Si vuole proseguire?").ShowDialog(form);
                    if (dr != DialogResult.Yes) return false;
                }

                query = "SELECT S.esercmovimento,S.nummovimento, S.importo as ImportoOriginale, I.importo as ImportoImputazione from spesa S join imputazionespesa I on " +
                       "  S.idspesa=I.idspesa where " +
                       "  I.esercizio= S.esercmovimento and " +
                       "  isnull(S.importo,0)<>isnull(I.importo,0)";
                DataTable SpeseConImpEsercizioIncoerente = SourceConn.SQLRunner(query, true, TIMEOUT);
                if(SpeseConImpEsercizioIncoerente.Rows.Count > 0) {
                    DialogResult dr = new FrmErrore(SpeseConImpEsercizioIncoerente,
                        "I seguenti mov. di spesa risultano avere un importo esercizio incoerente con quello della prima imputazione", "Si vuole proseguire?").ShowDialog(form);
                    if(dr != DialogResult.Yes) return false;
                }

            }
       
			return true;

		}


		public static string tabelleSpeciali = "'dettvarbilancio', 'finyear', 'imputazioneentrata', "
			+ "'imputazionespesa', 'tabelleclassificabili', 'tipoclassmovimentiapplicabile', "
			+ "'upb', 'variazionebilancio'";

		public static DataTable tFdrUpb;
		public static DataTable tCdsUpb;
		public static bool migraUpb(Form form, DataAccess sourceConn, DataAccess destConn, DataTable tTableName, DataTable tColName) {
			//truncate table upb
			//truncate table sortingapplicability
			//truncate table finyear
			//truncate table fin
			//truncate table finvar
			//truncate table finvardetail
			//truncate table incomeyear
			//truncate table expenseyear

			//fondoricerca, ripfondiricerca, centrospesa -> upb
			if (!creaTabellaUpb(form, sourceConn, destConn, out tFdrUpb, out tCdsUpb)) return false;//1.1 e 1.2

			//tabelleclassificabili -> sortabletable (sistema)//--------------AllSystemCfgNoGeo.sql
//			esportaTabelleClassificabili(form, sourceConn, destConn);//1.3

			//tipoclassmovimentiapplicabile -> sortingapplicability
			if (!esportaTipoClassMovimentiApplicabile(form, sourceConn, destConn, tTableName)) return false;//1.4

			//classtreefondo e classtreeripartizioni -> upbsorting
			if (!migraDaFdrAdUpbSorting(form, sourceConn, destConn, tFdrUpb)) return false;//1.5

			//classtreecentrospesa -> ubpsorting
			if (!migraDaCdsAdUpbSorting(form, sourceConn, destConn, tCdsUpb)) return false;//1.6

			DataTable tUpblookup = null;
			DataTable tEsistenzaUpblookup = sourceConn.SQLRunner("select object_id('upblookup')");
			if (tEsistenzaUpblookup.Rows[0][0] != DBNull.Value) {
				tUpblookup = sourceConn.SQLRunner("select * from upblookup");
				if (tUpblookup!=null){
					if (tUpblookup.Rows.Count==0) tUpblookup=null;
				}
			}

			//bilancio -> finyear
			if (!migraBilancioinFinYear(form, sourceConn, destConn, tUpblookup)) return false;//1.7

			//bilancio -> fin//-------------------------------------------chkcfgbilancio
			if (!migraBilancioInFin(form, sourceConn, destConn, tColName)) return false;//1.7


			//variazionebilancio, variazionecrediti, variazionecassa -> finvar
			//dettvarbilancio, dettvarcrediti, dettvarcassa -> finvardetail
			if (!migraVariazioni(form, sourceConn, destConn, tUpblookup)) return false;//1.8

			//imputazioneentrata -> incomeyear, finvar e finvardetail
			if (!migraImputazioneEOS("entrata", form, sourceConn, destConn, tFdrUpb, tCdsUpb, tUpblookup)) return false;//1.9

			//imputazionespesa -> expenseyear, finvar e finvardetail
			if (!migraImputazioneEOS("spesa", form, sourceConn, destConn, tFdrUpb, tCdsUpb, tUpblookup)) return false;//1.9

			DialogResult dr_FdR = MessageBox.Show(form, "Si vuole procedere a stornare le previsioni dell'ultimo anno"
				+ " dei fondi di ricerca dall'UPB Dipartimento se esistono fondi associati ad un unica voce di bilancio"
				+ " ponendo l'importo della variazione pari alla previsione disponibile del Fondo di Ricerca?",
				"", MessageBoxButtons.YesNo);
			if (dr_FdR == DialogResult.Yes) {
				if (!stornaPrevisioneDaLiberoAFdR_MonoCapitolo("E", form, sourceConn, destConn, tFdrUpb)) return false;
				if (!stornaPrevisioneDaLiberoAFdR_MonoCapitolo("S", form, sourceConn, destConn, tFdrUpb)) return false;
                if (!stornaCreditiCassaDaLiberoAFdR_MonoCapitolo(form, sourceConn, destConn, tFdrUpb)) return false;
			}

			// Attenzione! Se si è deciso di non migrare i centri di spesa
			// non occorrerà fare gli storni di bilancio, in quanto l'UPB di partenza risulterebbe lo stesso di arrivo,
			int totRighe = tCdsUpb.Select().Length;
			int totRigheUpbRoot = tCdsUpb.Select("(idupb = '0001')").Length;
			bool effettuaStorni = CfgFn.GetNoNullInt32(totRighe) != CfgFn.GetNoNullInt32(totRigheUpbRoot);
			if (effettuaStorni) {
				DialogResult dr = MessageBox.Show(form,"Si vuol procedere agli storni di bilancio dall'UPB Dipartimento"
					+ " agli UPB associati ai Centri di Spesa?", "", MessageBoxButtons.YesNo);
				effettuaStorni = effettuaStorni && (dr == DialogResult.Yes);
			}
			if (effettuaStorni) {
				//asscentroentrata -> finvar, finvardetail
				if (!migraAssCentroEOS("entrata", form, sourceConn, destConn, tCdsUpb, tUpblookup)) return false;//1.10

				//asscentrospesa -> finvar, finvardetail
				if (!migraAssCentroEOS("spesa", form, sourceConn, destConn, tCdsUpb, tUpblookup)) return false;//1.10
			}
			//opfondopiccolespese -> pettycashoperation
			if (!migraOpFondoPiccoleSpese(form, sourceConn, destConn, tColName, tFdrUpb, tCdsUpb, tUpblookup)) return false;//1.11

			//autoclassentrate -> autoincomesorting
			if (!migraAutoClassEOS("entrate", form, sourceConn, destConn, tCdsUpb, tUpblookup)) return false;//1.12

			//autoclassspese -> autoexpensesorting
			if (!migraAutoClassEOS("spese", form, sourceConn, destConn, tCdsUpb, tUpblookup)) return false;//1.12

			//filtraclassentrate -> sortingincomefilter
			if (!migraFiltraClassEOS("entrate", form, sourceConn, destConn, tCdsUpb, tUpblookup)) return false;//1.13

			//filtraclassspese -> sortingexpensefilter
			if (!migraFiltraClassEOS("spese", form, sourceConn, destConn, tCdsUpb, tUpblookup)) return false;//1.13

//			if ((tUpblookup != null) && !troncaNLivelliDiBilancio(destConn, 2)) return false;
			return true;
		}
	}
}
