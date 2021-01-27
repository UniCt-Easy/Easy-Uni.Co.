
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;


//using paymenttransmission_default;//trasmdocpagamento
//using trasmdocpagamento_gener_auto; diventato inutile


namespace meta_paymenttransmission//meta_trasmdocpagamento//
{
	/// <summary>
	/// Summary description for Class1.
	/// Author: Leo, 12 Dec 2002, End 12 Dec 2002
	/// </summary>
	public class Meta_paymenttransmission : Meta_easydata {
		public Meta_paymenttransmission(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "paymenttransmission") {
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
				return MetaData.GetFormByDllName("paymenttransmission_default");//PinoRana
			}

			if (FormName=="generazioneautomatica") 
			{
				Name = "Generazione automatica distinta di trasmissione";
				return MetaData.GetFormByDllName("paymenttransmission_generazioneautomatica");//PinoRana
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ypaymenttransmission", GetSys("esercizio"));
			SetDefault(PrimaryTable, "transmissiondate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "flagmailsent", "N");
            SetDefault(PrimaryTable, "transmissionkind", "I");
            SetDefault(PrimaryTable, "flagtransmissionenabled", "N");
            SetDefault(PrimaryTable, "noep", "N");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			/*RowChange.SetSelector(T, "ypaymenttransmission");
			RowChange.MarkAsAutoincrement(T.Columns["npaymenttransmission"],null,
				null,7);
			DataRow R = base.Get_New_Row(ParentRow, T);
			R["npaymenttransmission"]=-1;
			return R;*/
            RowChange.ClearMySelector(T, "ypaymenttransmission");
            RowChange.MarkAsAutoincrement(T.Columns["kpaymenttransmission"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["npaymenttransmission"], null, null, 0);
            RowChange.SetMySelector(T.Columns["npaymenttransmission"], "ypaymenttransmission", 0);

            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "npaymenttransmission");
            if (N < 9999000)
                R["npaymenttransmission"] = 9999001;
            else
                R["npaymenttransmission"] = N + 1;

            int K = MetaData.MaxFromColumn(T, "kpaymenttransmission");
            if (K < 9999000)
                R["kpaymenttransmission"] = 9999001;
            else
                R["kpaymenttransmission"] = K + 1;
            return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="lista") 
				return base.SelectOne(ListingType, filter, "paymenttransmissionview", Exclude);
			return null;
		}

	}
}
