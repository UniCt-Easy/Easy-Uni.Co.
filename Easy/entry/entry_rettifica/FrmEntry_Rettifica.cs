
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using ep_functions;
using funzioni_configurazione;

namespace entry_rettifica {
    public partial class FrmEntry_Rettifica : Form {
        MetaData Meta;
        DataTable tPlAccount;
        DataTable tAccount;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmEntry_Rettifica() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            tPlAccount = DataAccess.CreateTableByName(Meta.Conn, "placcount", "idplaccount, placcpart");
            tAccount = DataAccess.CreateTableByName(Meta.Conn, "account", "idacc, idplaccount");
        }

        public void MetaData_AfterActivation() {
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        public void MetaData_AfterClear() {
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }
        bool AnnoCommerciale = false;
        private void btnRettifica_Click(object sender, EventArgs e) {
            DataTable tEntryDetail = ottieniDettagliScritturaRettifica();
            if (tEntryDetail == null) return;

            AnnoCommerciale = chkCommerciale.Checked;

            if (!doRettifica(tEntryDetail)) {
                MessageBox.Show(this, "Errore nel processo di rettifica dei risconti", "Errore");
            }
            btnRettifica.Enabled = false;
        }
        
        private DataTable ottieniDettagliScritturaProgettiPluriennali() {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);
            string query =
                "select U.idupb,  " +
               " (select sum(ed1.amount) from entrydetail ed1  " +
               " join account AC1 on ed1.idacc = AC1.idacc " +
               " join placcount PL1 on AC1.idplaccount = PL1.idplaccount " +
               "   where ed1.yentry=" + strYear +
               " and ed1.idupb=U.idupb " +
               " and PL1.placcpart = 'C' " +
               " ) as cost, " +
               " (select sum(ed2.amount) from entrydetail ed2 " +
               " join account AC2 on ed2.idacc = AC2.idacc " +
               " join placcount PL2 on AC2.idplaccount = PL2.idplaccount " +
               "  where ed2.yentry=" + strYear +
               " and ed2.idupb=U.idupb " +
               " and PL2.placcpart = 'R' " +
               ") as revenue, " +
               "	(select sum(ed3.amount) from entrydetail ed3  " +
               "		where ed3.idacc = EU.idacc_accruals " +
               "		and ed3.yentry=" + strYear +
               "	) as accruals, " +
               "	EU.idacc_cost, EU.idacc_revenue, " +
               "	EU.idacc_deferredcost,EU.idacc_accruals, " +
               "	year(U.stop) " +
               "  from upb U " +
               "	join epupbkindyear EU on EU.idepupbkind = U.idepupbkind " +
               "	where " +
               "		year(U.stop) <= " + strYear +
               "		and EU.ayear =" + strYear;

            DataTable tPluri = DataAccess.SQLRunner(Meta.Conn, query);
            return tPluri;
        }


        private DataTable ottieniDettagliScritturaRettifica() {
            int currAyear = (int)Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);

