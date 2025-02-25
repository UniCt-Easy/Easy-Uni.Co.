
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.IO;

namespace no_table_trasfdocmandato {
    public partial class Frm_trasfdocmandato : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        IFolderBrowserDialog folderDlg;
        MetaDataDispatcher Disp;
        object idupb = null;
        public DataRow SelectedUpb;
        public Frm_trasfdocmandato() {
            InitializeComponent();
            folderDlg = createFolderBrowserDialog(_folderDlg);

            if (isBlazor())
			{
                txtFolder.Visible = false;
                btnSelezionaFolder.Visible = false;
			}
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Disp = Meta.Dispatcher;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioMandato.Text = Meta.GetSys("esercizio").ToString();
        }

        private void SelezionaCartella()
        {
            if (folderDlg.ShowDialog(this) == DialogResult.OK)
			{
                txtFolder.Text = folderDlg.SelectedPath;
			}
        }

        private void btnSelezionaFolder_Click(object sender, EventArgs e) {
            SelezionaCartella();
        }

        private void btnEseguidownload_Click(object sender, EventArgs e)
        {
            if (isBlazor())
			{
                SelezionaCartella();
			}
            object nstart = HelpForm.GetObjectFromString(typeof(int), txtNumInizio.Text, null);
            object nstop = HelpForm.GetObjectFromString(typeof(int), txtNumFine.Text, null);
            string pathdir = txtFolder.Text;
            object esercMandato = HelpForm.GetObjectFromString(typeof(int), txtEsercizioMandato.Text.ToString(), "x.y.year");
            string errors = "";


			if (pathdir.Equals("")) {
				show("Selezionare una directory per il salvataggio degli allegati", "Avviso");                
			} else {
				QueryHelper QHS = Conn.GetQueryHelper();
                string filtermandato = QHS.CmpEq("ypay", esercMandato);
                string filterKpay = "";
                if (nstart != DBNull.Value && nstop != DBNull.Value) {
                    filtermandato = QHS.AppAnd(filtermandato, QHS.AppAnd(QHS.Between("npay", nstart, nstop)));
                    DataTable tPayments = Conn.RUN_SELECT("payment", "*", null, filtermandato, null, false);
                    filterKpay = QHS.FieldIn("kpay", tPayments.Select());
                    
                }

                if (idupb != null) {
                    //al filtro sul numero mandato(che potrebbe cmq essere null), aggiunge quello per upb
                    filtermandato = QHS.AppAnd(filtermandato, QHS.CmpEq("idupb", idupb));
				    DataTable tExpenselastview = Conn.RUN_SELECT("expenselastview", "*", null, filtermandato, null, false);
                    filterKpay = QHS.AppAnd(filterKpay, QHS.FieldIn("kpay", tExpenselastview.Select()));
                }

                int filesCount = 0;
                AttachmentsManager attachmentsManager;
                AttachmentsManager.DocType[] types = { AttachmentsManager.DocType.mandate, 
                                                       AttachmentsManager.DocType.invoicebuy,
                                                       AttachmentsManager.DocType.itineration,
                                                       AttachmentsManager.DocType.itinerationrefund
                                                     };
				if (filterKpay == "") {
                    show("Indicare un intervallo di mandati oppure selezionare un UPB", "Avviso");
                    return;
                }

                AttachmentsManager attachmentsManagerS = new AttachmentsManager(Conn, pathdir);
                DataTable tPay = Conn.RUN_SELECT("payment", "*", null, filterKpay, null, false);
                foreach (DataRow R in tPay.Select()) {

                    //dstPath: rappresenta la cartella indicata + /mandato_ypay_npay/
                    string dstPath = Path.Combine(pathdir, "mandato_" + R["ypay"].ToString() + "_" + R["npay"].ToString());
                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }
                    // Stampa tutti gli allegati dei documenti associati al mandato corrente
                    foreach (AttachmentsManager.DocType doctype in types) {
                        attachmentsManager = new AttachmentsManager(Conn, doctype, dstPath, null, QHS.CmpEq("kpay",R["kpay"]));
                        filesCount += attachmentsManager.saveAttachments();
                    }

                    string errmess = "";
                    bool res = attachmentsManagerS.stampaMandato(Conn, dstPath, R, out errmess);
					if (!res) {
                        show(errmess);
                    }
					else {
                        filesCount++;
                    }
                }
                // Stampa FE associate ai pagamenti
                string queryFE = "SELECT distinct EL.ypay, EL.npay, sdi_acquisto.* "
                    + " FROM expense E "
                    + " join expenselastview EL on E.idexp = EL.idexp "
                    + " join expenseinvoice EI on EI.idexp = EL.idexp "
                    + " join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv "
                    + " join sdi_acquisto  on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto "
                    + " where sdi_acquisto.xml is not null and " + filterKpay;
                DataTable tFattElettr = Meta.Conn.SQLRunner(queryFE);
                if ((tFattElettr!= null) && (tFattElettr.Rows.Count > 0)) {
                    foreach (DataRow R in tFattElettr.Select()) {
                        string dstPath = Path.Combine(pathdir, "mandato_" + R["ypay"].ToString() + "_" + R["npay"].ToString());
                        if (!Directory.Exists(dstPath)) {
                            Directory.CreateDirectory(dstPath);
                        }
                        string errmess = "";
                        bool res = attachmentsManagerS.stampaFatturaFEacquisto(Conn, dstPath, R, out errmess);
                        if (!res) {
                            show(errmess);
                        }
                        else {
                            filesCount++;
                        }
                        res = attachmentsManagerS.stampaXML_FEacquisto(Conn, dstPath, R, out errmess);
                        if (!res) {
                            show(errmess);
                        }
                        else {
                            filesCount++;
                        }
                    }
                }
                // Stampa DURC validi alla data contabile del mandato
                //Prende gli allegati delle spese, solo quelli attivi.
                // Dobbiamo filtrare le Anagrafiche delle fatture, pagate con i mandati correnti, a cui era spuntato il check DURC
                string queryReg = " SELECT  EL.ypay, EL.npay, registrydurc.*  "
                     + "  FROM expense E "
                     + " join expenselastview EL on E.idexp = EL.idexp "
                     + " join expenseinvoice EI on EI.idexp = EL.idexp "
                     + " join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv "
                     + " join registrydurc  on registrydurc.idreg = EL.idreg "
                     + " where I.requested_doc & 4 <> 0 "
                     + " and EL.paymentadate between registrydurc.start and registrydurc.stop "
                    + " and "+ filterKpay ;
                DataTable tRegistrydurc = Meta.Conn.SQLRunner(queryReg);
                if ((tRegistrydurc != null) && (tRegistrydurc.Rows.Count > 0)) {
                    foreach (DataRow Rdurc in tRegistrydurc.Select()) {
                        string dstPath = Path.Combine(pathdir, "mandato_" + Rdurc["ypay"].ToString() + "_" + Rdurc["npay"].ToString());
                        if (!Directory.Exists(dstPath)) {
                            Directory.CreateDirectory(dstPath);
                        }

                        if (Rdurc["durccertification"] == DBNull.Value) continue;
                        byte[] ByteArray = (byte[])Rdurc["durccertification"];
                        int offset = 0;
                        string fname = GetFileName(ByteArray);
                        fname = "DURC_Anagr_" + Rdurc["idreg"].ToString() + "_" + fname;
                        string sw = Path.Combine(dstPath, fname);
                        try {
                            ScriviFile(sw, ByteArray, offset);
                        }
                        catch (Exception E) {
                            QueryCreator.ShowException(E);
                        }
                    }
                }
                // Stampa CC dedicato: prendiamo l'ultimo attivo
                // lo alleghiamo se il pagamento lo prevede
                //< expenselast.paymethod_flag & 32768  = 0
                string queryCC = " SELECT  EL.ypay, EL.npay, registrypaymethod.*  "
                     + "  FROM expense E "
                     + " join expenselastview EL on E.idexp = EL.idexp "
                     + " join registrypaymethod  on registrypaymethod.idreg = EL.idreg  and  registrypaymethod.idregistrypaymethod = EL.idregistrypaymethod"
                     + " where (EL.paymethod_flag  & 32768 ) <> 0 "
                     + " and (registrypaymethod.requested_doc & 1 )<>0 "
                    + " and " + filterKpay;
                DataTable tRegistryCC = Meta.Conn.SQLRunner(queryCC);
                if ((tRegistryCC != null) && (tRegistryCC.Rows.Count > 0)) {
                    foreach (DataRow R in tRegistryCC.Select()) {
                        string dstPath = Path.Combine(pathdir, "mandato_" + R["ypay"].ToString() + "_" + R["npay"].ToString());
                        if (!Directory.Exists(dstPath)) {
                            Directory.CreateDirectory(dstPath);
                        }

                        if (R["ccdedicato_doc"] == DBNull.Value) continue;
                        byte[] ByteArray = (byte[])R["ccdedicato_doc"];
                        int offset = 0;
                        string fname = GetFileName(ByteArray);
                        fname = "CCdedicato_Anagr_" + R["idreg"].ToString() + "_" + fname;
                        string sw = Path.Combine(dstPath, fname);
                        try {
                            ScriviFile(sw, ByteArray, offset);
                        }
                        catch (Exception E) {
                            QueryCreator.ShowException(E);
                        }
                    }
                }

                show("Download eseguito");

			}
		}
        string GetFileName(Byte[] B) {
            int len = 0;
            for (int i = 0; i < B.Length; i++) {
                len++;
                if (B[i] == 0) break;
            }
            byte[] b = new byte[len - 1];
            for (int i = 0; i < len - 1; i++) {
                b[i] = B[i];
            }
            return Encoding.Default.GetString(b);
        }
        public static void ScriviFile(string sw, byte[] documento, int offset) {
            // Legge il documento memorizzato nel DB e lo scrive nel file temp.
            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) return;
            try {
                FS.Write(documento, offset, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();

                MetaFactory.factory.getSingleton<IProcessRunner>()?.start(sw, false);
            }
            catch { }
        }
        private void btnUPB_Click(object sender, EventArgs e) {
            string filter = QHS.CmpEq("active", "S");
            MetaData MetaUpb = Disp.Get("upb");
            MetaUpb.FilterLocked = true;
            MetaUpb.SearchEnabled = false;
            MetaUpb.MainSelectionEnabled = true;
            MetaUpb.StartFilter = filter;
            MetaUpb.ExtraParameter = filter;
            string edittype;
            edittype = "tree";

            bool res = MetaUpb.Edit(this, edittype, true);
            if (!res) return;
            DataRow Selected = MetaUpb.LastSelectedRow;
            riempiTextBox(Selected);
        }
        TextBox GetTxtByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;
            TextBox T = (TextBox)Ctrl.GetValue(this);
            return T;
        }
        private void GestisceTextUpb(TextBox txtUpb) {
            if ((txtUpb==null) || (txtUpb.Text.Trim() == "")) {
                SelectedUpb = null;
                riempiTextBox(SelectedUpb);
                return;
            }
            MetaData MetaUpb = Disp.Get("upb");

            MetaUpb.FilterLocked = true;
            MetaUpb.SearchEnabled = false;
            MetaUpb.MainSelectionEnabled = true;
            MetaUpb.StartFilter = null;
            MetaUpb.startFieldWanted = "codeupb";
            MetaUpb.startValueWanted = null;

            MetaUpb.startValueWanted = txtUpb.Text.Trim();
            string startfield = MetaUpb.startFieldWanted;
            string startvalue = MetaUpb.startValueWanted;

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter = "(" + startfield + "='" + stripped + "')";
                SelectedUpb = MetaUpb.SelectByCondition(filter, "upb");
            }

            if (SelectedUpb == null) {
                string filter = "(codeupb like " + QueryCreator.quotedstrvalue(txtUpb.Text + "%", true) + ")";
                MetaUpb.FilterLocked = true;
                SelectedUpb = MetaUpb.SelectOne("default", filter, "upbview", null);
                riempiTextBox(SelectedUpb);
                return;
            }
            riempiTextBox(SelectedUpb);
        }
        private void riempiTextBox(DataRow Rupb) {
            txtUPB.Text = (Rupb != null) ? Rupb["codeupb"].ToString() : "";
            txtDescrUPB.Text = (Rupb != null) ? Rupb["title"].ToString() : "";
            idupb = (Rupb != null) ? Rupb["idupb"] : null;
        }

		private void txtUPB_Leave(object sender, EventArgs e) {

		}

		private void txtUPB_TextChanged(object sender, EventArgs e) {
            TextBox T = (TextBox)sender;
            if (!T.Modified) return;
            //string suffix = T.Name.Substring(6);
            //TextBox T1 = GetTxtByName("txtUPB");
            GestisceTextUpb(txtUPB);
        }
	}

}
