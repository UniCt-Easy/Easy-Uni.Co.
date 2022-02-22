
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_flussocreditidetail_esse3 {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_flussocreditidetail_esse3 : Meta_easydata {
        public Meta_flussocreditidetail_esse3(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "flussocreditidetail_esse3") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Dettaglio Flusso crediti esse3";
                return MetaData.GetFormByDllName("flussocreditidetail_esse3_default");
            }
            return null;
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {            
            T.setMySelector("iddetail", "idflusso", 0);
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            RowChange.setMinimumTempValue(T.Columns["iddetail"],999000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            return base.SelectOne(ListingType, filter, "flussocreditidetail_esse3", Exclude);
        }

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (list_type.Equals("posting")) {
                // Calcola il numero di bollettino nel caso in cui non sia stato valorizzato
                if (DBNull.Value.Equals(R["iduniqueformcode"])) {
                    R["iduniqueformcode"] = $"easyfcred{R["idflusso"]:D14}{R["idreg"]:D10}";
                    return;
                }
                //potrebbe essere stato chiamato altre volte ma prima del calcolo definitivo dei campi ad autoincremento
                if (R.RowState==DataRowState.Added && (R["iduniqueformcode"].ToString().StartsWith("easyfcred"))) {
                    R["iduniqueformcode"] = $"easyfcred{R["idflusso"]:D14}{R["idreg"]:D10}";
                    return;
                }
            }
        }
    }
}
