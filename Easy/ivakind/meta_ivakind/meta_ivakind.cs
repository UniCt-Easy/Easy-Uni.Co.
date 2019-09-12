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

using System;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//using tipoiva;

namespace meta_ivakind//meta_tipoiva//
{
	/// <summary>
	/// Summary description for tipooperazioneiva.
	/// </summary>
	public class Meta_ivakind : Meta_easydata {
		public Meta_ivakind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivakind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");

		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				Name="Elenco aliquote";
				DefaultListType="default";
				return GetFormByDllName("ivakind_default");
				//return new frmtipoiva();
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T, C.ColumnName,"", -1);
                int nPos = 1;
                DescribeAColumn(T, "idivakind", ".#", nPos++);
                DescribeAColumn(T, "codeivakind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "unabatabilitypercentage", "Indetraibilità", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["unabatabilitypercentage"], "p");
                DescribeAColumn(T, "rate", "Aliquota", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rate"], "p");


			}
		}
		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"active",true);
            SetDefault(PrimaryTable, "flag", 7);
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idivakind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idivakind");
            if (N < 9999000)
                R["idivakind"] = 9999001;
            else
                R["idivakind"] = N + 1;

            return R;
        }
    }
}
