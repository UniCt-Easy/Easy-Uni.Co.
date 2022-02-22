
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

namespace invoicedeferred_fattureliquidate {
    public partial class Frm_invoicedeferred_fattureliquidate : Form {
		ContextMenu ExcelMenu;
		public Frm_invoicedeferred_fattureliquidate(DataTable FattLiq) {
            InitializeComponent();
			ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
			gridfatture.ContextMenu = ExcelMenu;

			DS.Tables.Add(FattLiq);

			HelpForm.SetDataGrid(gridfatture, FattLiq);

			formatgrids FL = new formatgrids(gridfatture);
			FL.AutosizeColumnWidth();
		}
        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null)
                return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))
                return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))
                return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null)
                return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))
                return;
            string DDT = G.DataMember;
            if (DDT == null)
                return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null)
                return;
            exportclass.DataTableToExcel(T, true);
        }
    }
}
