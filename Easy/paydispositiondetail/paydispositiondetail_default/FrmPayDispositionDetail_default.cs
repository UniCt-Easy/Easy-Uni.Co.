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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace paydispositiondetail_default {
    public partial class FrmPayDispositionDetail_default : Form {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        bool inChiusura = false;
        string lastCIN = "";
        object lastABI = DBNull.Value;
        object lastCAB = DBNull.Value;
        string lastCC = "";
        public FrmPayDispositionDetail_default() {
            InitializeComponent();
        }


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            chkItaliano.Checked = true;
            grpEstero.Visible = false;
            grpItaliano.Visible = true;
            lblComuneStato.Text = "Comune di Nascita";
            // Questa gestione va spostata nel metadato
            //HelpForm.SetDenyNull(DS.paydispositiondetail.Columns["gender"], true);
            HelpForm.SetDenyNull(DS.paydispositiondetail.Columns["flaghuman"], true);
            GetData.SetStaticFilter(DS.paydisposition, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			DataAccess.SetTableForReading(DS.payment1, "payment");
			Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
        }

	public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
			switch (T.TableName) {
				case "chargehandling": {
						if (R != null) {
							int flag_exemption = (CfgFn.GetNoNullInt32(R["flag"]) & 1);
							chk_bank_charges_exempt.Checked = !((flag_exemption & 1) == 0);
						}

						break;
					}
			}
		}
	

		void CalcolaValoriDefaultModPagamento(object codicecred, DataRow Curr) {
            DataRow DefPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecred);
            if (DefPagam == null) return;
            if (DefPagam["iban"] == DBNull.Value) return;
            Curr["iban"] = DefPagam["iban"];
            Curr["abi"] = DefPagam["idbank"];
            Curr["cab"] = DefPagam["idcab"];
            Curr["cc"] = DefPagam["cc"];
            Curr["cin"] = DefPagam["cin"];
        }

        private bool valutaSeItaliano(object idCity, object idNation) {
            if ((idCity != null) && (idCity != DBNull.Value)) {
                return true;
            }
            if ((idNation != null) && (idNation != DBNull.Value)) {
                return false;
            }

            return true;
        }

        private object ottieniIdIndirizzoPredefinito() {
            string filter = QHS.CmpEq("codeaddress", "07_SW_DEF");
            object id = Meta.Conn.DO_READ_VALUE("address", filter, "idaddress");
            return id;
        }

        private object calcolaLocation(DataRow r, out string province) {
            province = "";
            string f = QHS.AppAnd(QHS.CmpEq("tablename", "paydispositiondetail"), QHS.CmpEq("field", "location"));
            int len = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("columntypes", f, "col_len"));
            int maxCity = len - 5;
            if (len == 0) {
                MessageBox.Show(this, "Errore interno!\nContattare il servizio assistenza");
                return null;
            }

            if (r["idcity"] != DBNull.Value) {
                string fCity = QHS.CmpEq("idcity", r["idcity"]);
                DataTable tGeoCity = DataAccess.CreateTableByName(Meta.Conn, "geo_cityview", "title, provincecode");
                Meta.Conn.RUN_SELECT_INTO_TABLE(tGeoCity, null, fCity, null, true);

                if ((tGeoCity != null) && (tGeoCity.Rows.Count != 0)) {
                    DataRow rCity = tGeoCity.Rows[0];
                    string title = rCity["title"].ToString();
                    province = rCity["provincecode"].ToString();
                    if (title.Length > maxCity) {
                        title = title.Substring(0, maxCity - 1);
                    }
                    return title;
                }
            }
            else {
                string localita = r["location"].ToString();
                if (localita != "") return localita;
            }

            return null;
        }

        private string calcolaAddress(object address) {
            if (address == null) return null;
            string f = QHS.AppAnd(QHS.CmpEq("tablename", "paydispositiondetail"), QHS.CmpEq("field", "address"));
            int len = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("columntypes", f, "col_len"));
            string outstr = (address.ToString().Length <= len)
                ? address.ToString() : address.ToString().Substring(0, len - 1);
            return outstr;
        }

        private void riempiRegistryAddress(DataTable t, object idreg, object idpred) {
            string filterReg = QHS.CmpEq("idreg", idreg);
            string filterRA = QHS.AppAnd(filterReg,
                QHS.CmpEq("idaddresskind", idpred), QHS.CmpEq("active", 'S'));
            Meta.Conn.RUN_SELECT_INTO_TABLE(t, "start desc", filterRA, "1", true);
            if (t.Rows.Count != 0) return;
            string filterRALargo = QHS.AppAnd(filterReg, QHS.CmpEq("active", 'S'));
            Meta.Conn.RUN_SELECT_INTO_TABLE(t, "start desc", filterRALargo, "1", true);
        }

        private void chkItaliano_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            ConfiguraCampiNascita(true);
        }

        private void ConfiguraCampiNascita(bool Aggiorna) {
            if (chkItaliano.Checked) {
                grpItaliano.Visible = true;
                grpEstero.Visible = false;
                lblComuneStato.Text = "Comune di Nascita";
                if (!Meta.IsEmpty) {
                    DS.paydispositiondetail.Rows[0]["idnation"] = DBNull.Value;
                    DS.geo_nation.Rows.Clear();
                    if (Aggiorna) {
                        Meta.myHelpForm.FillControls(grpEstero.Controls);
                    }
                }
            }
            else {
                grpEstero.Visible = true;
                grpItaliano.Visible = false;
                lblComuneStato.Text = "Stato di Nascita";
                if (!Meta.IsEmpty) {
                    DS.paydispositiondetail.Rows[0]["idcity"] = DBNull.Value;
                    DS.geo_cityview.Rows.Clear();
                    if (Aggiorna) {
                        Meta.myHelpForm.FillControls(grpItaliano.Controls);
                    }
                }
            }

        }

        public void MetaData_AfterFill() {
            if (Meta.InsertMode || Meta.EditMode) {
                if (DS.paydispositiondetail.Rows.Count == 0) return;
                DataRow Curr = DS.paydispositiondetail.Rows[0];
                if (Curr["flaghuman"] == DBNull.Value) return;
                if (Curr["flaghuman"].ToString().ToUpper() == "S") {
                    abilita_personafisica(true);
                }
                else {
                    abilita_personafisica(false);
                }
            }
            if ((Meta.FirstFillForThisRow) && (Meta.EditMode)) {
                assegnaVarDiConfronto();
            }

            if (Meta.FirstFillForThisRow) {
                if (DS.paydispositiondetail.Rows.Count == 0) return;
                DataRow Curr = DS.paydispositiondetail.Rows[0];
                int paymethodcode = CfgFn.GetNoNullInt32(Curr["paymethodcode"]);
                if (paymethodcode == 1) {
                    grpCoordinateBancarie.Enabled = true;
                }
                else {
                    PulisciCoordinateBancarie();
                    grpCoordinateBancarie.Enabled = false;
                }
                ValorizzaAnnoAccademico(Curr);
            }
        }

        public void ValorizzaAnnoAccademico(DataRow R) {
            // R paydispositiondetail
            if ((R["academicyear"] != null) && (R["academicyear"] != DBNull.Value)) {
                int AAAA2 = CfgFn.GetNoNullInt32(R["academicyear"]) + 1;
                txtAnnoAccademico2.Text = AAAA2.ToString();
            }
            else{
                txtAnnoAccademico2.Text = "";
            }
                
        }
        private void PulisciCoordinateBancarie() {
            txtABI.Text = "";
            txtCAB.Text = "";
            txtCC.Text = "";
            txtcin.Text = "";
            txtIBAN.Text = "";
        }
        private void PulisciCampi() {
            txtCF.Text = "";
            txtLocalita.Text = "";
            txtCAP.Text = "";
            txtProvince.Text = "";
            txtIndirizzo.Text = "";
            txtmail.Text = "";
            PulisciCoordinateBancarie();
            if ((!MetaData.Empty(this))) {
                DS.paydispositiondetail.Rows[0]["cf"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["address"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["cap"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["location"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["province"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["email"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["abi"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["cab"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["cc"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["cin"] = DBNull.Value;
                DS.paydispositiondetail.Rows[0]["iban"] = DBNull.Value;
            }

        }
        private void abilita_personafisica(bool personafisica) {
            if (!personafisica) {
                //E' un'azienda
                txtCognome.Text = "";
                txtNome.Text = "";
                txtDataNascita.Text = "";
                txtGeoNazione.Text = "";
                txtProvincia.Text = "";
                txtLocalitaGeo.Text = "";
                DS.geo_nation.Rows.Clear();
                DS.geo_cityview.Rows.Clear();

                if ((!MetaData.Empty(this))) {
                    DS.paydispositiondetail.Rows[0]["surname"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["forename"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["birthdate"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["idcity"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["idnation"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["gender"] = DBNull.Value;
                }
                grpBoxPersonaFisica.Visible = false;
                grpBoxAzienda.Visible = true;
            }
            else {
                //E' una persona fisica
                txtTitle.Text = "";
                txtP_iva.Text = "";

                if ((!MetaData.Empty(this))) {
                    DS.paydispositiondetail.Rows[0]["title"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["p_iva"] = DBNull.Value;

                }
                grpBoxPersonaFisica.Visible = true;
                grpBoxAzienda.Visible = false;

            }
        }
        private bool controllaBanca(string insertedBBAN) {
            string ABI = insertedBBAN.Substring(1, 5);
            string filtroBanca = QHS.CmpEq("idbank", ABI);
            object codiceABI = Meta.Conn.DO_READ_VALUE("bank", filtroBanca, "idbank");
            if (codiceABI == null) {
                MessageBox.Show("La banca inserita nel BBAN non esiste!");
                return false;
            }
            string CAB = insertedBBAN.Substring(6, 5);
            filtroBanca = QHS.AppAnd(filtroBanca, QHS.CmpEq("idcab", CAB));
            object codiceCAB = Meta.Conn.DO_READ_VALUE("cab", filtroBanca, "idcab");
            if (codiceCAB == null) {
                MessageBox.Show("Lo sportello inserito nel BBAN non esiste!");
                return false;
            }
            return true;
        }

        private void btnIBANcbi_Click(object sender, EventArgs e) {
            FrmAskIban frm = new FrmAskIban(txtIBAN.Text);
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            if (frm.insertedIBAN == "") {
                txtIBAN.Text = frm.insertedIBAN;
                return;
            }
            if (!frm.insertedIBAN.StartsWith("IT")) {
                if ((Meta.InsertMode) || (Meta.EditMode)) {
                    DS.paydispositiondetail.Rows[0]["iban"] = frm.insertedIBAN;
                    DS.paydispositiondetail.Rows[0]["cin"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["abi"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["cab"] = DBNull.Value;
                    DS.paydispositiondetail.Rows[0]["cc"] = DBNull.Value;
                    Meta.FreshForm();
                }
                return;
            }

            bool inserisciDati = controllaBanca(frm.insertedIBAN.Substring(4));
            if (!inserisciDati) return;

            string bban = frm.insertedIBAN.Substring(4);
            string CIN = bban.Substring(0, 1).ToUpper();
            string ABI = bban.Substring(1, 5);
            string CAB = bban.Substring(6, 5);
            string CC = bban.Substring(11, 12);
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                DS.paydispositiondetail.Rows[0]["cin"] = CIN;
                DS.paydispositiondetail.Rows[0]["abi"] = ABI;
                DS.paydispositiondetail.Rows[0]["cab"] = CAB;
                DS.paydispositiondetail.Rows[0]["cc"] = CC;
                DS.paydispositiondetail.Rows[0]["iban"] = frm.insertedIBAN;
                Meta.FreshForm();
            }
            else {
                txtABI.Text = ABI;
                txtCAB.Text = CAB;
                txtcin.Text = CIN;
                txtCC.Text = CC;
            }

            txtIBAN.Text = frm.insertedIBAN;

        }

        private void PayDispositionDetail_Single_Load(object sender, EventArgs e) {

        }

        private void chkFlaghuman_CheckedChanged(object sender, EventArgs e) {
            if ((Meta != null) && Meta.DrawStateIsDone) {
                PulisciCampi();
                if (chkFlaghuman.Checked) {
                    abilita_personafisica(true);
                }
                else {
                    abilita_personafisica(false);
                }
            }
        }

        private void txtcin_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            if (txtcin.Text == "") {
                //txtBBAN.Text = "";
                lastCIN = "";
                return;
            }
            if (lastCIN == txtcin.Text.ToUpper()) return;
            lastCIN = txtcin.Text.ToUpper();
            calcolaBBAN();

        }

        private void txtCC_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            if (txtCC.Text == "") {
                //txtBBAN.Text = "";
                lastCC = "";
                return;
            }
            if (lastCC == txtCC.Text) return;
            lastCC = txtCC.Text;
            calcolaBBAN();
        }
        public void assegnaVarDiConfronto() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.paydispositiondetail.Rows[0];

            lastCIN = (Curr["cin"] == DBNull.Value) ? "" : Curr["cin"].ToString().ToUpper();
            lastABI = Curr["abi"];
            lastCAB = Curr["cab"];
            lastCC = (Curr["cc"] == DBNull.Value) ? "" : Curr["cc"].ToString();
        }
        private void calcolaBBAN() {
            if (DS.paydispositiondetail.Rows.Count == 0) return;
            if (Meta.DrawStateIsDone) Meta.GetFormData(true);
            DataRow Curr = DS.paydispositiondetail.Rows[0];
            bool puoiCalcolare =
                ((Curr["cin"] != DBNull.Value) &&
                (Curr["abi"] != DBNull.Value) &&
                (Curr["cab"] != DBNull.Value) &&
                (Curr["cc"] != DBNull.Value) &&
                (Curr["cin"].ToString() != "") &&
                (Curr["abi"].ToString() != "") &&
                (Curr["cab"].ToString() != "") &&
                (Curr["cc"].ToString() != ""));
            if (!puoiCalcolare) {
                //txtBBAN.Text = "";
                return;
            }
            Curr["cin"] = Curr["cin"].ToString().ToUpper();
            bool cinCorretto = CfgFn.CheckCIN(Curr["cin"].ToString(), Curr["cab"].ToString(), Curr["abi"].ToString(), Curr["cc"].ToString());
            if (cinCorretto) {
                string BBAN = Curr["cin"].ToString() + Curr["abi"].ToString() + Curr["cab"].ToString() + Curr["cc"].ToString();
                txtIBAN.Text = CfgFn.calcolaIBAN("IT", BBAN);
                Curr["iban"] = txtIBAN.Text;
            }
            else {
                txtIBAN.Text = null;
            }
        }

        private void rdbBonifico_CheckedChanged(object sender, EventArgs e) {
            if (rdbBonifico.Checked) {
                grpCoordinateBancarie.Enabled = true;
            }
            else {
                PulisciCoordinateBancarie();
                grpCoordinateBancarie.Enabled = false;
            }
        }

        private void rdbCassa_CheckedChanged(object sender, EventArgs e) {
            if (rdbCassa.Checked) {
                PulisciCoordinateBancarie();
                grpCoordinateBancarie.Enabled = false;
            }

        }

        private void rdbAssegno_CheckedChanged(object sender, EventArgs e) {
            if (rdbAssegno.Checked) {
                PulisciCoordinateBancarie();
                grpCoordinateBancarie.Enabled = false;
            }
        }

        private void rdbAssegnoCircolare_CheckedChanged(object sender, EventArgs e) {
            if (rdbAssegnoCircolare.Checked) {
                PulisciCoordinateBancarie();
                grpCoordinateBancarie.Enabled = false;
            }
        }


        private void rdbAssegnoQuietanza_CheckedChanged(object sender, EventArgs e) {
            if (rdbAssegnoQuietanza.Checked) {
                PulisciCoordinateBancarie();
                grpCoordinateBancarie.Enabled = false;
            }
        }

        public void MetaData_AfterClear() {
            txtAnnoAccademico2.Text = "";
        }
        private void txtAnnoAccademico1_Leave(object sender, EventArgs e) {
            if (txtAnnoAccademico1.Text == "") {
                txtAnnoAccademico2.Text = "";
                return;
            }
            int AAAA1 = CfgFn.GetNoNullInt32(txtAnnoAccademico1.Text);
            int AAAA2 = AAAA1 + 1;
            txtAnnoAccademico2.Text = AAAA2.ToString();
        }

		private void btnScollega_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.paydispositiondetail.Rows[0];
			if (Curr["idexp"] == DBNull.Value) return;

			Curr["idexp"] = DBNull.Value;
			DS.expense.Clear();
			DS.payment1.Clear();
			txtEsercizio.Text = "";
			txtNum.Text = "";
			txtNMandato.Text = "";
			Meta.FreshForm();
		}
	}
}
