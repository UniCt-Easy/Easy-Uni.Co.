
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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using metadatalibrary;
using System.Text;
using funzioni_configurazione;
using System.Globalization;


namespace exporthelper
{
    public class GetAssetDetails : IExportHelper
    {
        public DataTable Execute(DataAccess DA, Hashtable H)
        {
            CQueryHelper QHC;
            QueryHelper QHS;
            QHC = new CQueryHelper();
            QHS = DA.GetQueryHelper();

            Hashtable H1 = new Hashtable();

            DataTable MultifieldKind = DA.RUN_SELECT("multifieldkind", "fieldname, fieldcode, systype, len", null, null, null, false);

            DataTable Asset = new DataTable();
            DataColumn kind = new DataColumn("kind", typeof(System.String)); kind.Caption = "Tipo";
            DataColumn idasset = new DataColumn("idasset", typeof(System.Int32)); idasset.Caption = "Id. Cespite";
            DataColumn idpiece = new DataColumn("idpiece", typeof(System.Int32)); idpiece.Caption = "# Accessorio";
            DataColumn description = new DataColumn("description", typeof(System.String)); description.Caption = "Inventario";
            DataColumn ninventory = new DataColumn("ninventory", typeof(System.Int32)); ninventory.Caption = "Num. inventario";
            DataColumn nassetacquire = new DataColumn("nassetacquire", typeof(System.Int32)); nassetacquire.Caption = "Num. Carico";
            DataColumn loaddescription = new DataColumn("loaddescription", typeof(System.String)); loaddescription.Caption = "Descr. Carico";
            DataColumn start = new DataColumn("start", typeof(System.Decimal)); start.Caption = "Val.orig.";
            DataColumn revals = new DataColumn("revals", typeof(System.Decimal)); revals.Caption = "Ammortamenti e rivalutazioni";
            DataColumn subtractions = new DataColumn("subtractions", typeof(System.Decimal)); subtractions.Caption = "Scarichi accessori posseduti";
            DataColumn currentvalue = new DataColumn("currentvalue", typeof(System.Decimal)); currentvalue.Caption = "Val. Corrente";
            DataColumn is_loaded = new DataColumn("is_loaded", typeof(System.String)); is_loaded.Caption = "Caricato";
            DataColumn is_unloaded = new DataColumn("is_unloaded", typeof(System.String)); is_unloaded.Caption = "Scaricato";

            DataColumn codeassetloadkind = new DataColumn("codeassetloadkind", typeof(System.String)); codeassetloadkind.Caption = "Cod. Buono Carico";
            DataColumn codeassetunloadkind = new DataColumn("codeassetunloadkind", typeof(System.String)); codeassetunloadkind.Caption = "Cod. Buono Scarico";

            DataColumn manager = new DataColumn("manager", typeof(System.String)); manager.Caption = "Responsabile";
            DataColumn location = new DataColumn("location", typeof(System.String)); location.Caption = "Ubicazione";

            DataColumn yassetload = new DataColumn("yassetload", typeof(System.Int32)); yassetload.Caption = "Eserc. Buono carico";
            DataColumn nassetload = new DataColumn("nassetload", typeof(System.Int32)); nassetload.Caption = "Num. Buono carico";
            DataColumn yassetunload = new DataColumn("yassetunload", typeof(System.Int32)); yassetunload.Caption = "Eserc. Buono scarico";
            DataColumn nassetunload = new DataColumn("nassetunload", typeof(System.Int32)); nassetunload.Caption = "Num. Buono scarico";

            DataColumn codeinv = new DataColumn("codeinv", typeof(System.String)); codeinv.Caption = "Cod. Classificazione";
            DataColumn inventorytree = new DataColumn("inventorytree", typeof(System.String)); inventorytree.Caption = "Classificazione";
            DataColumn codeinv_lev1 = new DataColumn("codeinv_lev1", typeof(System.String)); codeinv_lev1.Caption = "Cod. Categoria";
            DataColumn inventorytree_lev1 = new DataColumn("inventorytree_lev1", typeof(System.String)); inventorytree_lev1.Caption = "Categoria";

            Asset.Columns.Add(kind);
            Asset.Columns.Add(idasset);
            Asset.Columns.Add(idpiece);
            Asset.Columns.Add(description);
            Asset.Columns.Add(ninventory);
            Asset.Columns.Add(nassetacquire);
            Asset.Columns.Add(loaddescription);
            Asset.Columns.Add(codeinv);
            Asset.Columns.Add(inventorytree);
            Asset.Columns.Add(codeinv_lev1);
            Asset.Columns.Add(inventorytree_lev1);
            Asset.Columns.Add(start);
            Asset.Columns.Add(revals);
            Asset.Columns.Add(subtractions);
            Asset.Columns.Add(currentvalue);
            Asset.Columns.Add(is_loaded);
            Asset.Columns.Add(is_unloaded);
            Asset.Columns.Add(manager);
            Asset.Columns.Add(location);
            Asset.Columns.Add(codeassetloadkind);
            Asset.Columns.Add(yassetload);
            Asset.Columns.Add(nassetload);
            Asset.Columns.Add(codeassetunloadkind);
            Asset.Columns.Add(yassetunload);
            Asset.Columns.Add(nassetunload);

            foreach (DataRow R in MultifieldKind.Rows)
            {
                string type = R["systype"].ToString();
                int len = CfgFn.GetNoNullInt32(R["len"]);
                DataColumn field = null;
                switch (type.ToLower())
                {
                    case "int":
                        field = new DataColumn(R["fieldcode"].ToString(), typeof(System.Int32));
                        break;
                    case "string":
                        field = new DataColumn(R["fieldcode"].ToString(), typeof(System.String));
                        break;
                    case "date":
                        field = new DataColumn(R["fieldcode"].ToString(), typeof(System.DateTime));
                        break;
                    case "double":
                        field = new DataColumn(R["fieldcode"].ToString(), typeof(System.Double));
                        break;
                    case "decimal":
                        field = new DataColumn(R["fieldcode"].ToString(), typeof(System.Decimal));
                        break;
                    default: 
                         field = new DataColumn(R["fieldcode"].ToString(), typeof(System.String));
                        break;
                }
                Asset.Columns.Add(field);
                field.Caption = R["fieldname"].ToString();
                H1[R["fieldcode"]] = R["fieldname"];

            }

            string filtroCespite = null;
            if (H["idinventory"]!=DBNull.Value) filtroCespite= QHS.CmpEq("assetacquire.idinventory", H["idinventory"]) ;

            if (H["fromninv"] != DBNull.Value) filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpGe("asset.ninventory", H["fromninv"]));
            if (H["toninv"] != DBNull.Value) filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpLe("asset.ninventory", H["toninv"]));

