
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_profrefund//meta_tipospesaprof//
{
	/// <summary>
	/// Summary description for Meta_tipospesaprof.
	/// </summary>
	public class Meta_profrefund : Meta_easydata
	{
		public Meta_profrefund(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "profrefund")
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flagfiscaldeduction", "N");
            SetDefault(PrimaryTable, "flagsecuritydeduction", "N");
            SetDefault(PrimaryTable, "flagivadeduction", "S");
            SetDefault(PrimaryTable, "active", "N");
        }

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default"){
				Name = "Tipo Spesa";
				return GetFormByDllName("profrefund_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idlinkedrefund", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "flagfiscaldeduction", "Non Impon. Fiscalmente", nPos++);
                DescribeAColumn(T, "flagsecuritydeduction", "Non Impon. Previdenz.", nPos++);
                DescribeAColumn(T, "flagivadeduction", "Non Impon. IVA", nPos++);

			}
		}
	}
}
