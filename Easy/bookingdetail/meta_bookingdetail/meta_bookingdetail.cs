/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_bookingdetail
{
    public class Meta_bookingdetail:Meta_easydata
    {
        public Meta_bookingdetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "bookingdetail")
        {
            ListingTypes.Add("list");
            ListingTypes.Add("default");
            EditTypes.Add("single");
            EditTypes.Add("default");
            Name = "Dettaglio Prenotazione";
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

                DescribeAColumn(T, "!list", "Articolo","list.description", nPos++);
                DescribeAColumn(T, "number", "Quantit‡", nPos++);
                DescribeAColumn(T, "!store", "Magazzino", "store.description", nPos++);
            }
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "bookingdetailview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }


        protected override Form GetForm(string FormName)
        {
            DefaultListType = "default";
            if (FormName == "default") return MetaData.GetFormByDllName("bookingdetail_default");
            return null;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idlist"]) == 0)
            {
                errmess = "Il campo 'Articolo' Ë obbligatorio";
                errfield = "idlist";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["number"]) == 0)
            {
                errmess = "Il campo 'Quantit‡' Ë obbligatorio";
                errfield = "number";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["number"]) < 0)
            {
                errmess = "Il campo 'Quantit‡' dev'essere positivo";
                errfield = "number";
                return false;
            }
            return true;
        }
    
    }
}
