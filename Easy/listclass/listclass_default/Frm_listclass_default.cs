
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
using SituazioneViewer;
using funzioni_configurazione;
using metadatalibrary;


namespace listclass_default {
    public partial class Frm_listclass_default : Form {
        MetaData Meta;
        public Frm_listclass_default() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            DataAccess Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            GetData.SetSorting(DS.listclass, "printingorder");
            if (Meta.edit_type == "default") {
                //GetData.SetStaticFilter(DS.listclass, Meta.GetFilterForSearch(DS.listclass));
                //Meta.StartFilter = Meta.GetFilterForSearch(DS.listclass);
            }

            //string filterEpOperationDeb = QHS.CmpEq("idepoperation", "fatacq");
            //GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationDeb);
            //DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;

            DataAccess.SetTableForReading(DS.accmotiveapplied_credit, "accmotiveapplied");


            string filterEpOperationCred = QHS.CmpEq("idepoperation", "registry_cred");
            GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCred);
            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;

            setFiltroAcquistiVendite(true);
            HelpForm.SetDenyNull(DS.listclass.Columns["authrequired"],true);

            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterEsercizio2 = QHS.NullOrEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.intrastatcode, filterEsercizio);
            GetData.SetStaticFilter(DS.intrastatservice, filterEsercizio);
            GetData.SetStaticFilter(DS.listclassyear, filterEsercizio2);
            GetData.SetStaticFilter(DS.listclassyearview, filterEsercizio2);
            GetData.SetStaticFilter(DS.intrastatcodeview, filterEsercizio);
            HelpForm.SetDenyNull(DS.listclass.Columns["flagvisiblekind"], true);
            if (DS.listclass.Rows.Count == 0) {
                btnInsDettagli.Visible = false;
            }
        }

        void setFiltroAcquistiVendite(bool acquisti) {
            string filterEpOperationAcqVen;
            //string filterEpOperationCredDeb;
            if (acquisti) {
                filterEpOperationAcqVen = QHS.CmpEq("idepoperation", "fatacq");
                //filterEpOperationCredDeb = QHS.CmpEq("idepoperation", "registry_cred");
            }
            else {
                filterEpOperationAcqVen  = QHS.CmpEq("idepoperation", "fatven");
                //filterEpOperationCredDeb  = QHS.CmpEq("idepoperation", "registry_deb");
            }
            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationAcqVen);
            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationAcqVen;

            //GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCredDeb);
            //DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCredDeb;

        }

        public void MetaData_AfterGetFormData() {
            // In questo modo la libreria riconosce come sub entità di listclass la tabella listclassyear
            Meta.myHelpForm.addExtraEntity("listclassyear");
            //if (Meta.InsertMode)
            //{
            //    DataRow Curr = DS.listclass.Rows[0];
            //    foreach (DataRow R in DS.listclassyear.Select())
            //    {
            //        R["idlistclass"] = Curr["idlistclass"];
            //    }
            //}
        }
        public void MetaData_AfterActivation() {
            if (treeView1.Nodes.Count > 0) {
                if (!treeView1.Nodes[0].IsExpanded) {
                    treeView1.Nodes[0].Expand();
                }
            }
        }

        public void MetaData_BeforeFill() {
            Meta.MarkTableAsNotEntityChild(DS.intrastatservice);
            // Meta.MarkTableAsNotEntityChild(DS.intrastatcode);
            if (HelpForm.GetLastSelected(DS.listclass) == null)
                Meta.CanInsert = false;
            else
                Meta.CanInsert = true;
            if (Meta.InsertMode) {
                CreateListClassYearRow();
                btnInsDettagli.Visible = false;
            }
            if (DS.listclassyear.Rows.Count > 0) {
                btnInsDettagli.Visible = false;
                if (DS.listclassyear.Rows[0]["idintrastatcode"] != DBNull.Value) {
                    rdbBeni.Checked = true;
                    rdbServizi.Checked = false;
                }
                if (DS.listclassyear.Rows[0]["idintrastatservice"] != DBNull.Value) {
                    rdbBeni.Checked = false;
                    rdbServizi.Checked = true;
                }
            }
            else {
                btnInsDettagli.Visible = true;
            }
        }

        public void CreateListClassYearRow() {
            if (Meta.IsEmpty) return;
            DataRow Curr = HelpForm.GetLastSelected(DS.listclass);
            string filtro = QHC.AppAnd(QHC.CmpEq("idlistclass", Curr["idlistclass"]),
                QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataRow[] r = DS.listclassyear.Select(filtro);
            if (r.Length == 0) {
                MetaData metaLCY = MetaData.GetMetaData(this, "listclassyear");
                metaLCY.SetDefaults(DS.listclassyear);
                DataRow DR = metaLCY.Get_New_Row(Curr, DS.listclassyear);
            }
        }

        public void MetaData_AfterFill() {
            txtCodice.ReadOnly = Meta.EditMode;
            setFiltroCausale();
            AbilitaClassInv();
            AbilitaBeniServizi();

        }


        private void AbilitaClassInv() {
            if (radioInvent.Checked || radioNonInvent.Checked || radioMagazzino.Checked) {
                grpInventario.Visible = true;
            }
            else {
                txtDescClassif.Text = "";
                txtCodClassif.Text = "";
                grpInventario.Visible = false;
            }
        }


        private void AbilitaBeniServizi() {
            if (Meta.IsEmpty) {
                grpBeni.Visible = true;
                grpServizi.Visible = true;
                txtCodServizi.Text = "";
                txtServizi.Text = "";
                txtIntrastatCode.Text = "";
                txtDescrIntrastat.Text = "";
                cmbModErogazione.SelectedIndex = -1;
                cmbmeasure.SelectedIndex = -1;
                DS.intrastatservice.Clear();
                DS.intrastatcode.Clear();
                return;
            }
            DataRow Curr = HelpForm.GetLastSelected(DS.listclass);
            string filtro = QHC.AppAnd(QHC.CmpEq("idlistclass", Curr["idlistclass"]),
                QHC.CmpEq("ayear", Meta.GetSys("esercizio")));

            DataRow[] r = DS.listclassyear.Select(filtro);
            if (r.Length == 0) {
                grpBeni.Visible = false;
                grpServizi.Visible = false;
                txtCodServizi.Text = "";
                txtServizi.Text = "";
                txtIntrastatCode.Text = "";
                txtDescrIntrastat.Text = "";
                cmbModErogazione.SelectedIndex = -1;
                cmbmeasure.SelectedIndex = -1;
                DS.intrastatservice.Clear();
                DS.intrastatcode.Clear();
                return;
            }

            if (rdbBeni.Checked) {
                grpBeni.Visible = true;

                grpServizi.Visible = false;
                txtCodServizi.Text = "";
                txtServizi.Text = "";
                if (Meta.DrawStateIsDone) {
                    if (!Meta.IsEmpty) {
                        DS.listclassyear.Rows[0]["idintrastatservice"] = DBNull.Value;
                    }
                    DS.intrastatservice.Clear();
                    cmbModErogazione.SelectedIndex = -1;
                }
            }
            else {
                grpServizi.Visible = true;
                grpBeni.Visible = false;
                txtIntrastatCode.Text = "";
                txtDescrIntrastat.Text = "";
                if (Meta.DrawStateIsDone) {
                    if (!Meta.IsEmpty) {
                        DS.listclassyear.Rows[0]["idintrastatcode"] = DBNull.Value;
                    }
                    DS.intrastatcode.Clear();
                    cmbmeasure.SelectedIndex = -1;
                }
            }
        }

        public void MetaData_AfterClear() {
            txtCodice.ReadOnly = false;
            if (HelpForm.GetLastSelected(DS.listclass) == null)
                Meta.CanInsert = false;
            else
                Meta.CanInsert = true;
            btnInsDettagli.Visible = false;
            rdbServizi.Checked = false;
            rdbBeni.Checked = false;
            AbilitaBeniServizi();
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName != "listclass") return;
            bool ModoInsert = Meta.InsertMode;
            txtCodice.ReadOnly = Meta.EditMode;
        }

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
            TreeNode TN = e.Node;
            if (TN.Tag != null) return;
        }

        private void chkAttivo_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) {
                if (((CheckBox)sender).CheckState == CheckState.Indeterminate)
                    ((CheckBox)sender).CheckState = CheckState.Unchecked;
            }
        }

        private void radioInvent_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaClassInv();
        }

        private void radioNonInvent_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaClassInv();
        }

        private void radioMagazzino_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaClassInv();
        }

        private void radioServizi_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaClassInv();
        }

        private void rdbAltro_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaClassInv();
        }

        private void rdbBeni_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaBeniServizi();
        }

        private void rdbServizi_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            AbilitaBeniServizi();
        }

        private void btnInsDettagli_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);
            CreateListClassYearRow();
            Meta.FreshForm(false);
        }

        private void chkContrattiPassivi_CheckStateChanged(object sender, EventArgs e) {
            setFiltroCausale();
        }

        private void chkContrattiAttivi_CheckStateChanged(object sender, EventArgs e) {
            setFiltroCausale();
        }

        private void chkPrenotazioniVetrina_CheckStateChanged(object sender, EventArgs e) {
            setFiltroCausale();
        }

        void setFiltroCausale() {
            if (Meta==null)return;
            setFiltroAcquistiVendite(chkContrattiAttivi.Checked==false);
        }
    }
}
