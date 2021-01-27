
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_electronicinvoice {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_electronicinvoice : Meta_easydata {
        public Meta_electronicinvoice(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "electronicinvoice") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": {
                        DefaultListType = "default";
                        Name = "Seleziona fatture vendita da trasmettere";
                        return MetaData.GetFormByDllName("electronicinvoice_default");
                    }

            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "yelectronicinvoice", Conn.GetEsercizio());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["nelectronicinvoice"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
         
                return base.SelectOne(ListingType, filter, "electronicinvoiceview", ToMerge);

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                errmess = "Indicare il Cliente";
                errfield = "idreg";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idtreasurer"]) == 0) {
                errmess = "Indicare il Cedente/Prestatore";
                errfield = "idtreasurer";
                return false;
            }
            if (!base.IsValid(R, out errmess, out errfield))
                return false;

            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "nelectronicinvoice", "Numero");
                DescribeAColumn(T, "ydelectronicinvoice", "Esercizio");
            }
        }
    }
}
