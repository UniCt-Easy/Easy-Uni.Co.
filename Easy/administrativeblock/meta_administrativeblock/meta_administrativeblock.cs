
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
using funzioni_configurazione;

namespace meta_administrativeblock
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_administrativeblock : Meta_easydata {
        public Meta_administrativeblock(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "administrativeblock") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Fermo amministrativo";
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                return GetFormByDllName("administrativeblock_default");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idadministrativeblock", ".#", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "p_iva", "P.iva", nPos++);
                DescribeAColumn(T, "enactmentstart", "Provvedimento Inizio fermo", nPos++);
                DescribeAColumn(T, "start", "Inizio", nPos++);
                DescribeAColumn(T, "enactmentstop", "Provvedimento Fine fermo", nPos++);
                DescribeAColumn(T, "stop", "Fine", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            errfield = null;
            errmess = null;
            if ((R["start"] != DBNull.Value) && (R["stop"] != DBNull.Value)) {
                DateTime start = (DateTime)R["start"];
                DateTime stop = (DateTime)R["stop"];

                if (start > stop) {
                    errmess = "Attenzione! Non può essere immessa una data inizio successiva alla data fine";
                    errfield = "start";
                    return false;
                }
            }

            return base.IsValid(R, out errmess, out errfield);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idadministrativeblock"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idadministrativeblock");
            if (N < 9999000)
                R["idadministrativeblock"] = 9999001;
            else
                R["idadministrativeblock"] = N + 1;

            return R;
        }

    }
}
