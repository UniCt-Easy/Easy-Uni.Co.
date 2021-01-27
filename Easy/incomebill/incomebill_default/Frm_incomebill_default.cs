
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
using metadatalibrary;
using funzioni_configurazione;

namespace incomebill_default {
    public partial class Frm_incomebill_default : Form {
        MetaData Meta;
        public Frm_incomebill_default() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string billfilter = QHS.AppAnd(QHS.CmpEq("billkind", 'C'), QHS.CmpEq("ybill", Meta.GetSys("esercizio")));
            object idflowchart = Meta.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                int flagtreasurer = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("uniconfig", null, "(isnull(flag,0)&1)"));
                if (flagtreasurer != 0)
                    billfilter = QHS.AppAnd(billfilter, QHS.IsNotNull("idtreasurer"));
            }
            GetData.SetStaticFilter(DS.bill, billfilter);
            GetData.SetStaticFilter(DS.billview, billfilter);

        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "bill") {
                if (R != null)
                    ManageBollettaChange(R);
            }
        }

        void ManageBollettaChange(DataRow Bolletta) {
            if (Meta.IsEmpty)
                return;
            decimal impcorrente = CfgFn.GetNoNullDecimal(
                    HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text,
                                "x.y.c"));
            string filter = QueryCreator.WHERE_KEY_CLAUSE(Bolletta, DataRowVersion.Default, true);
            filter = GetData.MergeFilters(filter,
                "(billkind='C')and(ybill='" + Meta.GetSys("esercizio").ToString() + "')");
            object imp = Meta.Conn.DO_READ_VALUE("billview", filter,
                "isnull(total,0)-isnull(reduction,0)-isnull(covered,0)");

            decimal importoBolletta = CfgFn.GetNoNullDecimal(imp);
            if (importoBolletta < 0) {
                importoBolletta = 0;
            }
            DataRow R = DS.incomebill.Rows[0];
            R["amount"] = importoBolletta;
            txtImporto.Text = HelpForm.StringValue(importoBolletta, "x.y.c");

        }
    }
}
