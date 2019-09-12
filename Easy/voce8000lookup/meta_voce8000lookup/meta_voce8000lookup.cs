/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_voce8000lookup {

    public class Meta_voce8000lookup : Meta_easydata {
        public Meta_voce8000lookup(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "voce8000lookup") {
            Name = "Lookup Voci di Comunicazione 8000";
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Associazione voce 8000 - Imposta";
                return MetaData.GetFormByDllName("voce8000lookup_default");

            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idvoce"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield) {


            if ((R["conto"].ToString() == "")&&(R["taxcode"]!=DBNull.Value)) {
                errfield = "conto";
                errmess = "E' necessario scegliere il tipo applicazione della ritenuta";
                return false;
            }


            if (!base.IsValid(R, out errmess, out errfield))
                return false;

            return true;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
            int nPos = 1;
            DescribeAColumn(T, ".idvoce", "#", nPos++);
            DescribeAColumn(T, "conto", "Applicazione ", nPos++);
            DescribeAColumn(T, "servicekind", "Tipo compenso", nPos++);
            DescribeAColumn(T, "taxref", "Cod.Ritenuta", nPos++);
            DescribeAColumn(T, "voce", "Voce8000", nPos++);
            DescribeAColumn(T, "voceimponibile", "Voce Imponibile", nPos++);
            DescribeAColumn(T, "vocequotaesente", "Voce Quota esente", nPos++);
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            return base.SelectOne(ListingType, filter, "voce8000lookupview", Exclude);

        }
    }


}


