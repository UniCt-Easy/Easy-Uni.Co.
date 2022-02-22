
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
using funzioni_configurazione;

namespace no_table_esitoreversali {
    public partial class FrmNotableEsitoreversali : MetaDataForm {
        private string MESSAGGIO = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse per selezionare più ";
        private MetaData meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public FrmNotableEsitoreversali() {
            InitializeComponent();
        }

        #region aggiornaDataGrid: in base al radiobutton selezionato aggiorna il grid

        private void aggiornaDataGrid(string tipoMovimenti) {
            Cursor = Cursors.WaitCursor;
            label1.Text = MESSAGGIO + tipoMovimenti;
            txtSelezione.Text = null;
            txtDocumentiSelezionati.Text = null;
            fillProceedsView();
            string dataMember = gridReversali.DataMember;
            CurrencyManager cm = (CurrencyManager)gridReversali.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view != null) {
                for (int i = 0; i < cm.Count; i++) {
                    gridReversali.UnSelect(i);
                }
                new formatgrids(gridReversali).AutosizeColumnWidth();
                btnSalva.Enabled = false;
            }
            Cursor = null;
        }
        #endregion

        #region selezioneRigheCambiata: in base alla selezione nel grid aggiorna tutto il resto del form

        private int getPrimaRigaSelezionata(DataView view) {
            for (int i = 0; i < view.Count; i++) {
                if (gridReversali.IsSelected(i)) {
                    return i;
                }
            }
            return -1;
        }

        private DateTime getDateTime(object o) {
            if (o is DBNull) return QueryCreator.EmptyDate();
            return (DateTime)o;
        }

        bool AbilitaAggiornamento = true;
        /// <summary>
        /// In base alle righe selezionate nel grid aggiorna i campi rifbanca, flagesito, dataoperazione e datavaluta
        /// </summary>
        private void selezioneRigheCambiata() {
            if (!AbilitaAggiornamento) return;
            CurrencyManager cm = (CurrencyManager)gridReversali.BindingContext[DS, gridReversali.DataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                return;
            }
            string elenco = "";
            for (int i = 0; i < view.Count; i++) {
                if (gridReversali.IsSelected(i)) {
                    elenco += "," + view[i]["npro"];
                }
            }
            
            if (elenco != "") elenco = elenco.Remove(0, 1);

            bool esisteSelezione = elenco != "";
            btnSalva.Enabled = esisteSelezione;

            txtDocumentiSelezionati.Text = elenco;
        }

        #endregion

