
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;

namespace proceeds_reversalemultipla {

    public partial class frmFlussoCrediti : MetaDataForm {
        private MetaDataDispatcher disp;
        private DataAccess conn;
        private DataTable incassi;
        public bool errore = false;
        public List<DataRow> getSelectedRows() {
            var dsv = (DataSet) grid.DataSource;
            var tv = dsv?.Tables[grid.DataMember];
            if (tv == null) return null;
            
            
            int nrows = tv.Rows.Count;
            List<int> SelectedIndex = new List<int>();
            for (int i = 0; i < nrows; i++) {
                if (grid.IsSelected(i)) SelectedIndex.Add(i);
            }
            List<DataRow> SelectedRows = new List<DataRow>();
            foreach (int index in SelectedIndex) {
                //Prende una riga selezionata
                grid.CurrentRowIndex = index;
                DataRowView CurrDV = (DataRowView)grid.BindingContext[dsv, tv.TableName].Current;
                DataRow Curr = CurrDV.Row;
                SelectedRows.Add(Curr);                
            }
            return SelectedRows;
        }

        public frmFlussoCrediti(DataAccess conn, MetaDataDispatcher disp) {
            InitializeComponent();
            MetaData.SetColor(this);
            this.conn = conn;
            QueryHelper qhs = conn.GetQueryHelper();
            this.disp = disp;
            int esercizio = conn.GetEsercizio();
            object estimPhase = conn.GetSys("incomephase");
            DataSet d = new DataSet();
            incassi = conn.SQLRunner($@"
                    select I.* from incomelastview I
                        join incomelink IL on IL.idchild=I.idinc and {qhs.CmpEq("nlevel", estimPhase)} 
                        join incomeestimate IE on IE.idinc=IL.idparent
                        join estimatekind EK on IE.idestimkind=EK.idestimkind
                    where {qhs.AppAnd(qhs.IsNull("I.kpro"), qhs.CmpEq("ayear", esercizio), qhs.BitSet("EK.flag", 2)),0}
                ",false,120);
            if (incassi == null) {
                errore = true;
                return;                
            }
            d.Tables.Add(incassi);
            MetaData income = disp.Get("incomelastview");
            income.DescribeColumns(incassi,"documentocollegato");
            //id.DataSource = incassi;
            HelpForm.SetAllowMultiSelection(incassi,true);
            HelpForm.SetDataGrid(grid,incassi);
            HelpForm.SetGridStyle(grid,incassi);
        }

      

        private void btnSelectAll_Click(object sender, EventArgs e) {
            DataSet MyDS = (DataSet)grid.DataSource;
            DataTable MyTable = MyDS.Tables[grid.DataMember.ToString()];
            for (int i = 0; i < MyTable.Rows.Count; i++) { 
                grid.Select(i);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e) {
            DataSet MyDS = (DataSet)grid.DataSource;
            DataTable MyTable = MyDS.Tables[grid.DataMember.ToString()];
            for (int i = 0; i < MyTable.Rows.Count; i++) {
                grid.UnSelect(i);
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {

        }
    }
}
