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
using metadatalibrary;
using System.Windows.Forms;
using System.Text;
using LiveUpdate;
using funzioni_configurazione;

namespace Install
{
	/// <summary>
	/// Summary description for Anagrafica.
	/// </summary>
	public class Anagrafica
	{
        static string CAMBIA_CODICETIPOCLASS =
            "idregistryclass=case "
            + "when codtipoclass in ('01','02','08','09') then '21' "
            + "when codtipoclass in ('05','06','07') then '22' "
            + "when codtipoclass in ('03','04') then '23' "
            + "when codtipoclass in ('10','00') then '24' "
            + "else '24' end";
        
        //static string CAMBIA_CODICETIPOCLASS = "idregistryclass=codtipoclass";

        static string CAMBIA_TIPORESIDENZA = "residence=case when "
            + "tiporesidenza in ('E','U','R','T', 'A') then 'I' "
            + "when tiporesidenza in ('C','F') then tiporesidenza "
            + "else 'I' end";
        //static string CAMBIA_TIPORESIDENZA = "residence=tiporesidenza";

//		public static string CAMBIA_IDSER = "idser=case when idser in ( "
//			+ "'05_ASSRICM','05_ASSRINM','05_COORDM','05_COORDN','05_COORDP','05_TUTORM','05_TUTORNM','BORSISTI',"
//			+ "'BORSISTIES','COMPSTCON','COMPSTRA','CTERZIRICE','MISSASS','MISSDIP','MISSLAVAUT',"
//			+ "'MISSPROFES','OCCMUTUATI','OCCNIRAPEN','OCCNONMUT','PRESTPROF') "
//			+ "then idser else 'GENERICA' end";
//
		
		private static bool migraCreditoreDebitore(DataAccess sourceConn, DataAccess destConn, 
			Form form, DataTable tColName) 
		{
			DataTable tRegistry = Migrazione.leggiETraduciTabella("creditoredebitore", 
				sourceConn, tColName, form,	"'idregistryclass', 'residence'",
				CAMBIA_CODICETIPOCLASS + ", " + CAMBIA_TIPORESIDENZA);
			if (tRegistry==null) return false;

            string q_posgiur = "SELECT codicecreddeb, matricola FROM posgiuridica p0 WHERE NOT EXISTS" +
	            "(SELECT * FROM posgiuridica p1 " +
                " WHERE (p0.codicecreddeb = p1.codicecreddeb) " +
	            " AND (p0.datainizio < p1.datainizio))" +
                " AND p0.matricola IS NOT NULL";

            DataTable tPosG = DataAccess.SQLRunner(sourceConn, q_posgiur);

            if (tPosG == null) {
                MessageBox.Show(form, "Errore nella estrazione della matricola", "Errore");
                return false;
            }

            foreach (DataRow rPos in tPosG.Rows) {
                string filtro = "(idreg = " + QueryCreator.quotedstrvalue(rPos["codicecreddeb"], false) + ")";
                DataRow [] registry = tRegistry.Select(filtro);
                if (registry.Length == 0) {
                    MessageBox.Show(form, "Non esiste la riga di anagrafica della pos. giuridica considerata", "Errore");
                    return false;
                }
                DataRow r = registry[0];
                if (r["extmatricula"] != DBNull.Value) continue;
                r["extmatricula"] = rPos["matricola"];
            }

			tRegistry.TableName = "registry";
			return Migrazione.lanciaScript(form,destConn, tRegistry, "creditoredebitore -> registry");
		}

        private static bool migraContatto(DataAccess sourceConn, DataAccess destConn,
            Form form, DataTable tColName) {
            string query = "select ct=createtimestamp, cu=createuser, lt=lastmodtimestamp, lu=lastmoduser,"
                + " idreg = codicecreddeb, referencename = nomecontatto, registryreferencerole = funzionecontatto,"
                + " phonenumber = ISNULL(telefonoprefisso,'') + ISNULL(telefononumero,''),"
                + " faxnumber = ISNULL(telefaxprefisso,'') + ISNULL(telefaxnumero,''),"
                + " email = indirizzoemail, userweb = loginweb, passwordweb = passwordweb, txt = notes, rtf = olenotes,"
                + " flagdefault = ISNULL(predefinito,'N'), mobilenumber = numcellulare, idregistryreference = null, "
                + " skypenumber = null, msnnumber = null "
                + "from contatto "
                + "order by codicecreddeb";

            string errMsg;
            DataTable tRegRef = sourceConn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(form, errMsg);
                return false;
            }
            int nProg = 1;
            int lastIdReg = 0;
            foreach (DataRow r in tRegRef.Rows) {
                int currIdReg = CfgFn.GetNoNullInt32(r["idreg"]);
                if (currIdReg != lastIdReg) {
                    nProg = 1;
                    lastIdReg = currIdReg;
                }
                else {
                    nProg++;
                }
                r["idregistryreference"] = nProg;
            }

