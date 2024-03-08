
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
        public static void Reset() {
            lookupidunderwriter = new Hashtable();
            tFdrUpb = null;
            tCdsUpb = null;
            lookupidpettycash = new Hashtable();
            lookupidtreasurer = new Hashtable();
            lookupidstamphandling = new Hashtable();
            migraTrattBollo_eseguito = false;
            lookupautokind = new Hashtable();
            lookupmovkind = new Hashtable();
            migraTipoRecupero_eseguito = false;
        }
        static object gethash(Hashtable A, string code) {
            if (code == "") return DBNull.Value;
            code = code.ToUpper();
            if (A[code] == null) {
                MessageBox.Show("Code " + code + " was not found in " + A.GetType().Name);
                return DBNull.Value;
            }
            return A[code];
        }

		/// <summary>
		/// Parte 1.2. Inserimento dei FdR negli UPB
		/// Strategia: Se il fondo di ricerca ha un'unica suddivisione, verrà inserito un UPB di 2° livello
		/// Se il fondo ha più suddivisioni, verrà inserito un UPB di 2° livello che rappresenta il fondo
		/// e tanti UPB di 3° livello per quante sono le suddivisioni
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		private static DataTable inserisciFondiNegliUpb(Form form, DataAccess sourceConn, DataAccess  destConn,
            DataTable tUpb, out bool fondiMigrati) {

            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);
            migraEnteFinanziatore(form, sourceConn, destConn);

			fondiMigrati = false;
			DataTable tFdrUpb = new DataTable();
			tFdrUpb.Columns.Add("idres", typeof(string));
			tFdrUpb.Columns.Add("idpar", typeof(string));
			tFdrUpb.Columns.Add("idupb", typeof(string));
			DataTable t1 = sourceConn.SQLRunner(
                "SELECT top 1 codfaseimpegno,codfaseaccertamento from persbilancio order by esercizio desc");
			object appropriationPhaseCode = t1.Rows[0]["codfaseimpegno"];
			object assessmentPhaseCode = t1.Rows[0]["codfaseaccertamento"];
			string q2 = "SELECT idres=fondoricerca.codicefondo, idpar=ripfondiricerca.codiceripartizione, "
				+ "title_res=fondoricerca.denominazione, title_par=ripfondiricerca.denominazione, "
				+ "idunderwriter=fondoricerca.codiceentefin, active=fondoricerca.flagutilizzabile, "
				+ "codeman_res=fondoricerca.codiceresponsabile, idman_par=ripfondiricerca.codiceresponsabile, "
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
                    if (r["idunderwriter"]!=DBNull.Value)
                        rUpb1["idunderwriter"] = lookupidunderwriter[r["idunderwriter"].ToString().ToUpper()];
                    if (r["codeman_res"] != DBNull.Value) {
                        rUpb1["idman"] = Patrimonio.lookupidman[r["codeman_res"].ToString().ToUpper()];
                    }
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
                    if (r["codeman_res"] != DBNull.Value) {
                        rUpb2["idman"] = Patrimonio.lookupidman[r["codeman_par"].ToString().ToUpper()];
                    }
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

        public static Hashtable lookupidunderwriter = new Hashtable();
        public static bool migraEnteFinanziatore(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("underwriter", null, false) > 0) return true;
            DataTable All = sourceConn.SQLRunner(
                "SELECT M.codiceentefin,ct=M.createtimestamp,cu=M.createuser," +
                "description=M.descrizione,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                "FROM entefinanziatore M");
            if (All.Rows.Count == 0) return true;
            DataTable Underwriter = destConn.CreateTableByName("underwriter", "*");
            int nmaxunderwriter = 0;
            foreach (DataRow Curr in All.Rows) {
                nmaxunderwriter++;
                DataRow R = Underwriter.NewRow();
                R["idunderwriter"] = nmaxunderwriter;
                lookupidunderwriter[Curr["codiceentefin"].ToString().ToUpper()] = nmaxunderwriter;
                foreach (string S in new string[] { "ct", "cu", "description", "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                Underwriter.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Underwriter);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Underwriter");
 
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
				+ "codeman_cen = "
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
                    if (r["codeman_cen"] != DBNull.Value) {
                        rUpb["idman"] = Patrimonio.lookupidman[ r["codeman_cen"].ToString().ToUpper()];
                    }
					rUpb["assured"] = "N";
					rUpb["active"] = "S";
					tUpb.Rows.Add(rUpb);
					tCdsUpb.Rows.Add(new object[] {r["idcen"], idUpbCorr});
				}
			}
			return tCdsUpb;
		}

        public static DataTable tFdrUpb;
        public static DataTable tCdsUpb;

		/// <summary>
		/// Sezione 1. Riempimento della tabella UPB
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tFdrUpb"></param>
		/// <param name="tCdsUpb"></param>
		/// <returns>TRUE: Non si sono verificati errori; FALSE: Si sono verificati errori</returns>
		public static bool creaTabellaUpb(Form form, DataAccess sourceConn, DataAccess destConn) 
		{
            if (tFdrUpb != null) return true;
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
			tFdrUpb = inserisciFondiNegliUpb(form, sourceConn,destConn, ds.upb, out fondiMigrati);
			tCdsUpb = inserisciCdsNegliUpb(form, sourceConn, ds.upb, out centriMigrati);

            tFdrUpb.CaseSensitive = false;
            tCdsUpb.CaseSensitive = false;

			if (tFdrUpb == null) return false;
			if (tCdsUpb == null) return false;

			

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
		public static bool migraDaFdrAdUpbSorting(Form form, DataAccess sourceConn, DataAccess destConn) 
		{
            creaTabellaUpb(form, sourceConn, destConn);

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
		public static bool migraDaCdsAdUpbSorting(Form form, DataAccess sourceConn, DataAccess destConn) {
            creaTabellaUpb(form, sourceConn, destConn);

			string q = 	"SELECT DISTINCT idsorkind=codicetipoclass, idsor=idclass, idcen=SUBSTRING(idcentrospesa,3,LEN(idcentrospesa)),"
				+ " quota=null FROM classtreecentrospesa "
				+ "GROUP BY codicetipoclass, idclass, SUBSTRING(idcentrospesa,3,LEN(idcentrospesa))";
			DataTable tUpbSorting = Migrazione.eseguiQuery(sourceConn, q, form);
			if (tUpbSorting==null) return false;
			tUpbSorting.Columns.Add("idupb", typeof(string));
			tUpbSorting.Columns.Add("cu", typeof(string));
			tUpbSorting.Columns.Add("ct",typeof(DateTime));
			tUpbSorting.Columns.Add("lu", typeof(string));
			tUpbSorting.Columns.Add("lt",typeof(DateTime));
			foreach (DataRow r in tUpbSorting.Rows) {
				DataRow[] rCdrUpb = tCdsUpb.Select("idcen="+QueryCreator.quotedstrvalue(r["idcen"], false));
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
		public static bool migraImputazioneEOS(string eos, Form form, DataAccess sourceConn, DataAccess destConn) {
            if (eos=="spesa" && destConn.RUN_SELECT_COUNT("expenseyear",null,false)>0)return true;
            if (eos=="entrata" && destConn.RUN_SELECT_COUNT("incomeyear",null,false)>0)return true;

            migraBilancio(form, sourceConn, destConn);
            creaTabellaUpb(form, sourceConn, destConn);

			string maxFaseEOS = (string) sourceConn.DO_READ_VALUE("fase"+eos+"", null, "MAX(codicefase)");
			string q0 = "select esercizio, codfaseimpegno,codfaseaccertamento, tipoprevprincipale, tipoprevsecondaria=isnull(tipoprevsecondaria,'A') from persbilancio";
			DataTable tPersBil = Migrazione.eseguiQuery(sourceConn, q0, form);
			if (tPersBil==null) return false;
			string q1 = "select yvar, maxnvar=max(nvar) from finvar group by yvar";
			DataTable tContaFinVar = Migrazione.eseguiQuery(destConn, q1, form);
			if (tContaFinVar==null) return false;

			string nuovoNome = (eos == "spesa") ? "exp" : "inc";
            string filterfin = (eos == "spesa") ? " AND ((FIN.flag & 1)<>0) " : " AND ((FIN.flag & 1)=0) ";
			string qEOSY;
            if (eos == "spesa") {
                qEOSY = "select amount=imput.importo, ayear=imput.esercizio, "
                    + "ct=imput.createtimestamp, cu=imput.createuser,  "
                    + "idcen=imput.idcentrospesa, EX.idexp, "
                    + "imput.idbilancio, FIN.idfin,  lt=imput.lastmodtimestamp, "
                    + "lu=imput.lastmoduser,  "
                    + "idres=S.codicefondo, idpar=S.codiceripartizione "
                    + "from imputazionespesa imput "
                    + "left outer join spesa S on S.idspesa=imput.idspesa " +
                "left outer join bilancio B ON B.idbilancio=imput.idbilancio " +
                 "left outer join " + getExtAccess(destConn, "fin", false) + " FIN " +
                " ON FIN.codefin= B.codicebilancio " +
                " AND FIN.ayear = CONVERT(INT,B.esercizio) AND ((FIN.flag & 1)<>0)" +
                " JOIN " + getExtAccess(destConn, "expense", false) + " EX" +
                "   ON EX.ymov=S.esercmovimento " +
                "   AND EX.nmov=S.nummovimento " +
                "   AND EX.nphase = convert(int,S.codicefase)";
            }
            else {
                qEOSY = "select amount=imput.importo, ayear=imput.esercizio, "
                    + "ct=imput.createtimestamp, cu=imput.createuser,  "
                    + "idcen=imput.idcentrospesa, EX.idinc,"
                    + "imput.idbilancio, FIN.idfin,  lt=imput.lastmodtimestamp, "
                    + "lu=imput.lastmoduser,  "
                    + "idres=S.codicefondo, idpar=S.codiceripartizione "
                    + "from imputazioneentrata imput "
                    + "left outer join entrata S on S.identrata=imput.identrata " +
                "left outer join bilancio B ON B.idbilancio=imput.idbilancio " +
                 "left outer join " + getExtAccess(destConn, "fin", false) + " FIN " +
                " ON FIN.codefin= B.codicebilancio " +
                " AND FIN.ayear = CONVERT(INT,B.esercizio) AND ((FIN.flag & 1)=0)" +
                " JOIN " + getExtAccess(destConn, "income", false) + " EX" +
                "   ON EX.ymov=S.esercmovimento " +
                "   AND EX.nmov=S.nummovimento " +
                "   AND EX.nphase = convert(int,S.codicefase)";

            }

            DataTable tEOSYear = Migrazione.eseguiQuery(sourceConn, qEOSY, form);
			if (tEOSYear==null) return false;

			VistaUpb ds = new VistaUpb();
            tEOSYear.Columns.Add("idupb", typeof(string));
			// Passo 3.1.1. Associo gli UPB a tutti i movimenti di "+eos+" con un centro di "+eos+" associato
			foreach (DataRow r in tEOSYear.Rows) {
				r["idupb"] = getIdupbFromFinAndCen(r["idbilancio"], r["idcen"], tCdsUpb);
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
				if (!assegnaUpbAdImputazioneEStorna_perFdR(form, eos, sourceConn, destConn, tEOSYear, 
					rFdrUpb["idres"].ToString(), rFdrUpb["idpar"].ToString(), idUpb, tContaFinVar,
					maxFaseEOS,	tPersBil, tFdrUpb, effettuaStorni, ds)) return false;
			}
			//-- Passo 3.1.3. Associo l'UPB a tutti i movimenti di spesa rimanenti
			foreach (DataRow r in tEOSYear.Select("idupb is null")) {
				r["idupb"] = "0001";
			}

			tEOSYear.Columns.Remove("idbilancio");
            tEOSYear.Columns.Remove("idres");
            tEOSYear.Columns.Remove("idpar");
			tEOSYear.Columns.Remove("idcen");

			tEOSYear.TableName = eos=="spesa" ? "expenseyear" : "incomeyear";
			ds.Tables.Add(tEOSYear);
			return Migrazione.lanciaScript(form, destConn, ds, "imputazione"+eos+" -> "+tEOSYear.TableName);
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
			DataAccess sourceConn, DataAccess destConn, DataTable tEOSYear, string codiceFondo, string codiceRipartizione, 
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
                            if (!stornaDaLiberoAdUpb(form, sourceConn, destConn, eos, true, tipoPrevPrincipale, esercVariazione, tContaFinVar,
                                codiceFondo, codiceRipartizione,
                                (string)r["idupb"], codFaseCompetenza, maxFaseEOS, ds)) return false;

                            if (tipoPrevSecondaria == "S") {
                                if (!stornaDaLiberoAdUpb(form, sourceConn, destConn, eos, false, "S", esercVariazione, tContaFinVar,
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
			tPrevision.Columns.Add("idfin", typeof(int));
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
            string wherefin= (eos == "S") ? "((F.flag & 1)<>0)" : "((F.flag & 1)=0)";
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
                    //Ottiene idfin da idbilNew
                    DataTable NEWFIN = sourceConn.SQLRunner(
                        "select F.idfin from bilancio B " +
                            "left outer join " + getExtAccess(destConn, "fin", false) + " F " +
                            " ON F.codefin= B.codicebilancio " +
                            " AND F.ayear = CONVERT(INT,B.esercizio) " + 
                        " WHERE (B.idbilancio="+QueryCreator.quotedstrvalue(idBilNew,true)+ ")"+
                            wherefin
                    );
                    object idfin = NEWFIN.Rows[0]["idfin"];
					DataRow rPrevision = tPrevision.NewRow();

					rPrevision["idres"] = rSuddivisione["idres"];
					rPrevision["idpar"] = rSuddivisione["idpar"];
					rPrevision["idupb"] = rSuddivisione["idupb"];
                    rPrevision["idfin"] = idfin;
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
                    rFinVar["variationkind"] = 4; // "S";
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
            tPrevision.Columns.Add("idfin", typeof(int));
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

                //Ottiene idfin da idbilNew
                DataTable NEWFIN = sourceConn.SQLRunner(
                    "select F.idfin from bilancio B " +
                        "left outer join " + getExtAccess(destConn, "fin", false) + " F " +
                        " ON F.codefin= B.codicebilancio " +
                        " AND F.ayear = CONVERT(INT,B.esercizio) " +
                    " WHERE (B.idbilancio=" + QueryCreator.quotedstrvalue(idBilNew, true) + ")" +
                        "AND ((F.flag & 1)<>0)"
                );
                object idfin = NEWFIN.Rows[0]["idfin"];
                DataRow rPrevision = tPrevision.NewRow();

                rPrevision["idres"] = rSuddivisione["idres"];
                rPrevision["idpar"] = rSuddivisione["idpar"];
                rPrevision["idupb"] = rSuddivisione["idupb"];
                rPrevision["idfin"] = idfin;
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
                rFinVar["variationkind"] = 4; //"S"
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


        public static Hashtable lookupidpettycash= new Hashtable();
        private static bool migraFondoPiccoleSpese(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("pettycash", null, false) > 0) return true;
            DataTable All = sourceConn.SQLRunner("SELECT * from fondopiccolespese");
            int nmaxidpettycash = 0;
            DataTable PettyCash = destConn.CreateTableByName("pettycash", "*");

            foreach (DataRow Curr in All.Rows) {
                nmaxidpettycash++;
                DataRow R = PettyCash.NewRow();
                R["idpettycash"] = nmaxidpettycash;
                R["pettycode"] = Curr["codicefondops"].ToString().ToUpper();
                lookupidpettycash[R["pettycode"]] = nmaxidpettycash;
                R["description"] = Curr["descrizione"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                PettyCash.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(PettyCash);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento PettyCash");
        }

		/// <summary>
		/// Sezione 4. Aggiornamento della tabella PETTYCASHOPERATION
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tFdrUpb"></param>
		/// <param name="tCdsUpb"></param>
		private static bool migraOpFondoPiccoleSpese(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("pettycashoperation", null, false) > 0) return true;
            creaTabellaUpb(form,sourceConn,destConn);
            migraFondoPiccoleSpese(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT idcen=O.idcentrospesa, idres=O.codicefondo, idpar=O.codiceripartizione, " +
                " FIN.idfin, O.codicefondops, ct=O.createtimestamp, cu=O.createuser, " +
                " lu=O.lastmoduser, lt=O.lastmodtimestamp, adate=O.datacontabile, docdate=O.datadocumento, " +
                " description=O.descrizione, doc=O.documento, yoperation=O.esercoperazione,yrestore=O.esercreintegro, " +
                " amount=O.importo, txt=O.notes, rtf=O.olenotes, noperation=O.numoperazione, nrestore=O.numreintegro, " +
                " O.tipooperazione, O.tipospesa " +
                "from opfondopiccolespese O " +
                "left outer join bilancio B ON B.idbilancio=O.idbilancio " +
                 "left outer join " + getExtAccess(destConn, "fin", false) + " FIN " +
                " ON FIN.codefin= B.codicebilancio " +
                " AND FIN.ayear = CONVERT(INT,B.esercizio) AND ((FIN.flag & 1)<>0)");

			if (All.Rows.Count==0) return true;
            DataTable PettyCashOp = destConn.CreateTableByName("pettycashoperation", "*");
            foreach(DataRow Curr in All.Rows){
                DataRow R= PettyCashOp.NewRow();
                R["idpettycash"]= lookupidpettycash[Curr["codicefondops"].ToString().ToUpper()];
                int flag=0;
                if (Curr["tipooperazione"].ToString().ToUpper()=="A") flag+=1;// A/R/C/S bit 0,1,2,3, bit 4=documented
                if (Curr["tipooperazione"].ToString().ToUpper()=="R") flag+=2;// A/R/C/S bit 0,1,2,3, bit 4=documented
                if (Curr["tipooperazione"].ToString().ToUpper()=="C") flag+=4;// A/R/C/S bit 0,1,2,3, bit 4=documented
                if (Curr["tipooperazione"].ToString().ToUpper()=="S") flag+=8;// A/R/C/S bit 0,1,2,3, bit 4=documented
                if (Curr["tipospesa"].ToString().ToUpper()=="D") flag+=16;      // A/R/C/S bit 0,1,2,3, bit 4=documented
                R["flag"]=flag;
                if (Curr["idfin"] != DBNull.Value) {
                    R["idupb"] = "0001"; //default
                    object idUpb = getIdupbFromFinAndCen(Curr["idfin"], Curr["idcen"], tCdsUpb);
                    if (idUpb.ToString() != "0001") {
                        // Parte 4.1. Assegnazione dell'UPB alle operazioni associate a centri di spesa
                        R["idupb"] = idUpb;
                    }
                    else {
                        string filtroFdrUpb = QueryCreator.WHERE_COLNAME_CLAUSE(Curr,
                            new string[] { "idres", "idpar" }, DataRowVersion.Current, false);
                        DataRow[] rFdrUpb = tFdrUpb.Select(filtroFdrUpb);
                        if (rFdrUpb.Length > 0) {
                            // Parte 4.2. Assegnazione dell'UPB alle operazioni associate a fondi di ricerca
                            R["idupb"] = rFdrUpb[0]["idupb"];
                        }
                    }
                }
                foreach (string S in new string[] {"idfin","ct","cu","lt","lu","adate","docdate","doc",
                            "description","yoperation","noperation","yrestore","nrestore","amount",
                               "txt","rtf"}) {
                    R[S] = Curr[S];
                }
                PettyCashOp.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(PettyCashOp);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento PettyCashOp");

		}

        public static bool migraOpFondoPiccoleSpeseSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("pettycashexpense", null,false) > 0) return true;

            migraFondoPiccoleSpese(form, sourceConn, destConn);
            migraSpesa(form, sourceConn, destConn);

            DataTable All= sourceConn.SQLRunner(
                "SELECT M.codicefondops, ct=M.createtimestamp,cu=M.createuser,yoperation=M.esercoperazione,"+
                "EXP.idexp,lt=M.lastmodtimestamp,lu=M.lastmoduser,noperation=M.numoperazione "+
                "from piccolespesespesa M " +
                " JOIN SPESA S ON S.idspesa=M.idspesa " +
                " JOIN " + getExtAccess(destConn, "expense", false) + " EXP " +
                "  ON EXP.ymov=S.esercmovimento " +
                "  AND EXP.nmov=S.nummovimento " +
                " AND EXP.nphase = convert(int,S.codicefase)");
            if (All.Rows.Count == 0) return true;
            DataTable Pettycashexpense = destConn.CreateTableByName("pettycashexpense", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Pettycashexpense.NewRow();
                R["idpettycash"] = lookupidpettycash[Curr["codicefondops"].ToString().ToUpper()];
                foreach (string S in new string[] { "ct", "cu", "yoperation", "idexp", "lt", "lu", "noperation" }) {
                    R[S] = Curr[S];
                }
                Pettycashexpense.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Pettycashexpense);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Pettycashexpense");



        }

        public static bool migraOpFondoPiccoleSpeseEntrata(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("pettycashincome", null, false) > 0) return true;

            migraFondoPiccoleSpese(form, sourceConn, destConn);
            migraEntrata(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT M.codicefondops, ct=M.createtimestamp,cu=M.createuser,yoperation=M.esercoperazione," +
                "INC.idinc,lt=M.lastmodtimestamp,lu=M.lastmoduser,noperation=M.numoperazione " +
                "from piccolespeseentrata M " +
                " JOIN ENTRATA E ON E.identrata=M.identrata" +
                " JOIN " + getExtAccess(destConn, "income", false) + " INC " +
                "  ON INC.ymov=E.esercmovimento " +
                "  AND INC.nmov=E.nummovimento " +
                " AND INC.nphase = convert(int,E.codicefase)");
            if (All.Rows.Count == 0) return true;
            DataTable Pettycashincome = destConn.CreateTableByName("pettycashincome", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Pettycashincome.NewRow();
                R["idpettycash"] = lookupidpettycash[Curr["codicefondops"].ToString().ToUpper()];
                foreach (string S in new string[] {  "ct", "cu", "yoperation", "idinc", "lt", "lu", "noperation" }) {
                    R[S] = Curr[S];
                }
                Pettycashincome.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Pettycashincome);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Pettycashincome");



        }

        public static bool migraPersOpFondo(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("pettycashsetup", null, false) > 0) return true;
            migraFondoPiccoleSpese(form, sourceConn, destConn);
            migraBilancio(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            string sql = "SELECT M.codicefondops,ct=M.createtimestamp,cu=M.createuser,registrymanager=REG.idreg," +
                "ayear=M.esercizio,idfinincome=F1.idfin,idfinexpense=F2.idfin,amount=M.importo," +
                "lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                "FROM perspiccolespese M " +
                "LEFT OUTER JOIN BILANCIO B1 ON B1.idbilancio = M.idbilancioentrata " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F1 " +
                " ON F1.codefin=B1.codicebilancio " +
                " AND F1.ayear = B1.esercizio " +
                " AND (F1.flag & 1)=0 " +
                "LEFT OUTER JOIN BILANCIO B2 ON B2.idbilancio = M.idbilanciospesa " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F2 " +
                " ON F2.codefin=B2.codicebilancio " +
                " AND F2.ayear = B2.esercizio " +
                " AND (F2.flag & 1)<>0 " +
                "LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=M.creddebiresponsabile " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG " +
                " ON REG.title=CR.denominazione ";
            DataTable All = sourceConn.SQLRunner(sql    );
            if (All.Rows.Count == 0) return true;
            DataTable PetSetup = destConn.CreateTableByName("pettycashsetup", "*");
            foreach (DataRow Curr in All.Rows) {
                object O = lookupidpettycash[Curr["codicefondops"].ToString().Trim().ToUpper()];
                if (O == null) continue;
                DataRow R = PetSetup.NewRow();
                R["idpettycash"] = O; 
                foreach (string S in new string[] {"ct","cu","registrymanager","ayear","idfinincome",
                                "idfinexpense","amount","lt","lu" }) {
                    R[S] = Curr[S];
                }
                PetSetup.Rows.Add(R);
            }
            if (PetSetup.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(PetSetup);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento pettycashsetup da perspiccolespese");


        }


		private static int getNVarForYVar(int esercVariazione, DataTable tFinVar, DataTable tContaFinVar) {
			object o = tFinVar.Compute("max(nvar)", "yvar="+esercVariazione);
			if (o is DBNull) {
				DataRow[] r = tContaFinVar.Select("yvar="+esercVariazione);
				o = (r.Length>0) ? r[0]["maxnvar"] : 0;
			}
			return 1 + (int) o;
		}

		private static bool stornaDaLiberoAdUpb(Form form, DataAccess sourceConn, DataAccess destConn,
            string eos, bool isPrincipale, string previsionKind, 
			int esercVariazione, DataTable tContaFinVar,
			string codiceFondo, string codiceRipartizione, string idUpb,
			object codFaseImpegno, string maxFase, VistaUpb ds) 
		{
			int numVariazione = getNVarForYVar(esercVariazione, ds.finvar, tContaFinVar);
			string descrizione = "Storno da UPB Dipartimento a UPB dei Fondi di Ricerca (migrazione automatica)";
            string andfinflag = (eos == "spesa") ? "((F.flag & 1)<>0)" : "((F.flag & 1)=0)";
            string query = "SELECT yvar=" + esercVariazione
                + ", nvar=" + numVariazione
                + ", F.idfin, idupb="
                + QueryCreator.quotedstrvalue(idUpb, true)
                + ", amount=SUM(importo" + eos + ".importocorrente), ct=" + QueryCreator.quotedstrvalue(DateTime.Now, true)
                + ", cu='SA', description="
                + QueryCreator.quotedstrvalue(descrizione, true)
                + ", lt=" + QueryCreator.quotedstrvalue(DateTime.Now, true)
                + ", lu='''SA''' "
                + "FROM " + eos + " "
                + "JOIN imputazione" + eos + " "
                + "ON " + eos + ".id" + eos + " = imputazione" + eos + ".id" + eos + " "
                + "JOIN importo" + eos + " "
                + "ON importo" + eos + ".id" + eos + " = imputazione" + eos + ".id" + eos + " "
                + "AND importo" + eos + ".esercizio = imputazione" + eos + ".esercizio "
                + "JOIN BILANCIO B ON B.idbilancio  = imputazione" + eos + ".idbilancio "
                + " JOIN " + getExtAccess(destConn, "fin", false) + " F "
                + "  ON F.codefin=B.codicebilancio "
                + "  AND F.ayear= convert(int,B.esercizio) "
                + " WHERE imputazione" + eos + ".esercizio = " + esercVariazione
                + " AND " + eos + ".codicefondo=" + QueryCreator.quotedstrvalue(codiceFondo, true)
                + " AND " + eos + ".codiceripartizione=" + QueryCreator.quotedstrvalue(codiceRipartizione, true)
                + " AND " + andfinflag;

			if (previsionKind == "C") {
				query += " AND "+eos+".codicefase = " 
					+ QueryCreator.quotedstrvalue(codFaseImpegno, true)
					+ " AND imputazione"+eos+".flagcompetenza = 'C'"
					+ " group by F.idfin";
			}

			if (previsionKind == "S") {
				query += " AND "+eos+".codicefase = " 
					+ QueryCreator.quotedstrvalue(maxFase, true)
					+ " group by F.idfin";
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
				rFinVar["variationkind"] = 4;//"S"
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


        #region decl
        static string ripavanzoamm = "assegnazionecrediti";
        static string ripavanzocassa = "assegnazioneincassi";
        #endregion



        public static bool migraBilancio(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("fin", null, false) > 0) return true;

            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);

            //Migra tutto il bilancio, anno per annno, parte per parte e livello per livello
            int annomin = CfgFn.GetNoNullInt32( sourceConn.DO_READ_VALUE("bilancio",null,"min(esercizio)"));
            int annomax = CfgFn.GetNoNullInt32( sourceConn.DO_READ_VALUE("bilancio",null,"max(esercizio)"));
            int maxidfin = 0;
            for (int ayear=annomin;ayear<=annomax; ayear++){
                int fasemax = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("bilancio", "esercizio = " + ayear.ToString(), "max(codicelivello)"));
                foreach (string finpart in new string[] { "E", "S" }) {
                    Hashtable ParentID = new Hashtable();
                    for(int nlevel=1; nlevel<=fasemax; nlevel++){
                        DataTable All = sourceConn.SQLRunner(
                            "SELECT idbilancio, codefin=codicebilancio,ct=createtimestamp,cu=createuser," +
                            //parte di finyear ---
                            "prevision=preveserciziocorr, secondaryprev=prevseceserciziocorr, previousprevision=prevesercizioprec, "+
				             "previoussecondaryprev=prevsecesercizioprec, currentarrears=ripartizionecorr, "+
				             "previousarrears=ripartizioneprec, "+
                             //---
                            "title=denominazione,lt=lastmodtimestamp,lu=lastmoduser,livsupidbilancio,"+
                            //parte di finlast ----
                            "codiceresponsabile,scadenza," +
                            //----
                            "txt=notes,rtf=olenotes,printingorder=ordinestampa,flagpartitegiro,flagtrasferimenti, " +
                            "conta=(select count(*) from bilancio b2 where b2.livsupidbilancio=bilancio.idbilancio) "+
                            "FROM BILANCIO where " +
                                "partebilancio = '" + finpart + "' AND " +
                                "esercizio = " + ayear.ToString() + " AND " +
                                "codicelivello = '" + nlevel.ToString() + "'");
                        if (All.Rows.Count == 0) continue;
                        Hashtable NextParent = new Hashtable();
                        DataTable Fin = destConn.CreateTableByName("fin","*");
                        foreach (DataRow Curr in All.Rows) {
                            DataRow R = Fin.NewRow();
                            maxidfin++;
                            R["idfin"] = maxidfin;
                            NextParent[Curr["idbilancio"].ToString().ToUpper()] = maxidfin;
                            if (nlevel > 1) R["paridfin"] = ParentID[Curr["livsupidbilancio"].ToString().ToUpper()];
                            R["ayear"] = ayear;
                            R["nlevel"] = nlevel;
                            int flag = (finpart == "E") ? 0 : 1;
                            if (Curr["flagpartitegiro"].ToString().ToUpper() == "S") flag += 2;
                            if (Curr["flagtrasferimenti"].ToString().ToUpper() == "S") flag += 4;
                            R["flag"] = flag;
                            foreach (string S in new string[] {"codefin","ct","cu","title","lt","lu","txt","rtf","printingorder"}) {
                                R[S] = Curr[S];
                            }
                            Fin.Rows.Add(R);
                        }
                        ParentID = NextParent;
                        DataSet ds = new DataSet();
                        ds.Tables.Add(Fin);

                        bool res= Migrazione.lanciaScript(form, destConn, ds, "Popolamento Fin/"+ayear.ToString()+"/"+
                                        finpart+"/liv"+nlevel.ToString());
                        if (!res) return false;

                        int minlivoperativo = CfgFn.GetNoNullInt32( sourceConn.DO_READ_VALUE("livellobilancio",
                                    "esercizio = "+ ayear.ToString()+" AND flagoperativo='S'", "min(codicelivello)"));

                        if (nlevel >= minlivoperativo) {
                            //Importa dati di FinYear
                            DataTable FinYear = destConn.CreateTableByName("finyear", "*");
                            foreach (DataRow Curr in All.Rows) {
                                DataRow R = FinYear.NewRow();
                                R["idfin"] = ParentID[Curr["idbilancio"].ToString().ToUpper()];
                                R["ayear"] = ayear;
                                R["idupb"] = getIdupbFromFinAndCen(Curr["idbilancio"].ToString().ToUpper(),
                                                                        DBNull.Value, null);
                                foreach (string S in new string[] { "ct", "cu", "lt", "lu","prevision","secondaryprev",
                                    "previousprevision","previoussecondaryprev","currentarrears","previousarrears"}) {
                                    R[S] = Curr[S];
                                }

                                FinYear.Rows.Add(R);
                            }
                            ds = new DataSet();
                            ds.Tables.Add(FinYear);
                            res = Migrazione.lanciaScript(form, destConn, ds, "Popolamento FinYear/" + ayear.ToString() + "/" +
                                                                     finpart + "/liv" + nlevel.ToString());
                            if (!res) return false;
                        }
                        //Importa dati di finlast
                        if (nlevel < fasemax) continue;
                        DataTable FinLast = destConn.CreateTableByName("finlast", "*");
                        foreach (DataRow Curr in All.Select("conta=0")) {
                            DataRow R = FinLast.NewRow();
                            R["idfin"]= ParentID[Curr["idbilancio"].ToString().ToUpper()];
                            R["expiration"] = Curr["scadenza"];
                            if (Curr["codiceresponsabile"] != DBNull.Value) {
                                R["idman"] = Patrimonio.lookupidman[Curr["codiceresponsabile"].ToString().ToUpper()];
                            }
                            foreach (string S in new string[] { "ct", "cu", "lt", "lu" }) {
                                R[S] = Curr[S];
                            }
                            FinLast.Rows.Add(R);
                        }
                        ds = new DataSet();
                        ds.Tables.Add(FinLast);
                        res = Migrazione.lanciaScript(form, destConn, ds, "Popolamento FinLast/" + ayear.ToString() + "/" +
                                                                 finpart + "/liv" + nlevel.ToString());
                        if (!res) return false;

                        

                    }
                }
            }

            
            return true;
		}
        public static string getExtAccess(DataAccess Conn, string table, bool dbo) {
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo." + table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
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
		public static bool migraVariazioni(Form form, DataAccess sourceConn, DataAccess destConn) {
            migraBilancio(form, sourceConn, destConn);

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
					+ "variationkind=case tipovariazione when 'N' then 1 when 'R' then 2  "
                    + " when 'A' then 3 when 'S' then 4 end, "
                    +" nenactment=numprovved, "
					+ "enactmentdate=dataprovved, adate=datacontabile, txt=notes, "
					+ "rtf=olenotes, cu=createuser, ct=createtimestamp, "
					+ "lu=lastmoduser, lt=lastmodtimestamp, ";

				string queryVar = queryV
					+ "tipo=case tipoprevisione when 'P' then "
					+ VARBILPRIM+" else "
					+ VARBILSEC+" end, "
					+ "flagprevision=case tipoprevisione when 'P' then 'S' else 'N' end,"
                    + "flagcredit='N', flagproceeds='N', official='S',nofficial=numvariazione,"
					+ "flagsecondaryprev=case tipoprevisione when 'P' then 'N' else 'S' end "
					+ "from variazionebilancio where esercvariazione="+esercVariazione
					+ " union all "
					+ queryV
					+ "tipo="
					+ VARCREDITI
                    + ", flagprevision='N', flagcredit='S', flagproceeds='N', official='N',nofficial=null,"
                    + "flagsecondaryprev='N' "
					+ "from variazionecrediti where esercvariazione="+esercVariazione
					+ " union all "
					+ queryV
					+ "tipo="
					+ VARCASSA
					+ ", flagprevision='N', flagcredit='N', flagproceeds='S', official='N',nofficial=null,"
                    + " flagsecondaryprev='N' "
					+ "from variazionecassa where esercvariazione="+esercVariazione;
				//Copio variazionebilancio, variazionecrediti e variazionecassa in tFinVar
				DataTable tFinVar = Migrazione.eseguiQuery(sourceConn, queryVar, form);
				if (tFinVar==null) return false;

				string queryD = "select idupb='0001', yvar=D.esercvariazione, "
					+ "nvar=D.numvariazione, FIN.idfin, description=D.descrizione, "
					+ "amount=D.importo, cu=D.createuser, ct=D.createtimestamp, "
					+ "lu=D.lastmoduser, lt=D.lastmodtimestamp, tipo=";
                string joinfin = " JOIN BILANCIO B ON D.idbilancio=B.idbilancio " +
                             " JOIN " + getExtAccess(destConn, "fin", false) + " FIN ON " +
                             " FIN.codefin=B.codicebilancio AND " +
                             " FIN.ayear = CONVERT(INT,B.esercizio) ";
				string queryDett = queryD
					+ VARBILANCIO
					+ " from dettvarbilancio D "+joinfin +"where esercvariazione="+esercVariazione 
                         +" AND ( ((FIN.flag & 1)=0 AND B.partebilancio='E') OR ((FIN.flag & 1)<>0 AND B.partebilancio='S') ) "
					+ " union all "
					+ queryD
					+ VARCREDITI
					+ " from dettvarcrediti D "+joinfin+" where esercvariazione="+esercVariazione
                         + " AND ( ((FIN.flag & 1)=0 AND B.partebilancio='E') OR ((FIN.flag & 1)<>0 AND B.partebilancio='S') ) "
                    + " union all "
					+ queryD
					+ VARCASSA
					+ " from dettvarcassa D "+joinfin+" where esercvariazione="+esercVariazione
                    +   " AND ( ((FIN.flag & 1)=0 AND B.partebilancio='E') OR ((FIN.flag & 1)<>0 AND B.partebilancio='S') ) ";

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
		public static bool migraAssCentroEOS(string eos, Form form, DataAccess sourceConn, DataAccess destConn) {
            creaTabellaUpb(form, sourceConn, destConn);

			VistaUpb ds = new VistaUpb();
			string q1 = "select yvar, maxnvar=max(nvar) from finvar group by yvar";
			DataTable tContaFinVar = Migrazione.eseguiQuery(destConn, q1, form);
			if (tContaFinVar==null) return false;

			string[] discriminante = null;
			string query = "";

			if (eos == "entrata") {
				discriminante = new string[] {"yvar"};
				query = "select yvar=D.esercassegnazione, idcen=D.idcentrospesa, "
					+ "D.idbilancio, FIN.idfin, amount=sum(D.importo), "
					+ "flagprevision='S', flagcredit='N', flagproceeds='N' "
					+ "from asscentroentrata D "
                    + " JOIN BILANCIO B ON D.idbilancio=B.idbilancio " +
                             " JOIN " + getExtAccess(destConn, "fin", false) + " FIN ON " +
                             " FIN.codefin=B.codicebilancio AND " +
                             " FIN.ayear = B.esercizio "
                +" WHERE  ( ((FIN.flag & 1)=0 AND B.partebilancio='E') OR ((FIN.flag & 1)<>0 AND B.partebilancio='S') ) "

                +"group by esercassegnazione, idcentrospesa, FIN.idfin,D.idbilancio";
			}
			else {
				discriminante = new string[] {"yvar", "flagprevision", "flagcredit", "flagproceeds"};
				query = "select yvar=esercassegnazione, idcen=D.idcentrospesa, "
                    + "D.idbilancio, FIN.idfin, amount=sum(importo), "
					+ "flagprevision=flagprevisione, flagcredit=flagcrediti, flagproceeds=flagincassi "
					+ "from asscentrospesa D "
                               + " JOIN BILANCIO B ON D.idbilancio=B.idbilancio " +
                             " JOIN " + getExtAccess(destConn, "fin", false) + " FIN ON " +
                             " FIN.codefin=B.codicebilancio AND " +
                             " FIN.ayear = B.esercizio "
                +" WHERE  ( ((FIN.flag & 1)=0 AND B.partebilancio='E') OR ((FIN.flag & 1)<>0 AND B.partebilancio='S') ) "
                + "group by esercassegnazione, idcentrospesa, FIN.idfin,D.idbilancio, flagprevisione, flagcrediti, flagincassi";
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
					rFinVar["variationkind"] = 4; //"S"
					rFinVar["yvar"] = r["yvar"];
					ds.finvar.Rows.Add(rFinVar);
					r["nvar"] = rFinVar["nvar"];
				} else {
					r["nvar"] = righeFinVar[0]["nvar"];
				}
			}

			foreach (DataRow r1 in tApp.Select()) {
				object idUpb = getIdupbFromFinAndCen(r1["idbilancio"], r1["idcen"], tCdsUpb);
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


		private static object getIdupbFromFinAndCen(object idFin, object idCen, DataTable tCdsUpb) {
			

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
                    query = "SELECT bilancio.codicebilancio, bilancio.esercizio, bilancio.partebilancio,"
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
                if (tCapitoloCalderoneConPrevNegativa_S!=null && tCapitoloCalderoneConPrevNegativa_S.Rows.Count > 0) {
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
                if (tCapitoloCalderoneConPrevNegativa_E != null && tCapitoloCalderoneConPrevNegativa_E.Rows.Count > 0) {
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

        public static bool migraReversali(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("proceeds", null, false) > 0) return true;

            migraElenchiReversali(form, sourceConn, destConn);
            migraCassiere(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            migraBilancio(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                 "SELECT REG.idreg, FIN.idfin, D.*, PT.kproceedstransmission from documentoincasso D " +
                 "left outer join creditoredebitore CR on D.codicecreddeb=CR.codicecreddeb " +
                 "left outer join " + getExtAccess(destConn, "registry", true) + " REG " +
                     " ON REG.title= CR.denominazione " +
                 "left outer join bilancio B ON B.idbilancio=D.idbilancio " +
                 "left outer join " + getExtAccess(destConn, "fin", false) + " FIN " +
                     " ON FIN.codefin= B.codicebilancio " +
                     " AND FIN.ayear = CONVERT(INT,B.esercizio) " +
                     " AND (FIN.flag & 1)=0 "+
                "left outer join "+getExtAccess(destConn,"proceedstransmission",false)+" PT "+
                " ON PT.yproceedstransmission= D.esercelenco " +
                " AND PT.nproceedstransmission= D.numelenco "

                );
            if (All.Rows.Count == 0) return true;
            DataTable Proceeds = destConn.CreateTableByName("proceeds", "*");
            int nmaxproceeds = 0;
            foreach (DataRow Curr in All.Rows) {
                nmaxproceeds++;
                DataRow R = Proceeds.NewRow();
                R["kpro"] = nmaxproceeds;
                R["npro"] = Curr["numdocincasso"];
                R["ypro"] = Curr["esercdocincasso"];
                R["kproceedstransmission"] = Curr["kproceedstransmission"];
                R["adate"] = Curr["datacontabile"];
                R["printdate"] = Curr["datastampa"];
                R["idreg"] = Curr["idreg"];
                R["idfin"] = Curr["idfin"];
                if (Curr["codiceistituto"] != DBNull.Value)
                    R["idtreasurer"] = lookupidtreasurer[Curr["codiceistituto"].ToString().ToUpper()];
                if (Curr["codiceresponsabile"] != DBNull.Value)
                    R["idman"] = Patrimonio.lookupidman[Curr["codiceresponsabile"].ToString().ToUpper()];
                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                int flag = 0;
                if (Curr["tipoincasso"].ToString().ToUpper() == "C") flag += 1;
                if (Curr["tipoincasso"].ToString().ToUpper() == "R") flag += 2;
                if (Curr["tipoincasso"].ToString().ToUpper() == "M") flag += 4;
                if (Curr["tipoconto"].ToString().ToUpper() == "F") flag += 8;
                R["flag"] = flag;
                Proceeds.Rows.Add(R);
            }


            DataSet ds = new DataSet();
            ds.Tables.Add(Proceeds);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Proceeds");
        }

        public static Hashtable lookupidtreasurer = new Hashtable();
        public static bool migraCassiere(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("treasurer", null, false) > 0) return true;
            DataTable All = sourceConn.SQLRunner("SELECT ct=createtimestamp,cu=createuser, lt=lastmodtimestamp, " +
                    "lu=lastmoduser,description=descrizione,cap, cin, idbank=codicebanca, codetreasurer=codiceistituto, "+
                    "idcab=codicesportello,city=comune,flagdefault=flagstandard,address=indirizzo, "+
                    "cc=numeroconto, country=provincia, faxnumber= telefaxnumero, faxprefix=telefaxprefisso, "+
                    "phonenumber=telefononumero, phoneprefix=telefonoprefisso from istitutocassiere");
            if (All.Rows.Count == 0) return true;
            DataTable Treasurer = destConn.CreateTableByName("treasurer", "*");
            int nmaxtreasurer = 0;
            foreach (DataRow Curr in All.Rows) {
                nmaxtreasurer++;
                DataRow R = Treasurer.NewRow();
                R["idtreasurer"] = nmaxtreasurer;
                lookupidtreasurer[Curr["codetreasurer"].ToString().ToUpper()] = nmaxtreasurer;
                foreach (string S in new string[] { "ct", "cu", "lt", "lu", "description", "flagdefault",
                    "cap","cin","idbank","codetreasurer","idcab","city","address","cc","country","faxnumber","faxprefix",
                       "phonenumber","phoneprefix"}) {
                    R[S] = Curr[S];
                }
                Treasurer.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Treasurer);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Treasurer");
        }

        public static bool migraSaldoCassiere(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("treasurerstart", null, false) > 0) return true;
            migraCassiere(form, sourceConn, destConn);
            DataTable All = sourceConn.SQLRunner(
                "SELECT M.codiceistituto,ct=M.createtimestamp,cu=M.createuser,ayear=M.esercizio,amount=M.importo," +
                "lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                "from saldoinizialecassiere M");
            if (All.Rows.Count == 0) return true;

            DataTable TrStart = destConn.CreateTableByName("treasurerstart", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = TrStart.NewRow();
                R["idtreasurer"] = lookupidtreasurer[Curr["codiceistituto"].ToString().ToUpper()];
                foreach (string S in new string[] { "ct", "cu", "ayear", "amount", "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                TrStart.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(TrStart);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento treasurerstart");

        }

        public static Hashtable lookupidstamphandling = new Hashtable();
        public static bool migraTrattBollo_eseguito = false;
        public static bool migraTrattBollo(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraTrattBollo_eseguito) return true;
            migraTrattBollo_eseguito = true;
            DataTable Existent = destConn.SQLRunner("SELECT * FROM stamphandling");
            foreach (DataRow RC in Existent.Rows) {
                lookupidstamphandling[RC["handlingbankcode"].ToString().ToUpper()] = RC["idstamphandling"];
            }
            CQueryHelper QHC = new CQueryHelper();
            DataTable All = sourceConn.SQLRunner("SELECT ct=createtimestamp,cu=createuser, lt=lastmodtimestamp, " +
                    "lu=lastmoduser,description=descrizione, flagdefault=flagstandard, codicetrattamento from trattamentobollo");
            if (All.Rows.Count == 0) return true;
            DataTable Stamphandling = destConn.CreateTableByName("stamphandling", "*");
            int nmaxstamphandling = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("stamphandling",null,"max(idstamphandling)"));
            foreach (DataRow Curr in All.Rows) {
                string code=Curr["codicetrattamento"].ToString().ToUpper();
                if (lookupidstamphandling[code]!=null)continue;
                //Cerca nella descrizione (chiave alternat.)
                string find = QHC.CmpEq("description", Curr["description"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidstamphandling[code] = found[0]["idstamphandling"];
                    continue;
                }
                nmaxstamphandling++;
                DataRow R = Stamphandling.NewRow();                
                R["idstamphandling"] = nmaxstamphandling;
                R["active"] = "S";
                R["handlingbankcode"] = Curr["codicetrattamento"];
                lookupidstamphandling[Curr["codicetrattamento"].ToString().ToUpper()] = nmaxstamphandling;
                foreach (string S in new string[] {"ct","cu","lt","lu","description","flagdefault" }) {
                    R[S] = Curr[S];
                }
                Stamphandling.Rows.Add(R);
            }
            if (Stamphandling.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Stamphandling);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Stamphandling");
        }

        public static bool migraElenchiReversali(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("proceedstransmission", null, false) > 0) return true;
            migraCassiere(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT M.codiceistituto, M.codiceresponsabile, ct=M.createtimestamp," +
                " cu=M.createuser,transmissiondate=M.datatrasmissione,yproceedstransmission=M.esercelenco," +
                "lt=M.lastmodtimestamp,lu=M.lastmoduser, nproceedstransmission=M.numelenco " +
                " FROM trasmdocincasso M ");
            if (All.Rows.Count == 0) return true;
            DataTable ProcTrasm = destConn.CreateTableByName("proceedstransmission", "*");
            int nmaxproctrasm = 0;
            foreach (DataRow Curr in All.Rows) {
                nmaxproctrasm++;
                DataRow R = ProcTrasm.NewRow();
                R["kproceedstransmission"] = nmaxproctrasm;
                if (Curr["codiceistituto"] != DBNull.Value)
                    R["idtreasurer"] = lookupidtreasurer[Curr["codiceistituto"].ToString().ToUpper()];
                if (Curr["codiceresponsabile"] != DBNull.Value)
                    R["idman"] = Patrimonio.lookupidman[Curr["codiceresponsabile"].ToString().ToUpper()];
                foreach (string S in new string[] {  "ct", "cu", "transmissiondate", "yproceedstransmission",
                            "lt", "lu", "nproceedstransmission" }) {
                    R[S] = Curr[S];
                }
                ProcTrasm.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(ProcTrasm);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Proceedstransmission");
        }


        public static bool migraElenchiMandati(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("paymenttransmission", null, false) > 0) return true;
            migraCassiere(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT M.codiceistituto, M.codiceresponsabile, ct=M.createtimestamp," +
                " cu=M.createuser,transmissiondate=M.datatrasmissione,ypaymenttransmission=M.esercelenco," +
                "lt=M.lastmodtimestamp,lu=M.lastmoduser, npaymenttransmission=M.numelenco " +
                " FROM trasmdocpagamento M ");
            if (All.Rows.Count == 0) return true;
            DataTable PaymentTrasm = destConn.CreateTableByName("paymenttransmission", "*");
            int nmaxpaytrasm = 0;
            foreach (DataRow Curr in All.Rows) {
                nmaxpaytrasm++;
                DataRow R = PaymentTrasm.NewRow();
                R["kpaymenttransmission"] = nmaxpaytrasm;
                if (Curr["codiceistituto"] != DBNull.Value)
                    R["idtreasurer"] = lookupidtreasurer[Curr["codiceistituto"].ToString().ToUpper()];
                if (Curr["codiceresponsabile"] != DBNull.Value)
                    R["idman"] = Patrimonio.lookupidman[Curr["codiceresponsabile"].ToString().ToUpper()];
                foreach (string S in new string[] {  "ct", "cu", "transmissiondate", "ypaymenttransmission",
                            "lt", "lu", "npaymenttransmission" }) {
                    R[S] = Curr[S];
                }
                PaymentTrasm.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(PaymentTrasm);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento PaymentTrasm");
            
        }
        
        public static bool migraMandati(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("payment", null, false) > 0) return true;

            migraElenchiMandati(form, sourceConn, destConn);
            migraCassiere(form, sourceConn, destConn);
            migraTrattBollo(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            migraBilancio(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT REG.idreg, FIN.idfin, D.*, PT.kpaymenttransmission from documentopagamento D " +
                "left outer join creditoredebitore CR on D.codicecreddeb=CR.codicecreddeb " +
                "left outer join " + getExtAccess(destConn, "registry", true) + " REG " +
                    " ON REG.title= CR.denominazione "+
                "left outer join bilancio B ON B.idbilancio=D.idbilancio "+
                "left outer join "+getExtAccess(destConn,"fin",false)+" FIN "+
                    " ON FIN.codefin= B.codicebilancio "+
                    " AND FIN.ayear = CONVERT(INT,B.esercizio) "+
                    " AND (FIN.flag & 1)<>0 "+
                "left outer join "+getExtAccess(destConn,"paymenttransmission",false)+" PT "+
                " ON PT.ypaymenttransmission= D.esercelenco " +
                " AND PT.npaymenttransmission= D.numelenco "
               );
            if (All.Rows.Count == 0) return true;
            DataTable Payment = destConn.CreateTableByName("payment","*");
            int nmaxpayment = 0;
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Payment.NewRow();
                nmaxpayment++;
                R["kpay"] = nmaxpayment;
                R["npay"] = Curr["numdocpagamento"];
                R["ypay"] = Curr["esercdocpagamento"];
                R["kpaymenttransmission"] = Curr["kpaymenttransmission"];
                R["adate"] = Curr["datacontabile"];
                R["printdate"] = Curr["datastampa"];
                R["idreg"] = Curr["idreg"];
                R["idfin"] = Curr["idfin"];
                R["idtreasurer"] = gethash(lookupidtreasurer, Curr["codiceistituto"].ToString());
                R["idstamphandling"] = gethash(lookupidstamphandling, Curr["codicetrattamento"].ToString());
                R["idman"] = gethash(Patrimonio.lookupidman, Curr["codiceresponsabile"].ToString());
                R["txt"] = Curr["notes"];
                R["rtf"] = Curr["olenotes"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                int flag = 0;
                if (Curr["tipopagamento"].ToString().ToUpper() == "C") flag += 1;
                if (Curr["tipopagamento"].ToString().ToUpper() == "R") flag += 2;
                if (Curr["tipopagamento"].ToString().ToUpper() == "M") flag += 4;
                R["flag"] = flag;
                Payment.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Payment);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento payment");
        }

        public static Hashtable lookupautokind = new Hashtable();
        public static void RiempiLookupAutoKind() {
            lookupautokind["APFPS"]=(int) 1;
            lookupautokind["LIQRT"]=(int) 2;
            lookupautokind["REFPS"]=(int) 3;
            lookupautokind["RITEN"]=(int) 4;
            lookupautokind["RIEMI"]=(int) 5;
            lookupautokind["RECUP"]=(int) 6;
            lookupautokind["CHFPS"]=(int) 7;
            lookupautokind["CONTR"]=(int) 8;
            lookupautokind["ECONO"]=(int) 9;
            lookupautokind["ANPAR"]=(int) 10;
            lookupautokind["ANNUL"]=(int) 11;
            lookupautokind["LPIVA"]=(int) 12;
            lookupautokind["ACIVA"]=(int) 13;

        }

        public static Hashtable lookupmovkind = new Hashtable();
        public static void RiempiLookupMovKind() {
            lookupmovkind["ORDIN"] = (int)1; //Totale
            lookupmovkind["DOCUM"] = (int)1; //Totale
            lookupmovkind["IMPON"] = (int)3; //Solo Imponibile
            lookupmovkind["IMPOS"] = (int)2; //Solo Imposta
            lookupmovkind["SALDO"] = (int)4; //Totale
            lookupmovkind["ANGIR"] = (int)5; //Totale
            lookupmovkind["ANPAG"] = (int)6; //Totale

        }
        public static bool migraEntrata(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("income", null, false) > 0) return true;
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            migraSpesa(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);
            migraReversali(form, sourceConn, destConn);
            RiempiLookupAutoKind();

            int fasemax = CfgFn.GetNoNullInt32( sourceConn.DO_READ_VALUE("entrata",null,"MAX(codicefase)"));
            int annomin = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("entrata", null, "MIN(esercmovimento)"));
            int annomax = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("entrata", null, "MAX(esercmovimento)"));

            int maxidinc = 0;
            //Migra il mov. per anno e livelli
            for (int ymov = annomin; ymov <= annomax; ymov++) {
                for (int nphase = 1; nphase <= fasemax; nphase++) {
                    string sql =
                        "SELECT REG.idreg, E.codiceresponsabile, cu=E.createuser, ct=E.createtimestamp, " +
                        "adate=E.datacontabile, docdate=E.datadocumento, expiration=E.datascadenza,  " +
                        "description= E.descrizione, doc=E.documento, idpayment=EX.idexp," +
                        "lt=E.lastmodtimestamp, lu=E.lastmoduser, parentidinc=PAR.idinc, " +
                        "txt=E.notes, nmov=E.nummovimento, rtf=E.olenotes, E.tipoautomatismo, " +
                        //dati per incomelast
                        " PT.kpro, E.flagcopertura,idpro=MB.numoperazione  " +
                        " FROM ENTRATA E "+
                        " LEFT OUTER JOIN creditoredebitore cr on cr.codicecreddeb=E.codicecreddeb " +
                        " LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG ON REG.title=cr.denominazione " +
                        " LEFT OUTER JOIN spesa S on S.idspesa=E.idpagamento " +
                        " LEFT OUTER JOIN " + getExtAccess(destConn, "expense", false) + " EX " +
                            "ON EX.nphase= convert(int,S.codicefase) " +
                            "AND EX.ymov= S.esercmovimento " +
                            "AND EX.nmov= S.nummovimento " +
                        " LEFT OUTER JOIN entrata E2 ON E2.identrata = E.livsupidentrata " +
                        " LEFT OUTER JOIN " + getExtAccess(destConn, "income", false) + " PAR " +
                            "ON PAR.nphase = convert(int,E2.codicefase) " +
                            "AND PAR.ymov = E2.esercmovimento " +
                            "AND PAR.nmov = E2.nummovimento " +
                         "LEFT OUTER JOIN movimentobancario MB " +
                            " ON e.esercmovbancario = mb.esercmovbancario " +
                            "AND e.nummovbancario = mb.nummovbancario " +
                         "LEFT OUTER JOIN " + getExtAccess(destConn, "proceeds", false) + " PT " +
                            " ON PT.ypro=E.esercdocincasso " +
                            " AND PT.npro=E.numdocincasso " +

                        "WHERE E.codicefase='" + nphase.ToString() + "' AND E.esercmovimento=" + ymov.ToString();
                    DataTable All = sourceConn.SQLRunner(sql);
                    if (All.Rows.Count == 0) continue;
                    DataTable Income = destConn.CreateTableByName("income", "*");
                    DataTable IncomeLast= destConn.CreateTableByName("incomelast","*");

                    foreach (DataRow Curr in All.Rows) {
                        maxidinc++;
                        DataRow R = Income.NewRow();
                        R["idinc"] = maxidinc;
                        R["idman"] = gethash(Patrimonio.lookupidman, Curr["codiceresponsabile"].ToString());
                        R["ymov"] = ymov;
                        R["nphase"] = nphase;
                        if (Curr["tipoautomatismo"] != DBNull.Value) {
                            R["autokind"] = lookupautokind[Curr["tipoautomatismo"].ToString().ToUpper()];
                        }
                        foreach (string S in new string[] {"idreg","cu","ct","adate","docdate","expiration",
                                    "description","doc","idpayment","lt","lu","parentidinc","txt","nmov",
                                    "rtf"}) {
                            R[S] = Curr[S];
                        }
                        Income.Rows.Add(R);
                        if (nphase == fasemax) {
                            DataRow RR = IncomeLast.NewRow();
                            RR["idinc"] = maxidinc;
                            foreach (string S in new string[] {"cu","ct","lt","lu","kpro","idpro"}) {
                                RR[S] = Curr[S];
                            }
                            if (Curr["flagcopertura"].ToString().ToUpper() == "S")
                                RR["flag"] = 1;
                            else
                                RR["flag"] = 0;
                            IncomeLast.Rows.Add(RR);

                        }
                    }
   
                    DataSet ds = new DataSet();
                    ds.Tables.Add(Income);
                    if (nphase == fasemax) {
                        ds.Tables.Add(IncomeLast);
                    }
                    bool res= Migrazione.lanciaScript(form, destConn, ds, "Popolamento Income/"+ymov.ToString()+"-fase "+nphase.ToString());
                    if (!res) return false;                

                }
            }

            return true;
        }


        public static bool migraSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expense", null, false) > 0) return true;
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            Patrimonio.EsportaResponsabile(form, sourceConn, destConn);
            Anagrafica.migraModalitaPagamento(form, sourceConn, destConn);
            Missione.MigraTipoPrestazione(form, sourceConn, destConn);
            migraMandati(form, sourceConn, destConn);
            RiempiLookupAutoKind();

            int fasemax = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("spesa", null, "MAX(codicefase)"));
            int annomin = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("spesa", null, "MIN(esercmovimento)"));
            int annomax = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("spesa", null, "MAX(esercmovimento)"));

            int maxidexp = 0;
            //Migra il mov. per anno e livelli
            for (int ymov = annomin; ymov <= annomax; ymov++) {
                foreach (bool is_automatismo in new bool[] { false, true }) {
                    string whereautom = is_automatismo ? " AND (E.idpagamento is null)" : " AND (E.idpagamento is not null)";
                    for (int nphase = 1; nphase <= fasemax; nphase++) {
                        string sql =
                               "SELECT E.flagcopertura, REG.idreg, E.codiceresponsabile, cu=E.createuser, ct=E.createtimestamp, " +
                            "adate=E.datacontabile, docdate=E.datadocumento, expiration=E.datascadenza," +
                            "description= E.descrizione, doc=E.documento, idpayment=EX.idexp," +
                            "lt=E.lastmodtimestamp, lu=E.lastmoduser, parentidexp=PAR.idexp, " +
                            "txt=E.notes, nmov=E.nummovimento, rtf=E.olenotes, E.tipoautomatismo, " +
                            //dati per expenselast
                            "PT.kpay , E.flagautoritenute, E.flagautorecuperi, " +
                            "cc=E.numeroconto, cin=E.cin, idbank=E.codicebanca, idcab=E.codicesportello," +
                            "E.codicemodalita, RPM.idregistrypaymethod, servicestart=E.datainizioprestazione, " +
                            "servicestop=E.datafineprestazione, paymentdescr=E.descpagamento, ivaamount=E.importoprestazione1," +
                            "E.codiceprestazione, idpay=MB.numoperazione " +
                            " FROM SPESA E "+
                            " LEFT OUTER JOIN creditoredebitore cr on cr.codicecreddeb=E.codicecreddeb " +
                            " LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG ON REG.title=cr.denominazione " +
                            " LEFT OUTER JOIN spesa S on S.idspesa=E.idpagamento " +
                            " LEFT OUTER JOIN " + getExtAccess(destConn, "expense", false) + " EX " +
                                "ON EX.nphase= convert(int,S.codicefase) " +
                                "AND EX.ymov= S.esercmovimento " +
                                "AND EX.nmov= S.nummovimento " +
                            " LEFT OUTER JOIN spesa E2 ON E2.idspesa = E.livsupidspesa " +
                            " LEFT OUTER JOIN " + getExtAccess(destConn, "expense", false) + " PAR " +
                                "ON PAR.nphase = convert(int,E2.codicefase) " +
                                "AND PAR.ymov = E2.esercmovimento " +
                                "AND PAR.nmov = E2.nummovimento " +
                            " LEFT OUTER JOIN " + getExtAccess(destConn, "registrypaymethod", true) + " RPM " +
                                "ON RPM.idreg= REG.idreg " +
                                "AND RPM.regmodcode= E.tipomodalita " +
                            "LEFT OUTER JOIN movimentobancario MB " +
                                " ON S.esercmovbancario = mb.esercmovbancario " +
                                "AND S.nummovbancario = mb.nummovbancario " +
                            "LEFT OUTER JOIN " + getExtAccess(destConn, "payment", false) + " PT " +
                            " ON PT.ypay=E.esercdocpagamento " +
                            " AND PT.npay=E.numdocpagamento " +
                           "WHERE E.codicefase='" + nphase.ToString() + "' AND E.esercmovimento=" + ymov.ToString()
                                + whereautom;
                        DataTable All = sourceConn.SQLRunner(sql);
                        if (All.Rows.Count == 0) continue;
                        DataTable Expense = destConn.CreateTableByName("expense", "*");
                        DataTable ExpenseLast = destConn.CreateTableByName("expenselast", "*");

                        foreach (DataRow Curr in All.Rows) {
                            maxidexp++;
                            DataRow R = Expense.NewRow();
                            R["idexp"] = maxidexp;
                            if (Curr["codiceresponsabile"] != DBNull.Value) {
                                R["idman"] = Patrimonio.lookupidman[Curr["codiceresponsabile"].ToString().ToUpper()];
                            }
                            R["ymov"] = ymov;
                            R["nphase"] = nphase;
                            if (Curr["tipoautomatismo"] != DBNull.Value) {
                                R["autokind"] = lookupautokind[Curr["tipoautomatismo"].ToString().ToUpper()];
                            }
                            foreach (string S in new string[] {"idreg","cu","ct","adate","docdate","expiration",
                                    "description","doc","idpayment","lt","lu","parentidexp","txt","nmov",
                                    "rtf"}) {
                                R[S] = Curr[S];
                            }
                            Expense.Rows.Add(R);
                            if (nphase == fasemax) {
                                DataRow RR = ExpenseLast.NewRow();
                                RR["idexp"] = maxidexp;
                                RR["idpaymethod"] = gethash(Anagrafica.lookupidpaymethod, Curr["codicemodalita"].ToString());
                                RR["idser"] = gethash(Missione.lookupidser, Curr["codiceprestazione"].ToString());

                                foreach (string S in new string[] { "cu", "ct", "lt", "lu", "kpay", "idregistrypaymethod",
                                        "servicestart","servicestop","paymentdescr","ivaamount","idpay"}) {
                                    RR[S] = Curr[S];
                                }
                                int flag = 0;
                                if (Curr["flagcopertura"].ToString().ToUpper() == "S") flag+=1;
                                if (Curr["flagautoritenute"].ToString().ToUpper() == "S") flag += 2;
                                if (Curr["flagautorecuperi"].ToString().ToUpper() == "S") flag += 4;
                                RR["flag"] = flag;
                                ExpenseLast.Rows.Add(RR);

                            }
                        }

                        DataSet ds = new DataSet();
                        ds.Tables.Add(Expense);
                        if (nphase == fasemax) {
                            ds.Tables.Add(ExpenseLast);
                        }
                        bool res = Migrazione.lanciaScript(form, destConn, ds, "Popolamento Expense/" + ymov.ToString() + "-fase " + nphase.ToString());
                        if (!res) return false;

                    }
                }
            }

            return true;
        }


        public static bool migraVariazioniSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expensevar", null, false) > 0) return true;

            Iva.migraTipoDocumentoIva(form, sourceConn, destConn);
            Upb.RiempiLookupAutoKind();
            Upb.RiempiLookupMovKind();
            migraSpesa(form, sourceConn, destConn);

            string query = "SELECT EXP.idexp, " +
            " nvar = M.numvariazione, adate = M.datacontabile, amount = M.importo, " +
            "  M.tipoautomatismo, ct = M.createtimestamp, cu = M.createuser, lt = M.lastmodtimestamp, " +
            " lu = M.lastmoduser, description = M.descrizione, doc = M.documento, docdate = M.datadocumento, " +
            " rtf = M.olenotes, txt = M.notes,  VI.tipomovimento, " +
            " yvar = M.esercvariazione, VI.codicetipodoc , yinv = VI.esercdocumento, ninv = VI.numdocumento, " +
            " idpayment= ME.idexp " +
            " FROM variazionespesa M " +
            " LEFT OUTER JOIN IVAVARSPESA VI " +
            " ON M.idspesa = VI.idspesa " +
            " AND M.numvariazione = VI.numvariazione " +
            " JOIN SPESA S ON M.idspesa=S.idspesa " +
            " JOIN " + getExtAccess(destConn, "expense", false) + " EXP " +
            "  ON EXP.ymov=S.esercmovimento " +
            "  AND EXP.nmov=S.nummovimento " +
            "  AND EXP.nphase = convert(int,S.codicefase) " +
            " LEFT OUTER JOIN spesa PARSPESA ON M.idpagamento=PARSPESA.idspesa " +
            " LEFT OUTER JOIN " + getExtAccess(destConn, "expense", false) + " ME " +
            "  ON ME.ymov=PARSPESA.esercmovimento " +
            "  AND ME.nmov=PARSPESA.nummovimento " +
            "  AND ME.nphase = convert(int,PARSPESA.codicefase) ";

            DataTable All = DataAccess.SQLRunner(sourceConn, query);

            if (All == null) {
                string msg = "Errore nella migrazione delle variazioni di spesa";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }
            DataTable ExpenseVar = destConn.CreateTableByName("expensevar", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = ExpenseVar.NewRow();
                if (Curr["codicetipodoc"] != DBNull.Value)
                    R["idinvkind"] = Iva.lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                if (Curr["tipoautomatismo"] != DBNull.Value)
                    R["autokind"] = Upb.lookupautokind[Curr["tipoautomatismo"].ToString().ToUpper()];
                if (Curr["tipomovimento"] != DBNull.Value)
                    R["movkind"] = Upb.lookupmovkind[Curr["tipomovimento"].ToString().ToUpper()];
                foreach (string S in new string[] {"ct","cu","adate","docdate","description","doc",
                                "yvar","idpayment","idexp","amount","lt","lu","txt","nvar","rtf"})
                    R[S] = Curr[S];
                ExpenseVar.Rows.Add(R);
            }



            DataSet ds = new DataSet();
            ds.Tables.Add(ExpenseVar);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ExpenseVar");
        }

        public static bool migraVariazioniEntrata(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("incomevar", null, false) > 0) return true;

            Iva.migraTipoDocumentoIva(form, sourceConn, destConn);
            Upb.RiempiLookupAutoKind();
            Upb.RiempiLookupMovKind();
            migraEntrata(form, sourceConn, destConn);

            string query = "SELECT INC.idinc, " +
            " nvar = M.numvariazione, adate = M.datacontabile, amount = M.importo, " +
            " ct = M.createtimestamp, cu = M.createuser, lt = M.lastmodtimestamp, " +
            " lu = M.lastmoduser, description = M.descrizione, doc = M.documento, docdate = M.datadocumento, " +
            " rtf = M.olenotes, txt = M.notes, VI.tipomovimento, " +
            " yvar = M.esercvariazione, VI.codicetipodoc , yinv = VI.esercdocumento, ninv = VI.numdocumento " +
            " FROM variazioneentrata M " +
            " LEFT OUTER JOIN IVAVARENTRATA VI " +
            " ON M.identrata = VI.identrata " +
            " AND M.numvariazione = VI.numvariazione " +
            " JOIN ENTRATA E ON M.identrata=E.identrata " +
            " JOIN " + getExtAccess(destConn, "income", false) + " INC " +
            "  ON INC.ymov=E.esercmovimento " +
            "  AND INC.nmov=E.nummovimento " +
            "  AND INC.nphase = convert(int,E.codicefase) ";

            DataTable All = DataAccess.SQLRunner(sourceConn, query);

            if (All == null) {
                string msg = "Errore nella migrazione delle variazioni di entrata";
                MessageBox.Show(form, msg, "Errore");
                return false;
            }
            DataTable IncomeVar = destConn.CreateTableByName("incomevar", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = IncomeVar.NewRow();
                R["idinvkind"] = gethash(Iva.lookupidinvkind, Curr["codicetipodoc"].ToString());
                R["autokind"] = DBNull.Value;
                R["movkind"] = gethash(Upb.lookupmovkind, Curr["tipomovimento"].ToString());
                foreach (string S in new string[] {"ct","cu","adate","docdate","description","doc",
                                "yvar","idinc","amount","lt","lu","txt","nvar","rtf"})
                    R[S] = Curr[S];
                IncomeVar.Rows.Add(R);
            }



            DataSet ds = new DataSet();
            ds.Tables.Add(IncomeVar);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento IncomeVar");
        }

        public static bool migraTipoRecupero_eseguito = false;
        public static bool migraTipoRecupero(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraTipoRecupero_eseguito) return true;
            migraTipoRecupero_eseguito = true;
            Hashtable myhash = new Hashtable();
            DataTable Existent = destConn.SQLRunner("SELECT * from clawback");
            foreach (DataRow RC in Existent.Rows) {
                string codice=RC["clawbackref"].ToString().ToUpper();
                myhash[codice] = RC["idclawback"];
            }
            Existent.CaseSensitive = false;

            DataTable All = sourceConn.SQLRunner(
                "SELECT clawbackref=M.codicerecupero,ct=M.createtimestamp,cu=M.createuser,"+
                " description=M.descrizione,lt=M.lastmodtimestamp,lu=M.lastmoduser "+
                " from tiporecupero M");
            if (All.Rows.Count == 0) return true;
            CQueryHelper QHC= new CQueryHelper();
            DataTable Clawback = destConn.CreateTableByName("clawback", "*");
            int nmaxclawback = CfgFn.GetNoNullInt32( destConn.DO_READ_VALUE("clawback",null,"max(idclawback)"));
            foreach (DataRow Curr in All.Rows) {
                string codice = Curr["clawbackref"].ToString().ToUpper();
                if (myhash[codice] != null) continue;
                string find = QHC.CmpEq("description", Curr["description"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    myhash[codice] = found[0]["idclawback"];
                    continue;
                }
                nmaxclawback++;
                DataRow R = Clawback.NewRow();
                R["idclawback"] = nmaxclawback;
                foreach (string S in new string[] { "ct", "cu", "description", "lt", "lu","clawbackref" }) {
                    R[S] = Curr[S];
                }
                Clawback.Rows.Add(R);
            }
            if (Clawback.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Clawback);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Clawback");
        }


        public static bool migraRecupero(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expenseclawback", null, false) > 0) return true;

            migraTipoRecupero(form,sourceConn,destConn);
            migraSpesa(form,sourceConn,destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT CL.idclawback ,ct=M.createtimestamp,cu=M.createuser," +
                "EXP.idexp ,amount=M.importo,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                "from dettagliorecuperi M" +
                " JOIN " + getExtAccess(destConn, "clawback", true) + " CL ON CL.clawbackref=M.codicerecupero " +
                " JOIN SPESA S ON S.idspesa=M.idspesa " +
                " JOIN " + getExtAccess(destConn, "expense", false) + " EXP " +
                "  ON EXP.ymov=S.esercmovimento " +
                "  AND EXP.nmov=S.nummovimento " +
                " AND EXP.nphase = convert(int,S.codicefase)");
            if (All.Rows.Count == 0) return true;
            DataTable ExpClawback = destConn.CreateTableByName("expenseclawback", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = ExpClawback.NewRow();
                foreach (string S in new string[] { "idclawback", "ct", "cu", "idexp", "amount", "lt", "lu" }) {
                    R[S] = Curr[S];
                }

                ExpClawback.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(ExpClawback);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento expenseclawback");


        }

        /// <summary>
        /// Traduce dettaglioritenute e aggiunge la colonna nbracket=1
        /// </summary>
        /// <param name="form"></param>
        /// <param name="tColName"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        public static bool migraDettaglioRitenute(Form form,  DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expensetax", null, false) > 0) return true;
            Missione.MigraTipoRitenuta(form, sourceConn, destConn);
            migraSpesa(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                    "SELECT adminrate=D.aliquotaamministrazione, employrate=D.aliquotadipendente, " +
                    "ct=D.createtimestamp, cu=D.createuser, D.codiceritenuta, " +
                    "competencydate= D.datacompetenza, abatements=D.detrazioni, " +
                    "EXP.idexp, taxablegross=D.imponibile, " +
                    "lt=D.lastmodtimestamp, lu=D.lastmoduser, " +
                    "admindenominator=D.quotadenamministrazione, adminnumerator=D.quotanumamministrazione, " +
                    "employdenominator=D.quotadendipendente, employnumerator=D.quotanumdipendente, " +
                    "taxabledenominator=D.quotadenimponibile, taxablenumerator=D.quotanumimponibile, " +
                    "exemptionquota=D.quotaesente, admintax=D.ritamministrazione, employtax=D.ritdipendente " +
                    "from dettaglioritenute D " +
                    " JOIN spesa S on S.idspesa=D.idspesa " +
                     " JOIN " + getExtAccess(destConn, "expense", false) + " EXP " +
                     "  ON EXP.ymov=S.esercmovimento " +
                    "  AND EXP.nmov= S.nummovimento " +
                    "  AND EXP.nphase= convert(int,S.codicefase)"
                    );
            if (All.Rows.Count == 0) return true;
            DataTable ExpenseTax = destConn.CreateTableByName("expensetax", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = ExpenseTax.NewRow();
                R["nbracket"] = 1;
                R["taxcode"] = Missione.lookuptaxcode[Curr["codiceritenuta"].ToString().ToUpper()];
                R["taxablenet"] = CfgFn.GetNoNullDecimal(Curr["taxablegross"]) - CfgFn.GetNoNullDecimal(Curr["exemptionquota"]);
                foreach (string S in new string[] {"adminrate","employrate","ct","cu","competencydate","abatements",
                    "idexp","taxablegross","lt","lu","admindenominator","adminnumerator","employdenominator",
                    "employnumerator","taxabledenominator","taxablenumerator","exemptionquota","admintax","employtax"
                }) {
                    R[S] = Curr[S];
                }
                ExpenseTax.Rows.Add(R);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(ExpenseTax);

            return Migrazione.lanciaScript(form, destConn, ds, "dettaglioritenute -> expensetax");
        }


        public static bool migraRipAvanzoAmm(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("creditpart", null, false) > 0) return true;
            
            migraBilancio(form, sourceConn, destConn);
            migraEntrata(form, sourceConn, destConn);
            string sql =
                 "SELECT ct=M.createtimestamp,cu=M.createuser,adate=M.datacontabile,description=M.descrizione, " +
                " F.idfin ,I.idinc ,amount=M.importo,ycreditpart=M.esercassegnazione, " +
                " lt=M.lastmodtimestamp,lu=M.lastmoduser,txt=M.notes,ncreditpart=M.numassegnazione,rtf=M.olenotes " +
                " FROM " + ripavanzoamm + " M " +
                " JOIN BILANCIO B on B.idbilancio = M.idbilancio " +
                " JOIN " + getExtAccess(destConn, "fin", false) + " F " +
                "  ON F.codefin= B.codicebilancio " +
                "  AND F.ayear = B.esercizio " +
                "  AND (F.flag & 1)=0 " + // parte entrata
                " JOIN entrata E ON E.identrata=M.identrata " +
                " JOIN " + getExtAccess(destConn, "income", false) + " I " +
                "  ON I.ymov=E.esercmovimento " +
                "  AND I.nmov = E.nummovimento " +
                "  AND I.nphase= convert(int,E.codicefase) ";
            DataTable All = sourceConn.SQLRunner(sql);
            DataTable Creditpart = destConn.CreateTableByName("creditpart","*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Creditpart.NewRow();
                foreach (string S in new string[] { "ct", "cu", "adate", "description", "ycreditpart",
                    "idfin", "idinc", "amount", "lt", "lu", "txt", "ncreditpart", "rtf" }) {
                    R[S] = Curr[S];
                }
                Creditpart.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Creditpart);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento creditpart");


        }

        public static bool migraRipAvanzoCassa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("proceedspart", null, false) > 0) return true;

            migraBilancio(form, sourceConn, destConn);
            migraEntrata(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT ct=M.createtimestamp,cu=M.createuser,adate=M.datacontabile,description=M.descrizione, " +
                " F.idfin ,I.idinc ,amount=M.importo,yproceedspart=M.esercassegnazione, " +
                " lt=M.lastmodtimestamp,lu=M.lastmoduser,txt=M.notes,nproceedspart=M.numassegnazione,rtf=M.olenotes " +
                " FROM " + ripavanzocassa + " M " +
                " JOIN BILANCIO B on B.idbilancio = M.idbilancio " +
                " JOIN " + getExtAccess(destConn, "fin", false) + " F " +
                "  ON F.codefin= B.codicebilancio " +
                "  AND F.ayear = B.esercizio " +
                "  AND (F.flag & 1)=0 " + // parte entrata
                " JOIN entrata E ON E.identrata=M.identrata " +
                " JOIN " + getExtAccess(destConn, "income", false) + " I " +
                "  ON I.ymov=E.esercmovimento " +
                "  AND I.nmov = E.nummovimento " +
                "  AND I.nphase= convert(int,E.codicefase) " 
                );
            DataTable Proceedspart = destConn.CreateTableByName("proceedspart", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Proceedspart.NewRow();
                foreach (string S in new string[] { "ct", "cu", "adate", "description", "yproceedspart",
                    "idfin", "idinc", "amount", "lt", "lu", "txt", "nproceedspart", "rtf" }) {
                    R[S] = Curr[S];
                }
                Proceedspart.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Proceedspart);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento Proceedspart");
        }

        public static bool migraSitFinAmm(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("surplus", null, false) > 0) return true;

            DataTable All = sourceConn.SQLRunner(
                "SELECT ct=M.createtimestamp,cu=M.createuser,previsiondate=M.datapresunto,ayear=M.esercizio,"+
                "startfloatfund=M.fondocassa0101,proceedstilldate=M.incassi0101data,"+
                "competencyproceeds=M.incassicompetenza,proceedstoendofyear=M.incassidata3112,"+
                "residualproceeds=M.incassiresidui,lt=M.lastmodtimestamp,lu=M.lastmoduser,"+
                "paymentstilldate=M.pagamenti0101data,competencypayments=M.pagamenticompetenza,"+
                "paymentstoendofyear=M.pagamentidata3112,residualpayments=M.pagamentiresidui,currentrevenue=M.resattivicorr,"+
                "previousrevenue=M.resattiviprec,supposedcurrentrevenue=M.resattivipresunticorr,"+
                "supposedpreviousrevenue=M.resattivipresuntiprec,currentexpenditure=M.respassivicorr,"+
                "previousexpenditure=M.respassiviprec,supposedcurrentexpenditure=M.respassivipresunticorr,"+
                "supposedpreviousexpenditure=M.respassivipresuntiprec "+
                " FROM situazioneammin M "
                );
            DataTable Surplus = destConn.CreateTableByName("surplus", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Surplus.NewRow();
                foreach (string S in new string[] { "ct", "cu", "previsiondate", "ayear", "startfloatfund", "proceedstilldate", 
                    "competencyproceeds", "proceedstoendofyear", "residualproceeds", "lt", "lu", "paymentstilldate", 
                    "competencypayments", "paymentstoendofyear", "residualpayments", "currentrevenue", "previousrevenue", 
                    "supposedcurrentrevenue", "supposedpreviousrevenue", "currentexpenditure", "previousexpenditure", 
                    "supposedcurrentexpenditure", "supposedpreviousexpenditure" }) {
                    R[S] = Curr[S];
                }
                Surplus.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Surplus);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento Surplus");
        }

        public static bool migraConfigFasiCont(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("uniconfig", null, false) > 0) return true;
            object expfinphase = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("fasespesa", "(flagbilancio='S')", "min(codicefase)"));
            object expregphase = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("fasespesa", "(flagcreditoredebitore='S')", "min(codicefase)"));
            object incfinphase = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("fasespesa", "(flagbilancio='S')", "min(codicefase)"));
            object incregphase = CfgFn.GetNoNullInt32(sourceConn.DO_READ_VALUE("fasespesa", "(flagcreditoredebitore='S')", "min(codicefase)"));
            DataTable Uniconfig = destConn.CreateTableByName("uniconfig", "*");
            DataRow R = Uniconfig.NewRow();
            R["dummykey"] = 1;
            R["expensefinphase"] = expfinphase;
            R["incomefinphase"] = incfinphase;
            R["expenseregphase"] = expregphase;
            R["incomeregphase"] = incregphase;
            Uniconfig.Rows.Add(R);
            DataSet ds = new DataSet();
            ds.Tables.Add(Uniconfig);
            return Migrazione.lanciaScript(form, destConn, ds, "popolamento Uniconfig");


        }

        public static bool migraLivelloBil(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("finlevel", null, false) > 0) return true;

            DataTable All = sourceConn.SQLRunner(
                "SELECT tipocodice,lunghcodice,flagreset,flagoperativo,"+
                " nlevel=convert(int,M.codicelivello),ct=M.createtimestamp,cu=M.createuser,description=M.descrizione,"+
                " ayear=M.esercizio,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                " FROM livellobilancio M "
                );
            DataTable Finlevel = destConn.CreateTableByName("finlevel", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Finlevel.NewRow();
                int flag = 0;
                if (Curr["tipocodice"].ToString().ToUpper() == "A") flag += 1;
                if (Curr["flagoperativo"].ToString().ToUpper() == "S") flag += 2;
                if (Curr["flagreset"].ToString().ToUpper() == "S") flag += 4;
                int codelen = CfgFn.GetNoNullInt32(Curr["lunghcodice"]) * 256;
                flag += codelen;
                R["flag"] = flag;
                foreach (string S in new string[] { "nlevel", "ct", "cu", "description", "ayear", "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                Finlevel.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Finlevel);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento Finlevel");
        }


        public static bool migrafaseEntrata(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("incomephase", null, false) > 0) return true;

            DataTable All = sourceConn.SQLRunner(
                "SELECT nphase=convert(int,M.codicefase),ct=M.createtimestamp,cu=M.createuser,description=M.descrizione,"+
                " lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                " FROM faseentrata M "
                );
            DataTable Incomephase = destConn.CreateTableByName("incomephase", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Incomephase.NewRow();
                foreach (string S in new string[] { "nphase", "ct", "cu", "description",  "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                Incomephase.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Incomephase);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento Incomephase");
        }

        public static bool migrafaseSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expensephase", null, false) > 0) return true;

            DataTable All = sourceConn.SQLRunner(
                "SELECT nphase=convert(int,M.codicefase),ct=M.createtimestamp,cu=M.createuser,description=M.descrizione," +
                " lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                " FROM fasespesa M "
                );
            DataTable Expensephase = destConn.CreateTableByName("expensephase", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = Expensephase.NewRow();
                foreach (string S in new string[] { "nphase", "ct", "cu", "description",  "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                Expensephase.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Expensephase);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento Expensephase");
        }

        public static bool migraConvBilancio(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("finlookup", null, false) > 0) return true;

            migraBilancio(form, sourceConn, destConn);
            string sql = "SELECT ct=M.createtimestamp,cu=M.createuser,lt=M.lastmodtimestamp,lu=M.lastmoduser," +
                "newidfin = F_NEW.idfin, oldidfin=F_OLD.idfin " +
                "FROM convertbilancio M " +
                " JOIN BILANCIO B_OLD on B_OLD.idbilancio=M.oldidbilancio " +
                " JOIN " + getExtAccess(destConn, "fin", false) + " F_OLD " +
                "  ON F_OLD.codefin= B_OLD.codicebilancio " +
                "  AND F_OLD.ayear= B_OLD.esercizio " +
                "  AND ( ((F_OLD.flag & 1)=0 AND (B_OLD.partebilancio='E')) OR ((F_OLD.flag & 1)<>0 AND (B_OLD.partebilancio='S')) )" +
                " JOIN BILANCIO B_NEW on B_NEW.idbilancio=M.oldidbilancio " +
                " JOIN " + getExtAccess(destConn, "fin", false) + " F_NEW " +
                "  ON F_NEW.codefin= B_NEW.codicebilancio " +
                "  AND F_NEW.ayear= B_NEW.esercizio " +
                "  AND ( ((F_NEW.flag & 1)=0 AND (B_NEW.partebilancio='E')) OR ((F_NEW.flag & 1)<>0 AND (B_NEW.partebilancio='S')) )";
            DataTable All = sourceConn.SQLRunner(sql);
            if (All.Rows.Count > 0) {
                DataTable finlookup = destConn.CreateTableByName("finlookup", "*");
                foreach (DataRow Curr in All.Rows) {
                    DataRow R = finlookup.NewRow();
                    foreach (string S in new string[] {"lt","lu","ct","cu","newidfin","oldidfin" }) {
                        R[S] = Curr[S];
                    }
                    finlookup.Rows.Add(R);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(finlookup);

                if (! Migrazione.lanciaScript(form, destConn, ds, "popolamento finlookup")) return false;
            }
            
            return true;
        }


        public static bool migraRipartAutom(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("partincomesetup", null, false) > 0) return true;

            migraBilancio(form, sourceConn, destConn);
            string sql = "SELECT ct=M.createtimestamp,cu=M.createuser,lt=M.lastmodtimestamp,lu=M.lastmoduser," +
                "idfinexpense = F_EXP.idfin, idfinincome=F_INC.idfin, " +
                "txt = M.notes, rtf = M.olenotes, percentage = M.percentuale " +
                "FROM ripassegnazione M " +
                " LEFT OUTER JOIN BILANCIO B_ENT on B_ENT.idbilancio=M.idbilancioentrata " +
                " LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F_INC " +
                "  ON F_INC.codefin= B_ENT.codicebilancio " +
                "  AND F_INC.ayear= B_ENT.esercizio " +
                "  AND ((F_INC.flag & 1)=0) "+
                " LEFT OUTER JOIN BILANCIO B_SPE on B_SPE.idbilancio=M.idbilanciospesa " +
                " LEFT OUTER  JOIN " + getExtAccess(destConn, "fin", false) + " F_EXP " +
                "  ON F_EXP.codefin= B_SPE.codicebilancio " +
                "  AND F_EXP.ayear= B_SPE.esercizio "+
                "  AND ((F_EXP.flag & 1)<>0) ";
            DataTable All = sourceConn.SQLRunner(sql      );
            if (All.Rows.Count > 0) {
                DataTable Partincomesetup = destConn.CreateTableByName("partincomesetup", "*");
                foreach (DataRow Curr in All.Rows) {
                    DataRow R = Partincomesetup.NewRow();
                    foreach (string S in new string[] { "lt", "lu", "ct", "cu", "idfinexpense", "idfinincome" ,
                                "txt","rtf","percentage"}) {
                        R[S] = Curr[S];
                    }
                    Partincomesetup.Rows.Add(R);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(Partincomesetup);

                if (!Migrazione.lanciaScript(form, destConn, ds, "popolamento Partincomesetup")) return false;
            }

            return true;
        }

        public static bool MigraConfRecuperi(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("clawbacksetup", null, false) > 0) return true;
            migraTipoRecupero(form, sourceConn, destConn);
            DataTable All = sourceConn.SQLRunner(
                "SELECT clawbackfinance=F.idfin,CL.idclawback ,ct=M.createtimestamp," +
                "cu=M.createuser,ayear=M.esercizio,lt=M.lastmodtimestamp,lu=M.lastmoduser,txt=M.notes,rtf=M.olenotes " +
                "FROM automatismirecuperi M " +
                "JOIN " + getExtAccess(destConn, "clawback", true) + " CL " +
                " ON CL.clawbackref=M.codicerecupero " +
                "LEFT OUTER JOIN bilancio B on M.bilanciorecupero= B.idbilancio " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F " +
                "  ON F.codefin= B.codicebilancio " +
                "  AND F.ayear= B.esercizio " +
                "  AND ( ((F.flag & 1)=0 AND (B.partebilancio='E')) OR ((F.flag & 1)<>0 AND (B.partebilancio='S')) )");

            DataTable ClawBSetup = destConn.CreateTableByName("clawbacksetup", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = ClawBSetup.NewRow();
                foreach (string S in new string[] { "clawbackfinance", "idclawback", "ct", "cu", "ayear",
                    "lt", "lu", "txt", "rtf" }) {
                    R[S] = Curr[S];
                }
                ClawBSetup.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(ClawBSetup);

            return Migrazione.lanciaScript(form, destConn, ds, "popolamento clawbacksetup");

        }

        public static bool MigraConfRitenute(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("taxsetup", null, false) > 0) return true;
            Missione.MigraTipoRitenuta(form, sourceConn, destConn);
            migraBilancio(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            Anagrafica.RiempiLookupIdexpiration();

            //flag tinyint
            //flagregionalagency  -> bit 0 = N, bit 1 = S, bit 2 = P,  flagenteregionale
            //flagprevcurr -> bit 3 {C = 0; P = 1}  tipoperiodo
	
            DataTable All = sourceConn.SQLRunner(
                "SELECT idfinincomecontra=F1.idfin,idfinadmintax=F2.idfin," +
                "idfinexpensecontra=F3.idfin,M.codiceritenuta,ct=M.createtimestamp," +
                "cu=M.createuser,paymentagency=REG.idreg,ayear=M.esercizio,flagadminfinance=M.flagbilcontributi," +
                "M.flagenteregionale,expiringday=M.giornoscadenza,lt=M.lastmodtimestamp," +
                "lu=M.lastmoduser,txt=M.notes,rtf=M.olenotes,M.tipoperiodo, M.tiposcadenza " +
                "FROM automatismiritenute M " +
                "LEFT OUTER JOIN bilancio B1 ON B1.idbilancio = M.bilancioapplicazione " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F1 " +
                "  ON F1.codefin= B1.codicebilancio " +
                "  AND F1.ayear= B1.esercizio " +
                "  AND ( ((F1.flag & 1)=0 AND (B1.partebilancio='E')) OR ((F1.flag & 1)<>0 AND (B1.partebilancio='S')) )" +
                "LEFT OUTER JOIN bilancio B2 ON B2.idbilancio = M.bilanciocontributi " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F2 " +
                "  ON F2.codefin= B2.codicebilancio " +
                "  AND F2.ayear= B2.esercizio " +
                "  AND ( ((F2.flag & 1)=0 AND (B2.partebilancio='E')) OR ((F2.flag & 1)<>0 AND (B2.partebilancio='S')) )" +
                "LEFT OUTER JOIN bilancio B3 ON B3.idbilancio = M.bilancioversamento " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "fin", false) + " F3 " +
                "  ON F3.codefin= B3.codicebilancio " +
                "  AND F3.ayear= B3.esercizio " +
                "  AND ( ((F3.flag & 1)=0 AND (B3.partebilancio='E')) OR ((F3.flag & 1)<>0 AND (B3.partebilancio='S')) )" +
                "LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=M.enteversamento " +
                "LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG " +
                "ON REG.title= CR.denominazione");
            if (All.Rows.Count == 0) return true;
            DataTable TaxSetup = destConn.CreateTableByName("taxsetup", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = TaxSetup.NewRow();
                if (Curr["codiceritenuta"] != DBNull.Value)
                    R["taxcode"] = Missione.lookuptaxcode[Curr["codiceritenuta"].ToString().ToUpper()];
                int flag = 0;
                if (Curr["flagenteregionale"].ToString().ToUpper() == "N") flag += 1;
                if (Curr["flagenteregionale"].ToString().ToUpper() == "S") flag += 2;
                if (Curr["flagenteregionale"].ToString().ToUpper() == "P") flag += 4;
                if (Curr["tipoperiodo"].ToString().ToUpper() == "P") flag += 8;
                R["flag"] = flag;
                R["idexpirationkind"] = Curr["tiposcadenza"];//ogni quanti mesi
                foreach(string S in new string[]{"idfinincomecontra","idfinadmintax","idfinexpensecontra",
                          "ct","cu","paymentagency","ayear","flagadminfinance","expiringday","lt","lu","txt","rtf"}){
                    R[S]=Curr[S];
                }
                TaxSetup.Rows.Add(R);
            }
            if (TaxSetup.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(TaxSetup);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento TaxSetup da automatismiritenute");


        }

        /// <summary>
        /// Copia ordinegenericomovspesa in expensemandate ponendo idmankind='GENERALE'
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        public static bool migraOrdineGenericoMovSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expensemandate", null, false) > 0) return true;

            migraSpesa(form, sourceConn, destConn);

            string query = "select ct=O.createtimestamp, "
                + "cu=O.createuser, "
                + " E.idexp,"
                + "idmankind='GENERALE', "
                + "lt=O.lastmodtimestamp, "
                + "lu=O.lastmoduser, "
                + "movkind=case when O.tipomovimento = 'ORDIN' then 1 when O.tipomovimento='IMPON' then  3 "
                + "when O.tipomovimento='IMPOS' then 2 else 1 end, "
                + "nman=O.numordine, "
                + "yman=O.esercordine "
                + "from ordinegenericomovspesa O "
                + " JOIN spesa S on S.idspesa=O.idspesa "
                + " JOIN " + getExtAccess(destConn, "expense", false) + " E "
                + "  ON E.ymov=S.esercmovimento "
                + "  AND E.nmov= S.nummovimento "
                + "  AND E.nphase= convert(int,S.codicefase)";

            DataTable tExpenseMandate = Migrazione.eseguiQuery(sourceConn, query, form);
            if (tExpenseMandate.Rows.Count==0) return true;

            tExpenseMandate.TableName = "expensemandate";
            DataSet ds = new DataSet();
            ds.Tables.Add(tExpenseMandate);

            if (!Migrazione.lanciaScript(form, destConn, ds, "ordinegenericomovspesa -> expensemandate")) return false;


            query = "select ct=O.createtimestamp, "
                + "cu=O.createuser, "
                + " E.idexp, "
                + "idmankind='PATRIMONIO', "
                + "lt=O.lastmodtimestamp, "
                + "lu=O.lastmoduser, "
                + "movkind=case when O.tipomovimento = 'ORDIN' then 1 when O.tipomovimento='IMPON' then  3 "
                + "when O.tipomovimento='IMPOS' then 2 else 1 end, "
                + "nman=O.numordine, "
                + "yman=O.esercordine "
                + "from ordineinventariomovspesa O"
                + " JOIN spesa S on S.idspesa=O.idspesa "
                + " JOIN " + getExtAccess(destConn, "expense", false) + " E "
                + "  ON E.ymov=S.esercmovimento "
                + "  AND E.nmov= S.nummovimento "
                + "  AND E.nphase= convert(int,S.codicefase)";

            tExpenseMandate = Migrazione.eseguiQuery(sourceConn, query, form);
            if (tExpenseMandate == null) return false;

            tExpenseMandate.TableName = "expensemandate";
            ds = new DataSet();
            ds.Tables.Add(tExpenseMandate);

            if (!Migrazione.lanciaScript(form, destConn, ds, "ordineinventariomovspesa -> expensemandate")) return false;
            return true;
        }

        public static bool migraMissioneMovSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expenseitineration", null, false) > 0) return true;
            if (destConn.RUN_SELECT_COUNT("expense", null, false) == 0) return false;

            migraSpesa(form, sourceConn, destConn);
            Missione.migraMissione(form, sourceConn, destConn);

            string query = "select ct=M.createtimestamp, "
                + "cu=M.createuser, "
                + " E.idexp,"
                + "lt=M.lastmodtimestamp, "
                + "lu=M.lastmoduser, "
                + "movkind=case when M.tipomovimento= 'SALDO' then 4 when M.tipomovimento='ANGIR' then  5 "
                + "when M.tipomovimento='ANPAG' then 6 else 4 end,"
                + "M.nummissione, "
                + "M.esercmissione "
                + "from missionemovspesa M "
                + " JOIN spesa S on S.idspesa=M.idspesa "
                + " JOIN " + getExtAccess(destConn, "expense", false) + " E "
                + "  ON E.ymov=S.esercmovimento "
                + "  AND E.nmov= S.nummovimento "
                + "  AND E.nphase= convert(int,S.codicefase) ";

            DataTable tExpenseItineration = Migrazione.eseguiQuery(sourceConn, query, form);
            if (tExpenseItineration == null) return false;
            tExpenseItineration.Columns.Add("iditineration", typeof(int));
            foreach (DataRow R in tExpenseItineration.Rows) {
                string code=R["esercmissione"].ToString() + "-" + R["nummissione"].ToString();
                R["iditineration"] = Missione.lookup_idtineration[code];
            }
            tExpenseItineration.Columns.Remove("esercmissione");
            tExpenseItineration.Columns.Remove("nummissione");

            tExpenseItineration.TableName = "expenseitineration";
            DataSet ds = new DataSet();
            ds.Tables.Add(tExpenseItineration);

            if (!Migrazione.lanciaScript(form, destConn, ds, "missionemovspesa -> expenseitineration")) return false;
            return true;
        }


		public static bool migraUpb(Form form, DataAccess sourceConn, DataAccess destConn) {
			

			//fondoricerca, ripfondiricerca, centrospesa -> upb
			if (!creaTabellaUpb(form, sourceConn, destConn)) return false;//1.1 e 1.2

			//tabelleclassificabili -> sortabletable (sistema)//--------------AllSystemCfgNoGeo.sql
//			esportaTabelleClassificabili(form, sourceConn, destConn);//1.3


			//classtreefondo e classtreeripartizioni -> upbsorting
			if (!migraDaFdrAdUpbSorting(form, sourceConn, destConn)) return false;//1.5

			//classtreecentrospesa -> ubpsorting
			if (!migraDaCdsAdUpbSorting(form, sourceConn, destConn)) return false;//1.6


            if (!migraLivelloBil(form, sourceConn, destConn)) return false;

			//bilancio -> fin + finyear + finlast
			if (!migraBilancio(form, sourceConn, destConn)) return false;//1.7
           

			//variazionebilancio, variazionecrediti, variazionecassa -> finvar
			//dettvarbilancio, dettvarcrediti, dettvarcassa -> finvardetail
			if (!migraVariazioni(form, sourceConn, destConn)) return false;//1.8

            if (!migrafaseEntrata(form, sourceConn, destConn)) return false;

            if (!migraCassiere(form, sourceConn, destConn)) return false;
            if (!migraSaldoCassiere(form, sourceConn, destConn)) return false;

            if (!migraElenchiMandati(form, sourceConn, destConn)) return false;
            if (!migraElenchiReversali(form, sourceConn, destConn)) return false;
            
            if (!migraReversali(form, sourceConn, destConn)) return false;
            if (!migraMandati(form, sourceConn, destConn)) return false;



            //Migra mov. di entrata in income e incomelast + tutte le tabelle da cui dipendono
            if (!migraEntrata(form, sourceConn, destConn)) return false;

            if (!migrafaseSpesa(form, sourceConn, destConn)) return false;

            //Migra mov. di spesa in expense e expenselast + tutte le tabelle da cui dipendono
            if (!migraSpesa(form, sourceConn, destConn)) return false;

            //Migra variaz.entrata e contabilizzazioni note credito
            if (!migraVariazioniEntrata(form, sourceConn, destConn)) return false;

            if (!migraDettaglioRitenute(form, sourceConn, destConn)) return false;

            if (!migraTipoRecupero(form, sourceConn, destConn)) return false;
            if (!migraRecupero(form, sourceConn, destConn)) return false;
            if (!MigraConfRecuperi(form, sourceConn, destConn)) return false;
            if (!MigraConfRitenute(form, sourceConn, destConn)) return false;

            //Migra var. di spesa e contabilizzaz.note debito
            if (!migraVariazioniSpesa(form, sourceConn, destConn)) return false;

			//imputazioneentrata -> incomeyear, finvar e finvardetail
			if (!migraImputazioneEOS("entrata", form, sourceConn, destConn)) return false;//1.9

			//imputazionespesa -> expenseyear, finvar e finvardetail
			if (!migraImputazioneEOS("spesa", form, sourceConn, destConn)) return false;//1.9

			DialogResult dr_FdR = MessageBox.Show(form, "Si vuole procedere a stornare le previsioni dell'ultimo anno"
				+ " dei fondi di ricerca dall'UPB Dipartimento se esistono fondi associati ad un unica voce di bilancio"
				+ " ponendo l'importo della variazione pari alla previsione disponibile del Fondo di Ricerca?",
				"", MessageBoxButtons.YesNo);
			if (dr_FdR == DialogResult.Yes) {
				if (!stornaPrevisioneDaLiberoAFdR_MonoCapitolo("E", form, sourceConn, destConn, tFdrUpb)) return false;
				if (!stornaPrevisioneDaLiberoAFdR_MonoCapitolo("S", form, sourceConn, destConn, tFdrUpb)) return false;
                if (!stornaCreditiCassaDaLiberoAFdR_MonoCapitolo(form, sourceConn, destConn, tFdrUpb)) return false;
			}

            if (!migraRipartAutom(form, sourceConn, destConn)) return false;

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
				if (!migraAssCentroEOS("entrata", form, sourceConn, destConn)) return false;//1.10

				//asscentrospesa -> finvar, finvardetail
				if (!migraAssCentroEOS("spesa", form, sourceConn, destConn)) return false;//1.10
			}
            if (!migraRipAvanzoAmm(form, sourceConn, destConn)) return false;
            if (!migraRipAvanzoCassa(form, sourceConn, destConn)) return false;
            if (!migraSitFinAmm(form, sourceConn, destConn)) return false;

            
            //opfondopiccolespese -> pettycashoperation
			if (!migraOpFondoPiccoleSpese(form, sourceConn, destConn)) return false;//1.11
            if (!migraPersOpFondo(form, sourceConn, destConn)) return false;

            if (!migraOpFondoPiccoleSpeseSpesa(form, sourceConn, destConn)) return false;
            if (!migraOpFondoPiccoleSpeseEntrata(form, sourceConn, destConn)) return false;

            if (!migraConfigFasiCont(form, sourceConn, destConn)) return false;

            if (!migraConvBilancio(form, sourceConn, destConn)) return false;

            //ordinegenericomovspesa -> expensemandate
            if (!migraOrdineGenericoMovSpesa(form, sourceConn, destConn)) return false;
            if (!migraMissioneMovSpesa(form, sourceConn, destConn)) return false;

//			if ((tUpblookup != null) && !troncaNLivelliDiBilancio(destConn, 2)) return false;
			return true;
		}




	}
}
