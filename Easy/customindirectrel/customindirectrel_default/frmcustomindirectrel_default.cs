
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
using metaeasylibrary;
using funzioni_configurazione;

namespace customindirectrel_default {
    public partial class frmcustomindirectrel_default : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        public frmcustomindirectrel_default() {
            InitializeComponent();
            DataAccess.SetTableForReading(DS.customobject_middle, "customobject");
            DataAccess.SetTableForReading(DS.customobject_parent1, "customobject");
            DataAccess.SetTableForReading(DS.customobject_parent2, "customobject");
            DataAccess.SetTableForReading(DS.customobject_parent2view, "customobject");
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Dispatcher = Meta.Dispatcher as EntityDispatcher;
            Conn = Meta.Conn;
            esercizio = Conn.GetEsercizio();
            QHS = Conn.GetQueryHelper();
            PostData.MarkAsTemporaryTable(DS.edittype, false);
            PostData.MarkAsTemporaryTable(DS.listtype, false);
            cmblist.DataSource = DS.listtype;
            cmblist.DisplayMember = "list";
            cmblist.ValueMember = "list";
            cmbedit.DataSource = DS.edittype;
            cmbedit.DisplayMember = "edit";
            cmbedit.ValueMember = "edit";
            //bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
        }

        void riempiComboList(object table) {
            if (table==null || table.ToString() == "") return;
            object oldvalue = null;
            if (!Meta.IsEmpty) oldvalue = DS.customindirectrel._First().listtype;
            var Metatemp = Meta.Dispatcher.Get(table.ToString());
            var x = Metatemp.ListingTypes;
            DS.listtype.Clear();
            DataRow R = DS.listtype.NewRow();
            R["list"] = "";
            DS.listtype.Rows.Add(R);
            bool foundOriginal = false;
            foreach (var item in x) {
                if (oldvalue != null && item.ToString() == oldvalue.ToString()) foundOriginal = true;
                DataRow Rr = DS.listtype.NewRow();
                Rr["list"] = item;
                DS.listtype.Rows.Add(Rr);
            }
            if (oldvalue != null && !foundOriginal) {
                DataRow Rr = DS.listtype.NewRow();
                Rr["list"] = oldvalue;
                DS.listtype.Rows.Add(Rr);
            }
            DS.listtype.AcceptChanges();
            cmblist.DataSource = DS.listtype;
            cmblist.DisplayMember = "list";
            cmblist.ValueMember = "list";            
        }

        void riempiComboEdit(object table) {
            if (table == null || table.ToString() == "") return;
            object oldvalue = null;
            if (!Meta.IsEmpty) oldvalue = DS.customindirectrel.First().edittype;
            var Metatemp = Meta.Dispatcher.Get(table.ToString());
            var x = Metatemp.EditTypes;
            DS.edittype.Clear();
            DataRow R = DS.edittype.NewRow();
            R["edit"] = "";
            DS.edittype.Rows.Add(R);
            bool foundOriginal = false;
            foreach (var item in x) {
                if (oldvalue != null && item.ToString() == oldvalue.ToString()) foundOriginal = true;
                DataRow Rr = DS.edittype.NewRow();
                Rr["edit"] = item;
                DS.edittype.Rows.Add(Rr);
            }
            if (oldvalue != null && !foundOriginal) {
                DataRow Rr = DS.edittype.NewRow();
                Rr["edit"] = oldvalue;
                DS.edittype.Rows.Add(Rr);
            }
            DS.edittype.AcceptChanges();
            cmbedit.DataSource = DS.edittype;
            cmbedit.DisplayMember = "edit";
            cmbedit.ValueMember = "edit";

        }

        //public void MetaData_AfterActivation() { }
        public void MetaData_AfterClear() {
            DS.edittype.Clear();
            DS.listtype.Clear();
        }
        public void MetaData_BeforeFill() {
            if (Meta.FirstFillForThisRow) {
                var curr = DS.customindirectrel._First();
                riempiComboEdit(curr.parenttable2);
                riempiComboList(curr.parenttable2view ?? curr.parenttable2);
            }
        }
        public void MetaData_AfterFill() {
           

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone) return;
            if (R==null)return;
            if (T.TableName == "customobject_parent2" && R != null) {
                if (!Meta.IsEmpty) {
                    var curr = DS.customindirectrel.First();
                    curr.edittype = null;
                    if (txtParent2w.Text == "") {
                        curr.listtype = null;
                    }

                }
                riempiComboEdit(R["objectname"].ToString());
                if (txtParent2w.Text == "") {
                    riempiComboList(R["objectname"].ToString());
                }
            }
            if (T.TableName == DS.customobject_parent2view.TableName) {
                if (!Meta.IsEmpty) {
                    var curr = DS.customindirectrel.First();
                    curr.listtype = null;
                }
                riempiComboList(R["objectname"].ToString());
            }            
        }
        //public void MetaData_BeforePost() { }
        //public void MetaData_AfterPost() { }
    }
}
