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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;
                               
namespace meta_menuweb
{
    public class Meta_menuweb : Meta_easydata {
        public Meta_menuweb(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "menuweb") {
            //EditTypes.Add("default");
            //ListingTypes.Add("default");
        }

/// <summary>
/// Impostare la chiave, serve per le viste, non per le tabelle!!
/// </summary>
//private string[] mykey = new string[] { "campo chiave" /*,...campi chiave*/ };
//public override string[] primaryKey() {
//    return mykey;
//}

protected override Form GetForm(string FormName) {
    //if (FormName == "default") {
    //    DefaultListType = "default";
    //    Name = "Descrizione Form";
    //    return MetaData.GetFormByDllName("dummy_default");
    //}
    return null;
}

            string[] mykey = new string[] { "idmenuweb" };
            public override string[] primaryKey(){
             return mykey;
            }

            public override void SetDefaults(DataTable PrimaryTable) {
                base.SetDefaults(PrimaryTable);
                //PrimaryTable.setDefault("ayear", GetSys("esercizio"));
            }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idmenuweb"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idmenuweb"], 9999);

            string idmenuwebparent;
            if (ParentRow != null){
                idmenuwebparent = ParentRow["idmenuweb"].ToString();
                SetDefault(T, "idmenuwebparent", idmenuwebparent);
            }

            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

/// <summary>
/// FilterRow, si usa per i grid filtrati
/// </summary>
/// <param name="R"></param>
/// <param name="list_type"></param>
/// <returns></returns>
public override bool FilterRow(DataRow R, string list_type) {
    //if (list_type == "form_contenitore") {
    //    if (R["chiave contenitore"] == DBNull.Value) return false;
    //    return true;
    //}

    return true;
}

public override bool IsValid(DataRow R, out string errmess, out string errfield) {
    if (!base.IsValid(R, out errmess, out errfield)) return false;
    //if (condizione di errore) {
    //    errmess = "Messaggio di errore";
    //    errfield = "Nome campo su cui posizionare il focus";
    //    return false;
    //}


    return true;
}

public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
    //if (ListingType == "lista")
    //    return base.SelectOne(ListingType, filter, "dummyview", Exclude);
    //else
    return base.SelectOne(ListingType, filter, "dummy", Exclude);
}


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
