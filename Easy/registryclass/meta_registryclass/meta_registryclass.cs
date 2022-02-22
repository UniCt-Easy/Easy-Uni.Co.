
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
				case "aziende": {
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
