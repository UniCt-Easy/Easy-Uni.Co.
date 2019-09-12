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
using metaeasylibrary;
using metadatalibrary;
using System.Data;
//Pino: using geo_comune; diventato inutile
using System.Windows.Forms;

namespace meta_geo_importazione_dati//meta_geo_importazione_dati//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_geo_importazione_dati : Meta_easydata
	{
		public Meta_geo_importazione_dati(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "geo_importazione_dati") 
		{		
			Name="Importazione comuni";
			ListingTypes.Add("default");
			EditTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				DescribeAColumn(T,"idente","id. ente");
				DescribeAColumn(T,"idcodice","id. codice");
				DescribeAColumn(T,"nome_importazione","nome importazione");
				DescribeAColumn(T,"tabella_sorgente","tabella sorgente");
				DescribeAColumn(T,"cln_valore1","cln valore1");
				DescribeAColumn(T,"cln_valore2","cln valore2");
				DescribeAColumn(T,"cln_chiave","cln chiave");
				DescribeAColumn(T,"cln_denominazione","cln denominazione");
				DescribeAColumn(T,"cln_id_provincia","cln id. provincia");
				DescribeAColumn(T,"cln_sigla_provincia","cln. sigla provincia");
				DescribeAColumn(T,"cln_data_inizio","cln data inizio");
				DescribeAColumn(T,"cln_chiave","cln chiave");
				DescribeAColumn(T,"cln_data_fine","cln data fine");
				DescribeAColumn(T,"cln_istat","cln istat");
				DescribeAColumn(T,"cln_nazionale","cln nazionale");
				DescribeAColumn(T,"cln_catastale","cln catastale");
				DescribeAColumn(T,"cln_cap","cln cap");
			}
			return;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.MarkAsAutoincrement(T.Columns["chiave"],null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				ActAsList();
				return MetaData.GetFormByDllName("geo_city_default");//PinoRana
			}
			return null;
		}			
	}
}
