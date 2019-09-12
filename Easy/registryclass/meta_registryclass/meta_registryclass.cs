/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
//$CustomUsing$


namespace meta_registryclass
{
    public class Meta_registryclass : Meta_easydata 
	{
        public Meta_registryclass(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryclass") {
				Name = "Tipologia fiscale";
            EditTypes.Add("anagrafica");
			//----------------------segreterie-------------------------------------------- begin
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("persone");
			ListingTypes.Add("persone");
			//----------------------segreterie-------------------------------------------- end
		}

		protected override Form GetForm(string FormName) {
	        if (FormName=="anagrafica") {
	            Name="Tipologie classificazione";
	            ActAsList();
	            Form  F = MetaData.GetFormByDllName("registryclass_anagrafica");
	            return F;
	        }
	        return null;
	    }	

	    public override void SetDefaults(DataTable T) {
	        base.SetDefaults (T);

	        SetDefault(T,"active","S");

	        SetDefault(T,"flagtitle","S");
	        SetDefault(T,"flagtitle_forced","N");
	        SetDefault(T,"flagcf","S");
	        SetDefault(T,"flagcf_forced","N");
	        SetDefault(T,"flagp_iva","S");
	        SetDefault(T,"flagp_iva_forced","N");
	        SetDefault(T,"flagqualification","S");
	        SetDefault(T,"flagqualification_forced","N");
	        SetDefault(T,"flagextmatricula","S");
	        SetDefault(T,"flagextmatricula_forced","N");
	        SetDefault(T,"flagbadgecode","S");
	        SetDefault(T,"flagbadgecode_forced","N");
	        SetDefault(T,"flagmaritalstatus","S");
	        SetDefault(T,"flagmaritalstatus_forced","N");
	        SetDefault(T,"flagforeigncf","S");
	        SetDefault(T,"flagforeigncf_forced","N");
	        SetDefault(T,"flagmaritalsurname","S");
	        SetDefault(T,"flagmaritalsurname_forced","N");
	        SetDefault(T,"flagresidence","S");
	        SetDefault(T,"flagresidence_forced","N");
	        SetDefault(T,"flagfiscalresidence","S");
	        SetDefault(T,"flagfiscalresidence_forced","N");
	        //solo visibilità
	        SetDefault(T,"flagcfbutton","S");
	        SetDefault(T,"flaginfofromcfbutton","S");
	        //non utilizzati
	        SetDefault(T,"flagothers","S");
	        SetDefault(T,"flagothers_forced","N");
	        //posto a S in quanto flagCF = 'S'
	        SetDefault(T,"flaghuman","S");
	    }

