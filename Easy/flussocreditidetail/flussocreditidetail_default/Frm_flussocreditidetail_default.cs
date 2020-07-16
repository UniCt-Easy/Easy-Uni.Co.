/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using ep_functions;
using System.IO;
using pagoPaService;

namespace flussocreditidetail_default {
    public partial class Frm_flussocreditidetail_default :Form {
        MetaData Meta;
        public Frm_flussocreditidetail_default() {
            InitializeComponent();
        }
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;

        public void MetaData_AfterFill() {
            enableControls(false);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
            DataAccess.SetTableForReading(DS.upb_iva, "upb");

            string filterEpOperationCred = QHS.CmpEq("idepoperation", "fatven_cred");
            filterEpOperationCred = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationCred, Meta.Conn);
            GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCred);

            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;


            string filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn);
            DS.accmotiveapplied_revenue.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveapplied_undotax.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            DS.accmotiveapplied_undotaxpost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_revenue, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveapplied_undotax, filterEpOperation);
            GetData.SetStaticFilter(DS.accmotiveapplied_undotaxpost, filterEpOperation);

            DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

            if (tConfig == null || tConfig.Rows.Count == 0) {
                MessageBox.Show("Configurazione annuale non trovata.", "Errore");
                Meta.ErroreIrrecuperabile = true;
                return;
            }


            DataRow R = tConfig.Rows[0];

            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            CfgFn.SetGBoxClass(this, 1, idsorkind1);
            CfgFn.SetGBoxClass(this, 2, idsorkind2);
            CfgFn.SetGBoxClass(this, 3, idsorkind3);
            if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                tabControl1.TabPages.Remove(tabAnalitico);
            }
        }

        public void MetaData_AfterClear() {
            enableControls(true);
        }

        private void enableControls(bool abilita) {
            bool ReadOnly = !abilita;
            cmbIva.Enabled = abilita;
            gboxCausale.Enabled = abilita;
            gboxCompetenza.Enabled = abilita;
            gboxUPB.Enabled = abilita;
            gBoxupbIVA.Enabled = abilita;
            grpCausaleAnnullo.Enabled = abilita;
            grpCausaleAnnulloPre.Enabled = abilita;
            grpCausaleCredito.Enabled = abilita;
            grpCausaleRicavo.Enabled = abilita;
            txtstop.ReadOnly = ReadOnly;
            txtDescrizione.ReadOnly = ReadOnly;
            txtAnnotations.ReadOnly = ReadOnly;
            gboxclass1.Enabled = abilita;
            gboxclass2.Enabled = abilita;
            gboxclass3.Enabled = abilita;
            grpFattura.Enabled = abilita;
            grpRegistry.Enabled = abilita;
            grpRigaContratto.Enabled = abilita;
            groupBoxListino.Enabled = abilita;
            grpFlusso.Enabled = abilita;
            txtListDescription.ReadOnly = ReadOnly;
            txtCF.ReadOnly = ReadOnly;
            txtpiva.ReadOnly = ReadOnly;
            txtquantita.ReadOnly = ReadOnly;
            txtnumdettaglio.ReadOnly = ReadOnly;
            txtDataScadenza.ReadOnly = ReadOnly;
            txtIuv.ReadOnly = ReadOnly;
            txtNForm.ReadOnly = ReadOnly;
            txtAnnullamento.ReadOnly = ReadOnly;

            txtImpostaEUR.ReadOnly = ReadOnly;
            txtCF.ReadOnly = ReadOnly;
            txtVeroIUV.ReadOnly = ReadOnly;
            txtUnivoco.ReadOnly = ReadOnly;
            checkBox1.Enabled = !ReadOnly;
            checkBox2.Enabled = !ReadOnly;
        }

        private void btnRicevuta_Click(object sender, EventArgs e) {
            var curr = DS.flussocreditidetail._First();
            string error;
            var avviso = PagoPaService.ottieniAvvisoPagamento(Conn, curr.iuv, null, out error);
            if (error != null) {
                MessageBox.Show(error, "Errore");
                return;
            }

            fileSave.DefaultExt = "PDF";
            fileSave.AddExtension = true;
            if (fileSave.ShowDialog(this)!=DialogResult.OK)return;
            string fName = fileSave.FileName;
            if (!fName.ToLower().EndsWith(".pdf")) fName += ".pdf";
            try {
                FileStream f = new FileStream(fName, FileMode.Create);
                f.Write(avviso.pdf, 0, avviso.pdf.Length);
                f.Flush();
                f.Close();
                System.Diagnostics.Process.Start(fName);
            }
            catch(Exception E) {
                QueryCreator.ShowException(E);
            }
        }

        private void btnCheckIncassi_Click(object sender, EventArgs e) {
            DataRow curr = DS.flussocreditidetail.Rows[0];
            if (curr["iuv"] == DBNull.Value) {
                MessageBox.Show(this, @"Non è presente lo IUV per il credito, non è possibile interrogare la banca.",
                    @"Avviso");
                return;
            }

            DataTable Incassi = Conn.RUN_SELECT("flussoincassidetailview", "*", null, QHS.CmpEq("iuv", curr["iuv"]),
                null, false);
            if (Incassi.Rows.Count > 0) {
                DataRow rIncasso = Incassi.Rows[0];
                MessageBox.Show(this,
                    $@"E' già presente un incasso collegato, nel flusso di codice {rIncasso["codiceflusso"]}.",
                    "Avviso");
                //return;
            }

            string error;
            var msg = PagoPaService.AggiornaIuv(Conn, curr["iuv"].ToString());
            if (msg != null) {
                MessageBox.Show(this, msg,
                    @"Errore");
                return;
            }

            Incassi = Conn.RUN_SELECT("flussoincassidetailview", "*", null, QHS.CmpEq("iuv", curr["iuv"]), null, false);
            if (Incassi.Rows.Count > 0) {
                DataRow rIncasso = Incassi.Rows[0];
                MessageBox.Show(this,
                    $@"E' stato letto un incasso collegato, nel flusso di codice {rIncasso["codiceflusso"]}.",
                    @"Avviso");
                return;
            }

            MessageBox.Show(this, $@"Non sono stati registrati incassi su questo IUV, nell'esercizio corrente.",
                @"Avviso");
        }
    }

}
