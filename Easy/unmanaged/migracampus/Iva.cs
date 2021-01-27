
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Collections;
using funzioni_configurazione;

namespace Install
{
	/// <summary>
	/// Summary description for Iva.
	/// </summary>
	public class Iva
	{
        public static void Reset(){
            lookupidinvkind = new Hashtable();
            lookupidivaregisterkind = new Hashtable();
            lookupidivakind = new Hashtable();
            migraTipoIva_eseguito = false;
            lookupidivapayperiodicity = new Hashtable();
            migraTipoPeriodLiqIva_eseguito = false;
            idsorkindpiano = DBNull.Value; 
            lookupidconto_iva = new Hashtable();
            pianocontiiva_migrato = false;
            funzione_migraPianoDeiConti_eseguita = false;
            migraTipoRegistroIva_eseguito = false;
            migraTipoDocumentoIva_eseguito = false;
        }

        public static string getExtAccess(DataAccess Conn, string table, bool dbo) {
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo." + table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
        }
        public static Hashtable lookupidinvkind = new Hashtable();
        public static bool migraTipoDocumentoIva_eseguito = false;
        public static bool migraTipoDocumentoIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraTipoDocumentoIva_eseguito) return true;
            migraTipoDocumentoIva_eseguito = true;
            string query = "select codicetipodoc, descrizione, "
                                + "ct = createtimestamp, cu = createuser, "
                            + "lu=lastmoduser, lt=lastmodtimestamp, "
                            + "flagnotavariazione, "
                            + "flagvenditaacquisto "
                            + "from tipodocumentoiva";
            DataTable All = Migrazione.eseguiQuery(sourceConn, query, form);
            if (All.Rows.Count == 0) return true;