            switch (H["loaded"].ToString())
            {
                case "S":
                    filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpEq("AC.is_loaded", "S"));
                    break;
                case "N":
                    filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpEq("AC.is_loaded", "N"));
                    break;
                default:
                    break;
            }
            switch (H["unloaded"].ToString())
            {
                case "S":
                    filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpEq("AC.is_unloaded", "S"));
                    break;
                case "N":
                    filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpEq("AC.is_unloaded", "N"));
                    break;
                default:
                    break;
            }


            string parteWhere = (filtroCespite == null) ? "" : (" WHERE " + filtroCespite);
            DataTable T;
            // Elenco Cespiti
            string queryT = " SELECT CASE asset.idpiece WHEN 1 THEN 'Cespite Principale' ELSE 'Accessorio' END AS kind, " + 
                            " asset.idasset, " +
                            " asset.idpiece,  " +
                            " asset.lifestart , " +
                            " inventory.description, " +
                            " asset.ninventory, " +
                            " asset.nassetacquire, " +
                            " assetacquire.description as loaddescription, " +
                            " AV.codeinv as codeinv, " +
                            " AV.inventorytree as inventorytree, " +
                            " AV.codeinv_lev1 as codeinv_lev1, " +
                            " AV.inventorytree_lev1 as inventorytree_lev1, " +
                            " AC.start ," +
                            " AC.revals ," +
                            " AC.subtractions ," +
                            " AC.currentvalue ," +
                            " AC.is_loaded ," +
                            " AC.is_unloaded ," +
                            " assetloadkind.codeassetloadkind, " +
                            " assetload.yassetload, " +
                            " assetload.nassetload, " +
                            " assetunloadkind.codeassetunloadkind, " +
                            " assetunload.yassetunload, " +
                            " assetunload.nassetunload ," +
                            " R.title as manager, " +
                            " U.description as location, " +
                            " asset.multifield " +
                            " FROM asset " +
                            " JOIN assetacquire on assetacquire.nassetacquire = asset.nassetacquire " +
                            " JOIN inventory on assetacquire.idinventory = inventory.idinventory " +
                            " left outer join manager R ON R.idman = (select top 1 idman from assetmanager where idasset=asset.idasset and start is null) " +
                            " LEFT OUTER JOIN location U ON U.idlocation = (select top 1 idlocation from assetlocation where idasset = asset.idasset and start is null) " +
                            " left outer join assetload on assetload.idassetload = assetacquire.idassetload " +
                            " left outer join assetloadkind on assetloadkind.idassetloadkind = assetload.idassetloadkind " +
                            " left outer join assetunload on assetunload.idassetunload = asset.idassetunload " +
                            " left outer join assetunloadkind on assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind " +
                            " left join assetview_current AC on AC.idasset = asset.idasset and AC.idpiece = asset.idpiece " +
                            " left join assetview AV on AV.idasset = asset.idasset and AV.idpiece = asset.idpiece " +
                            parteWhere;
            T = DA.SQLRunner(queryT);
            foreach (DataRow R in T.Rows)
            {
                DataRow NewAsset = Asset.NewRow();

                foreach (DataColumn C in T.Columns)
                {
                    if ((C.ColumnName != "multifield") && (Asset.Columns.Contains(C.ColumnName)))
                        NewAsset[C.ColumnName] = R[C.ColumnName];
                }
                if (R["multifield"] != DBNull.Value)
                {
                    string value = R["multifield"].ToString();

                    string[] allmf = value.Split(new char[] { '§' });
                    foreach (string coppia in allmf)
                    {
                        if (coppia == "") continue;
                        string[] cc = coppia.Split(new char[] { '|' });
                        string code = cc[0].ToLower();
                        string val = cc[1];

                        if (Asset.Columns.Contains(code))
                        {
                            if (Asset.Columns[code].DataType == typeof(System.Double)) {
                                NewAsset[code] = GetDouble(val);
                                continue;
                            }
                            if (Asset.Columns[code].DataType == typeof(System.Decimal)) {
                                NewAsset[code] = GetCurrency(val);
                                continue;
                            }
                            NewAsset[code] = val;
                        }
                    }
                }
                Asset.Rows.Add(NewAsset);
            }

            // Output

            return Asset;
        }

        object GetDouble(string num) {
            string dec =CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator; //,
            string grp = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;  //.
            num = num.Trim(); // 45.90
            try {
                object d = Double.Parse(num); //4590
                string num1 = num;
                //if (num1.IndexOf(dec) >= 0) num1 = num1.TrimEnd('0');

                if (d.ToString() == num1) return num;
                string num2 = num1.Replace(dec, "&").Replace(grp, dec).Replace("&", grp); //45,90
                if (num2.IndexOf(dec) >= 0) {
                    num2 = num2.TrimEnd('0');
                    if (num2.EndsWith(dec)) {
                        num2 = num2.Substring(0, num2.Length - 1);
                    }

                }
                object d2 = Double.Parse(num2);
                if (d2.ToString() == num2) return num2;
                return num;
            }
            catch {
                return DBNull.Value;
            }           
        }

        object GetCurrency(string num) {
            string dec = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            string grp = CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
            num = num.Trim();
            try {
                object d = Double.Parse(num);
                string num1 = num;
                //if (num1.IndexOf(dec) >= 0) num1 = num1.TrimEnd('0');

                if (d.ToString() == num) return num;
                string num2 = num1.Replace(dec, "&").Replace(grp, dec).Replace("&", grp);
                if (num2.IndexOf(dec) >= 0) {
                    num2 = num2.TrimEnd('0');
                    if (num2.EndsWith(dec)) {
                        num2 = num2.Substring(0, num2.Length - 1);
                    }
                } 
                object d2 = Double.Parse(num2);
                if (d2.ToString() == num2) return num2;
                return num;
            }
            catch {
                return DBNull.Value;
            }
        }



    }
}
