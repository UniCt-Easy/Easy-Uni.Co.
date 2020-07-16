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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//using liquidazioneritenuta;
//using liquidazioneritenuta_dapagare;
//using liquidazioneritenutaperiodica;

namespace meta_taxpay//meta_liquidazioneritenuta//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_taxpay : Meta_easydata 
	{
		public Meta_taxpay(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxpay") 
		{
			//EditTypes.Add("default");
			EditTypes.Add("wiz_liquidperiodica");
			ListingTypes.Add("default");
			EditTypes.Add("ritenutedapagare");
			Name = "";
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name="Liquidazione delle ritenute gi‡ effettuate (storico)";
				return GetFormByDllName("taxpay_default");
				//return new frmliquidazioneritperiodica();
			}

			if (FormName=="wiz_liquidperiodica") 
			{
				DefaultListType="default";
				Name = "Calcolo liquidazione periodica";
				return GetFormByDllName("taxpay_wiz_liquidperiodica");
				//frmliquidazioneritenuta F = new frmliquidazioneritenuta();
				//return F;
			}

			if (FormName=="ritenutedapagare")
			{
				DefaultListType="default";
				Name = "Ritenute non ancora liquidate";
				return GetFormByDllName("taxpay_ritenutedapagare");
				//return new frmliquidazioneritenuta_dapagare();
			}
			return null;
		}		

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T, "ytaxpay");
			RowChange.MarkAsAutoincrement(T.Columns["ntaxpay"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ytaxpay", GetSys("esercizio").ToString());
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
		}
		
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "taxpayview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "taxpay", Exclude);
		}	
	}
}
