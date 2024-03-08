
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace entry_apertura {
    public partial class FrmEntry_Apertura : Form {
        MetaData Meta;
        DataTable tAccountLookUp;
        CQueryHelper QHC;
        QueryHelper QHS;
        public FrmEntry_Apertura() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            tAccountLookUp = DataAccess.CreateTableByName(Meta.Conn, "accountlookup", "oldidacc, newidacc");
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

        private void btnApertura_Click(object sender, EventArgs e) {
            if (!doApertura()) {
                MessageBox.Show(this, "Errore nel processo di apertura dei conti", "Errore");
            }
        }


        private bool doApertura() {
            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");

            /*
                Estrae tuti i dettagli scrittura associati allo stato patrimoniale, della scrittura di epilogo dell'anno precedente.
                TODO
                Deve fare questo calcolo distinguendo per idupb, idreg
            */

            int esercizio = (int)Meta.GetSys("esercizio");
            int lastEsercizio = esercizio - 1;
            string query = "SELECT ED.amount, ED.idacc, ED.idupb, ED.idreg "
            + " FROM entrydetail ED "
            + " JOIN entry E "
            + " ON E.yentry = ED.yentry AND E.nentry = ED.nentry "
            + " JOIN account ACC "
            + " ON " + QHS.CmpEq("ED.idacc", QHS.Field("ACC.idacc"))
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("ED.yentry", lastEsercizio),
            QHS.CmpEq("ACC.ayear", lastEsercizio), QHS.CmpEq("E.identrykind", 6), //scrittura di epilogo
            QHS.IsNotNull("ACC.idpatrimony"));

            DataTable tSaldo = Meta.Conn.SQLRunner(query);

            if (tSaldo == null) {
                MessageBox.Show(this, "Errore nella query che estrae i conti da aprire", "Errore");
                return false;
            }

            if (tSaldo.Rows.Count == 0) {
                MessageBox.Show(this, "La tabella dei saldi risulta vuota, procedura di apertura non eseguita", "Avvertimento");
                return true;
            }

            DataRow rEntry = fillEntry(tEntry);

            if (rEntry == null) {
                MessageBox.Show(this, "Errore nella creazione della scrittura", "Errore");
                return false;
            }

            decimal sumSP = 0;
            bool addedSP = false;

            foreach (DataRow rSaldo in tSaldo.Rows) {
                

                if (!addedSP) addedSP = true;
                sumSP += CfgFn.GetNoNullDecimal(rSaldo["amount"]);

                fillEntryDetail(tEntryDetail, rEntry, rSaldo);
            }

            if (addedSP) {
                string f = QHS.CmpEq("ayear", esercizio);

                object idaccPAT = Meta.Conn.DO_READ_VALUE("config", f, "idacc_patrimony");

                if ((idaccPAT == null) || (idaccPAT == DBNull.Value)) {
                    MessageBox.Show(this, "Non è stato selezionato il conto che pareggia l'epilogo dei conti patrimoniali", "Errore");
                    return false;
                }

                fillEntryDetail(tEntryDetail, rEntry, idaccPAT, sumSP);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Operazione Annullata!");
                return true;
            }

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(ds, Meta.Conn);
            if (Post.DO_POST()) {
                DataRow rEntryPosted = tEntry.Rows[0];
                EditEntry(rEntryPosted);
                MessageBox.Show(this, "Integrazione dei residui completata con successo!");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di integrazione!", "Errore");
                return false;
            }

            return true;
        }

        void EditEntry(DataRow R) {
            if (R == null) return;
            EditRelatedEntryByKey(R);
        }

        public void EditRelatedEntryByKey(DataRow rEntry) {
            if (rEntry == null) return;
            object yentry = rEntry["yentry"];
            object nentry = rEntry["nentry"];
            if ((yentry == DBNull.Value) || (nentry == DBNull.Value)) return;
            MetaData ToMeta = Meta.Dispatcher.Get("entry");
            if (ToMeta == null) return;
            string checkfilter = QHS.AppAnd(QHS.CmpEq("yentry", yentry), QHS.CmpEq("nentry", nentry));
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.LinkedForm != null) F = Meta.LinkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        private object attualizzaAccount(string oldidacc) {
            int currYear = (int)Meta.GetSys("esercizio");
            string fAcc = QHC.CmpEq("oldidacc", oldidacc);

            if (tAccountLookUp.Select(fAcc).Length > 0) {
                return tAccountLookUp.Select(fAcc)[0]["newidacc"];
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAccountLookUp, null, fAcc, null, true);

            if (tAccountLookUp.Select(fAcc).Length > 0) {
                return tAccountLookUp.Select(fAcc)[0]["newidacc"];
            }
            DataRow rAccountLookUp = tAccountLookUp.NewRow();
            rAccountLookUp["oldidacc"] = oldidacc;
            rAccountLookUp["newidacc"] = currYear.ToString().Substring(2, 2) + oldidacc.Substring(2, oldidacc.Length - 2);
            tAccountLookUp.Rows.Add(rAccountLookUp);
            return rAccountLookUp["newidacc"];
        }

        private DataRow fillEntry(DataTable tEntry) {
            int esercizio = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("yentry", esercizio);

            object nEntry = Meta.Conn.DO_READ_VALUE("entry", filter, "MAX(nentry)");
            if (nEntry == null) {
                MessageBox.Show(this, "Errore nel calcolo dell'ultima scrittura", "Errore");
                return null;
            }
            int freeN = 1 + CfgFn.GetNoNullInt32(nEntry);

            DataRow rEntry = tEntry.NewRow();
            DateTime dec31 = new DateTime(esercizio, 12, 31);
            rEntry["yentry"] = esercizio;
            rEntry["nentry"] = freeN;
            rEntry["identrykind"] = "7";
            rEntry["adate"] = dec31;
            rEntry["description"] = "Scrittura di apertura esercizio " + esercizio;
            rEntry["ct"] = DateTime.Now;
            rEntry["cu"] = "APERTURA";
            rEntry["lt"] = DateTime.Now;
            rEntry["lu"] = "'APERTURA'";

            tEntry.Rows.Add(rEntry);

            return rEntry;
        }

        private bool fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, DataRow rSaldo) {
            object newidAcc = attualizzaAccount(rSaldo["idacc"].ToString());
            decimal reverseAmount = - CfgFn.GetNoNullDecimal(rSaldo["amount"]);
            if (newidAcc == null) {
                MessageBox.Show(this, "Errore nell'attualizzazione del conto", "Errore");
                return false;
            }

            DataRow rEntryDetail = tEntryDetail.NewRow();
            object nDetMax = tEntryDetail.Compute("MAX(ndetail)", null);
            int freeDetail = 1 + CfgFn.GetNoNullInt32(nDetMax);
            rEntryDetail["yentry"] = rEntry["yentry"];
            rEntryDetail["nentry"] = rEntry["nentry"];
            rEntryDetail["ndetail"] = freeDetail;
            rEntryDetail["amount"] = reverseAmount;
            rEntryDetail["idacc"] = newidAcc;
            rEntryDetail["idreg"] = rSaldo["idreg"];
            rEntryDetail["idupb"] = rSaldo["idupb"];
            rEntryDetail["ct"] = DateTime.Now;
            rEntryDetail["cu"] = "APERTURA";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'APERTURA'";

            tEntryDetail.Rows.Add(rEntryDetail);
            return true;
        }

        private bool fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, object idacc, decimal amount) {
            DataRow rEntryDetail = tEntryDetail.NewRow();
            object nDetMax = tEntryDetail.Compute("MAX(ndetail)", null);
            int freeDetail = 1 + CfgFn.GetNoNullInt32(nDetMax);
            rEntryDetail["yentry"] = rEntry["yentry"];
            rEntryDetail["nentry"] = rEntry["nentry"];
            rEntryDetail["ndetail"] = freeDetail;
            rEntryDetail["amount"] = amount;
            rEntryDetail["idacc"] = idacc;
            rEntryDetail["ct"] = DateTime.Now;
            rEntryDetail["cu"] = "APERTURA";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'APERTURA'";

            tEntryDetail.Rows.Add(rEntryDetail);
            return true;
        }
    }
}
