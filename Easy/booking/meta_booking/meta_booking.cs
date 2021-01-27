
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
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_booking
{
    public class Meta_booking:Meta_easydata
    {
        public Meta_booking(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "booking")
        {
            Name = "Prenotazione";
            EditTypes.Add("default");
            ListingTypes.Add("list");

        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["idbooking"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["nbooking"], null, null, 0);
            RowChange.SetMySelector(T.Columns["nbooking"], "ybooking", 0);
            DataRow R= base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idman"]) == 0)
            {
                errmess = "Il campo 'Responsabile' è obbligatorio";
                errfield = "idman";
                return false;
            }
            return true;
        }


        public override string GetSorting(string ListingType)
        {
            string sorting;
            if (ListingType == "list")
            {
                sorting = "ybooking desc,nbooking desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ybooking", GetSys("esercizio"));
        }


        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "list")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "ybooking", "Anno",  nPos++);
                DescribeAColumn(T, "nbooking", "Numero", nPos++);
                DescribeAColumn(T, "!manager", "Responsabile", "manager.title", nPos++);


            }
        }
    }
}
