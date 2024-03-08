
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

namespace meta_showcase
{
    public class Meta_showcase: Meta_easydata
    {
        public Meta_showcase(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "showcase") 
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Vetrina";
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idshowcase"], null, null, 0);
            DataRow R=base.Get_New_Row(ParentRow, T);
            return R;

        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flagldapvisibility", 0);
            }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "showcaseview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        protected override Form GetForm(string FormName)
        {
            DefaultListType = "default";

            if (FormName == "default")
            {
                return MetaData.GetFormByDllName("showcase_default");
            }
            return null;
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (R["title"].ToString()=="")
            {
                errmess = "Il campo 'Nome' è obbligatorio";
                errfield = "title";
                return false;
            }

            if (R["description"].ToString() == "")
            {
                errmess = "Il campo 'Descrizione' è obbligatorio";
                errfield = "description";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idstore"]) == 0)
            {
                errmess = "Specificare un magazzino";
                errfield = "idstore";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["paymentexpiring"]) == 0) {
                errmess = "Il campo N. giorni scadenza è obbligatorio";
                errfield = "paymentexpiring";
                return false;
			}

            return true;
        }


        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);

            if (listtype == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int ncol;
                ncol = 1;

                DescribeAColumn(T, "showcasetitle", "Nome", ncol++);
                DescribeAColumn(T, "showcasedescription", "Descrizione",ncol++);
                DescribeAColumn(T, "storedescription", "Magazzino",  ncol++);
                DescribeAColumn(T, "deliveryaddress", "Indirizzo", ncol++);
            }
        }   
    }
}
