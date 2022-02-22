
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_trasfdocreversale {
    public partial class Frm_trasfdocreversale : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        public Frm_trasfdocreversale() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioReversale.Text = Meta.GetSys("esercizio").ToString();
        }

        private void btnSelezionaFolder_Click(object sender, EventArgs e) {
            if (folderDlg.ShowDialog(this) == DialogResult.OK) {
                txtFolder.Text = folderDlg.SelectedPath;
            }
        }

        private void btnEseguidownload_Click(object sender, EventArgs e) {
            object nstart = HelpForm.GetObjectFromString(typeof(int), txtNumInizio.Text, null);
            object nstop = HelpForm.GetObjectFromString(typeof(int), txtNumFine.Text, null);
            string pathdir = txtFolder.Text;
            object esercReversale = HelpForm.GetObjectFromString(typeof(int), txtEsercizioReversale.Text.ToString(), "x.y.year");
            string errors = "";

            if (pathdir.Equals("")) {
                show(this, "Selezionare una directory per il salvataggio degli allegati");
                return;
            }

            QueryHelper QHS = Conn.GetQueryHelper();
            string filterReversale = QHS.AppAnd(QHS.Between("npro", nstart, nstop), QHS.CmpEq("ypro", esercReversale));
            DataTable tProceeds = Conn.RUN_SELECT("proceeds", "*", null, filterReversale, null, false);
            string filterView = QHS.FieldIn("kpro", tProceeds.Select());

            int filesCount = 0;
            AttachmentsManager attachmentsManager; 
            AttachmentsManager.DocType[] types = { AttachmentsManager.DocType.estimate,
                                                   AttachmentsManager.DocType.invoicesell
                                                 };
            //AttachmentsManager.DocType doctype in  Enum.GetValues(typeof(AttachmentsManager.DocType))
            foreach(AttachmentsManager.DocType doctype in types) {
                 attachmentsManager = new AttachmentsManager(Conn, doctype, pathdir, null, filterView);
                 filesCount += attachmentsManager.saveAttachments();
			}
            AttachmentsManager attachmentsManagerS = new AttachmentsManager(Conn, pathdir);
            foreach (DataRow R in tProceeds.Select()) {
                string errmess = "";
                bool res = attachmentsManagerS.stampaReversale(Conn, pathdir, R, out errmess);
                if (!res) {
                    show(errmess);
                }
                else {
                    filesCount++;
                }
            }
            // Stampa FE associate agli incassi
            string queryFE = "SELECT distinct sdi_vendita.*, I.ipa_ven_cliente "
                + " FROM income E "
                + " join incomelast EL on E.idinc = EL.idinc "
                + " join incomeinvoice EI on EI.idinc = EL.idinc "
                + " join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv "
                + " join sdi_vendita  on I.idsdi_vendita = sdi_vendita.idsdi_vendita "
                + " where sdi_vendita.xml is not null and " + filterView;
            DataTable tFattElettr = Meta.Conn.SQLRunner(queryFE);
            if (tFattElettr.Rows.Count > 0) {
                foreach (DataRow R in tFattElettr.Select()) {
                    string errmess = "";
                    bool res = attachmentsManagerS.stampaFatturaFEvendita(Conn, pathdir, R, out errmess);
                    if (!res) {
                        show(errmess);
                    }
                    else {
                        filesCount++;
                    }
                    res = attachmentsManagerS.stampaXML_FEvendita(Conn, pathdir, R, out errmess);
                    if (!res) {
                        show(errmess);
                    }
                    else {
                        filesCount++;
                    }
                }
            }
            show("Downlaod eseguito");
        }
    }
}
