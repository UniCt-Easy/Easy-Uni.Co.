
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
using metadatalibrary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generaSQL {
    public partial class FrmSelezioneTabelle : MetaDataForm {
        public FrmSelezioneTabelle(DataAccess Conn,bool viste) {
            InitializeComponent();
            string kind = viste ? "N" : "S";
            DataTable TT = Conn.SQLRunner($"SELECT DISTINCT objectname  from customobject where isreal='{kind}' order by objectname");
            string prec = null;
            foreach (DataRow R in TT.Rows) {
                string curr = R["objectname"].ToString();
                if (prec != curr) {
                    TableList.Items.Add(curr);
                    prec = curr;
                }
            }
        }

        private void btDeselezionaTabelle_Click(object sender, EventArgs e) {
            foreach (ListViewItem LI in TableList.Items) {
                LI.Checked = false;
            }
        }

        private void btnAllTables_Click(object sender, EventArgs e) {
            foreach (ListViewItem LI in TableList.Items) {
                LI.Checked = true;
            }
        }
    }
}