            string queryED = "SELECT SUM(d.amount) AS amount, d.idacc, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,"
            + " d.competencystart, d.competencystop, d.idaccmotive FROM entrydetail d "
            + " JOIN entry e ON " + QHS.AppAnd(QHS.CmpEq("e.yentry", QHS.Field("d.yentry")),
            QHS.CmpEq("e.nentry", QHS.Field("d.nentry")))
            + " WHERE " + QHS.AppAnd(QHS.FieldIn("e.identrykind", new object [] {1, 5}),
            QHS.CmpEq("e.yentry", currAyear), QHS.CmpGt("d.competencystop", dec31),
            QHS.CmpLe("d.competencystart", dec31))
            + " GROUP BY d.idacc, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3, d.competencystart, d.competencystop, d.idaccmotive ";

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MessageBox.Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }
            tEntryDetail.TableName = "entrydetail";

            return tEntryDetail;
        }

        private bool doRettifica(DataTable tEntryDetailSource) {
            if (tEntryDetailSource == null) {
                MessageBox.Show(this, "La tabella dei dettagli scritture non è definita", "Errore");
                return false;
            }

            if (tEntryDetailSource.Rows.Count == 0) {
                MessageBox.Show(this, "La tabella dei dettagli scritture risulta vuota", "Avvertimento");
                return true;
            }

            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            tEntryDetail.Columns.Add("!valoreoriginale", typeof(decimal));

            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            ds.Relations.Add("entryentrydetail",
                    new DataColumn[] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                    new DataColumn[] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] }, false);

            int currYear = (int)Meta.GetSys("esercizio");

            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            MEntry.SetDefaults(ds.Tables["entry"]);
            MetaData.SetDefault(ds.Tables["entry"], "yentry", currYear);
            
            DateTime dec31 = new DateTime(currYear, 12, 31);
            string descr = "Rettifica costi/ricavi in risconti";

            DataRow rEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);

            rEntry["identrykind"] = 3;
            rEntry["adate"] = dec31;
            rEntry["description"] = descr;

            DateTime jan01 = new DateTime(1 + currYear, 1, 1);

            string campoRiscontoAttivo = "idacc_deferredrevenue";
            string campoRiscontoPassivo = "idacc_deferredcost";

            object idacc_riscontoA = Meta.Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), campoRiscontoAttivo);
            if ((idacc_riscontoA == null) || (idacc_riscontoA == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione non è stato specificato il conto del risconto attivo", "Errore");
                return false;
            }

            object idacc_riscontoP = Meta.Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), campoRiscontoPassivo);
            if ((idacc_riscontoP == null) || (idacc_riscontoP == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione non è stato specificato il conto del risconto passivo", "Errore");
                return false;
            }
            
            MetaData MEntryDetail = MetaData.GetMetaData(this, "entrydetail");
            MEntryDetail.SetDefaults(ds.Tables["entrydetail"]);

            foreach (DataRow Curr in tEntryDetailSource.Rows) {

                decimal importoDettaglio = CfgFn.GetNoNullDecimal(Curr["amount"]);
                if (importoDettaglio == 0) continue;

                object idAcc = Curr["idacc"];
                string placcpart = valutaIdAcc(idAcc);

                if ((placcpart != "C") && (placcpart != "R")) continue;

                if ((idAcc.Equals(idacc_riscontoA)) || (idAcc.Equals(idacc_riscontoP))) continue;

                DateTime inizioCompetenza = (DateTime)Curr["competencystart"];
                DateTime fineCompetenza = (DateTime)Curr["competencystop"];

                decimal importoRisconto = calcolaRisconto(AnnoCommerciale, (int)Meta.GetSys("esercizio"),
                                    importoDettaglio, inizioCompetenza, fineCompetenza);
                if (importoRisconto == 0) continue;
                

                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
                // perché per come è costruita la tabella le righe sono tutte diverse tra di loro
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                DataRow rEntryDetailCR = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                rEntryDetailCR["amount"] = -importoRisconto;
                rEntryDetailCR["idacc"] = Curr["idacc"];
                rEntryDetailCR["idreg"] = Curr["idreg"];
                rEntryDetailCR["idupb"] = Curr["idupb"];
                rEntryDetailCR["idsor1"] = Curr["idsor1"];
                rEntryDetailCR["idsor2"] = Curr["idsor2"];
                rEntryDetailCR["idsor3"] = Curr["idsor3"];
                rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                rEntryDetailCR["competencystart"] = jan01;
                rEntryDetailCR["competencystop"] = fineCompetenza;
                rEntryDetailCR["!valoreoriginale"] = Math.Abs(importoDettaglio);

                 //EP.EffettuaScrittura(idepcontext, importoRisconto, idAcc, Curr["idreg"], Curr["idupb"],
                //    jan01, Curr["competencystop"], null, Curr["idaccmotive"]);
                object riscontoChoosen = "";
                if (placcpart == "C") {
                    riscontoChoosen = idacc_riscontoA;
                    //EP.EffettuaScrittura(idepcontext, importoRisconto, idacc_riscontoA.ToString(), null, null, null, null);
                }
                else {
                    riscontoChoosen = idacc_riscontoP;
                    //EP.EffettuaScrittura(idepcontext, importoRisconto, idacc_riscontoP.ToString(), null, null, null, null);
                }

                // Dettaglio RISCONTO               
                string filter = costruisciFiltro(riscontoChoosen, Curr);
                if (tEntryDetail.Select(filter).Length > 0) {
                    DataRow rFound = tEntryDetail.Select(filter)[0];
                    rFound["amount"] = CfgFn.GetNoNullDecimal(rFound["amount"]) + importoRisconto;
                }
                else {
                    MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                    MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                    DataRow rEntryDetailRis = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                    rEntryDetailRis["amount"] = importoRisconto;
                    rEntryDetailRis["idacc"] = riscontoChoosen;
                    rEntryDetailRis["idreg"] = Curr["idreg"];
                    rEntryDetailRis["idupb"] = Curr["idupb"];
                    rEntryDetailRis["idsor1"] = Curr["idsor1"];
                    rEntryDetailRis["idsor2"] = Curr["idsor2"];
                    rEntryDetailRis["idsor3"] = Curr["idsor3"];
                    rEntryDetailRis["idaccmotive"] = Curr["idaccmotive"];
                    rEntryDetailRis["competencystart"] = jan01;
                    rEntryDetailRis["competencystop"] = fineCompetenza;
                    rEntryDetailCR["!valoreoriginale"] = importoDettaglio;

                }
            }

            FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn, AnnoCommerciale);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Operazione Annullata!");
                return true;
            }
            PostData Post = MEntry.Get_PostData();
            Post.InitClass(ds, Meta.Conn);

            if (Post.DO_POST()) {
                DataRow rEntryPosted = ds.Tables["entry"].Rows[0];
                EditRelatedEntryByKey(rEntryPosted);
                MessageBox.Show(this, "Rettifica completata con successo!");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di rettifica!", "Errore");
            }

            return true;
        }

        public static int ngiorniCommerciali(DateTime inizio, DateTime fine) {
            int giorni_primomese = inizio.Day > 30 ? 0 : 31 - inizio.Day;
            int giorni_ultimomese = fine.Day == 31 ? 30 : fine.Day;
            int n_anni_inmezzo =  0;
            if (fine.Year - inizio.Year > 1) n_anni_inmezzo = fine.Year - inizio.Year - 1;
            int n_mesi_inmezzo = 0;
            if (fine.Month - inizio.Month > 1) n_mesi_inmezzo = fine.Month - inizio.Month - 1;

            return giorni_primomese + n_anni_inmezzo * 360 + n_mesi_inmezzo * 30 + giorni_ultimomese;

        
        }
        public static int NgiorniTotali(DateTime inizio, DateTime Fine, bool commerciale) {
            if (commerciale) {
                return ngiorniCommerciali(inizio, Fine);
            }
            else {
                return 1 + (Fine - inizio).Days;
            }

        }
        public static int NGiorniDaTrascorrere(DateTime Fine, int currAyear, bool commerciale) {
            if (commerciale) {
                DateTime gen1 = new DateTime(currAyear + 1, 1, 1);
                return ngiorniCommerciali(gen1, Fine);
            }
            else {
                DateTime dec31 = new DateTime(currAyear, 12, 31);
                return (Fine - dec31).Days;
            }
        }

        public static decimal calcolaRisconto(bool ConsideraAnnoCommerciale, int currAyear,
                    decimal importo, DateTime inizioCompetenza, DateTime fineCompetenza) {

            int tot_giorni = NgiorniTotali(inizioCompetenza, fineCompetenza, ConsideraAnnoCommerciale);
            int tot_datrascorrere = NGiorniDaTrascorrere(fineCompetenza, currAyear,ConsideraAnnoCommerciale);
            decimal importoRisconto = (importo / tot_giorni) * tot_datrascorrere;
            return CfgFn.RoundValuta(importoRisconto);          
        }


        /// <summary>
        /// Metodo che costruisce un filtro per C#
        /// </summary>
        /// <param name="risconto"></param>
        /// <param name="rEntryDetail"></param>
        /// <returns></returns>
        private string costruisciFiltro(object risconto, DataRow rEntryDetail) {
            string filter = QHC.CmpEq("idacc", risconto);
            string f2 = QHC.MCmp(rEntryDetail, new string[] {"idreg", "idupb", "idsor1", "idsor2",
                "idsor3", "competencystop", "idaccmotive"});

            filter = QHC.AppAnd(filter, f2);
            return filter;
        }

        private string valutaIdAcc(object idAcc) {
            string filterC = QHC.CmpEq("idacc", idAcc);
            string filterSQL = QHC.CmpEq("idacc", idAcc);
            string filterPLC = "";
            string filterPLSQL = "";

            if (tAccount.Select(filterC).Length > 0) {
                DataRow rAcc = tAccount.Select(filterC)[0];
                filterPLC = QHC.CmpEq("idplaccount", rAcc["idplaccount"]);
                filterPLSQL = QHS.CmpEq("idplaccount", rAcc["idplaccount"]);
            }
            else {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAccount, null, filterSQL, null, true);
                if (tAccount.Select(filterC).Length > 0) {
                    DataRow rAcc = tAccount.Select(filterC)[0];
                    filterPLC = QHC.CmpEq("idplaccount", rAcc["idplaccount"]);
                    filterPLSQL = QHS.CmpEq("idplaccount", rAcc["idplaccount"]);
                }
            }

            if (filterPLC == "") return "";

            if (tPlAccount.Select(filterPLC).Length > 0) {
                return tPlAccount.Select(filterPLC)[0]["placcpart"].ToString().ToUpper();
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tPlAccount, null, filterPLSQL, null, true);

            if (tPlAccount.Select(filterPLC).Length > 0) {
                return tPlAccount.Select(filterPLC)[0]["placcpart"].ToString().ToUpper();
            }

            return "";

        }

        public void EditRelatedEntryByKey(DataRow rEntry) {
            if (rEntry == null) return;
            if ((rEntry["yentry"] == DBNull.Value) || (rEntry["nentry"] == DBNull.Value)) return;
            MetaData ToMeta = Meta.Dispatcher.Get("entry");
            if (ToMeta == null) return;
            string checkfilter = QHS.MCmp(rEntry, new string[] { "yentry", "nentry" });
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.LinkedForm != null) F = Meta.LinkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        private void btnPluriennali_Click(object sender, EventArgs e) {
            DataTable tEntryDetail = ottieniDettagliScritturaProgettiPluriennali();
            if (tEntryDetail == null) return;

            if (!doRettificaPluriennale(tEntryDetail)) {
                MessageBox.Show(this, "Errore nel processo di rettifica per i progetti pluriennali", "Errore");
            }
            btnPluriennali.Enabled = false;
        }

        // tEntryDetailSource: idupb, cost,revenue,accruals,idacc_cost,idacc_revenue,idacc_deferredcost,idacc_accruals,yearstop
        private bool doRettificaPluriennale(DataTable tEntryDetailSource) {
            if (tEntryDetailSource == null) {
                MessageBox.Show(this, "La tabella dei dettagli scritture non è definita", "Errore");
                return false;
            }

            if (tEntryDetailSource.Rows.Count == 0) {
                MessageBox.Show(this, "Nessun importo da rettificare", "Avvertimento");
                return true;
            }

            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            tEntryDetail.Columns.Add("!costi", typeof(decimal));
            tEntryDetail.Columns.Add("!ricavi", typeof(decimal));
            tEntryDetail.Columns.Add("!rateoattivo", typeof(decimal));
            tEntryDetail.Columns.Add("!scadenza", typeof(int));

            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            ds.Relations.Add("entryentrydetail",
                    new DataColumn[] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                    new DataColumn[] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] }, false);

            int currYear = (int)Meta.GetSys("esercizio");

            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            MEntry.SetDefaults(ds.Tables["entry"]);
            MetaData.SetDefault(ds.Tables["entry"], "yentry", currYear);

            DateTime dec31 = new DateTime(currYear, 12, 31);
            string descr = "Rettifica costi/ricavi per progetti pluriennali";

            DataRow rEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);

            rEntry["identrykind"] = 8;
            rEntry["adate"] = dec31;
            rEntry["description"] = descr;

            DateTime jan01 = new DateTime(1 + currYear, 1, 1);

            string campoRicavo = "idacc_revenue";
            string campoCosto = "idacc_cost";
            string campoRateoAttivo = "idacc_accruals";
            string campoRiscontoPassivo = "idacc_deferredcost";

            object idacc_riscontoA = Meta.Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), campoRateoAttivo);
            if ((idacc_riscontoA == null) || (idacc_riscontoA == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione non è stato specificato il conto del rateo attivo per la UPB:....", "Errore");
                return false;
            }

            object idacc_riscontoP = Meta.Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), campoRiscontoPassivo);
            if ((idacc_riscontoP == null) || (idacc_riscontoP == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione non è stato specificato il conto del risconto passivo per la UPB:....", "Errore");
                return false;
            }

            MetaData MEntryDetail = MetaData.GetMetaData(this, "entrydetail");
            MEntryDetail.SetDefaults(ds.Tables["entrydetail"]);
            
           


            foreach (DataRow Curr in tEntryDetailSource.Rows) {
                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
                // perché per come è costruita la tabella le righe sono tutte diverse tra di loro
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                bool annoFine = (CfgFn.GetNoNullInt32(Curr["yearstop"]) == currYear);

                tEntryDetail.Columns.Add("!costi", typeof(decimal));
                tEntryDetail.Columns.Add("!ricavi", typeof(decimal));
               
                

                DataRow rDetail=null;

                if (annoFine) {
                    decimal rateo = CfgFn.GetNoNullDecimal(Curr[campoRateoAttivo]);
                    if (rateo == 0) continue;

                    //genera scrittura COSTO A RATEO ATTIVO

                    rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                    rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                    rDetail["!rateoattivo"] = rateo;     
                    rDetail["amount"] = -rateo;
                    rDetail["idacc"] = Curr[campoCosto];
                    rDetail["idreg"] = DBNull.Value;
                    rDetail["idupb"] = Curr["idupb"];
                    //rDetail["idsor1"] = Curr["idsor1"];
                    //rDetail["idsor2"] = Curr["idsor2"];
                    //rDetail["idsor3"] = Curr["idsor3"];
                    //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                    rDetail["competencystart"] = DBNull.Value;
                    rDetail["competencystop"] = DBNull.Value;

                    rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                    rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                    rDetail["amount"] = rateo;
                    rDetail["idacc"] = Curr[campoRateoAttivo];
                    rDetail["idreg"] = DBNull.Value;
                    rDetail["idupb"] = Curr["idupb"];
                    //rDetail["idsor1"] = Curr["idsor1"];
                    //rDetail["idsor2"] = Curr["idsor2"];
                    //rDetail["idsor3"] = Curr["idsor3"];
                    //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                    rDetail["competencystart"] = DBNull.Value;
                    rDetail["competencystop"] = DBNull.Value;
                }
                else {
                    decimal costi = CfgFn.GetNoNullDecimal(Curr["cost"]);
                    decimal ricavi = CfgFn.GetNoNullDecimal(Curr["revenue"]);
                    if (costi == ricavi) continue;

                    if (costi > ricavi) {
                        decimal importo_rateo = costi - ricavi;
                        //genera scrittura RATEO ATTIVO A RICAVI

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                        rDetail["!ricavi"] = ricavi;
                        rDetail["!costi"] = costi;
                        rDetail["amount"] = importo_rateo;
                        rDetail["idacc"] = Curr[campoRicavo];
                        rDetail["idreg"] = DBNull.Value;
                        rDetail["idupb"] = Curr["idupb"];
                        //rDetail["idsor1"] = Curr["idsor1"];
                        //rDetail["idsor2"] = Curr["idsor2"];
                        //rDetail["idsor3"] = Curr["idsor3"];
                        //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["!ricavi"] = ricavi;
                        rDetail["!costi"] = costi;
                        rDetail["amount"] = -importo_rateo;
                        rDetail["idacc"] = Curr[campoRateoAttivo];
                        rDetail["idreg"] = DBNull.Value;
                        rDetail["idupb"] = Curr["idupb"];
                        //rDetail["idsor1"] = Curr["idsor1"];
                        //rDetail["idsor2"] = Curr["idsor2"];
                        //rDetail["idsor3"] = Curr["idsor3"];
                        //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;
                    }
                    else {
                        decimal importo_risconto = ricavi - costi;
                        //genera scrittura RICAVI A RISCONTI PASSIVI

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                        rDetail["!ricavi"] = ricavi;
                        rDetail["!costi"] = costi;

                        rDetail["amount"] = -importo_risconto;
                        rDetail["idacc"] = Curr[campoRicavo];
                        rDetail["idreg"] = DBNull.Value;
                        rDetail["idupb"] = Curr["idupb"];
                        //rDetail["idsor1"] = Curr["idsor1"];
                        //rDetail["idsor2"] = Curr["idsor2"];
                        //rDetail["idsor3"] = Curr["idsor3"];
                        //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["amount"] = importo_risconto;
                        rDetail["idacc"] = Curr[campoRiscontoPassivo];
                        rDetail["idreg"] = DBNull.Value;
                        rDetail["idupb"] = Curr["idupb"];
                        //rDetail["idsor1"] = Curr["idsor1"];
                        //rDetail["idsor2"] = Curr["idsor2"];
                        //rDetail["idsor3"] = Curr["idsor3"];
                        //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;
                    }
                }

            }

            FrmEntryPreSavePluriennale frm = new FrmEntryPreSavePluriennale(ds.Tables["entrydetail"], Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Operazione Annullata!");
                return true;
            }
            PostData Post = MEntry.Get_PostData();
            Post.InitClass(ds, Meta.Conn);

            if (Post.DO_POST()) {
                DataRow rEntryPosted = ds.Tables["entry"].Rows[0];
                EditRelatedEntryByKey(rEntryPosted);
                MessageBox.Show(this, "Assestamento completato con successo!");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di assestamento!", "Errore");
            }

            return true;
        }
    }
}