            tRegRef.TableName = "registryreference";

            DataSet ds = new DataSet();
            ds.Tables.Add(tRegRef);

            return Migrazione.lanciaScript(form, destConn, ds, "Contatto -> registryreference");

        }

        private static bool migraModPag(DataAccess sourceConn, DataAccess destConn,
                    Form form, DataTable tColName) {
            string query = "select ct = m.createtimestamp, cu = m.createuser, lt = m.lastmodtimestamp, lu = m.lastmoduser,"
                + " idreg = m.codicecreddeb, regmodcode = m.tipomodalita, idpaymethod = m.codicemodalita,"
                + " cin = m.cin, idbank = m.codicebanca, idcab = m.codicesportello, cc = m.numeroconto, "
                + " paymentdescr = m.descpagamento, paymentexpiring = m.scadpagamento, idexpirationkind = m.tiposcadenza, "
                + " flagstandard = ISNULL(m.flagmodalitastandard,'N'), active = ISNULL(m.flagattivo,'S'), "
                + " txt = m.notes, rtf = m.olenotes, "
                + " iddeputy = m.codicedelegato, refexternaldoc = m.rifdocumentoesterno, idregistrypaymethod = null,"
                + " idcurrency = c.codicevaluta "
                + "from modpagamentocreddebi m join creditoredebitore c on m.codicecreddeb = c.codicecreddeb "
                + "order by m.codicecreddeb";

            string errMsg;
            DataTable tRegPM = sourceConn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(form, errMsg);
                return false;
            }
            int nProg = 1;
            int lastIdReg = 0;
            foreach (DataRow r in tRegPM.Rows) {
                int currIdReg = CfgFn.GetNoNullInt32(r["idreg"]);
                if (currIdReg != lastIdReg) {
                    nProg = 1;
                    lastIdReg = currIdReg;
                }
                else {
                    nProg++;
                }
                r["idregistrypaymethod"] = nProg;
            }

            tRegPM.TableName = "registrypaymethod";

            DataSet ds = new DataSet();
            ds.Tables.Add(tRegPM);

            return Migrazione.lanciaScript(form, destConn, ds, "Mod. Pagamento dell'Anagrafica -> registrypaymethod");

        }


		/// <summary>
		/// Migra le tabelle speciali dell'Anagrafica.
		/// Questo metodo sarà chiamato da copiatutto
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tColName"></param>
		/// <returns></returns>
		public static bool migraSpeciali(Form form, DataAccess sourceConn, DataAccess destConn, 
		 DataTable tColName) {
			
			//"creditoredebitore -> registry"
			if (!migraCreditoreDebitore(sourceConn, destConn, form, tColName)) return false;

            //"contatto -> registryreference"
            if (!migraContatto(sourceConn, destConn, form, tColName)) return false;

            //"modpagamentocreddebi -> registrypaymethod"
            if (!migraModPag(sourceConn, destConn, form, tColName)) return false;

			//"cdruolo -> role"
			return true;
		}

		/// <summary>
		/// Migra sia le tabelle speciali che normali dell'anagrafica.
		/// Questo metodo sarà chiamato da copia "custom" dell'anagrafica.
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		/// <param name="tTableName"></param>
		/// <param name="tColName"></param>
		/// <returns></returns>
        public static bool migraAnagrafica(Form form, DataAccess sourceConn, DataAccess destConn,
            DataTable tTableName, DataTable tColName) {


            if (!migraSpeciali(form, sourceConn, destConn, tColName)) return false;

            string filtro = "tipocopia='copia' and copiato='N' and chk like '%Anagrafica%'";

            DataRow[] rTableName = tTableName.Select(filtro);

            foreach (DataRow rTable in rTableName) {
                DataSet ds = new DataSet();
                DataTable t = Migrazione.leggiETraduciTabella(rTable["oldtable"].ToString(), sourceConn, tColName, form);
                if (t == null) return false;
                t.TableName = rTable["newtable"].ToString();
                ds.Tables.Add(t);
                rTable["copiato"] = "S";
                string nomeCopia = "Copia tabella " + t.TableName;
                bool res = Migrazione.lanciaScript(form, destConn, t, nomeCopia);
                if (!res) return false;
            }
            return true;
        }
	}
}
