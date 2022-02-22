
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;
                               
namespace meta_sisest_corsolaurea
{
    public class Meta_sisest_corsolaurea : Meta_easydata {
        public Meta_sisest_corsolaurea(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sisest_corsolaurea") {
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
    //    DefaultListType = "default";
        Name = "Sisest Corso Laurea";
        return MetaData.GetFormByDllName("sisest_corsolaurea_default");
    }
    return null;
}

public override void SetDefaults(DataTable PrimaryTable) {
    base.SetDefaults(PrimaryTable);
    //SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
}

public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
    //RowChange.SetMySelector(T.Columns["nsisest_corsolaurea"], "nphase", 0);  //campo nphase  è selettore per calcolo di nsisest_corsolaurea
    //RowChange.SetMySelector(T.Columns["nsisest_corsolaurea"], "ysisest_corsolaurea", 0);//campo ysisest_corsolaurea  è selettore per calcolo di nsisest_corsolaurea
    RowChange.MarkAsAutoincrement(T.Columns["idcorsolaurea"], null, null, 0);  //idcorsolaurea è campo ad autoincremento
    //RowChange.MarkAsAutoincrement(T.Columns["idsisest_corsolaurea"], null, null, 0);  //idsisest_corsolaurea è campo ad autoincremento

    //RowChange.setMinimumTempValue(T.Columns["idsisest_corsolaurea"], 999900000);     //Da impostare  in caso di pericolo di conflitto
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
            if (R["codicecorso"].ToString() == "") {
                errmess = "Attenzione! Inserire il codice corso.";
                errfield = "codicecorso";
                return false;
            }
            if (R["descrizione"].ToString() == "") {
                errmess = "Attenzione! Inserire la descrizione.";
                errfield = "descrizione";
                return false;
            }
            return true;
}

public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
    //if (ListingType == "lista")
    //    return base.SelectOne(ListingType, filter, "sisest_corsolaureaview", Exclude);
    //else
    return base.SelectOne(ListingType, filter, "sisest_corsolaurea", Exclude);
}


public override void DescribeColumns(DataTable T, string ListingType) {
    base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idcorsolaurea", "#", nPos++);
                DescribeAColumn(T, "descrizione", "Descrizione", nPos++);
                DescribeAColumn(T, "codicecorso", "Cod.Corso", nPos++);              

            }
        }
    }
}
