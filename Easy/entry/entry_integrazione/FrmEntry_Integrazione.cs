
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

namespace entry_integrazione {
    public partial class FrmEntry_Integrazione : Form {
        MetaData Meta;
        DataTable tAccountLookUp;
        DataTable tPlAccount;
        DataTable tAccount;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmEntry_Integrazione() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            tAccountLookUp = DataAccess.CreateTableByName(Meta.Conn, "accountlookup", "oldidacc, newidacc");
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

        private void btnIntegrazione_Click(object sender, EventArgs e) {
            DataTable tEntryDetail = ottieniDettagliScrittura();
            if (tEntryDetail == null) return;

            if (!doIntegrazione(tEntryDetail)) {
                MessageBox.Show(this, "Errore nel processo di integrazione dei risconti", "Errore");
            }
        }

        private bool doIntegrazione(DataTable tEntryDetailSource) {
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

            
            DateTime jan01 = new DateTime(currYear, 1, 1);
            object descr = "Integrazione dei risconti";

            DataRow rEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);

            rEntry["identrykind"] = "5";
            rEntry["adate"] = jan01;
            rEntry["description"] = descr;

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
                object newIdAcc = attualizzaAccount(idAcc);
                string placcpart = valutaIdAcc(newIdAcc);

                if ((placcpart != "C") && (placcpart != "R")) continue;
                if ((newIdAcc.Equals(idacc_riscontoA)) || (newIdAcc.Equals(idacc_riscontoP))) continue;

                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
                // perché per come è costruita la tabella le righe sono tutte diverse tra di loro
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                DataRow rEntryDetailCR = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                rEntryDetailCR["amount"] = -importoDettaglio;
                rEntryDetailCR["idacc"] = newIdAcc;
                rEntryDetailCR["idreg"] = Curr["idreg"];
                rEntryDetailCR["idupb"] = Curr["idupb"];
                rEntryDetailCR["idsor1"] = Curr["idsor1"];
                rEntryDetailCR["idsor2"] = Curr["idsor2"];
                rEntryDetailCR["idsor3"] = Curr["idsor3"];
                rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                rEntryDetailCR["competencystart"] = Curr["competencystart"];
                rEntryDetailCR["competencystop"] = Curr["competencystop"];

                //EP.EffettuaScrittura(idepcontext, importoRisconto, idAcc, Curr["idreg"], Curr["idupb"],
                //    jan01, Curr["competencystop"], null, Curr["idaccmotive"]);
                object riscontoChoosen = "";
                if (placcpart == "C") {
                    riscontoChoosen = idacc_riscontoA;
                }
                else {
                    riscontoChoosen = idacc_riscontoP;
                }
                // Dettaglio RISCONTO               
                string filter = costruisciFiltro(riscontoChoosen, Curr);
                if (tEntryDetail.Select(filter).Length > 0) {
                    DataRow rFound = tEntryDetail.Select(filter)[0];
                    rFound["amount"] = CfgFn.GetNoNullDecimal(rFound["amount"]) + importoDettaglio;
                }
                else {
                    MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                    MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                    DataRow rEntryDetailRis = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                    rEntryDetailRis["amount"] = importoDettaglio;
                    rEntryDetailRis["idacc"] = riscontoChoosen;
                    rEntryDetailRis["idreg"] = Curr["idreg"];
                    rEntryDetailRis["idupb"] = Curr["idupb"];
                    rEntryDetailRis["idsor1"] = Curr["idsor1"];
                    rEntryDetailRis["idsor2"] = Curr["idsor2"];
                    rEntryDetailRis["idsor3"] = Curr["idsor3"];
                    rEntryDetailRis["idaccmotive"] = Curr["idaccmotive"];
                    rEntryDetailRis["competencystart"] = Curr["competencystart"];
                    rEntryDetailRis["competencystop"] = Curr["competencystop"];
                }

            }

            FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn);
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
                MessageBox.Show(this, "Integrazione dei residui completata con successo!");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di integrazione!", "Errore");
            }
            return true;
        }

        /// <summary>
        /// Metodo che restituisce un filtro per C#
        /// </summary>
        /// <param name="risconto"></param>
        /// <param name="rEntryDetail"></param>
        /// <returns></returns>
        private string costruisciFiltro(object risconto, DataRow rEntryDetail) {
            string filter = QHC.CmpEq("idacc", risconto);
            string f2 = QHC.MCmp(rEntryDetail, new string[] {"idreg", "idupb", "idsor1", "idsor2",
                "idsor3","competencystart", "competencystop", "idaccmotive"});

            filter = QHC.AppAnd(filter, f2);
            return filter;
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

        private object attualizzaAccount(object oldidacc) {
            int currYear = (int)Meta.GetSys("esercizio");
            string fAccC = QHC.CmpEq("oldidacc", oldidacc);

            if (tAccountLookUp.Select(fAccC).Length > 0) {
                return tAccountLookUp.Select(fAccC)[0]["newidacc"];
            }
            string fAccSQL = QHC.CmpEq("oldidacc", oldidacc);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAccountLookUp, null, fAccSQL, null, true);

            if (tAccountLookUp.Select(fAccC).Length > 0) {
                return tAccountLookUp.Select(fAccC)[0]["newidacc"];
            }
            DataRow rAccountLookUp = tAccountLookUp.NewRow();
            rAccountLookUp["oldidacc"] = oldidacc;
            rAccountLookUp["newidacc"] = currYear.ToString().Substring(2, 2) + oldidacc.ToString().Substring(2, oldidacc.ToString().Length - 2);
            tAccountLookUp.Rows.Add(rAccountLookUp);
            return rAccountLookUp["newidacc"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CoR">Flag che vale C: Costi; R: Ricavi</param>
        /// <returns></returns>
        private DataTable ottieniDettagliScrittura() {
            int lastAyear = (int)Meta.GetSys("esercizio") - 1;
            DateTime dec31 = new DateTime(lastAyear, 12, 31);

            string queryED = "SELECT d.* FROM entrydetail d "
            + " JOIN entry e ON " + QHS.AppAnd(QHS.CmpEq("e.yentry", QHS.Field("d.yentry")),
            QHS.CmpEq("e.nentry", QHS.Field("d.nentry")))
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("e.identrykind", 3), QHS.CmpEq("e.yentry", lastAyear));

            DataTable tEntryDetail = DataAccess.SQLRunner(Meta.Conn, queryED);
            if (tEntryDetail == null) {
                MessageBox.Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }

            tEntryDetail.TableName = "entrydetail";

            return tEntryDetail;
        }

        private DataTable ottieniScritturaRettifica() {
            int lastAyear = (int)Meta.GetSys("esercizio") - 1;
            DateTime dec31 = new DateTime(lastAyear, 12, 31);

            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");

            string filter = QHS.AppAnd(QHS.CmpEq("identrykind", 3), QHS.CmpEq("yentry", lastAyear));

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tEntry, null, filter, null, true);

            tEntry.TableName = "entry";

            return tEntry;
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
    }
}
