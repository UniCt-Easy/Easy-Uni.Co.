
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_registryregolaritafiscale {
    /// <summary>
    /// MetaData for visura
    /// </summary>
    public class Meta_registryregolaritafiscale :Meta_easydata {
        public Meta_registryregolaritafiscale(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryregolaritafiscale") {
            Name = "Regolarità Fiscale";
            EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("anagraficadetail");
            ListingTypes.Add("anagraficadetail");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "regolarità fiscale";
                return MetaData.GetFormByDllName("registryregolaritafiscale_default");
            }
            if (FormName == "anagraficadetail") {
                Name = "regolarità fiscale";
                DefaultListType = "anagraficadetail";
                return MetaData.GetFormByDllName("registryregolaritafiscale_anagraficadetail");
            }
            return null;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "registryregolaritafiscaleview", ToMerge);
            }

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data scadenza", nPos++);

            }

            if (ListingType == "anagraficadetail") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idregistryregolaritafiscale", "#", nPos++);
                DescribeAColumn(T, "start", "Inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Scadenza", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if ((R["start"] != DBNull.Value) && (R["stop"] != DBNull.Value)) {
                DateTime start = (DateTime)R["start"];
                DateTime stop = (DateTime)R["stop"];
                if (start > stop) {
                    errmess = "Attenzione! Non può essere immessa una data inizio successiva alla data scadenza";
                    errfield = "start";
                    return false;
                }
            }
            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistryregolaritafiscale"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);

        }


    }



}
