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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
//Pino: using tipoprestazione_Anagrafica; diventato inutile

namespace meta_service//meta_tipoprestazione//
{
	
	public class Meta_service : Meta_easydata
	{
		public Meta_service(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "service")
		{
			EditTypes.Add("default");
			EditTypes.Add("anagrafica");
			ListingTypes.Add("default");
			ListingTypes.Add("anagrafica");
            ListingTypes.Add("checkimport");
			Name = "Tipo Prestazione";
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				DefaultListType = "default";
				return MetaData.GetFormByDllName("service_anagrafica");//PinoRana
			}

			if (FormName=="anagrafica") {
				DefaultListType = "anagrafica";
				return MetaData.GetFormByDllName("service_anagrafica");//PinoRana
			}
			return null;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idser"], null, null, 7);
            return base.Get_New_Row(ParentRow, T);
        }
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			foreach (DataColumn C in T.Columns) 
				C.Caption="";

			if (ListingType=="default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeser", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
			if (ListingType=="anagrafica") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeser", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!codicecausale", "Causale", "motive770service.idmot", nPos++);
                DescribeAColumn(T, "active", "Flag attivo", nPos++);
			}
            if (ListingType == "checkimport")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeser", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "certificatekind", "Tipo Cert.Fiscale", nPos++);
                DescribeAColumn(T, "rec770kind", "Tipo Record", nPos++);
                DescribeAColumn(T, "allowedit", "Immissione manuale ritenute", nPos++);
            }
		}
        //codeser;description,certificatekind,rec770kind,allowedit;description",
		public override void SetDefaults(DataTable T) {
			base.SetDefaults (T);

			if (T.Columns.Contains("active")) {
				SetDefault(T, "active", "S");
				SetDefault(T, "flagapplyabatements","N");
			}
			if (T.Columns.Contains("itinerationvisible")) {
				SetDefault(T,"itinerationvisible","S");
			}
            if (T.Columns.Contains("flagnoexemptionquote")) {
            SetDefault(T, "flagnoexemptionquote", "N");
            }

            if (T.Columns.Contains("requested_doc")) {
                SetDefault(T, "requested_doc", 0);
            }
        }

	}
}
