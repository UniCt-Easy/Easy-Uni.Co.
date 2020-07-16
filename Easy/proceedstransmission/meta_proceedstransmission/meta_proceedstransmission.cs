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

using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//using proceedstransmission_default;//trasmdocincasso
//Pino: using trasmdocincasso_gener_auto; diventato inutile

namespace meta_proceedstransmission//meta_trasmdocincasso//
{
	/// <summary>
	/// Summary description for Class1.
	/// Author: Leo, 11 Dec 2002, End 12 Dec 2002
	/// Updated: 13 Dec 2002
	/// </summary>
	public class Meta_proceedstransmission : Meta_easydata {
		public Meta_proceedstransmission(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceedstransmission") {
			EditTypes.Add("default");
			EditTypes.Add("generazioneautomatica");
			ListingTypes.Add("lista");   
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				DefaultListType="lista";
				Name = "Distinta di trasmissione";
				return MetaData.GetFormByDllName("proceedstransmission_default");//PinoRana
			}
			if (FormName=="generazioneautomatica")
			{
				Name = "Generazione automatica distinta di trasmissione";
				return MetaData.GetFormByDllName("proceedstransmission_generazioneautomatica");//PinoRana
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yproceedstransmission", GetSys("esercizio"));
			SetDefault(PrimaryTable, "transmissiondate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "transmissionkind", "I");
            SetDefault(PrimaryTable, "flagtransmissionenabled", "N");
            SetDefault(PrimaryTable, "noep", "N");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			/*RowChange.SetSelector(T, "yproceedstransmission");
			RowChange.MarkAsAutoincrement(T.Columns["nproceedstransmission"],null,
				null,7);
			DataRow R = base.Get_New_Row(ParentRow, T);
            R["nproceedstransmission"]=-1;*/
            RowChange.ClearMySelector(T, "yproceedstransmission");
            RowChange.MarkAsAutoincrement(T.Columns["kproceedstransmission"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["nproceedstransmission"], null, null, 0);
            RowChange.SetMySelector(T.Columns["nproceedstransmission"], "yproceedstransmission", 0);

            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "nproceedstransmission");
            if (N < 9999000)
                R["nproceedstransmission"] = 9999001;
            else
                R["nproceedstransmission"] = N + 1;

            int K = MetaData.MaxFromColumn(T, "kproceedstransmission");
            if (K < 9999000)
                R["kproceedstransmission"] = 9999001;
            else
                R["kproceedstransmission"] = K + 1;
			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="lista") 
				return base.SelectOne(ListingType, filter, "proceedstransmissionview", Exclude);
			return null;
		}

	}

}
