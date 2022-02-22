
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
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_lcardvar {
    public class Meta_lcardvar : Meta_easydata  {
        public Meta_lcardvar(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "lcardvar") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "ylvar", GetSys("esercizio"));
            if (Conn.GetUsr("email") != null) {
                SetDefault(PrimaryTable,"email", Conn.GetUsr("email"));
            }
            if (Conn.GetUsr("surname") != null) {
                SetDefault(PrimaryTable, "surname", Conn.GetUsr("surname"));
            }
            if (Conn.GetUsr("forename") != null) {
                SetDefault(PrimaryTable, "forename", Conn.GetUsr("forename"));
            }
            if (Conn.GetUsr("cf") != null) {
                SetDefault(PrimaryTable, "cf", Conn.GetUsr("cf"));
            }


        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetMySelector(T.Columns["nlvar"], "ylvar", 0);
            RowChange.MarkAsAutoincrement(T.Columns["nlvar"], null, null, 7);
            RowChange.MarkAsAutoincrement(T.Columns["idlcardvar"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["amount"] == DBNull.Value){
                errmess = "Attenzione! L'importo non può essere nullo.";
                errfield = "amount";
                return false;
            }


            return true;
        }

    }
}
