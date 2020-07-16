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
using System.Windows.Forms;
                               
namespace meta_customdirectrelcol
{
    public class Meta_customdirectrelcol : Meta_easydata {
        public Meta_customdirectrelcol(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "customdirectrelcol") {
            //EditTypes.Add("default");
            ListingTypes.Add("single");
        }

        /// <summary>
        /// Impostare la chiave, serve per le viste, non per le tabelle!!
        /// </summary>
        //private string[] mykey = new string[] { "campo chiave" /*,...campi chiave*/ };
        //public override string[] primaryKey() {
        //    return mykey;
        //}

        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                DefaultListType = "single";
                Name = "Customdirectrelcol";
                return MetaData.GetFormByDllName("customdirectrelcol_single");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
    base.SetDefaults(PrimaryTable);
    //SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
}

public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            //RowChange.SetMySelector(T.Columns["ncustomdirectrelcol"], "nphase", 0);  //campo nphase  è selettore per calcolo di ncustomdirectrelcol
            //RowChange.SetMySelector(T.Columns["ncustomdirectrelcol"], "ycustomdirectrelcol", 0);//campo ycustomdirectrelcol  è selettore per calcolo di ncustomdirectrelcol
            //RowChange.MarkAsAutoincrement(T.Columns["ncustomdirectrelcol"], null, null, 0);  //ncustomdirectrelcol è campo ad autoincremento
            //RowChange.MarkAsAutoincrement(T.Columns["idcustomdirectrelcol"], null, null, 0);  //idcustomdirectrelcol è campo ad autoincremento
            T.setSelector("idcustomdirectrel",0);
    //RowChange.setMinimumTempValue(T.Columns["idcustomdirectrelcol"], 999900000);     //Da impostare  in caso di pericolo di conflitto
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
    //    return base.SelectOne(ListingType, filter, "customdirectrelcolview", Exclude);
    //else
    return base.SelectOne(ListingType, filter, "customdirectrelcol", Exclude);
}


public override void DescribeColumns(DataTable T, string ListingType) {
    base.DescribeColumns(T, ListingType);

            switch (ListingType) {
            case "single": {
                    foreach (DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                    int nPos = 1;
                    DescribeAColumn(T, "fromfield", "Colonna di partenza", nPos++);
                    DescribeAColumn(T, "tofield", "Colonna di arrivo", nPos++);
                    break;
                }
            }
        }
    }
}
