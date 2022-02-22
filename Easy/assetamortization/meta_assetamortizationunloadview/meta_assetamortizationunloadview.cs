
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
using metadatalibrary;
using metaeasylibrary;


namespace meta_assetamortizationunloadview
{
    /// <summary>
    /// Summary description for rivalutazionebeneview.
    /// </summary>
    public class Meta_assetamortizationunloadview : Meta_easydata
    {
        public Meta_assetamortizationunloadview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "assetamortizationunloadview")
        {
            ListingTypes.Add("default");
            ListingTypes.Add("buonoscarico");
            ListingTypes.Add("buonocarico");
            Name = "Rivalutazioni/Svalutazione Cespiti";
        }
        public override bool FilterRow(DataRow R, string list_type)
        {
            if (list_type == "buonoscarico")
            {
                if (R["idassetunload"] == DBNull.Value) return false;
                return true;
            }
            if (list_type == "buonocarico")
            {
                if (R["idassetload"] == DBNull.Value) return false;
                return true;
            }
            return true;
        }

        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "namortization", "Num. riv.", nPos++);
                DescribeAColumn(T, "idasset", "Num. Cespite", nPos++);
                DescribeAColumn(T, "codeinventoryamortization", "", nPos++);
                DescribeAColumn(T, "inventoryamortization", "Tipo rival./Sval.", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inv.", nPos++);
                //DescribeAColumn(T, "assetunloadkind", "Tipo Buono Scarico", nPos++);
                //DescribeAColumn(T, "yassetunload", "Eserc. Buono Scarico", nPos++);
                //DescribeAColumn(T, "nassetunload", "Num. Buono Scarico", nPos++);
                DescribeAColumn(T, "loaddescription", "Descr. cespite inv.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "currlocationcode", "Codice ubicazione", nPos++);
                DescribeAColumn(T, "currlocation", "Ubicazione", nPos++);
                DescribeAColumn(T, "currmanager", "Responsabile", nPos++);
                DescribeAColumn(T, "assetvalue", "Valore cespite", nPos++);
                DescribeAColumn(T, "amortizationquota", "Quota rival./sval.", nPos++);
                DescribeAColumn(T, "amount", "Importo riv./sv.", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["amortizationquota"], "p4");

            }
            if (listtype == "buonoscarico")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                //DescribeAColumn(T, "namortization", "Num. riv.", nPos++);
                //DescribeAColumn(T, "inventoryamortization", "Tipo rival./Sval.", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inv.", nPos++);
                //DescribeAColumn(T, "assetunloadkind", "Tipo Buono Scarico", nPos++);
                //DescribeAColumn(T, "yassetunload", "Eserc. Buono Scarico", nPos++);
                //DescribeAColumn(T, "nassetunload", "Num. Buono Scarico", nPos++);
                DescribeAColumn(T, "loaddescription", "Cespite", nPos++);
                //DescribeAColumn(T, "description", "Descrizione", nPos++);
                //DescribeAColumn(T, "currlocationcode", "Codice ubicazione", nPos++);
                //DescribeAColumn(T, "currlocation", "Ubicazione", nPos++);
                //DescribeAColumn(T, "currmanager", "Responsabile", nPos++);
                DescribeAColumn(T, "assetvalue", "Valore cespite", nPos++);
                DescribeAColumn(T, "amortizationquota", "Quota rival./sval.", nPos++);
                DescribeAColumn(T, "amount", "Importo riv./sv.", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["amortizationquota"], "p");
                FilterRows(T);
            }
            if (listtype == "buonocarico")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                //DescribeAColumn(T, "namortization", "Num. riv.", nPos++);
                //DescribeAColumn(T, "inventoryamortization", "Tipo rival./Sval.", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inv.", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                //DescribeAColumn(T, "assetunloadkind", "Tipo Buono Scarico", nPos++);
                //DescribeAColumn(T, "yassetunload", "Eserc. Buono Scarico", nPos++);
                //DescribeAColumn(T, "nassetunload", "Num. Buono Scarico", nPos++);
                DescribeAColumn(T, "loaddescription", "Cespite", nPos++);
                //DescribeAColumn(T, "description", "Descrizione", nPos++);
                //DescribeAColumn(T, "currlocationcode", "Codice ubicazione", nPos++);
                //DescribeAColumn(T, "currlocation", "Ubicazione", nPos++);
                //DescribeAColumn(T, "currmanager", "Responsabile", nPos++);
                DescribeAColumn(T, "assetvalue", "Valore cespite", nPos++);
                DescribeAColumn(T, "amortizationquota", "Quota rival./sval.", nPos++);
                DescribeAColumn(T, "amount", "Importo riv./sv.", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["amortizationquota"], "p");
                FilterRows(T);
            }
            if (listtype == "buonoscaricoautomatico") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "idasset", ".idasset", nPos++);
                DescribeAColumn(T, "idpiece", "Num. parte", nPos++);
                DescribeAColumn(T, "inventorykind", "Tipo inventario", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Num. inventario", nPos++);
                DescribeAColumn(T, "loaddescription", "Cespite", nPos++);

                DescribeAColumn(T, "assetvalue", "Valore cespite", nPos++);
                DescribeAColumn(T, "amortizationquota", "Quota rival./sval.", nPos++);
                DescribeAColumn(T, "amount", "Importo riv./sv.", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["amortizationquota"], "p");
                FilterRows(T);
            }
        }

    }
}
