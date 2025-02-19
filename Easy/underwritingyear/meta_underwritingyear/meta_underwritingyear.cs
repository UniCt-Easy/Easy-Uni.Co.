
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_underwritingyear
{
    /// <summary>
    /// Summary description for meta_underwritingyear.
    /// </summary>
    public class Meta_underwritingyear : Meta_easydata
    {
        public Meta_underwritingyear(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "underwritingyear")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }



        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", Conn.GetSys("esercizio"));
        }


        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            if (edit_type == "default"){
                if (ParentRow != null){
                    SetDefault(T, "idunderwriting", ParentRow["idunderwriting"]);
                }
            }
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


    }

}

