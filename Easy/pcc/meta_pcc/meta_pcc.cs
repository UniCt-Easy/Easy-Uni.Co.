
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_pcc {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_pcc : Meta_easydata {
        public Meta_pcc(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "pcc") {
            EditTypes.Add("default");
            EditTypes.Add("wizard_calcolo");
            EditTypes.Add("wizard_calcolo_sid");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": {
                        DefaultListType = "default";
                        Name = "Trasmissioni AreaRGS effettuate";
                        return MetaData.GetFormByDllName("pcc_default");
                    }
                case "wizard_calcolo": {
                        DefaultListType = "default";
                        Name = "Calcolo dati per Piattaforma per la certificazione dei crediti";
                        return MetaData.GetFormByDllName("pcc_wizard_calcolo");
                    }
                case "wizard_calcolo_sid": {
                        DefaultListType = "default";
                        Name = "Genera file trasmissione AreaRGS";
                        return MetaData.GetFormByDllName("pccsid_wizard_calcolo");
                    }
            }
            return null;
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idpcc desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R.Table.Columns.Contains("attachment")) {
                R.Table.Columns["attachment"].ExtendedProperties["skipSizeCheck"] = true;
            }
            return base.IsValid(R, out errmess, out errfield);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idpcc"], null, null, 0);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "idpcc", "Numero");
                DescribeAColumn(T, "filename", "Nome File");
            }
        }
    }
}
