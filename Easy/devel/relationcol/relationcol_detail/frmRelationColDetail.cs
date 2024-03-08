
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

namespace relationcol_detail {
    public partial class frmRelationColDetail : MetaDataForm {
        public frmRelationColDetail() {
            InitializeComponent();
        }

        MetaData Meta;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            DataAccess Conn = Meta.Conn;
            //QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.coldescr1, "coldescr");
            DataRow rcol = Meta.SourceRow;
            DataRow rRelation = rcol.Table.DataSet.Tables["relation"].Rows[0];
            
            //colonne child solo quelle della tabella child
            GetData.SetStaticFilter(DS.coldescr1, QHS.CmpEq("tablename", rRelation["childtable"]));
            txtRelazione.Text = rRelation["title"].ToString();
            txtRelazione.ReadOnly = true;
            //colonne parent solo colonne chiave della tabella parent
            GetData.SetStaticFilter(DS.coldescr, QHS.AppAnd(QHS.CmpEq("tablename", rRelation["parenttable"]),QHS.CmpEq("primarykey","S")));

        }
        string getHintForChildColumn(string parentcol) {
            //Cerca nelle colonne figlio mediante =
            foreach (DataRow rChild in DS.coldescr1.Rows) {
                if (rChild["colname"].ToString() == parentcol) {                    
                    return rChild["colname"].ToString();
                }
            }

            //Cerca nelle colonne figlio come iniziale
            foreach (DataRow rChild in DS.coldescr1.Rows) {
                if (rChild["colname"].ToString().StartsWith(parentcol)) {
                    return rChild["colname"].ToString();
                }
            }

            //Cerca nelle colonne figlio come substring
            foreach (DataRow rChild in DS.coldescr1.Rows) {
                if (rChild["colname"].ToString().Contains(parentcol)) {                    
                    return rChild["colname"].ToString();
                }
            }
            return null;
        }
        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow && Meta.InsertMode && cmbChildCol.SelectedIndex <= 0) {
                DataRow r = DS.relationcol.Rows[0];
                string parentcol = cmbParentCol.SelectedValue as string;
                object childcol = getHintForChildColumn(parentcol);
                if (childcol != null) HelpForm.SetComboBoxValue(cmbChildCol, childcol);
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow r) {
            if (!Meta.DrawStateIsDone) return;
            if (T.TableName=="coldescr" && r != null) {
                string parentcol = r["colname"].ToString();
                object childcol = getHintForChildColumn(parentcol);
                if (childcol!=null) HelpForm.SetComboBoxValue(cmbChildCol, childcol);                                                                                    
            }
        }


    }
}
