/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_payrolltaxcorrige {
    public class Meta_payrolltaxcorrige : Meta_easydata {
        public Meta_payrolltaxcorrige(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrolltaxcorrige") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default":
                    Name = "Storni Cedolino";
                    DefaultListType = "default";
                    return MetaData.GetFormByDllName("payrolltaxcorrige_default");
                case "readonly":
                    Name = "Storni Cedolino";
                    DefaultListType = "default";
                    return MetaData.GetFormByDllName("payrolltaxcorrige_default");
                default: return null;
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idpayroll");
            RowChange.MarkAsAutoincrement(T.Columns["idpayrolltaxcorrige"], null, null, 0, false);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                int n = 1;
                DescribeAColumn(T, "idpayroll", "Cedolino", n++);
                DescribeAColumn(T, "idpayrolltaxcorrige", "#", n++);
                DescribeAColumn(T, "taxref", "Cod. Ritenuta", "tax.taxref", n++);
                DescribeAColumn(T, "!descrritenuta", "Descr. Ritenuta", "tax.description", n++);
                DescribeAColumn(T, "taxablenet", "Imponibile Netto", n++);
                DescribeAColumn(T, "!ente", "Ente Locale", n++);
                DescribeAColumn(T, "employamount", "Importo Rit. c/Dip. Netto", n++);
                DescribeAColumn(T, "adminamount", "Importo Rit. c/Ammin. Netto", n++);
                ComputeRowsAs(T, ListingType);
            }
        }

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (!R.Table.Columns.Contains("!ente")) return;
            object taxCode = R["taxcode"];
            
            string f = QHS.CmpEq("taxcode", taxCode);
            object geo = Conn.DO_READ_VALUE("tax", f, "geoappliance");

            if ((geo == null) || (geo == DBNull.Value)) return;

            object idCity = R["idcity"];
            object idFiscalTaxRegion = R["idfiscaltaxregion"];

            string nomeEnte = "";
            switch(geo.ToString().ToUpper()) {
                case "C": {
                        if (idCity != DBNull.Value) {
                            nomeEnte = Conn.DO_READ_VALUE("geo_cityview", QHS.CmpEq("idcity", idCity), "title").ToString();
                        }
                    break;
                }
                case "P":{
                        if (idCity != DBNull.Value) {
                            nomeEnte = Conn.DO_READ_VALUE("geo_cityview", QHS.CmpEq("idcity", idCity), "country").ToString();
                        }
                    break;
                }
                case "R":{
                        if (idFiscalTaxRegion != DBNull.Value) {
                            nomeEnte = Conn.DO_READ_VALUE("fiscaltaxregion",
                                QHS.CmpEq("idfiscaltaxregion", idFiscalTaxRegion), "title").ToString();
                        }
                    break;
                }
            }

            R["!ente"] = nomeEnte;
        }
    }
}
