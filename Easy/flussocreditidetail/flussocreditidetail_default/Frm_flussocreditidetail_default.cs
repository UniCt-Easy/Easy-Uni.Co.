
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
using funzioni_configurazione;
using ep_functions;
using System.IO;
using pagoPaService;

namespace flussocreditidetail_default {
    public partial class Frm_flussocreditidetail_default : MetaDataForm {
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
            DataAccess.SetTableForReading(DS.finmotive_iva_income, "finmotive");
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

        public void MetaData_AfterClear() {
            enableControls(true);
        }

        private void enableControls(bool abilita) {
            bool ReadOnly = !abilita;
            txtCodiceTassonomia.ReadOnly = !abilita;
            cmbIva.Enabled = abilita;
            gboxCausale.Enabled = abilita;
            gboxCausaleIVA.Enabled = abilita;
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
            btnRicevuta.Enabled = !abilita;
        }

        private void btnRicevuta_Click(object sender, EventArgs e) {
            if (DS.flussocreditidetail.Rows.Count == 0) return;
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
            DataRow curr;

            if (DS.flussocreditidetail.Rows.Count != 0) {
                curr = DS.flussocreditidetail.Rows[0];
                if (curr["iuv"] == DBNull.Value) {
                    show(this, @"Non è presente lo IUV per il credito, non è possibile interrogare la banca.",
                        @"Avviso");
                    return;
                }
            }
            else {
                show(this, @"Selezionare un flusso per controllare la presenza di incassi.",
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

            var msg = PagoPaService.AggiornaIuv(Conn, curr["iuv"].ToString());
           
            //Controlla prima se ha effettivamente scaricato qualcosa, in questo caso non visualizza mai alcun errore
            Incassi = Conn.RUN_SELECT("flussoincassidetailview", "*", null, QHS.CmpEq("iuv", curr["iuv"]), null, false);
            if (Incassi.Rows.Count > 0) {
                DataRow rIncasso = Incassi.Rows[0];
                show(this,
                    $@"E' stato letto un incasso collegato, nel flusso di codice {rIncasso["codiceflusso"]}.",
                    @"Avviso");
                return;
            }
            
            if (msg != null) {
	            show(this, msg,
		            @"Errore");
	            return;
            }

            show(this, $@"Non sono stati registrati incassi su questo IUV, nell'esercizio corrente.",
                @"Avviso");
        }
        
        private IMetaDataDispatcher _dispatcher;
        private ISecurity _security;
        private void btnAnnullaCrediti_Click(object sender, EventArgs e)
        {
            if (DS.flussocreditidetail.Rows.Count == 0) return;
			Meta.GetFormData(true);
            _dispatcher = this.getInstance<IMetaDataDispatcher>();
            _security = this.getInstance<ISecurity>();
            DataRow curr = DS.flussocreditidetail.Rows[0];
			var f = new FrmAnnullaDettaglio(curr["iduniqueformcode"],DS,Meta,_dispatcher,_security);
			if (f.ShowDialog(this) != DialogResult.OK) return;
            else Meta.FreshForm();
 

		
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
                if (r.iuv == null) {
                    listaErrori.Add("È necessario avere lo IUV per inviare l'email");
                    continue;
                }
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
