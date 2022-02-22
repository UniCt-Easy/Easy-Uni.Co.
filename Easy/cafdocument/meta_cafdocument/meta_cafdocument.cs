
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace meta_cafdocument//meta_comunicazionedacaf//
{
	/// <summary>
	/// Summary description for Meta_comunicazionedacaf.
	/// </summary>
	public class Meta_cafdocument : Meta_easydata
	{
		public Meta_cafdocument(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "cafdocument") {
			EditTypes.Add("contratto");
			ListingTypes.Add("contratto");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				Name="Comunicazioni da CAF";
				DefaultListType="contratto";
				return GetFormByDllName("cafdocument_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			// N.B. Se dovesse cambiare la legge che attualmente vieta la rateizzazione della seconda rata di Acconto IRPEF
			// bisogna commentare il SetDefault seguente e modificare nel form contratto la proprietà READONLY della text box
			// che riceve questo valore a false
			SetDefault(PrimaryTable,"nquotasecondinstalment",1);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"idcon");
			RowChange.MarkAsAutoincrement(T.Columns["idcafdocument"],null,null,4);
			return base.Get_New_Row(ParentRow, T);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			DataRow rParent = PrimaryDataTable.Rows[0];
			DataTable ParentTable = SourceRow.Table;
			string filtroContratto = "(idcon=" + QueryCreator.quotedstrvalue(R["idcon"],false) + ")";
			DataRow rCafDiContratto = ParentTable.Select(filtroContratto)[0];
			DataRow rContratto = rCafDiContratto.GetParentRow("parasubcontractcafdocument");

			DateTime dataInizio = (DateTime) rContratto["start"];
			DateTime dataFine = (DateTime) rContratto["stop"];

			DateTime datamin = (dataInizio.Year == (int)R["ayear"]) ? dataInizio : new DateTime((int)R["ayear"],1,1);
			DateTime datamax = (dataFine.Year == (int)R["ayear"]) ? dataFine : new DateTime((int)R["ayear"],12,31);

			if ((CfgFn.GetNoNullDecimal(R["irpeftoretain"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["irpeftorefund"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["regionaltaxtoretain"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["regionaltaxtorefund"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["regionaltaxtoretainhusband"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["regionaltaxtorefundhusband"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["citytaxtoretain"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["citytaxtorefund"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["citytaxtoretainhusband"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["citytaxtorefundhusband"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["separatedincome"]) > 0)||
				(CfgFn.GetNoNullDecimal(R["separatedincomehusband"]) > 0) ||
                (CfgFn.GetNoNullDecimal(R["citytaxaccount"]) > 0)||
                (CfgFn.GetNoNullDecimal(R["citytaxaccounthusband"]) > 0)
				) {
				// Il numero di rate non può essere nullo o pari a zero
				if (CfgFn.GetNoNullInt32(R["ratequantity"]) <= 0) {
					errmess = "Inserire il numero di rate di pagamento delle addizionali";
					errfield = "ratequantity";
					return false;
				}
				
				// Il mese di inizio non può essere nullo
				if (CfgFn.GetNoNullInt32(R["startmonth"]) <= 0) {
					errmess = "Inserire il mese da cui iniziare a pagare le rate delle addizionali";
					errfield = "startmonth";
					return false;
				}
				
				// Il mese di inizio deve cadere nel range di esistenza del contratto
				if (CfgFn.GetNoNullInt32(R["startmonth"]) < datamin.Month) {
					errmess = "Il mese da cui si intende cominciare a pagare le rate delle addizionali è inferiore alla data inizio del contratto";
					errfield = "startmonth";
					return false;
				}

				if (CfgFn.GetNoNullInt32(R["startmonth"]) > datamax.Month) {
					errmess = "Il mese da cui si intende cominciare a pagare le rate delle addizionali è superiore alla data di fine del contratto";
					errfield = "startmonth";
					return false;
				}

				// Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno solare
				if (CfgFn.GetNoNullInt32(R["startmonth"]) + CfgFn.GetNoNullInt32(R["ratequantity"]) - 1 > datamax.Month) {
					errmess = "Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno fiscale";
					errfield = "ratequantity";
					return false;
				}
			}

			if (CfgFn.GetNoNullDecimal(R["firstrateadvance"]) > 0) {
				// Il numero di rate non può essere nullo o pari a zero
				if (CfgFn.GetNoNullInt32(R["nquotafirstinstalment"]) <= 0) {
					errmess = "Inserire il numero di rate di pagamento della prima rata di acconto IRPEF";
					errfield = "nquotafirstinstalment";
					return false;
				}
				
				// Il mese di inizio non può essere nullo
				if (CfgFn.GetNoNullInt32(R["monthfirstinstalment"]) <= 0) {
					errmess = "Inserire il mese da cui iniziare a pagare le rate della prima rata di acconto IRPEF";
					errfield = "monthfirstinstalment";
					return false;
				}
				
				// Il mese di inizio deve cadere nel range di esistenza del contratto
				if (CfgFn.GetNoNullInt32(R["monthfirstinstalment"]) < datamin.Month) {
					errmess = "Il mese da cui si intende cominciare a pagare le rate della prima rata di acconto IRPEF è inferiore alla data inizio del contratto";
					errfield = "monthfirstinstalment";
					return false;
				}

				if (CfgFn.GetNoNullInt32(R["monthfirstinstalment"]) > datamax.Month) {
					errmess = "Il mese da cui si intende cominciare a pagare le rate della prima rata di acconto IRPEF è superiore alla data di fine del contratto";
					errfield = "monthfirstinstalment";
					return false;
				}

				// Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno solare
				if (CfgFn.GetNoNullInt32(R["monthfirstinstalment"]) + CfgFn.GetNoNullInt32(R["nquotafirstinstalment"]) - 1 > datamax.Month) {
					errmess = "Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno fiscale";
					errfield = "nquotafirstinstalment";
					return false;
				}
			}

			if (CfgFn.GetNoNullDecimal(R["secondrateadvance"]) > 0) {
				// Il numero di rate non può essere nullo o pari a zero
				if (CfgFn.GetNoNullInt32(R["nquotasecondinstalment"]) <= 0) {
					errmess = "Inserire il numero di rate di pagamento della seconda rata di acconto IRPEF";
					errfield = "nquotasecondinstalment";
					return false;
				}
				
				// Il mese di inizio non può essere nullo
				if (CfgFn.GetNoNullInt32(R["monthsecondinstalment"]) <= 0) {
					errmess = "Inserire il mese da cui iniziare a pagare le rate della seconda rata di acconto IRPEF";
					errfield = "monthsecondinstalment";
					return false;
				}
				
				// Il mese di inizio deve cadere nel range di esistenza del contratto
				if (CfgFn.GetNoNullInt32(R["monthsecondinstalment"]) < datamin.Month) {
					errmess = "Il mese da cui si intende cominciare a pagare le rate della seconda rata di acconto IRPEF è inferiore alla data inizio del contratto";
					errfield = "monthsecondinstalment";
					return false;
				}

				if (CfgFn.GetNoNullInt32(R["monthsecondinstalment"]) > datamax.Month) {
					errmess = "Il mese da cui si intende cominciare a pagare le rate della seconda rata di acconto IRPEF è superiore alla data di fine del contratto";
					errfield = "monthsecondinstalment";
					return false;
				}

				// Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno solare
				if (CfgFn.GetNoNullInt32(R["monthsecondinstalment"]) + CfgFn.GetNoNullInt32(R["nquotasecondinstalment"]) - 1 > datamax.Month) {
					errmess = "Le rate devono essere pagate entro la fine del contratto e comunque entro l'anno fiscale";
					errfield = "nquotasecondinstalment";
					return false;
				}
			}

            DateTime docDate = (DateTime)R["docdate"];
            if (docDate > datamax) {
                errfield = "docdate";
                errmess = "La data della comunicazione da C.A.F. deve ricadere nel periodo di competenza del contratto " +
                    " quindi deve essere precedente o al più uguale a " + datamax.ToString("dd/MM/yyyy");
                return false;
            }

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "contratto") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"idcafdocument","Num. Comunicazione");
				DescribeAColumn(T,"docdate","Data Comunicazione");
				DescribeAColumn(T,"!descrcomunicazione","Tipo Comunicazione","tipocomunicazione.descrizione");
			}

		}

	}
}
