
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;


namespace relation_default {
    public partial class frmRelationDefault : MetaDataForm {
        public frmRelationDefault() {
            InitializeComponent();
        }
        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        string tableRelationCol = "relationcol";
        private MetaTable tRelationCol;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            DS.tabledescr_child.setTableForReading("tabledescr");
            DS.tabledescr_parent.setTableForReading("tabledescr");
            tRelationCol = DS.relationcol;
            DS.relationcol.TableForReading = "relationcol";

            if (Meta.edit_type == "child") {
                //Necessaria perchè nel form tabledescr questa tabella e la figlia si chiamano in modo diverso
                tRelationCol.TableName = "relationcol_child";
                tableRelationCol = tRelationCol.TableName;
                dgridCol.Tag = "relationcol_child.default.detail";
            }
            else {
                dgridCol.Tag = "relationcol.default.detail";
            }
            
        }

        public void MetaData_AfterFill() {     
            //se edittype default stiamo inserendo le tabelle PARENT della tabella corrententemente visualizzata in tabledescr 
            cmbParent.Enabled = Meta.edit_type!="child" && !Meta.EditMode && tRelationCol.Count==0;

            if (Meta.edit_type == "child" && Meta.FirstFillForThisRow && txtTabellaChild.Text=="") {
                txtTabellaChild.Text = cmbChild.Text;
            }

            //se edittype child stiamo inserendo le tabelle CHILD della tabella corrententemente visualizzata in tabledescr
            cmbChild.Enabled = Meta.edit_type == "child" && !Meta.EditMode && tRelationCol.Count == 0;
            if (DS.Tables[tableRelationCol].Rows.Count == 1 && txtDescription.Text=="") {
                DataRow curr = DS.relation.Rows[0];
                DataRow currCol = DS.Tables[tableRelationCol].Rows[0];
                object descr = Conn.DO_READ_VALUE("coldescr",
                    QHS.AppAnd(QHS.CmpEq("tablename", curr["childtable"]), QHS.CmpEq("colname", currCol["childcol"])),
                    "description"
                    );
                if (descr != null) {
                    txtDescription.Text = descr.ToString();
                }
            }
        }
        public void MetaData_AfterRowSelect(DataTable t,DataRow r) {
            if (!Meta.DrawStateIsDone) return;
            if (t.TableName== "tabledescr_child" && r != null) {
                txtTabellaChild.Text = r["description"].ToString();
            }
        }
    }
}
