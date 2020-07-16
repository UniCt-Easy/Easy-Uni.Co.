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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_epupbkind {
    public class Meta_epupbkind : Meta_easydata {
        public Meta_epupbkind(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "epupbkind") {
			// listapermovbancario elenca in ordine di numero mandato filtrando solo l'esercizio corrente
			EditTypes.Add("default");			
			ListingTypes.Add("default");
			Name = "Tipo UPB nell'economico patrimoniale";
    
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") 
			{
                Name = "Tipo UPB nell'economico patrimoniale";
				DefaultListType="default";
                return MetaData.GetFormByDllName("epupbkind_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "flag", "1");
            //SetDefault(PrimaryTable, "adate", GetSys("datacontabile")); no         
        }

        //public override void DescribeColumns(DataTable T, string ListingType) {
        //    base.DescribeColumns(T, ListingType);
        //    if (ListingType == "default") {
        //        foreach (DataColumn C in T.Columns) {
        //            DescribeAColumn(T, C.ColumnName, "", -1);
        //        }
        //        int nPos = 1;

        //        DescribeAColumn(T, "idepupbkind", "#", nPos++);
        //        DescribeAColumn(T, "title", "Tipo", nPos++);
        //        DescribeAColumn(T, "active", "Attivo", nPos++);
        //        DescribeAColumn(T, "description", "Descrizione", nPos++);
        //    }
        //}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){            
            RowChange.MarkAsAutoincrement(T.Columns["idepupbkind"], null, null, 0);
			DataRow R = base.Get_New_Row(ParentRow, T);           
			return R;
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "epupbkindview", Exclude);
            }
            else
            {
                return base.SelectOne(ListingType, filter, "epupbkind", Exclude);
            }

        }
    }
}
