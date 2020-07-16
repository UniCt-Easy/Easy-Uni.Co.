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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_listclassyear
{
    /// <summary>
    /// Summary description for Meta_listclassyear.
    /// </summary>
    public class Meta_listclassyear : Meta_easydata {
        public Meta_listclassyear(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "listclass"){
            Name = "Classificazione Merceologica";
            ListingTypes.Add("default");

        }

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idintrastatcode"]) != 0)
            {
                string code = Conn.DO_READ_VALUE("intrastatcode", QHS.CmpEq("idintrastatcode", R["idintrastatcode"]), "code").ToString();
                if ((code.Length) < 8)
                {
                    errmess = "E' necessario scegliere un codice di nomenclatura di 8 caratteri";
                    return false;
                }
            }
            return true;
        }
    }
}