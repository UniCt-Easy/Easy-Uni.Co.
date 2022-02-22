
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
using metaeasylibrary;
using metadatalibrary;
using ep_functions;
using funzioni_configurazione;
using pagoPaService;
using System.IO;

namespace flussocreditidetail_single {
    public partial class Frm_flussocreditidetail_single : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        public Frm_flussocreditidetail_single() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
			DataAccess.SetTableForReading(DS.upb_iva, "upb");
			Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            string filterEpOperationCred = QHS.CmpEq("idepoperation", "fatven_cred");
            filterEpOperationCred = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationCred, Conn as DataAccess);
            DS.accmotiveapplied_credit.setStaticFilter(filterEpOperationCred);
            DS.accmotiveapplied_credit.setTableForReading("accmotiveapplied");
            model.setExtraParams(DS.accmotiveapplied_credit, filterEpOperationCred);

            DS.finmotive_income.setTableForReading("finmotive");

            DS.accmotiveapplied_revenue.setTableForReading("accmotiveapplied");
            DS.accmotiveapplied_undotax.setTableForReading("accmotiveapplied");
            DS.accmotiveapplied_undotaxpost.setTableForReading("accmotiveapplied");
            string filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn as DataAccess);

            model.setExtraParams(DS.accmotiveapplied_revenue, filterEpOperation);
            model.setExtraParams(DS.accmotiveapplied_undotax, filterEpOperation);
            model.setExtraParams(DS.accmotiveapplied_undotaxpost, filterEpOperation);

            DS.accmotiveapplied_revenue.setStaticFilter(filterEpOperation);
            DS.accmotiveapplied_undotax.setStaticFilter(filterEpOperation);
            DS.accmotiveapplied_undotaxpost.setStaticFilter(filterEpOperation);

            cmbIva.DataSource = DS.ivakind;
            cmbIva.DisplayMember = "description";
            cmbIva.ValueMember = "idivakind";
            cmbIva.Enabled = false;

                                                                  

            DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

            if (tConfig == null || tConfig.Rows.Count == 0) {
                show("Configurazione annuale non trovata.", "Errore");
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

        public void MetaData_AfterFill() {
            if (Meta.EditMode) {
                var Curr = DS.flussocreditidetail.First();
                AbilitaDisabilitaModificaCausali(Curr.idestimkind == null && Curr.idinvkind == null);
                AbilitaDisabilitaSalvataggio(Curr.iuv == null);
                btnRicevuta.Visible = (Curr.iuv != null);
            }
        }

        public void AbilitaDisabilitaModificaCausali(bool abilita) {
            bool ReadOnly = !abilita;
            gboxCausale.Enabled = abilita;
            gBoxCausaleIVA.Enabled = abilita;
            gboxCompetenza.Enabled = abilita;
            gboxUPB.Enabled = abilita;

			grpCausaleAnnullo.Enabled = abilita;
            grpCausaleAnnulloPre.Enabled = abilita;
            grpCausaleCredito.Enabled = abilita;
            grpCausaleRicavo.Enabled = abilita;
            txtstop.ReadOnly = ReadOnly;
            txtDescrizione.ReadOnly = ReadOnly;

            txtTassonomia.ReadOnly = ReadOnly;

        }
        public void AbilitaDisabilitaSalvataggio(bool abilita) {
            bool ReadOnly = !abilita;
            if (abilita)
                this.Name = Meta.Name + " (sola lettura)";
            else
                this.Name = Meta.Name;
            
            grpFattura.Enabled = abilita;
            grpRegistry.Enabled = abilita;
            grpRigaContratto.Enabled = abilita;
			groupBoxListino.Enabled = abilita;

			txtListDescription.ReadOnly = ReadOnly;

			txtDataScadenza.ReadOnly = ReadOnly;
            txtIuv.ReadOnly = ReadOnly;
            txtNForm.ReadOnly = ReadOnly;
            txtAnnullamento.ReadOnly = ReadOnly;
        
            txtImpostaEUR.ReadOnly = ReadOnly;
            txtCF.ReadOnly = ReadOnly;
            txtVeroIUV.ReadOnly = ReadOnly;
            txtUnivoco.ReadOnly = ReadOnly;
        }

        private void btnRicevuta_Click(object sender, EventArgs e) {
            var curr = DS.flussocreditidetail._First();
            string error;
            var avviso = PagoPaService.ottieniAvvisoPagamento(Conn, curr.iuv,  out error);
            if (error != null) {
                show(error, "Errore");
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
                runProcess(fName, true);
            }
            catch(Exception E) {
                QueryCreator.ShowException(E);
            }

        }

        private void btnCheckIncassi_Click(object sender, EventArgs e) {
            DataRow curr = DS.flussocreditidetail.Rows[0];
            if (curr["iuv"] == DBNull.Value) {
                show(this, @"Non è presente lo IUV per il credito, non è possibile interrogare la banca.",
                    @"Avviso");
                return;
            }

            DataTable Incassi = Conn.RUN_SELECT("flussoincassidetailview", "*", null, QHS.CmpEq("iuv", curr["iuv"]),
                null, false);
            if (Incassi.Rows.Count > 0) {
                DataRow rIncasso = Incassi.Rows[0];
                show(this,
                    $@"E' già presente un incasso collegato, nel flusso di codice {rIncasso["codiceflusso"]}.",
                    "Avviso");
                //return;
            }

            string error;
            var msg = PagoPaService.AggiornaIuv(Conn, curr["iuv"].ToString());
            if (msg != null) {
                show(this, msg,
                    @"Errore");
                return;
            }

            Incassi = Conn.RUN_SELECT("flussoincassidetailview", "*", null, QHS.CmpEq("iuv", curr["iuv"]), null, false);
            if (Incassi.Rows.Count > 0) {
                DataRow rIncasso = Incassi.Rows[0];
                show(this,
                    $@"E' stato letto un incasso collegato, nel flusso di codice {rIncasso["codiceflusso"]}.",
                    @"Avviso");
                return;
            }

            show(this, $@"Non sono stati registrati incassi su questo IUV, nell'esercizio corrente.",
                @"Avviso");
        }

        private void button5_Click(object sender, EventArgs e) {
            DataRow curr = DS.flussocreditidetail.Rows[0];
            if (curr["iuv"] == DBNull.Value) {
                show(this, @"Non è presente lo IUV per il credito, non è possibile interrogare la banca.",
                    @"Avviso");
                return;
            }

            string error;
            string url = "www.temposrl.it";
            var msg = PagoPaService.AttivaCredito(Conn, curr["iuv"].ToString(),"www.temposrl.it", out url);
            if (msg != null) {
                show(this, msg,
                    @"Errore");
                return;
            }

        }

		private void btnEmailToCc_Click(object sender, EventArgs e) {
             DataTable config = Conn.RUN_SELECT("configsmtp", "*", null, null, null, false);
            if (config.Rows.Count == 0) {
                show("Il form Gestione Notifiche non contiene campi valorizzati");
                return;
			}

            string cc = config.Rows[0]["email_cc"].ToString();
            //if (cc.Trim() == "") {
            //    show("Non è stato configurato un indirizzo email in copia conoscenza");
            //    return;
            //}
            
			List<string> listaErrori = new List<string>();
            //Reperimento degli avvisi di pagamento dal partner tecnologico
            Dictionary<string, AvvisoPagamento> cert = new Dictionary<string, AvvisoPagamento>();
            foreach (var r in DS.flussocreditidetail) {
                if (r.iuv == null) continue;
                if (cert.ContainsKey(r.iuv)) continue;
                string result;
                cert[r.iuv] = PagoPaService.ottieniAvvisoPagamento(Conn, r.iuv,  out result);
                if (result != null) listaErrori.Add(result);
            }

            //Invio delle mail dei certificati
            foreach (var avviso in cert.Keys) {
                var avvPag = cert[avviso];
                if (avvPag == null) continue;
                if (string.IsNullOrEmpty(avvPag.email)) {
                    listaErrori.Add("Il debitore " + avvPag.debitore + " non ha fornito l'email");
                    continue;
                }
                var error = PagoPaService.InviaAvvisoPagamento(avvPag.ente, avvPag.debitore, avvPag.email, avvPag.pdf, cc, Conn);
                if (error != null) listaErrori.Add(error);
            }
            if (listaErrori.Count > 0) {  
                show(listaErrori[0].ToString());
                return;
            }
            else {
                show(this, "Email correttamente inviata", "Avviso");
            }
		}
	}
}
