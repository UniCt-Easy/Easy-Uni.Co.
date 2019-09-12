/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

namespace accountenactment_default {
    public partial class Frm_accountenactment_default :Form {
        QueryHelper QHS;
        CQueryHelper QHC = new CQueryHelper();
        MetaData Meta;
        public Frm_accountenactment_default() {
            InitializeComponent();
            QueryCreator.SetTableForPosting(DS.accountvarview, "accountvar");
        }

        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            GetData.SetStaticFilter(DS.accountenactment, QHS.CmpEq("yenactment", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.accountvarview, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabPageAttributi);
                }
            }

        }

        public void MetaData_AfterActivation() {
            btnCollega.BackColor = formcolors.GridButtonBackColor();
            btnCollega.ForeColor = formcolors.GridButtonForeColor();
            btnScollega.BackColor = formcolors.GridButtonBackColor();
            btnScollega.ForeColor = formcolors.GridButtonForeColor();
            btnModifica.BackColor = formcolors.GridButtonBackColor();
            btnModifica.ForeColor = formcolors.GridButtonForeColor();
        }


        public void MetaData_AfterClear() {
            gboxStato.Enabled = true;
            btnAnnulla.Visible = false;
            btnApprova.Visible = false;
            btnWait.Visible = false;

            txtEsercizioDocumento.Text = Meta.GetSys("esercizio").ToString();
            btnCollega.Enabled = false;
            btnScollega.Enabled = false;
            btnModifica.Enabled = false;

            //gestisciBottoniEsito(false);
            txtNumeroDocumento.ReadOnly = false;
        }


        public void MetaData_AfterFill() {
            bool ModoInsert = MetaData.GetMetaData(this).InsertMode;
            bool ModoEdit = MetaData.GetMetaData(this).EditMode;
            DataRow Curr = DS.accountenactment.Rows[0];
            string filtraAtto = QHS.CmpKey(Curr);
            AbilitaVariazioni(true);

            btnApprova.Enabled = true;
            btnAnnulla.Enabled = true;

            if (ModoEdit) {
                txtNumeroDocumento.ReadOnly = true;
            }
            gboxStato.Enabled = false;

            btnWait.Visible = !rdbInAttesa.Checked;
            btnApprova.Visible = rdbInAttesa.Checked;
            btnAnnulla.Visible = rdbInAttesa.Checked;

            //if (ModoInsert || ModoEdit) {
            if (rdbInAttesa.Checked) {
                AbilitaVariazioni(true);
            }
            else {
                AbilitaVariazioni(false);
            }
            //}
        }

        string CalculateFilterForLinking(bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";
            int currentyear = (int)Meta.GetSys("esercizio");
            //Aggiunge solo le var. di tipo "inserito"
            MyFilter = qh.IsNull("idenactment");
            // in inserimento solo variazioni ufficiali
            if (SQL) {
                MyFilter = qh.AppAnd(MyFilter,
                    qh.CmpGe("idaccountvarstatus", 4), qh.CmpEq("yvar", currentyear));
            }

            return MyFilter;
        }

        private void btnWait_Click(object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            bool do_update = MessageBox.Show("Attenzione, l'atto sarà rimesso nello stato di 'In attesa di approvazione' " +
                                "e tutte le variazioni contenute che attualmente " +
                                "sono nello stato di 'approvata' retrocederanno nuovamente allo stato " +
                                " 'Inserita' ", "Conferma", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK;
            if (!do_update) return;
            foreach (DataRow RR in DS.accountvarview.Select()) {
                if (RR["idaccountvarstatus"].ToString() == "5")
                    RR["idaccountvarstatus"] = 4;
            }
            DataRow Curr = DS.accountenactment.Rows[0];
            Curr["idenactmentstatus"] = 1;
            Meta.SaveFormData();
            Meta.FreshForm();
            if (!DS.HasChanges()) SendMails();
        }


        void AbilitaVariazioni(bool enable) {
            btnCollega.Enabled = enable;
            btnScollega.Enabled = enable;
            btnModifica.Enabled = enable;
        }

        void SendMails() {

            DataRow Curr = DS.accountenactment.Rows[0];
            foreach (DataRow V in DS.accountvarview.Rows) {
                SendMailVar(V);
            }


        }

        void SendMailVar(DataRow Var) {
            if (Var["idman"] == DBNull.Value) return;
            int idman = CfgFn.GetNoNullInt32(Var["idman"]);
            string filter = QHS.CmpEq("idman", idman);

            DataTable T = Meta.Conn.RUN_SELECT("manager", "*", null, filter, null, false);
            if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;

            string mailto = T.Rows[0]["email"].ToString();
            if (mailto == "") return;

            int CurrentStatus = CfgFn.GetNoNullInt32(Var["idaccountvarstatus"]);
            string currstatustext = "";
            switch (CurrentStatus) {
            case 3:
                currstatustext = "Da Correggere";
                break;
            case 4:
                currstatustext = "Inserita";
                break;
            case 5:
                currstatustext = "Approvato";
                break;
            case 6:
                currstatustext = "Annullato";
                break;
            }



            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.Conn = Meta.Conn;

            SM.To = mailto;
            string MsgBody = "";
            MsgBody = "La variazione di budget numero " + Var["nvar"] + " relativa all'esercizio " + Var["yvar"] + "\r\n";
            MsgBody += "E' passata nello stato '" + currstatustext + "'.\r\n";

            MsgBody += " Dettagli:\r\n";

            DataTable Accountvar = Meta.Conn.RUN_SELECT("accountvar", "*", null, QHS.CmpKey(Var), null, false);
            DataRow V = Accountvar.Rows[0];

            if (Var["description"].ToString() != "") MsgBody += Var["description"].ToString() + "\r\n";
            if (V["annotation"].ToString() != "") MsgBody += V["annotation"].ToString() + "\r\n";
            MsgBody += "\r\n\r\n";
            DataTable Accountvardetailview = Meta.Conn.RUN_SELECT("accountvardetailview", "*", null, QHS.CmpKey(Var), null, false);
            foreach (DataRow RD in Accountvardetailview.Rows) {
                MsgBody += GetTextForaccountvarDetail(RD);
                if (RD["description"].ToString() != "") MsgBody += RD["description"].ToString() + "\r\n";
                if (RD["annotation"].ToString() != "") MsgBody += RD["annotation"].ToString() + "\r\n";
            }
            MsgBody += "\r\n";


            SM.Subject = "Notifica cambiamento di stato variazione di budget";
            SM.MessageBody = MsgBody;
            SM.Conn = Meta.Conn;

            if (!SM.Send()) {
                if (SM.ErrorMessage != "") MessageBox.Show(SM.ErrorMessage, "Errore");
            }

        }

        string GetTextForaccountvarDetail(DataRow R) {
            string S = "";
            S += "Conto " + R["codeacc"].ToString() + " - " + R["account"].ToString() + "\r\n";
            S += "UPB " + R["codeupb"].ToString() + " - " + R["upb"].ToString() + "\r\n";
            S += "Importo variazione:" + CfgFn.GetNoNullDecimal(R["amount"]).ToString("c") + "\r\n"; ;
            return S;
        }

        private void btnApprova_Click(object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            DataRow Curr = DS.accountenactment.Rows[0];
            if (Curr["adate"] == DBNull.Value) {
                MessageBox.Show("E' necessario, prima di approvare l'atto, inserirne la data di approvazione");
                HelpForm.FocusControl(txtDataContabile);
                return;
            }
            bool do_update = MessageBox.Show("Attenzione, approvando l'atto " +
                    "e tutte le variazioni di budget in esso contenute che attualmente " +
                    "sono nello stato di 'Inserita' passeranno allo stato di " +
                    " 'Approvata' ", "Conferma", MessageBoxButtons.OKCancel) ==
                        DialogResult.OK;
            if (!do_update) return;

            bool do_update_enactment = false;
            bool do_update_all_accountvar_adate = false;
            bool do_update_approved_accountvar_adate = false;

            AskConfirm Ask = new AskConfirm(0);
            DialogResult AskRes = Ask.ShowDialog(this);
            if (AskRes != DialogResult.OK) return;

            do_update_enactment = Ask.chk_do_update_enactment.Checked;
            do_update_all_accountvar_adate = Ask.rdb_do_update_all_accountvar_adate.Checked;
            do_update_approved_accountvar_adate = Ask.rdb_do_update_approved_accountvar_adate.Checked;


            foreach (DataRow RR in DS.accountvarview.Select()) {
                if (do_update_enactment) {
                    RR["enactment"] = Curr["description"];
                    RR["enactmentdate"] = Curr["adate"];
                    RR["nenactment"] = Curr["nenactment"];
                }
                if (do_update_all_accountvar_adate) {
                    RR["adate"] = Curr["adate"];
                }
                if (RR["idaccountvarstatus"].ToString() == "4") {
                    RR["idaccountvarstatus"] = 5;
                    if (do_update_approved_accountvar_adate)
                        RR["adate"] = Curr["adate"];
                }
            }

            Curr["idenactmentstatus"] = 2;
            Meta.SaveFormData();
            Meta.FreshForm();
            if (!DS.HasChanges()) SendMails();
        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            if (!Meta.GetFormData(false)) return;
            bool do_update = MessageBox.Show("Attenzione l'atto sarà annullato " +
                                "e tutte le variazioni di budget in esso contenute attualmente nello stato di 'Inserita'" +
                                "passeranno allo stato " +
                                " 'Annullata' ", "Conferma", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK;
            if (!do_update) return;
            foreach (DataRow RR in DS.accountvarview.Select()) {
                if (RR["idaccountvarstatus"].ToString() == "4")
                    RR["idaccountvarstatus"] = 6;
            }
            DataRow Curr = DS.accountenactment.Rows[0];
            Curr["idenactmentstatus"] = 3;
            Meta.SaveFormData();
            Meta.FreshForm();
            if (!DS.HasChanges()) SendMails();
        }

        private void btnCollega_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            string MyFilter = CalculateFilterForLinking(true);
            string command = "choose.accountvarview.documentocollegato." + MyFilter;
            MetaData.Choose(this, command);
        }

        private void btnScollega_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            MetaData.Unlink_Grid(dgrVariazioni);
            Meta.FreshForm();
        }

        private void btnModifica_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = CalculateFilterForLinking(false);
            string MyFilterSQL = CalculateFilterForLinking(true);
            Meta.MultipleLinkUnlinkRows("Composizione documento",
                "Movimenti inclusi nel documento selezionato",
                "Movimenti non inclusi in alcun documento",
                DS.accountvarview, MyFilter, MyFilterSQL, "documentocollegato");
        }
    }
}
