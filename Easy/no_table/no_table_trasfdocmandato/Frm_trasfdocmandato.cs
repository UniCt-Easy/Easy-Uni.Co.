
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
namespace no_table_trasfdocmandato {
    public partial class Frm_trasfdocmandato : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;

        IFolderBrowserDialog folderDlg;

        public Frm_trasfdocmandato() {
            InitializeComponent();
            folderDlg = createFolderBrowserDialog(_folderDlg);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioMandato.Text = Meta.GetSys("esercizio").ToString();
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
            object esercMandato = HelpForm.GetObjectFromString(typeof(int), txtEsercizioMandato.Text.ToString(), "x.y.year");
            string errors = "";


			if (pathdir.Equals("")) {
				show("Selezionare una directory per il salvataggio degli allegati", "Avviso");                
			} else {
				QueryHelper QHS = Conn.GetQueryHelper();
				string filtermandato = QHS.AppAnd(QHS.Between("npay", nstart, nstop), QHS.CmpEq("ypay", esercMandato));
				DataTable tPayments = Conn.RUN_SELECT("payment", "*", null, filtermandato, null, false);
				string filterView = QHS.FieldIn("kpay", tPayments.Select());

				int filesCount = 0;
				AttachmentsManager attachmentsManager;
                AttachmentsManager.DocType[] types = { AttachmentsManager.DocType.mandate, 
                                                       AttachmentsManager.DocType.invoicebuy,
                                                       AttachmentsManager.DocType.itineration,
                                                       AttachmentsManager.DocType.itinerationrefund
                                                     };
				foreach (AttachmentsManager.DocType doctype in types) {
					attachmentsManager = new AttachmentsManager(Conn, doctype, pathdir, null, filterView);
					filesCount += attachmentsManager.saveAttachments();
				}
                AttachmentsManager attachmentsManagerS = new AttachmentsManager(Conn, pathdir);
                foreach (DataRow R in tPayments.Select()) {
                    string errmess = "";
                    bool res = attachmentsManagerS.stampaMandato(Conn, pathdir, R, out errmess);
					if (!res) {
                        show(errmess);
                    }
					else {
                        filesCount++;
                    }
				}
                // Stampa FE associate ai pagamenti
                string queryFE = "SELECT distinct sdi_acquisto.* "
                    + " FROM expense E "
                    + " join expenselast EL on E.idexp = EL.idexp "
                    + " join expenseinvoice EI on EI.idexp = EL.idexp "
                    + " join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv "
                    + " join sdi_acquisto  on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto "
                    + " where sdi_acquisto.xml is not null and " + filterView;
                DataTable tFattElettr = Meta.Conn.SQLRunner(queryFE);
                if (tFattElettr.Rows.Count > 0) {
                    foreach (DataRow R in tFattElettr.Select()) {
                        string errmess = "";
                        bool res = attachmentsManagerS.stampaFatturaFEacquisto(Conn, pathdir, R, out errmess);
                        if (!res) {
                            show(errmess);
                        }
                        else {
                            filesCount++;
                        }
                        res = attachmentsManagerS.stampaXML_FEacquisto(Conn, pathdir, R, out errmess);
                        if (!res) {
                            show(errmess);
                        }
                        else {
                            filesCount++;
                        }
                    }
                }
                show("Download eseguito");

			}
		}
    }
}
