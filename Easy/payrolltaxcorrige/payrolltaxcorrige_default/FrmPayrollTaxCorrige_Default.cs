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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace payrolltaxcorrige_default {
    public partial class FrmPayrollTaxCorrige_Default : Form {
        public FrmPayrollTaxCorrige_Default() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            if (Meta.edit_type == "readonly") {
                Meta.CanSave = false;
                rendiDiSolaLettura(this);
            }
        }

        private void rendiDiSolaLettura(Control control) {
            foreach (Control c in control.Controls) {
                if (c.HasChildren) {
                    rendiDiSolaLettura(c);
                }
                else {
                    TextBox t = c as TextBox;
                    if (t != null) {
                        t.ReadOnly = true;
                    }

                    RadioButton rb = c as RadioButton;
                    if (rb != null) {
                        rb.Enabled = false;
                    }

                    ComboBox cb = c as ComboBox;
                    if (cb != null) {
                        cb.Enabled = false;
                    }

                    Button b = c as Button;
                    if ((b != null) && (b != btnOk) && (b != btnCancel)) {
                        b.Enabled = false;
                    }
                }
            }
        }

        public void MetaData_BeforeFill() {
            if (DS.payrolltaxcorrige.Rows.Count == 0) return;
            DataRow Curr = DS.payrolltaxcorrige.Rows[0];
            DataRow parentRowCedolino = Curr.GetParentRow("payrollpayrolltaxcorrige");
            if (parentRowCedolino == null) return;
            DataRow parentRow = Curr.GetParentRow("taxpayrolltaxcorrige");
            if ((parentRow != null) && (parentRowCedolino != null)) {
                string filterImponibile = QHS.AppAnd(QHS.CmpEq("taxablecode", parentRow["taxablecode"]),
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                object imponibile = Meta.Conn.DO_READ_VALUE("taxablekind", filterImponibile, "description");
                if (imponibile != null) {
                    txtTipoImponibile.Text = imponibile.ToString();
                }

                object idCity = Curr["idcity"];
                object idFiscalTaxRegion = Curr["idfiscaltaxregion"];

                if (idCity != DBNull.Value) {
                    string nomeEnteLocale = ottieniEnteLocale(parentRow["geoappliance"], idCity);
                    txtEnte.Text = nomeEnteLocale;
                }
                else {
                    if (idFiscalTaxRegion != DBNull.Value) {
                        string nomeEnteLocale = ottieniEnteLocale(parentRow["geoappliance"], idFiscalTaxRegion);
                        txtEnte.Text = nomeEnteLocale;
                    }
                    else {
                        lblEnte.Visible = false;
                        txtEnte.Visible = false;
                    }
                }
            }
        }

        private string ottieniEnteLocale(object geoAppliance, object idGeo) {
            if (geoAppliance == DBNull.Value) return "";
            string geo = geoAppliance.ToString().ToUpper();

            object nomeEnte = null;
            if (geo == "R") {
                nomeEnte = Meta.Conn.DO_READ_VALUE("fiscaltaxregion", QHS.CmpEq("idfiscaltaxregion", idGeo), "title");
            }

            if (geo == "P") {
                nomeEnte = Meta.Conn.DO_READ_VALUE("geo_cityview", QHS.CmpEq("idcity", idGeo), "country");
            }

            if (geo == "C") {
                nomeEnte = Meta.Conn.DO_READ_VALUE("geo_cityview", QHS.CmpEq("idcity", idGeo), "title");
            }

            if (nomeEnte == null) return "";

            return nomeEnte.ToString();
        }

        public void MetaData_AfterActivation() {
            DataRow parentRowCedolino = DS.payrolltaxcorrige.Rows[0].GetParentRow("payrollpayrolltaxcorrige");
            if (parentRowCedolino == null) return;

            string isConguaglio = parentRowCedolino["flagbalance"].ToString().ToUpper();
            if (isConguaglio == "S") {
                rdoConguaglio.Checked = true;
                rdoRata.Checked = false;
            }
            else {
                rdoConguaglio.Checked = false;
                rdoRata.Checked = true;
            }
        }
    }
}