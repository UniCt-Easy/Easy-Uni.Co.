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

namespace meta_exhibitedcud {//meta_cudpresentato//
	/// <summary>
	/// Summary description for Meta_cudpresentato.
	/// </summary>
	public class Meta_exhibitedcud : Meta_easydata {
		public Meta_exhibitedcud(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "exhibitedcud") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				Name="CUD Presentato";
				DefaultListType="default";
				return GetFormByDllName("exhibitedcud_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "fiscalyear", GetSys("esercizio"));
			SetDefault(PrimaryTable, "start", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "stop", GetSys("datacontabile"));
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			decimal imponibilePrevidenziale = CfgFn.GetNoNullDecimal(R["taxablepension"]);
			if (imponibilePrevidenziale < 0) {
				errmess = "L'imponibile Previdenziale non può essere negativo";
				errfield = "taxablepension";
				return false;
			}
			decimal imponibileFiscaleLordo = CfgFn.GetNoNullDecimal(R["taxablegross"]);
			if (imponibileFiscaleLordo < 0) {
				errmess = "L'imponibile Fiscale Lordo non può essere negativo";
				errfield = "taxablenet";
				return false;
			}
			if (imponibilePrevidenziale < imponibileFiscaleLordo) {
				errmess = "L'imponibile previdenziale deve essere maggiore o uguale all'imponibile fiscale lordo";
				errfield = "imponibilefiscalelordo";
				return false;
			}

			if (R["cfotherdeputy"].ToString().Trim() == "") {
				errmess = "Attenzione! Bisogna specificare il codice fiscale del sostituto";
				errfield = "cfotherdeputy";
				return false;
			}

			string errori;
			int lunghezzaCF = R["cfotherdeputy"].ToString().Length;
			if ((lunghezzaCF != 11) && (lunghezzaCF != 16)) {
				errmess = "La lunghezza del Codice Fiscale è errata, essa deve essere di 11 o 16 caratteri";
				errfield = "cfotherdeputy";
				return false;
			}

			if (lunghezzaCF == 16) {
				CalcolaCodiceFiscale.CheckCF(R["cfotherdeputy"].ToString().ToUpper(),out errori);
				if (errori != "") {
					errmess = "Nel codice fiscale inserito compaiono i seguenti errori:\n\r " + errori;
					errfield = "cfotherdeputy";
					return false;
				}
			}

            // Il controllo lo faccio sul DBNull in quanto se metto ZERO volutamente devo specificare la regione fiscale
            if (((R["regionaltaxapplied"] != DBNull.Value) || (R["suspendedregionaltax"] != DBNull.Value))
             && (R["idfiscaltaxregion"] == DBNull.Value)){
                    errmess = "Bisogna specificare la regione fiscale alla quale si è versata l'addizionale regionale";
                    errfield = "idfiscaltaxregion";
                    return false;
            }

            // Il controllo lo faccio sul DBNull in quanto se metto ZERO volutamente devo specificare la regione fiscale
            if (((R["citytax_account"] != DBNull.Value) || (R["citytaxapplied"] != DBNull.Value)
                || (R["suspendedcitytax"] != DBNull.Value))
            && (R["idcity"] == DBNull.Value)){
                    errmess = "Bisogna specificare il comune al quale si è versata l'addizionale comunale e/o l'acconto";
                    errfield = "idcity";
                    return false;
            }

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idcon","");
                DescribeAColumn(T, "idlinkedcon", "Rif.contratto");
				DescribeAColumn(T,"idexhibitedcud","Num. Collab.");
				DescribeAColumn(T,"start","Data Inizio Collab.");
				DescribeAColumn(T,"stop","Data Fine Collab.");
				DescribeAColumn(T,"nmonths","Num. Mesi");
				DescribeAColumn(T,"flagignoreprevcud","Ignora CUD Precedenti");
				DescribeAColumn(T,"cfotherdeputy","CF altro sostituto");
				DescribeAColumn(T,"transfermotive","Causa Passaggio");
				DescribeAColumn(T,"taxablepension","Impon. Previdenziale");
				DescribeAColumn(T,"taxablenet","Impon. Fiscale Netto");
				DescribeAColumn(T,"irpefapplied","Imposte IRPEF Applicate");
				DescribeAColumn(T,"irpefsuspended","Imposte IRPEF Sospese");
				DescribeAColumn(T,"regionaltaxapplied","Add. Regionali Applicate");
				DescribeAColumn(T,"suspendedregionaltax","Add. Regionali Sospese");
				DescribeAColumn(T,"citytaxapplied","Add. Comunali Applicate");
				DescribeAColumn(T,"suspendedcitytax","Add. Comunali Sospese");
				DescribeAColumn(T,"fiscalyear","Anno Fiscale");
				DescribeAColumn(T,"inpsowed","Contributi dovuti");
				DescribeAColumn(T,"inpsretained","Contributi trattenuti");
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"idcon");
			RowChange.MarkAsAutoincrement(T.Columns["idexhibitedcud"],null,null,4);
            DataRow R = base.Get_New_Row(ParentRow, T);
            //Ricalcola l'id facendo in modo che sia molto alto
            int N = MetaData.MaxFromColumn(T, "idexhibitedcud");
            if (N < 9900)
                R["idexhibitedcud"] = 9900;
            else
                R["idexhibitedcud"] = N + 1;
            return R;
        }
    }
}