            DataTable Existent = destConn.SQLRunner("SELECT * from invoicekind");
            Existent.CaseSensitive=false;
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codeinvkind"].ToString().ToUpper();
                lookupidinvkind[code] = RC["idinvkind"];
            }
            CQueryHelper QHC = new CQueryHelper();

            query = "select distinct codicetipodoc, flagpromiscuo='N' "
                        + "from tipodocoperiva "
                        + "join tipooperregiva on tipodocoperiva.codicetipoop=tipooperregiva.codicetipoop "
                        + "join tiporegistroiva on tipooperregiva.codicetiporeg=tiporegistroiva.codicetiporeg "
                        + "where classregistro <> 'P' ";
            DataTable t = Migrazione.eseguiQuery(sourceConn, query, form);
            if (t == null) return false;

            DataTable InvKind = destConn.CreateTableByName("invoicekind", "*");
            int nmaxinvkind = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("invoicekind", null, "max(idinvkind)"));
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["codicetipodoc"].ToString().ToUpper();
                if (lookupidinvkind[code] != null) continue;
                string find = QHC.CmpEq("description", Curr["descrizione"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidinvkind[code] = found[0]["idinvkind"];
                    continue;
                }
                nmaxinvkind++;
                DataRow R = InvKind.NewRow();
                R["idinvkind"] = nmaxinvkind;
                R["codeinvkind"] = Curr["codicetipodoc"].ToString().ToUpper();
                lookupidinvkind[R["codeinvkind"].ToString()] = nmaxinvkind;
                R["lu"] = Curr["lu"];
                R["cu"] = Curr["cu"];
                R["lt"] = Curr["lt"];
                R["ct"] = Curr["ct"];
                R["description"] = Curr["descrizione"];
                int flag = 0;
                if (Curr["flagvenditaacquisto"].ToString().ToUpper() == "V") flag += 1;
                string q = "codicetipodoc=" + QueryCreator.quotedstrvalue(Curr["codicetipodoc"], false);
                t.CaseSensitive = false;
                DataRow[] r = t.Select(q);
                if (r.Length > 0) {
                    if (r[0]["flagpromiscuo"].ToString().ToUpper() == "S") flag += 2;
                }
                if (Curr["flagnotavariazione"].ToString().ToUpper() == "S") flag += 4;
                R["flag"] = flag;
                InvKind.Rows.Add(R);
            }
            //flagbuysell (A = 0; V = 1); flagmixed (N = 0; S = 1); flagvariation (N = 0; S = 1)

            if (InvKind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(InvKind);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento invoicekind da tipodocumentoiva,tipodocoperiva ");
        }

        public static Hashtable lookupidivaregisterkind = new Hashtable();
        public static bool migraTipoRegistroIva_eseguito = false;
        public static bool migraTipoRegistroIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraTipoRegistroIva_eseguito) return true;
            migraTipoRegistroIva_eseguito = true;
            DataTable Existent = destConn.SQLRunner("SELECT * from ivaregisterkind");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codeivaregisterkind"].ToString().ToUpper();
                lookupidivaregisterkind[code] = RC["idivaregisterkind"];
            }
            CQueryHelper QHC = new CQueryHelper();

            DataTable All = sourceConn.SQLRunner(
                "SELECT  codeivaregisterkind=M.codicetiporeg,ct=M.createtimestamp,registerclass=M.classregistro," +
                "cu=M.createuser,description=M.descrizione,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                "FROM tiporegistroiva M ");
            if (All.Rows.Count == 0) return true;
            DataTable IvaRegKind = destConn.CreateTableByName("ivaregisterkind", "*");
            int nmaxivaregkind = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("ivaregisterkind",null,"max(idivaregisterkind)"));
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["codeivaregisterkind"].ToString().ToUpper();
                if (lookupidivaregisterkind[code] != null) continue;
                string find = QHC.CmpEq("description", Curr["description"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidivaregisterkind[code] = found[0]["idivaregisterkind"];
                    continue;
                }


                nmaxivaregkind++;
                DataRow R = IvaRegKind.NewRow();
                R["idivaregisterkind"] = nmaxivaregkind;
                lookupidivaregisterkind[code] = nmaxivaregkind;
                R["codeivaregisterkind"] = code;
                foreach (string S in new string[] { "ct", "cu", "registerclass", "description", "lt", "lu" }) {
                    R[S] = Curr[S];
                }
                IvaRegKind.Rows.Add(R);
            }
            if (IvaRegKind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(IvaRegKind);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ivaregisterkind da tiporegistroiva ");



        }

		/// <summary>
		/// Crea la tabella di mezzo tra invoicekind e ivaregisterkind
		/// </summary>
		/// <param name="form"></param>
		/// <param name="sourceConn"></param>
		/// <param name="destConn"></param>
		public static bool migraInvoicekindRegisterkind(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("invoicekindregisterkind", null, false) > 0) return true;
            migraTipoDocumentoIva(form, sourceConn, destConn);
            migraTipoRegistroIva(form, sourceConn, destConn);

            string query = "select distinct codicetipodoc codicetiporeg "
				+ "from tipodocoperiva "
				+ "join tipooperregiva on tipodocoperiva.codicetipoop=tipooperregiva.codicetipoop";
			DataTable t = Migrazione.eseguiQuery(sourceConn, query, form);
            if (t.Rows.Count == 0) return true;
            DataTable InvRegKind = destConn.CreateTableByName("invoicekindregisterkind", "*");
			foreach (DataRow Curr in t.Rows) {
                DataRow R = InvRegKind.NewRow();
                R["idinvkind"] = lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                R["idivaregisterkind"] = lookupidivaregisterkind[Curr["codicetiporeg"].ToString().ToUpper()];
				R["ct"] = DateTime.Now;
				R["lt"] = DateTime.Now;
                R["cu"] = "SWMORE";
                R["lu"] = "SWMORE";
                InvRegKind.Rows.Add(R);
			}
            if (InvRegKind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(InvRegKind);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento invoicekindregisterkind da tipodocoperiva,tipooperregiva ");
        }

        public static Hashtable lookupidivakind = new Hashtable();
        static bool migraTipoIva_eseguito = false;
        public static bool migraTipoIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraTipoIva_eseguito) return true;
            migraTipoIva_eseguito = true;

            DataTable Existent = destConn.SQLRunner("SELECT * from ivakind");
            foreach (DataRow RC in Existent.Rows) {
                string code = RC["codeivakind"].ToString().ToUpper();
                lookupidivakind[code] = RC["idivakind"];
            }

            DataTable All = sourceConn.SQLRunner(
                "SELECT rate=M.aliquota,codeivakind=M.codicetipoiva,ct=M.createtimestamp,cu=M.createuser," +
                "description=M.descrizione,lt=M.lastmodtimestamp,lu=M.lastmoduser," +
                "unabatabilitypercentage=M.percindeducibilita " +
                " FROM tipoiva M");
            if (All.Rows.Count == 0) return true;
            DataTable IvaKind = destConn.CreateTableByName("ivakind", "*");
            int maxidivakind = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("ivakind",null,"max(idivakind)"));
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["codeivakind"].ToString().ToUpper();
                if (lookupidivakind[code] != null) continue;
                DataRow R = IvaKind.NewRow();
                maxidivakind++;
                R["idivakind"] = maxidivakind;
                R["codeivakind"] = code;
                lookupidivakind[code] = maxidivakind;
                foreach (string S in new string[] { "rate", "ct", "cu", "description", 
                    "lt", "lu", "unabatabilitypercentage" }) {
                    R[S] = Curr[S];
                }
                R["active"] = "S";
                IvaKind.Rows.Add(R);
            }
            if (IvaKind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(IvaKind);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento IvaKind da tipoiva ");

        }

        public static Hashtable lookupidivapayperiodicity = new Hashtable();
        static bool migraTipoPeriodLiqIva_eseguito = false;
        public static bool migraTipoPeriodLiqIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraTipoPeriodLiqIva_eseguito) return true;
            migraTipoPeriodLiqIva_eseguito = true;
            DataTable Existent = destConn.SQLRunner("select * from ivapayperiodicity");
            CQueryHelper QHC = new CQueryHelper();
            string sql =
                "SELECT M.codicetipoper,ct=M.createtimestamp,cu=M.createuser," +
                "description=M.descrizione,periodicday=M.giornoper,lt=M.lastmodtimestamp," +
                "lu=M.lastmoduser,periodicmonth=M.meseper,periodicity=M.periodicita " +
                "from tipoperiodliquiva M ";
            DataTable All = sourceConn.SQLRunner(sql);
            if (All.Rows.Count == 0) return true;
            DataTable IvaPayPer = destConn.CreateTableByName("ivapayperiodicity", "*");
            int nmaxinvpayper = CfgFn.GetNoNullInt32(
                destConn.DO_READ_VALUE("ivapayperiodicity",null,"max(idivapayperiodicity)"));
            foreach (DataRow Curr in All.Rows) {
                string code = Curr["codicetipoper"].ToString().ToUpper();
                string filter = QHC.MCmp(Curr, "description");
                DataRow[] found = Existent.Select(filter);
                if (found.Length > 0) {
                    lookupidivapayperiodicity[code] = found[0]["idivapayperiodicity"];
                    continue;
                }
                filter = QHC.MCmp(Curr, "periodicday", "periodicmonth", "periodicity");
                 found = Existent.Select(filter);
                if (found.Length > 0) {
                    lookupidivapayperiodicity[code] = found[0]["idivapayperiodicity"];
                    continue;
                }

                nmaxinvpayper++;
                DataRow R = IvaPayPer.NewRow();
                R["idivapayperiodicity"] = nmaxinvpayper;
                lookupidivapayperiodicity[code] = nmaxinvpayper;
                foreach (string S in new string[] {"ct", "cu", "description", "periodicday", "lt", "lu", 
                    "periodicmonth", "periodicity" }) {
                    R[S] = Curr[S];
                }
                IvaPayPer.Rows.Add(R);
            }
            if (IvaPayPer.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(IvaPayPer);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ivapayperiodicity da tipoperiodliquiva ");

        }

        public static bool migraRegistroIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("ivaregister", null, false) > 0) return true;
            migraTipoDocumentoIva(form, sourceConn, destConn);
            migraTipoRegistroIva(form, sourceConn, destConn);

            DataTable All = sourceConn.SQLRunner(
                "SELECT M.codicetipodoc, M.codicetiporeg,ct=M.createtimestamp,"+
                "cu=M.createuser,yinv=M.esercdocumento,yivaregister=M.esercregistrazione,lt=M.lastmodtimestamp,"+
                "lu=M.lastmoduser,ninv=M.numdocumento,protocolnum=M.numprotocollo,nivaregister=M.numregistrazione "+
                "from registroiva M ");
            if (All.Rows.Count == 0) return true;
            DataTable IvaReg = destConn.CreateTableByName("ivaregister", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = IvaReg.NewRow();
                R["idinvkind"] = lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                R["idivaregisterkind"] = lookupidivaregisterkind[Curr["codicetiporeg"].ToString().ToUpper()];
                foreach (string S in new string[] {"ct","cu","yinv",
                            "yivaregister","lt","lu","ninv","protocolnum","nivaregister"}) {
                    R[S] = Curr[S];
                }
                IvaReg.Rows.Add(R);
            }
            if (IvaReg.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(IvaReg);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ivaregister da registroiva ");

        }

		public static bool migraInvoiceDeferred(Form form, DataAccess sourceConn, DataAccess destConn) {
			DataSet ds = destConn.CallSP("compute_invoicedeferred", new object[]{},false,0);
			if (ds == null) return false;
			return true;
		}

        /// <summary>
        /// Metodo che migra i dati da documentoiva a invoice (La gestione dell'idcentrospesa è demandata alla migrazione
        /// dei dettdocumentoiva in invoicedetail)
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <param name="tColName"></param>
        /// <returns></returns>
        public static bool migraDocumentoIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("invoice", null, false) > 0) return true;
            
            migraTipoDocumentoIva(form, sourceConn, destConn);
            Anagrafica.migraValuta(form, sourceConn, destConn);
            Anagrafica.RiempiLookupIdexpiration();
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);


            string query = "select distinct codicetipodoc, flag=flagimmediata+flagdifferita "
                + "from tipodocoperiva "
                + "join tipooperregiva on tipodocoperiva.codicetipoop=tipooperregiva.codicetipoop "
                + "join tiporegistroiva on tipooperregiva.codicetiporeg=tiporegistroiva.codicetiporeg "
                + "where classregistro <> 'P' ";
            DataTable t1 = sourceConn.SQLRunner(query);
            if (t1 == null) return false;
            Hashtable GetFlagDeferred = new Hashtable();
            //string filtroImmed = QueryCreator.ColumnValues(t1, "flag in('AI','DI')", "codicetipodoc", false);
            foreach (DataRow F in t1.Select("flag in('AI','DI')"))
                GetFlagDeferred[F["codicetipodoc"].ToString().ToUpper()] = "N";
            //string filtroDiffer = QueryCreator.ColumnValues(t1, "flag in('IA','ID')", "codicetipodoc", false);
            foreach (DataRow F in t1.Select("flag in('IA','ID')")) {
                if (GetFlagDeferred[F["codicetipodoc"].ToString().ToUpper()] == null)
                    GetFlagDeferred[F["codicetipodoc"].ToString().ToUpper()] = "S";
                else
                    GetFlagDeferred[F["codicetipodoc"].ToString().ToUpper()] = null;
            }
            string sql = "SELECT REG.idreg,M.codicetipodoc,M.codicevaluta," +
                "ct=M.createtimestamp,cu=M.createuser,adate=M.datacontabile,packinglistdate=M.datadoctrasp," +
                "docdate=M.datadocumento,description=M.descrizione,doc=M.documento,yinv=M.esercdocumento," +
                "officiallyprinted=M.flagstampa,lt=M.lastmodtimestamp,lu=M.lastmoduser,txt=M.notes," +
                "packinglistnum=M.numdoctrasp,ninv=M.numdocumento,rtf=M.olenotes,registryreference=M.riferimentocreddeb," +
                "paymentexpiring=M.scadpagamento,exchangerate=M.tassocambio, M.tiposcadenza " +
                " FROM documentoiva M " +
                " LEFT OUTER JOIN creditoredebitore CR ON CR.codicecreddeb=M.codicecreddeb " +
                " LEFT OUTER JOIN " + getExtAccess(destConn, "registry", true) + " REG " +
                "  ON REG.title=CR.denominazione ";
            DataTable All = sourceConn.SQLRunner(sql);

            DataTable Invoice= destConn.CreateTableByName("invoice","*");
            foreach(DataRow Curr in All.Rows){
                DataRow R = Invoice.NewRow();
                if (Curr["codicetipodoc"] != DBNull.Value) {
                    R["idinvkind"] = lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                    if (GetFlagDeferred[Curr["codicetipodoc"].ToString().ToUpper()] != null)
                        R["flagdeferred"] = GetFlagDeferred[Curr["codicetipodoc"].ToString().ToUpper()];
                }
                if (Curr["codicevaluta"] != DBNull.Value)
                    R["idcurrency"] = Anagrafica.lookupidcurrency[Curr["codicevaluta"].ToString().ToUpper()];
                if (Curr["tiposcadenza"] != DBNull.Value)
                    R["idexpirationkind"] = Anagrafica.lookupidexpiration[Curr["tiposcadenza"].ToString().ToUpper()];

                foreach (string S in new string[] {"idreg","ct","cu","adate","packinglistdate","docdate","description",
                            "doc","yinv","officiallyprinted","lt","lu","txt","packinglistnum","ninv","rtf",
                                            "registryreference","paymentexpiring","exchangerate"}) {
                    R[S] = Curr[S];
                }

                Invoice.Rows.Add(R);

            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Invoice);

            return Migrazione.lanciaScript(form, destConn, ds, "documentoiva, tipooperregiva -> invoice");
        }


        public static bool migraDettDocumentoIva(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("invoicedetail", null, false) > 0) return true;
            Upb.creaTabellaUpb(form, sourceConn, destConn);
            migraTipoDocumentoIva(form, sourceConn, destConn);
            migraTipoIva(form, sourceConn, destConn);
 
            string query = "select annotations=DETT.camponote, ct=DETT.createtimestamp, "
                + "cu=DETT.createuser, detaildescription=DETT.descrdettaglio, DETT.codicetipodoc, "
                + "DETT.codicetipoiva, number = 1,  "
                + "lt=DETT.lastmodtimestamp, lu=DETT.lastmoduser,  DETT.idconto, "
                + "ninv=DETT.numdocumento,  "
                + "taxable=DETT.imponibile, tax=DETT.imposta, "
                + "unabatable=DETT.indetraibile, yinv=DETT.esercdocumento,  DOC.idcentrospesa "
                + "from dettdocumentoiva DETT "
                + "join documentoiva DOC "
                + "on DOC.codicetipodoc = DETT.codicetipodoc "
                + "and DOC.esercdocumento = DETT.esercdocumento "
                + "and DOC.numdocumento = DETT.numdocumento "
                + " ORDER BY DETT.codicetipodoc, DETT.esercdocumento, DETT.numdocumento ";
                
            DataTable All = sourceConn.SQLRunner(query);
            if (All.Rows.Count == 0) return true;

            DataTable InvDet = destConn.CreateTableByName("invoicedetail", "*");
            string lastsel = "";
            int rownum = 0;
            
            foreach (DataRow Curr in All.Rows) {
                DataRow R = InvDet.NewRow();
                R["idinvkind"] = lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                string newsel = R["idinvkind"].ToString() + "-" + Curr["yinv"].ToString() + "-" + Curr["ninv"].ToString();
                if (newsel == lastsel) {
                    rownum++;
                }
                else {
                    rownum = 1;
                }
                lastsel = newsel;
                R["rownum"] = rownum;
                R["idgroup"] = rownum;
                if (Curr["codicetipoiva"] != DBNull.Value) {
                    R["idivakind"] = lookupidivakind[Curr["codicetipoiva"].ToString().ToUpper()];
                }
                if (Upb.tCdsUpb != null && Curr["idcentrospesa"] != DBNull.Value) {
                    DataRow[] rUpb = Upb.tCdsUpb.Select("(idcen = " +
                        QueryCreator.quotedstrvalue(Curr["idcentrospesa"].ToString().Remove(0, 2), false) + ")");
                    if (rUpb.Length > 0) {
                        R["idupb"] = rUpb[0]["idupb"];
                    }
                }
                if (pianocontiiva_migrato && (Curr["idconto"] != DBNull.Value)) {
                    string idconto = Curr["idconto"].ToString().ToUpper();
                    R["idsor1"] = lookupidconto_iva[idconto];
                }
                foreach (string S in new string[] { "annotations", "ct", "cu", "detaildescription", 
                    "yinv", "taxable", "tax", "unabatable", "lt", "lu", "ninv" }) {
                    R[S] = Curr[S];
                }

                InvDet.Rows.Add(R);
            }

          

            DataSet ds = new DataSet();
            ds.Tables.Add(InvDet);

            return Migrazione.lanciaScript(form, destConn, ds, "dettdocumentoiva -> invoicedetail");
        }

        public static bool migraIvaMovSpesa(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("expenseinvoice", null, false) > 0) return true;

            migraTipoDocumentoIva(form, sourceConn, destConn);
            Upb.migraSpesa(form, sourceConn, destConn);

            DataTable All= sourceConn.SQLRunner(
                "SELECT M.codicetipodoc,ct=M.createtimestamp,cu=M.createuser,yinv=M.esercdocumento,"+
                " E.idexp,lt=M.lastmodtimestamp,lu=M.lastmoduser,ninv=M.numdocumento,"+
                "movkind=case when M.tipomovimento ='DOCUM' then 1 when M.tipomovimento='IMPON' then  3 "+
                 "when M.tipomovimento='IMPOS' then 2 else 1 END "+
                " FROM ivamovspesa M "+
                " JOIN spesa S on S.idspesa=M.idspesa "+
                 " JOIN " + getExtAccess(destConn, "expense", false) + " E "+
                 "  ON E.ymov=S.esercmovimento "+
                 "  AND E.nmov= S.nummovimento "+
                 "  AND E.nphase= convert(int,S.codicefase)");
            if (All.Rows.Count == 0) return true;
            DataTable ExpInv = destConn.CreateTableByName("expenseinvoice", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = ExpInv.NewRow();
                R["idinvkind"] = lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                foreach (string S in new string[] { "ct", "cu", "yinv", "idexp", "lt", "lu", "ninv", "movkind" }) {
                    R[S] = Curr[S];
                }
                ExpInv.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(ExpInv);
            return Migrazione.lanciaScript(form, destConn, ds, "ivamovspesa -> expenseinvoice");
        }
        public static bool migraIvaMovEntrata(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("incomeinvoice", null, false) > 0) return true;

            migraTipoDocumentoIva(form, sourceConn, destConn);
            Upb.migraEntrata(form, sourceConn, destConn);
            string sql =
                "SELECT M.codicetipodoc,ct=M.createtimestamp,cu=M.createuser,yinv=M.esercdocumento," +
                " I.idinc,lt=M.lastmodtimestamp,lu=M.lastmoduser,ninv=M.numdocumento," +
                "movkind=case when M.tipomovimento ='DOCUM' then 1 when M.tipomovimento='IMPON' then  3 " +
                 "when M.tipomovimento='IMPOS' then 2 else 1 END " +
                " FROM ivamoventrata M " +
                " JOIN entrata E on E.identrata=M.identrata " +
                 " JOIN " + getExtAccess(destConn, "income", false) + " I " +
                 "  ON I.ymov=E.esercmovimento " +
                 "  AND I.nmov= E.nummovimento " +
                 "  AND I.nphase= convert(int,E.codicefase)";

            DataTable All = sourceConn.SQLRunner(sql);
            if (All.Rows.Count == 0) return true;
            DataTable IncInv = destConn.CreateTableByName("incomeinvoice", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = IncInv.NewRow();
                R["idinvkind"] = lookupidinvkind[Curr["codicetipodoc"].ToString().ToUpper()];
                foreach (string S in new string[] { "ct", "cu", "yinv", "idinc", "lt", "lu", "ninv", "movkind" }) {
                    R[S] = Curr[S];
                }
                IncInv.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(IncInv);
            return Migrazione.lanciaScript(form, destConn, ds, "ivamoventrata -> incomeinvoice");
        }

        
        /// <summary>
        /// Copia dettdocumentoiva in invoicedetail
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>

        public static object idsorkindpiano = DBNull.Value; 

        public static Hashtable lookupidconto_iva = new Hashtable();
        public static bool pianocontiiva_migrato = false;
        static bool funzione_migraPianoDeiConti_eseguita = false;
        public static bool migraPianoDeiConti(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (funzione_migraPianoDeiConti_eseguita) return true;     
            if (destConn.RUN_SELECT_COUNT("sortingkind", "codesorkind='PIANOCONTI'", false) > 0) return true;

            funzione_migraPianoDeiConti_eseguita = true;
            DialogResult dr = MessageBox.Show(form, "Vuoi migrare il piano dei conti come classificazione supplementare?",
                "Domanda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.OK) {
                return true;
            }
            DataTable tPianoLivello = sourceConn.SQLRunner("SELECT * from livellopianoconti");
            if (tPianoLivello == null) return false;

            DataTable tPiano = sourceConn.SQLRunner("SELECT * from pianoconti");
            if (tPiano == null) return false;
            int maxidsorkind = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sortingkind", null, "max(idsorkind)"));
            maxidsorkind++;
            DataTable sortingkind = DataAccess.CreateTableByName(destConn, "sortingkind", "*");
            sortingkind.Clear();
            string codesorkind = "PIANOCONTI";
            idsorkindpiano = maxidsorkind;
            DataRow rSortingKind = sortingkind.NewRow();
            rSortingKind["idsorkind"] = maxidsorkind;
            rSortingKind["codesorkind"] = codesorkind;
            rSortingKind["active"] = "S";
            rSortingKind["description"] = "Piano dei Conti";
            int flag = 0;
            rSortingKind["flag"] = flag;
            rSortingKind["ct"] = DateTime.Now;
            rSortingKind["cu"] = "-";
            rSortingKind["lt"] = DateTime.Now;
            rSortingKind["lu"] = "-";
            sortingkind.Rows.Add(rSortingKind);

            CQueryHelper QHC = new CQueryHelper();

            DataTable sortinglevel = DataAccess.CreateTableByName(destConn, "sortinglevel", "*");
            sortinglevel.Clear();
            foreach (DataRow rPianoLiv in tPianoLivello.Select(null, "codicelivello")) {
                DataRow rSortingLev = sortinglevel.NewRow();
                rSortingLev["idsorkind"] = idsorkindpiano;
                rSortingLev["nlevel"] = CfgFn.GetNoNullInt32(rPianoLiv["codicelivello"]);
                rSortingLev["description"] = rPianoLiv["descrizione"];
                int len = CfgFn.GetNoNullInt32(rPianoLiv["lunghcodice"]);
                int flag2 = 0;
                if (rPianoLiv["tipocodice"].ToString().ToUpper() == "A") flag2 += 1;
                if (rPianoLiv["flagoperativo"].ToString().ToUpper() == "S") flag2 += 2;
                if (rPianoLiv["flagreset"].ToString().ToUpper() == "S") flag2 += 4;
                flag2 += len * 256;
                rSortingLev["flag"] = flag2;

                rSortingLev["ct"] = DateTime.Now;
                rSortingLev["cu"] = "-";
                rSortingLev["lt"] = DateTime.Now;
                rSortingLev["lu"] = "-";

                sortinglevel.Rows.Add(rSortingLev);
            }

            DataTable Sorting = DataAccess.CreateTableByName(destConn, "sorting", "*");
            int maxidsor = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sorting", null, "max(idsor)"));

            foreach (DataRow rPiano in tPiano.Select(null, "codicelivello")) {
                maxidsor++;
                DataRow R = Sorting.NewRow();
                R["idsor"] = maxidsor;
                R["idsorkind"] = idsorkindpiano;
                if (CfgFn.GetNoNullInt32(R["codicelivello"]) > 1) {
                    string filterparent = QHC.CmpEq("idclass", rPiano["livsupidclass"]);
                    DataRow[] Parent = tPiano.Select(filterparent);
                    if (Parent.Length > 0) {
                        string myfilter = QHC.CmpEq("sortcode", Parent[0]["codiceconto"]);
                        DataRow[] myparent = Sorting.Select(myfilter);
                        if (myparent.Length > 0) R["paridsor"] = myparent[0]["idsor"];
                    }
                }
                R["description"] = rPiano["descrizione"];
                R["sortcode"] = rPiano["codiceconto"];
                R["printingorder"] = rPiano["idconto"];
                R["nlevel"] = CfgFn.GetNoNullInt32(rPiano["codicelivello"]);
                R["txt"] = rPiano["notes"];
                R["rtf"] = rPiano["olenotes"];
                R["lu"] = rPiano["lastmoduser"];
                R["cu"] = rPiano["createuser"];
                R["lt"] = rPiano["lastmodtimestamp"];
                R["ct"] = rPiano["createtimestamp"];
                Sorting.Rows.Add(R);

                lookupidconto_iva[rPiano["idconto"].ToString().ToUpper()] = maxidsor;

            }
            DataSet dsClass = new DataSet("a");
            dsClass.Tables.Add(sortingkind);
            dsClass.Tables.Add(Sorting);
            dsClass.Tables.Add(sortinglevel);
            pianocontiiva_migrato = true;
            return Migrazione.lanciaScript(form, destConn, dsClass, "pianoconti, livellopianoconti -> sortingkind, sortinglevel, sorting");
        }
		

        /// <summary>
        /// Per ogni riga di tipodocumentoiva crea n righe di invoicekindyear dove n è il numero di esercizi
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        public static bool creaInvoicekindyear(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("invoicekindyear", null, false) > 0) return true;
            
            migraTipoDocumentoIva(form,sourceConn,destConn);

            string q1 = "select min(esercizio), max(esercizio) from esercizio";
            DataTable tAccountingYear = Migrazione.eseguiQuery(sourceConn, q1, form);
            if (tAccountingYear == null) return false;
            short min = (short)tAccountingYear.Rows[0][0];
            short max = (short)tAccountingYear.Rows[0][1];
            string q2 = "select idinvkind=codicetipodoc, ayear=" + min
                + ", cu=createuser, ct=createtimestamp, lu=lastmoduser, lt=lastmodtimestamp "
                + "from tipodocumentoiva";
            DataTable All = destConn.SQLRunner("SELECT * from invoicekind");
            DataTable InvKindYear = destConn.CreateTableByName("invoicekindyear", "*");

            for (int i = min + 1; i <= max; i++) {
                foreach (DataRow Curr in All.Rows) {
                    DataRow R = InvKindYear.NewRow();
                    foreach (string S in new string[] { "lt", "lu", "ct", "cu", "idinvkind" }) {
                        R[S] = Curr[S];
                    }
                    R["ayear"] = i;

                    InvKindYear.Rows.Add(R);
                }
            }
            if (InvKindYear.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(InvKindYear);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento invoicekindyear ");

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
		public static bool migraIva(Form form, DataAccess sourceConn, DataAccess destConn) 
		{

            if (!migraTipoDocumentoIva(form, sourceConn, destConn)) return false;

            //tiporegistroiva -> ivaregisterkind
            if (!migraTipoRegistroIva(form, sourceConn, destConn)) return false;


            //tipodocoperiva,tipooperregiva-> invoicekindregisterkind
            if (!migraInvoicekindRegisterkind(form, sourceConn, destConn)) return false;

            if (!migraTipoIva(form, sourceConn, destConn)) return false;

            if (!migraTipoPeriodLiqIva(form, sourceConn, destConn)) return false;

            if (!migraRegistroIva(form, sourceConn, destConn)) return false;

            if (!migraDocumentoIva(form, sourceConn, destConn)) return false;

            if (!migraPianoDeiConti(form, sourceConn, destConn)) return false;

            if (!migraDettDocumentoIva(form, sourceConn, destConn)) return false;

            if (!migraIvaMovEntrata(form, sourceConn, destConn)) return false;
            if (!migraIvaMovSpesa(form, sourceConn, destConn)) return false;

            if (!creaInvoicekindyear(form, sourceConn, destConn)) return false;

            //liquidazioneiva -> invoicedeferred
            if (!migraInvoiceDeferred(form, sourceConn, destConn)) return false;

            return true;
			
		}

	}
}
