
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//Pino: using registroiva; diventato inutile

namespace meta_ivaregister//meta_registroiva//
{
	/// <summary>
	/// Summary description for Meta_registroiva.
	/// </summary>
	public class Meta_ivaregister : Meta_easydata {

		public Meta_ivaregister(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivaregister") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Registro";
				this.CanCancel=false;
				this.CanInsert=false;
				this.CanInsertCopy=false;
				this.CanSave=false;
				return MetaData.GetFormByDllName("ivaregister_default");//PinoRana
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"yivaregister", Conn.GetEsercizio());
		}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"yivaregister");
			RowChange.SetSelector(T,"idivaregisterkind");
			RowChange.MarkAsAutoincrement(T.Columns["nivaregister"],null,null,6);
			RowChange.MarkAsAutoincrement(T.Columns["protocolnum"],null,null,6);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			if (ListingType=="protocollo"){
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 1;
				DescribeAColumn(T,"idivaregisterkind","Codice Registro",nPos++);
				DescribeAColumn(T,"!registerkind","Registro".PadLeft(50),"ivaregisterkind.description",nPos++);
                DescribeAColumn(T, "yivaregister", "Es. Protocollo", nPos++);
				DescribeAColumn(T,"protocolnum","Num. Protocollo",nPos++);
			}
		}


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType=="default")
				return base.SelectOne (ListingType, filter, "ivaregisterview", ToMerge);
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

	}
}
