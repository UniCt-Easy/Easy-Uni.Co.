
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
                               
namespace meta_customindirectrel
{
    public class Meta_customindirectrel : Meta_easydata {
        public Meta_customindirectrel(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "customindirectrel") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

/// <summary>
/// Impostare la chiave, serve per le viste, non per le tabelle!!
/// </summary>
//private string[] mykey = new string[] { "campo chiave" /*,...campi chiave*/ };
//public override string[] primaryKey() {
//    return mykey;
//}

protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Relazioni indirette tra Form";
                return MetaData.GetFormByDllName("customindirectrel_default");
            }
            return null;
}

public override void SetDefaults(DataTable PrimaryTable) {
    base.SetDefaults(PrimaryTable);
    //SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
}

public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            //RowChange.SetMySelector(T.Columns["ncustomindirectrel"], "nphase", 0);  //campo nphase  è selettore per calcolo di ncustomindirectrel
            //RowChange.SetMySelector(T.Columns["ncustomindirectrel"], "ycustomindirectrel", 0);//campo ycustomindirectrel  è selettore per calcolo di ncustomindirectrel
            //RowChange.MarkAsAutoincrement(T.Columns["ncustomindirectrel"], null, null, 0);  //ncustomindirectrel è campo ad autoincremento
            //RowChange.MarkAsAutoincrement(T.Columns["idcustomindirectrel"], null, null, 0);  //idcustomindirectrel è campo ad autoincremento
            T.setAutoincrement("idcustomindirectrel", null, null, 0);
            T.setMinimumTempValue("idcustomindirectrel", 999900000);
            //RowChange.setMinimumTempValue(T.Columns["idcustomindirectrel"], 999900000);     //Da impostare  in caso di pericolo di conflitto
            DataRow R = base.Get_New_Row(ParentRow, T);
    return R;
}

        ///// <summary>
        ///// FilterRow, si usa per i grid filtrati
        ///// </summary>
        ///// <param name="R"></param>
        ///// <param name="list_type"></param>
        ///// <returns></returns>
        //public override bool FilterRow(DataRow R, string list_type) {
        //    //if (list_type == "form_contenitore") {
        //    //    if (R["chiave contenitore"] == DBNull.Value) return false;
        //    //    return true;
        //    //}

        //    return true;
        //}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["description"]==DBNull.Value) {
                errmess = "Inserire la descrizione";
                errfield = "description";
                return false;
            }
            if (R["edittype"] == DBNull.Value) {
                errmess = "Inserire l'edittype";
                errfield = "edittype";
                return false;
            }
            if (R["middletable"] == DBNull.Value) {
                errmess = "Inserire la middletable";
                errfield = "middletable";
                return false;
            }
            if (R["parenttable1"] == DBNull.Value) {
                errmess = "Inserire la parenttable1";
                errfield = "parenttable1";
                return false;
            }

            if (R["parenttable2"] == DBNull.Value) {
                errmess = "Inserire la parenttable2";
                errfield = "parenttable2";
                return false;
            }

            return true;
        }

        //public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
        //    //if (ListingType == "lista")
        //    //    return base.SelectOne(ListingType, filter, "customindirectrelview", Exclude);
        //    //else
        //    return base.SelectOne(ListingType, filter, "customindirectrel", Exclude);
        //}


        public override void DescribeColumns(DataTable T, string ListingType) {
    base.DescribeColumns(T, ListingType);

    //switch (ListingType) {
    //    case "default": {
    //            foreach (DataColumn C in T.Columns) {
    //                DescribeAColumn(T, C.ColumnName, "", -1);
    //            }
    //            int nPos = 1;
    //            DescribeAColumn(T, "nomecampo", "caption", nPos++);
    //            break;
    //        }
    //}
}
    }
}
