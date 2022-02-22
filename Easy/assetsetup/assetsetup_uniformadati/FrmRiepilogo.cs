
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace assetsetup_uniformadati {
    public partial class FrmRiepilogo : MetaDataForm {
        DataSet dsPruned = new DataSet();
        public FrmRiepilogo(MetaData Meta, DataSet ds) {
            InitializeComponent();
            pruneTable(ds);
            fillCaption();
            fillGrid();
        }

        private void pruneTable(DataSet ds) {
            string [] elencoTabelle = new string [] {"inventory", "assetloadmotive", "assetunloadmotive", "assetloadkind", "assetunloadkind"};

            foreach (string tName in elencoTabelle) {
                DataTable t = new DataTable(tName);
                foreach (DataColumn C in ds.Tables[tName].Columns) {
                    t.Columns.Add(C.ColumnName);
                }

                foreach (DataRow r in ds.Tables[tName].Rows) {
                    if ((r["!linkedcode"] == DBNull.Value) || (r["!linkedcode"].ToString() == ""))
                        continue;
                    DataRow newRowOfT = t.NewRow();
                    foreach (DataColumn C in ds.Tables[tName].Columns) {
                        if (t.Columns.Contains(C.ColumnName)) {
                            newRowOfT[C.ColumnName] = r[C.ColumnName];
                        }
                    }
                    t.Rows.Add(newRowOfT);
                }
                dsPruned.Tables.Add(t);
            }
            dsPruned.AcceptChanges();
        }

        private void fillGrid() {
            HelpForm.SetDataGrid(dgInventory, dsPruned.Tables["inventory"]);
            HelpForm.SetDataGrid(dgAssetLoadMotive, dsPruned.Tables["assetloadmotive"]);
            HelpForm.SetDataGrid(dgAssetUnloadMotive, dsPruned.Tables["assetunloadmotive"]);
            HelpForm.SetDataGrid(dgAssetLoadKind, dsPruned.Tables["assetloadkind"]);
            HelpForm.SetDataGrid(dgAssetUnloadKind, dsPruned.Tables["assetunloadkind"]);
        }

        private void fillCaption() {
            string [] elencoTabelle = new string [] {"inventory", "assetloadmotive", "assetunloadmotive", "assetloadkind", "assetunloadkind"};
            
            foreach (string tName in elencoTabelle) {
                foreach (DataColumn c in dsPruned.Tables[tName].Columns) {
                    c.Caption = "";
                }
            }

            // Tabella INVENTORY
            dsPruned.Tables["inventory"].Columns["codeinventory"].Caption = "Cod. Inventario";
            dsPruned.Tables["inventory"].Columns["description"].Caption = "Inventario";
            dsPruned.Tables["inventory"].Columns["!linkedcode"].Caption = "Cod. Inventario di Rif.";
            dsPruned.Tables["inventory"].Columns["!linkeddescr"].Caption = "Inventario di Rif.";

            // Tabella ASSETLOADMOTIVE
            dsPruned.Tables["assetloadmotive"].Columns["codemot"].Caption = "Cod. Causale";
            dsPruned.Tables["assetloadmotive"].Columns["description"].Caption = "Causale";
            dsPruned.Tables["assetloadmotive"].Columns["!linkedcode"].Caption = "Cod. Causale di Rif.";
            dsPruned.Tables["assetloadmotive"].Columns["!linkeddescr"].Caption = "Causale di Rif.";

            // Tabella ASSETUNLOADMOTIVE
            dsPruned.Tables["assetunloadmotive"].Columns["codemot"].Caption = "Cod. Causale";
            dsPruned.Tables["assetunloadmotive"].Columns["description"].Caption = "Causale";
            dsPruned.Tables["assetunloadmotive"].Columns["!linkedcode"].Caption = "Cod. Causale di Rif.";
            dsPruned.Tables["assetunloadmotive"].Columns["!linkeddescr"].Caption = "Causale di Rif.";

            // Tabella ASSETLOADKIND
            dsPruned.Tables["assetloadkind"].Columns["codeassetloadkind"].Caption = "Cod. Buono di Carico";
            dsPruned.Tables["assetloadkind"].Columns["description"].Caption = "Descrizione Tipo Buono";
            dsPruned.Tables["assetloadkind"].Columns["!linkedcode"].Caption = "Cod. Buono di Carico di Rif.";
            dsPruned.Tables["assetloadkind"].Columns["!linkeddescr"].Caption = "Descrizione Tipo Buono di Rif.";

            // Tabella ASSETUNLOADKIND
            dsPruned.Tables["assetunloadkind"].Columns["codeassetunloadkind"].Caption = "Cod. Buono di Scarico";
            dsPruned.Tables["assetunloadkind"].Columns["description"].Caption = "Descrizione Tipo Buono";
            dsPruned.Tables["assetunloadkind"].Columns["!linkedcode"].Caption = "Cod. Buono di Scarico di Rif.";
            dsPruned.Tables["assetunloadkind"].Columns["!linkeddescr"].Caption = "Descrizione Tipo Buono di Rif.";
        }
    }
}
