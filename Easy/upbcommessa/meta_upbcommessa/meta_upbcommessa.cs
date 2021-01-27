
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;

namespace meta_upbcommessa {
    public class Meta_upbcommessa : Meta_easydata {
        public Meta_upbcommessa(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "upbcommessa") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Assestamento Commessa completata";
        }

        /// <summary>
        /// Impostare la chiave, serve per le viste, non per le tabelle!!
        /// </summary>
        private string[] mykey = new string[] {"idupb", "ayear"};

        public override string[] primaryKey() {
            return mykey;
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Assestamento Commessa completata";
                return MetaData.GetFormByDllName("upbcommessa_default");
            }

            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            //SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            //RowChange.SetMySelector(T.Columns["nupbcommessa"], "nphase", 0);  //campo nphase  è selettore per calcolo di nupbcommessa
            //RowChange.SetMySelector(T.Columns["nupbcommessa"], "yupbcommessa", 0);//campo yupbcommessa  è selettore per calcolo di nupbcommessa
            //RowChange.MarkAsAutoincrement(T.Columns["nupbcommessa"], null, null, 0);  //nupbcommessa è campo ad autoincremento
            //RowChange.MarkAsAutoincrement(T.Columns["idupbcommessa"], null, null, 0);  //idupbcommessa è campo ad autoincremento

            //RowChange.setMinimumTempValue(T.Columns["idupbcommessa"], 999900000);     //Da impostare  in caso di pericolo di conflitto
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        /// <summary>
        /// FilterRow, si usa per i grid filtrati
        /// </summary>
        /// <param name="R"></param>
        /// <param name="list_type"></param>
        /// <returns></returns>
        public override bool FilterRow(DataRow R, string list_type) {
            //if (list_type == "form_contenitore") {
            //    if (R["chiave contenitore"] == DBNull.Value) return false;
            //    return true;
            //}

            return true;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            //if (condizione di errore) {
            //    errmess = "Messaggio di errore";
            //    errfield = "Nome campo su cui posizionare il focus";
            //    return false;
            //}


            return true;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "upbcommessaview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "upbcommessa", Exclude);
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            //switch (ListingType) {
            //    case "default": {
            //        foreach (DataColumn C in T.Columns) {
            //            DescribeAColumn(T, C.ColumnName, "", -1);
            //        }

            //        int nPos = 1;
            //        DescribeAColumn(T, "ayear", "esercizio", nPos++);
            //        DescribeAColumn(T, "codeupb", "esercizio", nPos++);
            //        break;
            //    }
        }
    }
}

