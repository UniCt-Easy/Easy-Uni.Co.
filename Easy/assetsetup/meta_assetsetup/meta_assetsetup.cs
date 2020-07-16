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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_assetsetup
{
	/// <summary>
	/// Summary description for perspatrimonio.
	/// </summary>
	public class Meta_assetsetup : Meta_easydata 
	{
		public Meta_assetsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "assetsetup") {		
			EditTypes.Add("default");
            EditTypes.Add("creaxml");
            EditTypes.Add("uniforma");
            EditTypes.Add("settransmitted");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName){
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Configurazione";
                return MetaData.GetFormByDllName("assetsetup_default");
            }
            if (FormName == "creaxml") {
                DefaultListType = "default";
                Name = "Esporta Dati Ufficiali in file XML";
                return MetaData.GetFormByDllName("assetsetup_creaxml");
            }
            if (FormName == "uniforma") {
                DefaultListType = "default";
                Name = "Uniformazione dei dati di configurazione";
                return MetaData.GetFormByDllName("assetsetup_uniformadati");
            }
            if (FormName == "settransmitted") {
                DefaultListType = "default";
                Name = "Set del flag transmitted a S per cespiti gi‡ esportati";
                return GetFormByDllName("assetsetup_impostatransmitted");
            }
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear", GetSys("esercizio"));
			SetDefault(PrimaryTable,"flagmotive", "N");
			SetDefault(PrimaryTable,"flagregistry", "N");
			SetDefault(PrimaryTable,"flagrestart", "S");
			SetDefault(PrimaryTable,"linktoinvoice", "N");
		}
	

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				DescribeAColumn(T,"ayear","Esercizio");
				DescribeAColumn(T,"flagmotive","Flag causale");
				DescribeAColumn(T,"flagregistry","Flag Creditore/Debitore");
				DescribeAColumn(T,"flagnumbering","Flag numerazione");
				DescribeAColumn(T,"flagrestart","Flag Esercizio");
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			base.IsValid (R, out errmess, out errfield);

			if (R["flagnumbering"].ToString()=="" || R["flagnumbering"].ToString()=="N") {
				errmess="Specificare il tipo di numerazione";
				errfield="flagnumbering";
				return false;
			}
			return true;
		}

	}
	
}