		//----------------------segreterie-------------------------------------------- begin

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idregistryclass"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idregistryclass"], 9990000);
			//$Get_New_Row$
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (R.Table.Columns.Contains("description") && R["description"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Descrizione' è obbligatorio";
				errfield = "description";
				return false;
			}
			if (R.Table.Columns.Contains("description") && R["description"].ToString().Trim().Length > 150) {
				errmess = "Attenzione! Il campo 'Descrizione' può essere al massimo di 150 caratteri";
				errfield = "description";
				return false;
			}
			if (R.Table.Columns.Contains("flagbadgecode") && R["flagbadgecode"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice badge visibile' è obbligatorio";
				errfield = "flagbadgecode";
				return false;
			}
			if (R.Table.Columns.Contains("flagbadgecode_forced") && R["flagbadgecode_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice badge obbligatorio' è obbligatorio";
				errfield = "flagbadgecode_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagCF") && R["flagCF"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice fiscale visibile' è obbligatorio";
				errfield = "flagCF";
				return false;
			}
			if (R.Table.Columns.Contains("flagcf_forced") && R["flagcf_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice fiscale obbligatorio' è obbligatorio";
				errfield = "flagcf_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagextmatricula") && R["flagextmatricula"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Matricola esterna visibile' è obbligatorio";
				errfield = "flagextmatricula";
				return false;
			}
			if (R.Table.Columns.Contains("flagextmatricula_forced") && R["flagextmatricula_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Matricola esterna obbligatoria' è obbligatorio";
				errfield = "flagextmatricula_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagfiscalresidence") && R["flagfiscalresidence"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Campo residenza visibile' è obbligatorio";
				errfield = "flagfiscalresidence";
				return false;
			}
			if (R.Table.Columns.Contains("flagfiscalresidence_forced") && R["flagfiscalresidence_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'inserimento residenza obbligatorio' è obbligatorio";
				errfield = "flagfiscalresidence_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagforeigncf") && R["flagforeigncf"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice fiscale estero visibile' è obbligatorio";
				errfield = "flagforeigncf";
				return false;
			}
			if (R.Table.Columns.Contains("flagforeigncf_forced") && R["flagforeigncf_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice fiscale estero obbligatorio' è obbligatorio";
				errfield = "flagforeigncf_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagmaritalstatus") && R["flagmaritalstatus"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Campo stato civile visibile' è obbligatorio";
				errfield = "flagmaritalstatus";
				return false;
			}
			if (R.Table.Columns.Contains("flagmaritalstatus_forced") && R["flagmaritalstatus_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Campo stato civile obbligatorio' è obbligatorio";
				errfield = "flagmaritalstatus_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagmaritalsurname") && R["flagmaritalsurname"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Cognome acquisito visibile' è obbligatorio";
				errfield = "flagmaritalsurname";
				return false;
			}
			if (R.Table.Columns.Contains("flagmaritalsurname_forced") && R["flagmaritalsurname_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Cognome acquisito obbligatorio' è obbligatorio";
				errfield = "flagmaritalsurname_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagothers") && R["flagothers"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'campo non usato' è obbligatorio";
				errfield = "flagothers";
				return false;
			}
			if (R.Table.Columns.Contains("flagothers_forced") && R["flagothers_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'campo non usato' è obbligatorio";
				errfield = "flagothers_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagp_iva") && R["flagp_iva"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Partita iva visibile' è obbligatorio";
				errfield = "flagp_iva";
				return false;
			}
			if (R.Table.Columns.Contains("flagp_iva_forced") && R["flagp_iva_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Partita iva obbligatoria' è obbligatorio";
				errfield = "flagp_iva_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagqualification") && R["flagqualification"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'campo \"Titolo\" visibile' è obbligatorio";
				errfield = "flagqualification";
				return false;
			}
			if (R.Table.Columns.Contains("flagqualification_forced") && R["flagqualification_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'campo \"Titolo\" obbligatorio' è obbligatorio";
				errfield = "flagqualification_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagresidence") && R["flagresidence"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Usato congiuntamente a flagresidence_forced per stabilire se l'indirizzo di residenza è obbligatorio, Da solo non ha un gran significato poiché non esiste un campo indirizzo di residenza' è obbligatorio";
				errfield = "flagresidence";
				return false;
			}
			if (R.Table.Columns.Contains("flagresidence_forced") && R["flagresidence_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Informazioni sulla residenza obbligatorie' è obbligatorio";
				errfield = "flagresidence_forced";
				return false;
			}
			if (R.Table.Columns.Contains("flagtitle") && R["flagtitle"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Campo Denominazione diverso da cognome+nome, inserito manualmente' è obbligatorio";
				errfield = "flagtitle";
				return false;
			}
			if (R.Table.Columns.Contains("flagtitle_forced") && R["flagtitle_forced"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Non usato, il campo denominazione  è sempre obbligatorio in un modo o nell'altro' è obbligatorio";
				errfield = "flagtitle_forced";
				return false;
			}
			if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim() == "") {
				errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
				errfield = "idregistryclass";
				return false;
			}
			if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
				errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 2 caratteri";
				errfield = "idregistryclass";
				return false;
			}
			//$IsValid$

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idregistryclass", "Codice", nPos++);
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "flagbadgecode", "Codice badge visibile", nPos++);
						DescribeAColumn(T, "active", "Attivo", nPos++);
						DescribeAColumn(T, "flagbadgecode_forced", "Codice badge obbligatorio", nPos++);
						DescribeAColumn(T, "flagCF", "Codice fiscale visibile", nPos++);
						DescribeAColumn(T, "flagcf_forced", "Codice fiscale obbligatorio", nPos++);
						DescribeAColumn(T, "flagcfbutton", "Bottone \"calcola codice fiscale\" visibile", nPos++);
						DescribeAColumn(T, "flagextmatricula", "Matricola esterna visibile", nPos++);
						DescribeAColumn(T, "flagextmatricula_forced", "Matricola esterna obbligatoria", nPos++);
						DescribeAColumn(T, "flagfiscalresidence", "Campo residenza visibile", nPos++);
						DescribeAColumn(T, "flagfiscalresidence_forced", "inserimento residenza obbligatorio", nPos++);
						DescribeAColumn(T, "flagforeigncf", "Codice fiscale estero visibile", nPos++);
						DescribeAColumn(T, "flagforeigncf_forced", "Codice fiscale estero obbligatorio", nPos++);
						DescribeAColumn(T, "flaghuman", "Persona fisica", nPos++);
						DescribeAColumn(T, "flaginfofromcfbutton", "Bottone \"Comune, Data da C.F.\" visibile", nPos++);
						DescribeAColumn(T, "flagmaritalstatus", "Campo stato civile visibile", nPos++);
						DescribeAColumn(T, "flagmaritalstatus_forced", "Campo stato civile obbligatorio", nPos++);
						DescribeAColumn(T, "flagmaritalsurname", "Cognome acquisito visibile", nPos++);
						DescribeAColumn(T, "flagmaritalsurname_forced", "Cognome acquisito obbligatorio", nPos++);
						DescribeAColumn(T, "flagothers", "campo non usato", nPos++);
						DescribeAColumn(T, "flagothers_forced", "campo non usato", nPos++);
						DescribeAColumn(T, "flagp_iva", "Partita iva visibile", nPos++);
						DescribeAColumn(T, "flagp_iva_forced", "Partita iva obbligatoria", nPos++);
						DescribeAColumn(T, "flagqualification", "campo \"Titolo\" visibile", nPos++);
						DescribeAColumn(T, "flagqualification_forced", "campo \"Titolo\" obbligatorio", nPos++);
						DescribeAColumn(T, "flagresidence", "Usato congiuntamente a flagresidence_forced per stabilire se l'indirizzo di residenza è obbligatorio, Da solo non ha un gran significato poiché non esiste un campo indirizzo di residenza", nPos++);
						DescribeAColumn(T, "flagresidence_forced", "Informazioni sulla residenza obbligatorie", nPos++);
						DescribeAColumn(T, "flagtitle", "Campo Denominazione diverso da cognome+nome, inserito manualmente", nPos++);
						DescribeAColumn(T, "flagtitle_forced", "Non usato, il campo denominazione  è sempre obbligatorio in un modo o nell'altro", nPos++);
						break;
					}
				case "persone": {
						DescribeAColumn(T, "idregistryclass", "Codice", nPos++);
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "active", "Attivo", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//----------------------segreterie-------------------------------------------- end

	}
}
