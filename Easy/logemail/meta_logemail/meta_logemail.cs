
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_logemail//meta_logemail//
{
	/// <summary>
	/// Summary description for Meta_logemail
	/// </summary>
	public class Meta_logemail : Meta_easydata 
	{
		public Meta_logemail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "logemail") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Log delle Email inviate";
		}
					
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.MarkAsAutoincrement(T.Columns["id"],null,null, 0);
			return base.Get_New_Row(ParentRow, T);
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Form F = GetFormByDllName("logemail_default");
				return F;
			}
			
			return null;
		}		
	
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype == "default") {
				foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "sender", "Mittente", nPos++);
                DescribeAColumn(T, "receiver", "Destinatario", nPos++);
                DescribeAColumn(T, "sent", "Inviato", nPos++);
                DescribeAColumn(T, "subject", "Oggetto", nPos++);
                DescribeAColumn(T, "message", "Messaggio", nPos++);
				DescribeAColumn(T, "errorMessage", "Messaggio di errore", nPos++);
				DescribeAColumn(T, "allegato", "Allegato/i", nPos++);
				DescribeAColumn(T, "cc", "Cc", nPos++);
				DescribeAColumn(T, "bcc", "Bcc", nPos++);
				DescribeAColumn(T, "moduleContext", "Contesto", nPos++);
				DescribeAColumn(T, "lt", "Data e ora invio", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["lt"],"G");
			}	
		}  
	}
}
