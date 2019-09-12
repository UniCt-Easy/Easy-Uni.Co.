/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
                               
namespace meta_customindirectrelcol
{
    public class Meta_customindirectrelcol : Meta_easydata {
        public Meta_customindirectrelcol(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "customindirectrelcol") {
            EditTypes.Add("single");
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
                Name = "Customindirectrelcol";
                return MetaData.GetFormByDllName("customindirectrelcol_single");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
    base.SetDefaults(PrimaryTable);
    //SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
}

public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
    //RowChange.SetMySelector(T.Columns["ncustomindirectrelcol"], "nphase", 0);  //campo nphase  è selettore per calcolo di ncustomindirectrelcol
    //RowChange.SetMySelector(T.Columns["ncustomindirectrelcol"], "ycustomindirectrelcol", 0);//campo ycustomindirectrelcol  è selettore per calcolo di ncustomindirectrelcol
    //RowChange.MarkAsAutoincrement(T.Columns["ncustomindirectrelcol"], null, null, 0);  //ncustomindirectrelcol è campo ad autoincremento
    //RowChange.MarkAsAutoincrement(T.Columns["idcustomindirectrelcol"], null, null, 0);  //idcustomindirectrelcol è campo ad autoincremento

    //RowChange.setMinimumTempValue(T.Columns["idcustomindirectrelcol"], 999900000);     //Da impostare  in caso di pericolo di conflitto
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
            if (R["parentfield"] == DBNull.Value) {
                errmess = "Inserire il parentfield";
                errfield = "parentfield";
                return false;
            }
            if (R["middlefield"] == DBNull.Value) {
                errmess = "Inserire il middlefield";
                errfield = "middlefield";
                return false;
            }


            return true;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
    //if (ListingType == "lista")
    //    return base.SelectOne(ListingType, filter, "customindirectrelcolview", Exclude);
    //else
    return base.SelectOne(ListingType, filter, "customindirectrelcol", Exclude);
}


public override void DescribeColumns(DataTable T, string ListingType) {
    base.DescribeColumns(T, ListingType);

            switch (ListingType) {
            case "single": {
                    foreach (DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                    int nPos = 1;
                    DescribeAColumn(T, "middlefield", "Colonna centrale", nPos++);
                    DescribeAColumn(T, "parentfield", "Colonna padre", nPos++);
                    DescribeAColumn(T, "parentnumber", "Numero padre", nPos++);
                    break;
                }
            }
        }
    }
}
