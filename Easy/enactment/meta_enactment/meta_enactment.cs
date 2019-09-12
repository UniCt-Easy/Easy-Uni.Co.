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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_enactment
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_enactment : Meta_easydata {
		public Meta_enactment(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "enactment") {
			// listapermovbancario elenca in ordine di numero mandato filtrando solo l'esercizio corrente
			EditTypes.Add("default");			
			ListingTypes.Add("default");
			Name = "Atto Amministrativo";
    
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") 
			{
				Name = "Atto Amministrativo";
				DefaultListType="default";
				return MetaData.GetFormByDllName("enactment_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yenactment", GetSys("esercizio").ToString());
			//SetDefault(PrimaryTable, "adate", GetSys("datacontabile")); no
            SetDefault(PrimaryTable, "idenactmentstatus", 1);
		}

        protected override void InsertCopyColumn (DataColumn C, DataRow Source, DataRow Dest) {
            if ((C.ColumnName == "nofficial") || (C.ColumnName == "idenactmentstatus")) return;
            base.InsertCopyColumn(C, Source, Dest);
        }

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.ClearMySelector(T, "yenactment");
            RowChange.MarkAsAutoincrement(T.Columns["idenactment"], null, null, 0);
			RowChange.MarkAsAutoincrement(T.Columns["nenactment"],null, null,0);
            RowChange.SetMySelector(T.Columns["nenactment"], "yenactment", 0);
			DataRow R = base.Get_New_Row(ParentRow, T);
			int N = MetaData.MaxFromColumn(T,"nenactment");
			if (N<9999000)
                R["nenactment"] = 9999001;
			else
                R["nenactment"] = N + 1;

            int K = MetaData.MaxFromColumn(T, "idenactment");
            if (K < 9999000)
                R["idenactment"] = 9999001;
            else
                R["idenactment"] = K + 1;
           
			return R;
		}


		public override void DescribeColumns(DataTable T, string ListingType) {			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
				}
                int nPos = 1;

                DescribeAColumn(T, "yenactment", "Eserc.", nPos++);
                DescribeAColumn(T, "nenactment", "Numero", nPos++);
                DescribeAColumn(T, "nofficial", "Numero ufficiale", nPos++);
                DescribeAColumn(T, "adate", "Data emiss.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
		}
	}
}
