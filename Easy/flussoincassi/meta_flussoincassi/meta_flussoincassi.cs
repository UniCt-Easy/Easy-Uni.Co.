
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



namespace meta_flussoincassi {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_flussoincassi : Meta_easydata {

        int esercizio;

        public Meta_flussoincassi(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "flussoincassi") {
            Name = "Flusso Incassi";
            EditTypes.Add("default");
            ListingTypes.Add("default");            
            esercizio = Convert.ToInt32(GetSys("esercizio"));
        }

        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": {
                        Name = "Flusso Incassi";
                        CanInsertCopy = false;
                        DefaultListType = "default";
                        return MetaData.GetFormByDllName("flussoincassi_default");
                }
            }
            return null;
        }

        override public void SetDefaults(DataTable Primary) {
            base.SetDefaults(Primary);

            SetDefault(Primary, "ayear", esercizio);
            SetDefault(Primary, "to_complete", "N");
            SetDefault(Primary, "elaborato", "N");
            SetDefault(Primary, "active", "S");
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idflusso"], null, null, -1);
            RowChange.setMinimumTempValue(T.Columns["idflusso"],900000000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "flussoincassiview", ToMerge);
			else
				return base.SelectOne(ListingType, filter, "flussoincassi", ToMerge);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codiceflusso", "Codice", nPos++);
                DescribeAColumn(T, "trn", "TRN", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "causale", "Causale", nPos++);
                DescribeAColumn(T, "dataincasso", "Data Incasso", nPos++);
                DescribeAColumn(T, "nbill", "Numero Sospeso Attivo", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "elaborato", "Elaborato", nPos++);              
            }


        }

    }

}


