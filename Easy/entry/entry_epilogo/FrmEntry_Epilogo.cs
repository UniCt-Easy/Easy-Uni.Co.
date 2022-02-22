
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
using funzioni_configurazione;
using metadatalibrary;

namespace entry_epilogo {
    public partial class FrmEntry_Epilogo : Form {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmEntry_Epilogo() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
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

        private void btnEpilogo_Click(object sender, EventArgs e) {
            if (chkContoEconomico.Checked == false && chkStatoPatrimoniale.Checked == false) {
                MessageBox.Show("E' necessario selezionare almeno una dei due tipi scrittura (conto economico/stato patrimoniale)", "Errore");
                return;
            }
            if (!doEpilogo()) {
                MessageBox.Show(this, "Errore nel processo di epilogo", "Errore");
            }
        }

        private bool doEpilogo() {
            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            int esercizio = (int)Meta.GetSys("esercizio");

            string filter = QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio),
                                        QHS.CmpEq("ACC.ayear", esercizio));

            if (chkStatoPatrimoniale.Checked == false) {
                filter = QHS.AppAnd(filter, QHS.IsNull("ACC.idpatrimony"));
            }
            if (chkContoEconomico.Checked == false) {
                filter = QHS.AppAnd(filter, QHS.IsNull("ACC.idplaccount"));
            }
            /*
            Deve discriminare  idupb/idreg nel pareggio conti patrimmoniali ed economici.

            Se il saldo del epilogo del conto economico è diverso da zero, lo devo pareggiare con una scrittura che coinvolga il conto di config
             risultato economico
             In entry kind aggiungere "Risultato economico"
             e la scrittura suddetta sarà di questo tipo

            Ordine delle operazioni:
             epilogo conto economico suddiviso per upb - anagrafica
            
             risultato economico suddiviso per upb - anagrafica

             epilogo stato patrimoniale suddiviso per upb - anagrafica

            */
            string query = "SELECT -SUM(ED.amount) AS amount, ED.idacc, ED.idupb, ED.idreg, "
            + " CASE "
	        + " WHEN " + QHS.IsNotNull("ACC.idpatrimony") + " THEN 'P' "
	        + " WHEN " + QHS.IsNotNull("ACC.idplaccount") + " THEN 'E' "
	        + " ELSE NULL "
            + " END AS tipo "
            + " FROM entrydetail ED "
            + " JOIN account ACC "
            + " ON " + QHS.CmpEq("ED.idacc", QHS.Field("ACC.idacc"))
            + " WHERE " + filter
            + " GROUP BY ED.idacc, ED.idupb, ED.idreg, ACC.idplaccount, ACC.idpatrimony "
            + " HAVING " + QHS.CmpNe("SUM(ED.amount)", 0);

            DataTable tSaldo = Meta.Conn.SQLRunner(query);

            if (tSaldo == null) {
                MessageBox.Show(this, "Errore nella query che estrae i conti da epilogare", "Errore");
                return false;
            }

            if (tSaldo.Rows.Count == 0) {
                MessageBox.Show(this, "La tabella dei saldi risulta vuota, procedura di epilogo non eseguita", "Avvertimento");
                return true;
            }

            decimal sumCE = 0;
            decimal sumSP = 0;
            bool addedCE = false;
            bool addedSP = false;
            DataRow rEntry = fillEntry(tEntry);

            if (rEntry == null) {
                MessageBox.Show(this, "Errore nella creazione della scrittura", "Errore");
                return false;
            }

            string f = QHS.CmpEq("ayear", esercizio);

            object idaccPAT = Meta.Conn.DO_READ_VALUE("config", f, "idacc_patrimony");

            if (chkStatoPatrimoniale.Checked) {
                if ((idaccPAT == null) || (idaccPAT == DBNull.Value)) {
                    MessageBox.Show(this, "Non è stato selezionato il conto che pareggia l'epilogo dei conti patrimoniali", "Errore");
                    return false;
                }
            }


            object idaccPL = Meta.Conn.DO_READ_VALUE("config", f, "idacc_pl");
            if (chkContoEconomico.Checked) {
                if ((idaccPL == null) || (idaccPL == DBNull.Value)) {
                    MessageBox.Show(this, "Non è stato selezionato il conto che pareggia l'epilogo dei conti economici", "Errore");
                    return false;
                }
            }

            foreach (DataRow rSaldo in tSaldo.Rows) {
                string tipo = rSaldo["tipo"].ToString().ToUpper();

                if (tipo == "") continue;

                object currIdAcc = rSaldo["idacc"];
                if ((currIdAcc.Equals(idaccPAT)) || (currIdAcc.Equals(idaccPL))) continue;

                if (tipo == "P") {
                    if (!addedSP) addedSP = true;
                    sumSP += CfgFn.GetNoNullDecimal(rSaldo["amount"]);
                }

                if (tipo == "E") {
                    if (!addedCE) addedCE = true;
                    sumCE += CfgFn.GetNoNullDecimal(rSaldo["amount"]);
                }

                fillEntryDetail(tEntryDetail, rEntry, rSaldo);
            }

            if (addedSP) {
                fillEntryDetail(tEntryDetail, rEntry, idaccPAT, -sumSP);
            }

            if (addedCE) {
                fillEntryDetail(tEntryDetail, rEntry, idaccPL, -sumCE);
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
                MessageBox.Show(this, "Epilogo completato con successo!");
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
            rEntry["identrykind"] = 6;
            rEntry["adate"] = dec31;
            string descr = "Scrittura di epilogo esercizio " + esercizio;
            if (!chkContoEconomico.Checked) descr += " (Stato Patrimoniale)";
            if (!chkStatoPatrimoniale.Checked) descr += " (Conto Economico)";
            rEntry["description"] = descr;
            rEntry["ct"] = DateTime.Now;
            rEntry["cu"] = "EPILOGO";
            rEntry["lt"] = DateTime.Now;
            rEntry["lu"] = "'EPILOGO'";

            tEntry.Rows.Add(rEntry);

            return rEntry;
        }

        private bool fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, DataRow rSaldo) {
            DataRow rEntryDetail = tEntryDetail.NewRow();
            object nDetMax = tEntryDetail.Compute("MAX(ndetail)", null);
            int freeDetail = 1 + CfgFn.GetNoNullInt32(nDetMax);
            rEntryDetail["yentry"] = rEntry["yentry"];
            rEntryDetail["nentry"] = rEntry["nentry"];
            rEntryDetail["ndetail"] = freeDetail;
            rEntryDetail["amount"] = rSaldo["amount"];
            rEntryDetail["idacc"] = rSaldo["idacc"];
            rEntryDetail["idreg"] = rSaldo["idreg"];
            rEntryDetail["idupb"] = rSaldo["idupb"];
            rEntryDetail["ct"] = DateTime.Now;
            rEntryDetail["cu"] = "EPILOGO";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'EPILOGO'";

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
            rEntryDetail["cu"] = "EPILOGO";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'EPILOGO'";

            tEntryDetail.Rows.Add(rEntryDetail);
            return true;
        }
    }
}
