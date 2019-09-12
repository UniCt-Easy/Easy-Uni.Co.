/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace mandateavcp_single {
    public partial class Frm_mandateavcp_single : Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        public Frm_mandateavcp_single() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.mandateavcp.Columns["flagnonparticipating"], true);
        }

        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            GetData.MarkToAddBlankRow(DS.capogruppo);
            PostData.MarkAsTemporaryTable(DS.capogruppo, true);

            DataTable Partecipanti = Meta.SourceRow.Table.DataSet.Tables["mandateavcp"];
            foreach (DataRow p in Partecipanti.Select(
                 QHC.AppAnd(QHC.IsNull("idmain_avcp"),QHC.CmpEq("flagcontractor","N"),
                 QHC.CmpEq("idavcp_role","04"),
                    QHC.CmpNe("idavcp", Meta.SourceRow["idavcp"])))) {
                DataRow rC = DS.capogruppo.NewRow();
                rC["idavcp"] = p["idavcp"];
                rC["title"] = p["title"];
                DS.capogruppo.Rows.Add(rC);
            }
            object this_avcp = Meta.SourceRow["idavcp"];
            if (Partecipanti.Select(QHC.CmpEq("idmain_avcp", this_avcp)).Length > 0) {
                chkSingolo.Enabled = false;
                cmbRuolo.Enabled = false;
            }
            
        }

     
        void ImpostaSingoloOGruppo() {
            
            if (chkSingolo.Checked) {
                cmbCapogruppo.SelectedIndex = 0;
                cmbRuolo.SelectedIndex = 0;
                gboxGruppo.Visible = false;
                if (DS.mandateavcp.Rows.Count > 0) {
                    DataRow Curr = DS.mandateavcp.Rows[0];
                    Curr["idavcp_role"] = DBNull.Value;
                    Curr["idmain_avcp"] = DBNull.Value;
                }
                     
            }
            else {
                gboxGruppo.Visible = true;
            }
        }
        public void MetaData_AfterFill() {
            DataRow Curr = DS.mandateavcp.Rows[0];
            if (Curr["idreg"] != DBNull.Value) {
                txtCF.ReadOnly = true;
                txtCFEstero.ReadOnly = true;
                txtRagSociale.ReadOnly = true;
            }
            else {
                txtCF.ReadOnly = false;
                txtCFEstero.ReadOnly = false;
                txtRagSociale.ReadOnly = false;
            }
            ImpostaSingoloOGruppo();
            MostraNascondiCapogruppo();
        }

        void MostraNascondiCapogruppo() {
            if (cmbRuolo.Visible == false || cmbRuolo.SelectedIndex==0 || cmbRuolo.SelectedValue==null ||cmbRuolo.SelectedValue.ToString() == "04") {
                labelCapo.Visible = false;
                cmbCapogruppo.SelectedIndex = 0;
                cmbCapogruppo.Visible = false;
                return;
            }
           
            cmbCapogruppo.Visible = true;
            labelCapo.Visible = true;
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "registry") {
                if (R == null) {
                    txtCF.ReadOnly = false;
                    txtCFEstero.ReadOnly = false;
                    txtRagSociale.ReadOnly = false;
                }
                else {
                    if (R["cf"] != DBNull.Value) {
                        txtCF.Text = R["cf"].ToString();
                    }
                    else {
                        if (R["p_iva"] != DBNull.Value) {
                            string p_iva = R["p_iva"].ToString();
                            if (isPartitaEstera(p_iva)) {
                                txtCFEstero.Text = p_iva;
                            }
                            else {
                                txtCF.Text = p_iva;
                            }
                        }
                        else {
                            txtCFEstero.Text = R["foreigncf"].ToString();
                        }
                    }

                    txtRagSociale.Text = R["title"].ToString();
                    txtCF.ReadOnly = true;
                    txtCFEstero.ReadOnly = true;
                    txtRagSociale.ReadOnly = true;
                }
            }

            if ((T.TableName == "avcprole") && Meta.DrawStateIsDone) {
                MostraNascondiCapogruppo();
            }
        }

        bool isPartitaEstera(string p_iva) {
            if (p_iva == null) return false;
            if (p_iva.Length == 2) return false;
            if (Char.IsDigit(p_iva[0])) return false;
            if (Char.IsDigit(p_iva[1])) return false;
            return true;
        }

        private void chkSingolo_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            ImpostaSingoloOGruppo();
        }

      
    }
}
