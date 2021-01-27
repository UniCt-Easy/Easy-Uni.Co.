
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace expensetaxofficial_default {
    public partial class FrmExpenseTaxOfficial_Default : Form {
        MetaData Meta;
        bool inChiusura = false;
        CQueryHelper QHC;
        QueryHelper QHS;

        decimal lastImponibileLordo;
        decimal lastQuotaEsente;
        decimal lastImponibileNetto;
        decimal lastAliquotaDip;
        decimal lastQuotaNumDip;
        decimal lastQuotaDenDip;
        decimal lastDetrazioni;
        decimal lastAliquotaAmm;
        decimal lastQuotaNumAmm;
        decimal lastQuotaDenAmm;

        public FrmExpenseTaxOfficial_Default() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            rendiReadOnly();
        }

        /// <summary>
        /// Metodo che rende read only gli oggetti non modificabili del form
        /// </summary>
        private void rendiReadOnly() {
            DataRow ExpTaxParent = Meta.SourceRow;

            string solaLettura = (ExpTaxParent.Table.ExtendedProperties["readonly"] != null)
                ? ExpTaxParent.Table.ExtendedProperties["readonly"].ToString().ToUpper()
                : "S";

            if (solaLettura == "S") {
                gBoxGenerale.Enabled = false;
                gBoxScaglione.Enabled = false;
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "tax") {
                if (!Meta.DrawStateIsDone) return;
                DataRow Curr = DS.expensetaxofficial.Rows[0];
                if (R == null) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                    Curr["idcity"] = DBNull.Value;
                    Curr["idfiscaltaxregion"] = DBNull.Value;
                }
                else {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", R["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    Curr["idfiscaltaxregion"] = DBNull.Value;
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    Curr["idcity"] = DBNull.Value;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    Curr["idcity"] = DBNull.Value;
                                    Curr["idfiscaltaxregion"] = DBNull.Value;
                                    txtGeoComune0101.Text = "";
                                    txtProvincia.Text = "";
                                    HelpForm.SetComboBoxValue(cmbRegioneFiscale, -1);
                                    break;
                                }
                        }
                    }
                }
            }
        }

        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow && Meta.EditMode) {
                calcolaVarConfronto();
            }

            if ((Meta.FirstFillForThisRow) && (DS.expensetaxofficial.Rows.Count > 0)) {
                DataRow Curr = DS.expensetaxofficial.Rows[0];
                if (CfgFn.GetNoNullInt32(Curr["taxcode"]) == 0) {
                    grpCity.Visible = false;
                    grpRegion.Visible = false;
                }
                else {
                    DataRow[] Tax = DS.tax.Select(QHC.CmpEq("taxcode", Curr["taxcode"]));
                    if (Tax.Length > 0) {
                        DataRow rTax = Tax[0];
                        string geo = rTax["geoappliance"].ToString().ToUpper();
                        switch (geo) {
                            case "C": {
                                    grpCity.Visible = true;
                                    grpRegion.Visible = false;
                                    break;
                                }
                            case "R": {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = true;
                                    break;
                                }
                            default: {
                                    grpCity.Visible = false;
                                    grpRegion.Visible = false;
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void calcolaVarConfronto() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.expensetaxofficial.Rows[0];
            lastImponibileLordo = CfgFn.GetNoNullDecimal(Curr["taxablegross"]);
            lastQuotaEsente = CfgFn.GetNoNullDecimal(Curr["exemptionquota"]);
            lastImponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);

            lastAliquotaDip = CfgFn.GetNoNullDecimal(Curr["employrate"]);
            lastQuotaNumDip = CfgFn.GetNoNullDecimal(Curr["employnumerator"]);
            lastQuotaDenDip = CfgFn.GetNoNullDecimal(Curr["employdenominator"]);
            lastDetrazioni = CfgFn.GetNoNullDecimal(Curr["abatements"]);

            lastAliquotaAmm = CfgFn.GetNoNullDecimal(Curr["adminrate"]);
            lastQuotaNumAmm = CfgFn.GetNoNullDecimal(Curr["adminnumerator"]);
            lastQuotaDenAmm = CfgFn.GetNoNullDecimal(Curr["admindenominator"]);
        }

        private decimal calcRitenutaAmm() {
            DataRow Curr = DS.expensetaxofficial.Rows[0];
            decimal imponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);
            decimal aliquota = CfgFn.GetNoNullDecimal(Curr["adminrate"]);
            double quotaNum = CfgFn.GetNoNullDouble(Curr["adminnumerator"]);
            double quotaDen = CfgFn.GetNoNullDouble(Curr["admindenominator"]);

            decimal imponibile = CfgFn.DecMulDiv(imponibileNetto, quotaNum, quotaDen);
            decimal importoRitenuta = imponibile * aliquota;
            return CfgFn.RoundValuta(importoRitenuta);
        }

        private decimal calcRitenutaDip() {
            DataRow Curr = DS.expensetaxofficial.Rows[0];
            decimal imponibileNetto = CfgFn.GetNoNullDecimal(Curr["taxablenet"]);
            decimal aliquota = CfgFn.GetNoNullDecimal(Curr["employrate"]);
            double quotaNum = CfgFn.GetNoNullDouble(Curr["employnumerator"]);
            double quotaDen = CfgFn.GetNoNullDouble(Curr["employdenominator"]);
            decimal detrazioni = CfgFn.GetNoNullDecimal(Curr["abatements"]);

            decimal imponibile = CfgFn.DecMulDiv(imponibileNetto, quotaNum, quotaDen);
            decimal importoRitenuta = imponibile * aliquota;
            importoRitenuta -= detrazioni;
            return CfgFn.RoundValuta(importoRitenuta);
        }

        private void txtImponibileLordo_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.InsertMode) return;
            object o = HelpForm.GetObjectFromString(typeof(decimal), txtImponibileLordo.Text, txtImponibileLordo.Tag.ToString());
            decimal imponibileLordo = CfgFn.GetNoNullDecimal(o);
            if (lastImponibileLordo != imponibileLordo) {
                decimal imponibileNetto = calcolaImponibileNetto(imponibileLordo, lastQuotaEsente);
                txtImponibileNetto.Text = HelpForm.StringValue(imponibileNetto, "x.y.c");
                //imponibileNetto.ToString("c");
                Meta.GetFormData(true);
                calcolaRitenutaAggiornaTextBox("D");
                calcolaRitenutaAggiornaTextBox("A");
                lastImponibileLordo = imponibileLordo;
            }
        }

        private void txtQuotaEsente_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.InsertMode) return;
            object o = HelpForm.GetObjectFromString(typeof(decimal), txtQuotaEsente.Text, txtQuotaEsente.Tag.ToString());
            decimal quotaEsente = CfgFn.GetNoNullDecimal(o);
            if (lastQuotaEsente != quotaEsente) {
                decimal imponibileNetto = calcolaImponibileNetto(lastImponibileLordo, quotaEsente);
                txtImponibileNetto.Text = imponibileNetto.ToString("c");
                Meta.GetFormData(true);
                calcolaRitenutaAggiornaTextBox("D");
                calcolaRitenutaAggiornaTextBox("A");
                lastQuotaEsente = quotaEsente;
            }
        }

        private decimal calcolaImponibileNetto(decimal imponibileLordo, decimal quotaEsente) {
            decimal imponibileNetto = (imponibileLordo > quotaEsente) ? imponibileLordo - quotaEsente : 0;
            return imponibileNetto;
        }

        /// <summary>
        /// Metodo che richiama il calcola della ritenuta dipendente e amministrazione ed aggiorna
        /// il text box corrispondente dell'importo della ritenuta
        /// </summary>
        /// <param name="tipo">D: Dipendente - A: Amministrazione</param>
        private void calcolaRitenutaAggiornaTextBox(string tipo) {
            DataRow Curr = DS.expensetaxofficial.Rows[0];
            if (tipo == "D") {
                if (Curr["employrate"] != DBNull.Value && Curr["taxablenet"] != DBNull.Value) {
                    decimal ritDip = calcRitenutaDip();
                    txtImportoDip.Text = ritDip.ToString("c");
                }
            }
            if (tipo == "A") {
                if (Curr["adminrate"] != DBNull.Value && Curr["taxablenet"] != DBNull.Value) {
                    decimal ritAmm = calcRitenutaAmm();
                    txtImportoAmm.Text = ritAmm.ToString("c");
                }
            }
        }

        private decimal decimalDaTextBox(TextBox text) {
            object o = HelpForm.GetObjectFromString(typeof(decimal), text.Text, text.Tag.ToString());
            return ((o == null) || (o == DBNull.Value)) ? 0 : (decimal)o;
        }

        private void txtDetrazioni_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            decimal detrazioni = decimalDaTextBox(txtDetrazioni);
            if (detrazioni == lastDetrazioni) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("D");
        }

        private void txtAliquotaDip_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            decimal aliquotaDip = decimalDaTextBox(txtAliquotaDip);
            if (aliquotaDip == lastAliquotaDip) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("D");
        }

        private void txtQuotaDip1_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            decimal quotaNumDip = decimalDaTextBox(txtQuotaDip1);
            if (quotaNumDip == lastQuotaNumDip) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("D");
        }

        private void txtQuotaDip2_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            decimal quotaDenDip = decimalDaTextBox(txtQuotaDip2);
            if (quotaDenDip == lastQuotaDenDip) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("D");
        }

        private void txtAliquotaAmm_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            decimal aliquotaAmm = decimalDaTextBox(txtAliquotaAmm);
            if (aliquotaAmm == lastAliquotaAmm) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("A");
        }

        private void txtQuotaAmm1_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            decimal quotaNumAmm = decimalDaTextBox(txtQuotaAmm1);
            if (quotaNumAmm == lastQuotaNumAmm) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("A");
        }

        private void txtQuotaAmm2_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            decimal quotaDenAmm = decimalDaTextBox(txtQuotaAmm2);
            if (quotaDenAmm == lastQuotaDenAmm) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("A");
        }

        private void txtImponibileNetto_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            decimal imponibileNetto = decimalDaTextBox(txtImponibileNetto);
            if (imponibileNetto == lastImponibileNetto) return;
            Meta.GetFormData(true);
            calcolaRitenutaAggiornaTextBox("D");
            calcolaRitenutaAggiornaTextBox("A");
        }

    }
}
