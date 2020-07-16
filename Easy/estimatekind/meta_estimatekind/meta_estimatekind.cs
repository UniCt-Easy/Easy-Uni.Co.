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
using metadatalibrary;
using metaeasylibrary;
using System.Text.RegularExpressions;
using funzioni_configurazione;

namespace meta_estimatekind {
	/// <summary>
	/// Summary description for meta_estimatekind.
	/// </summary>
	public class Meta_estimatekind: Meta_easydata {
		public Meta_estimatekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "estimatekind"){		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
		}
		
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name="Tipo di Contratto attivo";
				return GetFormByDllName("estimatekind_default");
			
			}
			return null;
		}
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "active", "S");
            SetDefault(T, "flag", 0);
            }

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest)
        {
            if (C.ColumnName == "idestimkind") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T,"idestimkind", "Codice", nPos++);
				DescribeAColumn(T,"description", "Descrizione", nPos++);
                //DescribeAColumn(T, "!codeupb", "U.P.B.", "upb.codeupb", nPos++);
				DescribeAColumn(T, "office", "Ufficio", nPos++);
				DescribeAColumn(T, "phonenumber", "Telefono", nPos++);
				DescribeAColumn(T, "faxnumber", "Fax", nPos++);
				DescribeAColumn(T, "email", "E-Mail", nPos++);
				DescribeAColumn(T, "linktoinvoice", "Fattura", nPos++);
				DescribeAColumn(T, "multireg", "Anagrafe", nPos++);

			}
            if (ListingType == "lista"){
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "description", "Contratto Attivo", nPos++);
            }

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
			return true;
		}
	}
}