        #region selezionaIDocumentiInBaseATextBox: in base al contenuto di txtSelezione seleziona le righe del grid
        /// <summary>
        /// In base al contenuto di txtSelezione seleziona le righe del grid
        /// </summary>
        private void selezionaIDocumentiInBaseATextBox() {
            string dataMember = gridReversali.DataMember;
            CurrencyManager cm = (CurrencyManager)gridReversali.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return;

            if (txtSelezione.Text == "") {
                txtDocumentiSelezionati.Text = null;
                for (int i = 0; i < cm.Count; i++) {
                    gridReversali.UnSelect(i);
                }
                btnSalva.Enabled = false;
                return;
            }
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (DataRowView r in view) {
                int numDoc = CfgFn.GetNoNullInt32(r["npro"]);
                if (numDoc < min) {
                    min = numDoc;
                }
                if (numDoc > max) {
                    max = numDoc;
                }
            }

            List<int> al = new List<int>();
            string[] valori = txtSelezione.Text.Split(new char[] { ',' });
            foreach (string valore in valori) {
                int pos = valore.IndexOf('-');
                try {
                    if (pos == -1) {
                        int numDoc = Int32.Parse(valore);
                        al.Add(numDoc);
                    }
                    else {
                        string valore1 = valore.Substring(0, pos);
                        string valore2 = valore.Substring(pos + 1);
                        int doc1 = (valore1 == "") ? min : Int32.Parse(valore1);
                        int doc2 = (valore2 == "") ? max : Int32.Parse(valore2);
                        if (doc1 > doc2) {
                            int h = doc1;
                            doc1 = doc2;
                            doc2 = h;
                        }
                        for (int i = doc1; i <= doc2; i++) {
                            al.Add(i);
                        }
                    }
                }
                catch (FormatException) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nella selezione desiderata: " + valore + "\nImmettere i numeri dei movimenti e/o gli intervalli dei movimenti separati da virgole.");
                    return;
                }
            }
            for (int i = 0; i < cm.Count; i++) {
                int numDoc = (int)view[i]["npro"];
                int pos = al.IndexOf(numDoc);
                if (pos != -1) {
                    gridReversali.Select(i);
                }
                else {
                    gridReversali.UnSelect(i);
                }
            }
            selezioneRigheCambiata();
        }
        #endregion

        public void MetaData_AfterLink() {
            meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();
            HelpForm.SetAllowMultiSelection(DS.proceedsview, true);
            GetData.SetSorting(DS.proceedsview, "npro");
            MetaData.SetDefault(DS.banktransaction, "kind", "C");
            MetaData.SetDefault(DS.banktransaction, "yban", meta.GetSys("esercizio"));
        }

        //private void impostaCaption() {
        //    if (DS.incomeview == null) return;

        //    foreach (DataColumn C in DS.incomeview.Columns) {
        //        DS.incomeview.Columns[C.ColumnName].Caption = "";
        //    }
        //    //DS.incomeview.Columns["ymov"].Caption = "Eserc. Mov.";
        //    DS.incomeview.Columns["nmov"].Caption = "Num. Mov.";
        //    DS.incomeview.Columns["description"].Caption = "Descrizione";
        //    DS.incomeview.Columns["registry"].Caption = "Versante";
        //    DS.incomeview.Columns["curramount"].Caption = "Importo";
        //    //DS.incomeview.Columns["ypro"].Caption = "Eserc. Reversale";
        //    DS.incomeview.Columns["npro"].Caption = "Num. Reversale";
        //    DS.incomeview.Columns["idpro"].Caption = "Num. Operazione";
        //}

        private void fillProceedsView() {
            DS.proceedsview.Clear();

            //string q1 = " exists (select * from incomeview where"
            //    + QHS.AppAnd(
            //        QHS.CmpEq("proceedsview.ypro",QHS.Field("incomeview.ypro")),
            //        QHS.CmpEq("proceedsview.npro",QHS.Field("incomeview.npro")));
            //string q2 = " not exists (select * from banktransaction where"
            //    + QHS.AppAnd(
            //        QHS.CmpEq("banktransaction.ypro",QHS.Field("incomeview.ypro")),
            //        QHS.CmpEq("banktransaction.npro",QHS.Field("incomeview.npro")), 
            //        QHS.CmpEq("banktransaction.idpro",QHS.Field("incomeview.idpro")),
            //        QHS.CmpEq("banktransaction.idinc",QHS.Field("incomeview.idinc)")));

            //string filtro = QHS.AppAnd(
            //    QHS.CmpEq("yproceedstransmission", meta.GetSys("esercizio")),
            //    q1, q2) + ")";

            string filtro = QHS.AppAnd(
                QHS.CmpEq("ypro", meta.GetSys("esercizio")),
                QHS.IsNotNull("yproceedstransmission"),
                QHS.NullOrEq("performed", 0));

            meta.Conn.RUN_SELECT_INTO_TABLE(DS.proceedsview, "ypro,npro", filtro, null, false);

            if (gridReversali.DataSource == null) {
                HelpForm.SetDataGrid(gridReversali, DS.proceedsview);
                new formatgrids(gridReversali).AutosizeColumnWidth();
            }
        }

        public void MetaData_AfterActivation() {
            //impostaCaption();
            fillProceedsView();
            btnSalva.Enabled = false;
        }

        private void esita() {
            if (txtDataOperaz.Text == "") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Inserire la data di operazione");
                txtDataOperaz.Focus();
                return;
            }
            string dataMember = gridReversali.DataMember;
            CurrencyManager cm = (CurrencyManager)gridReversali.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return;

            object bankReference = txtRifBanca.Text;
            object transactionDate = HelpForm.GetObjectFromString(typeof(DateTime), txtDataOperaz.Text, "x.y");
            if (transactionDate != DBNull.Value)
            {
                {
                    try
                    {
                        DateTime a = (DateTime)transactionDate;
                    }
                    catch
                    {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Data operazione non valida");
                        return;
                    }
                }
            }
            object valueDate = HelpForm.GetObjectFromString(typeof(DateTime), txtDataValuta.Text, "x.y");
            if (valueDate != DBNull.Value)
            {
                try
                {
                    DateTime a = (DateTime)valueDate;
                }
                catch
                {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Data valuta non valida");
                    return;
                }
            }

            string messaggio = "";
            for (int i = 0; i < view.Count; i++) {
                if (gridReversali.IsSelected(i)) {
                    messaggio += "," + view[i]["npro"];

                }
            }
            if (messaggio == "") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Nessuna reversale selezionata");
                return;
            }
            messaggio = messaggio.Substring(1);

            DS.incomeview.Clear();
            string filtro = QHS.AppAnd(
                QHS.CmpEq("ypro", meta.GetSys("esercizio")),
                QHS.FieldInList("npro", messaggio),
                "(curramount > (select isnull(sum(amount),0) from banktransaction where"
                + QHS.AppAnd(
                    QHS.CmpEq("banktransaction.kpro", QHS.Field("incomeview.kpro")),
                    QHS.CmpEq("banktransaction.idpro", QHS.Field("incomeview.idpro")),
                    QHS.CmpEq("banktransaction.idinc", QHS.Field("incomeview.idinc))"))));

            meta.Conn.RUN_SELECT_INTO_TABLE(DS.incomeview, null, filtro, null, false);

            DS.banktransaction.Clear();
            MetaData metaBT = MetaData.GetMetaData(this, "banktransaction");
            foreach (DataRow rInc in DS.incomeview.Rows) {
                string filtroEsitato = QHS.MCmp(rInc, "ypro", "npro", "idpro", "idinc");
                object esitato = meta.Conn.DO_READ_VALUE("banktransaction", filtroEsitato, "sum(amount)");

                meta.SetDefaults(DS.banktransaction);
                DataRow r = metaBT.Get_New_Row(rInc, DS.banktransaction);
                r["bankreference"] = bankReference;
                r["transactiondate"] = transactionDate;
                r["valuedate"] = valueDate;
                r["amount"] = CfgFn.GetNoNullDecimal(rInc["curramount"]) - CfgFn.GetNoNullDecimal(esitato);
                r["kpro"] = rInc["kpro"];
                r["idpro"] = rInc["idpro"];
                r["idinc"] = rInc["idinc"];
            }
            PostData pd = meta.Get_PostData();
            pd.InitClass(DS, meta.Conn);
            if (pd.DO_POST()) {
                messaggio = "Per esitare le seguenti reversali: " + messaggio;
                if (DS.banktransaction.Rows.Count == 1) {
                    messaggio += "\nè stata creata la transazione bancaria n°" + DS.banktransaction.Rows[0]["nban"];
                }
                else {
                    messaggio += "\nsono state create le transazioni bancarie dalla n°"
                        + DS.banktransaction.Rows[0]["nban"]
                        + " alla n°"
                        + DS.banktransaction.Rows[DS.banktransaction.Rows.Count - 1]["nban"];
                }
                messaggio += "\nassegnando i seguenti valori:"
                    + "\nrif. banca: '" + bankReference
                    + "'\ndata operazione: '" + HelpForm.StringValue(transactionDate, "x.y")
                    + "'\ndata valuta: '" + HelpForm.StringValue(valueDate, "x.y") + "'";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, messaggio, "DB AGGIORNATO CORRETTAMENTE");
            }
            else {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore durante l'aggiornamento del D.B.!", "ERRORE");
            }
            aggiornaDataGrid("MOVIMENTI esitati totalmente");
            decimal importoTot = ricalcolaImportoTotale();
            txtImporto.Text = importoTot.ToString("c");
        }

        private void btnSalva_Click(object sender, System.EventArgs e) {
            AbilitaAggiornamento = false;
            esita();
            AbilitaAggiornamento = true;
            selezioneRigheCambiata();
        }

        private void txtDataOperaz_Leave(object sender, System.EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataOperaz, "x.y");
        }

        private void txtDataValuta_Leave(object sender, System.EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataValuta, "x.y");
        }

        private void btnSeleziona_Click(object sender, System.EventArgs e) {
            selezionaIDocumentiInBaseATextBox();
            decimal importoTot = ricalcolaImportoTotale();
            txtImporto.Text = importoTot.ToString("c");
        }

        private void gridReversali_MouseClick(object sender, MouseEventArgs e) {
            selezioneRigheCambiata();
            decimal importoTot = ricalcolaImportoTotale();
            txtImporto.Text = importoTot.ToString("c");
        }

        private void gridReversali_CurrentCellChanged(object sender, System.EventArgs e) {
            selezioneRigheCambiata();
        }

        private decimal ricalcolaImportoTotale() {
            decimal importoTot = 0;
            CurrencyManager cm = (CurrencyManager)gridReversali.BindingContext[DS, gridReversali.DataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                return importoTot;
            }

            for (int i = 0; i < view.Count; i++) {
                if (gridReversali.IsSelected(i)) {
                    importoTot += CfgFn.GetNoNullDecimal(view[i]["total"]);
                }
            }
            return importoTot;
        }
    }
}
