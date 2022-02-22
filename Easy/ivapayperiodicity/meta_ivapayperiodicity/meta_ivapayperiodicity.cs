
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//using tipoperiodliquiva;

namespace meta_ivapayperiodicity//meta_tipoperiodliquiva//
{
    /// <summary>
    /// Summary description for tipoperiodliquiva.
    /// </summary>
    public class Meta_ivapayperiodicity : Meta_easydata {
        public Meta_ivapayperiodicity(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
        base(Conn, Dispatcher, "ivapayperiodicity") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Peridiocità della liquidazione";
                ActAsList();
                SearchEnabled = false;
                return GetFormByDllName("ivapayperiodicity_default");
                //return new frmtipoperiodliquiva();
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                int nPos = 1;
                DescribeAColumn(T, "idivapayperiodicity", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "periodicity", "Periodicità", nPos++);
                DescribeAColumn(T, "periodicday", "Giorno", nPos++);
                DescribeAColumn(T, "periodicmonth", "Mese", nPos++);
            }
            if (ListingType == "checkimport") {
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "periodicday", "Giorno", nPos++);
                DescribeAColumn(T, "periodicity", "Periodicità", nPos++);
                DescribeAColumn(T, "periodicmonth", "Mese", nPos++);
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idivapayperiodicity"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idivapayperiodicity");
            if (N < 9999000)
                R["idivapayperiodicity"] = 9999001;
            else
                R["idivapayperiodicity"] = N + 1;

            return R;
        }
    }

}
