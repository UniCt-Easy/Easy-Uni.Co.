
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

namespace inventorytree_uniforma {
    public partial class AskClassificazione : MetaDataForm {
        MetaData Meta;
        public AskClassificazione(MetaData Meta) {
            this.Meta = Meta;
            InitializeComponent();
            string filter = "tablename = 'inventorytree'";
            DataTable tClass = DataAccess.CreateTableByName(Meta.Conn, "sortingapplicabilityview", "idsorkind, description");
            GetData.MarkToAddBlankRow(tClass);
            GetData.Add_Blank_Row(tClass);
            Meta.Conn.RUN_SELECT_INTO_TABLE(tClass, null, filter, null, true);

            if (tClass == null) return;
            
            tClass.TableName = "sortingkind";
            DataSet ds = new DataSet();
            ds.Tables.Add(tClass);
            cmbSortingKind.DataSource = ds.Tables[0];
            cmbSortingKind.ValueMember = "idsorkind";
            cmbSortingKind.DisplayMember = "description";
        }
    }
}
