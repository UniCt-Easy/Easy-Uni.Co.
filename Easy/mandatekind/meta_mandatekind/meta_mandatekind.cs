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
using System.Text.RegularExpressions;
using funzioni_configurazione;

namespace meta_mandatekind {
	/// <summary>
	/// Summary description for meta_mandatekind.
	/// </summary>
	public class Meta_mandatekind: Meta_easydata {
		public Meta_mandatekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mandatekind"){		
			EditTypes.Add("default");
            EditTypes.Add("associa");
			ListingTypes.Add("default");
            ListingTypes.Add("richiesta");
            ListingTypes.Add("lista");
            Name = "Tipo contratto passivo";
		}
		
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
                Name = "Tipo di Contratto Passivo"; 
				return GetFormByDllName("mandatekind_default");
			}
            if (FormName == "associa")
            {
                Name = "Associa Tipo di Contratto Passivo a Richiesta d'Acquisto";
                return GetFormByDllName("mandatekind_associa");
            }
			return null;
		}

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "flagactivity", 4);
            SetDefault(T, "linktoasset", "S");
            SetDefault(T, "linktoinvoice", "S");
            SetDefault(T, "multireg", "N");
            SetDefault(T, "isrequest", "N");
            SetDefault(T, "active", "S");
            SetDefault(T, "flag_autodocnumbering", "N");
            SetDefault(T, "flag", 0);
            SetDefault(T, "touniqueregister", "N");
            SetDefault(T, "flagcreatedoubleentry", "N");
            SetDefault(T, "requested_doc", 0);
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T,"idmankind", "Codice", nPos++);
				DescribeAColumn(T,"description", "Descrizione", nPos++);
                //DescribeAColumn(T, "!codeupb", "U.P.B.", "upb.codeupb", nPos++);
				DescribeAColumn(T, "office", "Ufficio", nPos++);
				DescribeAColumn(T, "phonenumber", "Telefono", nPos++);
				DescribeAColumn(T, "faxnumber", "Fax", nPos++);
				DescribeAColumn(T, "email", "E-Mail", nPos++);
				
				DescribeAColumn(T, "linktoinvoice", "Fattura", nPos++);
				DescribeAColumn(T, "linktoasset", "Carico cespite", nPos++);
				DescribeAColumn(T, "multireg", "Anagrafe", nPos++);
                DescribeAColumn(T, "ipa_fe", "IPA", nPos++);
                DescribeAColumn(T, "riferimento_amministrazione", "Riferimento Amministrazione", nPos++);
			}
            if (ListingType == "lista"){
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "description", "Contratto Passivo", nPos++);
            }
            if (ListingType == "richiesta")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idmankind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Contratto Passivo", nPos++);
            }
            
            
		}
      
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest)
        {
            if (C.ColumnName == "idmankind")   return;
            base.InsertCopyColumn(C, Source, Dest);
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if (R["email"].ToString().Trim() != "") {
				Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
				string s = R["email"].ToString();

				Match m = emailregex.Match(s);

				if (!m.Success) {
					errfield = "email";
					errmess = "Inserire correttamente l'indirizzo email nel seguente formato: userid@dominio.organizzazione";
					return false;
				}
			}
			decimal deltapercentage = CfgFn.GetNoNullDecimal(R["deltapercentage"]);
			if (deltapercentage <0 || deltapercentage>1) {
				errmess="Percentuale non valida";
				errfield="deltapercentage";
				return false;
			}
			decimal deltaamount = CfgFn.GetNoNullDecimal(R["deltaamount"]);
			if (deltaamount <0) {
				errmess="Importo non valido";
				errfield="deltaamount";
				return false;
			}

            if (R["isrequest"].ToString().ToUpper() == "S") {
                if (R["linktoinvoice"].ToString() != "N") {
                    errmess = "Una richiesta d'ordine non Ë associabile a fattura";
                    errfield = "linktoinvoice";
                    return false;
                }
                if (R["linktoasset"].ToString() != "N") {
                    errmess = "Una richiesta d'ordine non Ë utilizzabile con il carico cespite";
                    errfield = "linktoasset";
                    return false;
                }
                if (R["multireg"].ToString() != "N") {
                    errmess = "Una richiesta d'ordine non puÚ avere l'anagrafe nel dettaglio";
                    errfield = "multireg";
                    return false;
                }
            }
			return true;
		}
	}
}